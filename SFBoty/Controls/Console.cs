using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SFBoty.Controls {
	public class Console : UserControl {
		private TextBox txtSendLine;
		private System.ComponentModel.IContainer components;
		private RichTextBox txtConsole;

		public event EventHandler<MessageEnterEventArgs> MessageEnter;

		private void InitializeComponent() {
			this.txtConsole = new System.Windows.Forms.RichTextBox();
			this.txtSendLine = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// txtConsole
			// 
			this.txtConsole.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtConsole.BackColor = System.Drawing.Color.Black;
			this.txtConsole.ForeColor = System.Drawing.Color.White;
			this.txtConsole.Location = new System.Drawing.Point(0, 0);
			this.txtConsole.Name = "txtConsole";
			this.txtConsole.ReadOnly = true;
			this.txtConsole.Size = new System.Drawing.Size(419, 345);
			this.txtConsole.TabIndex = 0;
			this.txtConsole.Text = "";
			// 
			// txtSendLine
			// 
			this.txtSendLine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtSendLine.Location = new System.Drawing.Point(1, 342);
			this.txtSendLine.Name = "txtSendLine";
			this.txtSendLine.Size = new System.Drawing.Size(418, 20);
			this.txtSendLine.TabIndex = 1;
			this.txtSendLine.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSendLine_KeyUp);
			// 
			// Console
			// 
			this.Controls.Add(this.txtSendLine);
			this.Controls.Add(this.txtConsole);
			this.Name = "Console";
			this.Size = new System.Drawing.Size(419, 363);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		public Console() {
			InitializeComponent();
		}

		public void SetMessages(List<string> messages) {
			try {
				lock (messages) {
					txtConsole.Text = "";

					foreach (string s in messages) {
						txtConsole.Text += s + Environment.NewLine;
					}
				}
			} catch { 
				//nothing to do
			}
		}

		public void SetMessages(HashSet<string> messages) {
			try {
				lock (messages) {
					txtConsole.Text = "";

					foreach (string s in messages) {
						txtConsole.Text += s + Environment.NewLine;
					}
				}
			} catch {
				//nothing to do
			}
		}

		private void txtSendLine_KeyUp(object sender, KeyEventArgs e) {
			if (e.KeyCode == Keys.Enter) {
				if (MessageEnter != null) {
					MessageEnter(this, new MessageEnterEventArgs(txtSendLine.Text));
				}
				txtSendLine.Text = "";
			}
		}
	}

	public class MessageEnterEventArgs : EventArgs {
		public string Text;

		public MessageEnterEventArgs(string text) {
			this.Text = text;
		}
	}
}
