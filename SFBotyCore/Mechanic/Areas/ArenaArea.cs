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
			if (!Account.Settings.PerformArena || DateTime.Now < Account.ArenaEndTime || Account.QuestIsStarted || Account.TownWatchIsStarted) {
                return;
            }

            List<string> guildFilter = Account.Settings.IgnoreGuilds.Split('/').ToList<string>();
            List<string> playerFilter = Account.Settings.IgnorePlayers.Split('/').ToList<string>();
			int levelDifference = Account.Settings.LevelDifference;
			int myLevel = Account.Level;
			int maxTries = Account.Settings.MaxTriesToFindEnemy;

            string s;
			string[] fightAnswer;
			string[] arenaAnswer;
            if (Account.Settings.AttackSuggestedEnemy) {
                RaiseMessageEvent("Arena betreten");
                
				int tries = 0;
                do {
                    ThreadSleep(Account.Settings.minTimeToJoinHoF, Account.Settings.maxTimeToJoinHoF);
                    s = SendRequest(ActionTypes.JoinArena);
					arenaAnswer = s.Substring(4, s.Length - 5).Split(';');
					tries++;
					if (tries == maxTries) {
						break;
					} //else do nothing
                } while (playerFilter.Contains(arenaAnswer[ResponseTypes.ArenaEnemyNick]) 
						|| guildFilter.Contains(arenaAnswer[ResponseTypes.ArenaGildenNick])
						|| Convert.ToInt32(arenaAnswer[ResponseTypes.ArenaEnemyLevel]) >= (myLevel + levelDifference)
						|| Convert.ToInt32(arenaAnswer[ResponseTypes.ArenaEnemyLevel]) <= (myLevel - levelDifference));

				if (tries <= maxTries) {
					RaiseMessageEvent(string.Format("Greife Spieler: {0} an.", arenaAnswer[0]));
					s = SendRequest(string.Concat(ActionTypes.AttackEnemy, arenaAnswer[0]));

					fightAnswer = s.Split(';');

					bool win = Convert.ToInt32(fightAnswer[1].Split('/')[fightAnswer[1].Split('/').Length - 7]) > 0 ? true : false;
					int honorChange = Convert.ToInt32(fightAnswer[7]);
					double goldChange = Convert.ToDouble(fightAnswer[8]) / 100;

					if (win) {
						RaiseMessageEvent(string.Format("Du hast gegen {0} gewonnen. Ehre: +{1} Gold: +{2}", arenaAnswer[ResponseTypes.ArenaEnemyNick], honorChange, goldChange));
					} else {
						RaiseMessageEvent(string.Format("Du hast gegen {0} verloren. Ehre: -{1} Gold: -{2}", arenaAnswer[ResponseTypes.ArenaEnemyNick], honorChange, goldChange));
					}
					Account.ArenaEndTime = DateTime.Now.AddMinutes(10);
				} else {
					RaiseMessageEvent("Es wurde kein passender Gegner gefunden.");
					return;
				}

            } else {
                ThreadSleep(Account.Settings.minTimeToJoinHoF, Account.Settings.maxTimeToJoinHoF);
                RaiseMessageEvent("Ehrenhalle wird betreten");
                s = SendRequest(ActionTypes.JoinHallOfFame + Account.Rang);

                //TODO: Kampf mit Rangbereich
            }  
        }

        public override void RaiseMessageEvent(string s) {
            if (MessageOutput != null) {
                MessageOutput(this, new MessageEventsArgs(s));
            }
        }
    }
}
