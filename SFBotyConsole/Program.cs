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

namespace SFBotyConsole {
	class Program {

		static void Main(string[] args) {
			Console.BufferWidth += 50;
			Console.BufferHeight += 200;
			Console.WindowWidth += 50;

			List<AccountSettings> accountSettings = new List<AccountSettings>();
			accountSettings = LoadSettings();
			//AccountSettings settings = new AccountSettings("Nickname", "passwordhash", "server");
			//Account acc = new Account(settings);
			//accounts.Add(acc);
			//SaveAccounts(accounts);

			SaveSettings(accountSettings);

			List<Account> accounts = new List<Account>();
			accountSettings.ForEach(s => accounts.Add(new Account(s)));

			List<Bot> bots = new List<Bot>();
			foreach (Account a in accounts) {
				Bot bot = new Bot(a);
				bot.MessageOutput += new EventHandler<MessageEventsArgs>(bot_MessageOutput);
				bots.Add(bot);
			}

			System.IO.StreamWriter writer = new System.IO.StreamWriter(String.Concat("log", DateTime.Now.ToShortDateString(), ".log"), true);
			Console.WriteLine(DateTime.Now.ToString() + ": Bot wurde gestartet");
			writer.WriteLine(DateTime.Now.ToString() + ": Bot wurde gestartet");
			writer.Close();
			writer.Dispose();

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
			System.IO.StreamWriter writer = new System.IO.StreamWriter(String.Concat("log", DateTime.Now.ToShortDateString(), ".log"), true);

			Bot tmp = (Bot)sender;
			Console.WriteLine(DateTime.Now.ToString() + " " + tmp.Account.Settings.Username + "(" + tmp.Account.Settings.Server + "): " + e.Message);
			writer.WriteLine(DateTime.Now.ToString() + " " + tmp.Account.Settings.Username + "(" + tmp.Account.Settings.Server + "): " + e.Message);

			writer.Close();
			writer.Dispose();
		}
	}
}