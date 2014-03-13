using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SFBotyCore.Mechanic.Account;
using SFBotyCore;
using System.Net.Mail;
using System.Net;

namespace SFBoty.Controls {
	public class MailSettings : UserControl {
		private GroupBox groupBox1;
		private TextBox txtTo;
		private TextBox txtFrom;
		private TextBox txtSmtp;
		private Label label5;
		private Label label4;
		private Label label3;
		private Label label2;
		private Label label1;
		private TextBox txtPasswort;
		private TextBox txtUser;
		private Label label6;
		private Button btnTestMail;
		private NumericUpDown numPort;
		private Button btnReset;
		private CheckBox ckbSendErrorMail;
	
		private void InitializeComponent() {
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.txtPasswort = new System.Windows.Forms.TextBox();
			this.txtUser = new System.Windows.Forms.TextBox();
			this.txtSmtp = new System.Windows.Forms.TextBox();
			this.txtTo = new System.Windows.Forms.TextBox();
			this.txtFrom = new System.Windows.Forms.TextBox();
			this.ckbSendErrorMail = new System.Windows.Forms.CheckBox();
			this.label6 = new System.Windows.Forms.Label();
			this.btnTestMail = new System.Windows.Forms.Button();
			this.btnReset = new System.Windows.Forms.Button();
			this.numPort = new System.Windows.Forms.NumericUpDown();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numPort)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.numPort);
			this.groupBox1.Controls.Add(this.btnReset);
			this.groupBox1.Controls.Add(this.btnTestMail);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.txtPasswort);
			this.groupBox1.Controls.Add(this.txtUser);
			this.groupBox1.Controls.Add(this.txtSmtp);
			this.groupBox1.Controls.Add(this.txtTo);
			this.groupBox1.Controls.Add(this.txtFrom);
			this.groupBox1.Controls.Add(this.ckbSendErrorMail);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(397, 183);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "EMail Benachrichtigung";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(7, 149);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(53, 13);
			this.label5.TabIndex = 11;
			this.label5.Text = "Passwort:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(7, 123);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(52, 13);
			this.label4.TabIndex = 10;
			this.label4.Text = "Benutzer:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(7, 97);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(34, 13);
			this.label3.TabIndex = 9;
			this.label3.Text = "Smtp:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(7, 71);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(23, 13);
			this.label2.TabIndex = 8;
			this.label2.Text = "An:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(7, 45);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(29, 13);
			this.label1.TabIndex = 7;
			this.label1.Text = "Von:";
			// 
			// txtPasswort
			// 
			this.txtPasswort.Location = new System.Drawing.Point(66, 146);
			this.txtPasswort.Name = "txtPasswort";
			this.txtPasswort.PasswordChar = ' ';
			this.txtPasswort.Size = new System.Drawing.Size(216, 20);
			this.txtPasswort.TabIndex = 6;
			this.txtPasswort.TextChanged += new System.EventHandler(this.txtPasswort_TextChanged);
			// 
			// txtUser
			// 
			this.txtUser.Location = new System.Drawing.Point(66, 120);
			this.txtUser.Name = "txtUser";
			this.txtUser.Size = new System.Drawing.Size(216, 20);
			this.txtUser.TabIndex = 5;
			this.txtUser.TextChanged += new System.EventHandler(this.txtUser_TextChanged);
			// 
			// txtSmtp
			// 
			this.txtSmtp.Location = new System.Drawing.Point(66, 94);
			this.txtSmtp.Name = "txtSmtp";
			this.txtSmtp.Size = new System.Drawing.Size(216, 20);
			this.txtSmtp.TabIndex = 3;
			this.txtSmtp.TextChanged += new System.EventHandler(this.txtSmtp_TextChanged);
			// 
			// txtTo
			// 
			this.txtTo.Location = new System.Drawing.Point(66, 68);
			this.txtTo.Name = "txtTo";
			this.txtTo.Size = new System.Drawing.Size(216, 20);
			this.txtTo.TabIndex = 2;
			this.txtTo.TextChanged += new System.EventHandler(this.txtTo_TextChanged);
			// 
			// txtFrom
			// 
			this.txtFrom.Location = new System.Drawing.Point(66, 42);
			this.txtFrom.Name = "txtFrom";
			this.txtFrom.Size = new System.Drawing.Size(216, 20);
			this.txtFrom.TabIndex = 1;
			this.txtFrom.TextChanged += new System.EventHandler(this.txtFrom_TextChanged);
			// 
			// ckbSendErrorMail
			// 
			this.ckbSendErrorMail.AutoSize = true;
			this.ckbSendErrorMail.Location = new System.Drawing.Point(10, 19);
			this.ckbSendErrorMail.Name = "ckbSendErrorMail";
			this.ckbSendErrorMail.Size = new System.Drawing.Size(213, 17);
			this.ckbSendErrorMail.TabIndex = 0;
			this.ckbSendErrorMail.Text = "Sende ein EMail wenn ein Fehler auftritt";
			this.ckbSendErrorMail.UseVisualStyleBackColor = true;
			this.ckbSendErrorMail.CheckedChanged += new System.EventHandler(this.ckbSendErrorMail_CheckedChanged);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(288, 97);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(29, 13);
			this.label6.TabIndex = 12;
			this.label6.Text = "Port:";
			// 
			// btnTestMail
			// 
			this.btnTestMail.Location = new System.Drawing.Point(291, 15);
			this.btnTestMail.Name = "btnTestMail";
			this.btnTestMail.Size = new System.Drawing.Size(90, 23);
			this.btnTestMail.TabIndex = 1;
			this.btnTestMail.Text = "Sende TestMail";
			this.btnTestMail.UseVisualStyleBackColor = true;
			this.btnTestMail.Click += new System.EventHandler(this.btnTestMail_Click);
			// 
			// btnReset
			// 
			this.btnReset.Location = new System.Drawing.Point(291, 144);
			this.btnReset.Name = "btnReset";
			this.btnReset.Size = new System.Drawing.Size(47, 23);
			this.btnReset.TabIndex = 13;
			this.btnReset.Text = "Reset";
			this.btnReset.UseVisualStyleBackColor = true;
			this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
			// 
			// numPort
			// 
			this.numPort.Location = new System.Drawing.Point(323, 94);
			this.numPort.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
			this.numPort.Name = "numPort";
			this.numPort.Size = new System.Drawing.Size(58, 20);
			this.numPort.TabIndex = 14;
			this.numPort.ValueChanged += new System.EventHandler(this.numPort_ValueChanged);
			// 
			// MailSettings
			// 
			this.Controls.Add(this.groupBox1);
			this.Name = "MailSettings";
			this.Size = new System.Drawing.Size(397, 183);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numPort)).EndInit();
			this.ResumeLayout(false);

		}

		public MailSettings() {
			InitializeComponent();
		}

		private AccountSettings Settings;
		public void SetSettings(AccountSettings settings) {
			Settings = settings;

			CryptManager.Init(Settings);

			txtFrom.Text = settings.MailFrom;
			txtTo.Text = settings.MailTo;
			txtSmtp.Text = settings.MailSmtp;
			txtUser.Text = settings.MailUserNamer;
			if (!string.IsNullOrEmpty(settings.MailCryptPasswort)) {
				txtPasswort.Text = CryptManager.Decrypt(settings.MailCryptPasswort);
			}
			numPort.Value = settings.MailPort;
			ckbSendErrorMail.Checked = settings.SendErrorMail;
		}

		private void txtFrom_TextChanged(object sender, EventArgs e) {
			Settings.MailFrom = txtFrom.Text;
		}

		private void txtTo_TextChanged(object sender, EventArgs e) {
			Settings.MailTo = txtTo.Text;
		}

		private void txtSmtp_TextChanged(object sender, EventArgs e) {
			Settings.MailSmtp = txtSmtp.Text;
		}

		private void txtUser_TextChanged(object sender, EventArgs e) {
			Settings.MailUserNamer = txtUser.Text;
		}

		private void txtPasswort_TextChanged(object sender, EventArgs e) {
			CryptManager.Init(Settings);
			if (txtPasswort.Text == "") {
				Settings.MailCryptPasswort = "";
			} else {
				Settings.MailCryptPasswort = CryptManager.Encrypt(txtPasswort.Text);
			}
		}

		private void numPort_ValueChanged(object sender, EventArgs e) {
			Settings.MailPort = Convert.ToInt32(numPort.Value);
		}

		private void btnReset_Click(object sender, EventArgs e) {
			txtPasswort.Text = "";
			Settings.MailCryptPasswort = "";
		}

		private void btnTestMail_Click(object sender, EventArgs e) {
			CryptManager.Init(Settings);
			string from = Settings.MailFrom;
			string to = Settings.MailTo;
			int port = Settings.MailPort;
			string smtpAddress = Settings.MailSmtp;
			string userName = Settings.MailUserNamer;
			string passwort = CryptManager.Decrypt(Settings.MailCryptPasswort);

			MailMessage message = new MailMessage();
			message.To.Add(to);
			message.Subject = String.Concat("Testmail - Error on SFBoty on ", Settings.Server, " with Player ", Settings.Username);
			message.From = new MailAddress(from);
			message.Body = "Dies ist eine Testmail";

			SmtpClient smtp = new SmtpClient(smtpAddress, port);
			smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
			smtp.EnableSsl = true;
			smtp.Credentials = new NetworkCredential(userName, passwort);
			smtp.Timeout = 30000;

			try {
				smtp.Send(message);
				MessageBox.Show("Mail wurde gesendet.");
			} catch {
				MessageBox.Show("Mail wurde nicht gesendet.");
			}

			message.Dispose();
			smtp.Dispose();
		}

		private void ckbSendErrorMail_CheckedChanged(object sender, EventArgs e) {
			Settings.SendErrorMail = ckbSendErrorMail.Checked;
		}
	}
}
