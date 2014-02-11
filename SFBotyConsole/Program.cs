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

namespace SFBotyConsole {
	class Program {

		static void Main(string[] args) {
			Console.BufferWidth += 50;
			Console.BufferHeight += 200;
			Console.WindowWidth += 50;

			List<AccountSettings> accountSettings = new List<AccountSettings>();
			accountSettings = LoadSettings();
			//AccountSettings settings = new AccountSettings("nickname", "passworthash", "server");
			//accountSettings.Add(settings);

			//SaveSettings(accountSettings);

			List<Account> accounts = new List<Account>();
			accountSettings.ForEach(s => accounts.Add(new Account(s)));

			List<Bot> bots = new List<Bot>();
			foreach (Account a in accounts) {
				Bot bot = new Bot(a);
				bot.MessageOutput += new EventHandler<MessageEventsArgs>(bot_MessageOutput);
				bots.Add(bot);
			}

			Console.WriteLine(DateTime.Now.ToString() + ": Bot wurde gestartet");

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
		}
	}
}