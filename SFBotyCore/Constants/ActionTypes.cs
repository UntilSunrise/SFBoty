using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SFBotyCore.Constants {
	public static class ActionTypes {
		public static string LoginToSF = "002";
		public static string LogOut = "535";

		public static string TakeQuest1 = "5101%3B0";
		public static string TakeQuest2 = "5102%3B0";
		public static string TakeQuest3 = "5103%3B0";
		public static string QuestCancel = "511";

		public static string JoinTarvern = "010";
		public static string JoinArena = "011";
		public static string JoinGuild = "006";
		public static string JoinCharacter = "004";//Aufrufen des eigenen Chars
		public static string JoinDungeon = "008";
		public static string JoinWeaponshop = "013";
		public static string JoinMagicshop = "014";
		/// <summary>
		/// Es kann auch noch die Obergrenze des Rangbereiches angegeben werden
		/// Bsp: 007;1 Zeigt die Ränge 1-15 an.
		/// </summary>
		public static string JoinHallOfFame = "007;";

		/// <summary>
		/// Anzahl muss noch angehangen werden
		/// </summary>
		public static string GuildDonateGold = "1111%3B";
		/// <summary>
		/// Anzahl muss noch angehangen werden
		/// </summary>
		public static string GuildDonateMushroom = "1112%3B";
		public static string GuildJoinAttack = "112";
		public static string GuildJoinDefence = "113";

		/// <summary>
		/// Es muss noch der Nick des Spielers angehangen werden.
		/// Eventuelle Leerzeichen in Namen müssen nachträglich entsprechend ersetzt werden.
		/// </summary>
		public static string AttackEnemy = "512";

		public static string GetChatHistory_NotSure = "5173"; //getChatHistory?

		public static string JoinTownWatch = "012";
		public static string DoTownWatch1Hour = "5021";
		public static string DoTownWatch10Hour = "50210";
		/// <summary>
		/// Arbeitszeit in Stunden muss noch angehangen werden
		/// </summary>
		public static string DoTownWatchHour = "502";

		public static string JoinToilet = "303";
		public static string FlushToilet = "302";
		public static string ResponseToiletFull = "306";
		public static string ResponseToiletLocked = "304";
		/// <summary>
		/// Achtung die Item Rucksackslot Nummer muss noch angehangen werden (1-5)
		/// und die entsprechende Action ";0;0" verkauft ein Item und ";10;0" packt es in das WC. 
		/// Bsp.: 50425;0;0 verkauft das Item in Slot 5
		/// </summary>
		public static string ItemAction = "5042;";

		/// <summary>
		/// Achtung DungeonID muss noch selbstständigangehangen werden
		/// </summary>
		public static string DoDungeon = "519"; // ID 1-13 wird hierbei dann angehangen

		public static string BuyStatStr = "0211";
		public static string BuyStatDex = "0212";
		public static string BuyStatInt = "0213";
		public static string BuyStatAus = "0214";
		public static string BuyStatLuck = "0215";
		public static string BuyBeer = "518";
	}
}
