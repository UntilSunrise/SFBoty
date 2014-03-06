namespace SFBoty {
	partial class MainWindow {
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
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.accountOverview1 = new SFBoty.Controls.AccountOverview();
			this.console1 = new SFBoty.Controls.Console();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.SuspendLayout();
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.accountOverview1);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.console1);
			this.splitContainer1.Size = new System.Drawing.Size(1060, 507);
			this.splitContainer1.SplitterDistance = 353;
			this.splitContainer1.TabIndex = 0;
			// 
			// accountOverview1
			// 
			this.accountOverview1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.accountOverview1.Location = new System.Drawing.Point(0, 0);
			this.accountOverview1.Name = "accountOverview1";
			this.accountOverview1.Size = new System.Drawing.Size(353, 507);
			this.accountOverview1.TabIndex = 0;
			// 
			// console1
			// 
			this.console1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.console1.Location = new System.Drawing.Point(0, 0);
			this.console1.Name = "console1";
			this.console1.Size = new System.Drawing.Size(703, 507);
			this.console1.TabIndex = 0;
			// 
			// MainWindow
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1060, 507);
			this.Controls.Add(this.splitContainer1);
			this.Name = "MainWindow";
			this.Text = "SFBoty";
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.SplitContainer splitContainer1;
		private Controls.AccountOverview accountOverview1;
		private Controls.Console console1;

	}
}

