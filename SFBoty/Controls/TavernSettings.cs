using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SFBotyCore.Mechanic.Account;
using SFBotyCore;

namespace SFBoty.Controls {
	public class TavernSettings : UserControl {
		private GroupBox groupBox1;
		private CheckBox checkBox4;
		private CheckBox notitle;
		private Label label2;
		private NumericUpDown nupBeerCount;
		private CheckBox ckbBuyBear;
		private ComboBox ddlQuestMode;
		private Label label1;
		private CheckBox checkBox5;
		private CheckBox ckbPerformQuest;
	
		private void InitializeComponent() {
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.checkBox5 = new System.Windows.Forms.CheckBox();
			this.checkBox4 = new System.Windows.Forms.CheckBox();
			this.notitle = new System.Windows.Forms.CheckBox();
			this.label2 = new System.Windows.Forms.Label();
			this.nupBeerCount = new System.Windows.Forms.NumericUpDown();
			this.ckbBuyBear = new System.Windows.Forms.CheckBox();
			this.ddlQuestMode = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.ckbPerformQuest = new System.Windows.Forms.CheckBox();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.nupBeerCount)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.checkBox5);
			this.groupBox1.Controls.Add(this.checkBox4);
			this.groupBox1.Controls.Add(this.notitle);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.nupBeerCount);
			this.groupBox1.Controls.Add(this.ckbBuyBear);
			this.groupBox1.Controls.Add(this.ddlQuestMode);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.ckbPerformQuest);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(258, 174);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Taverne";
			// 
			// checkBox5
			// 
			this.checkBox5.AutoSize = true;
			this.checkBox5.Enabled = false;
			this.checkBox5.Location = new System.Drawing.Point(11, 141);
			this.checkBox5.Name = "checkBox5";
			this.checkBox5.Size = new System.Drawing.Size(220, 17);
			this.checkBox5.TabIndex = 8;
			this.checkBox5.Text = "Items in Goldberechnung mit einbeziehen";
			this.checkBox5.UseVisualStyleBackColor = true;
			// 
			// checkBox4
			// 
			this.checkBox4.AutoSize = true;
			this.checkBox4.Enabled = false;
			this.checkBox4.Location = new System.Drawing.Point(11, 118);
			this.checkBox4.Name = "checkBox4";
			this.checkBox4.Size = new System.Drawing.Size(118, 17);
			this.checkBox4.TabIndex = 7;
			this.checkBox4.Text = "Spiele nach Events";
			this.checkBox4.UseVisualStyleBackColor = true;
			// 
			// notitle
			// 
			this.notitle.AutoSize = true;
			this.notitle.Enabled = false;
			this.notitle.Location = new System.Drawing.Point(11, 95);
			this.notitle.Name = "notitle";
			this.notitle.Size = new System.Drawing.Size(145, 17);
			this.notitle.TabIndex = 6;
			this.notitle.Text = "Volles Inventar ignorieren";
			this.notitle.UseVisualStyleBackColor = true;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(199, 73);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(44, 13);
			this.label2.TabIndex = 5;
			this.label2.Text = "pro Tag";
			// 
			// nupBeerCount
			// 
			this.nupBeerCount.Location = new System.Drawing.Point(125, 71);
			this.nupBeerCount.Name = "nupBeerCount";
			this.nupBeerCount.Size = new System.Drawing.Size(68, 20);
			this.nupBeerCount.TabIndex = 4;
			this.nupBeerCount.ValueChanged += new System.EventHandler(this.nupBeerCount_ValueChanged);
			// 
			// ckbBuyBear
			// 
			this.ckbBuyBear.AutoSize = true;
			this.ckbBuyBear.Location = new System.Drawing.Point(11, 72);
			this.ckbBuyBear.Name = "ckbBuyBear";
			this.ckbBuyBear.Size = new System.Drawing.Size(108, 17);
			this.ckbBuyBear.TabIndex = 3;
			this.ckbBuyBear.Text = "Kaufe Bier bis zu:";
			this.ckbBuyBear.UseVisualStyleBackColor = true;
			this.ckbBuyBear.CheckedChanged += new System.EventHandler(this.ckbBuyBear_CheckedChanged);
			// 
			// ddlQuestMode
			// 
			this.ddlQuestMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.ddlQuestMode.FormattingEnabled = true;
			this.ddlQuestMode.Items.AddRange(new object[] {
            "BestXP",
            "BestGold",
            "BestTime",
            "HighstMountPerSecond"});
			this.ddlQuestMode.Location = new System.Drawing.Point(72, 44);
			this.ddlQuestMode.Name = "ddlQuestMode";
			this.ddlQuestMode.Size = new System.Drawing.Size(121, 21);
			this.ddlQuestMode.TabIndex = 2;
			this.ddlQuestMode.SelectedIndexChanged += new System.EventHandler(this.ddlQuestMode_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(8, 47);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(58, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Bevorzugt:";
			// 
			// ckbPerformQuest
			// 
			this.ckbPerformQuest.AutoSize = true;
			this.ckbPerformQuest.Location = new System.Drawing.Point(11, 21);
			this.ckbPerformQuest.Name = "ckbPerformQuest";
			this.ckbPerformQuest.Size = new System.Drawing.Size(103, 17);
			this.ckbPerformQuest.TabIndex = 0;
			this.ckbPerformQuest.Text = "Aktiviere Quests";
			this.ckbPerformQuest.UseVisualStyleBackColor = true;
			this.ckbPerformQuest.CheckedChanged += new System.EventHandler(this.ckbPerformQuest_CheckedChanged);
			// 
			// TavernSettings
			// 
			this.Controls.Add(this.groupBox1);
			this.Name = "TavernSettings";
			this.Size = new System.Drawing.Size(258, 174);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.nupBeerCount)).EndInit();
			this.ResumeLayout(false);

		}

		public TavernSettings() {
			InitializeComponent();
		}

		private AccountSettings Settings;
		public void SetSettings(AccountSettings settings) {
			Settings = settings;

			ckbBuyBear.Checked = Settings.BuyBeer;
			ckbPerformQuest.Checked = Settings.PerformQuesten;
			nupBeerCount.Value = Settings.MaxBeerToBuy;
			ddlQuestMode.Text = Settings.QuestMode.ToString();
		}

		private void ddlQuestMode_SelectedIndexChanged(object sender, EventArgs e) {
			Settings.QuestMode = ddlQuestMode.SelectedItem.ToString().ToEnum<AutoQuestMode>();
		}

		private void ckbPerformQuest_CheckedChanged(object sender, EventArgs e) {
			Settings.PerformQuesten = ckbPerformQuest.Checked;
		}

		private void ckbBuyBear_CheckedChanged(object sender, EventArgs e) {
			Settings.BuyBeer = ckbBuyBear.Checked;
		}

		private void nupBeerCount_ValueChanged(object sender, EventArgs e) {
			Settings.MaxBeerToBuy = Convert.ToInt32(nupBeerCount.Value);
		}
	}
}
