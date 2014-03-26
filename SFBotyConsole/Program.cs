using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFBotyCore.Mechanic;
using SFBotyCore.Mechanic.Account;
using SFBotyCore.Mechanic.Areas;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Xml.Serialization;
using System.Globalization;
using SFBotyCore;

namespace SFBotyConsole {
	class Program {

		static void Main(string[] args) {
			ChatLogs = new Dictionary<string, HashSet<string>>();

			List<AccountSettings> accountSettings = new List<AccountSettings>();
			accountSettings = LoadSettings();

			List<Account> accounts = new List<Account>();
			accountSettings.ForEach(s => accounts.Add(new Account(s)));

			List<Bot> bots = new List<Bot>();
			foreach (Account a in accounts) {
				Bot bot = new Bot(a);
				bot.MessageOutput += new EventHandler<MessageEventsArgs>(bot_MessageOutput);
				bot.ExtendedLog += new EventHandler<MessageEventsArgs>(bot_ExtendedLog);
				bot.Error += new EventHandler<MessageEventsArgs>(bot_Error);

				bot.AddMenu(new LoginArea());
				bot.AddMenu(new MagicShopArea());
				bot.AddMenu(new BlacksmithArea());
				bot.AddMenu(new MountArea());
				bot.AddMenu(new TavernArea());
				bot.AddMenu(new ToiletArea());
				bot.AddMenu(new ArenaArea());
				bot.AddMenu(new GuildArea());
				bot.AddMenu(new CharScreenArea());
				bot.AddMenu(new DungeonArea());
				bot.AddMenu(new StadtwacheArea());

				bots.Add(bot);
			}

			Console.WriteLine(DateTime.Now.ToString() + ": Bot wurde gestartet");
			ClearLogs();

			bots.ForEach(b => b.Run());

			string command = "";
			while (command != "exit") {
				command = Console.ReadLine();

				switch (command.ToLower()) {
					case "exit":
						bots.ForEach(b => b.Stop());
						break;
					case "help":
						Console.WriteLine("Folgende Befehlt gibt es: exit, sleep, help");
						break;
					case "sleep":
						Console.WriteLine("use: [sleep]_[server]_[user]_[timeMinute]");
						break;
					default:
						Console.WriteLine("Ungültiger Befehl versuche es mit dem Befehl \"help\"");
						break;
				}

				if (command.StartsWith("sleep ")) {
					string[] commandParts = command.Split(' ');
					if (commandParts.Count() == 4) {
						List<Bot> tmp = bots.Where(b => b.Account.Settings.Username.ToLower() == commandParts[2].ToLower() && b.Account.Settings.Server.ToLower() == commandParts[1].ToLower()).ToList();
						if (tmp.Count > 0) {
							Bot bot = tmp.First();
							if (bot != null) {
								bot.Break(Convert.ToSingle(commandParts[3]) * 60f);
								Console.WriteLine(string.Concat("Bot ", bot.Account.Settings.Server, " ", bot.Account.Settings.Username, " unterbricht"));
							}
						}
					}
				}
			}
		}

		private static List<AccountSettings> LoadSettings() {
			if (File.Exists("acc.sav")) {
				FileStream fs = new FileStream("acc.sav", FileMode.Open);
				List<AccountSettings> acc;

				XmlSerializer xml = new XmlSerializer(typeof(List<AccountSettings>));
				acc = (List<AccountSettings>)xml.Deserialize(fs);
				fs.Close();

				return acc;
			} else {
				return new List<AccountSettings>();
			}
		}

		private static void SaveSettings(List<AccountSettings> accounts) {
			TextWriter writer = new StreamWriter("acc.sav");

			XmlSerializer xml = new XmlSerializer(accounts.GetType());
			xml.Serialize(writer, accounts);

			writer.Close();
		}

