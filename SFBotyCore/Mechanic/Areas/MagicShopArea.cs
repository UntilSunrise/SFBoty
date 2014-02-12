using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using SFBotyCore.Constants;
using SFBotyCore.Mechanic;

namespace SFBotyCore.Mechanic.Areas {
	class MagicShopArea : BaseArea {

		
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
				int backpackslotWithLowestItemValue = Account.BackpackItems.Where(b => b.GoldValue != 0 && b.Typ != ItemTypes.Buff && b.IsEpic == false).OrderBy(b => b.GoldValue).First().InventoryID;

				s = SellItemWithLowestValue(backpackslotWithLowestItemValue, s);

				CharScreenArea.UpdateAccountStats(s, Account);

			}// else do nothing
		}

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
