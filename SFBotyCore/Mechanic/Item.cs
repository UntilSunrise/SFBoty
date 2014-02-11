using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFBotyCore.Mechanic;
using SFBotyCore.Constants;

namespace SFBotyCore.Mechanic {
	public class Item {
		private int inventoryID;
		private double typeOriginal;
		private double picOriginal;
		private int damageMin;
		private int damageMax;
		private int attributeType1;
		private int attributeType2;
		private int attributeType3;
		private int attributeValue1;
		private int attributeValue2;
		private int attributeValue3;
		private int goldValue;
		private double mushroomValue;
		private int enchantment;
		private int socket;
		private int enchantmentPower;
		private int socketPower;

		public int InventoryID { get; private set; }
		public ItemTypes Typ { get; private set; }
		public int DamageMin { get; private set; }
		public int DamageMax { get; private set; }
		public AttributeTypes AttributeType1 { get; private set; }
		public AttributeTypes AttributeType2 { get; private set; }
		public AttributeTypes AttributeType3 { get; private set; }
		public int AttributeValue1 { get; private set; }
		public int AttributeValue2 { get; private set; }
		public int AttributeValue3 { get; private set; }
		public int GoldValue { get; private set; }
		public bool IsEpic { get; private set; }

		public Item(string[] responseString, int offset) {
			inventoryID = (offset - ResponseTypes.BackpackFirstItemPosition) /  ResponseTypes.ItemSize;
			typeOriginal = Convert.ToInt32(responseString[(offset + ResponseTypes.ItemTyp)]);
			picOriginal = Convert.ToDouble(responseString[(offset + ResponseTypes.ItemPicture)]);
			mushroomValue = Convert.ToInt32(responseString[(offset + ResponseTypes.ItemMushroomValue)]);
			enchantment = (int)(typeOriginal / Math.Pow(2, 24));
			socket = (int)(typeOriginal - (enchantment * Math.Pow(2, 24)));
			socket = (int)(socket / Math.Pow(2, 16));
			typeOriginal = ((typeOriginal - (enchantment * Math.Pow(2, 24))) - (socket * Math.Pow(2, 16)));
			enchantmentPower = (int)(picOriginal / Math.Pow(2, 16));
			picOriginal = (picOriginal - (enchantmentPower * Math.Pow(2, 16)));
			socketPower = (int)(mushroomValue / Math.Pow(2, 16));
			mushroomValue = (mushroomValue - (socketPower * Math.Pow(2, 16)));
			damageMin = Convert.ToInt32(responseString[(offset + ResponseTypes.ItemDamageMin)]);
			damageMax = Convert.ToInt32(responseString[(offset + ResponseTypes.ItemDamageMax)]);
			attributeType1 = Convert.ToInt32(responseString[(offset + ResponseTypes.ItemAttributeType1)]);
			attributeType2 = Convert.ToInt32(responseString[(offset + ResponseTypes.ItemAttributeType2)]);
			attributeType3 = Convert.ToInt32(responseString[(offset + ResponseTypes.ItemAttributeType3)]);
			attributeValue1 = Convert.ToInt32(responseString[(offset + ResponseTypes.ItemAttributeValue1)]);
			attributeValue2 = Convert.ToInt32(responseString[(offset + ResponseTypes.ItemAttributeValue2)]);
			attributeValue3 = Convert.ToInt32(responseString[(offset + ResponseTypes.ItemAttributeValue3)]);
			goldValue = Convert.ToInt32(responseString[(offset + ResponseTypes.ItemGoldValue)]);

			InventoryID = this.inventoryID;
			IsEpic = IsEpicCheck(this.picOriginal);
			Typ = (ItemTypes)this.typeOriginal;
			DamageMin = this.damageMin;
			DamageMax = this.damageMax;
			AttributeType1 = (AttributeTypes)this.attributeType1;
			AttributeType2 = (AttributeTypes)this.attributeType2;
			AttributeType3 = (AttributeTypes)this.attributeType3;
			AttributeValue1 = this.attributeValue1;
			AttributeValue2 = this.attributeValue2;
			AttributeValue3 = this.attributeValue3;
			GoldValue = this.goldValue;
		}

		private bool IsEpicCheck(double picNumber) {
			while (picNumber > 1000) {
				picNumber = picNumber - 1000;
			}
			return (picNumber >= 50);
		}
	}
}
