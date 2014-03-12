using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFBotyCore.Mechanic;
using SFBotyCore.Constants;
using SFBotyCore.Mechanic.Account;

namespace SFBotyCore {
	public static class Helper {

		public static int GetGoldMountFromGoldCurve(int statAmount, int[] goldCurve) {
			int gold = goldCurve[statAmount];
			return gold <= 0 || gold > 10000000 || statAmount > 15000 ? 10000000 : gold;
		}

		public static int GetGoldMountFromGoldCurve(int statAmount) {
			return GetGoldMountFromGoldCurve(statAmount, GoldCurve);
		}

		private static int[] _goldcurve;
		public static int[] GoldCurve {
			get {
				if (_goldcurve == null)
					_goldcurve = CalcGoldCurve();
				return _goldcurve;
			}
		}
		public static int[] CalcGoldCurve() {
			int priceLimit = 10000000;

			bool attPriceLimitation = false;
			int[] GoldKurve = new int[15001];
			int[] TrueAttPreis = new int[15001];
			GoldKurve[1] = 25;
			GoldKurve[2] = 50;
			GoldKurve[3] = 75;
			int i = 4;
			while (i <= 15000) {
				GoldKurve[i] = (((GoldKurve[(i - 1)]) + ((GoldKurve[((i / 2))] / 3))) + ((GoldKurve[((i / 3))] / 4)));
				GoldKurve[i] = ((GoldKurve[i] / 5));
				GoldKurve[i] = (GoldKurve[i] * 5);
				i = (i + 1);
			};
			i = 0;
			while (i <= 15000) {
				TrueAttPreis[i] = GoldKurve[((1 + (i / 5)))];
				i = (i + 1);
			};
			i = 0;
			while (i <= 14996) {
				if (attPriceLimitation) {
					TrueAttPreis[i] = priceLimit;
				} else {
					TrueAttPreis[i] = (((((TrueAttPreis[i]) + (TrueAttPreis[(i + 1)])) + (TrueAttPreis[(i + 2)])) + (TrueAttPreis[(i + 3)])) + (TrueAttPreis[(i + 4)]));
					TrueAttPreis[i] = ((TrueAttPreis[i] / 5));
					TrueAttPreis[i] = ((TrueAttPreis[i] / 5));
					TrueAttPreis[i] = ((TrueAttPreis[i] * 5));
					if (TrueAttPreis[i] > priceLimit) {
						TrueAttPreis[i] = priceLimit;
						attPriceLimitation = true;
					};
				};
				i = (i + 1);
			};

			return TrueAttPreis;
		}

		public static bool IsShopItemBetter(Item shopItem, Account account) {
			if (shopItem.Typ == ItemTypes.Leer) {
				return false;
			} else {
				if (account.InventoryItems.Where(i => i.Typ == shopItem.Typ).Count() == 0) {
					return true;
				}

				return Helper.IsBackpackItemBetterThanInventoryItem(shopItem, account.InventoryItems.Where(b => b.Typ == shopItem.Typ && b.Typ != null).First(), account);
			}
		}

		public static bool IsBackpackItemBetterThanInventoryItem(Item backpackItem, Item inventoryItem, Account account) {
			if (!account.Settings.UseAlternativeIventoryChecking) {
				return IsBackpackItemBetterThanInventoryItemJens(backpackItem, inventoryItem, account.Class);
			} else {
				return IsBackpackItemBetterThanInventoryItemIngo(backpackItem, inventoryItem, account);
			}
		}

