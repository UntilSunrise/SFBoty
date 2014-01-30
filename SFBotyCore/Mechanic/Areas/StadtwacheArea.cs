using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFBoty.Mechanic.Account;
using System.Net;
using System.Threading;
using SFBotyCore.Constants;

namespace SFBoty.Mechanic.Areas {
	public class StadtwacheArea : BaseArea {

		#region Events
		public override event EventHandler<MessageEventsArgs> MessageOutput;
		#endregion

		public StadtwacheArea()
			: base() {

		}

		public override void Initialize(Account.Account account, WebClient refClient) {
			base.Initialize(account, refClient);
		}

		public override void Dispose() {
			base.Dispose();
		}

		public override void PerformArea() {
			base.PerformArea();

			//wenn stadtwache läuft tue nichts

			if (!Account.Settings.PerformStadtwache) {
				return;
			}

			string s;
			if ((Account.ALU_Seconds == 0 || !Account.Settings.PerformQuesten) && !Account.QuestIsStarted && !Account.StadtwacheWurdeGestatet) {
				ThreadSleep(Account.Settings.minTimeToJoinStadtwache, Account.Settings.maxTimeToJoinStadtwache);
				RaiseMessageEvent("Stadtwache betreten");
				s = SendRequest(ActionTypes.JoinStadtwache);
				RaiseMessageEvent("10h Stadtwache ausführen");
				
				ThreadSleep(Account.Settings.minTimeToDoStadtwache, Account.Settings.maxTimeToDoStadtwache);
				s = SendRequest(ActionTypes.DoStadtwache10Hour);
				Account.StadtwacheWurdeGestatet = true;
				Account.StadtwacheEndTime = DateTime.Now.AddHours(10);
				RaiseMessageEvent("Stadtwache ende: " + Account.StadtwacheEndTime.ToString());
				
				ThreadSleep(Account.Settings.minTimeToLogOut, Account.Settings.maxTimeToLogOut);
				RaiseMessageEvent("Logout");
				RaiseMessageEvent("SessionID: " + Account.Settings.SessionID);
				s = SendRequest(ActionTypes.LogOut);
				Account.Logout();
				RaiseMessageEvent("SessionID: " + Account.Settings.SessionID);
				Thread.Sleep(1000 * 60 * 60 * 10);
			} else {
				if (DateTime.Now > Account.StadtwacheEndTime && Account.StadtwacheWurdeGestatet) {
					ThreadSleep(Account.Settings.minTimeToJoinStadtwache, Account.Settings.maxTimeToJoinStadtwache);
					RaiseMessageEvent("Stadtwache betreten");

					s = SendRequest(ActionTypes.JoinStadtwache);
					RaiseMessageEvent("Stadtwache beendet");
					ThreadSleep(Account.Settings.minTimeToJoinChar, Account.Settings.maxTimeToJoinChar);
					s = SendRequest(ActionTypes.JoinCharacter);
					RaiseMessageEvent("Stadtwache S-String: " + s);
					Account.StadtwacheWurdeGestatet = false;
					CharScreenArea.UpdateAccountStats(s, Account);
				}
			}

		}

		public override void RaiseMessageEvent(string s) {
			if (MessageOutput != null) {
				MessageOutput(this, new MessageEventsArgs(s));
			}
		}
	}
}
