using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SFBotyCore.Mechanic.Account {
	public enum AutoQuestMode { 
		BestXP,
		BestGold,
		BestTime,
		HighstMountPerSecond
	}

	[Serializable]
	public class AccountSettings {
		public string Username { get; set; }
		public string PasswordHash { get; set; }
		public string Server { get; set; }
		public string SessionID { get; set; }
		private static string EmpytSessionID = "00000000000000000000000000000000";

		public bool PerformQuesten { get; set; }
		public bool PerformBuyStats { get; set; }
		public bool PerformStadtwache { get; set; }
		public bool PerformDungeons { get; set; }
		public bool PerformToilet { get; set; }
        public bool SellToiletItemIfNotEpic { get; set; }

		public float StatStrFactor { get; set; }
		public float StatDexFactor { get; set; }
		public float StatIntFactor { get; set; }
		public float StatAusFactor { get; set; }
		public float StatLuckFactor { get; set; }

		public bool BuyBeer { get; set; }
		public int MaxBeerToBuy { get; set; }

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
		#endregion
		

		public bool HasLogin { get { return SessionID != EmpytSessionID; } }
		public AutoQuestMode QuestMode { get; set; }

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

			this.StatStrFactor = 0.45f;
			this.StatDexFactor = 0.05f;
			this.StatIntFactor = 0.05f;
			this.StatAusFactor = 0.35f;
			this.StatLuckFactor = 0.10f;

			this.BuyBeer = false;
			this.MaxBeerToBuy = 10;

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

			this.QuestMode = AutoQuestMode.BestXP;
		}

		public void ResetSessionID() {
			this.SessionID = EmpytSessionID;
		}

	}
}
