using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using SFBotyCore.Constants;

namespace SFBotyCore.Mechanic.Account {
	public enum AutoQuestMode {
		BestXP,
		BestGold,
		BestTime,
		HighstMountPerSecond
	}

	public class AccountSettings {
		public string Username { get; set; }
		public string PasswordHash { get; set; }
		public string Server { get; set; }
		
		private string _sessionID = null;
		[XmlIgnoreAttribute]
		public string SessionID { get { return _sessionID == null ? EmpytSessionID : _sessionID; } set { _sessionID = value; } }
		private static string EmpytSessionID = "00000000000000000000000000000000";

		public bool PerformQuesten { get; set; }
		public bool PerformBuyStats { get; set; }
		public bool PerformStadtwache { get; set; }
		public bool PerformDungeons { get; set; }
		public bool PerformToilet { get; set; }
		public bool PerformArena { get; set; }
		public bool PerformGuild { get; set; }

		public bool SellToiletItemIfNotEpic { get; set; }

		public int MaxTriesToFindEnemy { get; set; }
		public bool AttackSuggestedEnemy { get; set; }
		public bool AttackEnemyBetweenRange { get; set; } //Ist eine ungenutzte Variable
		/// <summary>
		/// Oberegrenze des Ranges zum Angriff.
		/// z.B. 5 = Rang + 5;
		/// </summary>
		public int UpperRangeLimit { get; set; }
		/// <summary>
		/// Untere Ranggrenze zum Angriff.
		/// z.B. 100 = Rang - 100;
		/// </summary>
		public int LowerRangeLimit { get; set; }
		public int LevelDifference { get; set; }
		public string IgnoreGuilds { get; set; }
		public string IgnorePlayers { get; set; }

		public float StatStrFactor { get; set; }
		public float StatDexFactor { get; set; }
		public float StatIntFactor { get; set; }
		public float StatAusFactor { get; set; }
		public float StatLuckFactor { get; set; }

		public bool BuyBeer { get; set; }
		public int MaxBeerToBuy { get; set; }

		public bool DonateGold { get; set; }
		public float FactorToDonate { get; set; }
		public bool GetChatHistory { get; set; }

		public int TownWatchMinHourForShortWork { get; set; }
		public int TownWatchMaxHourForShortWork { get; set; }

		public bool SaveMoney { get; set; }
		public float SaveMoneyFactor { get; set; }

		public MountTypes MountToBuy { get; set; }
		public bool BuyMount { get; set; }

		public bool BuyItemsInMagicShop { get; set; }
		public bool UseMushroomsForBuying { get; set; }
		/// <summary>
		/// false = Jens Variante wird für den Item-Vergleich verwendet;
		/// </summary>
		public bool UseAlternativeIventoryChecking { get; set; }
		public bool IgnoreErrors { get; set; }

		//times are in Sekunds
		#region Times
		public float minShortTime { get; set; }
		public float maxShortTime { get; set; }
		public float minLongTime { get; set; }
		public float maxLongTime { get; set; }
		public float guildVisitInterval { get; set; }
		public float MinSendRequestInterval { get; set; }
		#endregion

		public bool HasLogin { get { return SessionID != EmpytSessionID; } }
		public AutoQuestMode QuestMode { get; set; }

		#region MailSettings
		public string MailFrom { get; set; }
		public string MailTo { get; set; }
		public int MailPort { get; set; }
		public string MailSmtp { get; set; }
		public string MailUserNamer { get; set; }
		public string MailCryptPasswort { get; set; }
		public bool SendErrorMail { get; set; }
		#endregion

		public AccountSettings() {
			//only for Serialization
		}

