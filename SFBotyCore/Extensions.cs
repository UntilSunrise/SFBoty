using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SFBotyCore {
	public static class Extensions {
		public static DateTime MillisecondsToDateTime(this string s) {
			return new DateTime(1970, 1, 1).AddMilliseconds((Convert.ToDouble(s) * 1000) - (1000 * 60 * 60)).ToLocalTime(); // DungeonTime new DateTime(1970, 1, 1).AddMilliseconds(Convert.ToDouble(s.Split('/')[459]) * 1000 - (1000* 60 * 60)).ToLocalTime()
		}
	}
}
