using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SFBotyCore {
	public static class Extensions {
		public static DateTime MillisecondsToDateTime(this string s) {
			return new DateTime(1970, 1, 1).AddMilliseconds((Convert.ToDouble(s) * 1000) - (1000 * 60 * 60)).ToLocalTime(); // DungeonTime new DateTime(1970, 1, 1).AddMilliseconds(Convert.ToDouble(s.Split('/')[459]) * 1000 - (1000* 60 * 60)).ToLocalTime()
		}

		public static bool HasMirror(this string[] s) {
			string blub = Convert.ToString(Convert.ToInt64(s[28]), 2);

			for (int i = blub.Length; i < 32; i = blub.Length) {
				blub = string.Concat("0", blub);
			}

			return (blub.Substring(23, 1) == "1" ? true : false);
		}
	}
}
