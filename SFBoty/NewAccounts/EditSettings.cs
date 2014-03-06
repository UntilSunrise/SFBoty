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

			allgemeineSettings1.SetSettings(Clone);
			tavernSettings1.SetSettings(Clone);
			toiletteSettings1.SetSettings(Clone);
			townWatchSettings1.SetSettings(Clone);
			dungeonTowerSettings1.SetSettings(Clone);
			arenaSettings1.SetSettings(Clone);
			gildenSettings1.SetSettings(Clone);
			characterSettings1.SetSettings(Clone);
			shopSettings1.SetSettings(Clone);
		}

		private void btnSave_Click(object sender, EventArgs e) {
			Setting.SetSettings(Clone);
		}
	}
}
