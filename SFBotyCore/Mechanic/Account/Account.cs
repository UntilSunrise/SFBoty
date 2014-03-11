using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using SFBotyCore.Constants;

namespace SFBotyCore.Mechanic.Account {

	public class Account {
		public AccountSettings Settings { get; set; }

		public ClassTypes Class { get; set; }

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
		public int HighestBuyedStat { get { return Math.Max(BuyedStr, Math.Max(BuyedDex, Math.Max(BuyedInt, Math.Max(BuyedAus, BuyedLuck)))); } }

		public Int64 Silver { get; set; }
		public int Mushroom { get; set; }
		public int Level { get; set; }
		public int Honor { get; set; }
		public int Rang { get; set; }
		public List<Item> BackpackItems { get; set; }
		public List<Item> InventoryItems { get; set; }

		public Guild Guild { get; set; }
		public bool HasAGuild { get; set; }
		public DateTime LastDonateTime { get; set; }
		public bool HasJoinAttack { get; set; }
		public bool HasJoinDefence { get; set; }
		public bool BackpackIsFull { get { return BackpackItems.Where(b => b.Typ != ItemTypes.Leer).Count() == 5; } }

		public DateTime LastAction { get; set; } //Wann hat der Bot das letzte mal eine Nachricht an den Server gesendet

		public MountTypes Mount { get; set; }
		public DateTime MountDuration { get; set; }

		public bool BackpackHasToiletItem {
			get {
				return BackpackItems.Where(
					b =>
						b.SilverValue != 0
						&& b.Typ != ItemTypes.Buff
						&& b.Typ != ItemTypes.Leer
						&& b.Typ != ItemTypes.SpiegelOderSchlüssel
						&& b.Typ != ItemTypes.KeineAhnung2
						&& b.IsEpic == false)
					.Count() > 0;
			}
		}

		public Account(AccountSettings settings) {
			Settings = settings;

			Class = ClassTypes.Mage;

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
			BackpackItems = new List<Item>();
			InventoryItems = new List<Item>();

			Guild = new Guild();
			HasAGuild = true;
			HasJoinAttack = false;
			HasJoinDefence = false;

			LastDonateTime = DateTime.Now;
			LastAction = DateTime.Now;

			Mount = MountTypes.None;
			MountDuration = DateTime.Now;
		}

		public void Logout() {
			Settings.ResetSessionID();
			if (Level >= 100 && !ToiletIsAvailable) {
				ToiletIsAvailable = true;
			}
		}
	}
}
