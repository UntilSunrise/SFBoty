using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using SFBotyCore.Constants;

namespace SFBotyCore.Mechanic.Areas {
	public class GuildArea : BaseArea {
		public override event EventHandler<MessageEventsArgs> MessageOutput;

		public override void RaiseMessageEvent(string s) {
			if (MessageOutput != null) {
				MessageOutput(this, new MessageEventsArgs(s));
			}
		}

		public override void Dispose() {
			base.Dispose();
		}

		public override void Initialize(Account.Account account, WebClient refClient) {
			base.Initialize(account, refClient);
		}

		public override void PerformArea() {
			base.PerformArea();

			if (!Account.Settings.PerformGuild || !Account.HasAGuild) {
				return;
			}

			string s = "";
			bool hasJoinIn = false;
			if ((Account.ALU_Seconds == 0 || !Account.Settings.PerformQuesten) && !Account.TownWatchIsStarted && !Account.QuestIsStarted && Account.LastDonateTime.IsOtherDay(DateTime.Now) && Account.Settings.DonateGold) { //einmal spenden nach dem Questen am Tag
				RaiseMessageEvent("Betrete die Gilde");
				ThreadSleep(Account.Settings.minTimeToJoinGuild, Account.Settings.maxTimeToJoinGuild);
				s = SendRequest(ActionTypes.JoinGuild);

				Account.LastDonateTime = DateTime.Now;
				ThreadSleep(Account.Settings.minTimeToDonate, Account.Settings.maxTimeToDonate);
				int silver = (int)(Account.Silver * Account.Settings.FactorToDonate);
				silver = silver - silver % 100;
				SendRequest(String.Concat(ActionTypes.GuildDonateGold, silver));
				Account.Silver -= silver;
				RaiseMessageEvent(String.Concat("Es wurde ", (int)(silver / 100), " Gold an die Gilde ", Account.Guild.Name, " gespendet"));

				hasJoinIn = true;
			}

			if (DateTime.Now > Account.NextGuildVisit) {
				if (!hasJoinIn) {
					RaiseMessageEvent("Betrete die Gilde");
					ThreadSleep(Account.Settings.minTimeToJoinGuild, Account.Settings.maxTimeToJoinGuild);
					s = SendRequest(ActionTypes.JoinGuild);
				}

				Assert.Asserts.IsFalse(s == "", "Schwerer Fehler im Guildenbreich");

				if (s == ResponseTypes.PlayerHasNoGuild) {
					Account.HasAGuild = false;
					return;
				}

				string[] guildInformation = s.Split('§')[1].Split(';');
				string wellcomeText = guildInformation[0].Replace("#", Environment.NewLine);
				string members = guildInformation[1];
				string guildName = guildInformation[2];
				string guildHonor = guildInformation[3];
				string guildRang = guildInformation[4];

				Account.Guild.MemberNames = members.Split('/');
				Account.Guild.WellcomeText = wellcomeText;
				Account.Guild.Name = guildName;
				Account.Guild.Honor = Convert.ToInt32(guildHonor);
				Account.Guild.Rang = Convert.ToInt32(guildRang);

				Account.NextGuildVisit = DateTime.Now.AddSeconds(Account.Settings.guildVisitInterval);
			}
		}
	}
}

/*
 * 365 AngriffsZeit
 * 376 Verteidigungszeit
 * 1 - Gilden Silber
 * 2 - Gilden Pilze 
 */