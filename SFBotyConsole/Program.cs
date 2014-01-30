using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFBoty.Mechanic;
using SFBoty.Mechanic.Account;
using SFBoty.Mechanic.Areas;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace SFBotyConsole {
	class Program {

		static void Main(string[] args) {
			List<Account> accounts = new List<Account>();
			accounts = LoadAccounts();
			//AccountSettings settings = new AccountSettings("Nickname", "passwordhash", "server");
			//Account acc = new Account(settings);
			//accounts.Add(acc);
			//SaveAccounts(accounts);

			List<Bot> bots = new List<Bot>();
			foreach (Account a in accounts) {
				Bot bot = new Bot(a);
				bot.MessageOutput += new EventHandler<MessageEventsArgs>(bot_MessageOutput);
				bots.Add(bot);
			}
			
			System.IO.StreamWriter writer = new System.IO.StreamWriter(String.Concat("log", DateTime.Now.ToShortDateString(), ".log"), true);
			Console.WriteLine(DateTime.Now.ToString() +  ": Bot wurde gestartet");
			writer.WriteLine(DateTime.Now.ToString() + ": Bot wurde gestartet");
			writer.Close();
			writer.Dispose();

			bots.ForEach(b => b.Run());
		}

		private static List<Account> LoadAccounts() {
			if (File.Exists("acc.sav")) {
				BinaryFormatter bf = new BinaryFormatter();
				FileStream fs = new FileStream("acc.sav", FileMode.Open);
				List<Account> acc = (List<Account>)bf.Deserialize(fs);
				fs.Close();
				return acc;
			} else {
				return new List<Account>();
			}		
		}

		private static void SaveAccounts(List<Account> account) {
			BinaryFormatter bf = new BinaryFormatter();
			FileStream fs = new FileStream("acc.sav", FileMode.Create);
			bf.Serialize(fs, account);
			fs.Close();
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