using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.IO;
using SFBotyCore.Mechanic;
using SFBotyCore.Mechanic.Account;
using SFBotyCore.Mechanic.Areas;
using SFBoty.Controls;
using System.Globalization;
using SFBotyCore;

namespace SFBoty {
	public partial class MainWindow : Form {
		private Dictionary<string, Bot> Bots;
		private Dictionary<string, List<string>> BotLogs;
		private Dictionary<string, HashSet<string>> ChatLogs;
		private string SelectedBotKey;

		public MainWindow() {
			InitializeComponent();
			this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);

			Bots = new Dictionary<string, Bot>();
			BotLogs = new Dictionary<string, List<string>>();
			ChatLogs = new Dictionary<string, HashSet<string>>();
			SelectedBotKey = "";

			accountOverview1.StartBot += new EventHandler<SFBoty.Controls.EventSettingsArgs>(accountOverview1_StartBot);
			accountOverview1.StopBot += new EventHandler<SFBoty.Controls.EventSettingsArgs>(accountOverview1_StopBot);
			accountOverview1.StartAllBots += new EventHandler<SFBoty.Controls.EventSettingsArgs>(accountOverview1_StartAllBots);
			accountOverview1.SelectedAccountChanged += new EventHandler<EventSettingsArgs>(accountOverview1_SelectedAccountChanged);

			console1.MessageEnter += new EventHandler<MessageEnterEventArgs>(console1_MessageEnter);

			ClearLogs();
		}

		void console1_MessageEnter(object sender, MessageEnterEventArgs e) {
			string command = e.Text;
			if (command.StartsWith("sleep ")) {
				string[] commandParts = command.Split(' ');
				if (commandParts.Count() == 4) {
					List<KeyValuePair<string, Bot>> tmp = Bots.Where(b => b.Key.ToLower() == commandParts[2].ToLower() + commandParts[1].ToLower()).ToList();
					if (tmp.Count > 0) {
						Bot bot = tmp.First().Value;
						if (bot != null) {
							bot.Break(Convert.ToSingle(commandParts[3]) * 60f);
							BotLogs[SelectedBotKey].Add(string.Concat("Bot ", bot.Account.Settings.Server, " ", bot.Account.Settings.Username, " unterbricht"));
							WriteLogToConsole(SelectedBotKey);
						}
					}
				}			
			} else {
				MessageBox.Show("ungültiger Befehl (use: [sleep]_[server]_[user]_[timeMinute]");
			}
		}

		void Form1_FormClosing(object sender, FormClosingEventArgs e) {
			foreach (Bot b in Bots.Values) {
				b.Stop();
			}
		}

		#region BotHandling
		void accountOverview1_StartAllBots(object sender, EventSettingsArgs e) {
			foreach (AccountSettings s in e.Settings) {
				Account acc = new Account(s);
				StartOneBot(acc);
			}
		}

		void accountOverview1_StopBot(object sender, EventSettingsArgs e) {
			foreach (AccountSettings setting in e.Settings) {
				string key = String.Concat(setting.Username, setting.Server);
				Bots[key].Stop();
			}
		}

		void accountOverview1_StartBot(object sender, EventSettingsArgs e) {
			if (e.Settings.Count == 1) {
				Account acc = new Account(e.Settings[0]);
				StartOneBot(acc);
			}
		}

		private void StartOneBot(Account acc) {
			string key = String.Concat(acc.Settings.Username, acc.Settings.Server);
			if (Bots.Keys.Any(x => x == key)) {
				Bots[key].Run();
			} else {
				Bot bot = new Bot(acc);
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

				Bots.Add(key, bot);
				Bots[key].Run();
			}
		}

