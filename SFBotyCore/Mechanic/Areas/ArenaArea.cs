using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFBotyCore.Mechanic.Account;
using System.Net;
using System.Threading;
using Assert;
using SFBotyCore.Mechanic;
using SFBotyCore.Constants;

namespace SFBotyCore.Mechanic.Areas {
	public class ArenaArea : BaseArea {
		#region Events
		public override event EventHandler<MessageEventsArgs> MessageOutput;
		#endregion

		public ArenaArea()
			: base() {

		}

		public override void Initialize(Account.Account account, WebClient refClient) {
			base.Initialize(account, refClient);
		}

		public override void Dispose() {
			base.Dispose();
		}

		public override void PerformArea() {
			base.PerformArea();

			//Wenn die Arena nicht genutzt werden soll, tue nichts.
			if (!Account.Settings.PerformArena) {
				return;
			}
			if ((Account.QuestIsStarted || Account.TownWatchIsStarted) && !Account.MirrorIsCompleted || DateTime.Now < Account.ArenaEndTime) {
				return;
			}

			List<string> guildFilter = Account.Settings.IgnoreGuilds.Split('/').ToList<string>();
			List<string> playerFilter = Account.Settings.IgnorePlayers.Split('/').ToList<string>();
			int levelDifference = Account.Settings.LevelDifference;
			int rang = Account.Rang;
			int maxRangeLimit = rang - Account.Settings.UpperRangeLimit;
			int minRangeLimit = rang + Account.Settings.LowerRangeLimit;
			int myLevel = Account.Level;
			int maxTries = Account.Settings.MaxTriesToFindEnemy;

			string s;
			string[] fightAnswer;
			int enemyLevel = 0;
			string enemyNick = "";
			string enemyGuildNick = "";

			RaiseMessageEvent("Arena betreten");

			int tries = 0;
			do {
				ThreadSleep(Account.Settings.minTimeToJoinHoF, Account.Settings.maxTimeToJoinHoF);
				if (Account.Settings.AttackSuggestedEnemy) {
					s = SendRequest(ActionTypes.JoinArena);
					string[] arenaAnswer = s.Substring(4, s.Length - 5).Split(';');

					enemyLevel = Convert.ToInt32(arenaAnswer[ResponseTypes.ArenaEnemyLevel]);
					enemyNick = arenaAnswer[ResponseTypes.ArenaEnemyNick];
					enemyGuildNick = arenaAnswer[ResponseTypes.ArenaGuildNick];
				} else {
					Random random = new Random(System.Environment.TickCount);

					s = SendRequest(string.Concat(ActionTypes.JoinHallOfFame, random.Next(maxRangeLimit, minRangeLimit))).Remove(0, 4);

					int i = 0;
					Dictionary<int, HoFCharacter> HoFCharacters = new Dictionary<int, HoFCharacter>();
					while (i < 15) {
						HoFCharacters.Add(i, new HoFCharacter(s.Split('/'), i * ResponseTypes.HoFOffset));
						i++;
					}
					int myRandomEnemy = random.Next(1, 16);
					enemyLevel = HoFCharacters[myRandomEnemy].Level;
					enemyNick = HoFCharacters[myRandomEnemy].CharacterNick;
					enemyGuildNick = HoFCharacters[myRandomEnemy].GuildNick;
				}
				tries++;
				if (tries == maxTries) {
					break;
				} //else do nothing
			} while (playerFilter.Contains(enemyNick)
					|| Account.Settings.Username == enemyNick
					|| guildFilter.Contains(enemyGuildNick)
					|| enemyLevel >= (myLevel + levelDifference)
					|| enemyLevel <= (myLevel - levelDifference));

			if (tries <= maxTries) {
				RaiseMessageEvent(string.Format("Greife Spieler: {0} an.", enemyNick));
				s = SendRequest(string.Concat(ActionTypes.AttackEnemy, enemyNick));

				fightAnswer = s.Split(';');

				bool win = Convert.ToInt32(fightAnswer[1].Split('/')[fightAnswer[1].Split('/').Length - 7]) > 0 ? true : false;
				int honorChange = Convert.ToInt32(fightAnswer[7]);
				double goldChange = Convert.ToDouble(fightAnswer[8]) / 100;

				if (win) {
					RaiseMessageEvent(string.Format("Du hast gegen {0} gewonnen. Ehre: +{1} Gold: +{2}", enemyNick, honorChange, goldChange));
				} else {
					RaiseMessageEvent(string.Format("Du hast gegen {0} verloren. Ehre: {1} Gold: {2}", enemyNick, honorChange, goldChange));
				}
			} else {
				RaiseMessageEvent("Es wurde kein passender Gegner gefunden.");
				return;
			}

			//Account Daten aktualisieren
			s = SendRequest(ActionTypes.JoinCharacter);
			Account.ArenaEndTime = s.Split('/')[ResponseTypes.NextFreeDuellTimestamp].MillisecondsToDateTime();
			Account.Silver = Convert.ToInt64(s.Split('/')[ResponseTypes.Silver]);
			Account.Rang = Convert.ToInt32(s.Split('/')[ResponseTypes.Rang]);
			Account.Honor = Convert.ToInt32(s.Split('/')[ResponseTypes.Honor]);
		}

		public override void RaiseMessageEvent(string s) {
			if (MessageOutput != null) {
				MessageOutput(this, new MessageEventsArgs(s));
			}
		}
	}
}
