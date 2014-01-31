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
			if (!base.Account.Settings.HasLogin && !Account.QuestIsStarted && DateTime.Now > Account.TownWatchEndTime) {

				Account.Logout();
				base.RecreateClient();
				
				string s = SendRequest(ActionTypes.LoginToSF);
				RaiseMessageEvent("Login");

				Account.Settings.SessionID = s.Split('/')[ResponseTypes.SessionID].Split(';')[2];
				Account.Silver = Convert.ToInt32(s.Split('/')[ResponseTypes.Silver]);
				Account.Mushroom = Convert.ToInt32(s.Split('/')[ResponseTypes.Mushrooms]);
				Account.Level = Convert.ToInt32(s.Split('/')[ResponseTypes.Level]);
				Account.Rang = Convert.ToInt32(s.Split('/')[ResponseTypes.Rang]);
				Account.Honor = Convert.ToInt32(s.Split('/')[ResponseTypes.Honor]);
				Account.DungeonEndTime = s.Split('/')[ResponseTypes.NextFreeDungeonTimestamp].MillisecondsToDateTime();
				Account.ArenaEndTime = s.Split('/')[ResponseTypes.NextFreeDuellTimestamp].MillisecondsToDateTime();
				DateTime actionDate = s.Split('/')[ResponseTypes.ActionDateTimestamp].MillisecondsToDateTime();
				string actionStatus = s.Split('/')[ResponseTypes.ActionStatus];
				if (DateTime.Now < actionDate) {
					if (actionStatus == ActionStatusTypes.TownWatchTaken) {
						Account.TownWatchEndTime = actionDate;
						Account.TownWatchIsStarted = true;
					} else {
						Account.QuestEndTime = actionDate;
						Account.QuestIsStarted = true;
					}
				}

				Account.ALU_Seconds = Convert.ToInt32(s.Split('/')[ResponseTypes.ALU]);
			}
		}

		public override void RaiseMessageEvent(string s) {
			if (MessageOutput != null) {
				MessageOutput(this, new MessageEventsArgs(s));
			}
		}
	}
}
