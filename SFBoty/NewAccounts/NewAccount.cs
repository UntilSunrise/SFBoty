using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SFBotyCore.Mechanic.Account;
using System.Security.Cryptography;

namespace SFBoty.NewAccounts {
	public partial class NewAccount : Form {
		public NewAccount() {
			InitializeComponent();
		}

		public AccountSettings Setting;

		private void btnOk_Click(object sender, EventArgs e) {
			Setting = new AccountSettings(txtNick.Text, GetMD5Hash(txtHash.Text), txtServer.Text);
		}

		public string GetMD5Hash(string TextToHash) {
			//Prüfen ob Daten übergeben wurden.
			if ((TextToHash == null) || (TextToHash.Length == 0)) {
				return string.Empty;
			}

			//MD5 Hash aus dem String berechnen. Dazu muss der string in ein Byte[]
			//zerlegt werden. Danach muss das Resultat wieder zurück in ein string.
			MD5 md5 = new MD5CryptoServiceProvider();
			byte[] textToHash = Encoding.Default.GetBytes(TextToHash);
			byte[] result = md5.ComputeHash(textToHash);

			return System.BitConverter.ToString(result).Replace("-", "").ToLower();
		} 
	}
}
