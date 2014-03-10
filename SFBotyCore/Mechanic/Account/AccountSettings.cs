﻿using System;
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

		public int TownWatchMinHourForShortWork { get; set; }
		public int TownWatchMaxHourForShortWork { get; set; }

		public bool SaveMoney { get; set; }
		public float SaveMoneyFactor { get; set; }

		public MountTypes MountToBuy { get; set; }
		public bool BuyMount { get; set; }

		//times are in Sekunds
		#region Times
		public float minTimeToJoinTarvern { get; set; }
		public float maxTimeToJoinTarvern { get; set; }

		public float minTimeToTakeQuest { get; set; }
		public float maxTimeToTakeQuest { get; set; }

		public float minTimeToEndAQuest { get; set; }
		public float maxTimeToEndAQuest { get; set; }

		public float minTimeToJoinStadtwache { get; set; }
		public float maxTimeToJoinStadtwache { get; set; }

		public float minTimeToDoStadtwache { get; set; }
		public float maxTimeToDoStadtwache { get; set; }

		public float minTimeToJoinChar { get; set; }
		public float maxTimeToJoinChar { get; set; }

		public float minTimeToJoinHoF { get; set; }
		public float maxTimeToJoinHoF { get; set; }

		public float minTimeToJoinEnemy { get; set; }
		public float maxTimeToJoinEnemy { get; set; }

		public float minTimeToLogOut { get; set; }
		public float maxTimeToLogOut { get; set; }

		public float minTimeToBuyStat { get; set; }
		public float maxTimeToBuyStat { get; set; }

		public float minTimeToBuyBeer { get; set; }
		public float maxTimeToBuyBeer { get; set; }

		public float minTimeToJoinDungeon { get; set; }
		public float maxTimeToJoinDungeon { get; set; }

		public float minTimeToJoinShops { get; set; }
		public float maxTimeToJoinShops { get; set; }

		public float minTimeToJoinToilet { get; set; }
		public float maxTimeToJoinToilet { get; set; }

		public float minTimeToDoToilet { get; set; }
		public float maxTimeToDoToilet { get; set; }

		public float minTimeToSellItem { get; set; }
		public float maxTimeToSellItem { get; set; }

		public float minTimeToJoinGuild { get; set; }
		public float maxTimeToJoinGuild { get; set; }

		public float guildVisitInterval { get; set; }
		public float minTimeToDonate { get; set; }
		public float maxTimeToDonate { get; set; }

		public float minTimeToUseItem { get; set; }
		public float maxTimeToUseItem { get; set; }

		public float MinSendRequestInterval { get; set; }
		#endregion

		public float minShortTime { 
			get {
				return minTimeToDonate == null || minTimeToDonate == 0 ? 1f : minTimeToDonate;
			}
			set {
				minTimeToJoinTarvern = value;
				minTimeToEndAQuest = value;
				minTimeToJoinStadtwache = value;
				minTimeToJoinChar = value;
				minTimeToJoinHoF = value;
				minTimeToJoinEnemy = value;
				minTimeToLogOut = value;
				minTimeToBuyStat = value;
				minTimeToBuyBeer = value;
				minTimeToJoinDungeon = value;
				minTimeToJoinShops = value;		
				minTimeToJoinToilet = value;		
				minTimeToDoToilet = value;
				minTimeToSellItem = value;
				minTimeToJoinGuild = value;
				minTimeToDonate = value;
				minTimeToUseItem = value;
			}
		}
		public float maxShortTime {
			get {
				return maxTimeToDonate == null || maxTimeToDonate == 0 ? 3f : maxTimeToDonate;
			}
			set {
				maxTimeToJoinTarvern = value;
				maxTimeToEndAQuest = value;
				maxTimeToJoinStadtwache = value;
				maxTimeToJoinChar = value;
				maxTimeToJoinHoF = value;
				maxTimeToJoinEnemy = value;
				maxTimeToLogOut = value;
				maxTimeToBuyStat = value;
				maxTimeToBuyBeer = value;
				maxTimeToJoinDungeon = value;
				maxTimeToJoinShops = value;		
				maxTimeToJoinToilet = value;		
				maxTimeToDoToilet = value;
				maxTimeToSellItem = value;
				maxTimeToJoinGuild = value;
				maxTimeToDonate = value;
				maxTimeToUseItem = value;
			}
		}
		public float minLongTime {
			get {
				return minTimeToTakeQuest == null || minTimeToTakeQuest == 0 ? 15f : minTimeToTakeQuest;
			}
			set {
				minTimeToTakeQuest = value;
				minTimeToDoStadtwache = value;
			}
		}
		public float maxLongTime {
			get {
				return maxTimeToTakeQuest == null || maxTimeToTakeQuest == 0 ? 45f : maxTimeToTakeQuest;
			}
			set {
				maxTimeToTakeQuest = value;
				maxTimeToDoStadtwache = value;
			}
		}

		public bool HasLogin { get { return SessionID != EmpytSessionID; } }
		public AutoQuestMode QuestMode { get; set; }

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

			this.StatStrFactor = 0.45f;
			this.StatDexFactor = 0.05f;
			this.StatIntFactor = 0.05f;
			this.StatAusFactor = 0.35f;
			this.StatLuckFactor = 0.10f;

			this.BuyBeer = false;
			this.MaxBeerToBuy = 10;

			this.TownWatchMinHourForShortWork = 9;
			this.TownWatchMaxHourForShortWork = 21;

			this.minTimeToJoinTarvern = 2f;
			this.maxTimeToJoinTarvern = 5f;

			this.minTimeToTakeQuest = 15f;
			this.maxTimeToTakeQuest = 45f;

			this.minTimeToEndAQuest = 3f;
			this.maxTimeToEndAQuest = 6F;

			this.minTimeToJoinStadtwache = 2f;
			this.maxTimeToJoinStadtwache = 5f;

			this.minTimeToDoStadtwache = 15f;
			this.maxTimeToDoStadtwache = 45f;

			this.minTimeToJoinChar = 2f;
			this.maxTimeToJoinChar = 5f;

			this.minTimeToJoinHoF = 2f;
			this.maxTimeToJoinHoF = 5f;

			this.minTimeToJoinEnemy = 1f;
			this.maxTimeToJoinEnemy = 2f;

			this.minTimeToLogOut = 2f;
			this.maxTimeToLogOut = 5f;

			this.minTimeToBuyStat = 2f;
			this.maxTimeToBuyStat = 4f;

			this.minTimeToBuyBeer = 2f;
			this.maxTimeToBuyBeer = 4f;

			this.minTimeToJoinDungeon = 3f;
			this.maxTimeToJoinDungeon = 6f;

			this.minTimeToJoinShops = 2f;
			this.maxTimeToJoinShops = 5f;

			this.minTimeToJoinToilet = 3f;
			this.maxTimeToJoinToilet = 5f;

			this.minTimeToDoToilet = 3f;
			this.maxTimeToDoToilet = 5f;

			this.minTimeToSellItem = 1f;
			this.maxTimeToSellItem = 3f;

			this.minTimeToJoinGuild = 3f;
			this.maxTimeToJoinGuild = 5.5f;
			this.minTimeToDonate = 2f;
			this.maxTimeToDonate = 4f;

			this.minTimeToUseItem = 2f;
			this.maxTimeToUseItem = 3f;

			this.MinSendRequestInterval = 1f;

			this.QuestMode = AutoQuestMode.BestXP;

			this.SaveMoney = false;
			this.SaveMoneyFactor = 2.6f;

			this.MountToBuy = MountTypes.None;
			this.BuyMount = true;
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
			this.maxTimeToBuyBeer = tmp.maxTimeToBuyBeer;
			this.maxTimeToBuyStat = tmp.maxTimeToBuyStat;
			this.maxTimeToDonate = tmp.maxTimeToDonate;
			this.maxTimeToDoStadtwache = tmp.maxTimeToDoStadtwache;
			this.maxTimeToDoToilet = tmp.maxTimeToDoToilet;
			this.maxTimeToEndAQuest = tmp.maxTimeToEndAQuest;
			this.maxTimeToJoinChar = tmp.maxTimeToJoinChar;
			this.maxTimeToJoinDungeon = tmp.maxTimeToJoinDungeon;
			this.maxTimeToJoinEnemy = tmp.maxTimeToJoinEnemy;
			this.maxTimeToJoinGuild = tmp.maxTimeToJoinGuild;
			this.maxTimeToJoinHoF = tmp.maxTimeToJoinHoF;
			this.maxTimeToJoinShops = tmp.maxTimeToJoinShops;
			this.maxTimeToJoinStadtwache = tmp.maxTimeToJoinStadtwache;
			this.maxTimeToJoinTarvern = tmp.maxTimeToJoinTarvern;
			this.maxTimeToJoinToilet = tmp.maxTimeToJoinToilet;
			this.maxTimeToLogOut = tmp.maxTimeToLogOut;
			this.maxTimeToSellItem = tmp.maxTimeToSellItem;
			this.maxTimeToTakeQuest = tmp.maxTimeToTakeQuest;
			this.MaxTriesToFindEnemy = tmp.MaxTriesToFindEnemy;
			this.MinSendRequestInterval = tmp.MinSendRequestInterval;
			this.minTimeToBuyBeer = tmp.minTimeToBuyBeer;
			this.minTimeToBuyStat = tmp.minTimeToBuyStat;
			this.minTimeToDonate = tmp.minTimeToDonate;
			this.minTimeToDoStadtwache = tmp.minTimeToDoStadtwache;
			this.minTimeToDoToilet = tmp.minTimeToDoToilet;
			this.minTimeToEndAQuest = tmp.minTimeToEndAQuest;
			this.minTimeToJoinChar = tmp.minTimeToJoinChar;
			this.minTimeToJoinDungeon = tmp.minTimeToJoinDungeon;
			this.minTimeToJoinEnemy = tmp.minTimeToJoinEnemy;
			this.minTimeToJoinGuild = tmp.minTimeToJoinGuild;
			this.minTimeToJoinHoF = tmp.minTimeToJoinHoF;
			this.minTimeToJoinShops = tmp.minTimeToJoinShops;
			this.minTimeToJoinStadtwache = tmp.minTimeToJoinStadtwache;
			this.minTimeToJoinTarvern = tmp.minTimeToJoinTarvern;
			this.minTimeToJoinToilet = tmp.minTimeToJoinToilet;
			this.minTimeToLogOut = tmp.minTimeToLogOut;
			this.minTimeToSellItem = tmp.minTimeToSellItem;
			this.minTimeToTakeQuest = tmp.minTimeToTakeQuest;
			this.minTimeToUseItem = tmp.minTimeToUseItem;
			this.maxTimeToUseItem = tmp.maxTimeToUseItem;
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
			tmp.maxTimeToBuyBeer = this.maxTimeToBuyBeer;
			tmp.maxTimeToBuyStat = this.maxTimeToBuyStat;
			tmp.maxTimeToDonate = this.maxTimeToDonate;
			tmp.maxTimeToDoStadtwache = this.maxTimeToDoStadtwache;
			tmp.maxTimeToDoToilet = this.maxTimeToDoToilet;
			tmp.maxTimeToEndAQuest = this.maxTimeToEndAQuest;
			tmp.maxTimeToJoinChar = this.maxTimeToJoinChar;
			tmp.maxTimeToJoinDungeon = this.maxTimeToJoinDungeon;
			tmp.maxTimeToJoinEnemy = this.maxTimeToJoinEnemy;
			tmp.maxTimeToJoinGuild = this.maxTimeToJoinGuild;
			tmp.maxTimeToJoinHoF = this.maxTimeToJoinHoF;
			tmp.maxTimeToJoinShops = this.maxTimeToJoinShops;
			tmp.maxTimeToJoinStadtwache = this.maxTimeToJoinStadtwache;
			tmp.maxTimeToJoinTarvern = this.maxTimeToJoinTarvern;
			tmp.maxTimeToJoinToilet = this.maxTimeToJoinToilet;
			tmp.maxTimeToLogOut = this.maxTimeToLogOut;
			tmp.maxTimeToSellItem = this.maxTimeToSellItem;
			tmp.maxTimeToTakeQuest = this.maxTimeToTakeQuest;
			tmp.MaxTriesToFindEnemy = this.MaxTriesToFindEnemy;
			tmp.MinSendRequestInterval = this.MinSendRequestInterval;
			tmp.minTimeToBuyBeer = this.minTimeToBuyBeer;
			tmp.minTimeToBuyStat = this.minTimeToBuyStat;
			tmp.minTimeToDonate = this.minTimeToDonate;
			tmp.minTimeToDoStadtwache = this.minTimeToDoStadtwache;
			tmp.minTimeToDoToilet = this.minTimeToDoToilet;
			tmp.minTimeToEndAQuest = this.minTimeToEndAQuest;
			tmp.minTimeToJoinChar = this.minTimeToJoinChar;
			tmp.minTimeToJoinDungeon = this.minTimeToJoinDungeon;
			tmp.minTimeToJoinEnemy = this.minTimeToJoinEnemy;
			tmp.minTimeToJoinGuild = this.minTimeToJoinGuild;
			tmp.minTimeToJoinHoF = this.minTimeToJoinHoF;
			tmp.minTimeToJoinShops = this.minTimeToJoinShops;
			tmp.minTimeToJoinStadtwache = this.minTimeToJoinStadtwache;
			tmp.minTimeToJoinTarvern = this.minTimeToJoinTarvern;
			tmp.minTimeToJoinToilet = this.minTimeToJoinToilet;
			tmp.minTimeToLogOut = this.minTimeToLogOut;
			tmp.minTimeToSellItem = this.minTimeToSellItem;
			tmp.minTimeToTakeQuest = this.minTimeToTakeQuest;
			tmp.minTimeToUseItem = this.minTimeToUseItem;
			tmp.maxTimeToUseItem = this.maxTimeToUseItem;
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

			Assert.Asserts.AreNotSame(tmp, this, "Mist");

			return tmp;
		}

	}
}