		public AccountSettings(string username, string passwortHash, string server) {
			this.Username = username;
			this.PasswordHash = passwortHash;
			this.Server = server;
			this.SessionID = EmpytSessionID;

			this.PerformQuesten = true;
			this.PerformBuyStats = true;
			this.PerformStadtwache = true;
			this.PerformDungeons = true;

			this.PerformToilet = true;
			this.SellToiletItemIfNotEpic = true;

			this.PerformArena = true;
			this.MaxTriesToFindEnemy = 10;
			this.AttackSuggestedEnemy = true;
			this.AttackEnemyBetweenRange = false;
			this.UpperRangeLimit = 10;
			this.LowerRangeLimit = 10;
			this.LevelDifference = 5;
			this.IgnoreGuilds = "AssertFail";
			this.IgnorePlayers = "Tendil/Myrkai";

			this.PerformGuild = true;
			this.guildVisitInterval = 60 * 90; //1.5h
			this.DonateGold = true;
			this.FactorToDonate = 0.1f;
			this.GetChatHistory = false;

			this.StatStrFactor = 0.45f;
			this.StatDexFactor = 0.05f;
			this.StatIntFactor = 0.05f;
			this.StatAusFactor = 0.35f;
			this.StatLuckFactor = 0.10f;

			this.BuyBeer = false;
			this.MaxBeerToBuy = 10;

			this.TownWatchMinHourForShortWork = 9;
			this.TownWatchMaxHourForShortWork = 21;

			this.MinSendRequestInterval = 1f;

			this.QuestMode = AutoQuestMode.BestXP;

			this.SaveMoney = false;
			this.SaveMoneyFactor = 2.6f;

			this.MountToBuy = MountTypes.None;
			this.BuyMount = true;

			this.BuyItemsInMagicShop = false;
			this.UseAlternativeIventoryChecking = false;
			this.UseMushroomsForBuying = false;

			this.SendErrorMail = false;
			this.MailFrom = "";
			this.MailPort = 0;
			this.MailSmtp = "";
			this.MailTo = "";
			this.MailUserNamer = "";
			this.MailCryptPasswort = "";

			this.IgnoreErrors = false;
		}

		public void ResetSessionID() {
			this.SessionID = EmpytSessionID;
		}

		public void SetSettings(AccountSettings tmp) {
			this.AttackEnemyBetweenRange = tmp.AttackEnemyBetweenRange;
			this.AttackSuggestedEnemy = tmp.AttackSuggestedEnemy;
			this.BuyBeer = tmp.BuyBeer;
			this.DonateGold = tmp.DonateGold;
			this.FactorToDonate = tmp.FactorToDonate;
			this.guildVisitInterval = tmp.guildVisitInterval;
			this.IgnoreGuilds = tmp.IgnoreGuilds;
			this.IgnorePlayers = tmp.IgnorePlayers;
			this.LevelDifference = tmp.LevelDifference;
			this.LowerRangeLimit = tmp.LowerRangeLimit;
			this.MaxBeerToBuy = tmp.MaxBeerToBuy;
			this.maxShortTime = tmp.maxShortTime;
			this.maxLongTime = tmp.maxLongTime;
			this.MaxTriesToFindEnemy = tmp.MaxTriesToFindEnemy;
			this.MinSendRequestInterval = tmp.MinSendRequestInterval;
			this.minShortTime = tmp.minShortTime;
			this.minLongTime = tmp.minLongTime;
			this.PasswordHash = tmp.PasswordHash;
			this.PerformArena = tmp.PerformArena;
			this.PerformBuyStats = tmp.PerformBuyStats;
			this.PerformDungeons = tmp.PerformDungeons;
			this.PerformGuild = tmp.PerformGuild;
			this.PerformQuesten = tmp.PerformQuesten;
			this.PerformStadtwache = tmp.PerformStadtwache;
			this.PerformToilet = tmp.PerformToilet;
			this.QuestMode = tmp.QuestMode;
			this.SellToiletItemIfNotEpic = tmp.SellToiletItemIfNotEpic;
			this.Server = tmp.Server;
			this.StatAusFactor = tmp.StatAusFactor;
			this.StatDexFactor = tmp.StatDexFactor;
			this.StatIntFactor = tmp.StatIntFactor;
			this.StatLuckFactor = tmp.StatLuckFactor;
			this.StatStrFactor = tmp.StatStrFactor;
			this.TownWatchMaxHourForShortWork = tmp.TownWatchMaxHourForShortWork;
			this.TownWatchMinHourForShortWork = tmp.TownWatchMinHourForShortWork;
			this.UpperRangeLimit = tmp.UpperRangeLimit;
			this.Username = tmp.Username;
			this.SaveMoney = tmp.SaveMoney;
			this.SaveMoneyFactor = tmp.SaveMoneyFactor;
			this.MountToBuy = tmp.MountToBuy;
			this.BuyMount = tmp.BuyMount;
			this.BuyItemsInMagicShop = tmp.BuyItemsInMagicShop;
			this.UseAlternativeIventoryChecking = tmp.UseAlternativeIventoryChecking;
			this.UseMushroomsForBuying = tmp.UseMushroomsForBuying;
			this.SendErrorMail = tmp.SendErrorMail;
			this.MailCryptPasswort = tmp.MailCryptPasswort;
			this.MailFrom = tmp.MailFrom;
			this.MailPort = tmp.MailPort;
			this.MailSmtp = tmp.MailSmtp;
			this.MailTo = tmp.MailTo;
			this.MailUserNamer = tmp.MailUserNamer;
			this.GetChatHistory = tmp.GetChatHistory;
			this.IgnoreErrors = tmp.IgnoreErrors;
		}

