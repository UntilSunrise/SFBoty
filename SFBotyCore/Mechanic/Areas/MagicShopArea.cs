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

			} else if(1==2) { //betrette den shop um ein Item oder Trank zu kaufen
				RaiseMessageEvent("Betrete Zauberladen");
				ThreadSleep(Account.Settings.minTimeToJoinChar, Account.Settings.maxTimeToJoinChar);
				s = SendRequest(ActionTypes.JoinMagicshop);

				List<Item> shopItems = new List<Item>();
				for(int i = 0; i < ResponseTypes.ShopSize; i++) {
					shopItems.Add(new Item(s.Split('/'), 361 + (i * ResponseTypes.ItemSize), 16));
				}
			}
		}
		///*
		// * curl "http://s30.sfgame.de/request.php?req=b08v3349T1NC154H3my791z80l210M91014&random="%"2&rnd=5486142141394533540033" -H "Accept: */*" -H "Connection: keep-alive" -H "Accept-Encoding: gzip,deflate,sdch" -H "Referer: http://s30.sfgame.de/" -H "Accept-Language: de-DE,de;q=0.8,en-US;q=0.6,en;q=0.4" -H "User-Agent: Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/33.0.1750.146 Safari/537.36" --compressed
		// * curl "http://s30.sfgame.de/request.php?req=b08v3349T1NC154H3my791z80l210M915044;1;2;3&random="%"2&rnd=9137640921394533563755" -H "Accept: */*" -H "Connection: keep-alive" -H "Accept-Encoding: gzip,deflate,sdch" -H "Referer: http://s30.sfgame.de/" -H "Accept-Language: de-DE,de;q=0.8,en-US;q=0.6,en;q=0.4" -H "User-Agent: Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/33.0.1750.146 Safari/537.36" --compressed
		// * kaufe erstes item im shop und lege ins ins 3ten slot im rucksack
		// * /

		private string SellItemWithLowestValue(int InventoryID, string s) {
			RaiseMessageEvent(string.Format("Item im Slot {0}, wird verkauft.", InventoryID));
			ThreadSleep(Account.Settings.minTimeToSellItem, Account.Settings.maxTimeToSellItem);
			return SendRequest(ActionTypes.ItemAction + InventoryID + ";0;0");
		}

		public override void RaiseMessageEvent(string s) {
			if (MessageOutput != null) {
				MessageOutput(this, new MessageEventsArgs(s));
			}
		}
	}
}
