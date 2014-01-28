﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFBoty.Mechanic;
using SFBoty.Mechanic.Areas;
using SFBoty.Mechanic.Account;
using System.Net;
using System.Threading;
using System.Collections.ObjectModel;

namespace SFBotyCore.Mechanic.Areas {
	public class DungeonType {
		public int DungeonID { get; private set; }
		public int DungeonEbene { get; private set; }
		public int DungeonMonsterLvl { get; private set; }

		public DungeonType(int id, int ebene, int lvl) {
			DungeonID = id;
			DungeonEbene = ebene;
			DungeonMonsterLvl = lvl;
		}
	}

	public class DungeonArea : BaseArea {
		#region statics
		public static ReadOnlyCollection<DungeonType> Dungeons { get { return new ReadOnlyCollection<DungeonType>(_Dungeons); } }
		private static List<DungeonType> _Dungeons = new List<DungeonType>() { 
			new DungeonType(1, 1, 10),
 			new DungeonType(1, 2, 12),
			new DungeonType(1, 3, 14),
			new DungeonType(1, 4, 16),
			new DungeonType(1, 5, 18),
			new DungeonType(1, 6, 22),
			new DungeonType(1, 7, 26),
			new DungeonType(1, 8, 30),
			new DungeonType(1, 9, 40),
			new DungeonType(1, 10, 50),

			new DungeonType(2, 1, 20),
 			new DungeonType(2, 2, 24),
			new DungeonType(2, 3, 28),
			new DungeonType(2, 4, 34),
			new DungeonType(2, 5, 38),
			new DungeonType(2, 6, 44),
			new DungeonType(2, 7, 48),
			new DungeonType(2, 8, 56),
			new DungeonType(2, 9, 66),
			new DungeonType(2, 10, 77),

			new DungeonType(3, 1, 32),
 			new DungeonType(3, 2, 36),
			new DungeonType(3, 3, 42),
			new DungeonType(3, 4, 46),
			new DungeonType(3, 5, 54),
			new DungeonType(3, 6, 60),
			new DungeonType(3, 7, 64),
			new DungeonType(3, 8, 76),
			new DungeonType(3, 9, 86),
			new DungeonType(3, 10, 90),

			new DungeonType(4, 1, 52),
 			new DungeonType(4, 2, 58),
			new DungeonType(4, 3, 62),
			new DungeonType(4, 4, 68),
			new DungeonType(4, 5, 74),
			new DungeonType(4, 6, 82),
			new DungeonType(4, 7, 84),
			new DungeonType(4, 8, 96),
			new DungeonType(4, 9, 102),
			new DungeonType(4, 10, 110),

			new DungeonType(5, 1, 72),
 			new DungeonType(5, 2, 78),
			new DungeonType(5, 3, 80),
			new DungeonType(5, 4, 88),
			new DungeonType(5, 5, 94),
			new DungeonType(5, 6, 100),
			new DungeonType(5, 7, 108),
			new DungeonType(5, 8, 114),
			new DungeonType(5, 9, 122),
			new DungeonType(5, 10, 130),

			new DungeonType(6, 1, 92),
 			new DungeonType(6, 2, 98),
			new DungeonType(6, 3, 104),
			new DungeonType(6, 4, 106),
			new DungeonType(6, 5, 118),
			new DungeonType(6, 6, 124),
			new DungeonType(6, 7, 128),
			new DungeonType(6, 8, 136),
			new DungeonType(6, 9, 144),
			new DungeonType(6, 10, 150),

			new DungeonType(7, 1, 112),
 			new DungeonType(7, 2, 116),
			new DungeonType(7, 3, 120),
			new DungeonType(7, 4, 126),
			new DungeonType(7, 5, 134),
			new DungeonType(7, 6, 138),
			new DungeonType(7, 7, 142),
			new DungeonType(7, 8, 146),
			new DungeonType(7, 9, 148),
			new DungeonType(7, 10, 170),

			new DungeonType(8, 1, 132),
 			new DungeonType(8, 2, 140),
			new DungeonType(8, 3, 154),
			new DungeonType(8, 4, 158),
			new DungeonType(8, 5, 164),
			new DungeonType(8, 6, 168),
			new DungeonType(8, 7, 172),
			new DungeonType(8, 8, 180),
			new DungeonType(8, 9, 185),
			new DungeonType(8, 10, 200),

			new DungeonType(9, 1, 152),
 			new DungeonType(9, 2, 156),
			new DungeonType(9, 3, 160),
			new DungeonType(9, 4, 162),
			new DungeonType(9, 5, 166),
			new DungeonType(9, 6, 174),
			new DungeonType(9, 7, 176),
			new DungeonType(9, 8, 178),
			new DungeonType(9, 9, 190),
			new DungeonType(9, 10, 201) // ich weiß das lvl hier ist immer genau dein char lvl, aber so lässt es sich am besten berechnen das es der schwerste dungeonlvl ist (zumindest in den Standard dungeons 1-9)
		};
		#endregion
				
