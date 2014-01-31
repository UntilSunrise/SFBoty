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

		public bool ToiletIsAvailable { get; set; }
		public bool ToiletAlreadyUsedToday { get; set; }
		public int CurrentToiletLevel { get; set; }
		public int CurrentToiletPoints { get; set; }
		public int ToiletPointsForNewLevel { get; set; }

		public bool StadtwacheWurdeGestatet { get; set; }
		public DateTime StadtwacheEndTime { get; set; }

		public DateTime DungeonEndTime {get; set;}

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

		public int Silver { get; set; }
		public int Pilze { get; set; }
		public int Level { get; set; }
        public int Honor { get; set; }
        public int Rang { get; set; }

		public Account(AccountSettings settings) {
			Settings = settings;

			ALU_Seconds = 100 * 60;
			QuestIsStarted = false;
			QuestEndTime = DateTime.Now;

			ToiletIsAvailable = true;
			ToiletAlreadyUsedToday = false;
			CurrentToiletLevel = 0;
			CurrentToiletPoints = 0;
			ToiletPointsForNewLevel = 0;

			StadtwacheWurdeGestatet = false;
			StadtwacheEndTime = DateTime.Now;
			DungeonEndTime = DateTime.Now;

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
			Pilze = 0;
			Level = 0;
            Honor = 0;
            Rang = 0;
		}

		public void Logout() {
			Settings.ResetSessionID();
			//TODO FIX: try to set to 100 alu after echt logout;
		}
	}
}