		private static bool IsBackpackItemBetterThanInventoryItemIngo(Item backpackItem, Item inventoryItem, Account account) {
			//backpack
			int bpStr = backpackItem.AttributeValue1 > 0 && backpackItem.AttributeType1 == AttributeTypes.Strength || backpackItem.AttributeType1 == AttributeTypes.All ? backpackItem.AttributeValue1 : 0;
			bpStr += backpackItem.AttributeValue2 > 0 && backpackItem.AttributeType2 == AttributeTypes.Strength || backpackItem.AttributeType2 == AttributeTypes.All ? backpackItem.AttributeValue2 : 0;
			bpStr += backpackItem.AttributeValue3 > 0 && backpackItem.AttributeType3 == AttributeTypes.Strength || backpackItem.AttributeType3 == AttributeTypes.All ? backpackItem.AttributeValue3 : 0;
						
			int bpDex = backpackItem.AttributeValue1 > 0 && backpackItem.AttributeType1 == AttributeTypes.Dexterity || backpackItem.AttributeType1 == AttributeTypes.All ? backpackItem.AttributeValue1 : 0;
			bpDex += backpackItem.AttributeValue2 > 0 && backpackItem.AttributeType2 == AttributeTypes.Dexterity || backpackItem.AttributeType2 == AttributeTypes.All ? backpackItem.AttributeValue2 : 0;
			bpDex += backpackItem.AttributeValue3 > 0 && backpackItem.AttributeType3 == AttributeTypes.Dexterity || backpackItem.AttributeType3 == AttributeTypes.All ? backpackItem.AttributeValue3 : 0;
			
			int bpInt = backpackItem.AttributeValue1 > 0 && backpackItem.AttributeType1 == AttributeTypes.Intelligence || backpackItem.AttributeType1 == AttributeTypes.All ? backpackItem.AttributeValue1 : 0;
			bpInt += backpackItem.AttributeValue2 > 0 && backpackItem.AttributeType2 == AttributeTypes.Intelligence || backpackItem.AttributeType2 == AttributeTypes.All ? backpackItem.AttributeValue2 : 0;
			bpInt += backpackItem.AttributeValue3 > 0 && backpackItem.AttributeType3 == AttributeTypes.Intelligence || backpackItem.AttributeType3 == AttributeTypes.All ? backpackItem.AttributeValue3 : 0; 
			
			int bpAua = backpackItem.AttributeValue1 > 0 && backpackItem.AttributeType1 == AttributeTypes.Stamina || backpackItem.AttributeType1 == AttributeTypes.All ? backpackItem.AttributeValue1 : 0;
			bpAua += backpackItem.AttributeValue2 > 0 && backpackItem.AttributeType2 == AttributeTypes.Stamina || backpackItem.AttributeType2 == AttributeTypes.All ? backpackItem.AttributeValue2 : 0;
			bpAua += backpackItem.AttributeValue3 > 0 && backpackItem.AttributeType3 == AttributeTypes.Stamina || backpackItem.AttributeType3 == AttributeTypes.All ? backpackItem.AttributeValue3 : 0; 
			
			int bpLuck = backpackItem.AttributeValue1 > 0 && backpackItem.AttributeType1 == AttributeTypes.Luck || backpackItem.AttributeType1 == AttributeTypes.All ? backpackItem.AttributeValue1 : 0;
			bpLuck += backpackItem.AttributeValue2 > 0 && backpackItem.AttributeType2 == AttributeTypes.Luck || backpackItem.AttributeType2 == AttributeTypes.All ? backpackItem.AttributeValue2 : 0;
			bpLuck += backpackItem.AttributeValue3 > 0 && backpackItem.AttributeType3 == AttributeTypes.Luck || backpackItem.AttributeType3 == AttributeTypes.All ? backpackItem.AttributeValue3 : 0; 
			
			int bpArmor = backpackItem.Typ != ItemTypes.Waffe ? backpackItem.DamageMin : 0;
			int bpDMG = backpackItem.Typ == ItemTypes.Waffe ? (backpackItem.DamageMin + backpackItem.DamageMax) / 2 : 0;
			
			//inventory
			int invStr = inventoryItem.AttributeValue1 > 0 && inventoryItem.AttributeType1 == AttributeTypes.Strength || inventoryItem.AttributeType1 == AttributeTypes.All ? inventoryItem.AttributeValue1 : 0;
			invStr += inventoryItem.AttributeValue2 > 0 && inventoryItem.AttributeType2 == AttributeTypes.Strength || inventoryItem.AttributeType2 == AttributeTypes.All ? inventoryItem.AttributeValue2 : 0;
			invStr += inventoryItem.AttributeValue3 > 0 && inventoryItem.AttributeType3 == AttributeTypes.Strength || inventoryItem.AttributeType3 == AttributeTypes.All ? inventoryItem.AttributeValue3 : 0;

			int invDex = inventoryItem.AttributeValue1 > 0 && inventoryItem.AttributeType1 == AttributeTypes.Dexterity || inventoryItem.AttributeType1 == AttributeTypes.All ? inventoryItem.AttributeValue1 : 0;
			invDex += inventoryItem.AttributeValue2 > 0 && inventoryItem.AttributeType2 == AttributeTypes.Dexterity || inventoryItem.AttributeType2 == AttributeTypes.All ? inventoryItem.AttributeValue2 : 0;
			invDex += inventoryItem.AttributeValue3 > 0 && inventoryItem.AttributeType3 == AttributeTypes.Dexterity || inventoryItem.AttributeType3 == AttributeTypes.All ? inventoryItem.AttributeValue3 : 0;

			int invInt = inventoryItem.AttributeValue1 > 0 && inventoryItem.AttributeType1 == AttributeTypes.Intelligence || inventoryItem.AttributeType1 == AttributeTypes.All ? inventoryItem.AttributeValue1 : 0;
			invInt += inventoryItem.AttributeValue2 > 0 && inventoryItem.AttributeType2 == AttributeTypes.Intelligence || inventoryItem.AttributeType2 == AttributeTypes.All ? inventoryItem.AttributeValue2 : 0;
			invInt += inventoryItem.AttributeValue3 > 0 && inventoryItem.AttributeType3 == AttributeTypes.Intelligence || inventoryItem.AttributeType3 == AttributeTypes.All ? inventoryItem.AttributeValue3 : 0;

			int invAua = inventoryItem.AttributeValue1 > 0 && inventoryItem.AttributeType1 == AttributeTypes.Stamina || inventoryItem.AttributeType1 == AttributeTypes.All ? inventoryItem.AttributeValue1 : 0;
			invAua += inventoryItem.AttributeValue2 > 0 && inventoryItem.AttributeType2 == AttributeTypes.Stamina || inventoryItem.AttributeType2 == AttributeTypes.All ? inventoryItem.AttributeValue2 : 0;
			invAua += inventoryItem.AttributeValue3 > 0 && inventoryItem.AttributeType3 == AttributeTypes.Stamina || inventoryItem.AttributeType3 == AttributeTypes.All ? inventoryItem.AttributeValue3 : 0;

			int invLuck = inventoryItem.AttributeValue1 > 0 && inventoryItem.AttributeType1 == AttributeTypes.Luck || inventoryItem.AttributeType1 == AttributeTypes.All ? inventoryItem.AttributeValue1 : 0;
			invLuck += inventoryItem.AttributeValue2 > 0 && inventoryItem.AttributeType2 == AttributeTypes.Luck || inventoryItem.AttributeType2 == AttributeTypes.All ? inventoryItem.AttributeValue2 : 0;
			invLuck += inventoryItem.AttributeValue3 > 0 && inventoryItem.AttributeType3 == AttributeTypes.Luck || inventoryItem.AttributeType3 == AttributeTypes.All ? inventoryItem.AttributeValue3 : 0;

			int invArmor = inventoryItem.Typ != ItemTypes.Waffe ? inventoryItem.DamageMin : 0;
			int invDMG = inventoryItem.Typ == ItemTypes.Waffe ? (inventoryItem.DamageMin + inventoryItem.DamageMax) / 2 : 0;

			float bpSummary = 0;
			float invSummary = 0;
			float armorFactor = 0.2f;
			float dmgFactor = 0.2f;

			bpSummary = bpStr * account.Settings.StatStrFactor + bpDex * account.Settings.StatDexFactor + bpInt * account.Settings.StatIntFactor + bpAua * account.Settings.StatAusFactor + bpLuck * account.Settings.StatLuckFactor + bpArmor * armorFactor + bpDMG * dmgFactor;
			invSummary = invStr * account.Settings.StatStrFactor + invDex * account.Settings.StatDexFactor + invInt * account.Settings.StatIntFactor + invAua * account.Settings.StatAusFactor + invLuck * account.Settings.StatLuckFactor + invArmor * armorFactor + invDMG * dmgFactor;

			return (bpSummary > invSummary);
		}

