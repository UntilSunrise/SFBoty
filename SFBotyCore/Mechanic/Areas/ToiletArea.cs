using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFBoty.Mechanic.Account;
using System.Net;
using System.Threading;
using Assert;
using SFBotyCore.Mechanic;

namespace SFBoty.Mechanic.Areas {
	public class ToiletArea : BaseArea {

		private enum ToiletAnswer { 
			Status = 0,
			Level = 1,
			Exp = 2,
			ExpToNextLevel = 3
		};

		#region Events
		public override event EventHandler<MessageEventsArgs> MessageOutput;
		#endregion

		public ToiletArea()
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

			//Wenn das WC nicht genutzt werden soll, tue nichts.
			if (!Account.Settings.PerformToilet) {
				return;
			}

			string s;
			if ((Account.Level >= 100 || Account.ToiletIsAvailable) && !Account.ToiletAlreadyUsedToday) {
				ThreadSleep(Account.Settings.minTimeToJoinToilet, Account.Settings.maxTimeToJoinToilet);
				RaiseMessageEvent("WC betreten");
				s = SendRequest(ActionTypes.JoinToilet);
				string[] answerToilet = s.Split('/');
				answerToilet = answerToilet[answerToilet.Length - 1].Split(';');

				//Prüfung, ob das WC zur Verfügung steht und Speicherung für diese Ausführungszeit
				if (s.Substring(0, 4).Contains(ActionTypes.ResponseToiletLocked)) {
					RaiseMessageEvent("WC steht nicht zur Verfügung!");
					Account.ToiletIsAvailable = false;
				} else {
					Account.ToiletIsAvailable = true;					

					if (answerToilet[(int)ToiletAnswer.Status] == "1") {
						RaiseMessageEvent("WC wurde heute schon benutzt!");
						Account.ToiletAlreadyUsedToday = true;
						return;
					} // else do nothing

					//Gucke, ob das WC schon voll ist und drücke die Spülung
					if (answerToilet[(int)ToiletAnswer.Exp] == answerToilet[(int)ToiletAnswer.ExpToNextLevel]) {
						RaiseMessageEvent("WC ist voll, Spülung wird gedrückt.");
						s = SendRequest(ActionTypes.FlushToilet);

						answerToilet = s.Split('/');
						answerToilet = answerToilet[answerToilet.Length - 1].Split(';');

						Account.CurrentToiletLevel = Convert.ToInt32(answerToilet[(int)ToiletAnswer.Level]);
						Account.CurrentToiletPoints = Convert.ToInt32(answerToilet[(int)ToiletAnswer.Exp]);
						Account.ToiletPointsForNewLevel = Convert.ToInt32(answerToilet[(int)ToiletAnswer.ExpToNextLevel]);
						RaiseMessageEvent("Spülung gedrückt, Aurastufe: " + Account.CurrentToiletLevel);
					} // else do nothing
					
					int i = 0;
					Dictionary<int,Item> BackpackItems = new Dictionary<int,Item>();
					while (i < ResponseStringPositions.BackpackSize) {
						BackpackItems.Add(i, new Item(answerToilet, ResponseStringPositions.BackpackFirstItemPosition + (i * ResponseStringPositions.ItemSize)));
						i++;
					}

					//TODO: ?günstiges? Item heraussuchen und ins Klo werfen.
				}

			} // else do nothing
		}

		public override void RaiseMessageEvent(string s) {
			if (MessageOutput != null) {
				MessageOutput(this, new MessageEventsArgs(s));
			}
		}

	}
}
