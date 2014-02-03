using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SFBotyCore.Mechanic.Account {
	[Serializable]
	public class Guild {
		public string Name { get; set; }
		public string[] MemberNames { get; set; }
		public string WellcomeText { get; set; }
		public int Honor { get; set; }
		public int Rang { get; set; }

		public Guild() {
			Name = "None";
			MemberNames = new string[0];
			WellcomeText = "";
			Honor = 0;
			Rang = 0;
		}
	}
}
