using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFBotyCore.Mechanic.Account;
using System.Net;
using System.Threading;
using SFBotyCore.Constants;

namespace SFBotyCore.Mechanic.Areas {
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
			if ((Account.ALU_Seconds == 0 || !Account.Settings.PerformQuesten) && !Account.QuestIsStarted && !Account.TownWatchIsStarted) {
				ThreadSleep(Account.Settings.minTimeToJoinStadtwache, Account.Settings.maxTimeToJoinStadtwache);
				RaiseMessageEvent("Stadtwache betreten");
				s = SendRequest(ActionTypes.JoinTownWatch);
					
				ThreadSleep(Account.Settings.minTimeToDoStadtwache, Account.Settings.maxTimeToDoStadtwache);
				s = SendRequest(ActionTypes.DoTownWatch10Hour);
				Account.TownWatchIsStarted = true;
				Account.TownWatchEndTime = DateTime.Now.AddHours(10);
				RaiseMessageEvent("10h Stadtwache ausführen. Stadtwache ende: " + Account.TownWatchEndTime.ToString());
				
				ThreadSleep(Account.Settings.minTimeToLogOut, Account.Settings.maxTimeToLogOut);
				s = SendRequest(ActionTypes.LogOut);
				Account.Logout();
				Thread.Sleep(1000 * 60 * 60 * 10);
			} else {
				if (DateTime.Now > Account.TownWatchEndTime && Account.TownWatchIsStarted) {
					ThreadSleep(Account.Settings.minTimeToJoinStadtwache, Account.Settings.maxTimeToJoinStadtwache);
					RaiseMessageEvent("Stadtwache betreten");

					s = SendRequest(ActionTypes.JoinTownWatch);
					RaiseMessageEvent("Stadtwache beendet");
					ThreadSleep(Account.Settings.minTimeToJoinChar, Account.Settings.maxTimeToJoinChar);
					s = SendRequest(ActionTypes.JoinCharacter);
					Account.TownWatchIsStarted = false;
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
