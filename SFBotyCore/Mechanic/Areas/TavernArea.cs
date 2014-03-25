using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFBotyCore.Mechanic.Account;
using System.Net;
using System.Threading;
using Assert;
using SFBotyCore.Constants;

namespace SFBotyCore.Mechanic.Areas {
	public class TavernArea : BaseArea {

		#region Events
		public override event EventHandler<MessageEventsArgs> MessageOutput;
		#endregion

		public TavernArea()
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

			if (Account.BackpackIsFull || !DateTime.Now.Hour.IsBetween(Account.Settings.TownWatchMinHourForShortWork, Account.Settings.TownWatchMaxHourForShortWork)) {
				return;
			}

			string s;
			if (!Account.QuestIsStarted && !Account.TownWatchIsStarted) {
				ThreadSleep(Account.Settings.minShortTime, Account.Settings.maxShortTime);
				RaiseMessageEvent("Taverne betreten");
				s = SendRequest(ActionTypes.JoinTarvern);
				string[] answerTavern = s.Split('/');

				if (s.Substring(0, 4).Contains("103") || s.Substring(0, 4).Contains("106")) {
					ThreadSleep(Account.Settings.minShortTime, Account.Settings.maxShortTime);
					s = SendRequest(ActionTypes.JoinCharacter);
					ThreadSleep(Account.Settings.minShortTime, Account.Settings.maxShortTime);
					s = SendRequest(ActionTypes.JoinTarvern);
					answerTavern = s.Split('/');

				}
				int alu = Convert.ToInt32(answerTavern[456]);
				Account.ALU_Seconds = alu;

				if (Account.Settings.BuyBeer) {
					//answerTarvern[457] //usedBeerAmount
					//answerTarvern[108] //länge > 2 dann gibt es max 11 beer
					int usedBeer = Convert.ToInt32(answerTavern[457]);
					int maxBeer = answerTavern[108].Length > 2 ? 11 : 10;
					if (usedBeer < maxBeer && usedBeer < Account.Settings.MaxBeerToBuy && Account.ALU_Seconds <= 20 * 60) {
						while (Account.ALU_Seconds + 20 * 60 < 100 * 60 && Account.Mushroom > 1 && usedBeer < maxBeer) {
							ThreadSleep(Account.Settings.minShortTime, Account.Settings.maxShortTime);
							SendRequest(ActionTypes.BuyBeer);
							Account.ALU_Seconds += 20 * 60;
							usedBeer += 1;
							Account.Mushroom -= 1;
							RaiseMessageEvent("Buy Beer " + usedBeer.ToString());
						}
					}
				}

				if (Account.ALU_Seconds == 0) {
					RaiseMessageEvent("Keine Alu mehr");
					return;
				}

				int quest1Dauer = Convert.ToInt32(answerTavern[241]);
				int quest2Dauer = Convert.ToInt32(answerTavern[242]);
				int quest3Dauer = Convert.ToInt32(answerTavern[243]);

				if (Account.ALU_Seconds < quest1Dauer && Account.ALU_Seconds < quest2Dauer && Account.ALU_Seconds < quest3Dauer) {
					Account.ALU_Seconds = 0;
					RaiseMessageEvent("Alu reicht für keine Quest mehr aus.");
					return;
				}

				ItemTypes quest1ItemType = answerTavern[244].ToEnum<ItemTypes>();
				ItemTypes quest2ItemType = answerTavern[256].ToEnum<ItemTypes>();
				ItemTypes quest3ItemType = answerTavern[278].ToEnum<ItemTypes>();

				int quest1XP = Convert.ToInt32(answerTavern[280]);
				int quest2XP = Convert.ToInt32(answerTavern[281]);
				int quest3XP = Convert.ToInt32(answerTavern[282]);

				int quest1Gold = Convert.ToInt32(answerTavern[283]);
				int quest2Gold = Convert.ToInt32(answerTavern[284]);
				int quest3Gold = Convert.ToInt32(answerTavern[285]);

				// 30 - 42 => Spiegelstück
				// 1 - 10 => Dungeonschlüssel
				// 20 => Kloschlüssel
				int keyOrMirrorDescription = Convert.ToInt32(answerTavern[245]);

				if (Account.Settings.PerformQuesten) {
					ThreadSleep(Account.Settings.minLongTime, Account.Settings.maxLongTime);
					if (quest1ItemType == ItemTypes.SpiegelOderSchlüssel || quest2ItemType == ItemTypes.SpiegelOderSchlüssel || quest3ItemType == ItemTypes.SpiegelOderSchlüssel) {
						RaiseMessageEvent("Schlüssel oder Spiegelstück gefunden.");
						if (quest1ItemType == ItemTypes.SpiegelOderSchlüssel) {
							s = SendRequest(ActionTypes.TakeQuest1);
							Account.ALU_Seconds -= quest1Dauer;
							Account.QuestIsStarted = true;
							Account.QuestEndTime = DateTime.Now.AddSeconds(quest1Dauer);
						} else if (quest2ItemType == ItemTypes.SpiegelOderSchlüssel) {
							s = SendRequest(ActionTypes.TakeQuest2);
							Account.ALU_Seconds -= quest2Dauer;
							Account.QuestIsStarted = true;
							Account.QuestEndTime = DateTime.Now.AddSeconds(quest2Dauer);
						} else if (quest3ItemType == ItemTypes.SpiegelOderSchlüssel) {
							s = SendRequest(ActionTypes.TakeQuest3);
							Account.ALU_Seconds -= quest3Dauer;
							Account.QuestIsStarted = true;
							Account.QuestEndTime = DateTime.Now.AddSeconds(quest3Dauer);
						}
					} else {
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
									Account.ALU_Seconds -= quest3Dauer;
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
					}
					RaiseMessageEvent("Quest ends " + Account.QuestEndTime.ToString());
				}
			} else {
				if (DateTime.Now > Account.QuestEndTime && Account.QuestIsStarted) {
					ThreadSleep(Account.Settings.minLongTime, Account.Settings.maxLongTime);
					string t = SendRequest(ActionTypes.JoinTarvern);
					ThreadSleep(Account.Settings.minShortTime, Account.Settings.maxShortTime);
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
		public bool IsChatHistory { get; set; }

		public MessageEventsArgs(string s) {
			Message = s;
			IsChatHistory = false;
		}
	}
}
