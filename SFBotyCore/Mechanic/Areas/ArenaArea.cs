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

            List<string> guildFilter = Account.Settings.IgnoreGuilds.Split('/').ToList<string>();
            List<string> playerFilter = Account.Settings.IgnorePlayers.Split('/').ToList<string>();

            string s;
            //TODO: Prüfung, ob die Arena schon wieder verfügbar ist.
            

            if (Account.Settings.AttackSuggestedEnemy) {
                RaiseMessageEvent("Arena wird betreten");
                
                string[] arenaAnswer;
                do {
                    ThreadSleep(Account.Settings.minTimeToJoinHoF, Account.Settings.maxTimeToJoinHoF);
                    s = SendRequest(ActionTypes.JoinArena);
                    arenaAnswer = s.Substring(3, s.Length - 1).Split(';');
                } while (playerFilter.Contains(arenaAnswer[0]) || guildFilter.Contains(arenaAnswer[2]));

                RaiseMessageEvent(string.Format("Greife Spieler: {0} an.", arenaAnswer[0]));
                s = SendRequest(string.Concat(ActionTypes.AttackEnemy, arenaAnswer[0]));

                //TODO:Auswertung des Kampfes
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
