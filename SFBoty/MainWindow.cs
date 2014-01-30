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
using SFBoty.Mechanic;
using SFBoty.Mechanic.Account;

namespace SFBoty {
	public partial class MainWindow : Form {
		public MainWindow() {
			InitializeComponent();
			this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
		}

		void Form1_FormClosing(object sender, FormClosingEventArgs e) {
			bot.Stop();
		}

		public void bot_QuestWasTaken(object sender, EventArgs e) {
			txtOutput.Invoke(() => txtOutput.Text += System.Environment.NewLine + "Quest was taken " + DateTime.Now.ToShortTimeString());
		}

		void bot_MessageOutput(object sender, Mechanic.Areas.MessageEventsArgs e) {
			txtOutput.Invoke(() => txtOutput.Text += System.Environment.NewLine + e.Message + DateTime.Now.ToShortTimeString());
		}

		private Bot bot;
		private void btnConnect_Click(object sender, EventArgs e) {
			txtOutput.Text = "Bot is startet";

			AccountSettings settings = new AccountSettings("Myrkai", "X", "S");
			Account account = new Account(settings);
			bot = new Bot(account);
			bot.MessageOutput += new EventHandler<Mechanic.Areas.MessageEventsArgs>(bot_MessageOutput);
			bot.Run();
		}
	}
}
