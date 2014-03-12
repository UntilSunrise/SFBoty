using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using SFBotyCore.Constants;
using SFBotyCore.Mechanic;

namespace SFBotyCore.Mechanic.Areas {
	public class MagicShopArea : BaseArea {
	
		#region Events
		public override event EventHandler<MessageEventsArgs> MessageOutput;
		#endregion

		public MagicShopArea()
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
            if (Account.BackpackItems.Count == 0) {
                RaiseMessageEvent("Charakterübersicht betreten");
                ThreadSleep(Account.Settings.minTimeToJoinChar, Account.Settings.maxTimeToLogOut);
                s = SendRequest(ActionTypes.JoinCharacter);
                CharScreenArea.UpdateAccountStats(s, Account);
            }

			if (Account.BackpackIsFull) {
				RaiseMessageEvent("Betrete Zauberladen");
				ThreadSleep(Account.Settings.minTimeToJoinChar, Account.Settings.maxTimeToJoinChar);
				s = SendRequest(ActionTypes.JoinMagicshop);
				int backpackslotWithLowestItemValue = Account.BackpackItems.Where(b => b.SilverValue != 0 && b.Typ != ItemTypes.Buff && b.IsEpic == false).OrderBy(b => b.SilverValue).First().InventoryID;

				s = SellItemWithLowestValue(backpackslotWithLowestItemValue, s);

				CharScreenArea.UpdateAccountStats(s, Account);

			} else if(Account.Settings.BuyItemsInMagicShop && Account.MagicShopLastVisitingForBuying.IsOtherDay(DateTime.Now)) { //betrette den shop um ein Item oder Trank zu kaufen
				Account.MagicShopLastVisitingForBuying = DateTime.Now;
				RaiseMessageEvent("Betrete Zauberladen");
				ThreadSleep(Account.Settings.minTimeToJoinChar, Account.Settings.maxTimeToJoinChar);
				s = SendRequest(ActionTypes.JoinMagicshop);

				List<Item> shopItems = new List<Item>();
				for(int i = 0; i < ResponseTypes.ShopSize; i++) {
					shopItems.Add(new Item(s.Split('/'), ResponseTypes.FidgetFirstItemPosition + (i * ResponseTypes.ItemSize), ResponseTypes.MagicShopInventoryIDOffset));
				}

				string inventoryIDForBuying = GetInventoryIDFormMagicShopWithBetterItem(shopItems);
				if (Convert.ToInt32(inventoryIDForBuying) > 0) {
					//string sendRequestString = "5044" + "%3B" + inventoryIDForBuying + "2%3B" + freebackpackslot;
				}

				//check for next item to buy

				//goto charscreen um items auszurüsten
			}
		}

		private string SellItemWithLowestValue(int InventoryID, string s) {
			RaiseMessageEvent(string.Format("Item im Slot {0}, wird verkauft.", InventoryID));
			ThreadSleep(Account.Settings.minTimeToSellItem, Account.Settings.maxTimeToSellItem);
			return SendRequest(ActionTypes.ItemAction + InventoryID + "%3B0%3B0");
		}

		private string GetInventoryIDFormMagicShopWithBetterItem(List<Item> shopItems) {
			string inventoryID = "-1";

			//welche Items kann ich mir leisten
			//darf ich pilze verwenden
			//welche Items sind besser
			//gibt das erst beste item aus

			return inventoryID;
		}

		public override void RaiseMessageEvent(string s) {
			if (MessageOutput != null) {
				MessageOutput(this, new MessageEventsArgs(s));
			}
		}
	}
}
