using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFBotyCore.Mechanic.Account;
using System.Threading;
using System.Net;
using SFBotyCore.Constants;
using SFBotyCore;

namespace SFBotyCore.Mechanic.Areas {
	public class LoginArea : BaseArea {

		#region Events
		public override event EventHandler<MessageEventsArgs> MessageOutput;
		#endregion


		public LoginArea() : base() { 
		
		}

		public override void Initialize(Account.Account account, System.Net.WebClient refClient) {
			base.Initialize(account, refClient);
		}

		public override void Dispose() {
			base.Dispose();
		}

		public override void PerformArea() {
			base.PerformArea();
			if (!base.Account.Settings.HasLogin && !Account.QuestIsStarted && DateTime.Now > Account.StadtwacheEndTime) {

				Account.Logout();
				base.RecreateClient();
				
				string s = SendRequest(ActionTypes.LoginToSF);
				RaiseMessageEvent("Login");
				RaiseMessageEvent("Request String: " + s);

				//read SessionID
				RaiseMessageEvent("Old SessionID: " + Account.Settings.SessionID + " new ID: " + s.Split('/')[511].Split(';')[2]);
				Account.Settings.SessionID = s.Split('/')[511].Split(';')[2];
				Account.Silver = Convert.ToInt32(s.Split('/')[13]);
				Account.Pilze = Convert.ToInt32(s.Split('/')[14]);
				Account.DungeonEndTime = s.Split('/')[459].ToSFDateTime();
				DateTime actionDate = s.Split('/')[47].ToSFDateTime();
				if (DateTime.Now < actionDate) {
					if ((actionDate - DateTime.Now).TotalMinutes > 30) {
						Account.StadtwacheEndTime = actionDate;
						Account.StadtwacheWurdeGestatet = true;
					} else {
						Account.QuestEndTime = actionDate;
						Account.QuestIsStarted = true;
					}
					Account.StadtwacheWurdeGestatet = true;
				}

				RaiseMessageEvent("Login ALU: " + s.Split('/')[456]);
			}
		}

		public override void RaiseMessageEvent(string s) {
			if (MessageOutput != null) {
				MessageOutput(this, new MessageEventsArgs(s));
			}
		}
	}
}
