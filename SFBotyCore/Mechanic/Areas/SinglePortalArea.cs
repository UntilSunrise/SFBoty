using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFBotyCore.Mechanic;
using SFBotyCore.Mechanic.Areas;
using SFBotyCore.Mechanic.Account;
using System.Net;
using System.Threading;
using System.Collections.ObjectModel;
using SFBotyCore.Constants;

namespace SFBotyCore.Mechanic.Areas {

	public class SinglePortalArea : BaseArea {

		public override event EventHandler<MessageEventsArgs> MessageOutput;

		public override void RaiseMessageEvent(string s) {
			if (MessageOutput != null) {
				MessageOutput(this, new MessageEventsArgs(s));
			}
		}

		public override void Initialize(Account.Account account, WebClient refClient) {
			base.Initialize(account, refClient);
		}

		public override void PerformArea() {
			base.PerformArea();

			if (Account.Level < 99 || !Account.SinglePortalCanBeVisit) {
				return;
			}

			if (!Account.QuestIsStarted && !Account.TownWatchIsStarted || Account.MirrorIsCompleted) {
				ThreadSleep(Account.Settings.minShortTime, Account.Settings.maxShortTime);
				RaiseMessageEvent("Betrete private Portalübersicht");
				string s = SendRequest(ActionTypes.JoinDungeon);
				string[] answerRequest = s.Split('/');

				int beforeFightLifePercent = Int32.Parse(answerRequest[ResponseTypes.SinglePortalLifePercent]) / 65536;

				s = SendRequest(ActionTypes.DoSinglePortalFight);
				ThreadSleep(Account.Settings.minShortTime, Account.Settings.maxShortTime);
				s = SendRequest(ActionTypes.JoinDungeon);
				answerRequest = s.Split('/');

				int afterFightLifePercent = Int32.Parse(answerRequest[ResponseTypes.SinglePortalLifePercent]) / 65536;

				RaiseMessageEvent(String.Format("Privates Portalmonster hat {0}% Leben verloren.", beforeFightLifePercent - afterFightLifePercent));

				CharScreenArea.UpdateAccountStats(s, Account);

			}
		}
	}
}
