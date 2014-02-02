using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SFBotyCore.Constants {
	public static class ResponseTypes {
		public static int SessionID = 511;

		public static int Silver = 13;
		public static int Mushrooms = 14;
		public static int ALU = 456;
		public static int Level = 7;
		public static int Rang = 11;
		public static int Honor = 10;

		public static int ShakesFirstItemPosition = 288;
		public static int FidgetFirstItemPosition = 361;
		public static int ShopSize = 6;

		public static int InventoryFirstItemPosition = 48;
		public static int InventorySize = 10;

		public static int BackpackFirstItemPosition = 168;
		public static int BackpackSize = 5;

		public static int ItemSize = 12;

		public static int NextFreeDungeonTimestamp = 459;
		public static int NextFreeDuellTimestamp = 460;

		public static int ActionDateTimestamp = 47;
		public static int ActionStatus = 45;

		#region CharacterAttributes
		public static int str = 30;
		public static int ges = 31;
		public static int inte = 32;
		public static int aus = 33;
		public static int luck = 34;
		public static int strAddon = 35;
		public static int gesAddon = 36;
		public static int inteAddon = 37;
		public static int ausAddon = 38;
		public static int luckAddon = 39;
		public static int strBuyed = 40;
		public static int gesBuyed = 41;
		public static int inteBuyed = 42;
		public static int ausBuyed = 43;
		public static int luckBuyed = 44;
		#endregion

		#region Itempositions
		public static int ItemTyp = 0;
		public static int ItemPicture = 1;
		public static int ItemDamageMin = 2;
		public static int ItemDamageMax = 3;
		public static int ItemAttributeType1 = 4;
		public static int ItemAttributeType2 = 5;
		public static int ItemAttributeType3 = 6;
		public static int ItemAttributeValue1 = 7;
		public static int ItemAttributeValue2 = 8;
		public static int ItemAttributeValue3 = 9;
		public static int ItemGoldValue = 10;
		public static int ItemMushroomValue = 11;
		public static int ItemSocket = 600;
		public static int ItemEnchantment = 601;
		public static int ItemEnchantmentPower = 602;
		public static int ItemSocketPower = 603;
		#endregion

		#region HallOfFamepositions
		public static int HoFOffset = 5;

		public static int HoFRang = 0;
		public static int HoFCharacternick = 1;
		public static int HoFGuildnick = 2;
		public static int HoFLevel = 3;
		public static int HoFHonor = 4;
		#endregion

		#region Arenapositions
		public static int ArenaEnemyNick = 0;
		public static int ArenaEnemyLevel = 1;
		public static int ArenaGuildNick = 2;
		public static int ArenaNextFreeDuellTimestamp = 3;
		#endregion

		#region GuildTypes
		public static string PlayerHasNoGuild = "017";
		#endregion
	}
}