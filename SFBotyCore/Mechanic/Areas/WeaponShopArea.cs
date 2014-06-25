using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using SFBotyCore.Constants;

namespace SFBotyCore.Mechanic.Areas {
	public class WeaponShopArea : BaseArea {
		#region Events
		public override event EventHandler<MessageEventsArgs> MessageOutput;
		#endregion

		public WeaponShopArea() : base() { 
			
		}

		public override void RaiseMessageEvent(string s) {
			if (MessageOutput != null) {
				MessageOutput(this, new MessageEventsArgs(s));
			}
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
			if (Account.BackpackItems.Count == 0 || Account.InventoryItems.Count == 0) {
				RaiseMessageEvent("Charakterübersicht betreten");
				ThreadSleep(Account.Settings.minShortTime, Account.Settings.maxShortTime);
				s = SendRequest(ActionTypes.JoinCharacter);
				CharScreenArea.UpdateAccountStats(s, Account);
			}

			if (Account.BackpackIsFull) {
				s = GetOneBackpackSlotTroughWeaponShop();
			}

			if (Account.Settings.BuyItemsInMagicShop && Account.WeaponShopLastVisitingForBuying.IsOtherDay(DateTime.Now) && Account.ALU_Seconds == 0) { //betrette den shop um ein Item zu kaufen
				Account.WeaponShopLastVisitingForBuying = DateTime.Now;

				bool checkForAnotherItem = true;

				while (checkForAnotherItem) {
					RaiseMessageEvent("Betrete Waffenladen");
					ThreadSleep(Account.Settings.minShortTime, Account.Settings.maxShortTime);
					s = SendRequest(ActionTypes.JoinWeaponshop);

					List<Item> shopItems = new List<Item>();
					for (int i = 0; i < ResponseTypes.ShopSize; i++) {
						shopItems.Add(new Item(s.Split('/'), ResponseTypes.ShakesFirstItemPosition + (i * ResponseTypes.ItemSize), ResponseTypes.WeaponShopInventoryIDOffset));
					}

					string inventoryIDForBuying = GetInventoryIDFormMagicShopWithBetterItem(shopItems, Account.Settings.UseMushroomsForBuying);
					bool hasBuyedOneItem = false;
					if (Convert.ToInt32(inventoryIDForBuying) > 0) {
						ThreadSleep(Account.Settings.minLongTime, Account.Settings.maxLongTime);
						s = SendRequest(string.Concat("5043", "%3B", inventoryIDForBuying, "%3B2%3B", Account.FreeBackpackInventoryID));
						hasBuyedOneItem = true;
						RaiseMessageEvent(string.Format("Es wurde Item {0} gekauft und in den Rucksackslot {1} verstaut", inventoryIDForBuying, Account.FreeBackpackInventoryID));
					}

					//goto charscreen um items auszurüsten
					if (hasBuyedOneItem) {
						RaiseMessageEvent("Charakterübersicht betreten");
						ThreadSleep(Account.Settings.minShortTime, Account.Settings.maxShortTime);
						s = SendRequest(ActionTypes.JoinCharacter);
						CharScreenArea.UpdateAccountStats(s, Account);
						s = ItemsBuckleOn();

						if (Account.BackpackIsFull) {
							s = GetOneBackpackSlotTroughWeaponShop();
						}
					} else {
						//check for next item to buy
						checkForAnotherItem = false;
					}
				}
			}

		}

		private string SellItemWithLowestValue(int InventoryID, string s) {
			RaiseMessageEvent(string.Format("Item im Slot {0}, wird verkauft.", InventoryID));
			ThreadSleep(Account.Settings.minShortTime, Account.Settings.maxShortTime);
			return SendRequest(ActionTypes.ItemAction + InventoryID + "%3B0%3B0");
		}

		private string GetInventoryIDFormMagicShopWithBetterItem(List<Item> shopItems, bool useMushrooms) {
			string inventoryID = "-1";

			//welche Items kann ich mir leisten
			List<Item> avaibleItems = shopItems.Where(si => si.SilverValue <= Account.Silver && si.MushroomValue <= Account.Mushroom && si.Typ != ItemTypes.Buff).ToList();
			//darf ich pilze verwenden
			if (!useMushrooms) {
				avaibleItems = avaibleItems.Where(ai => ai.MushroomValue == 0).ToList();
			}

			//welche Items sind besser
			avaibleItems = avaibleItems.Where(ai => Helper.IsShopItemBetter(ai, Account)).ToList();
			//gibt das erst beste item aus
			if (avaibleItems.Count() > 0) {
				inventoryID = avaibleItems.OrderBy(ai => ai.MushroomValue).OrderBy(ai => ai.SilverValue).First().InventoryID.ToString();
			}

			return inventoryID;
		}

		public string ItemsBuckleOn() {
			string s = "";
			foreach (Item bpItem in Account.BackpackItems) {
				if (bpItem.Typ != ItemTypes.SpiegelOderSchlüssel && bpItem.Typ != ItemTypes.Buff && bpItem.Typ != ItemTypes.Leer) {
					bool bpItemIsBetter = Helper.IsBackpackItemBetterThanInventoryItem(bpItem, Account.InventoryItems.Where(a => a.Typ == bpItem.Typ).First(), Account);

					if (bpItemIsBetter) {
						RaiseMessageEvent(String.Format("Lege Rucksack-Item im Slot: {0} an.", bpItem.InventoryID));
						ThreadSleep(Account.Settings.minShortTime, Account.Settings.maxShortTime);
						s = SendRequest(ActionTypes.ItemAction + bpItem.InventoryID + "%3B1%3B-1");
					}
				}
			}
			return s;
		}

		public string GetOneBackpackSlotTroughWeaponShop() {
			RaiseMessageEvent("Betrete Waffenladen");
			ThreadSleep(Account.Settings.minShortTime, Account.Settings.maxShortTime);
			string s = SendRequest(ActionTypes.JoinWeaponshop);

			if (Account.BackpackItems.Where(b => b.SilverValue != 0 && b.Typ != ItemTypes.Buff && b.IsEpic == false).Count() > 0) {
				int backpackslotWithLowestItemValue = Account.BackpackItems.Where(b => b.SilverValue != 0 && b.Typ != ItemTypes.Buff && b.IsEpic == false).OrderBy(b => b.SilverValue).First().InventoryID;
				s = SellItemWithLowestValue(backpackslotWithLowestItemValue, s);
			} else {
				s = SellItemWithLowestValue(1, s);
			}

			CharScreenArea.UpdateAccountStats(s, Account);

			return s;
		}
	}
}
