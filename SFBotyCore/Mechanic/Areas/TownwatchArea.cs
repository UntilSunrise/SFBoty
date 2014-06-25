using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFBotyCore.Mechanic.Account;
using System.Net;
using System.Threading;
using SFBotyCore.Constants;

namespace SFBotyCore.Mechanic.Areas {
	public class TownwatchArea : BaseArea {

		#region Events
		public override event EventHandler<MessageEventsArgs> MessageOutput;
		#endregion

		public TownwatchArea()
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

			//wenn Townwatch läuft tue nichts

			if (!Account.Settings.PerformTownwatch) {
				return;
			}

			string s;
			if ((Account.ALU_Seconds == 0 || !Account.Settings.PerformQuesten) && !Account.QuestIsStarted && !Account.TownWatchIsStarted) {
				ThreadSleep(Account.Settings.minShortTime, Account.Settings.maxShortTime);
				RaiseMessageEvent("Townwatch betreten");
				s = SendRequest(ActionTypes.JoinTownWatch);

				s = DoWork(s);
			} else {
				if (DateTime.Now > Account.TownWatchEndTime && Account.TownWatchIsStarted) {
					ThreadSleep(Account.Settings.minShortTime, Account.Settings.maxShortTime);
					RaiseMessageEvent("Townwatch betreten");

					s = SendRequest(ActionTypes.JoinTownWatch);
					RaiseMessageEvent("Townwatch beendet");
					ThreadSleep(Account.Settings.minShortTime, Account.Settings.maxShortTime);
					s = SendRequest(ActionTypes.JoinCharacter);
					Account.TownWatchIsStarted = false;
					CharScreenArea.UpdateAccountStats(s, Account);
				}
			}

		}

		private string DoWork(string s) {
			ThreadSleep(Account.Settings.minLongTime, Account.Settings.maxLongTime);

			int currentHour = DateTime.Now.Hour;

			if (currentHour.IsBetween(Account.Settings.TownWatchMinHourForShortWork, Account.Settings.TownWatchMaxHourForShortWork)) {
				s = SendRequest(ActionTypes.DoTownWatch1Hour);
				Account.TownWatchIsStarted = true;
				Account.TownWatchEndTime = DateTime.Now.AddHours(1);
				RaiseMessageEvent("1h Townwatch ausführen. Townwatch ende: " + Account.TownWatchEndTime.ToString());
			} else {
				DateTime targetDate = DateTime.Now;
				
				int counter = 0;
				while (!targetDate.Hour.IsBetween(Account.Settings.TownWatchMinHourForShortWork, Account.Settings.TownWatchMaxHourForShortWork)) {
					targetDate = targetDate.AddHours(1);
					counter += 1;

					if (counter >= 24) {
						throw new Exception("Fehler in der Townwatch");
					}
				}

				int hourToWork = Math.Min(Convert.ToInt32((targetDate - DateTime.Now).TotalHours), 10);
				if (hourToWork == 0) {
					hourToWork = 1;
					SendRequest("!!!Fehler in der Townwatch!!!");
				}

				s = SendRequest(String.Concat(ActionTypes.DoTownWatchHour, hourToWork));
				Account.TownWatchIsStarted = true;
				Account.TownWatchEndTime = DateTime.Now.AddHours(hourToWork);
				RaiseMessageEvent(String.Concat(hourToWork, "h Townwatch ausführen. Townwatch ende: ", Account.TownWatchEndTime.ToString()));

				ThreadSleep(Account.Settings.minShortTime, Account.Settings.maxShortTime);
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
