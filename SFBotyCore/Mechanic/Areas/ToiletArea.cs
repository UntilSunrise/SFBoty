using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFBotyCore.Mechanic.Account;
using System.Net;
using System.Threading;
using Assert;
using SFBotyCore.Mechanic;
using SFBotyCore.Constants;

namespace SFBotyCore.Mechanic.Areas {
	public class ToiletArea : BaseArea {

		private enum ToiletAnswer {
			Status = 1,
			Level = 2,
			Exp = 3,
			ExpToNextLevel = 4
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
			if (!Account.Settings.PerformToilet || Account.Level < 100 || Account.BackpackIsFull || !Account.BackpackHasToiletItem) {
				return;
			}
			if ((Account.QuestIsStarted || Account.TownWatchIsStarted) && !Account.MirrorIsCompleted || DateTime.Now < Account.ToiletEndTime) {
				return;
			}

			string s;
			if ((Account.Level >= 100 && Account.ToiletIsAvailable)) {
				ThreadSleep(Account.Settings.minShortTime, Account.Settings.maxShortTime);
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
						Account.ToiletEndTime = (DateTime.Now - DateTime.Now.TimeOfDay).AddDays(1);
						return;
					}

					s = CheckAndFlushToilette(s);

					CharScreenArea.UpdateAccountStats(s, Account);

					//Rucksackslotnummer mit dem niedrigsten Gold Wert
					int backpackslotWithLowestItemValue = Account.BackpackItems.Where(
																						b =>
																							b.SilverValue != 0
																							&& b.Typ != ItemTypes.Buff
																							&& b.Typ != ItemTypes.Leer
																							&& b.Typ != ItemTypes.SpiegelOderSchlüssel
																							&& b.Typ != ItemTypes.KeineAhnung2
																							&& b.IsEpic == false
																						).OrderBy(b => b.SilverValue).First().InventoryID;
					if (backpackslotWithLowestItemValue == 0) {
						return;
					}
					ThreadSleep(Account.Settings.minShortTime, Account.Settings.maxShortTime);
					RaiseMessageEvent(string.Format("Item im Slot {0}, wird in die Toilette geschmissen.", backpackslotWithLowestItemValue));
					s = SendRequest(ActionTypes.ItemAction + backpackslotWithLowestItemValue + "%3B10%3B0");
					answerToilet = s.Split('/');
					Account.ToiletEndTime = (DateTime.Now - DateTime.Now.TimeOfDay).AddDays(1);

					if (Account.Settings.SellToiletItemIfNotEpic && !answerToilet[0].Contains("E")) {
						ThreadSleep(Account.Settings.minShortTime, Account.Settings.maxShortTime);
						RaiseMessageEvent(string.Format("Item im Slot {0}, wird verkauft. Kein Epic.", backpackslotWithLowestItemValue));
						s = SendRequest(ActionTypes.ItemAction + backpackslotWithLowestItemValue + "%3B0%3B0");
					}
					CharScreenArea.UpdateAccountStats(s, Account);
				}

			} else {
				if (Account.ToiletEndTime.IsOtherDay(DateTime.Now) && !Account.ToiletIsAvailable && Account.Level >= 100) {
					Account.ToiletIsAvailable = true;
				}
			}
		}

		private string CheckAndFlushToilette(string s) {
			//Gucke, ob das WC schon voll ist und drücke die Spülung
			string[] answerToilet = s.Split('/');
			answerToilet = answerToilet[answerToilet.Length - 1].Split(';');

			if (answerToilet[(int)ToiletAnswer.Exp] == answerToilet[(int)ToiletAnswer.ExpToNextLevel]) {
				RaiseMessageEvent("WC ist voll, Spülung wird gedrückt.");
				ThreadSleep(Account.Settings.minShortTime, Account.Settings.maxShortTime);
				s = SendRequest(ActionTypes.FlushToilet);

				answerToilet = s.Split('/');
				answerToilet = answerToilet[answerToilet.Length - 1].Split(';');

				Account.CurrentToiletLevel = Convert.ToInt32(answerToilet[(int)ToiletAnswer.Level]);
				Account.CurrentToiletPoints = Convert.ToInt32(answerToilet[(int)ToiletAnswer.Exp]);
				Account.ToiletPointsForNewLevel = Convert.ToInt32(answerToilet[(int)ToiletAnswer.ExpToNextLevel]);
				RaiseMessageEvent("Spülung gedrückt, Aurastufe: " + Account.CurrentToiletLevel);
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
