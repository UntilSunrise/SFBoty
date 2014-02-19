using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SFBoty.Controls {
	public class ArenaSettings : UserControl {
		private GroupBox groupBox1;
		private RadioButton radioButton2;
		private RadioButton radioButton1;
		private Label label2;
		private NumericUpDown numericUpDown2;
		private NumericUpDown numericUpDown1;
		private Label label1;
		private Label label4;
		private NumericUpDown numericUpDown3;
		private Label label3;
		private CheckBox checkBox1;

		private void InitializeComponent() {
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.label1 = new System.Windows.Forms.Label();
			this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
			this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
			this.label4 = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.numericUpDown3);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.numericUpDown2);
			this.groupBox1.Controls.Add(this.numericUpDown1);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.radioButton2);
			this.groupBox1.Controls.Add(this.radioButton1);
			this.groupBox1.Controls.Add(this.checkBox1);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupBox1.Location = new System.Drawing.Point(0, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(292, 193);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Arena";
			// 
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Location = new System.Drawing.Point(15, 19);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(98, 17);
			this.checkBox1.TabIndex = 0;
			this.checkBox1.Text = "Aktiviere Arena";
			this.checkBox1.UseVisualStyleBackColor = true;
			// 
			// radioButton1
			// 
			this.radioButton1.AutoSize = true;
			this.radioButton1.Location = new System.Drawing.Point(15, 43);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new System.Drawing.Size(193, 17);
			this.radioButton1.TabIndex = 1;
			this.radioButton1.TabStop = true;
			this.radioButton1.Text = "Vorgeschlagenen Gegner angreifen";
			this.radioButton1.UseVisualStyleBackColor = true;
			// 
			// radioButton2
			// 
			this.radioButton2.AutoSize = true;
			this.radioButton2.Location = new System.Drawing.Point(15, 67);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new System.Drawing.Size(191, 17);
			this.radioButton2.TabIndex = 2;
			this.radioButton2.TabStop = true;
			this.radioButton2.Text = "Gegner aus Rangbereich angreifen";
			this.radioButton2.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 91);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(192, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "Rangbereich zur Gegnerwahl zwischen";
			// 
			// numericUpDown1
			// 
			this.numericUpDown1.Location = new System.Drawing.Point(210, 89);
			this.numericUpDown1.Name = "numericUpDown1";
			this.numericUpDown1.Size = new System.Drawing.Size(73, 20);
			this.numericUpDown1.TabIndex = 4;
			// 
			// numericUpDown2
			// 
			this.numericUpDown2.Location = new System.Drawing.Point(210, 115);
			this.numericUpDown2.Name = "numericUpDown2";
			this.numericUpDown2.Size = new System.Drawing.Size(73, 20);
			this.numericUpDown2.TabIndex = 5;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(179, 115);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(25, 13);
			this.label2.TabIndex = 6;
			this.label2.Text = "und";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 163);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(124, 13);
			this.label3.TabIndex = 7;
			this.label3.Text = "Mindestlevelunterschied:";
			// 
			// numericUpDown3
			// 
			this.numericUpDown3.Location = new System.Drawing.Point(210, 163);
			this.numericUpDown3.Name = "numericUpDown3";
			this.numericUpDown3.Size = new System.Drawing.Size(73, 20);
			this.numericUpDown3.TabIndex = 8;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
			this.label4.Location = new System.Drawing.Point(12, 142);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(193, 13);
			this.label4.TabIndex = 9;
			this.label4.Text = "Dein Rang (1000): ergibt 1100 bis 1300";
			// 
			// ArenaSettings
			// 
			this.Controls.Add(this.groupBox1);
			this.Name = "ArenaSettings";
			this.Size = new System.Drawing.Size(292, 193);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
			this.ResumeLayout(false);

		}

		public ArenaSettings() {
			InitializeComponent();
		}
	}
}