		private static bool IsBackpackItemBetterThanInventoryItemJens(Item backpackItem, Item inventoryItem, ClassTypes charClass) {

			bool bpIsTripleEpic = backpackItem.IsEpic && (backpackItem.AttributeType1 == AttributeTypes.Intelligence || backpackItem.AttributeType1 == AttributeTypes.Strength || backpackItem.AttributeType1 == AttributeTypes.Dexterity) ? true : false;
			bool invIsTripleEpic = inventoryItem.IsEpic && (backpackItem.AttributeType1 == AttributeTypes.Intelligence || inventoryItem.AttributeType1 == AttributeTypes.Strength || inventoryItem.AttributeType1 == AttributeTypes.Dexterity) ? true : false;

			int bpStr = bpIsTripleEpic && charClass == ClassTypes.Warrior ? backpackItem.AttributeValue1 : backpackItem.AttributeType1 == AttributeTypes.All ? backpackItem.AttributeValue1 : backpackItem.AttributeType1 == AttributeTypes.Strength ? backpackItem.AttributeValue1 : backpackItem.AttributeType2 == AttributeTypes.Strength ? backpackItem.AttributeValue2 : backpackItem.AttributeType3 == AttributeTypes.Strength ? backpackItem.AttributeValue3 : 0;
			int bpDex = bpIsTripleEpic && charClass == ClassTypes.Scout ? backpackItem.AttributeValue1 : backpackItem.AttributeType1 == AttributeTypes.All ? backpackItem.AttributeValue1 : backpackItem.AttributeType1 == AttributeTypes.Dexterity ? backpackItem.AttributeValue1 : backpackItem.AttributeType2 == AttributeTypes.Dexterity ? backpackItem.AttributeValue2 : backpackItem.AttributeType3 == AttributeTypes.Dexterity ? backpackItem.AttributeValue3 : 0;
			int bpInt = bpIsTripleEpic && charClass == ClassTypes.Mage ? backpackItem.AttributeValue1 : backpackItem.AttributeType1 == AttributeTypes.All ? backpackItem.AttributeValue1 : backpackItem.AttributeType1 == AttributeTypes.Intelligence ? backpackItem.AttributeValue1 : backpackItem.AttributeType2 == AttributeTypes.Intelligence ? backpackItem.AttributeValue2 : backpackItem.AttributeType3 == AttributeTypes.Intelligence ? backpackItem.AttributeValue3 : 0;
			int bpAus = bpIsTripleEpic ? backpackItem.AttributeValue1 : backpackItem.AttributeType1 == AttributeTypes.All ? backpackItem.AttributeValue1 : backpackItem.AttributeType1 == AttributeTypes.Stamina ? backpackItem.AttributeValue1 : backpackItem.AttributeType2 == AttributeTypes.Stamina ? backpackItem.AttributeValue2 : backpackItem.AttributeType3 == AttributeTypes.Stamina ? backpackItem.AttributeValue3 : 0;
			int bpLuck = bpIsTripleEpic ? backpackItem.AttributeValue1 : backpackItem.AttributeType1 == AttributeTypes.All ? backpackItem.AttributeValue1 : backpackItem.AttributeType1 == AttributeTypes.Luck ? backpackItem.AttributeValue1 : backpackItem.AttributeType2 == AttributeTypes.Luck ? backpackItem.AttributeValue2 : backpackItem.AttributeType3 == AttributeTypes.Luck ? backpackItem.AttributeValue3 : 0;
			int bpArmor = backpackItem.Typ != ItemTypes.Waffe ? backpackItem.DamageMin : 0;
			int bpDMG = backpackItem.Typ == ItemTypes.Waffe ? (backpackItem.DamageMin + backpackItem.DamageMax) / 2 : 0;

			int invStr = invIsTripleEpic && charClass == ClassTypes.Warrior ? inventoryItem.AttributeValue1 : inventoryItem.AttributeType1 == AttributeTypes.All ? backpackItem.AttributeValue1 : inventoryItem.AttributeType1 == AttributeTypes.Strength ? inventoryItem.AttributeValue1 : inventoryItem.AttributeType2 == AttributeTypes.Strength ? inventoryItem.AttributeValue2 : inventoryItem.AttributeType3 == AttributeTypes.Strength ? inventoryItem.AttributeValue3 : 0;
			int invDex = invIsTripleEpic && charClass == ClassTypes.Scout ? inventoryItem.AttributeValue1 : inventoryItem.AttributeType1 == AttributeTypes.All ? backpackItem.AttributeValue1 : inventoryItem.AttributeType1 == AttributeTypes.Dexterity ? inventoryItem.AttributeValue1 : inventoryItem.AttributeType2 == AttributeTypes.Dexterity ? inventoryItem.AttributeValue2 : inventoryItem.AttributeType3 == AttributeTypes.Dexterity ? inventoryItem.AttributeValue3 : 0;
			int invInt = invIsTripleEpic && charClass == ClassTypes.Mage ? inventoryItem.AttributeValue1 : inventoryItem.AttributeType1 == AttributeTypes.All ? backpackItem.AttributeValue1 : inventoryItem.AttributeType1 == AttributeTypes.Intelligence ? inventoryItem.AttributeValue1 : inventoryItem.AttributeType2 == AttributeTypes.Intelligence ? inventoryItem.AttributeValue2 : inventoryItem.AttributeType3 == AttributeTypes.Intelligence ? inventoryItem.AttributeValue3 : 0;
			int invAus = invIsTripleEpic ? inventoryItem.AttributeValue1 : inventoryItem.AttributeType1 == AttributeTypes.All ? backpackItem.AttributeValue1 : inventoryItem.AttributeType1 == AttributeTypes.Stamina ? inventoryItem.AttributeValue1 : inventoryItem.AttributeType2 == AttributeTypes.Stamina ? inventoryItem.AttributeValue2 : inventoryItem.AttributeType3 == AttributeTypes.Stamina ? inventoryItem.AttributeValue3 : 0;
			int invLuck = invIsTripleEpic ? inventoryItem.AttributeValue1 : inventoryItem.AttributeType1 == AttributeTypes.All ? backpackItem.AttributeValue1 : inventoryItem.AttributeType1 == AttributeTypes.Luck ? inventoryItem.AttributeValue1 : inventoryItem.AttributeType2 == AttributeTypes.Luck ? inventoryItem.AttributeValue2 : inventoryItem.AttributeType3 == AttributeTypes.Luck ? inventoryItem.AttributeValue3 : 0;
			int invArmor = inventoryItem.Typ != ItemTypes.Waffe ? inventoryItem.DamageMin : 0;
			int invDMG = inventoryItem.Typ == ItemTypes.Waffe ? (inventoryItem.DamageMin + inventoryItem.DamageMax) / 2 : 0;

			int mainMultiplier = 10;
			int ausMultiplier = 8;
			int luckMultiplier = 6;
			int dmgMultiplier = 4;
			int armorMultiplier = 2;

			int bpSummary = 0;
			int invSummary = 0;

			switch (charClass) {
				case ClassTypes.Mage:
					bpSummary = (bpInt * mainMultiplier) + (bpAus * ausMultiplier) + (bpLuck * luckMultiplier) + (bpDMG * dmgMultiplier) + (bpArmor * armorMultiplier);
					invSummary = (invInt * mainMultiplier) + (invAus * ausMultiplier) + (invLuck * luckMultiplier) + (invDMG * dmgMultiplier) + (invArmor * armorMultiplier);
					break;
				case ClassTypes.Scout:
					bpSummary = (bpDex * mainMultiplier) + (bpAus * ausMultiplier) + (bpLuck * luckMultiplier) + (bpDMG * dmgMultiplier) + (bpArmor * armorMultiplier);
					invSummary = (invDex * mainMultiplier) + (invAus * ausMultiplier) + (invLuck * luckMultiplier) + (invDMG * dmgMultiplier) + (invArmor * armorMultiplier);
					break;
				case ClassTypes.Warrior:
					bpSummary = (bpStr * mainMultiplier) + (bpAus * ausMultiplier) + (bpLuck * luckMultiplier) + (bpDMG * dmgMultiplier) + (bpArmor * armorMultiplier);
					invSummary = (invStr * mainMultiplier) + (invAus * ausMultiplier) + (invLuck * luckMultiplier) + (invDMG * dmgMultiplier) + (invArmor * armorMultiplier);
					break;
				default:
					break;
			}

			return (bpSummary > invSummary);
		}
	}
}
