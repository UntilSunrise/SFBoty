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
	public partial class EditSettings : Form {
		private AccountSettings Setting;
		private AccountSettings Clone;
		
		public EditSettings(AccountSettings s) {
			InitializeComponent();
			Setting = s;
			Clone = Setting.Clone();

			Clone.Username += "Test";
		}

		private void btnSave_Click(object sender, EventArgs e) {
			Setting.SetSettings(Clone);
		}
	}
}
