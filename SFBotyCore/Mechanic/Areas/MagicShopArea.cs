using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using SFBotyCore.Constants;

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

			string s = SendRequest(ActionTypes.JoinMagicshop);

			int i = 1;
			Dictionary<int, Item> BackpackItems = new Dictionary<int, Item>();
			while (i <= ResponseTypes.BackpackSize) {
				BackpackItems.Add(i, new Item(s.Split('/'), ResponseTypes.BackpackFirstItemPosition + (i * ResponseTypes.ItemSize)));
				i++;
			}

			ThreadSleep(Account.Settings.minTimeToDoToilet, Account.Settings.maxTimeToDoToilet);
			//Rucksackslotnummer mit dem niedrigsten Gold Wert
			//TODO Epics ignorieren
			int backpackslotWithLowestItemValue = BackpackItems.Where(b => b.Value.GoldValue != 0 && b.Value.Typ != ItemTypes.Buff).OrderBy(b => b.Value.GoldValue).First().Key;
		}

		public void SellItemWithLowestValue(int InventoryID, string s) {
			RaiseMessageEvent(string.Format("Item im Slot {0}, wird verkauft.", InventoryID));
			ThreadSleep(Account.Settings.minTimeToSellItem, Account.Settings.maxTimeToSellItem);
			s = SendRequest(ActionTypes.ItemAction + InventoryID + ";0;0");
		}

		public override void RaiseMessageEvent(string s) {
			if (MessageOutput != null) {
				MessageOutput(this, new MessageEventsArgs(s));
			}
		}
	}
}
