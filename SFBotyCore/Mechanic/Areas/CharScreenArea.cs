using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFBotyCore.Mechanic.Account;
using System.Net;
using System.Threading;
using SFBotyCore.Constants;

namespace SFBotyCore.Mechanic.Areas {
	public class CharScreenArea : BaseArea {

		#region Events
		public override event EventHandler<MessageEventsArgs> MessageOutput;
		#endregion

		public CharScreenArea()
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

			//wenn stadtwache läuft tue nichts
			string s;
			if ((Account.ALU_Seconds == 0 || !Account.Settings.PerformQuesten) && !Account.QuestIsStarted && !Account.TownWatchIsStarted) {
				RaiseMessageEvent("Charakterübersicht betreten");
				ThreadSleep(Account.Settings.minTimeToJoinChar, Account.Settings.maxTimeToLogOut);
				s = SendRequest(ActionTypes.JoinCharacter);
				CharScreenArea.UpdateAccountStats(s, Account);

				if (Account.Settings.PerformBuyStats) {

					bool canBuyStats = true;
					
					while (canBuyStats) {
						bool haveBuy = false;

                        int sumStats = 0;
                        if (Account.Settings.StatStrFactor > 0f) {
                            sumStats += Account.BaseStr;
                        }
                        if (Account.Settings.StatDexFactor > 0f) {
                            sumStats += Account.BaseDex;
                        }
                        if (Account.Settings.StatIntFactor > 0f) {
                            sumStats += Account.BaseInt;
                        }
                        if (Account.Settings.StatAusFactor > 0f) {
                            sumStats += Account.BaseAus;
                        }
                        if (Account.Settings.StatLuckFactor > 0f) {
                            sumStats += Account.BaseLuck;
                        }

                        int strLimit = (int)(sumStats * Account.Settings.StatStrFactor);
                        int dexLimit = (int)(sumStats * Account.Settings.StatDexFactor);
                        int intLimit = (int)(sumStats * Account.Settings.StatIntFactor);
                        int ausLimit = (int)(sumStats * Account.Settings.StatAusFactor);
                        int LuckLimit = (int)(sumStats * Account.Settings.StatLuckFactor);

						if (Account.BaseStr <= strLimit && Account.Silver > Helper.GetGoldMountFromGoldCurve(Account.BuyedStr)) {
							ThreadSleep(Account.Settings.minTimeToBuyStat, Account.Settings.maxTimeToBuyStat);
							s = SendRequest(ActionTypes.BuyStatStr);
							if (s.Split('/').Count() < 2) {
								canBuyStats = false;
								break;
							}
							RaiseMessageEvent("Kaufe Stärke");
							CharScreenArea.UpdateAccountStats(s, Account);
							RaiseMessageEvent("Stats: Str: " + Account.BaseStr.ToString() + " Ges: " + Account.BaseDex.ToString() + " Int: " + Account.BaseInt.ToString() + " Aus: " + Account.BaseAus.ToString() + " Glück: " + Account.BaseLuck.ToString());
							Account.BuyedStr += 1;
							Account.BaseStr += 1;
							Account.Silver -= Helper.GetGoldMountFromGoldCurve(Account.BuyedStr - 1);
							haveBuy = true;
						}

						if (Account.BaseDex <= dexLimit && Account.Silver > Helper.GetGoldMountFromGoldCurve(Account.BuyedDex)) {
							ThreadSleep(Account.Settings.minTimeToBuyStat, Account.Settings.maxTimeToBuyStat);
							s = SendRequest(ActionTypes.BuyStatDex);
							if (s.Split('/').Count() < 2) {
								canBuyStats = false;
								break;
							}
							RaiseMessageEvent("Kaufe Geschicklichkeit");
							CharScreenArea.UpdateAccountStats(s, Account);
							RaiseMessageEvent("Stats: Str: " + Account.BaseStr.ToString() + " Ges: " + Account.BaseDex.ToString() + " Int: " + Account.BaseInt.ToString() + " Aus: " + Account.BaseAus.ToString() + " Glück: " + Account.BaseLuck.ToString());
							Account.BuyedDex += 1;
							Account.BaseDex += 1;
							Account.Silver -= Helper.GetGoldMountFromGoldCurve(Account.BuyedDex - 1);
							haveBuy = true;
						}

						if (Account.BaseInt <= intLimit && Account.Silver > Helper.GetGoldMountFromGoldCurve(Account.BuyedInt)) {
							ThreadSleep(Account.Settings.minTimeToBuyStat, Account.Settings.maxTimeToBuyStat);
							s = SendRequest(ActionTypes.BuyStatInt);
							if (s.Split('/').Count() < 2) {
								canBuyStats = false;
								break;
							}
							RaiseMessageEvent("Kaufe Intelligenz");
							CharScreenArea.UpdateAccountStats(s, Account);
							RaiseMessageEvent("Stats: Str: " + Account.BaseStr.ToString() + " Ges: " + Account.BaseDex.ToString() + " Int: " + Account.BaseInt.ToString() + " Aus: " + Account.BaseAus.ToString() + " Glück: " + Account.BaseLuck.ToString());
							Account.BuyedInt += 1;
							Account.BaseInt += 1;
							Account.Silver -= Helper.GetGoldMountFromGoldCurve(Account.BuyedInt - 1);
							haveBuy = true;
						}

						if (Account.BaseAus <= ausLimit && Account.Silver > Helper.GetGoldMountFromGoldCurve(Account.BuyedAus)) {
							ThreadSleep(Account.Settings.minTimeToBuyStat, Account.Settings.maxTimeToBuyStat);
							s = SendRequest(ActionTypes.BuyStatAus);
							if (s.Split('/').Count() < 2) {
								canBuyStats = false;
								break;
							}
							RaiseMessageEvent("Kaufe Ausdauer");
							CharScreenArea.UpdateAccountStats(s, Account);
							RaiseMessageEvent("Stats: Str: " + Account.BaseStr.ToString() + " Ges: " + Account.BaseDex.ToString() + " Int: " + Account.BaseInt.ToString() + " Aus: " + Account.BaseAus.ToString() + " Glück: " + Account.BaseLuck.ToString());
							Account.BuyedAus += 1;
							Account.BaseAus += 1;
							Account.Silver -= Helper.GetGoldMountFromGoldCurve(Account.BuyedAus - 1);
							haveBuy = true;
						}

						if (Account.BaseLuck <= LuckLimit && Account.Silver > Helper.GetGoldMountFromGoldCurve(Account.BuyedLuck)) {
							ThreadSleep(Account.Settings.minTimeToBuyStat, Account.Settings.maxTimeToBuyStat);
							s = SendRequest(ActionTypes.BuyStatLuck);
							if (s.Split('/').Count() < 2) {
								canBuyStats = false;
								break;
							}
							RaiseMessageEvent("Kaufe Glück");
							CharScreenArea.UpdateAccountStats(s, Account);
							RaiseMessageEvent("Stats: Str: " + Account.BaseStr.ToString() + " Ges: " + Account.BaseDex.ToString() + " Int: " + Account.BaseInt.ToString() + " Aus: " + Account.BaseAus.ToString() + " Glück: " + Account.BaseLuck.ToString());
							Account.BuyedLuck += 1;
							Account.BaseLuck += 1;
							Account.Silver -= Helper.GetGoldMountFromGoldCurve(Account.BuyedLuck - 1);
							haveBuy = true;
						}

						if (!haveBuy) {
							canBuyStats = false;
						}
					}
				}
			}

		}

