using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFBoty.Mechanic.Account;
using System.Net;
using System.Threading;
using Assert;

namespace SFBoty.Mechanic.Areas {
	public class ToiletArea : BaseArea {

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

				//Prüfung, ob das WC zur Verfügung steht und Speicherung für diese Ausführungszeit
				if (s.Substring(0, 4).Contains(ActionTypes.ResponseToiletLocked)) {
					RaiseMessageEvent("WC steht nicht zur Verfügung!");
					Account.ToiletIsAvailable = false;
				} else {
					Account.ToiletIsAvailable = true;


					// Wert 0 = 0/1 Wurde WC benutzt
					// Wert 1 WC-Level
					// Wert 2 WC-Punkte
					// Wert 3 WC-Punkte für das nächste Level
					answerToilet = answerToilet[answerToilet.Length - 1].Split(';');

					if (answerToilet[0] == "1") {
						RaiseMessageEvent("WC wurde heute schon benutzt!");
						Account.ToiletAlreadyUsedToday = true;
						return;
					} // else do nothing

					//Gucke, ob das WC schon voll ist und drücke die Spülung
					if (answerToilet[2] == answerToilet[3]) {
						RaiseMessageEvent("WC ist voll, Spülung wird gedrückt.");
						s = SendRequest(ActionTypes.FlushToilet);

						answerToilet = s.Split('/');
						answerToilet = answerToilet[answerToilet.Length - 1].Split(';');

						Account.CurrentToiletLevel = Convert.ToInt32(answerToilet[1]);
						Account.CurrentToiletPoints = Convert.ToInt32(answerToilet[2]);
						Account.ToiletPointsForNewLevel = Convert.ToInt32(answerToilet[3]);
						RaiseMessageEvent("Spülung gedrückt, Aurastufe: " + Account.CurrentToiletLevel);
					} // else do nothing

					//TODO: Item in Toilette werfen

					// Inventar Platz 1: Goldwert s[178]
					// Inventar Platz 2: Goldwert s[190]
					// Inventar Platz 3: Goldwert s[202]
					// Inventar Platz 4: Goldwert s[214]
					// Inventar Platz 5: Goldwert s[226]
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