		void bot_Error(object sender, MessageEventsArgs e) {
			Bot tmp = (Bot)sender;

			if (!System.IO.Directory.Exists("Logs")) {
				System.IO.Directory.CreateDirectory("Logs");
			}

			CultureInfo culture = new CultureInfo("de-DE");

			System.IO.StreamWriter writer = new System.IO.StreamWriter(String.Concat("Logs/", tmp.Account.Settings.Server, "-", tmp.Account.Settings.Username, "-error-", DateTime.Now.ToString(culture).Remove(DateTime.Now.ToString(culture).Length - 9), ".log"), true);
			writer.WriteLine(DateTime.Now.ToString() + ": " + e.Message);

			writer.Close();
			writer.Dispose();
		}

		void bot_ExtendedLog(object sender, MessageEventsArgs e) {
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

		private void LogChatHistory(Bot bot, MessageEventsArgs e) {
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
				}

				writer.Close();
				writer.Dispose();
			}

			while (ChatLogs[key].Count > 20) {
				ChatLogs[key].Remove(ChatLogs[key].First());
			}
		}

		void bot_MessageOutput(object sender, MessageEventsArgs e) {
			Bot bot = (Bot)sender;

			if (e.IsChatHistory) {
				LogChatHistory(bot, e);
				return; //ja ich habe mir den else Zweig gespart
			}

			string key = String.Concat(bot.Account.Settings.Username, bot.Account.Settings.Server);
			if (BotLogs.Keys.Any(x => x == key)) {
				if (BotLogs[key] != null) {
					if (BotLogs[key].Count < 20) {
						BotLogs[key].Add(DateTime.Now.ToString() + ": " + e.Message);
					} else {
						BotLogs[key].RemoveAt(0);
						BotLogs[key].Add(DateTime.Now.ToString() + ": " + e.Message);
					}
				} else {
					BotLogs[key] = new List<string>();
					BotLogs[key].Add(DateTime.Now.ToString() + ": " + e.Message);
				}
			} else {
				BotLogs.Add(key, new List<string>() { DateTime.Now.ToString() + ": " + e.Message });
			}

			WriteLogToConsole(SelectedBotKey);

			Bot tmp = (Bot)sender;

			if (!System.IO.Directory.Exists("Logs")) {
				System.IO.Directory.CreateDirectory("Logs");
			}

			CultureInfo culture = new CultureInfo("de-DE");

			System.IO.StreamWriter writer = new System.IO.StreamWriter(String.Concat("Logs/", tmp.Account.Settings.Server, "-", tmp.Account.Settings.Username, "-log-", DateTime.Now.ToString(culture).Remove(DateTime.Now.ToString(culture).Length - 9), ".log"), true);

			writer.WriteLine(DateTime.Now.ToString() + ": " + e.Message);

			writer.Close();
			writer.Dispose();

			ClearLogs();
		}

		void accountOverview1_SelectedAccountChanged(object sender, EventSettingsArgs e) {
			if (e.Settings.Count() > 0) {
				string key = String.Concat(e.Settings[0].Username, e.Settings[0].Server);
				this.SelectedBotKey = key;
				WriteLogToConsole(SelectedBotKey);
			}
		}

		private void WriteLogToConsole(string key) {
			try {
				lock (console1) {
					if (BotLogs.Keys.Any(x => x == key) && BotLogs[key] != null && BotLogs[key].Count() > 0) {
						console1.Invoke(() => console1.SetMessages(BotLogs[key]));
					}
				}
			} catch { }
		}
		#endregion

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

		private void MainWindow_Resize(object sender, EventArgs e) {
			if (this.WindowState == FormWindowState.Minimized) {
				notifyIcon.Visible = true;
				notifyIcon.ShowBalloonTip(500, "Anwendung ist minimiert", "Wiederherstellen das Icon Doppelklicken", ToolTipIcon.Info);
				notifyIcon.Text = "SFBoty";
				notifyIcon.DoubleClick += new EventHandler(notifyIcon_DoubleClick);
				this.ShowInTaskbar = false;
			} else {
				notifyIcon.Visible = false;
			}
		}

		void notifyIcon_DoubleClick(object sender, EventArgs e) {
			this.ShowInTaskbar = true;
			this.WindowState = FormWindowState.Normal;
			notifyIcon.Visible = false;
		}
	}
}
