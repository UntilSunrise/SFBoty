namespace SFBoty.NewAccounts {
	partial class EditSettings {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.btnSave = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage7 = new System.Windows.Forms.TabPage();
			this.allgemeineSettings1 = new SFBoty.Controls.AllgemeineSettings();
			this.tabPage8 = new System.Windows.Forms.TabPage();
			this.tavernSettings1 = new SFBoty.Controls.TavernSettings();
			this.townWatchSettings1 = new SFBoty.Controls.TownWatchSettings();
			this.toiletteSettings1 = new SFBoty.Controls.ToiletteSettings();
			this.tabPage9 = new System.Windows.Forms.TabPage();
			this.tabPage10 = new System.Windows.Forms.TabPage();
			this.tabPage11 = new System.Windows.Forms.TabPage();
			this.tabPage12 = new System.Windows.Forms.TabPage();
			this.tabControl1.SuspendLayout();
			this.tabPage7.SuspendLayout();
			this.tabPage8.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnSave
			// 
			this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnSave.Location = new System.Drawing.Point(519, 439);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(75, 23);
			this.btnSave.TabIndex = 0;
			this.btnSave.Text = "Speichern";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(438, 439);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 1;
			this.btnCancel.Text = "Abbruch";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// tabControl1
			// 
			this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl1.Controls.Add(this.tabPage7);
			this.tabControl1.Controls.Add(this.tabPage8);
			this.tabControl1.Controls.Add(this.tabPage9);
			this.tabControl1.Controls.Add(this.tabPage10);
			this.tabControl1.Controls.Add(this.tabPage11);
			this.tabControl1.Controls.Add(this.tabPage12);
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(609, 433);
			this.tabControl1.TabIndex = 2;
			// 
			// tabPage7
			// 
			this.tabPage7.Controls.Add(this.allgemeineSettings1);
			this.tabPage7.Location = new System.Drawing.Point(4, 22);
			this.tabPage7.Name = "tabPage7";
			this.tabPage7.Size = new System.Drawing.Size(601, 407);
			this.tabPage7.TabIndex = 0;
			this.tabPage7.Text = "Allgemein";
			this.tabPage7.UseVisualStyleBackColor = true;
			// 
			// allgemeineSettings1
			// 
			this.allgemeineSettings1.Location = new System.Drawing.Point(8, 3);
			this.allgemeineSettings1.Name = "allgemeineSettings1";
			this.allgemeineSettings1.Size = new System.Drawing.Size(309, 272);
			this.allgemeineSettings1.TabIndex = 0;
			// 
			// tabPage8
			// 
			this.tabPage8.Controls.Add(this.tavernSettings1);
			this.tabPage8.Controls.Add(this.townWatchSettings1);
			this.tabPage8.Controls.Add(this.toiletteSettings1);
			this.tabPage8.Location = new System.Drawing.Point(4, 22);
			this.tabPage8.Name = "tabPage8";
			this.tabPage8.Size = new System.Drawing.Size(601, 407);
			this.tabPage8.TabIndex = 1;
			this.tabPage8.Text = "Verhalten";
			this.tabPage8.UseVisualStyleBackColor = true;
			// 
			// tavernSettings1
			// 
			this.tavernSettings1.Enabled = false;
			this.tavernSettings1.Location = new System.Drawing.Point(11, 3);
			this.tavernSettings1.Name = "tavernSettings1";
			this.tavernSettings1.Size = new System.Drawing.Size(373, 174);
			this.tavernSettings1.TabIndex = 3;
			// 
			// townWatchSettings1
			// 
			this.townWatchSettings1.Enabled = false;
			this.townWatchSettings1.Location = new System.Drawing.Point(11, 307);
			this.townWatchSettings1.Name = "townWatchSettings1";
			this.townWatchSettings1.Size = new System.Drawing.Size(373, 97);
			this.townWatchSettings1.TabIndex = 2;
			// 
			// toiletteSettings1
			// 
			this.toiletteSettings1.Enabled = false;
			this.toiletteSettings1.Location = new System.Drawing.Point(11, 183);
			this.toiletteSettings1.Name = "toiletteSettings1";
			this.toiletteSettings1.Size = new System.Drawing.Size(373, 118);
			this.toiletteSettings1.TabIndex = 1;
			// 
			// tabPage9
			// 
			this.tabPage9.Location = new System.Drawing.Point(4, 22);
			this.tabPage9.Name = "tabPage9";
			this.tabPage9.Size = new System.Drawing.Size(601, 407);
			this.tabPage9.TabIndex = 2;
			this.tabPage9.Text = "Gilde";
			this.tabPage9.UseVisualStyleBackColor = true;
			// 
			// tabPage10
			// 
			this.tabPage10.Location = new System.Drawing.Point(4, 22);
			this.tabPage10.Name = "tabPage10";
			this.tabPage10.Size = new System.Drawing.Size(601, 407);
			this.tabPage10.TabIndex = 3;
			this.tabPage10.Text = "Charakter";
			this.tabPage10.UseVisualStyleBackColor = true;
			// 
			// tabPage11
			// 
			this.tabPage11.Location = new System.Drawing.Point(4, 22);
			this.tabPage11.Name = "tabPage11";
			this.tabPage11.Size = new System.Drawing.Size(601, 407);
			this.tabPage11.TabIndex = 4;
			this.tabPage11.Text = "Händler";
			this.tabPage11.UseVisualStyleBackColor = true;
			// 
			// tabPage12
			// 
			this.tabPage12.Location = new System.Drawing.Point(4, 22);
			this.tabPage12.Name = "tabPage12";
			this.tabPage12.Size = new System.Drawing.Size(601, 407);
			this.tabPage12.TabIndex = 5;
			this.tabPage12.Text = "Benachrichtigungen";
			this.tabPage12.UseVisualStyleBackColor = true;
			// 
			// EditSettings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(606, 474);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnSave);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "EditSettings";
			this.Text = "EditSettings";
			this.tabControl1.ResumeLayout(false);
			this.tabPage7.ResumeLayout(false);
			this.tabPage8.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage7;
		private System.Windows.Forms.TabPage tabPage8;
		private System.Windows.Forms.TabPage tabPage9;
		private System.Windows.Forms.TabPage tabPage10;
		private System.Windows.Forms.TabPage tabPage11;
		private System.Windows.Forms.TabPage tabPage12;
		private Controls.AllgemeineSettings allgemeineSettings1;
		private Controls.ToiletteSettings toiletteSettings1;
		private Controls.TownWatchSettings townWatchSettings1;
		private Controls.TavernSettings tavernSettings1;
	}
}