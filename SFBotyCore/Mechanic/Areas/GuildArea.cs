﻿using System;
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
				ThreadSleep(Account.Settings.minShortTime, Account.Settings.maxShortTime);
				s = SendRequest(ActionTypes.JoinGuild);

				if (s.Contains("178")) {
					ThreadSleep(Account.Settings.minShortTime, Account.Settings.maxShortTime);
					s = SendRequest(ActionTypes.JoinGuild);
				}

				Account.LastDonateTime = DateTime.Now;
				ThreadSleep(Account.Settings.minShortTime, Account.Settings.maxShortTime);
				int silver = Convert.ToInt32(Account.Silver * Account.Settings.FactorToDonate);
				silver = silver - silver % 100; //silbertrennung vom gold abziehen
				silver = silver - silver % Convert.ToInt32(Math.Pow(10d, Convert.ToDouble(silver.ToString().Length - 1))); // auf eine glate summe abrunden statt 5487 Gold lieber 5000 gold spenden

				if (silver > (1000000000 - Account.Guild.Silver)) {
					//Spende nur den Betrag, der zum Gold-Cap der Gilde benötigt wird
					silver = 1000000000 - Account.Guild.Silver;
				} else {
					silver = 0;
				}

				if (silver > 0) {
					SendRequest(String.Concat(ActionTypes.GuildDonateGold, silver));
					Account.Silver -= silver;
					RaiseMessageEvent(String.Concat("Es wurde ", Convert.ToInt32(silver / 100), " Gold an die Gilde ", Account.Guild.Name, " gespendet"));
				}
				
				hasJoinIn = true;
			}

			if (DateTime.Now > Account.NextGuildVisit) {
				if (!hasJoinIn) {
					RaiseMessageEvent("Betrete die Gilde");
					ThreadSleep(Account.Settings.minShortTime, Account.Settings.maxShortTime);
					s = SendRequest(ActionTypes.JoinGuild);

					if (s.Contains("178")) {
						ThreadSleep(Account.Settings.minShortTime, Account.Settings.maxShortTime);
						s = SendRequest(ActionTypes.JoinGuild);
					}
				}

				Assert.Asserts.IsFalse(s == "", "Schwerer Fehler im Guildenbreich");

				if (s == ResponseTypes.PlayerHasNoGuild) {
					Account.HasAGuild = false;
					return;
				}

				if (s.Split('§').Count() < 2) {
					return;
				}
				string[] guildInformation = s.Split('§')[1].Split(';');
				if (guildInformation.Count() < 4) {
					return;
				}
				string wellcomeText = guildInformation[0].Replace("#", Environment.NewLine);
				string members = guildInformation[1];
				string guildName = guildInformation[2];
				string guildHonor = guildInformation[3];
				string guildRang = guildInformation[4];

				string[] answer = s.Split('/');
				if (answer.Count() < 367) {
					return;
				}
				string guildSilver = answer[1];
				string guildMushrooms = answer[2];

				Account.Guild.MemberNames = members.Split('/');
				Account.Guild.WellcomeText = wellcomeText;
				Account.Guild.Name = guildName;
				Account.Guild.Honor = Convert.ToInt32(guildHonor);
				Account.Guild.Rang = Convert.ToInt32(guildRang);
				Account.Guild.Silver = Convert.ToInt32(guildSilver);
				Account.Guild.Mushrooms = Convert.ToInt32(guildMushrooms);

				if (answer[365].MillisecondsToDateTime() > DateTime.Now) {
					if (!Account.HasJoinAttack) {
						ThreadSleep(Account.Settings.minShortTime, Account.Settings.maxShortTime);
						SendRequest(ActionTypes.GuildJoinAttack);
						Account.HasJoinAttack = true;
						RaiseMessageEvent("Hat sich zum Angriff gemeldet");
					}
				} else {
					Account.HasJoinAttack = false;
				}

				if (answer[367].MillisecondsToDateTime() > DateTime.Now) {
					if (!Account.HasJoinDefence) {
						ThreadSleep(Account.Settings.minShortTime, Account.Settings.maxShortTime);
						SendRequest(ActionTypes.GuildJoinDefence);
						Account.HasJoinDefence = true;
						RaiseMessageEvent("Hat sich zur Verteidigung gemeldet");
					}
				} else {
					Account.HasJoinDefence = false;
				}

				Account.NextGuildVisit = DateTime.Now.AddSeconds(Account.Settings.guildVisitInterval);
			}
		}
	}
}