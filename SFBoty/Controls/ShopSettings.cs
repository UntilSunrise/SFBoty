using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SFBotyCore.Mechanic.Account;

namespace SFBoty.Controls {
	public class ShopSettings : UserControl {
		private GroupBox groupBox1;
		private Label label2;
		private NumericUpDown numericUpDown1;
		private Label label1;
		private CheckBox checkBox2;
		private CheckBox checkBox1;
		private GroupBox groupBox2;
		private ComboBox comboBox1;
		private GroupBox groupBox3;
		private CheckBox checkBox4;
		private CheckBox checkBox5;
		private GroupBox groupBox4;
		private NumericUpDown numGoldFactor;
		private Label label3;
		private CheckBox ckbSaveMoney;
		private Label label4;
		private CheckBox checkBox3;
	
		private void InitializeComponent() {
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label2 = new System.Windows.Forms.Label();
			this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.checkBox2 = new System.Windows.Forms.CheckBox();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.checkBox3 = new System.Windows.Forms.CheckBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.checkBox5 = new System.Windows.Forms.CheckBox();
			this.checkBox4 = new System.Windows.Forms.CheckBox();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.label4 = new System.Windows.Forms.Label();
			this.numGoldFactor = new System.Windows.Forms.NumericUpDown();
			this.label3 = new System.Windows.Forms.Label();
			this.ckbSaveMoney = new System.Windows.Forms.CheckBox();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numGoldFactor)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.numericUpDown1);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.checkBox2);
			this.groupBox1.Controls.Add(this.checkBox1);
			this.groupBox1.Location = new System.Drawing.Point(3, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(330, 91);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Tränke";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(150, 62);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(124, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Pilze zum Blättern täglich";
			// 
			// numericUpDown1
			// 
			this.numericUpDown1.Enabled = false;
			this.numericUpDown1.Location = new System.Drawing.Point(96, 60);
			this.numericUpDown1.Name = "numericUpDown1";
			this.numericUpDown1.Size = new System.Drawing.Size(48, 20);
			this.numericUpDown1.TabIndex = 3;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(7, 62);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(83, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Verwende max. ";
			// 
			// checkBox2
			// 
			this.checkBox2.AutoSize = true;
			this.checkBox2.Enabled = false;
			this.checkBox2.Location = new System.Drawing.Point(10, 42);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Size = new System.Drawing.Size(207, 17);
			this.checkBox2.TabIndex = 1;
			this.checkBox2.Text = "Kaufe auch Trank des ewigen Lebens";
			this.checkBox2.UseVisualStyleBackColor = true;
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Enabled = false;
			this.checkBox1.Location = new System.Drawing.Point(10, 19);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(145, 17);
			this.checkBox1.TabIndex = 0;
			this.checkBox1.Text = "Automatischer Trankkauf";
			this.checkBox1.UseVisualStyleBackColor = true;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.comboBox1);
			this.groupBox2.Controls.Add(this.checkBox3);
			this.groupBox2.Location = new System.Drawing.Point(3, 100);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(330, 48);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Reittier";
			// 
			// comboBox1
			// 
			this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox1.Enabled = false;
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Items.AddRange(new object[] {
            "Tiger/Raptor"});
			this.comboBox1.Location = new System.Drawing.Point(174, 17);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(121, 21);
			this.comboBox1.TabIndex = 2;
			// 
			// checkBox3
			// 
			this.checkBox3.AutoSize = true;
			this.checkBox3.Enabled = false;
			this.checkBox3.Location = new System.Drawing.Point(10, 19);
			this.checkBox3.Name = "checkBox3";
			this.checkBox3.Size = new System.Drawing.Size(158, 17);
			this.checkBox3.TabIndex = 0;
			this.checkBox3.Text = "Reittier automatisch kaufen:";
			this.checkBox3.UseVisualStyleBackColor = true;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.checkBox5);
			this.groupBox3.Controls.Add(this.checkBox4);
			this.groupBox3.Location = new System.Drawing.Point(3, 233);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(330, 68);
			this.groupBox3.TabIndex = 2;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Sonstiges";
			// 
			// checkBox5
			// 
			this.checkBox5.AutoSize = true;
			this.checkBox5.Enabled = false;
			this.checkBox5.Location = new System.Drawing.Point(10, 42);
			this.checkBox5.Name = "checkBox5";
			this.checkBox5.Size = new System.Drawing.Size(288, 17);
			this.checkBox5.TabIndex = 1;
			this.checkBox5.Text = "Sammelalbum der Akribie kaufen, wenn es im Laden ist.";
			this.checkBox5.UseVisualStyleBackColor = true;
			// 
			// checkBox4
			// 
			this.checkBox4.AutoSize = true;
			this.checkBox4.Checked = true;
			this.checkBox4.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox4.Enabled = false;
			this.checkBox4.Location = new System.Drawing.Point(10, 19);
			this.checkBox4.Name = "checkBox4";
			this.checkBox4.Size = new System.Drawing.Size(312, 17);
			this.checkBox4.TabIndex = 0;
			this.checkBox4.Text = "Verkaufe den billigsten Gegenstand falls das Inventar voll ist.";
			this.checkBox4.UseVisualStyleBackColor = true;
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.label4);
			this.groupBox4.Controls.Add(this.numGoldFactor);
			this.groupBox4.Controls.Add(this.label3);
			this.groupBox4.Controls.Add(this.ckbSaveMoney);
			this.groupBox4.Location = new System.Drawing.Point(3, 154);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(330, 73);
			this.groupBox4.TabIndex = 3;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Gold aufbewahren";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(195, 45);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(88, 13);
			this.label4.TabIndex = 3;
			this.label4.Text = "ergibt Goldbetrag";
			// 
			// numGoldFactor
			// 
			this.numGoldFactor.DecimalPlaces = 1;
			this.numGoldFactor.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.numGoldFactor.Location = new System.Drawing.Point(128, 43);
			this.numGoldFactor.Name = "numGoldFactor";
			this.numGoldFactor.Size = new System.Drawing.Size(61, 20);
			this.numGoldFactor.TabIndex = 2;
			this.numGoldFactor.ValueChanged += new System.EventHandler(this.numGoldFactor_ValueChanged);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(7, 45);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(115, 13);
			this.label3.TabIndex = 1;
			this.label3.Text = "Teuerster Statpreis mal";
			// 
			// ckbSaveMoney
			// 
			this.ckbSaveMoney.AutoSize = true;
			this.ckbSaveMoney.Location = new System.Drawing.Point(10, 19);
			this.ckbSaveMoney.Name = "ckbSaveMoney";
			this.ckbSaveMoney.Size = new System.Drawing.Size(113, 17);
			this.ckbSaveMoney.TabIndex = 0;
			this.ckbSaveMoney.Text = "Gold aufbewahren";
			this.ckbSaveMoney.UseVisualStyleBackColor = true;
			this.ckbSaveMoney.CheckedChanged += new System.EventHandler(this.ckbSaveMoney_CheckedChanged);
			// 
			// ShopSettings
			// 
			this.Controls.Add(this.groupBox4);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Name = "ShopSettings";
			this.Size = new System.Drawing.Size(338, 307);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numGoldFactor)).EndInit();
			this.ResumeLayout(false);

		}

		public ShopSettings() {
			InitializeComponent();
		}

		private AccountSettings Settings;
		public void SetSettings(AccountSettings settings) {
			Settings = settings;
			ckbSaveMoney.Checked = settings.SaveMoney;
			numGoldFactor.Value = new decimal(settings.SaveMoneyFactor);
		}

		private void ckbSaveMoney_CheckedChanged(object sender, EventArgs e) {
			Settings.SaveMoney = ckbSaveMoney.Checked;
		}

		private void numGoldFactor_ValueChanged(object sender, EventArgs e) {
			Settings.SaveMoneyFactor = Convert.ToSingle(numGoldFactor.Value);
		}
	}
}
