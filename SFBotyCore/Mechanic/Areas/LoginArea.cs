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


		public LoginArea()
			: base() {

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

				UpdateLoginData(s, Account);
			}
		}

		public static void UpdateLoginData(string s, Account.Account acc) {
			acc.Settings.SessionID = s.Split('/')[ResponseTypes.SessionID].Split(';')[2];
			acc.Silver = Convert.ToInt32(s.Split('/')[ResponseTypes.Silver]);
			acc.Mushroom = Convert.ToInt32(s.Split('/')[ResponseTypes.Mushrooms]);
			acc.Level = Convert.ToInt32(s.Split('/')[ResponseTypes.Level]);
			acc.Rang = Convert.ToInt32(s.Split('/')[ResponseTypes.Rang]);
			acc.Honor = Convert.ToInt32(s.Split('/')[ResponseTypes.Honor]);
			acc.DungeonEndTime = s.Split('/')[ResponseTypes.NextFreeDungeonTimestamp].MillisecondsToDateTime();
			acc.ArenaEndTime = s.Split('/')[ResponseTypes.NextFreeDuellTimestamp].MillisecondsToDateTime();
			acc.MirrorIsCompleted = s.Split('/').HasMirror();
			DateTime actionDate = s.Split('/')[ResponseTypes.ActionDateTimestamp].MillisecondsToDateTime();
			string actionStatus = s.Split('/')[ResponseTypes.ActionStatus];
			if (DateTime.Now < actionDate) {
				if (actionStatus == ActionStatusTypes.TownWatchTaken) {
					acc.TownWatchEndTime = actionDate;
					acc.TownWatchIsStarted = true;
				} else {
					acc.QuestEndTime = actionDate;
					acc.QuestIsStarted = true;
				}
			}

			acc.ALU_Seconds = Convert.ToInt32(s.Split('/')[ResponseTypes.ALU]);
		}

		public override void RaiseMessageEvent(string s) {
			if (MessageOutput != null) {
				MessageOutput(this, new MessageEventsArgs(s));
			}
		}
	}
}
