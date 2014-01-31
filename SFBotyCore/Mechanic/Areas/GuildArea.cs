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

			//check of has a guild
			if (DateTime.Now > Account.NextGuildVisit) {
				ThreadSleep(Account.Settings.minTimeToJoinGuild, Account.Settings.maxTimeToJoinGuild);
				string s = SendRequest(ActionTypes.JoinGuild);

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
