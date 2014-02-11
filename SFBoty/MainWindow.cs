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

namespace SFBoty {
	public partial class MainWindow : Form {
		public MainWindow() {
			InitializeComponent();
			this.FormClosing += new FormClosingEventHandler(Form1_FormClosing);
			//accountOverview1.LoadAllAccountsFromXML();
		}

		void Form1_FormClosing(object sender, FormClosingEventArgs e) {
			
		}
	}
}
