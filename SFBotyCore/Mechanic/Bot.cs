using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFBotyCore.Mechanic.Account;
using System.Threading;
using System.Net;
using System.IO;
using SFBotyCore.Mechanic.Areas;

namespace SFBotyCore.Mechanic {
	public class Bot {

		public Account.Account Account { get; private set; }
		private Thread CurrentThread { get; set; }
		private WebClient Client { get; set; }
		private Random random;

		private LoginArea LoginArea;
		private TavernArea TarvernArea;
		private StadtwacheArea StadtwacheArea;
		private CharScreenArea CharArea;
		private DungeonArea DungeonArea;
		private ToiletArea ToiletArea;
		private ArenaArea ArenaArea;
		private GuildArea GuildArea;
		private MagicShopArea MagicShopArea;

		#region Events
		public event EventHandler<MessageEventsArgs> MessageOutput;
		public event EventHandler<MessageEventsArgs> ExtendedLog;
		public event EventHandler<MessageEventsArgs> Error;
		#endregion

		public Bot(Account.Account account) {
			this.Account = account;
			this.CurrentThread = new Thread(new ThreadStart(PerformAction));

			this.Client = new WebClient();
			Client.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:26.0) Gecko/20100101 Firefox/26.0");
			Client.Headers.Add(HttpRequestHeader.AcceptLanguage, "de-DE,de;q=0.8,en-US;q=0.6,en;q=0.4");
			Client.Headers.Add(HttpRequestHeader.AcceptCharset, "ISO-8859-1,utf-8;q=0.7,*;q=0.3");

			random = new Random(System.Environment.TickCount);

			LoginArea = new LoginArea();
			LoginArea.Initialize(Account, Client);
			LoginArea.MessageOutput += new EventHandler<MessageEventsArgs>(Event_MessageOutput);
			LoginArea.ExtendedLog += new EventHandler<MessageEventsArgs>(Log_ExtendedLog);

			TarvernArea = new TavernArea();
			TarvernArea.Initialize(Account, Client);
			TarvernArea.MessageOutput += new EventHandler<MessageEventsArgs>(Event_MessageOutput);
			TarvernArea.ExtendedLog += new EventHandler<MessageEventsArgs>(Log_ExtendedLog);

			StadtwacheArea = new StadtwacheArea();
			StadtwacheArea.Initialize(Account, Client);
			StadtwacheArea.MessageOutput += new EventHandler<MessageEventsArgs>(Event_MessageOutput);
			StadtwacheArea.ExtendedLog += new EventHandler<MessageEventsArgs>(Log_ExtendedLog);

			CharArea = new CharScreenArea();
			CharArea.Initialize(Account, Client);
			CharArea.MessageOutput += new EventHandler<MessageEventsArgs>(Event_MessageOutput);
			CharArea.ExtendedLog += new EventHandler<MessageEventsArgs>(Log_ExtendedLog);

			DungeonArea = new DungeonArea();
			DungeonArea.Initialize(Account, Client);
			DungeonArea.MessageOutput += new EventHandler<MessageEventsArgs>(Event_MessageOutput);
			DungeonArea.ExtendedLog += new EventHandler<MessageEventsArgs>(Log_ExtendedLog);

			ToiletArea = new ToiletArea();
			ToiletArea.Initialize(Account, Client);
			ToiletArea.MessageOutput += new EventHandler<MessageEventsArgs>(Event_MessageOutput);
			ToiletArea.ExtendedLog += new EventHandler<MessageEventsArgs>(Log_ExtendedLog);

			ArenaArea = new ArenaArea();
			ArenaArea.Initialize(Account, Client);
			ArenaArea.MessageOutput += new EventHandler<MessageEventsArgs>(Event_MessageOutput);
			ArenaArea.ExtendedLog += new EventHandler<MessageEventsArgs>(Log_ExtendedLog);

			GuildArea = new GuildArea();
			GuildArea.Initialize(Account, Client);
			GuildArea.MessageOutput += new EventHandler<MessageEventsArgs>(Event_MessageOutput);
			GuildArea.ExtendedLog += new EventHandler<MessageEventsArgs>(Log_ExtendedLog);

			MagicShopArea = new MagicShopArea();
			MagicShopArea.Initialize(Account, Client);
			MagicShopArea.MessageOutput += new EventHandler<MessageEventsArgs>(Event_MessageOutput);
			MagicShopArea.ExtendedLog += new EventHandler<MessageEventsArgs>(Log_ExtendedLog);
		}

		void Log_ExtendedLog(object sender, MessageEventsArgs e) {
			if (ExtendedLog != null) {
				ExtendedLog(this, e);
			}
		}

		void Event_MessageOutput(object sender, MessageEventsArgs e) {
			if (MessageOutput != null) {
				MessageOutput(this, e);
			}
		}

		public void Run() {
			CurrentThread.Start();
		}

		public void Stop() {
			CurrentThread.Abort();
		}

		#region Thread
		/// <summary>
		/// Ausführung des Bots über den eigenen Thread
		/// </summary>
		private void PerformAction() {
			try {
				while (true) {
					if (Account.Settings.HasLogin) {
						MagicShopArea.PerformArea();
						TarvernArea.PerformArea();
						ToiletArea.PerformArea();
						ArenaArea.PerformArea();
						GuildArea.PerformArea();
						CharArea.PerformArea();
						DungeonArea.PerformArea();
						StadtwacheArea.PerformArea();
					} else {
						LoginArea.PerformArea();
					}

					//at the end oh an Threadloop sleep for 1 Secound
					Thread.Sleep(1000);
				}
			} catch (Exception ex) {
				if (Error != null) {
					Error(this, new MessageEventsArgs(ex.ToString()));
				}
			}
		}
		#endregion

		public void Dispose() {
			this.CurrentThread.Abort();
			Client.Dispose();
			LoginArea.Dispose();
			TarvernArea.Dispose();
			ToiletArea.Dispose();
			ArenaArea.Dispose();
			CharArea.Dispose();
			StadtwacheArea.Dispose();
			DungeonArea.Dispose();
			MagicShopArea.Dispose();
		}
	}
}
