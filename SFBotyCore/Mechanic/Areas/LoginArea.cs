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
			if (!base.Account.Settings.HasLogin && !Account.QuestIsStarted && DateTime.Now > Account.TownWatchEndTime) {

				Account.Logout();
				base.RecreateClient();

				string s = SendRequest(ActionTypes.LoginToSF);
				RaiseMessageEvent("Login");

				UpdateLoginData(s, Account);
			}

			base.PerformArea();
		}

		public static void UpdateLoginData(string s, Account.Account acc) {
			string[] answer = s.Split('/');

			acc.Settings.SessionID = answer[ResponseTypes.SessionID].Split(';')[2];
			acc.Silver = Convert.ToInt64(answer[ResponseTypes.Silver]);
			acc.Mushroom = Convert.ToInt32(answer[ResponseTypes.Mushrooms]);
			acc.Level = Convert.ToInt32(answer[ResponseTypes.Level]);
			acc.Rang = Convert.ToInt32(answer[ResponseTypes.Rang]);
			acc.Honor = Convert.ToInt32(answer[ResponseTypes.Honor]);
			acc.DungeonEndTime = answer[ResponseTypes.NextFreeDungeonTimestamp].MillisecondsToDateTime();
			acc.ArenaEndTime = answer[ResponseTypes.NextFreeDuellTimestamp].MillisecondsToDateTime();
			acc.MirrorIsCompleted = answer.HasMirror();
			DateTime actionDate = answer[ResponseTypes.ActionDateTimestamp].MillisecondsToDateTime();
			string actionStatus = answer[ResponseTypes.ActionStatus];
			if (DateTime.Now < actionDate) {
				if (actionStatus == ActionStatusTypes.TownWatchTaken) {
					acc.TownWatchEndTime = actionDate;
					acc.TownWatchIsStarted = true;
				} else {
					acc.QuestEndTime = actionDate;
					acc.QuestIsStarted = true;
				}
			}

			acc.ALU_Seconds = Convert.ToInt32(answer[ResponseTypes.ALU]);

			GuildAttackDefenceTypes type = answer[ResponseTypes.GuildAttackDefenceEnum].ToEnum<GuildAttackDefenceTypes>();
			switch (type) {
				case GuildAttackDefenceTypes.NoAction:
					acc.HasJoinAttack = false;
					acc.HasJoinDefence = false;
					break;
				case GuildAttackDefenceTypes.JoinAttack:
					acc.HasJoinAttack = true;
					acc.HasJoinDefence = false;
					break;
				case GuildAttackDefenceTypes.JoinDefence:
					acc.HasJoinAttack = false;
					acc.HasJoinDefence = true;
					break;
				case GuildAttackDefenceTypes.JoinBoth:
					acc.HasJoinAttack = true;
					acc.HasJoinDefence = true;
					break;
			}
		}

		public override void RaiseMessageEvent(string s) {
			if (MessageOutput != null) {
				MessageOutput(this, new MessageEventsArgs(s));
			}
		}
	}
}
