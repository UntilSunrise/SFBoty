using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SFBotyCore.Mechanic.Account;

namespace SFBoty.NewAccounts {
	public partial class NewAccount : Form {
		public NewAccount() {
			InitializeComponent();
		}

		public AccountSettings Setting;

		private void btnOk_Click(object sender, EventArgs e) {
			Setting = new AccountSettings(txtNick.Text, txtHash.Text, txtServer.Text);
		}
	}
}
