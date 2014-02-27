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

				s = DoWork(s);
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

		private string DoWork(string s) {
			ThreadSleep(Account.Settings.minTimeToDoStadtwache, Account.Settings.maxTimeToDoStadtwache);

			int currentHour = DateTime.Now.Hour;

			if (currentHour.IsBetween(Account.Settings.TownWatchMinHourForShortWork, Account.Settings.TownWatchMaxHourForShortWork)) {
				s = SendRequest(ActionTypes.DoTownWatch1Hour);
				Account.TownWatchIsStarted = true;
				Account.TownWatchEndTime = DateTime.Now.AddHours(1);
				RaiseMessageEvent("1h Stadtwache ausführen. Stadtwache ende: " + Account.TownWatchEndTime.ToString());
			} else {
				DateTime targetDate = DateTime.Now;
				while (!targetDate.Hour.IsBetween(Account.Settings.TownWatchMinHourForShortWork, Account.Settings.TownWatchMaxHourForShortWork)) {
					targetDate = targetDate.AddHours(1);
				}

				int hourToWork = Math.Min(Convert.ToInt32((targetDate - DateTime.Now).TotalHours), 10);
				if (hourToWork == 0) {
					hourToWork = 1;
					SendRequest("!!!Fehler in der Stadtwache!!!");
				}

				s = SendRequest(String.Concat(ActionTypes.DoTownWatchHour, hourToWork));
				Account.TownWatchIsStarted = true;
				Account.TownWatchEndTime = DateTime.Now.AddHours(hourToWork);
				RaiseMessageEvent(String.Concat(hourToWork, "h Stadtwache ausführen. Stadtwache ende: ", Account.TownWatchEndTime.ToString()));

				ThreadSleep(Account.Settings.minTimeToLogOut, Account.Settings.maxTimeToLogOut);
				s = SendRequest(ActionTypes.LogOut);
				Account.Logout();
				Thread.Sleep(1000 * 60 * 60 * hourToWork);
			}

			return s;
		}

		public override void RaiseMessageEvent(string s) {
			if (MessageOutput != null) {
				MessageOutput(this, new MessageEventsArgs(s));
			}
		}
	}
}
