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

namespace SFBoty {
	public partial class MainWindow : Form {
		private Dictionary<string, Bot> Bots;
		private Dictionary<string, List<string>> BotLogs;
		private string SelectedBotKey;

		public MainWindow() {
			InitializeComponent();
			this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);

			Bots = new Dictionary<string, Bot>();
			BotLogs = new Dictionary<string, List<string>>();
			SelectedBotKey = "";

			accountOverview1.StartBot += new EventHandler<SFBoty.Controls.EventSelltingsArgs>(accountOverview1_StartBot);
			accountOverview1.StopBot += new EventHandler<SFBoty.Controls.EventSelltingsArgs>(accountOverview1_StopBot);
			accountOverview1.StartAllBots += new EventHandler<SFBoty.Controls.EventSelltingsArgs>(accountOverview1_StartAllBots);
			accountOverview1.SelectedAccountChanged += new EventHandler<EventSelltingsArgs>(accountOverview1_SelectedAccountChanged);
		}

		void Form1_FormClosing(object sender, FormClosingEventArgs e) {
			foreach (Bot b in Bots.Values) {
				b.Stop();
			}
		}

		#region BotHandling
		void accountOverview1_StartAllBots(object sender, EventSelltingsArgs e) {
			foreach (AccountSettings s in e.Settings) {
				Account acc = new Account(s);
				StartOneBot(acc);
			}
		}

		void accountOverview1_StopBot(object sender, EventSelltingsArgs e) {
			throw new NotImplementedException();
		}

		void accountOverview1_StartBot(object sender, EventSelltingsArgs e) {
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
			Application.Restart();
		}

		void bot_ExtendedLog(object sender, MessageEventsArgs e) {
			
		}

		void bot_MessageOutput(object sender, MessageEventsArgs e) {
			Bot bot = (Bot)sender;
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
		}

		void accountOverview1_SelectedAccountChanged(object sender, EventSelltingsArgs e) {
			if (e.Settings.Count() > 0) {
				string key = String.Concat(e.Settings[0].Username, e.Settings[0].Server);
				this.SelectedBotKey = key;
				WriteLogToConsole(SelectedBotKey);
			}		
		}

		private void WriteLogToConsole(string key) {
			if (BotLogs.Keys.Any(x => x == key) && BotLogs[key] != null && BotLogs[key].Count() > 0) {
				console1.Invoke(() => console1.SetMessages(BotLogs[key]));
			}
		}
		#endregion

	}
}
