using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SFBotyCore.Mechanic.Account;
using System.IO;
using System.Xml.Serialization;
using SFBoty.NewAccounts;

namespace SFBoty.Controls {
	public class AccountOverview : UserControl {
		#region Fields
		private Button btnLoadAccounts;
		private DataGridViewTextBoxColumn ID;
		private DataGridViewTextBoxColumn Test1;
		private DataGridViewTextBoxColumn Test2;
		private Button btnCreateAccount;
		private Button btnSaveAll;
		private DataGridView dgvAccountList;
		private Button btnStop;
		private Button btnStart;
		private Button btnStartAll;

		private List<AccountSettings> Settings = new List<AccountSettings>();
		public event EventHandler<EventSelltingsArgs> StartBot;
		public event EventHandler<EventSelltingsArgs> StopBot;
		public event EventHandler<EventSelltingsArgs> StartAllBots;
		public event EventHandler<EventSelltingsArgs> SelectedAccountChanged;
		#endregion

		private void InitializeComponent() {
			this.dgvAccountList = new System.Windows.Forms.DataGridView();
			this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Test1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Test2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.btnLoadAccounts = new System.Windows.Forms.Button();
			this.btnCreateAccount = new System.Windows.Forms.Button();
			this.btnSaveAll = new System.Windows.Forms.Button();
			this.btnStop = new System.Windows.Forms.Button();
			this.btnStart = new System.Windows.Forms.Button();
			this.btnStartAll = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dgvAccountList)).BeginInit();
			this.SuspendLayout();
			// 
			// dgvAccountList
			// 
			this.dgvAccountList.AllowUserToAddRows = false;
			this.dgvAccountList.AllowUserToDeleteRows = false;
			this.dgvAccountList.AllowUserToResizeColumns = false;
			this.dgvAccountList.AllowUserToResizeRows = false;
			this.dgvAccountList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
			| System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			this.dgvAccountList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dgvAccountList.BackgroundColor = System.Drawing.Color.White;
			this.dgvAccountList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvAccountList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Test1,
            this.Test2});
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
			this.dgvAccountList.Size = new System.Drawing.Size(575, 467);
			this.dgvAccountList.TabIndex = 0;
			this.dgvAccountList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAccountList_CellContentClick);
			this.dgvAccountList.SelectionChanged += new System.EventHandler(this.dgvAccountList_SelectionChanged);
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
			this.btnLoadAccounts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnLoadAccounts.Location = new System.Drawing.Point(0, 473);
			this.btnLoadAccounts.Name = "btnLoadAccounts";
			this.btnLoadAccounts.Size = new System.Drawing.Size(92, 23);
			this.btnLoadAccounts.TabIndex = 1;
			this.btnLoadAccounts.Text = "Load Accounts";
			this.btnLoadAccounts.UseVisualStyleBackColor = true;
			this.btnLoadAccounts.Click += new System.EventHandler(this.btnLoadAccounts_Click);
			// 
			// btnCreateAccount
			// 
			this.btnCreateAccount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			this.btnCreateAccount.Location = new System.Drawing.Point(98, 473);
			this.btnCreateAccount.Name = "btnCreateAccount";
			this.btnCreateAccount.Size = new System.Drawing.Size(368, 23);
			this.btnCreateAccount.TabIndex = 2;
			this.btnCreateAccount.Text = "Create New Account";
			this.btnCreateAccount.UseVisualStyleBackColor = true;
			this.btnCreateAccount.Click += new System.EventHandler(this.btnCreateAccount_Click);
			// 
			// btnSaveAll
			// 
			this.btnSaveAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSaveAll.Location = new System.Drawing.Point(469, 473);
			this.btnSaveAll.Name = "btnSaveAll";
			this.btnSaveAll.Size = new System.Drawing.Size(103, 23);
			this.btnSaveAll.TabIndex = 3;
			this.btnSaveAll.Text = "Save all Accounts";
			this.btnSaveAll.UseVisualStyleBackColor = true;
			this.btnSaveAll.Click += new System.EventHandler(this.btnSaveAll_Click);
			// 
			// btnStop
			// 
			this.btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnStop.Location = new System.Drawing.Point(1, 500);
			this.btnStop.Name = "btnStop";
			this.btnStop.Size = new System.Drawing.Size(91, 23);
			this.btnStop.TabIndex = 4;
			this.btnStop.Text = "Stop";
			this.btnStop.UseVisualStyleBackColor = true;
			this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
			// 
			// btnStart
			// 
			this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
			| System.Windows.Forms.AnchorStyles.Right)));
			this.btnStart.Location = new System.Drawing.Point(98, 500);
			this.btnStart.Name = "btnStart";
			this.btnStart.Size = new System.Drawing.Size(368, 23);
			this.btnStart.TabIndex = 5;
			this.btnStart.Text = "Start";
			this.btnStart.UseVisualStyleBackColor = true;
			this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
			// 
			// btnStartAll
			// 
			this.btnStartAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnStartAll.Location = new System.Drawing.Point(469, 500);
			this.btnStartAll.Name = "btnStartAll";
			this.btnStartAll.Size = new System.Drawing.Size(103, 23);
			this.btnStartAll.TabIndex = 6;
			this.btnStartAll.Text = "Start All";
			this.btnStartAll.UseVisualStyleBackColor = true;
			this.btnStartAll.Click += new System.EventHandler(this.btnStartAll_Click);
			// 
			// AccountOverview
			// 
			this.Controls.Add(this.btnStartAll);
			this.Controls.Add(this.btnStart);
			this.Controls.Add(this.btnStop);
			this.Controls.Add(this.btnSaveAll);
			this.Controls.Add(this.btnCreateAccount);
			this.Controls.Add(this.btnLoadAccounts);
			this.Controls.Add(this.dgvAccountList);
			this.Name = "AccountOverview";
			this.Size = new System.Drawing.Size(575, 529);
			((System.ComponentModel.ISupportInitialize)(this.dgvAccountList)).EndInit();
			this.ResumeLayout(false);

		}

		#region EventsHandling
		private void btnLoadAccounts_Click(object sender, EventArgs e) {
			LoadAllAccountsFromXML();
		}

		private void btnCreateAccount_Click(object sender, EventArgs e) {
			NewAccount frm = new NewAccount();
			DialogResult result = frm.ShowDialog();

			if (result == DialogResult.OK) {
				AccountSettings s = frm.Setting;
				Settings.Add(s);
				dgvAccountList.Rows.Add(s.Username, s.Server, "gestopt");
			}
		}

		private void btnSaveAll_Click(object sender, EventArgs e) {
			SaveSettings(Settings);
			MessageBox.Show("Einstellungen wurden gespeichert");
		}

		private void dgvAccountList_CellContentClick(object sender, DataGridViewCellEventArgs e) {
			if (dgvAccountList.SelectedRows.Count > 0) {
				EditSettings frm = new EditSettings(Settings.Single(x => x.Username == dgvAccountList.SelectedRows[0].Cells[0].Value && x.Server == dgvAccountList.SelectedRows[0].Cells[1].Value));
				DialogResult result = frm.ShowDialog();

				if (result == DialogResult.OK) {
					Refresh();
				}
			}
		}

		private void btnStop_Click(object sender, EventArgs e) {
			if (dgvAccountList.SelectedRows.Count > 0) {
				AccountSettings settings = Settings.Single(x => x.Username == dgvAccountList.SelectedRows[0].Cells[0].Value && x.Server == dgvAccountList.SelectedRows[0].Cells[1].Value);
				if (StopBot != null) {
					StopBot(this, new EventSelltingsArgs(new List<AccountSettings>() { settings }));
					//todo rows status update
				}
			}
		}

		private void btnStart_Click(object sender, EventArgs e) {
			if (dgvAccountList.SelectedRows.Count > 0) {
				AccountSettings settings = Settings.Single(x => x.Username == dgvAccountList.SelectedRows[0].Cells[0].Value && x.Server == dgvAccountList.SelectedRows[0].Cells[1].Value);
				if (StartBot != null) {
					StartBot(this, new EventSelltingsArgs(new List<AccountSettings>() { settings }));
					//todo rows status update
				}
			}
		}

		private void btnStartAll_Click(object sender, EventArgs e) {
			if (dgvAccountList.Rows.Count > 0) {
				if (StartAllBots != null) {
					StartAllBots(this, new EventSelltingsArgs(Settings));
					//todo rows status update
				}
			}
		}
		#endregion

		#region Public Methoden
		public void LoadAllAccountsFromXML() {
			dgvAccountList.Rows.Clear();
			List<AccountSettings> settings = AccountSettings();
			Settings = settings;
			foreach (AccountSettings setting in settings) {
				dgvAccountList.Rows.Add(setting.Username, setting.Server, "gestopt");
			}
		}

		public void Refresh() {
			dgvAccountList.Rows.Clear();
			foreach (AccountSettings setting in Settings) {
				dgvAccountList.Rows.Add(setting.Username, setting.Server, "gestopt");
			}
		}
		#endregion

		#region Private Methoden
		private List<AccountSettings> AccountSettings() {
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

		private void SaveSettings(List<AccountSettings> accounts) {
			TextWriter writer = new StreamWriter("acc.sav");

			XmlSerializer xml = new XmlSerializer(accounts.GetType());
			xml.Serialize(writer, accounts);

			writer.Close();
		}
		#endregion

		public AccountOverview() {
			InitializeComponent();
		}

		private void dgvAccountList_SelectionChanged(object sender, EventArgs e) {
			if (dgvAccountList.SelectedRows.Count > 0) {
				AccountSettings settings = Settings.Single(x => x.Username == dgvAccountList.SelectedRows[0].Cells[0].Value && x.Server == dgvAccountList.SelectedRows[0].Cells[1].Value);
				if (SelectedAccountChanged != null) {
					SelectedAccountChanged(this, new EventSelltingsArgs(new List<AccountSettings>() { settings }));
				}
			}
		}

	}

	public class EventSelltingsArgs : EventArgs {
		public List<AccountSettings> Settings;

		public EventSelltingsArgs(List<AccountSettings> s) {
			Settings = new List<AccountSettings>();
			if (s != null) {
				Settings = s;
			}
		}
	}
}
