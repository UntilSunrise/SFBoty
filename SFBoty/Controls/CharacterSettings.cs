﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SFBotyCore.Mechanic.Account;

namespace SFBoty.Controls {
	public class CharacterSettings : UserControl {
		private GroupBox groupBox1;
		private RadioButton radioButton2;
		private RadioButton radioButton1;
		private GroupBox groupBox2;
		private NumericUpDown numLuck;
		private TrackBar barLuck;
		private Label label5;
		private NumericUpDown numAus;
		private TrackBar barAus;
		private Label label4;
		private NumericUpDown numInt;
		private TrackBar barInt;
		private Label label3;
		private NumericUpDown numDex;
		private TrackBar barDex;
		private Label label2;
		private NumericUpDown numStrenght;
		private TrackBar barStrengh;
		private Label label1;
		private GroupBox groupBox3;
		private Label lblAnzeige;
		private CheckBox checkBox2;
		private CheckBox ckbBuyItems;
		private CheckBox ckbUseMushroomsForBuying;
		private CheckBox ckbBuyStats;

		private void InitializeComponent() {
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.numLuck = new System.Windows.Forms.NumericUpDown();
			this.barLuck = new System.Windows.Forms.TrackBar();
			this.label5 = new System.Windows.Forms.Label();
			this.numAus = new System.Windows.Forms.NumericUpDown();
			this.barAus = new System.Windows.Forms.TrackBar();
			this.label4 = new System.Windows.Forms.Label();
			this.numInt = new System.Windows.Forms.NumericUpDown();
			this.barInt = new System.Windows.Forms.TrackBar();
			this.label3 = new System.Windows.Forms.Label();
			this.numDex = new System.Windows.Forms.NumericUpDown();
			this.barDex = new System.Windows.Forms.TrackBar();
			this.label2 = new System.Windows.Forms.Label();
			this.numStrenght = new System.Windows.Forms.NumericUpDown();
			this.barStrengh = new System.Windows.Forms.TrackBar();
			this.label1 = new System.Windows.Forms.Label();
			this.ckbBuyStats = new System.Windows.Forms.CheckBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.ckbBuyItems = new System.Windows.Forms.CheckBox();
			this.lblAnzeige = new System.Windows.Forms.Label();
			this.checkBox2 = new System.Windows.Forms.CheckBox();
			this.ckbUseMushroomsForBuying = new System.Windows.Forms.CheckBox();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numLuck)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.barLuck)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numAus)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.barAus)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numInt)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.barInt)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numDex)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.barDex)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numStrenght)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.barStrengh)).BeginInit();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.radioButton2);
			this.groupBox1.Controls.Add(this.radioButton1);
			this.groupBox1.Controls.Add(this.groupBox2);
			this.groupBox1.Controls.Add(this.ckbBuyStats);
			this.groupBox1.Location = new System.Drawing.Point(3, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(615, 308);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Attribute";
			// 
			// radioButton2
			// 
			this.radioButton2.AutoSize = true;
			this.radioButton2.Enabled = false;
			this.radioButton2.Location = new System.Drawing.Point(16, 278);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new System.Drawing.Size(156, 17);
			this.radioButton2.TabIndex = 3;
			this.radioButton2.Text = "Verteilung nach jeder Quest";
			this.radioButton2.UseVisualStyleBackColor = true;
			// 
			// radioButton1
			// 
			this.radioButton1.AutoSize = true;
			this.radioButton1.Checked = true;
			this.radioButton1.Enabled = false;
			this.radioButton1.Location = new System.Drawing.Point(16, 255);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new System.Drawing.Size(176, 17);
			this.radioButton1.TabIndex = 2;
			this.radioButton1.TabStop = true;
			this.radioButton1.Text = "Verteilung vor jeder Stadtwache";
			this.radioButton1.UseVisualStyleBackColor = true;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.numLuck);
			this.groupBox2.Controls.Add(this.barLuck);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Controls.Add(this.numAus);
			this.groupBox2.Controls.Add(this.barAus);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Controls.Add(this.numInt);
			this.groupBox2.Controls.Add(this.barInt);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Controls.Add(this.numDex);
			this.groupBox2.Controls.Add(this.barDex);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.numStrenght);
			this.groupBox2.Controls.Add(this.barStrengh);
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Location = new System.Drawing.Point(16, 42);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(587, 207);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Prozentuale Verteilung der Attribute";
			// 
			// numLuck
			// 
			this.numLuck.Location = new System.Drawing.Point(520, 159);
			this.numLuck.Name = "numLuck";
			this.numLuck.Size = new System.Drawing.Size(58, 20);
			this.numLuck.TabIndex = 14;
			this.numLuck.ValueChanged += new System.EventHandler(this.numLuck_ValueChanged);
			// 
			// barLuck
			// 
			this.barLuck.Location = new System.Drawing.Point(74, 154);
			this.barLuck.Maximum = 100;
			this.barLuck.Name = "barLuck";
			this.barLuck.Size = new System.Drawing.Size(442, 45);
			this.barLuck.TabIndex = 13;
			this.barLuck.Scroll += new System.EventHandler(this.barLuck_Scroll);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(11, 162);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(38, 13);
			this.label5.TabIndex = 12;
			this.label5.Text = "Glück:";
			// 
			// numAus
			// 
			this.numAus.Location = new System.Drawing.Point(520, 127);
			this.numAus.Name = "numAus";
			this.numAus.Size = new System.Drawing.Size(58, 20);
			this.numAus.TabIndex = 11;
			this.numAus.ValueChanged += new System.EventHandler(this.numAus_ValueChanged);
			// 
			// barAus
			// 
			this.barAus.Location = new System.Drawing.Point(74, 122);
			this.barAus.Maximum = 100;
			this.barAus.Name = "barAus";
			this.barAus.Size = new System.Drawing.Size(442, 45);
			this.barAus.TabIndex = 10;
			this.barAus.Scroll += new System.EventHandler(this.barAus_Scroll);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(11, 130);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(55, 13);
			this.label4.TabIndex = 9;
			this.label4.Text = "Ausdauer:";
			// 
			// numInt
			// 
			this.numInt.Location = new System.Drawing.Point(520, 94);
			this.numInt.Name = "numInt";
			this.numInt.Size = new System.Drawing.Size(58, 20);
			this.numInt.TabIndex = 8;
			this.numInt.ValueChanged += new System.EventHandler(this.numInt_ValueChanged);
			// 
			// barInt
			// 
			this.barInt.Location = new System.Drawing.Point(74, 89);
			this.barInt.Maximum = 100;
			this.barInt.Name = "barInt";
			this.barInt.Size = new System.Drawing.Size(442, 45);
			this.barInt.TabIndex = 7;
			this.barInt.Scroll += new System.EventHandler(this.barInt_Scroll);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(11, 97);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(57, 13);
			this.label3.TabIndex = 6;
			this.label3.Text = "Intelligenz:";
			// 
			// numDex
			// 
			this.numDex.Location = new System.Drawing.Point(520, 59);
			this.numDex.Name = "numDex";
			this.numDex.Size = new System.Drawing.Size(58, 20);
			this.numDex.TabIndex = 5;
			this.numDex.ValueChanged += new System.EventHandler(this.numDex_ValueChanged);
			// 
			// barDex
			// 
			this.barDex.Location = new System.Drawing.Point(74, 54);
			this.barDex.Maximum = 100;
			this.barDex.Name = "barDex";
			this.barDex.Size = new System.Drawing.Size(442, 45);
			this.barDex.TabIndex = 4;
			this.barDex.Scroll += new System.EventHandler(this.barDex_Scroll);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(11, 62);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(58, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Geschick::";
			// 
			// numStrenght
			// 
			this.numStrenght.Location = new System.Drawing.Point(520, 26);
			this.numStrenght.Name = "numStrenght";
			this.numStrenght.Size = new System.Drawing.Size(58, 20);
			this.numStrenght.TabIndex = 2;
			this.numStrenght.ValueChanged += new System.EventHandler(this.numStrenght_ValueChanged);
			// 
			// barStrengh
			// 
			this.barStrengh.Location = new System.Drawing.Point(74, 21);
			this.barStrengh.Maximum = 100;
			this.barStrengh.Name = "barStrengh";
			this.barStrengh.Size = new System.Drawing.Size(442, 45);
			this.barStrengh.TabIndex = 1;
			this.barStrengh.Scroll += new System.EventHandler(this.barStrengh_Scroll);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(11, 29);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(41, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Stärke:";
			// 
			// ckbBuyStats
			// 
			this.ckbBuyStats.AutoSize = true;
			this.ckbBuyStats.Location = new System.Drawing.Point(16, 19);
			this.ckbBuyStats.Name = "ckbBuyStats";
			this.ckbBuyStats.Size = new System.Drawing.Size(124, 17);
			this.ckbBuyStats.TabIndex = 0;
			this.ckbBuyStats.Text = "Aktiviere Attributkauf";
			this.ckbBuyStats.UseVisualStyleBackColor = true;
			this.ckbBuyStats.CheckedChanged += new System.EventHandler(this.ckbBuyStats_CheckedChanged);
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.ckbUseMushroomsForBuying);
			this.groupBox3.Controls.Add(this.ckbBuyItems);
			this.groupBox3.Controls.Add(this.lblAnzeige);
			this.groupBox3.Controls.Add(this.checkBox2);
			this.groupBox3.Location = new System.Drawing.Point(3, 317);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(615, 71);
			this.groupBox3.TabIndex = 1;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Inventar";
			// 
			// ckbBuyItems
			// 
			this.ckbBuyItems.AutoSize = true;
			this.ckbBuyItems.Location = new System.Drawing.Point(299, 19);
			this.ckbBuyItems.Name = "ckbBuyItems";
			this.ckbBuyItems.Size = new System.Drawing.Size(123, 17);
			this.ckbBuyItems.TabIndex = 2;
			this.ckbBuyItems.Text = "Kaufe Bessere Items";
			this.ckbBuyItems.UseVisualStyleBackColor = true;
			this.ckbBuyItems.CheckedChanged += new System.EventHandler(this.ckbBuyItems_CheckedChanged);
			// 
			// lblAnzeige
			// 
			this.lblAnzeige.AutoSize = true;
			this.lblAnzeige.Location = new System.Drawing.Point(13, 48);
			this.lblAnzeige.Name = "lblAnzeige";
			this.lblAnzeige.Size = new System.Drawing.Size(462, 13);
			this.lblAnzeige.TabIndex = 1;
			this.lblAnzeige.Text = "Unter Verwendung der oben eingestellten Attributverteilung wird das bessere Equip" +
    "ment ermittelt.";
			// 
			// checkBox2
			// 
			this.checkBox2.AutoSize = true;
			this.checkBox2.Checked = true;
			this.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox2.Enabled = false;
			this.checkBox2.Location = new System.Drawing.Point(16, 19);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Size = new System.Drawing.Size(240, 17);
			this.checkBox2.TabIndex = 0;
			this.checkBox2.Text = "Bessere Gegenstände automatisch ausrüsten";
			this.checkBox2.UseVisualStyleBackColor = true;
			// 
			// ckbUseMushroomsForBuying
			// 
			this.ckbUseMushroomsForBuying.AutoSize = true;
			this.ckbUseMushroomsForBuying.Location = new System.Drawing.Point(426, 19);
			this.ckbUseMushroomsForBuying.Name = "ckbUseMushroomsForBuying";
			this.ckbUseMushroomsForBuying.Size = new System.Drawing.Size(168, 17);
			this.ckbUseMushroomsForBuying.TabIndex = 3;
			this.ckbUseMushroomsForBuying.Text = "und benutze Pilze zum kaufen";
			this.ckbUseMushroomsForBuying.UseVisualStyleBackColor = true;
			this.ckbUseMushroomsForBuying.CheckedChanged += new System.EventHandler(this.ckbUseMushroomsForBuying_CheckedChanged);
			// 
			// CharacterSettings
			// 
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox1);
			this.Name = "CharacterSettings";
			this.Size = new System.Drawing.Size(622, 390);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numLuck)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.barLuck)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numAus)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.barAus)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numInt)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.barInt)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numDex)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.barDex)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numStrenght)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.barStrengh)).EndInit();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.ResumeLayout(false);

		}

		public CharacterSettings() {
			InitializeComponent();
		}

		private AccountSettings Settings;
		public void SetSettings(AccountSettings settings) {
			Settings = settings;

			ckbBuyStats.Checked = settings.PerformBuyStats;
			barStrengh.Value = Convert.ToInt32(settings.StatStrFactor * 100);
			barDex.Value = Convert.ToInt32(settings.StatDexFactor * 100);
			barInt.Value = Convert.ToInt32(settings.StatIntFactor * 100);
			barAus.Value = Convert.ToInt32(settings.StatAusFactor * 100);
			barLuck.Value = Convert.ToInt32(settings.StatLuckFactor * 100);

			numStrenght.Value = Convert.ToInt32(settings.StatStrFactor * 100);
			numDex.Value = Convert.ToInt32(settings.StatDexFactor * 100);
			numInt.Value = Convert.ToInt32(settings.StatIntFactor * 100);
			numAus.Value = Convert.ToInt32(settings.StatAusFactor * 100);
			numLuck.Value = Convert.ToInt32(settings.StatLuckFactor * 100);

			lblAnzeige.Visible = settings.UseAlternativeIventoryChecking;
			ckbBuyItems.Checked = settings.BuyItemsInMagicShop;
			ckbUseMushroomsForBuying.Checked = settings.UseMushroomsForBuying;
		}

		private void ckbBuyStats_CheckedChanged(object sender, EventArgs e) {
			Settings.PerformBuyStats = ckbBuyStats.Checked;
		}

		private void barStrengh_Scroll(object sender, EventArgs e) {
			int current = Convert.ToInt32(numStrenght.Value);
			int sum = barStrengh.Value + barDex.Value + barInt.Value + barAus.Value + barLuck.Value;
			if (sum <= 100) {
				numStrenght.Value = barStrengh.Value;
			} else {
				barStrengh.Value = current;
			}
			Settings.StatStrFactor = Convert.ToSingle(barStrengh.Value / 100f);
		}

		private void barDex_Scroll(object sender, EventArgs e) {
			int current = Convert.ToInt32(numDex.Value);
			int sum = barStrengh.Value + barDex.Value + barInt.Value + barAus.Value + barLuck.Value;
			if (sum <= 100) {
				numDex.Value = barDex.Value;
			} else {
				barDex.Value = current;
			}
			Settings.StatDexFactor = Convert.ToSingle(barDex.Value / 100f);
		}

		private void barInt_Scroll(object sender, EventArgs e) {
			int current = Convert.ToInt32(numInt.Value);
			int sum = barStrengh.Value + barDex.Value + barInt.Value + barAus.Value + barLuck.Value;
			if (sum <= 100) {
				numInt.Value = barInt.Value;
			} else {
				barInt.Value = current;
			}
			Settings.StatIntFactor = Convert.ToSingle(barInt.Value / 100f);
		}

		private void barAus_Scroll(object sender, EventArgs e) {
			int current = Convert.ToInt32(numAus.Value);
			int sum = barStrengh.Value + barDex.Value + barInt.Value + barAus.Value + barLuck.Value;
			if (sum <= 100) {
				numAus.Value = barAus.Value;
			} else {
				barAus.Value = current;
			}
			Settings.StatAusFactor = Convert.ToSingle(barAus.Value / 100f);
		}

		private void barLuck_Scroll(object sender, EventArgs e) {
			int current = Convert.ToInt32(numLuck.Value);
			int sum = barStrengh.Value + barDex.Value + barInt.Value + barAus.Value + barLuck.Value;
			if (sum <= 100) {
				numLuck.Value = barLuck.Value;
			} else {
				barLuck.Value = current;
			}
			Settings.StatLuckFactor = Convert.ToSingle(barLuck.Value / 100f);
		}

		private void numStrenght_ValueChanged(object sender, EventArgs e) {
			int current = barStrengh.Value;
			int sum = Convert.ToInt32(numStrenght.Value + numDex.Value + numInt.Value + numAus.Value + numLuck.Value);
			if (sum <= 100) {
				barStrengh.Value = Convert.ToInt32(numStrenght.Value);
			} else {
				numStrenght.Value = current;
			}
			Settings.StatStrFactor = Convert.ToSingle(numStrenght.Value / 100m);
		}

		private void numDex_ValueChanged(object sender, EventArgs e) {
			int current = barDex.Value;
			int sum = Convert.ToInt32(numStrenght.Value + numDex.Value + numInt.Value + numAus.Value + numLuck.Value);
			if (sum <= 100) {
				barDex.Value = Convert.ToInt32(numDex.Value);
			} else {
				numDex.Value = current;
			}
			Settings.StatDexFactor = Convert.ToSingle(numDex.Value / 100m);
		}

		private void numInt_ValueChanged(object sender, EventArgs e) {
			int current = barInt.Value;
			int sum = Convert.ToInt32(numStrenght.Value + numDex.Value + numInt.Value + numAus.Value + numLuck.Value);
			if (sum <= 100) {
				barInt.Value = Convert.ToInt32(numInt.Value);
			} else {
				numInt.Value = current;
			}
			Settings.StatIntFactor = Convert.ToSingle(numInt.Value / 100m);
		}

		private void numAus_ValueChanged(object sender, EventArgs e) {
			int current = barAus.Value;
			int sum = Convert.ToInt32(numStrenght.Value + numDex.Value + numInt.Value + numAus.Value + numLuck.Value);
			if (sum <= 100) {
				barAus.Value = Convert.ToInt32(numAus.Value);
			} else {
				numAus.Value = current;
			}
			Settings.StatAusFactor = Convert.ToSingle(numAus.Value / 100m);
		}

		private void numLuck_ValueChanged(object sender, EventArgs e) {
			int current = barLuck.Value;
			int sum = Convert.ToInt32(numStrenght.Value + numDex.Value + numInt.Value + numAus.Value + numLuck.Value);
			if (sum <= 100) {
				barLuck.Value = Convert.ToInt32(numLuck.Value);
			} else {
				numLuck.Value = current;
			}
			Settings.StatLuckFactor = Convert.ToSingle(numLuck.Value / 100m);
		}

		private void ckbBuyItems_CheckedChanged(object sender, EventArgs e) {
			Settings.BuyItemsInMagicShop = ckbBuyItems.Checked;
		}

		private void ckbUseMushroomsForBuying_CheckedChanged(object sender, EventArgs e) {
			Settings.UseMushroomsForBuying = ckbUseMushroomsForBuying.Checked;
		}
	}
}
