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

			ThreadSleep(Account.Settings.minTimeToJoinChar, Account.Settings.maxTimeToJoinChar);
			string s = SendRequest(ActionTypes.JoinMagicshop);

			int i = 1;
			Dictionary<int, Item> BackpackItems = new Dictionary<int, Item>();
			while (i <= ResponseTypes.BackpackSize) {
				BackpackItems.Add(i, new Item(s.Split('/'), ResponseTypes.BackpackFirstItemPosition + ((i - 1) * ResponseTypes.ItemSize)));
				i++;
			}

			if (BackpackItems.Where(b => b.Value.Typ != ItemTypes.Leer).Count() == 5) {
			int backpackslotWithLowestItemValue = BackpackItems.Where(b => b.Value.GoldValue != 0 && b.Value.Typ != ItemTypes.Buff && b.Value.IsEpic == false).OrderBy(b => b.Value.GoldValue).First().Key;

			s = SellItemWithLowestValue(backpackslotWithLowestItemValue, s);
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
