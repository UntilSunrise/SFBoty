using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFBotyCore.Constants;

namespace SFBotyCore.Mechanic {
	public class HoFCharacter {
		public int Rang { get; set; }
		public string CharacterNick { get; set; }
		public string GuildNick { get; set; }
		public int Level { get; set; }
		public int Honor { get; set; }

		public HoFCharacter(string[] responseString, int offset) {
			Rang = Convert.ToInt32(responseString[(offset + ResponseTypes.HoFRang)]) < 0 ? Convert.ToInt32(responseString[(offset + ResponseTypes.HoFRang)]) * -1 : Convert.ToInt32(responseString[(offset + ResponseTypes.HoFRang)]);
			CharacterNick = responseString[(offset + ResponseTypes.HoFCharacternick)];
			GuildNick = responseString[(offset + ResponseTypes.HoFGuildnick)];
			Level = Convert.ToInt32(responseString[(offset + ResponseTypes.HoFLevel)]) < 0 ? Convert.ToInt32(responseString[(offset + ResponseTypes.HoFLevel)]) * -1 : Convert.ToInt32(responseString[(offset + ResponseTypes.HoFLevel)]);
			Honor = Convert.ToInt32(responseString[(offset + ResponseTypes.HoFHonor)]) < 0 ? Convert.ToInt32(responseString[(offset + ResponseTypes.HoFHonor)]) * -1 : Convert.ToInt32(responseString[(offset + ResponseTypes.HoFHonor)]);
		}
	}
}
