using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SFBotyCore.Mechanic.Account;

namespace SFBoty.Controls {
	public class TownWatchSettings : UserControl {
		private GroupBox groupBox1;
		private Label label5;
		private NumericUpDown numericUpDown3;
		private Label label4;
		private Label label3;
		private NumericUpDown numMaxTime;
		private Label label2;
		private NumericUpDown numMinTime;
		private Label label1;
		private CheckBox ckbPerfomTownWatch;
	
		private void InitializeComponent() {
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label5 = new System.Windows.Forms.Label();
			this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.numMaxTime = new System.Windows.Forms.NumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.numMinTime = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.ckbPerfomTownWatch = new System.Windows.Forms.CheckBox();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numMaxTime)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numMinTime)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.numericUpDown3);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.numMaxTime);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.numMinTime);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.ckbPerfomTownWatch);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(322, 97);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Stadtwache";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(133, 71);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(52, 13);
			this.label5.TabIndex = 8;
			this.label5.Text = "Stunde/n";
			// 
			// numericUpDown3
			// 
			this.numericUpDown3.Enabled = false;
			this.numericUpDown3.Location = new System.Drawing.Point(56, 69);
			this.numericUpDown3.Name = "numericUpDown3";
			this.numericUpDown3.Size = new System.Drawing.Size(71, 20);
			this.numericUpDown3.TabIndex = 7;
			this.numericUpDown3.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(9, 71);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(41, 13);
			this.label4.TabIndex = 6;
			this.label4.Text = "Jeweils";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(288, 46);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(24, 13);
			this.label3.TabIndex = 5;
			this.label3.Text = "Uhr";
			// 
			// numMaxTime
			// 
			this.numMaxTime.Location = new System.Drawing.Point(239, 44);
			this.numMaxTime.Name = "numMaxTime";
			this.numMaxTime.Size = new System.Drawing.Size(43, 20);
			this.numMaxTime.TabIndex = 4;
			this.numMaxTime.ValueChanged += new System.EventHandler(this.numMaxTime_ValueChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(208, 46);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(25, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "und";
			// 
			// numMinTime
			// 
			this.numMinTime.Location = new System.Drawing.Point(156, 44);
			this.numMinTime.Name = "numMinTime";
			this.numMinTime.Size = new System.Drawing.Size(46, 20);
			this.numMinTime.TabIndex = 2;
			this.numMinTime.ValueChanged += new System.EventHandler(this.numMinTime_ValueChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(9, 46);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(141, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Kurze Stadtwache zwischen";
			// 
			// ckbPerfomTownWatch
			// 
			this.ckbPerfomTownWatch.AutoSize = true;
			this.ckbPerfomTownWatch.Location = new System.Drawing.Point(12, 21);
			this.ckbPerfomTownWatch.Name = "ckbPerfomTownWatch";
			this.ckbPerfomTownWatch.Size = new System.Drawing.Size(127, 17);
			this.ckbPerfomTownWatch.TabIndex = 0;
			this.ckbPerfomTownWatch.Text = "Aktiviere Stadtwache";
			this.ckbPerfomTownWatch.UseVisualStyleBackColor = true;
			this.ckbPerfomTownWatch.CheckedChanged += new System.EventHandler(this.ckbPerfomTownWatch_CheckedChanged);
			// 
			// TownWatchSettings
			// 
			this.Controls.Add(this.groupBox1);
			this.Name = "TownWatchSettings";
			this.Size = new System.Drawing.Size(322, 97);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numMaxTime)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numMinTime)).EndInit();
			this.ResumeLayout(false);

		}

		public TownWatchSettings() {
			InitializeComponent();
		}

		private AccountSettings Settings;
		public void SetSettings(AccountSettings settings) {
			Settings = settings;

			ckbPerfomTownWatch.Checked = Settings.PerformTownwatch;
			numMinTime.Value = Settings.TownWatchMinHourForShortWork;
			numMaxTime.Value = Settings.TownWatchMaxHourForShortWork;
		}

		private void ckbPerfomTownWatch_CheckedChanged(object sender, EventArgs e) {
			Settings.PerformTownwatch = ckbPerfomTownWatch.Checked;
		}

		private void numMinTime_ValueChanged(object sender, EventArgs e) {
			Settings.TownWatchMinHourForShortWork = Convert.ToInt32(numMinTime.Value);
		}

		private void numMaxTime_ValueChanged(object sender, EventArgs e) {
			Settings.TownWatchMaxHourForShortWork = Convert.ToInt32(numMaxTime.Value);
		}

	}
}