		public override void RaiseMessageEvent(string s) {
			if (MessageOutput != null) {
				MessageOutput(this, new MessageEventsArgs(s));
			}
		}

		public static void UpdateAccountStats(string s, Account.Account acc) {
			if (s == "E078") {
				return;
			}
			
			string[] answerTavern = s.Split('/');
			string str = answerTavern[ResponseTypes.str];
			string ges = answerTavern[ResponseTypes.ges];
			string inte = answerTavern[ResponseTypes.inte];
			string aus = answerTavern[ResponseTypes.aus];
			string luck = answerTavern[ResponseTypes.luck];
			string strAddon = answerTavern[ResponseTypes.strAddon];
			string gesAddon = answerTavern[ResponseTypes.gesAddon];
			string inteAddon = answerTavern[ResponseTypes.inteAddon];
			string ausAddon = answerTavern[ResponseTypes.ausAddon];
			string luckAddon = answerTavern[ResponseTypes.luckAddon];
			string strBuyed = answerTavern[ResponseTypes.strBuyed];
			string gesBuyed = answerTavern[ResponseTypes.gesBuyed];
			string inteBuyed = answerTavern[ResponseTypes.inteBuyed];
			string ausBuyed = answerTavern[ResponseTypes.ausBuyed];
			string luckBuyed = answerTavern[ResponseTypes.luckBuyed];

			acc.BaseStr = Convert.ToInt32(str);
			acc.BaseDex = Convert.ToInt32(ges);
			acc.BaseInt = Convert.ToInt32(inte);
			acc.BaseAus = Convert.ToInt32(aus);
			acc.BaseLuck = Convert.ToInt32(luck);

			acc.AddonStr = Convert.ToInt32(strAddon);
			acc.AddonDex = Convert.ToInt32(gesAddon);
			acc.AddonInt = Convert.ToInt32(inteAddon);
			acc.AddonAus = Convert.ToInt32(ausAddon);
			acc.AddonLuck = Convert.ToInt32(luckAddon);

			acc.BuyedStr = Convert.ToInt32(strBuyed);
			acc.BuyedDex = Convert.ToInt32(gesBuyed);
			acc.BuyedInt = Convert.ToInt32(inteBuyed);
			acc.BuyedAus = Convert.ToInt32(ausBuyed);
			acc.BuyedLuck = Convert.ToInt32(luckBuyed);

			acc.Silver = Convert.ToInt64(answerTavern[ResponseTypes.Silver]);
			acc.Mushroom = Convert.ToInt32(answerTavern[ResponseTypes.Mushrooms]);
			acc.Level = Convert.ToInt32(answerTavern[ResponseTypes.Level]);
			acc.Honor = Convert.ToInt32(answerTavern[ResponseTypes.Honor]);
			acc.Rang = Convert.ToInt32(answerTavern[ResponseTypes.Rang]);

			int i = 1;
			acc.BackpackItems.Clear();
			while (i <= ResponseTypes.BackpackSize) {
				acc.BackpackItems.Add(new Item(s.Split('/'), ResponseTypes.BackpackFirstItemPosition + ((i - 1) * ResponseTypes.ItemSize)));
				i++;
			}

			int j = 1;
			acc.InventoryItems.Clear();
			while (j <= 10) {
				acc.InventoryItems.Add(new Item(s.Split('/'), ResponseTypes.InventoryFirstItemPosition + ((j - 1) * ResponseTypes.ItemSize)));
				j++;
			}
		}
	}
}
