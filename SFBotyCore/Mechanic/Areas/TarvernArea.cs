using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFBoty.Mechanic.Account;
using System.Net;
using System.Threading;
using Assert;
using SFBotyCore.Constants;

namespace SFBoty.Mechanic.Areas {
	public class TarvernArea : BaseArea {

		#region Events
		public override event EventHandler<MessageEventsArgs> MessageOutput;
		#endregion

		public TarvernArea()
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

			string s;
			if (!Account.QuestIsStarted && !Account.StadtwacheWurdeGestatet) {
				ThreadSleep(Account.Settings.minTimeToJoinTarvern, Account.Settings.maxTimeToJoinTarvern);
				RaiseMessageEvent("Tarverne betretten");
				s = SendRequest(ActionTypes.JoinTarvern);
				string[] answerTarvern = s.Split('/');

				Asserts.IsFalse(s.Substring(0, 4).Contains("103"), "Stadtwache wurde nicht beendet");
				Asserts.IsFalse(s.Substring(0, 4).Contains("106"), "Quest wurde nicht beendet");

				int alu = Convert.ToInt32(answerTarvern[456]);
				Account.ALU_Seconds = alu;

				if (Account.Settings.BuyBeer) {
					//answerTarvern[457] //usedBeerAmount
					//answerTarvern[108] //länge > 2 dann gibt es max 11 beer
					int usedBeer = Convert.ToInt32(answerTarvern[457]);
					int maxBeer = answerTarvern[108].Length > 2 ? 11 : 10;
					if (usedBeer < maxBeer && usedBeer < Account.Settings.MaxBeerToBuy && Account.ALU_Seconds <= 20 * 60) {
						while (Account.ALU_Seconds + 20 * 60 < 100 * 60 && Account.Pilze > 0) {
							ThreadSleep(Account.Settings.minTimeToBuyBeer, Account.Settings.maxTimeToBuyBeer);
							SendRequest(ActionTypes.BuyBeer);
							Account.ALU_Seconds += 20 * 60;
							usedBeer += 1;
							Account.Pilze -= 1;
							RaiseMessageEvent("Buy Beer " + usedBeer.ToString());
						}
					}
				}


				if (Account.ALU_Seconds == 0) {
					RaiseMessageEvent("Keine Alu mehr");
					return;
				}

				int quest1Dauer = Convert.ToInt32(answerTarvern[241]);
				int quest2Dauer = Convert.ToInt32(answerTarvern[242]);
				int quest3Dauer = Convert.ToInt32(answerTarvern[243]);

				int quest1XP = Convert.ToInt32(answerTarvern[280]);
				int quest2XP = Convert.ToInt32(answerTarvern[281]);
				int quest3XP = Convert.ToInt32(answerTarvern[282]);

				int quest1Gold = Convert.ToInt32(answerTarvern[283]);
				int quest2Gold = Convert.ToInt32(answerTarvern[284]);
				int quest3Gold = Convert.ToInt32(answerTarvern[285]);

				if (Account.Settings.PerformQuesten) {
					ThreadSleep(Account.Settings.minTimeToTakeQuest, Account.Settings.maxTimeToTakeQuest);
					switch (Account.Settings.QuestMode) {
						case AutoQuestMode.BestXP:
							int xpSecondQuest1 = quest1XP / quest1Dauer;
							int xpSecondQuest2 = quest2XP / quest2Dauer;
							int xpSecondQuest3 = quest3XP / quest3Dauer;
							if (xpSecondQuest1 >= xpSecondQuest2 && xpSecondQuest1 >= xpSecondQuest3) {
								s = SendRequest(ActionTypes.TakeQuest1);
								Account.ALU_Seconds -= quest1Dauer;
								Account.QuestIsStarted = true;
								Account.QuestEndTime = DateTime.Now.AddSeconds(quest1Dauer);
							} else if (xpSecondQuest2 >= xpSecondQuest1 && xpSecondQuest2 >= xpSecondQuest3) {
								s = SendRequest(ActionTypes.TakeQuest2);
								Account.ALU_Seconds -= quest2Dauer;
								Account.QuestIsStarted = true;
								Account.QuestEndTime = DateTime.Now.AddSeconds(quest2Dauer);
							} else if (xpSecondQuest3 >= xpSecondQuest1 && xpSecondQuest3 >= xpSecondQuest2) {
								s = SendRequest(ActionTypes.TakeQuest3);
								Account.ALU_Seconds -= xpSecondQuest3;
								Account.QuestIsStarted = true;
								Account.QuestEndTime = DateTime.Now.AddSeconds(quest3Dauer);
							}
							break;
						case AutoQuestMode.BestGold:
							int goldSecondQuest1 = quest1Gold / quest1Dauer;
							int goldSecondQuest2 = quest2Gold / quest2Dauer;
							int goldSecondQuest3 = quest3Gold / quest3Dauer;
							if (goldSecondQuest1 >= goldSecondQuest2 && goldSecondQuest1 >= goldSecondQuest3) {
								s = SendRequest(ActionTypes.TakeQuest1);
								Account.ALU_Seconds -= quest1Dauer;
								Account.QuestIsStarted = true;
								Account.QuestEndTime = DateTime.Now.AddSeconds(quest1Dauer);
							} else if (goldSecondQuest2 >= goldSecondQuest1 && goldSecondQuest2 >= goldSecondQuest3) {
								s = SendRequest(ActionTypes.TakeQuest2);
								Account.ALU_Seconds -= quest2Dauer;
								Account.QuestIsStarted = true;
								Account.QuestEndTime = DateTime.Now.AddSeconds(quest2Dauer);
							} else if (goldSecondQuest3 >= goldSecondQuest1 && goldSecondQuest3 >= goldSecondQuest2) {
								s = SendRequest(ActionTypes.TakeQuest3);
								Account.ALU_Seconds -= quest3Dauer;
								Account.QuestIsStarted = true;
								Account.QuestEndTime = DateTime.Now.AddSeconds(quest3Dauer);
							}
							break;
						case AutoQuestMode.BestTime:
							if (quest1Dauer <= quest2Dauer && quest1Dauer <= quest3Dauer) {
								s = SendRequest(ActionTypes.TakeQuest1);
								Account.ALU_Seconds -= quest1Dauer;
								Account.QuestIsStarted = true;
								Account.QuestEndTime = DateTime.Now.AddSeconds(quest1Dauer);
							} else if (quest2Dauer <= quest1Dauer && quest2Dauer <= quest3Dauer) {
								s = SendRequest(ActionTypes.TakeQuest2);
								Account.ALU_Seconds -= quest2Dauer;
								Account.QuestIsStarted = true;
								Account.QuestEndTime = DateTime.Now.AddSeconds(quest2Dauer);
							} else if (quest3Dauer <= quest1Dauer && quest3Dauer <= quest2Dauer) {
								s = SendRequest(ActionTypes.TakeQuest3);
								Account.ALU_Seconds -= quest3Dauer;
								Account.QuestIsStarted = true;
								Account.QuestEndTime = DateTime.Now.AddSeconds(quest3Dauer);
							}
							break;
						case AutoQuestMode.HighstMountPerSecond:
							int _xpSecondQuest1 = quest1XP / quest1Dauer;
							int _xpSecondQuest2 = quest2XP / quest2Dauer;
							int _xpSecondQuest3 = quest3XP / quest3Dauer;
							int _goldSecondQuest1 = quest1Gold / quest1Dauer;
							int _goldSecondQuest2 = quest2Gold / quest2Dauer;
							int _goldSecondQuest3 = quest3Gold / quest3Dauer;
							if (GreaterThen(_xpSecondQuest1, _xpSecondQuest1, _xpSecondQuest2, _xpSecondQuest3, _goldSecondQuest1, _goldSecondQuest2, _goldSecondQuest3)) {
								s = SendRequest(ActionTypes.TakeQuest1);
								Account.ALU_Seconds -= quest1Dauer;
								Account.QuestIsStarted = true;
								Account.QuestEndTime = DateTime.Now.AddSeconds(quest1Dauer);
							} else if (GreaterThen(_xpSecondQuest2, _xpSecondQuest1, _xpSecondQuest2, _xpSecondQuest3, _goldSecondQuest1, _goldSecondQuest2, _goldSecondQuest3)) {
								s = SendRequest(ActionTypes.TakeQuest2);
								Account.ALU_Seconds -= quest2Dauer;
								Account.QuestIsStarted = true;
								Account.QuestEndTime = DateTime.Now.AddSeconds(quest2Dauer);
							} else if (GreaterThen(_xpSecondQuest3, _xpSecondQuest1, _xpSecondQuest2, _xpSecondQuest3, _goldSecondQuest1, _goldSecondQuest2, _goldSecondQuest3)) {
								s = SendRequest(ActionTypes.TakeQuest3);
								Account.ALU_Seconds -= quest3Dauer;
								Account.QuestIsStarted = true;
								Account.QuestEndTime = DateTime.Now.AddSeconds(quest3Dauer);
							} else if (GreaterThen(_goldSecondQuest1, _xpSecondQuest1, _xpSecondQuest2, _xpSecondQuest3, _goldSecondQuest1, _goldSecondQuest2, _goldSecondQuest3)) {
								s = SendRequest(ActionTypes.TakeQuest1);
								Account.ALU_Seconds -= quest1Dauer;
								Account.QuestIsStarted = true;
								Account.QuestEndTime = DateTime.Now.AddSeconds(quest1Dauer);
							} else if (GreaterThen(_goldSecondQuest2, _xpSecondQuest1, _xpSecondQuest2, _xpSecondQuest3, _goldSecondQuest1, _goldSecondQuest2, _goldSecondQuest3)) {
								s = SendRequest(ActionTypes.TakeQuest2);
								Account.ALU_Seconds -= quest2Dauer;
								Account.QuestIsStarted = true;
								Account.QuestEndTime = DateTime.Now.AddSeconds(quest2Dauer);
							} else if (GreaterThen(_goldSecondQuest3, _xpSecondQuest1, _xpSecondQuest2, _xpSecondQuest3, _goldSecondQuest1, _goldSecondQuest2, _goldSecondQuest3)) {
								s = SendRequest(ActionTypes.TakeQuest3);
								Account.ALU_Seconds -= quest3Dauer;
								Account.QuestIsStarted = true;
								Account.QuestEndTime = DateTime.Now.AddSeconds(quest3Dauer);
							}
							break;
					}
					RaiseMessageEvent("Quest ends " + Account.QuestEndTime.ToString());
				}
			} else {
				if (DateTime.Now > Account.QuestEndTime && Account.QuestIsStarted) {
					ThreadSleep(Account.Settings.minTimeToTakeQuest, Account.Settings.maxTimeToTakeQuest);
					string t = SendRequest(ActionTypes.JoinTarvern);
					ThreadSleep(Account.Settings.minTimeToEndAQuest, Account.Settings.maxTimeToEndAQuest);
					string returnString = SendRequest(ActionTypes.JoinCharacter);
					Account.QuestIsStarted = false;
					RaiseMessageEvent("Quest was finished");

					CharScreenArea.UpdateAccountStats(returnString, Account);
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

	public class MessageEventsArgs : EventArgs {
		public string Message { get; private set; }

		public MessageEventsArgs(string s) {
			Message = s;
		}
	}
}