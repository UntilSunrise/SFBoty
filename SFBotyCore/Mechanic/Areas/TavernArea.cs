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
				RaiseMessageEvent("Betrete Taverne");
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
							RaiseMessageEvent("Kaufe Bier " + usedBeer.ToString());
						}
					}
				}

				if (Account.ALU_Seconds == 0) {
					RaiseMessageEvent("Keine Alu mehr");
					return;
				}

				int quest1Duration = Convert.ToInt32(answerTavern[241]);
				int quest2Duration = Convert.ToInt32(answerTavern[242]);
				int quest3Duration = Convert.ToInt32(answerTavern[243]);

				if (Account.ALU_Seconds < quest1Duration && Account.ALU_Seconds < quest2Duration && Account.ALU_Seconds < quest3Duration) {
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
							Account.ALU_Seconds -= quest1Duration;
							Account.QuestIsStarted = true;
							Account.QuestEndTime = DateTime.Now.AddSeconds(quest1Duration);
						} else if (quest2ItemType == ItemTypes.SpiegelOderSchlüssel) {
							s = SendRequest(ActionTypes.TakeQuest2);
							Account.ALU_Seconds -= quest2Duration;
							Account.QuestIsStarted = true;
							Account.QuestEndTime = DateTime.Now.AddSeconds(quest2Duration);
						} else if (quest3ItemType == ItemTypes.SpiegelOderSchlüssel) {
							s = SendRequest(ActionTypes.TakeQuest3);
							Account.ALU_Seconds -= quest3Duration;
							Account.QuestIsStarted = true;
							Account.QuestEndTime = DateTime.Now.AddSeconds(quest3Duration);
						}
					} else {
						switch (Account.Settings.QuestMode) {
							case AutoQuestMode.BestXP:
								int xpSecondQuest1 = quest1XP / quest1Duration;
								int xpSecondQuest2 = quest2XP / quest2Duration;
								int xpSecondQuest3 = quest3XP / quest3Duration;
								if (xpSecondQuest1 >= xpSecondQuest2 && xpSecondQuest1 >= xpSecondQuest3) {
									s = SendRequest(ActionTypes.TakeQuest1);
									Account.ALU_Seconds -= quest1Duration;
									Account.QuestIsStarted = true;
									Account.QuestEndTime = DateTime.Now.AddSeconds(quest1Duration);
								} else if (xpSecondQuest2 >= xpSecondQuest1 && xpSecondQuest2 >= xpSecondQuest3) {
									s = SendRequest(ActionTypes.TakeQuest2);
									Account.ALU_Seconds -= quest2Duration;
									Account.QuestIsStarted = true;
									Account.QuestEndTime = DateTime.Now.AddSeconds(quest2Duration);
								} else if (xpSecondQuest3 >= xpSecondQuest1 && xpSecondQuest3 >= xpSecondQuest2) {
									s = SendRequest(ActionTypes.TakeQuest3);
									Account.ALU_Seconds -= quest3Duration;
									Account.QuestIsStarted = true;
									Account.QuestEndTime = DateTime.Now.AddSeconds(quest3Duration);
								}
								break;
							case AutoQuestMode.BestGold:
								int goldSecondQuest1 = quest1Gold / quest1Duration;
								int goldSecondQuest2 = quest2Gold / quest2Duration;
								int goldSecondQuest3 = quest3Gold / quest3Duration;
								if (goldSecondQuest1 >= goldSecondQuest2 && goldSecondQuest1 >= goldSecondQuest3) {
									s = SendRequest(ActionTypes.TakeQuest1);
									Account.ALU_Seconds -= quest1Duration;
									Account.QuestIsStarted = true;
									Account.QuestEndTime = DateTime.Now.AddSeconds(quest1Duration);
								} else if (goldSecondQuest2 >= goldSecondQuest1 && goldSecondQuest2 >= goldSecondQuest3) {
									s = SendRequest(ActionTypes.TakeQuest2);
									Account.ALU_Seconds -= quest2Duration;
									Account.QuestIsStarted = true;
									Account.QuestEndTime = DateTime.Now.AddSeconds(quest2Duration);
								} else if (goldSecondQuest3 >= goldSecondQuest1 && goldSecondQuest3 >= goldSecondQuest2) {
									s = SendRequest(ActionTypes.TakeQuest3);
									Account.ALU_Seconds -= quest3Duration;
									Account.QuestIsStarted = true;
									Account.QuestEndTime = DateTime.Now.AddSeconds(quest3Duration);
								}
								break;
							case AutoQuestMode.BestTime:
								if (quest1Duration <= quest2Duration && quest1Duration <= quest3Duration) {
									s = SendRequest(ActionTypes.TakeQuest1);
									Account.ALU_Seconds -= quest1Duration;
									Account.QuestIsStarted = true;
									Account.QuestEndTime = DateTime.Now.AddSeconds(quest1Duration);
								} else if (quest2Duration <= quest1Duration && quest2Duration <= quest3Duration) {
									s = SendRequest(ActionTypes.TakeQuest2);
									Account.ALU_Seconds -= quest2Duration;
									Account.QuestIsStarted = true;
									Account.QuestEndTime = DateTime.Now.AddSeconds(quest2Duration);
								} else if (quest3Duration <= quest1Duration && quest3Duration <= quest2Duration) {
									s = SendRequest(ActionTypes.TakeQuest3);
									Account.ALU_Seconds -= quest3Duration;
									Account.QuestIsStarted = true;
									Account.QuestEndTime = DateTime.Now.AddSeconds(quest3Duration);
								}
								break;
							case AutoQuestMode.HighstMountPerSecond:
								int _xpSecondQuest1 = quest1XP / quest1Duration;
								int _xpSecondQuest2 = quest2XP / quest2Duration;
								int _xpSecondQuest3 = quest3XP / quest3Duration;
								int _goldSecondQuest1 = quest1Gold / quest1Duration;
								int _goldSecondQuest2 = quest2Gold / quest2Duration;
								int _goldSecondQuest3 = quest3Gold / quest3Duration;
								if (GreaterThen(_xpSecondQuest1, _xpSecondQuest1, _xpSecondQuest2, _xpSecondQuest3, _goldSecondQuest1, _goldSecondQuest2, _goldSecondQuest3)) {
									s = SendRequest(ActionTypes.TakeQuest1);
									Account.ALU_Seconds -= quest1Duration;
									Account.QuestIsStarted = true;
									Account.QuestEndTime = DateTime.Now.AddSeconds(quest1Duration);
								} else if (GreaterThen(_xpSecondQuest2, _xpSecondQuest1, _xpSecondQuest2, _xpSecondQuest3, _goldSecondQuest1, _goldSecondQuest2, _goldSecondQuest3)) {
									s = SendRequest(ActionTypes.TakeQuest2);
									Account.ALU_Seconds -= quest2Duration;
									Account.QuestIsStarted = true;
									Account.QuestEndTime = DateTime.Now.AddSeconds(quest2Duration);
								} else if (GreaterThen(_xpSecondQuest3, _xpSecondQuest1, _xpSecondQuest2, _xpSecondQuest3, _goldSecondQuest1, _goldSecondQuest2, _goldSecondQuest3)) {
									s = SendRequest(ActionTypes.TakeQuest3);
									Account.ALU_Seconds -= quest3Duration;
									Account.QuestIsStarted = true;
									Account.QuestEndTime = DateTime.Now.AddSeconds(quest3Duration);
								} else if (GreaterThen(_goldSecondQuest1, _xpSecondQuest1, _xpSecondQuest2, _xpSecondQuest3, _goldSecondQuest1, _goldSecondQuest2, _goldSecondQuest3)) {
									s = SendRequest(ActionTypes.TakeQuest1);
									Account.ALU_Seconds -= quest1Duration;
									Account.QuestIsStarted = true;
									Account.QuestEndTime = DateTime.Now.AddSeconds(quest1Duration);
								} else if (GreaterThen(_goldSecondQuest2, _xpSecondQuest1, _xpSecondQuest2, _xpSecondQuest3, _goldSecondQuest1, _goldSecondQuest2, _goldSecondQuest3)) {
									s = SendRequest(ActionTypes.TakeQuest2);
									Account.ALU_Seconds -= quest2Duration;
									Account.QuestIsStarted = true;
									Account.QuestEndTime = DateTime.Now.AddSeconds(quest2Duration);
								} else if (GreaterThen(_goldSecondQuest3, _xpSecondQuest1, _xpSecondQuest2, _xpSecondQuest3, _goldSecondQuest1, _goldSecondQuest2, _goldSecondQuest3)) {
									s = SendRequest(ActionTypes.TakeQuest3);
									Account.ALU_Seconds -= quest3Duration;
									Account.QuestIsStarted = true;
									Account.QuestEndTime = DateTime.Now.AddSeconds(quest3Duration);
								}
								break;
						}
					}
					RaiseMessageEvent("Quest endet: " + Account.QuestEndTime.ToString());
				}
			} else {
				if (DateTime.Now > Account.QuestEndTime && Account.QuestIsStarted) {
					ThreadSleep(Account.Settings.minLongTime, Account.Settings.maxLongTime);
					string t = SendRequest(ActionTypes.JoinTarvern);
					ThreadSleep(Account.Settings.minShortTime, Account.Settings.maxShortTime);
					string returnString = SendRequest(ActionTypes.JoinCharacter);
					Account.QuestIsStarted = false;
					RaiseMessageEvent("Quest ist erledigt");

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
