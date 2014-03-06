using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SFBotyCore.Mechanic.Account;

namespace SFBoty.Controls {
	public class ToiletteSettings : UserControl {
		private GroupBox groupBox1;
		private CheckBox ckbFlush;
		private CheckBox ckbSellIItemsFromToilett;
		private CheckBox ckbPerfomToilett;
	
		private void InitializeComponent() {
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.ckbFlush = new System.Windows.Forms.CheckBox();
			this.ckbSellIItemsFromToilett = new System.Windows.Forms.CheckBox();
			this.ckbPerfomToilett = new System.Windows.Forms.CheckBox();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.ckbFlush);
			this.groupBox1.Controls.Add(this.ckbSellIItemsFromToilett);
			this.groupBox1.Controls.Add(this.ckbPerfomToilett);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(206, 95);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Toilette";
			// 
			// ckbFlush
			// 
			this.ckbFlush.AutoSize = true;
			this.ckbFlush.Checked = true;
			this.ckbFlush.CheckState = System.Windows.Forms.CheckState.Checked;
			this.ckbFlush.Enabled = false;
			this.ckbFlush.Location = new System.Drawing.Point(11, 67);
			this.ckbFlush.Name = "ckbFlush";
			this.ckbFlush.Size = new System.Drawing.Size(144, 17);
			this.ckbFlush.TabIndex = 2;
			this.ckbFlush.Text = "Toilettenspühlung ziehen";
			this.ckbFlush.UseVisualStyleBackColor = true;
			// 
			// ckbSellIItemsFromToilett
			// 
			this.ckbSellIItemsFromToilett.AutoSize = true;
			this.ckbSellIItemsFromToilett.Location = new System.Drawing.Point(11, 44);
			this.ckbSellIItemsFromToilett.Name = "ckbSellIItemsFromToilett";
			this.ckbSellIItemsFromToilett.Size = new System.Drawing.Size(178, 17);
			this.ckbSellIItemsFromToilett.TabIndex = 1;
			this.ckbSellIItemsFromToilett.Text = "Items aus der Toilette verkaufen";
			this.ckbSellIItemsFromToilett.UseVisualStyleBackColor = true;
			this.ckbSellIItemsFromToilett.CheckedChanged += new System.EventHandler(this.ckbSellIItemsFromToilett_CheckedChanged);
			// 
			// ckbPerfomToilett
			// 
			this.ckbPerfomToilett.AutoSize = true;
			this.ckbPerfomToilett.Location = new System.Drawing.Point(11, 21);
			this.ckbPerfomToilett.Name = "ckbPerfomToilett";
			this.ckbPerfomToilett.Size = new System.Drawing.Size(105, 17);
			this.ckbPerfomToilett.TabIndex = 0;
			this.ckbPerfomToilett.Text = "Aktiviere Toilette";
			this.ckbPerfomToilett.UseVisualStyleBackColor = true;
			this.ckbPerfomToilett.CheckedChanged += new System.EventHandler(this.ckbPerfomToilett_CheckedChanged);
			// 
			// ToiletteSettings
			// 
			this.Controls.Add(this.groupBox1);
			this.Name = "ToiletteSettings";
			this.Size = new System.Drawing.Size(206, 95);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

		}

		public ToiletteSettings() {
			InitializeComponent();
		}

		private AccountSettings Settings;
		public void SetSettings(AccountSettings settings) {
			Settings = settings;

			ckbPerfomToilett.Checked = Settings.PerformToilet;
			ckbSellIItemsFromToilett.Checked = Settings.SellToiletItemIfNotEpic;
		}

		private void ckbSellIItemsFromToilett_CheckedChanged(object sender, EventArgs e) {
			Settings.SellToiletItemIfNotEpic = ckbSellIItemsFromToilett.Checked;
		}

		private void ckbPerfomToilett_CheckedChanged(object sender, EventArgs e) {
			Settings.PerformToilet = ckbPerfomToilett.Checked;
		}
	}
}
