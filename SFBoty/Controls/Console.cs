using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SFBoty.Controls {
	public class Console : UserControl {
		private RichTextBox txtConsole;

		private void InitializeComponent() {
			this.txtConsole = new System.Windows.Forms.RichTextBox();
			this.SuspendLayout();
			// 
			// txtConsole
			// 
			this.txtConsole.BackColor = System.Drawing.Color.Black;
			this.txtConsole.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtConsole.ForeColor = System.Drawing.Color.White;
			this.txtConsole.Location = new System.Drawing.Point(0, 0);
			this.txtConsole.Name = "txtConsole";
			this.txtConsole.ReadOnly = true;
			this.txtConsole.Size = new System.Drawing.Size(419, 371);
			this.txtConsole.TabIndex = 0;
			this.txtConsole.Text = "";
			// 
			// Console
			// 
			this.Controls.Add(this.txtConsole);
			this.Name = "Console";
			this.Size = new System.Drawing.Size(419, 371);
			this.ResumeLayout(false);

		}

		public Console() {
			InitializeComponent();
		}

		public void SetMessages(List<string> messages) {
			txtConsole.Text = "";

			foreach (string s in messages) {
				txtConsole.Text += DateTime.Now.ToString() + ": " + s + Environment.NewLine;
			}
		}
	}
}
