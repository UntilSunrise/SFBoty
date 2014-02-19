using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
		private NumericUpDown numericUpDown1;
		private CheckBox checkBox3;
		private CheckBox checkBox2;
		private CheckBox checkBox7;
		private CheckBox checkBox6;
		private CheckBox checkBox5;
		private CheckBox checkBox1;
	
		private void InitializeComponent() {
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.checkBox2 = new System.Windows.Forms.CheckBox();
			this.checkBox3 = new System.Windows.Forms.CheckBox();
			this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.checkBox4 = new System.Windows.Forms.CheckBox();
			this.label5 = new System.Windows.Forms.Label();
			this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
			this.label6 = new System.Windows.Forms.Label();
			this.checkBox5 = new System.Windows.Forms.CheckBox();
			this.checkBox6 = new System.Windows.Forms.CheckBox();
			this.checkBox7 = new System.Windows.Forms.CheckBox();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
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
			this.groupBox1.Controls.Add(this.numericUpDown1);
			this.groupBox1.Controls.Add(this.checkBox3);
			this.groupBox1.Controls.Add(this.checkBox2);
			this.groupBox1.Controls.Add(this.checkBox1);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(525, 161);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Gilde";
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Checked = true;
			this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBox1.Enabled = false;
			this.checkBox1.Location = new System.Drawing.Point(16, 19);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(94, 17);
			this.checkBox1.TabIndex = 0;
			this.checkBox1.Text = "Aktiviere Gilde";
			this.checkBox1.UseVisualStyleBackColor = true;
			// 
			// checkBox2
			// 
			this.checkBox2.AutoSize = true;
			this.checkBox2.Location = new System.Drawing.Point(16, 43);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Size = new System.Drawing.Size(167, 17);
			this.checkBox2.TabIndex = 1;
			this.checkBox2.Text = "An Gildenkämpfen teilnehmen";
			this.checkBox2.UseVisualStyleBackColor = true;
			// 
			// checkBox3
			// 
			this.checkBox3.AutoSize = true;
			this.checkBox3.Location = new System.Drawing.Point(16, 66);
			this.checkBox3.Name = "checkBox3";
			this.checkBox3.Size = new System.Drawing.Size(97, 17);
			this.checkBox3.TabIndex = 2;
			this.checkBox3.Text = "Spende täglich";
			this.checkBox3.UseVisualStyleBackColor = true;
			// 
			// numericUpDown1
			// 
			this.numericUpDown1.DecimalPlaces = 1;
			this.numericUpDown1.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
			this.numericUpDown1.Location = new System.Drawing.Point(119, 65);
			this.numericUpDown1.Name = "numericUpDown1";
			this.numericUpDown1.Size = new System.Drawing.Size(59, 20);
			this.numericUpDown1.TabIndex = 3;
			this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
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
			// numericUpDown2
			// 
			this.numericUpDown2.Location = new System.Drawing.Point(119, 91);
			this.numericUpDown2.Name = "numericUpDown2";
			this.numericUpDown2.Size = new System.Drawing.Size(59, 20);
			this.numericUpDown2.TabIndex = 5;
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
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(13, 121);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(232, 13);
			this.label3.TabIndex = 7;
			this.label3.Text = "Die Spende erfolgt aks letzte Aktion des Tages.";
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
			// checkBox4
			// 
			this.checkBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.checkBox4.AutoSize = true;
			this.checkBox4.Location = new System.Drawing.Point(291, 19);
			this.checkBox4.Name = "checkBox4";
			this.checkBox4.Size = new System.Drawing.Size(100, 17);
			this.checkBox4.TabIndex = 9;
			this.checkBox4.Text = "Gilde ausbauen";
			this.checkBox4.UseVisualStyleBackColor = true;
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
			// numericUpDown3
			// 
			this.numericUpDown3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
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
			// checkBox5
			// 
			this.checkBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.checkBox5.AutoSize = true;
			this.checkBox5.Location = new System.Drawing.Point(313, 66);
			this.checkBox5.Name = "checkBox5";
			this.checkBox5.Size = new System.Drawing.Size(64, 17);
			this.checkBox5.TabIndex = 13;
			this.checkBox5.Text = "Festung";
			this.checkBox5.UseVisualStyleBackColor = true;
			// 
			// checkBox6
			// 
			this.checkBox6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.checkBox6.AutoSize = true;
			this.checkBox6.Location = new System.Drawing.Point(313, 89);
			this.checkBox6.Name = "checkBox6";
			this.checkBox6.Size = new System.Drawing.Size(79, 17);
			this.checkBox6.TabIndex = 14;
			this.checkBox6.Text = "Goldschatz";
			this.checkBox6.UseVisualStyleBackColor = true;
			// 
			// checkBox7
			// 
			this.checkBox7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.checkBox7.AutoSize = true;
			this.checkBox7.Location = new System.Drawing.Point(313, 112);
			this.checkBox7.Name = "checkBox7";
			this.checkBox7.Size = new System.Drawing.Size(80, 17);
			this.checkBox7.TabIndex = 15;
			this.checkBox7.Text = "Lehrmeister";
			this.checkBox7.UseVisualStyleBackColor = true;
			// 
			// GildenSettings
			// 
			this.Controls.Add(this.groupBox1);
			this.Name = "GildenSettings";
			this.Size = new System.Drawing.Size(525, 167);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
			this.ResumeLayout(false);

		}

		public GildenSettings() {
			InitializeComponent();
		}
	}
}
