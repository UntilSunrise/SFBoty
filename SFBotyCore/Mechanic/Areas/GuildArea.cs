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

/*
 * 
 * DoDonate = function (evt:Event=undefined){
                    DonateTimeout.stop();
                    if (GoldToDonate > 0){
                        SendAction(ACT_GUILD_DONATE, 1, String((GoldToDonate * 100)));
                    } else {
                        if (MushToDonate > 0){
                            SendAction(ACT_GUILD_DONATE, 2, String(MushToDonate));
                        };
                    };
                    GoldToDonate = 0;
                    MushToDonate = 0;
                };
 * 
*/

/*
DateTime t = mfbot.TimeReturnUnix2DateUtc((long)Convert.ToInt32(array.GetValue(365)));
					DateTime t2 = mfbot.TimeReturnUnix2DateUtc((long)Convert.ToInt32(array.GetValue(367)));
					if (t > DateTime.UtcNow)
					{
						string hTML2 = this.getHTML(name, "112", this.v);
						if (!hTML2.Substring(0, 2).Contains("E") || hTML2.Substring(0, 2).Contains("E064"))
						{
							this.writeLog(name, string.Format(this.rm.GetString("Charakter wurde zum Gildenangriff am {0} gemeldet."), t.ToString()), "INFO-GLD");
						}
					}
					if (t2 > DateTime.UtcNow)
					{
						string hTML3 = this.getHTML(name, "113", this.v);
						if (!hTML3.Substring(0, 2).Contains("E") || hTML3.Substring(0, 2).Contains("E064"))
						{
							this.writeLog(name, string.Format(this.rm.GetString("Charakter wurde zur Gildenverteidigung am {0} gemeldet."), t2.ToString()), "INFO-GLD");
						}
					}
*/