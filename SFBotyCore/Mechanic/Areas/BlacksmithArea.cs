﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using SFBotyCore.Constants;

namespace SFBotyCore.Mechanic.Areas {
	public class BlacksmithArea : BaseArea {
		#region Events
		public override event EventHandler<MessageEventsArgs> MessageOutput;
		#endregion

		public BlacksmithArea() : base() { 
			
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

		//reine kopie, hier funktioniert noch garnichts
		public override void PerformArea() {
			base.PerformArea();

			string s;
			if (Account.BackpackItems.Count == 0 || Account.InventoryItems.Count == 0) {
				RaiseMessageEvent("Charakterübersicht betreten");
				ThreadSleep(Account.Settings.minTimeToJoinChar, Account.Settings.maxTimeToLogOut);
				s = SendRequest(ActionTypes.JoinCharacter);
				CharScreenArea.UpdateAccountStats(s, Account);
			}

			if (Account.BackpackIsFull) {
				RaiseMessageEvent("Betrete Waffenshop");
				ThreadSleep(Account.Settings.minShortTime, Account.Settings.maxShortTime);
				s = SendRequest(ActionTypes.JoinWeaponshop);
				int backpackslotWithLowestItemValue = Account.BackpackItems.Where(b => b.SilverValue != 0 && b.Typ != ItemTypes.Buff && b.IsEpic == false).OrderBy(b => b.SilverValue).First().InventoryID;

				s = SellItemWithLowestValue(backpackslotWithLowestItemValue, s);
				CharScreenArea.UpdateAccountStats(s, Account);
			}

			if (Account.Settings.BuyItemsInMagicShop && Account.WeaponShopLastVisitingForBuying.IsOtherDay(DateTime.Now) && Account.ALU_Seconds == 0) { //betrette den shop um ein Item zu kaufen
				Account.WeaponShopLastVisitingForBuying = DateTime.Now;
				RaiseMessageEvent("Betrete Waffenshop");
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

				//check for next item to buy
				if (hasBuyedOneItem) {
					//todo
				}

				//goto charscreen um items auszurüsten
				if (hasBuyedOneItem) {
					RaiseMessageEvent("Charakterübersicht betreten");
					ThreadSleep(Account.Settings.minTimeToJoinChar, Account.Settings.maxTimeToLogOut);
					s = SendRequest(ActionTypes.JoinCharacter);
					CharScreenArea.UpdateAccountStats(s, Account);
				}
			}

		}

		private string SellItemWithLowestValue(int InventoryID, string s) {
			RaiseMessageEvent(string.Format("Item im Slot {0}, wird verkauft.", InventoryID));
			ThreadSleep(Account.Settings.minTimeToSellItem, Account.Settings.maxTimeToSellItem);
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
	}
}