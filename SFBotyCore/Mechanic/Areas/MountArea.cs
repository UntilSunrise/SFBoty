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

	public class MountArea : BaseArea {

		private static int pigCostSilver = 100;
		private static int wolfCostSilver = 500;
		private static int raptorCostSilver = 1000;
		private static int dragonCostSilver = 0;

		private static int pigCostMushroom = 0;
		private static int wolfCostMushroom = 0;
		private static int raptorCostMushroom = 1;
		private static int dragonCostMushroom = 25;

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

			if (!Account.Settings.BuyMount || DateTime.Now < Account.MountDuration && Account.Mount == Account.Settings.MountToBuy || Account.Settings.MountToBuy == MountTypes.None) {
				return;
			}

			if (Account.Mount != Account.Settings.MountToBuy && !CanBuySelectedMount() && Account.Mount != MountTypes.None) {
				return;
			}

			if (!Account.QuestIsStarted && !Account.TownWatchIsStarted || Account.MirrorIsCompleted) {
				RaiseMessageEvent("Join Mount Shop");
				ThreadSleep(Account.Settings.minShortTime, Account.Settings.maxShortTime);
				string s = SendRequest(ActionTypes.JoinMountShop);

				//checkForMoney
				bool canBuyMount = false;
				canBuyMount = CanBuySelectedMount();

				//try To Buy A Cheaper One
				MountTypes nextMount = Account.Settings.MountToBuy;
				while ((int)nextMount > 1 && !canBuyMount) {
					nextMount = ((int)nextMount - 1).ToString().ToEnum<MountTypes>();
					if (CanBuyAMount(nextMount)) {
						canBuyMount = true;
					}
				}

				if (canBuyMount && nextMount > Account.Mount) {
					RaiseMessageEvent(String.Concat("Buy Mount ", nextMount.ToString()));
					ThreadSleep(Account.Settings.minShortTime, Account.Settings.maxShortTime);
					s = SendRequest(String.Concat(ActionTypes.BuyMount, (int)nextMount));

					ThreadSleep(Account.Settings.minShortTime, Account.Settings.maxShortTime);
					s = SendRequest(ActionTypes.JoinCharacter);

					canBuyMount = false;
					Account.MountDuration = Account.MountDuration.AddDays(14d);
					Account.Mount = nextMount;

					RemoveMountCost(nextMount);
				}
			}
		}

		private bool CanBuySelectedMount() {
			return CanBuyAMount(Account.Settings.MountToBuy);
		}

		private bool CanBuyAMount(MountTypes type) {
			bool canBuyMount = false;
			switch (type) {
				case MountTypes.Schwein:
					if (Account.Silver >= pigCostSilver && Account.Mushroom >= pigCostMushroom) {
						canBuyMount = true;
					}
					break;
				case MountTypes.Wolf:
					if (Account.Silver >= wolfCostSilver && Account.Mushroom >= wolfCostMushroom) {
						canBuyMount = true;
					}
					break;
				case MountTypes.Raptor:
					if (Account.Silver >= raptorCostSilver && Account.Mushroom >= raptorCostMushroom) {
						canBuyMount = true;
					}
					break;
				case MountTypes.Drachengreif:
					if (Account.Silver >= dragonCostSilver && Account.Mushroom >= dragonCostMushroom) {
						canBuyMount = true;
					}
					break;
				default:
					canBuyMount = false;
					break;
			}

			return canBuyMount;
		}

		private void RemoveMountCost(MountTypes type) {
			switch (type) {
				case MountTypes.Schwein:
					if (Account.Silver >= pigCostSilver && Account.Mushroom >= pigCostMushroom) {
						Account.Silver -= pigCostSilver;
						Account.Mushroom -= pigCostMushroom;
					}
					break;
				case MountTypes.Wolf:
					if (Account.Silver >= wolfCostSilver && Account.Mushroom >= wolfCostMushroom) {
						Account.Silver -= wolfCostSilver;
						Account.Mushroom -= wolfCostMushroom;
					}
					break;
				case MountTypes.Raptor:
					if (Account.Silver >= raptorCostSilver && Account.Mushroom >= raptorCostMushroom) {
						Account.Silver -= raptorCostSilver;
						Account.Mushroom -= raptorCostMushroom;
					}
					break;
				case MountTypes.Drachengreif:
					if (Account.Silver >= dragonCostSilver && Account.Mushroom >= dragonCostMushroom) {
						Account.Silver -= dragonCostSilver;
						Account.Mushroom -= dragonCostMushroom;
					}
					break;
				default:
					break;
			}
		}

	}

}
