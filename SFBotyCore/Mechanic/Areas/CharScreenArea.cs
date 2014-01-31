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

		public CharScreenArea() : base() { 
		
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
			if ((Account.ALU_Seconds == 0 || !Account.Settings.PerformQuesten) && !Account.QuestIsStarted && !Account.StadtwacheWurdeGestatet) {
				RaiseMessageEvent("Join Char-Übersicht");
			  	ThreadSleep(Account.Settings.minTimeToJoinChar, Account.Settings.maxTimeToLogOut);
				s = SendRequest(ActionTypes.JoinCharacter);
				CharScreenArea.UpdateAccountStats(s, Account);

				if (Account.Settings.PerformBuyStats) {
					RaiseMessageEvent("Check To Buy Stats");

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

					bool canBuyStats = true;
					int strLimit = (int)(sumStats * Account.Settings.StatStrFactor);
					int dexLimit = (int)(sumStats * Account.Settings.StatDexFactor);
					int intLimit = (int)(sumStats * Account.Settings.StatIntFactor);
					int ausLimit = (int)(sumStats * Account.Settings.StatAusFactor);
					int LuckLimit = (int)(sumStats * Account.Settings.StatLuckFactor);

					while (canBuyStats) {
						if (Account.BaseStr <= strLimit) {
							ThreadSleep(Account.Settings.minTimeToBuyStat, Account.Settings.maxTimeToBuyStat);
							s = SendRequest(ActionTypes.BuyStatStr);
							if (s.Split('/').Count() < 2) {
								canBuyStats = false;
								break;
							}
							RaiseMessageEvent("buying Str");
							CharScreenArea.UpdateAccountStats(s, Account);
							RaiseMessageEvent("Stats: Str: " + Account.BaseStr.ToString() + " Dex: " + Account.BaseDex.ToString() + " Int: " + Account.BaseInt.ToString() + " Aus: " + Account.BaseAus.ToString() + " Luck: " + Account.BaseLuck.ToString());
						}

						if (Account.BaseDex <= dexLimit) {
							ThreadSleep(Account.Settings.minTimeToBuyStat, Account.Settings.maxTimeToBuyStat);
							s = SendRequest(ActionTypes.BuyStatDex);
							if (s.Split('/').Count() < 2) {
								canBuyStats = false;
								break;
							}
							RaiseMessageEvent("buying Dex");
							CharScreenArea.UpdateAccountStats(s, Account);
							RaiseMessageEvent("Stats: Str: " + Account.BaseStr.ToString() + " Dex: " + Account.BaseDex.ToString() + " Int: " + Account.BaseInt.ToString() + " Aus: " + Account.BaseAus.ToString() + " Luck: " + Account.BaseLuck.ToString());
						}

						if (Account.BaseInt <= intLimit) {
							ThreadSleep(Account.Settings.minTimeToBuyStat, Account.Settings.maxTimeToBuyStat);
							s = SendRequest(ActionTypes.BuyStatInt);
							if (s.Split('/').Count() < 2) {
								canBuyStats = false;
								break;
							}
							RaiseMessageEvent("buying Int");
							CharScreenArea.UpdateAccountStats(s, Account);
							RaiseMessageEvent("Stats: Str: " + Account.BaseStr.ToString() + " Dex: " + Account.BaseDex.ToString() + " Int: " + Account.BaseInt.ToString() + " Aus: " + Account.BaseAus.ToString() + " Luck: " + Account.BaseLuck.ToString());
						}

						if (Account.BaseAus <= ausLimit) {
							ThreadSleep(Account.Settings.minTimeToBuyStat, Account.Settings.maxTimeToBuyStat);
							s = SendRequest(ActionTypes.BuyStatAus);
							if (s.Split('/').Count() < 2) {
								canBuyStats = false;
								break;
							}
							RaiseMessageEvent("buying Aus");
							CharScreenArea.UpdateAccountStats(s, Account);
							RaiseMessageEvent("Stats: Str: " + Account.BaseStr.ToString() + " Dex: " + Account.BaseDex.ToString() + " Int: " + Account.BaseInt.ToString() + " Aus: " + Account.BaseAus.ToString() + " Luck: " + Account.BaseLuck.ToString());
						}

						if (Account.BaseLuck <= LuckLimit) {				
							ThreadSleep(Account.Settings.minTimeToBuyStat, Account.Settings.maxTimeToBuyStat);
							s = SendRequest(ActionTypes.BuyStatLuck);
							if (s.Split('/').Count() < 2) {
								canBuyStats = false;
								break;
							}
							RaiseMessageEvent("buying Luck");
							CharScreenArea.UpdateAccountStats(s, Account);
							RaiseMessageEvent("Stats: Str: " + Account.BaseStr.ToString() + " Dex: " + Account.BaseDex.ToString() + " Int: " + Account.BaseInt.ToString() + " Aus: " + Account.BaseAus.ToString() + " Luck: " + Account.BaseLuck.ToString());
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

		public static void UpdateAccountStats (string s, Account.Account acc) {
			string[] answerTavern = s.Split('/');
			string str = answerTavern[30];
			string ges = answerTavern[31];
			string inte = answerTavern[32];
			string aus = answerTavern[33];
			string luck = answerTavern[34];
			string strAddon = answerTavern[35];
			string gesAddon = answerTavern[36];
			string inteAddon = answerTavern[37];
			string ausAddon = answerTavern[38];
			string luckAddon = answerTavern[39];

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

			acc.Silver = Convert.ToInt32(answerTavern[13]);
			acc.Pilze = Convert.ToInt32(answerTavern[14]);
			acc.Level = Convert.ToInt32(answerTavern[7]);
            acc.Honor = Convert.ToInt32(answerTavern[10]);
            acc.Rang  = Convert.ToInt32(answerTavern[11]);
		}
	}
}
