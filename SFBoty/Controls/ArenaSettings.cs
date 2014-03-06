using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SFBotyCore.Mechanic.Account;

namespace SFBoty.Controls {
	public class ArenaSettings : UserControl {
		private GroupBox groupBox1;
		private RadioButton optAttackNotSuggestedEnemy;
		private RadioButton optAttackSuggestedEnemy;
		private Label label2;
		private NumericUpDown numMaxRang;
		private NumericUpDown numMinRang;
		private Label label1;
		private Label lblRang;
		private NumericUpDown numLevelDiff;
		private Label label3;
		private CheckBox ckbAttackEnermysInLevelRange;
		private CheckBox ckbPerformArena;

		private void InitializeComponent() {
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.ckbAttackEnermysInLevelRange = new System.Windows.Forms.CheckBox();
			this.lblRang = new System.Windows.Forms.Label();
			this.numLevelDiff = new System.Windows.Forms.NumericUpDown();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.numMaxRang = new System.Windows.Forms.NumericUpDown();
			this.numMinRang = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.optAttackNotSuggestedEnemy = new System.Windows.Forms.RadioButton();
			this.optAttackSuggestedEnemy = new System.Windows.Forms.RadioButton();
			this.ckbPerformArena = new System.Windows.Forms.CheckBox();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numLevelDiff)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numMaxRang)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numMinRang)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.ckbAttackEnermysInLevelRange);
			this.groupBox1.Controls.Add(this.lblRang);
			this.groupBox1.Controls.Add(this.numLevelDiff);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.numMaxRang);
			this.groupBox1.Controls.Add(this.numMinRang);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.optAttackNotSuggestedEnemy);
			this.groupBox1.Controls.Add(this.optAttackSuggestedEnemy);
			this.groupBox1.Controls.Add(this.ckbPerformArena);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(292, 193);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Arena";
			// 
			// ckbAttackEnermysInLevelRange
			// 
			this.ckbAttackEnermysInLevelRange.AutoSize = true;
			this.ckbAttackEnermysInLevelRange.Location = new System.Drawing.Point(15, 35);
			this.ckbAttackEnermysInLevelRange.Name = "ckbAttackEnermysInLevelRange";
			this.ckbAttackEnermysInLevelRange.Size = new System.Drawing.Size(202, 17);
			this.ckbAttackEnermysInLevelRange.TabIndex = 10;
			this.ckbAttackEnermysInLevelRange.Text = "Greife nur Gegner im Levelbereich an";
			this.ckbAttackEnermysInLevelRange.UseVisualStyleBackColor = true;
			this.ckbAttackEnermysInLevelRange.CheckedChanged += new System.EventHandler(this.ckbAttackEnermysInLevelRange_CheckedChanged);
			// 
			// lblRang
			// 
			this.lblRang.AutoSize = true;
			this.lblRang.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
			this.lblRang.Location = new System.Drawing.Point(12, 148);
			this.lblRang.Name = "lblRang";
			this.lblRang.Size = new System.Drawing.Size(193, 13);
			this.lblRang.TabIndex = 9;
			this.lblRang.Text = "Dein Rang (1000): ergibt 1100 bis 1300";
			// 
			// numLevelDiff
			// 
			this.numLevelDiff.Location = new System.Drawing.Point(210, 169);
			this.numLevelDiff.Name = "numLevelDiff";
			this.numLevelDiff.Size = new System.Drawing.Size(73, 20);
			this.numLevelDiff.TabIndex = 8;
			this.numLevelDiff.ValueChanged += new System.EventHandler(this.numLevelDiff_ValueChanged);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 169);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(124, 13);
			this.label3.TabIndex = 7;
			this.label3.Text = "Mindestlevelunterschied:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(179, 121);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(25, 13);
			this.label2.TabIndex = 6;
			this.label2.Text = "und";
			// 
			// numMaxRang
			// 
			this.numMaxRang.Location = new System.Drawing.Point(210, 121);
			this.numMaxRang.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			this.numMaxRang.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
			this.numMaxRang.Name = "numMaxRang";
			this.numMaxRang.Size = new System.Drawing.Size(73, 20);
			this.numMaxRang.TabIndex = 5;
			this.numMaxRang.ValueChanged += new System.EventHandler(this.numMaxRang_ValueChanged);
			// 
			// numMinRang
			// 
			this.numMinRang.Location = new System.Drawing.Point(210, 95);
			this.numMinRang.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
			this.numMinRang.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
			this.numMinRang.Name = "numMinRang";
			this.numMinRang.Size = new System.Drawing.Size(73, 20);
			this.numMinRang.TabIndex = 4;
			this.numMinRang.ValueChanged += new System.EventHandler(this.numMinRang_ValueChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 97);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(192, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "Rangbereich zur Gegnerwahl zwischen";
			// 
			// optAttackNotSuggestedEnemy
			// 
			this.optAttackNotSuggestedEnemy.AutoSize = true;
			this.optAttackNotSuggestedEnemy.Location = new System.Drawing.Point(15, 73);
			this.optAttackNotSuggestedEnemy.Name = "optAttackNotSuggestedEnemy";
			this.optAttackNotSuggestedEnemy.Size = new System.Drawing.Size(191, 17);
			this.optAttackNotSuggestedEnemy.TabIndex = 2;
			this.optAttackNotSuggestedEnemy.TabStop = true;
			this.optAttackNotSuggestedEnemy.Text = "Gegner aus Rangbereich angreifen";
			this.optAttackNotSuggestedEnemy.UseVisualStyleBackColor = true;
			this.optAttackNotSuggestedEnemy.CheckedChanged += new System.EventHandler(this.optAttackNotSuggestedEnemy_CheckedChanged);
			// 
			// optAttackSuggestedEnemy
			// 
			this.optAttackSuggestedEnemy.AutoSize = true;
			this.optAttackSuggestedEnemy.Location = new System.Drawing.Point(15, 53);
			this.optAttackSuggestedEnemy.Name = "optAttackSuggestedEnemy";
			this.optAttackSuggestedEnemy.Size = new System.Drawing.Size(193, 17);
			this.optAttackSuggestedEnemy.TabIndex = 1;
			this.optAttackSuggestedEnemy.TabStop = true;
			this.optAttackSuggestedEnemy.Text = "Vorgeschlagenen Gegner angreifen";
			this.optAttackSuggestedEnemy.UseVisualStyleBackColor = true;
			this.optAttackSuggestedEnemy.CheckedChanged += new System.EventHandler(this.optAttackSuggestedEnemy_CheckedChanged);
			// 
			// ckbPerformArena
			// 
			this.ckbPerformArena.AutoSize = true;
			this.ckbPerformArena.Location = new System.Drawing.Point(15, 16);
			this.ckbPerformArena.Name = "ckbPerformArena";
			this.ckbPerformArena.Size = new System.Drawing.Size(98, 17);
			this.ckbPerformArena.TabIndex = 0;
			this.ckbPerformArena.Text = "Aktiviere Arena";
			this.ckbPerformArena.UseVisualStyleBackColor = true;
			this.ckbPerformArena.CheckedChanged += new System.EventHandler(this.ckbPerformArena_CheckedChanged);
			// 
			// ArenaSettings
			// 
			this.Controls.Add(this.groupBox1);
			this.Name = "ArenaSettings";
			this.Size = new System.Drawing.Size(292, 193);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numLevelDiff)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numMaxRang)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numMinRang)).EndInit();
			this.ResumeLayout(false);

		}

		public ArenaSettings() {
			InitializeComponent();
		}

		private AccountSettings Settings;
		public void SetSettings(AccountSettings settings) {
			Settings = settings;

			ckbPerformArena.Checked = settings.PerformArena;
			optAttackSuggestedEnemy.Checked = Settings.AttackSuggestedEnemy;
			optAttackNotSuggestedEnemy.Checked = !settings.AttackSuggestedEnemy;
			numMinRang.Value = settings.LowerRangeLimit;
			numMaxRang.Value = settings.UpperRangeLimit;
			numLevelDiff.Value = settings.LevelDifference;
			ckbAttackEnermysInLevelRange.Checked = settings.AttackEnemyBetweenRange;

			lblRang.Text = "Dein Rang(1000): ergibt " + (1000 - settings.LowerRangeLimit).ToString() + " bis " + (1000 + settings.UpperRangeLimit).ToString();
		}

		private void ckbPerformArena_CheckedChanged(object sender, EventArgs e) {
			Settings.PerformArena = ckbPerformArena.Checked;
		}

		private void ckbAttackEnermysInLevelRange_CheckedChanged(object sender, EventArgs e) {
			Settings.AttackEnemyBetweenRange = ckbPerformArena.Checked;
		}

		private void optAttackSuggestedEnemy_CheckedChanged(object sender, EventArgs e) {
			Settings.AttackSuggestedEnemy = optAttackSuggestedEnemy.Checked;
		}

		private void optAttackNotSuggestedEnemy_CheckedChanged(object sender, EventArgs e) {
			Settings.AttackSuggestedEnemy = !optAttackNotSuggestedEnemy.Checked;
		}

		private void numMinRang_ValueChanged(object sender, EventArgs e) {
			Settings.LowerRangeLimit = Convert.ToInt32(numMinRang.Value);
			lblRang.Text = "Dein Rang(1000): ergibt " + (1000 - Settings.LowerRangeLimit).ToString() + " bis " + (1000 + Settings.UpperRangeLimit).ToString();
		}

		private void numMaxRang_ValueChanged(object sender, EventArgs e) {
			Settings.UpperRangeLimit = Convert.ToInt32(numMaxRang.Value);
			lblRang.Text = "Dein Rang(1000): ergibt " + (1000 - Settings.LowerRangeLimit).ToString() + " bis " + (1000 + Settings.UpperRangeLimit).ToString();
		}

		private void numLevelDiff_ValueChanged(object sender, EventArgs e) {
			Settings.LevelDifference = Convert.ToInt32(numLevelDiff.Value);
		}
	}
}
