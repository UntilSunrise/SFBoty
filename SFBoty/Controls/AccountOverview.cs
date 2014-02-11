using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SFBotyCore.Mechanic.Account;
using System.IO;
using System.Xml.Serialization;

namespace SFBoty.Controls {
	public class AccountOverview : UserControl {
		#region Fields
		private Button btnLoadAccounts;
		private DataGridViewTextBoxColumn ID;
		private DataGridViewTextBoxColumn Test1;
		private DataGridViewTextBoxColumn Test2;
		private DataGridView dgvAccountList;
		#endregion	

		private void InitializeComponent() {
			this.dgvAccountList = new System.Windows.Forms.DataGridView();
			this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Test1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Test2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.btnLoadAccounts = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dgvAccountList)).BeginInit();
			this.SuspendLayout();
			// 
			// dgvAccountList
			// 
			this.dgvAccountList.AllowUserToAddRows = false;
			this.dgvAccountList.AllowUserToDeleteRows = false;
			this.dgvAccountList.AllowUserToResizeColumns = false;
			this.dgvAccountList.AllowUserToResizeRows = false;
			this.dgvAccountList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvAccountList.BackgroundColor = System.Drawing.Color.White;
			this.dgvAccountList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvAccountList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Test1,
            this.Test2});
			this.dgvAccountList.Dock = System.Windows.Forms.DockStyle.Top;
			this.dgvAccountList.EnableHeadersVisualStyles = false;
			this.dgvAccountList.GridColor = System.Drawing.Color.Black;
			this.dgvAccountList.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.dgvAccountList.Location = new System.Drawing.Point(0, 0);
			this.dgvAccountList.MultiSelect = false;
			this.dgvAccountList.Name = "dgvAccountList";
			this.dgvAccountList.ReadOnly = true;
			this.dgvAccountList.RowHeadersVisible = false;
			this.dgvAccountList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvAccountList.ShowCellErrors = false;
			this.dgvAccountList.ShowCellToolTips = false;
			this.dgvAccountList.ShowEditingIcon = false;
			this.dgvAccountList.ShowRowErrors = false;
			this.dgvAccountList.Size = new System.Drawing.Size(575, 481);
			this.dgvAccountList.TabIndex = 0;
			// 
			// ID
			// 
			this.ID.HeaderText = "Account";
			this.ID.Name = "ID";
			this.ID.ReadOnly = true;
			// 
			// Test1
			// 
			this.Test1.HeaderText = "Server";
			this.Test1.Name = "Test1";
			this.Test1.ReadOnly = true;
			// 
			// Test2
			// 
			this.Test2.HeaderText = "Status";
			this.Test2.Name = "Test2";
			this.Test2.ReadOnly = true;
			// 
			// btnLoadAccounts
			// 
			this.btnLoadAccounts.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.btnLoadAccounts.Location = new System.Drawing.Point(0, 497);
			this.btnLoadAccounts.Name = "btnLoadAccounts";
			this.btnLoadAccounts.Size = new System.Drawing.Size(575, 23);
			this.btnLoadAccounts.TabIndex = 1;
			this.btnLoadAccounts.Text = "Load Accounts From XML";
			this.btnLoadAccounts.UseVisualStyleBackColor = true;
			this.btnLoadAccounts.Click += new System.EventHandler(this.btnLoadAccounts_Click);
			// 
			// AccountOverview
			// 
			this.Controls.Add(this.btnLoadAccounts);
			this.Controls.Add(this.dgvAccountList);
			this.Name = "AccountOverview";
			this.Size = new System.Drawing.Size(575, 520);
			((System.ComponentModel.ISupportInitialize)(this.dgvAccountList)).EndInit();
			this.ResumeLayout(false);

		}

		#region EventsHandling
		private void btnLoadAccounts_Click(object sender, EventArgs e) {
			LoadAllAccountsFromXML();
		}
		#endregion

		#region Public Methoden
		public void LoadAllAccountsFromXML() {
			dgvAccountList.Rows.Clear();
			List<AccountSettings> settings = AccountSettings();
			foreach (AccountSettings setting in settings) {
				dgvAccountList.Rows.Add(setting.Server, setting.Username, "gestopt");
			}
		}
		#endregion

		#region Private Methoden
		private static List<AccountSettings> AccountSettings() {
			if (File.Exists("acc.sav")) {
				FileStream fs = new FileStream("acc.sav", FileMode.Open);
				List<AccountSettings> acc;

				XmlSerializer xml = new XmlSerializer(typeof(List<AccountSettings>));
				acc = (List<AccountSettings>)xml.Deserialize(fs);
				fs.Close();

				return acc;
			} else {
				return new List<AccountSettings>();
			}
		}
		#endregion

		public AccountOverview() {
			InitializeComponent();
		}

	}
}
