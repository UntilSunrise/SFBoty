using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFBoty.Mechanic.Account;
using System.Net;
using System.Threading;

namespace SFBoty.Mechanic.Areas {
	public class StadtwacheArea : BaseArea {

		#region Events
		public override event EventHandler<MessageEventsArgs> MessageOutput;
		#endregion

		public StadtwacheArea() : base() { 
		
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
			if (Account.ALU_Seconds == 0 && !Account.QuestIsStarted && !Account.StadtwacheWurdeGestatet) {
				Thread.Sleep(random.Next((int)(Account.Settings.minTimeToJoinStadtwache * 1000), (int)(Account.Settings.maxTimeToJoinStadtwache * 1000)));
				RaiseMessageEvent("Stadtwache betretten");
				s = SendRequest(ActionTypes.JoinStadtwache);
				RaiseMessageEvent("10h Stadtwache ausführen");
				Thread.Sleep(random.Next((int)(Account.Settings.minTimeToDoStadtwache * 1000), (int)(Account.Settings.maxTimeToDoStadtwache * 1000)));
				s = SendRequest(ActionTypes.DoStadtwache10Hour);
				Account.StadtwacheWurdeGestatet = true;
				Account.StadtwacheEndTime = DateTime.Now.AddHours(10);
				RaiseMessageEvent("Stadtwache ende: " + Account.StadtwacheEndTime.ToString());
				Thread.Sleep(random.Next((int)(Account.Settings.minTimeToLogOut * 1000), (int)(Account.Settings.maxTimeToLogOut * 1000)));
				RaiseMessageEvent("Logout");
				RaiseMessageEvent("SessionID: " + Account.Settings.SessionID);
				s = SendRequest(ActionTypes.LogOut);
				Account.Logout();
				RaiseMessageEvent("SessionID: " + Account.Settings.SessionID);
				Thread.Sleep(1000 * 60 * 60 * 10);
			} else {
				if (DateTime.Now > Account.StadtwacheEndTime && Account.StadtwacheWurdeGestatet) {
					RaiseMessageEvent("Stadtwache beendet");
					Thread.Sleep(random.Next((int)(Account.Settings.minTimeToJoinChar * 1000), (int)(Account.Settings.maxTimeToLogOut * 1000)));
					s = SendRequest(ActionTypes.JoinCharacter);
					Account.StadtwacheWurdeGestatet = false;
					CharScreenArea.UpdateAccountStats(s, Account);
					
					//Thread.Sleep(random.Next((int)(Account.Settings.minTimeToJoinTarvern * 1000), (int)(Account.Settings.maxTimeToJoinTarvern * 1000)));
					//s = SendRequest(ActionTypes.JoinTarvern);
					//int alu = Convert.ToInt32(s.Split('/')[456]);
					//RaiseMessageEvent("Alu after 10h stadtwache: " + alu.ToString() + " S-StringAlu: " + s.Split('/')[456]);
					//RaiseMessageEvent("RequestString after 10h stadtwache: " + s);
					//Account.ALU_Seconds = alu;
				}
			}
				
		}

		public override void RaiseMessageEvent(string s) {
			if (MessageOutput != null) {
				MessageOutput(this, new MessageEventsArgs(s));
			}
		}

		private bool GreaterThen(int source, params int[] targets) {
			bool returnValue = true;

			foreach (int a in targets) {
				if (source < a) {
					returnValue = false;
					break;
				}
			}

			return returnValue;
		}
	}
}
