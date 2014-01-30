using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SFBotyCore.Constants {
	public static class ResponseStringPositions {
		public static int ShakesFirstItemPosition = 288;
		public static int FidgetFirstItemPosition = 361;
		public static int ShopSize = 6;
		
		public static int InventoryFirstItemPosition = 48;
		public static int InventorySize = 10;

		public static int BackpackFirstItemPosition = 168;
		public static int BackpackSize = 5;

		public static int ItemSize = 12;

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
        public static int HoFRang = 0;
        public static int HoFCharacternick = 1;
        public static int HoFGildennick = 2;
        public static int HoFLevel = 3;
        public static int HoFHonor = 4;
        #endregion
    }
}