using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFBotyCore.Mechanic.Account;
using System.Threading;
using System.Net;
using System.IO;
using SFBotyCore.Mechanic.Areas;
using System.Net.Mail;

namespace SFBotyCore.Mechanic {
	public class Bot {

		public Account.Account Account { get; private set; }
		private Thread CurrentThread { get; set; }
		private WebClient Client { get; set; }
		private Random random;

		private List<IMenuArea> Menus;

		#region Events
		public event EventHandler<MessageEventsArgs> MessageOutput;
		public event EventHandler<MessageEventsArgs> ExtendedLog;
		public event EventHandler<MessageEventsArgs> Error;
		#endregion

		public Bot(Account.Account account) {
			this.Account = account;
			this.CurrentThread = new Thread(new ThreadStart(PerformAction));
			
			this.Client = new WebClient();
			Client.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:26.0) Gecko/20100101 Firefox/26.0");
			Client.Headers.Add(HttpRequestHeader.AcceptLanguage, "de-DE,de;q=0.8,en-US;q=0.6,en;q=0.4");
			Client.Headers.Add(HttpRequestHeader.AcceptCharset, "ISO-8859-1,utf-8;q=0.7,*;q=0.3");

			Menus = new List<IMenuArea>();
			random = new Random(System.Environment.TickCount);
		}

		void Log_ExtendedLog(object sender, MessageEventsArgs e) {
			if (ExtendedLog != null) {
				ExtendedLog(this, e);
			}
		}

		void Event_MessageOutput(object sender, MessageEventsArgs e) {
			if (MessageOutput != null) {
				MessageOutput(this, e);
			}
		}

		public void AddMenu(IMenuArea menu) {
			Menus.Add(menu);
			menu.Initialize(Account, Client);
			menu.MessageOutput += new EventHandler<MessageEventsArgs>(Event_MessageOutput);
			menu.ExtendedLog += new EventHandler<MessageEventsArgs>(Log_ExtendedLog);
		}

		public void Run() {
			CurrentThread.Start();
		}

		public void Stop() {
			CurrentThread.Abort();
		}

		#region Thread
		/// <summary>
		/// Ausführung des Bots über den eigenen Thread
		/// </summary>
		private void PerformAction() {
			bool running = true;
			try {
				while (running) {
					Menus.ForEach(x => x.PerformArea());

					//at the end oh an Threadloop sleep for 1 Secound
					Thread.Sleep(1000);
					if ((DateTime.Now - Account.LastAction).TotalHours > 12d) {
						if (Error != null) {
							Error(this, new MessageEventsArgs("Bot steht still und arbeitet nicht mehr. Programmlogikfehler"));
							running = false;
						}
					}
				}
			} catch (ThreadAbortException) {
				//nothing to do
				//http://msdn.microsoft.com/de-de/library/5b50fdsz%28v=vs.110%29.aspx
			} catch (Exception ex) {
				if (Account.Settings.SendErrorMail) {
					SendErrorMail(ex.ToString());
				}

				if (MessageOutput != null) {
					MessageOutput(this, new MessageEventsArgs("Ein Fehler ist aufgetretten"));
				}

				if (Error != null) {
					Error(this, new MessageEventsArgs(ex.ToString()));
				}
			}
		}

		private void SendErrorMail(string body) {
			CryptManager.Init(Account.Settings);
			string from = Account.Settings.MailFrom;
			string to = Account.Settings.MailTo;
			int port = Account.Settings.MailPort;
			string smtpAddress = Account.Settings.MailSmtp;
			string userName = Account.Settings.MailUserNamer;
			string passwort = CryptManager.Decrypt(Account.Settings.MailCryptPasswort);

			MailMessage message = new MailMessage();
			message.To.Add(to);
			message.Subject = String.Concat("Error on SFBoty on ", Account.Settings.Server, " with Player ", Account.Settings.Username);
			message.From = new MailAddress(from);
			message.Body = body;

			SmtpClient smtp = new SmtpClient(smtpAddress, port);
			smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
			smtp.EnableSsl = true;
			smtp.Credentials = new NetworkCredential(userName, passwort);
			smtp.Timeout = 30000;

			try {
				smtp.Send(message);
			} catch (Exception ex) {
				if (MessageOutput != null) {
					MessageOutput(this, new MessageEventsArgs("Mail konnte nicht gesendet werden."));
				}
				
				if (Error != null) {
					Error(this, new MessageEventsArgs("Mail konnte nicht gesendet werden." + Environment.NewLine + ex.ToString()));
				}
			}

			message.Dispose();
			smtp.Dispose();
		}

		#endregion

		public void Dispose() {
			this.CurrentThread.Abort();
			Client.Dispose();
			Menus.ForEach(x => x.Dispose());
		}
	}
}
