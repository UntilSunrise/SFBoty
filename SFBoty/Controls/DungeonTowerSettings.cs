using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SFBotyCore.Mechanic.Account;

namespace SFBoty.Controls {
	public class DungeonTowerSettings : UserControl {
		private GroupBox groupBox1;
		private Label label4;
		private Label label3;
		private NumericUpDown numericUpDown2;
		private NumericUpDown numericUpDown1;
		private Label label2;
		private Label label1;
		private CheckBox checkBox2;
		private CheckBox ckbPerformDungeon;

		private void InitializeComponent() {
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
			this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.checkBox2 = new System.Windows.Forms.CheckBox();
			this.ckbPerformDungeon = new System.Windows.Forms.CheckBox();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.numericUpDown2);
			this.groupBox1.Controls.Add(this.numericUpDown1);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.checkBox2);
			this.groupBox1.Controls.Add(this.ckbPerformDungeon);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(235, 174);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Dungeon  –  Turm";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
			this.label4.Location = new System.Drawing.Point(12, 144);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(175, 13);
			this.label4.TabIndex = 6;
			this.label4.Text = "Dein Level (100): ergibt 105 bis 110";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 121);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(146, 13);
			this.label3.TabIndex = 5;
			this.label3.Text = "Maximaler Stufenunterschied:";
			// 
			// numericUpDown2
			// 
			this.numericUpDown2.Enabled = false;
			this.numericUpDown2.Location = new System.Drawing.Point(164, 119);
			this.numericUpDown2.Name = "numericUpDown2";
			this.numericUpDown2.Size = new System.Drawing.Size(56, 20);
			this.numericUpDown2.TabIndex = 4;
			// 
			// numericUpDown1
			// 
			this.numericUpDown1.Enabled = false;
			this.numericUpDown1.Location = new System.Drawing.Point(164, 93);
			this.numericUpDown1.Name = "numericUpDown1";
			this.numericUpDown1.Size = new System.Drawing.Size(56, 20);
			this.numericUpDown1.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 95);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(143, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "Minimaler Stufenunterschied:";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 73);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(149, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Mindestunterschied Dungeon:";
			// 
			// checkBox2
			// 
			this.checkBox2.AutoSize = true;
			this.checkBox2.Enabled = false;
			this.checkBox2.Location = new System.Drawing.Point(15, 42);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Size = new System.Drawing.Size(94, 17);
			this.checkBox2.TabIndex = 1;
			this.checkBox2.Text = "Aktiviere Turm";
			this.checkBox2.UseVisualStyleBackColor = true;
			// 
			// ckbPerformDungeon
			// 
			this.ckbPerformDungeon.AutoSize = true;
			this.ckbPerformDungeon.Location = new System.Drawing.Point(15, 19);
			this.ckbPerformDungeon.Name = "ckbPerformDungeon";
			this.ckbPerformDungeon.Size = new System.Drawing.Size(114, 17);
			this.ckbPerformDungeon.TabIndex = 0;
			this.ckbPerformDungeon.Text = "Aktiviere Dungeon";
			this.ckbPerformDungeon.UseVisualStyleBackColor = true;
			this.ckbPerformDungeon.CheckedChanged += new System.EventHandler(this.ckbPerformDungeon_CheckedChanged);
			// 
			// DungeonTowerSettings
			// 
			this.Controls.Add(this.groupBox1);
			this.Name = "DungeonTowerSettings";
			this.Size = new System.Drawing.Size(235, 174);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
			this.ResumeLayout(false);

		}

		public DungeonTowerSettings() {
			InitializeComponent();
		}

		private AccountSettings Settings;
		public void SetSettings(AccountSettings settings) {
			Settings = settings;

			ckbPerformDungeon.Checked = settings.PerformDungeons;
		}

		private void ckbPerformDungeon_CheckedChanged(object sender, EventArgs e) {
			Settings.PerformDungeons = ckbPerformDungeon.Checked;
		}
	}
}