		public AccountSettings Clone() {
			AccountSettings tmp = new AccountSettings();
			tmp.AttackEnemyBetweenRange = this.AttackEnemyBetweenRange;
			tmp.AttackSuggestedEnemy = this.AttackSuggestedEnemy;
			tmp.BuyBeer = this.BuyBeer;
			tmp.DonateGold = this.DonateGold;
			tmp.FactorToDonate = this.FactorToDonate;
			tmp.guildVisitInterval = this.guildVisitInterval;
			tmp.IgnoreGuilds = this.IgnoreGuilds;
			tmp.IgnorePlayers = this.IgnorePlayers;
			tmp.LevelDifference = this.LevelDifference;
			tmp.LowerRangeLimit = this.LowerRangeLimit;
			tmp.MaxBeerToBuy = this.MaxBeerToBuy;
			tmp.maxShortTime = this.maxShortTime;
			tmp.maxLongTime = this.maxLongTime;
			tmp.MaxTriesToFindEnemy = this.MaxTriesToFindEnemy;
			tmp.MinSendRequestInterval = this.MinSendRequestInterval;
			tmp.minShortTime = this.minShortTime;
			tmp.minLongTime = this.minLongTime;
			tmp.PasswordHash = this.PasswordHash;
			tmp.PerformArena = this.PerformArena;
			tmp.PerformBuyStats = this.PerformBuyStats;
			tmp.PerformDungeons = this.PerformDungeons;
			tmp.PerformGuild = this.PerformGuild;
			tmp.PerformQuesten = this.PerformQuesten;
			tmp.PerformStadtwache = this.PerformStadtwache;
			tmp.PerformToilet = this.PerformToilet;
			tmp.QuestMode = this.QuestMode;
			tmp.SellToiletItemIfNotEpic = this.SellToiletItemIfNotEpic;
			tmp.Server = this.Server;
			tmp.StatAusFactor = this.StatAusFactor;
			tmp.StatDexFactor = this.StatDexFactor;
			tmp.StatIntFactor = this.StatIntFactor;
			tmp.StatLuckFactor = this.StatLuckFactor;
			tmp.StatStrFactor = this.StatStrFactor;
			tmp.TownWatchMaxHourForShortWork = this.TownWatchMaxHourForShortWork;
			tmp.TownWatchMinHourForShortWork = this.TownWatchMinHourForShortWork;
			tmp.UpperRangeLimit = this.UpperRangeLimit;
			tmp.Username = this.Username;
			tmp.SaveMoney = this.SaveMoney;
			tmp.SaveMoneyFactor = this.SaveMoneyFactor;
			tmp.MountToBuy = this.MountToBuy;
			tmp.BuyMount = this.BuyMount;
			tmp.BuyItemsInMagicShop = this.BuyItemsInMagicShop;
			tmp.UseAlternativeIventoryChecking = this.UseAlternativeIventoryChecking;
			tmp.UseMushroomsForBuying = this.UseMushroomsForBuying;
			tmp.SendErrorMail = this.SendErrorMail;
			tmp.MailCryptPasswort = this.MailCryptPasswort;
			tmp.MailFrom = this.MailFrom;
			tmp.MailPort = this.MailPort;
			tmp.MailSmtp = this.MailSmtp;
			tmp.MailTo = this.MailTo;
			tmp.MailUserNamer = this.MailUserNamer;
			tmp.GetChatHistory = this.GetChatHistory;
			tmp.IgnoreErrors = this.IgnoreErrors;

			Assert.Asserts.AreNotSame(tmp, this, "Mist");

			return tmp;
		}

	}
}
