using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SFBoty.Controls {
	public class CharacterSettings : UserControl {
		private GroupBox groupBox1;
		private RadioButton radioButton2;
		private RadioButton radioButton1;
		private GroupBox groupBox2;
		private NumericUpDown numericUpDown5;
		private TrackBar trackBar5;
		private Label label5;
		private NumericUpDown numericUpDown4;
		private TrackBar trackBar4;
		private Label label4;
		private NumericUpDown numericUpDown3;
		private TrackBar trackBar3;
		private Label label3;
		private NumericUpDown numericUpDown2;
		private TrackBar trackBar2;
		private Label label2;
		private NumericUpDown numericUpDown1;
		private TrackBar trackBar1;
		private Label label1;
		private GroupBox groupBox3;
		private Label label6;
		private CheckBox checkBox2;
		private CheckBox checkBox1;

		private void InitializeComponent() {
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.numericUpDown5 = new System.Windows.Forms.NumericUpDown();
			this.trackBar5 = new System.Windows.Forms.TrackBar();
			this.label5 = new System.Windows.Forms.Label();
			this.numericUpDown4 = new System.Windows.Forms.NumericUpDown();
			this.trackBar4 = new System.Windows.Forms.TrackBar();
			this.label4 = new System.Windows.Forms.Label();
			this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
			this.trackBar3 = new System.Windows.Forms.TrackBar();
			this.label3 = new System.Windows.Forms.Label();
			this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
			this.trackBar2 = new System.Windows.Forms.TrackBar();
			this.label2 = new System.Windows.Forms.Label();
			this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
			this.trackBar1 = new System.Windows.Forms.TrackBar();
			this.label1 = new System.Windows.Forms.Label();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.label6 = new System.Windows.Forms.Label();
			this.checkBox2 = new System.Windows.Forms.CheckBox();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown5)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBar5)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBar4)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBar3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.radioButton2);
			this.groupBox1.Controls.Add(this.radioButton1);
			this.groupBox1.Controls.Add(this.groupBox2);
			this.groupBox1.Controls.Add(this.checkBox1);
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
			this.groupBox2.Controls.Add(this.numericUpDown5);
			this.groupBox2.Controls.Add(this.trackBar5);
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Controls.Add(this.numericUpDown4);
			this.groupBox2.Controls.Add(this.trackBar4);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Controls.Add(this.numericUpDown3);
			this.groupBox2.Controls.Add(this.trackBar3);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Controls.Add(this.numericUpDown2);
			this.groupBox2.Controls.Add(this.trackBar2);
			this.groupBox2.Controls.Add(this.label2);
			this.groupBox2.Controls.Add(this.numericUpDown1);
			this.groupBox2.Controls.Add(this.trackBar1);
			this.groupBox2.Controls.Add(this.label1);
			this.groupBox2.Location = new System.Drawing.Point(16, 42);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(587, 207);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Prozentuale Verteilung der Attribute";
			// 
			// numericUpDown5
			// 
			this.numericUpDown5.Location = new System.Drawing.Point(520, 159);
			this.numericUpDown5.Name = "numericUpDown5";
			this.numericUpDown5.Size = new System.Drawing.Size(58, 20);
			this.numericUpDown5.TabIndex = 14;
			// 
			// trackBar5
			// 
			this.trackBar5.Location = new System.Drawing.Point(74, 154);
			this.trackBar5.Maximum = 100;
			this.trackBar5.Name = "trackBar5";
			this.trackBar5.Size = new System.Drawing.Size(442, 45);
			this.trackBar5.TabIndex = 13;
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
			// numericUpDown4
			// 
			this.numericUpDown4.Location = new System.Drawing.Point(520, 127);
			this.numericUpDown4.Name = "numericUpDown4";
			this.numericUpDown4.Size = new System.Drawing.Size(58, 20);
			this.numericUpDown4.TabIndex = 11;
			// 
			// trackBar4
			// 
			this.trackBar4.Location = new System.Drawing.Point(74, 122);
			this.trackBar4.Maximum = 100;
			this.trackBar4.Name = "trackBar4";
			this.trackBar4.Size = new System.Drawing.Size(442, 45);
			this.trackBar4.TabIndex = 10;
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
			// numericUpDown3
			// 
			this.numericUpDown3.Location = new System.Drawing.Point(520, 94);
			this.numericUpDown3.Name = "numericUpDown3";
			this.numericUpDown3.Size = new System.Drawing.Size(58, 20);
			this.numericUpDown3.TabIndex = 8;
			// 
			// trackBar3
			// 
			this.trackBar3.Location = new System.Drawing.Point(74, 89);
			this.trackBar3.Maximum = 100;
			this.trackBar3.Name = "trackBar3";
			this.trackBar3.Size = new System.Drawing.Size(442, 45);
			this.trackBar3.TabIndex = 7;
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
			// numericUpDown2
			// 
			this.numericUpDown2.Location = new System.Drawing.Point(520, 59);
			this.numericUpDown2.Name = "numericUpDown2";
			this.numericUpDown2.Size = new System.Drawing.Size(58, 20);
			this.numericUpDown2.TabIndex = 5;
			// 
			// trackBar2
			// 
			this.trackBar2.Location = new System.Drawing.Point(74, 54);
			this.trackBar2.Maximum = 100;
			this.trackBar2.Name = "trackBar2";
			this.trackBar2.Size = new System.Drawing.Size(442, 45);
			this.trackBar2.TabIndex = 4;
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
			// numericUpDown1
			// 
			this.numericUpDown1.Location = new System.Drawing.Point(520, 26);
			this.numericUpDown1.Name = "numericUpDown1";
			this.numericUpDown1.Size = new System.Drawing.Size(58, 20);
			this.numericUpDown1.TabIndex = 2;
			// 
			// trackBar1
			// 
			this.trackBar1.Location = new System.Drawing.Point(74, 21);
			this.trackBar1.Maximum = 100;
			this.trackBar1.Name = "trackBar1";
			this.trackBar1.Size = new System.Drawing.Size(442, 45);
			this.trackBar1.TabIndex = 1;
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
			// checkBox1
			// 
			this.checkBox1.AutoSize = true;
			this.checkBox1.Location = new System.Drawing.Point(16, 19);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new System.Drawing.Size(124, 17);
			this.checkBox1.TabIndex = 0;
			this.checkBox1.Text = "Aktiviere Attributkauf";
			this.checkBox1.UseVisualStyleBackColor = true;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.label6);
			this.groupBox3.Controls.Add(this.checkBox2);
			this.groupBox3.Location = new System.Drawing.Point(3, 317);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(615, 71);
			this.groupBox3.TabIndex = 1;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Inventar";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(13, 48);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(462, 13);
			this.label6.TabIndex = 1;
			this.label6.Text = "Unter Verwendung der oben eingestellten Attributverteilung wird das bessere Equip" +
    "ment ermittelt.";
			// 
			// checkBox2
			// 
			this.checkBox2.AutoSize = true;
			this.checkBox2.Location = new System.Drawing.Point(16, 19);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Size = new System.Drawing.Size(240, 17);
			this.checkBox2.TabIndex = 0;
			this.checkBox2.Text = "Bessere Gegenstände automatisch ausrüsten";
			this.checkBox2.UseVisualStyleBackColor = true;
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
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown5)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBar5)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBar4)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBar3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.ResumeLayout(false);

		}

		public CharacterSettings() {
			InitializeComponent();
		}
	}
}
