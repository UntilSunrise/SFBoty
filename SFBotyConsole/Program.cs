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
			Console.BufferWidth += 50;
			Console.BufferHeight += 200;
			Console.WindowWidth += 50;

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

		static void bot_MessageOutput(object sender, MessageEventsArgs e) {
			Bot tmp = (Bot)sender;

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