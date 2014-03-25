using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SFBotyCore.Mechanic.Account;

namespace SFBoty.Controls {
	public class GildenSettings : UserControl {
		private GroupBox groupBox1;
		private Label label6;
		private NumericUpDown numericUpDown3;
		private Label label5;
		private CheckBox checkBox4;
		private Label label4;
		private Label label3;
		private Label label2;
		private NumericUpDown numericUpDown2;
		private Label label1;
		private NumericUpDown numFactorGold;
		private CheckBox ckbDonate;
		private CheckBox ckbFightForGuild;
		private CheckBox checkBox7;
		private CheckBox checkBox6;
		private CheckBox checkBox5;
		private Label label7;
		private TextBox txtIgnoreGuilde;
		private Label label8;
		private TextBox txtIgnorePlayer;
		private GroupBox groupBox2;
		private CheckBox ckbGetChat;
		private CheckBox chkPerformGuild;
	
		private void InitializeComponent() {
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.ckbGetChat = new System.Windows.Forms.CheckBox();
			this.checkBox7 = new System.Windows.Forms.CheckBox();
			this.checkBox6 = new System.Windows.Forms.CheckBox();
			this.checkBox5 = new System.Windows.Forms.CheckBox();
			this.label6 = new System.Windows.Forms.Label();
			this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
			this.label5 = new System.Windows.Forms.Label();
			this.checkBox4 = new System.Windows.Forms.CheckBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.numFactorGold = new System.Windows.Forms.NumericUpDown();
			this.ckbDonate = new System.Windows.Forms.CheckBox();
			this.ckbFightForGuild = new System.Windows.Forms.CheckBox();
			this.chkPerformGuild = new System.Windows.Forms.CheckBox();
			this.txtIgnoreGuilde = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.txtIgnorePlayer = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numFactorGold)).BeginInit();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.ckbGetChat);
			this.groupBox1.Controls.Add(this.checkBox7);
			this.groupBox1.Controls.Add(this.checkBox6);
			this.groupBox1.Controls.Add(this.checkBox5);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.numericUpDown3);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.checkBox4);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.numericUpDown2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.numFactorGold);
			this.groupBox1.Controls.Add(this.ckbDonate);
			this.groupBox1.Controls.Add(this.ckbFightForGuild);
			this.groupBox1.Controls.Add(this.chkPerformGuild);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(525, 159);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Gilde";
			// 
			// ckbGetChat
			// 
			this.ckbGetChat.AutoSize = true;
			this.ckbGetChat.Location = new System.Drawing.Point(291, 136);
			this.ckbGetChat.Name = "ckbGetChat";
			this.ckbGetChat.Size = new System.Drawing.Size(141, 17);
			this.ckbGetChat.TabIndex = 16;
			this.ckbGetChat.Text = "Chatverlauf aufzeichnen";
			this.ckbGetChat.UseVisualStyleBackColor = true;
			this.ckbGetChat.CheckedChanged += new System.EventHandler(this.ckbGetChat_CheckedChanged);
			// 
			// checkBox7
			// 
			this.checkBox7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.checkBox7.AutoSize = true;
			this.checkBox7.Enabled = false;
			this.checkBox7.Location = new System.Drawing.Point(313, 112);
			this.checkBox7.Name = "checkBox7";
			this.checkBox7.Size = new System.Drawing.Size(80, 17);
			this.checkBox7.TabIndex = 15;
			this.checkBox7.Text = "Lehrmeister";
			this.checkBox7.UseVisualStyleBackColor = true;
			// 
			// checkBox6
			// 
			this.checkBox6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.checkBox6.AutoSize = true;
			this.checkBox6.Enabled = false;
			this.checkBox6.Location = new System.Drawing.Point(313, 89);
			this.checkBox6.Name = "checkBox6";
			this.checkBox6.Size = new System.Drawing.Size(79, 17);
			this.checkBox6.TabIndex = 14;
			this.checkBox6.Text = "Goldschatz";
			this.checkBox6.UseVisualStyleBackColor = true;
			// 
			// checkBox5
			// 
			this.checkBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.checkBox5.AutoSize = true;
			this.checkBox5.Enabled = false;
			this.checkBox5.Location = new System.Drawing.Point(313, 66);
			this.checkBox5.Name = "checkBox5";
			this.checkBox5.Size = new System.Drawing.Size(64, 17);
			this.checkBox5.TabIndex = 13;
			this.checkBox5.Text = "Festung";
			this.checkBox5.UseVisualStyleBackColor = true;
			// 
			// label6
			// 
			this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(464, 44);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(46, 13);
			this.label6.TabIndex = 12;
			this.label6.Text = "Stufe/n.";
			// 
			// numericUpDown3
			// 
			this.numericUpDown3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.numericUpDown3.Enabled = false;
			this.numericUpDown3.Location = new System.Drawing.Point(399, 42);
			this.numericUpDown3.Name = "numericUpDown3";
			this.numericUpDown3.Size = new System.Drawing.Size(59, 20);
			this.numericUpDown3.TabIndex = 11;
			this.numericUpDown3.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// label5
			// 
			this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(288, 44);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(105, 13);
			this.label5.TabIndex = 10;
			this.label5.Text = "Abwechselnd jeweils";
			// 
			// checkBox4
			// 
			this.checkBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.checkBox4.AutoSize = true;
			this.checkBox4.Enabled = false;
			this.checkBox4.Location = new System.Drawing.Point(291, 19);
			this.checkBox4.Name = "checkBox4";
			this.checkBox4.Size = new System.Drawing.Size(100, 17);
			this.checkBox4.TabIndex = 9;
			this.checkBox4.Text = "Gilde ausbauen";
			this.checkBox4.UseVisualStyleBackColor = true;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(13, 138);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(236, 13);
			this.label4.TabIndex = 8;
			this.label4.Text = "Nach dem Questen, aber vor dem Attribute kauf.";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(13, 121);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(228, 13);
			this.label3.TabIndex = 7;
			this.label3.Text = "Die Spende erfolgt als letzte Aktion des Tages.";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(184, 93);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(29, 13);
			this.label2.TabIndex = 6;
			this.label2.Text = "Pilze";
			// 
			// numericUpDown2
			// 
			this.numericUpDown2.Enabled = false;
			this.numericUpDown2.Location = new System.Drawing.Point(119, 91);
			this.numericUpDown2.Name = "numericUpDown2";
			this.numericUpDown2.Size = new System.Drawing.Size(59, 20);
			this.numericUpDown2.TabIndex = 5;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(184, 67);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(93, 13);
			this.label1.TabIndex = 4;
			this.label1.Text = "% Gold (1 = 100%)";
			// 
			// numFactorGold
			// 
			this.numFactorGold.DecimalPlaces = 1;
			this.numFactorGold.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.numFactorGold.Location = new System.Drawing.Point(119, 65);
			this.numFactorGold.Name = "numFactorGold";
			this.numFactorGold.Size = new System.Drawing.Size(59, 20);
			this.numFactorGold.TabIndex = 3;
			this.numFactorGold.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.numFactorGold.ValueChanged += new System.EventHandler(this.numFactorGold_ValueChanged);
			// 
			// ckbDonate
			// 
			this.ckbDonate.AutoSize = true;
			this.ckbDonate.Location = new System.Drawing.Point(16, 66);
			this.ckbDonate.Name = "ckbDonate";
			this.ckbDonate.Size = new System.Drawing.Size(97, 17);
			this.ckbDonate.TabIndex = 2;
			this.ckbDonate.Text = "Spende täglich";
			this.ckbDonate.UseVisualStyleBackColor = true;
			this.ckbDonate.CheckedChanged += new System.EventHandler(this.ckbDonate_CheckedChanged);
			// 
			// ckbFightForGuild
			// 
			this.ckbFightForGuild.AutoSize = true;
			this.ckbFightForGuild.Checked = true;
			this.ckbFightForGuild.CheckState = System.Windows.Forms.CheckState.Checked;
			this.ckbFightForGuild.Enabled = false;
			this.ckbFightForGuild.Location = new System.Drawing.Point(16, 43);
			this.ckbFightForGuild.Name = "ckbFightForGuild";
			this.ckbFightForGuild.Size = new System.Drawing.Size(167, 17);
			this.ckbFightForGuild.TabIndex = 1;
			this.ckbFightForGuild.Text = "An Gildenkämpfen teilnehmen";
			this.ckbFightForGuild.UseVisualStyleBackColor = true;
			// 
			// chkPerformGuild
			// 
			this.chkPerformGuild.AutoSize = true;
			this.chkPerformGuild.Checked = true;
			this.chkPerformGuild.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkPerformGuild.Location = new System.Drawing.Point(16, 19);
			this.chkPerformGuild.Name = "chkPerformGuild";
			this.chkPerformGuild.Size = new System.Drawing.Size(94, 17);
			this.chkPerformGuild.TabIndex = 0;
			this.chkPerformGuild.Text = "Aktiviere Gilde";
			this.chkPerformGuild.UseVisualStyleBackColor = true;
			this.chkPerformGuild.CheckedChanged += new System.EventHandler(this.chkPerformGuild_CheckedChanged);
			// 
			// txtIgnoreGuilde
			// 
			this.txtIgnoreGuilde.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtIgnoreGuilde.Location = new System.Drawing.Point(119, 19);
			this.txtIgnoreGuilde.Name = "txtIgnoreGuilde";
			this.txtIgnoreGuilde.Size = new System.Drawing.Size(391, 20);
			this.txtIgnoreGuilde.TabIndex = 16;
			this.txtIgnoreGuilde.TextChanged += new System.EventHandler(this.txtIgnoreGuilde_TextChanged);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(13, 22);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(101, 13);
			this.label7.TabIndex = 17;
			this.label7.Text = "Ignoriere die Gilden:";
			// 
			// txtIgnorePlayer
			// 
			this.txtIgnorePlayer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtIgnorePlayer.Location = new System.Drawing.Point(119, 45);
			this.txtIgnorePlayer.Name = "txtIgnorePlayer";
			this.txtIgnorePlayer.Size = new System.Drawing.Size(391, 20);
			this.txtIgnorePlayer.TabIndex = 18;
			this.txtIgnorePlayer.TextChanged += new System.EventHandler(this.txtIgnorePlayer_TextChanged);
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(13, 48);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(103, 13);
			this.label8.TabIndex = 19;
			this.label8.Text = "Ignoriere die Spieler:";
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.Controls.Add(this.label8);
			this.groupBox2.Controls.Add(this.txtIgnoreGuilde);
			this.groupBox2.Controls.Add(this.txtIgnorePlayer);
			this.groupBox2.Controls.Add(this.label7);
			this.groupBox2.Location = new System.Drawing.Point(0, 163);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(525, 71);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Gilden und Spieler bei Angriffen ignorieren (\"/\" ist der Separator)";
			// 
			// GildenSettings
			// 
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Name = "GildenSettings";
			this.Size = new System.Drawing.Size(525, 238);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numFactorGold)).EndInit();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.ResumeLayout(false);

		}

		public GildenSettings() {
			InitializeComponent();
		}

		private AccountSettings Settings;
		public void SetSettings(AccountSettings settings) {
			Settings = settings;

			chkPerformGuild.Checked = settings.PerformGuild;
			ckbDonate.Checked = settings.DonateGold;
			numFactorGold.Value = new decimal(settings.FactorToDonate);

			txtIgnoreGuilde.Text = settings.IgnoreGuilds;
			txtIgnorePlayer.Text = settings.IgnorePlayers;

			ckbGetChat.Checked = settings.GetChatHistory;
		}

		private void chkPerformGuild_CheckedChanged(object sender, EventArgs e) {
			Settings.PerformGuild = chkPerformGuild.Checked;
		}

		private void ckbDonate_CheckedChanged(object sender, EventArgs e) {
			Settings.DonateGold = ckbDonate.Checked;
		}

		private void numFactorGold_ValueChanged(object sender, EventArgs e) {
			Settings.FactorToDonate = Convert.ToSingle(numFactorGold.Value);
		}

		private void txtIgnoreGuilde_TextChanged(object sender, EventArgs e) {
			Settings.IgnoreGuilds = txtIgnoreGuilde.Text;
		}

		private void txtIgnorePlayer_TextChanged(object sender, EventArgs e) {
			Settings.IgnorePlayers = txtIgnorePlayer.Text;
		}

		private void ckbGetChat_CheckedChanged(object sender, EventArgs e) {
			Settings.GetChatHistory = ckbGetChat.Checked;
		}
	}
}
