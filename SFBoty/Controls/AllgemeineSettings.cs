using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SFBotyCore.Mechanic.Account;

namespace SFBoty.Controls {
	public class AllgemeineSettings : UserControl {
		private GroupBox groupBox1;
		private TextBox txtPasswort;
		private TextBox txtAccount;
		private TextBox txtServer;
		private Label label3;
		private Label label2;
		private Label label1;
		private GroupBox groupBox2;
		private CheckBox checkBox1;
		private NumericUpDown numMaxLongTime;
		private NumericUpDown numMinLongTime;
		private NumericUpDown numMaxShortTime;
		private NumericUpDown numMinShortTime;
		private Label label7;
		private Label label6;
		private Label label5;
		private Label label8;
		private NumericUpDown numGuildVisitInterval;
		private Label label4;
	
		private void InitializeComponent() {
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.txtPasswort = new System.Windows.Forms.TextBox();
			this.txtAccount = new System.Windows.Forms.TextBox();
			this.txtServer = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.numMaxLongTime = new System.Windows.Forms.NumericUpDown();
			this.numMinLongTime = new System.Windows.Forms.NumericUpDown();
			this.numMaxShortTime = new System.Windows.Forms.NumericUpDown();
			this.numMinShortTime = new System.Windows.Forms.NumericUpDown();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.numGuildVisitInterval = new System.Windows.Forms.NumericUpDown();
			this.label8 = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numMaxLongTime)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numMinLongTime)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numMaxShortTime)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numMinShortTime)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numGuildVisitInterval)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.txtPasswort);
			this.groupBox1.Controls.Add(this.txtAccount);
			this.groupBox1.Controls.Add(this.txtServer);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(3, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(308, 107);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Allgemein";
			// 
			// txtPasswort
			// 
			this.txtPasswort.Location = new System.Drawing.Point(85, 72);
			this.txtPasswort.Name = "txtPasswort";
			this.txtPasswort.Size = new System.Drawing.Size(217, 20);
			this.txtPasswort.TabIndex = 5;
			// 
			// txtAccount
			// 
			this.txtAccount.Location = new System.Drawing.Point(85, 46);
			this.txtAccount.Name = "txtAccount";
			this.txtAccount.Size = new System.Drawing.Size(217, 20);
			this.txtAccount.TabIndex = 4;
			// 
			// txtServer
			// 
			this.txtServer.Location = new System.Drawing.Point(85, 20);
			this.txtServer.Name = "txtServer";
			this.txtServer.Size = new System.Drawing.Size(217, 20);
			this.txtServer.TabIndex = 3;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(8, 75);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(53, 13);
			this.label3.TabIndex = 2;
			this.label3.Text = "Passwort:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(8, 49);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(50, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Account:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(8, 23);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(41, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Server:";
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.Controls.Add(this.label8);
			this.groupBox2.Controls.Add(this.numGuildVisitInterval);
			this.groupBox2.Controls.Add(this.checkBox1);
			this.groupBox2.Controls.Add(this.numMaxLongTime);
			this.groupBox2.Controls.Add(this.numMinLongTime);
			this.groupBox2.Controls.Add(this.numMaxShortTime);
			this.groupBox2.Controls.Add(this.numMinShortTime);
			this.groupBox2.Controls.Add(this.label7);
			this.groupBox2.Controls.Add(this.label6);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Location = new System.Drawing.Point(3, 116);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(308, 224);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Intervall";
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Enabled = false;
			this.checkBox1.Location = new System.Drawing.Point(222, 201);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(86, 17);
			this.checkBox1.TabIndex = 8;
			this.checkBox1.Text = "Expert Mode";
			this.checkBox1.UseVisualStyleBackColor = true;
			// 
			// numMaxLongTime
			// 
			this.numMaxLongTime.DecimalPlaces = 1;
			this.numMaxLongTime.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.numMaxLongTime.Location = new System.Drawing.Point(119, 97);
			this.numMaxLongTime.Name = "numMaxLongTime";
			this.numMaxLongTime.Size = new System.Drawing.Size(183, 20);
			this.numMaxLongTime.TabIndex = 7;
			// 
			// numMinLongTime
			// 
			this.numMinLongTime.DecimalPlaces = 1;
			this.numMinLongTime.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.numMinLongTime.Location = new System.Drawing.Point(119, 71);
			this.numMinLongTime.Name = "numMinLongTime";
			this.numMinLongTime.Size = new System.Drawing.Size(183, 20);
			this.numMinLongTime.TabIndex = 6;
			// 
			// numMaxShortTime
			// 
			this.numMaxShortTime.DecimalPlaces = 1;
			this.numMaxShortTime.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.numMaxShortTime.Location = new System.Drawing.Point(119, 45);
			this.numMaxShortTime.Name = "numMaxShortTime";
			this.numMaxShortTime.Size = new System.Drawing.Size(183, 20);
			this.numMaxShortTime.TabIndex = 5;
			// 
			// numMinShortTime
			// 
			this.numMinShortTime.DecimalPlaces = 1;
			this.numMinShortTime.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.numMinShortTime.Location = new System.Drawing.Point(119, 19);
			this.numMinShortTime.Name = "numMinShortTime";
			this.numMinShortTime.Size = new System.Drawing.Size(183, 20);
			this.numMinShortTime.TabIndex = 4;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(7, 99);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(92, 13);
			this.label7.TabIndex = 3;
			this.label7.Text = "Max lange Aktion:";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(7, 73);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(89, 13);
			this.label6.TabIndex = 2;
			this.label6.Text = "Min lange Aktion:";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(7, 47);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(92, 13);
			this.label5.TabIndex = 1;
			this.label5.Text = "Max kurze Aktion:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(7, 21);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(89, 13);
			this.label4.TabIndex = 0;
			this.label4.Text = "Min kurze Aktion:";
			// 
			// numGuildVisitInterval
			// 
			this.numGuildVisitInterval.DecimalPlaces = 1;
			this.numGuildVisitInterval.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.numGuildVisitInterval.Location = new System.Drawing.Point(119, 123);
			this.numGuildVisitInterval.Name = "numGuildVisitInterval";
			this.numGuildVisitInterval.Size = new System.Drawing.Size(183, 20);
			this.numGuildVisitInterval.TabIndex = 9;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(7, 125);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(107, 13);
			this.label8.TabIndex = 10;
			this.label8.Text = "Interval Gildebesuch:";
			// 
			// AllgemeineSettings
			// 
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Name = "AllgemeineSettings";
			this.Size = new System.Drawing.Size(311, 399);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numMaxLongTime)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numMinLongTime)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numMaxShortTime)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numMinShortTime)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numGuildVisitInterval)).EndInit();
			this.ResumeLayout(false);

		}

		
		public AllgemeineSettings() {
			InitializeComponent();
		}

		private AccountSettings Settings;
		public void SetSettings(AccountSettings settings) {
			Settings = settings;

			txtAccount.Text = Settings.Username;
			txtPasswort.Text = Settings.PasswordHash;
			txtServer.Text = Settings.Server;

			numMinShortTime.Value = new decimal(settings.minShortTime);
			numMaxShortTime.Value = new decimal(settings.maxShortTime);
			numMinLongTime.Value = new decimal(settings.minLongTime);
			numMaxLongTime.Value = new decimal(settings.maxLongTime);
		}
	}
}