		public override event EventHandler<MessageEventsArgs> MessageOutput;

		public override void RaiseMessageEvent(string s) {
			if (MessageOutput != null) {
				MessageOutput(this, new MessageEventsArgs(s));
			}
		}

		public override void Initialize(Account account, WebClient refClient) {
			base.Initialize(account, refClient);
		}

		public override void PerformArea() {
			base.PerformArea();
			return;

			if (Account.ALU_Seconds == 0 && !Account.QuestIsStarted && !Account.StadtwacheWurdeGestatet) {
				Thread.Sleep(random.Next((int)(Account.Settings.minTimeToJoinDungeon * 1000), (int)(Account.Settings.maxTimeToJoinDungeon * 1000)));
				RaiseMessageEvent("Join Dungeonoverview");
				string s = SendRequest(ActionTypes.JoinDungeon);
				string[] anserRequest = s.Split('/');

				int d1Lvl = Convert.ToInt32(anserRequest[480]) - 1;
				int d2Lvl = Convert.ToInt32(anserRequest[481]) - 1;
				int d3Lvl = Convert.ToInt32(anserRequest[482]) - 1;
				int d4Lvl = Convert.ToInt32(anserRequest[483]) - 1;
				int d5Lvl = Convert.ToInt32(anserRequest[484]) - 1;
				int d6Lvl = Convert.ToInt32(anserRequest[485]) - 1;
				int d7Lvl = Convert.ToInt32(anserRequest[486]) - 1;
				int d8Lvl = Convert.ToInt32(anserRequest[487]) - 1;
				int d9Lvl = Convert.ToInt32(anserRequest[488]) - 1;

				DungeonType nextDungeon;
				nextDungeon = FilterNextDungeon(d1Lvl, d2Lvl, d3Lvl, d4Lvl, d5Lvl, d6Lvl, d7Lvl, d8Lvl, d9Lvl);

				//sleep
				Thread.Sleep(random.Next((int)(Account.Settings.minTimeToJoinDungeon * 1000), (int)(Account.Settings.maxTimeToJoinDungeon * 1000)));
				s = SendRequest(String.Concat(ActionTypes.DoDungeon, nextDungeon.DungeonID));
				//sleep
				Thread.Sleep(random.Next((int)(Account.Settings.minTimeToJoinChar * 1000), (int)(Account.Settings.maxTimeToJoinChar * 1000)));
				s = SendRequest(ActionTypes.JoinCharacter);
				//set 1h for next dungeon time
			}
		}

		private static DungeonType FilterNextDungeon(int d1Lvl, int d2Lvl, int d3Lvl, int d4Lvl, int d5Lvl, int d6Lvl, int d7Lvl, int d8Lvl, int d9Lvl) {
			List<DungeonType> nextDungeons = new List<DungeonType>();
			nextDungeons.AddRange(DungeonArea.Dungeons.Where(d => (d1Lvl <= 10 && d.DungeonID == 1 && d.DungeonEbene == d1Lvl && d1Lvl > 0)));
			nextDungeons.AddRange(DungeonArea.Dungeons.Where(d => (d2Lvl <= 10 && d.DungeonID == 2 && d.DungeonEbene == d2Lvl && d2Lvl > 0)));
			nextDungeons.AddRange(DungeonArea.Dungeons.Where(d => (d3Lvl <= 10 && d.DungeonID == 3 && d.DungeonEbene == d3Lvl && d3Lvl > 0)));
			nextDungeons.AddRange(DungeonArea.Dungeons.Where(d => (d4Lvl <= 10 && d.DungeonID == 4 && d.DungeonEbene == d4Lvl && d4Lvl > 0)));
			nextDungeons.AddRange(DungeonArea.Dungeons.Where(d => (d5Lvl <= 10 && d.DungeonID == 5 && d.DungeonEbene == d5Lvl && d5Lvl > 0)));
			nextDungeons.AddRange(DungeonArea.Dungeons.Where(d => (d6Lvl <= 10 && d.DungeonID == 6 && d.DungeonEbene == d6Lvl && d6Lvl > 0)));
			nextDungeons.AddRange(DungeonArea.Dungeons.Where(d => (d7Lvl <= 10 && d.DungeonID == 7 && d.DungeonEbene == d7Lvl && d7Lvl > 0)));
			nextDungeons.AddRange(DungeonArea.Dungeons.Where(d => (d8Lvl <= 10 && d.DungeonID == 8 && d.DungeonEbene == d8Lvl && d8Lvl > 0)));
			nextDungeons.AddRange(DungeonArea.Dungeons.Where(d => (d9Lvl <= 10 && d.DungeonID == 9 && d.DungeonEbene == d9Lvl && d9Lvl > 0)));
			return nextDungeons.OrderBy(x => x.DungeonMonsterLvl).First();
		}

	}
}