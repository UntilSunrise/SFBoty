using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SFBotyCore.Mechanic.Account {
	[Serializable]
	public class Account {
		public AccountSettings Settings { get; set; }

		public int ALU_Seconds { get; set; }
		public bool QuestIsStarted { get; set; }
		public DateTime QuestEndTime { get; set; }

		public bool MirrorIsCompleted { get; set; }

		public bool ToiletIsAvailable { get; set; }
		public DateTime ToiletEndTime { get; set; }
		public int CurrentToiletLevel { get; set; }
		public Int64 CurrentToiletPoints { get; set; }
		public Int64 ToiletPointsForNewLevel { get; set; }

		public bool TownWatchIsStarted { get; set; }
		public DateTime TownWatchEndTime { get; set; }

		public DateTime DungeonEndTime { get; set; }
		public DateTime ArenaEndTime { get; set; }
		public DateTime NextGuildVisit { get; set; }

		public int BaseStr { get; set; }
		public int BaseDex { get; set; }
		public int BaseInt { get; set; }
		public int BaseAus { get; set; }
		public int BaseLuck { get; set; }
		public int AddonStr { get; set; }
		public int AddonDex { get; set; }
		public int AddonInt { get; set; }
		public int AddonAus { get; set; }
		public int AddonLuck { get; set; }
		public int BuyedStr { get; set; }
		public int BuyedDex { get; set; }
		public int BuyedInt { get; set; }
		public int BuyedAus { get; set; }
		public int BuyedLuck { get; set; }

		public Int64 Silver { get; set; }
		public int Mushroom { get; set; }
		public int Level { get; set; }
		public int Honor { get; set; }
		public int Rang { get; set; }

		public Guild Guild { get; set; }
		public bool HasAGuild { get; set; }
		public DateTime LastDonateTime { get; set; }

		public Account(AccountSettings settings) {
			Settings = settings;

			ALU_Seconds = 100 * 60;
			QuestIsStarted = false;
			QuestEndTime = DateTime.Now;

			MirrorIsCompleted = false;

			ToiletIsAvailable = true;
			ToiletEndTime = DateTime.Now;
			CurrentToiletLevel = 0;
			CurrentToiletPoints = 0;
			ToiletPointsForNewLevel = 0;

			TownWatchIsStarted = false;
			TownWatchEndTime = DateTime.Now;
			DungeonEndTime = DateTime.Now;
			ArenaEndTime = DateTime.Now;
			NextGuildVisit = DateTime.Now;

			BaseStr = 0;
			BaseDex = 0;
			BaseInt = 0;
			BaseAus = 0;
			BaseLuck = 0;
			AddonStr = 0;
			AddonDex = 0;
			AddonInt = 0;
			AddonAus = 0;
			AddonLuck = 0;

			Silver = 0;
			Mushroom = 0;
			Level = 0;
			Honor = 0;
			Rang = 0;

			Guild = new Guild();
			HasAGuild = true;

			LastDonateTime = DateTime.Now;
		}

		public void Logout() {
			Settings.ResetSessionID();
			if (Level >= 100 && !ToiletIsAvailable) {
				ToiletIsAvailable = true;
			}
		}
	}
}
