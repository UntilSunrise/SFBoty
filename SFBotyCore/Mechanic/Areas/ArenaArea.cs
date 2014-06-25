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
			int maxRangeLimit = rang + Account.Settings.UpperRangeLimit;
			int minRangeLimit = rang - Account.Settings.LowerRangeLimit;
			int myLevel = Account.Level;
			int maxTries = Account.Settings.MaxTriesToFindEnemy;

			string s;
			string[] fightAnswer;
			int enemyLevel = 0;
			string enemyNick = "";
			string enemyGuildNick = "";

			RaiseMessageEvent("Betrete Arena");

			int tries = 1;
			do {
                if (tries > maxTries) {
                    break;
                } //else do nothing

				ThreadSleep(Account.Settings.minShortTime, Account.Settings.maxShortTime);
				if (Account.Settings.AttackSuggestedEnemy) {
					s = SendRequest(ActionTypes.JoinArena);
					string[] arenaAnswer = s.Substring(4, s.Length - 5).Split(';');

					if (arenaAnswer.Count() - 1 >= ResponseTypes.ArenaEnemyLevel && arenaAnswer.Count() - 1 >= ResponseTypes.ArenaEnemyNick && arenaAnswer.Count() - 1 >= ResponseTypes.ArenaGuildNick) {
						enemyLevel = Convert.ToInt32(arenaAnswer[ResponseTypes.ArenaEnemyLevel]);
						enemyNick = arenaAnswer[ResponseTypes.ArenaEnemyNick];
						enemyGuildNick = arenaAnswer[ResponseTypes.ArenaGuildNick];
					} else {
						return;
					}
				} else {
					Random random = new Random(System.Environment.TickCount);

					s = SendRequest(string.Concat(ActionTypes.JoinHallOfFame, random.Next(minRangeLimit, maxRangeLimit))).Remove(0, 4);

					int i = 0;
					Dictionary<int, HoFCharacter> HoFCharacters = new Dictionary<int, HoFCharacter>();
					while (i < (s.Split('/').Count() / 5)) {
						HoFCharacters.Add(i, new HoFCharacter(s.Split('/'), i * ResponseTypes.HoFOffset));
						i++;
					}

					int myRandomEnemy = -1;

					if (Account.Settings.AttackEnemyBetweenRange) {
						try {
							List<int> filteredEnemys = new List<int>();
							foreach (KeyValuePair<int, HoFCharacter> id in HoFCharacters.Where(x => x.Value.Level >= myLevel - levelDifference && x.Value.Level <= myLevel + levelDifference)) {
								filteredEnemys.Add(id.Key);
							}
							myRandomEnemy = filteredEnemys[random.Next(0, filteredEnemys.Count)];
						} catch {
							myRandomEnemy = -1;
						}
					} else {
						myRandomEnemy = random.Next(0, HoFCharacters.Count());
					}

					if (myRandomEnemy >= 0 && HoFCharacters.Count - 1 > myRandomEnemy && HoFCharacters[myRandomEnemy] != null) {
						enemyLevel = HoFCharacters[myRandomEnemy].Level;
                        enemyNick = HoFCharacters[myRandomEnemy].CharacterNick;
						enemyGuildNick = HoFCharacters[myRandomEnemy].GuildNick;
					}
				}
				tries++;
			} while (playerFilter.Contains(enemyNick)
					|| string.IsNullOrEmpty(enemyNick.Trim())
					|| Account.Settings.Username == enemyNick
					|| guildFilter.Contains(enemyGuildNick)
					|| (!enemyLevel.IsBetween(myLevel - levelDifference, myLevel + levelDifference) && Account.Settings.AttackEnemyBetweenRange));

            if (tries <= maxTries && !playerFilter.Contains(enemyNick) && !guildFilter.Contains(enemyGuildNick) && Account.Settings.Username != enemyNick) {
				RaiseMessageEvent(string.Format("Greife Spieler: {0} an.", enemyNick));
				ThreadSleep(Account.Settings.minShortTime, Account.Settings.maxShortTime);
				s = SendRequest(string.Concat(ActionTypes.AttackEnemy, enemyNick.Escape()));

				fightAnswer = s.Split(';');

				Asserts.IsTrue(fightAnswer.Count() >= 8, "Unerwarteter Fehler im Arena-Bereich");

				bool win = Convert.ToInt32(fightAnswer[1].Split('/')[fightAnswer[1].Split('/').Length - 7]) > 0 ? true : false;
				int honorChange = Convert.ToInt32(fightAnswer[7]);
				double goldChange = Convert.ToDouble(fightAnswer[8]) / 100;

				if (win) {
					RaiseMessageEvent(string.Format("Du hast gegen {0} gewonnen. Ehre: +{1} Gold: +{2}", enemyNick, honorChange, goldChange));
				} else {
					RaiseMessageEvent(string.Format("Du hast gegen {0} verloren. Ehre: {1} Gold: {2}", enemyNick, honorChange, goldChange));
				}
				//Account Daten aktualisieren
				ThreadSleep(Account.Settings.minShortTime, Account.Settings.maxShortTime);
				s = SendRequest(ActionTypes.JoinCharacter);
				if (s.Split('/').Count() < ResponseTypes.NextFreeDuellTimestamp) {
					Account.ArenaEndTime = DateTime.Now.AddMinutes(10);
					return;
				}
				CharScreenArea.UpdateAccountStats(s, Account);
				Account.ArenaEndTime = s.Split('/')[ResponseTypes.NextFreeDuellTimestamp].MillisecondsToDateTime();
			} else {
				RaiseMessageEvent("Es wurde kein passender Gegner gefunden.");
				Account.ArenaEndTime = DateTime.Now.AddMinutes(10);
				return;
			}
		}

		public override void RaiseMessageEvent(string s) {
			if (MessageOutput != null) {
				MessageOutput(this, new MessageEventsArgs(s));
			}
		}
	}
}