		private static Dictionary<string, HashSet<string>> ChatLogs;
		private static void LogChatHistory(Bot bot, MessageEventsArgs e) {
			string key = String.Concat(bot.Account.Settings.Username, bot.Account.Settings.Server);
			List<string> chatLines = e.Message.Split('\n').Select(x => x.Trim()).ToList();

			if (!ChatLogs.Keys.Any(x => x == key)) {
				ChatLogs.Add(key, new HashSet<string>());
			}

			if (ChatLogs[key] == null) {
				ChatLogs[key] = new HashSet<string>();
			}

			List<string> newChatLines = chatLines.Where(x => !x.Contains(ChatLogs[key].ToList())).ToList();

			for (int i = chatLines.Count() - 1; i >= 0; i--) {
				ChatLogs[key].Add(chatLines[i]);
			}

			if (newChatLines.Count() > 0) {
				if (!System.IO.Directory.Exists("Logs")) {
					System.IO.Directory.CreateDirectory("Logs");
				}

				CultureInfo culture = new CultureInfo("de-DE");

				System.IO.StreamWriter writer = new System.IO.StreamWriter(String.Concat("Logs/", bot.Account.Settings.Server, "-", bot.Account.Settings.Username, "-chatlog-", DateTime.Now.ToString(culture).Remove(DateTime.Now.ToString(culture).Length - 9), ".log"), true);
				for (int i = newChatLines.Count() - 1; i >= 0; i--) {
					writer.WriteLine(newChatLines[i]);
					Console.WriteLine(string.Concat(DateTime.Now.ToString(), " " + bot.Account.Settings.Username, "(", bot.Account.Settings.Server, ") Chat: ", newChatLines[i]));
				}

				writer.Close();
				writer.Dispose();
			}

			while (ChatLogs[key].Count > 20) {
				ChatLogs[key].Remove(ChatLogs[key].First());
			}
		}

		static void bot_MessageOutput(object sender, MessageEventsArgs e) {
			Bot tmp = (Bot)sender;

			if (e.IsChatHistory) {
				LogChatHistory(tmp, e);
				return; //ja ich habe mir den else Zweig gespart
			}

			if (!System.IO.Directory.Exists("Logs")) {
				System.IO.Directory.CreateDirectory("Logs");
			}

			CultureInfo culture = new CultureInfo("de-DE");

			System.IO.StreamWriter writer = new System.IO.StreamWriter(String.Concat("Logs/", tmp.Account.Settings.Server, "-", tmp.Account.Settings.Username, "-log-", DateTime.Now.ToString(culture).Remove(DateTime.Now.ToString(culture).Length - 9), ".log"), true);

			Console.WriteLine(DateTime.Now.ToString() + " " + tmp.Account.Settings.Username + "(" + tmp.Account.Settings.Server + "): " + e.Message);
			writer.WriteLine(DateTime.Now.ToString() + ": " + e.Message);

			writer.Close();
			writer.Dispose();

			ClearLogs();
		}

		static void bot_Error(object sender, MessageEventsArgs e) {
			Bot tmp = (Bot)sender;

			if (!System.IO.Directory.Exists("Logs")) {
				System.IO.Directory.CreateDirectory("Logs");
			}

			CultureInfo culture = new CultureInfo("de-DE");

			Console.WriteLine(DateTime.Now.ToString() + " " + tmp.Account.Settings.Username + "(" + tmp.Account.Settings.Server + "): " + "Error ist aufgetretten");
			System.IO.StreamWriter writer = new System.IO.StreamWriter(String.Concat("Logs/", tmp.Account.Settings.Server, "-", tmp.Account.Settings.Username, "-error-", DateTime.Now.ToString(culture).Remove(DateTime.Now.ToString(culture).Length - 9), ".log"), true);
			writer.WriteLine(DateTime.Now.ToString() + ": " + e.Message);

			writer.Close();
			writer.Dispose();
		}

		static void bot_ExtendedLog(object sender, MessageEventsArgs e) {
			Bot tmp = (Bot)sender;

			if (!System.IO.Directory.Exists("Logs")) {
				System.IO.Directory.CreateDirectory("Logs");
			}

			CultureInfo culture = new CultureInfo("de-DE");

			System.IO.StreamWriter writer = new System.IO.StreamWriter(String.Concat("Logs/", tmp.Account.Settings.Server, "-", tmp.Account.Settings.Username, "-extlog-", DateTime.Now.ToString(culture).Remove(DateTime.Now.ToString(culture).Length - 9), ".log"), true);
			writer.WriteLine(DateTime.Now.ToString() + ": " + e.Message);

			writer.Close();
			writer.Dispose();
		}

		private static DateTime LastClearingDay = DateTime.Now.AddDays(-1);
		private static int MaxLoggingDays = 2;
		static void ClearLogs() {
			try {
				if (LastClearingDay.IsOtherDay(DateTime.Now)) {

					LastClearingDay = DateTime.Now;
					CultureInfo culture = new CultureInfo("de-DE");
					List<string> dateString = new List<string>();
					for (int i = 0; i <= MaxLoggingDays; i++) {
						dateString.Add(DateTime.Now.AddDays(-i).ToString(culture).Remove(DateTime.Now.ToString(culture).Length - 9));
					}

					foreach (string file in Directory.GetFiles("Logs")) {
						string name = Path.GetFileName(file);
						if (!name.Contains(dateString)) {
							File.Delete("Logs/" + name);
						}
					}
				}
			} catch {
				LastClearingDay = DateTime.Now;
			}
		}
	}
}