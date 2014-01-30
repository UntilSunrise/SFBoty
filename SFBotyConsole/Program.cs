using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFBoty.Mechanic;
using SFBoty.Mechanic.Account;
using SFBoty.Mechanic.Areas;

namespace SFBotyConsole {
	class Program {

		static void Main(string[] args) {
			AccountSettings settings = new AccountSettings("nickname", "Hash", "Server");
			//settings.BuyBeer = true;
			//settings.PerformQuesten = false;
			//settings.PerformStadtwache = false;
			Account account = new Account(settings);
			Bot bot = new Bot(account);
			bot.MessageOutput += new EventHandler<MessageEventsArgs>(bot_MessageOutput);
			
			System.IO.StreamWriter writer = new System.IO.StreamWriter(String.Concat("log", DateTime.Now.ToShortDateString(), ".log"), true);
			Console.WriteLine(DateTime.Now.ToString() +  ": Bot wurde gestartet");
			writer.WriteLine(DateTime.Now.ToString() + ": Bot wurde gestartet");
			writer.Close();
			writer.Dispose();

			bot.Run();
		}

		static void bot_MessageOutput(object sender, MessageEventsArgs e) {
			System.IO.StreamWriter writer = new System.IO.StreamWriter(String.Concat("log", DateTime.Now.ToShortDateString(), ".log"), true);

			Bot tmp = (Bot)sender;
			Console.WriteLine(DateTime.Now.ToString() + " " + tmp.Account.Settings.Username + "(" + tmp.Account.Settings.Server + "): " + e.Message);
			writer.WriteLine(DateTime.Now.ToString() + " " + tmp.Account.Settings.Username + "(" + tmp.Account.Settings.Server + "): " + e.Message);

			writer.Close();
			writer.Dispose();
		}
	}
}