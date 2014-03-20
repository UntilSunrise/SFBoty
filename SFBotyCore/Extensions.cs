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

		public static bool IsOtherDay(this DateTime source, DateTime target) {
			return source.Day != target.Day || source.Month != target.Month || source.Year != target.Year;
		}

		public static bool IsBetween(this int source, int min, int max) {
			return source >= min && source <= max;
		}

		public static string Escape(this string s) {
			return s.Replace(" ", "%20")
					.Replace("Ä", "%C4")
					.Replace("Ö", "%D6")
					.Replace("Ü", "%DC")
					.Replace("ü", "%FC")
					.Replace("ä", "%E4")
					.Replace("ö", "%F6")
					.Replace("^", "%5E")
					.Replace("~", "%7E")
					.Replace("ß", "%DF"); //Ich weiß selbst das diese Stelle hier hässlich ist, aber flash escaped ihre werte sehr seltsam und ich hab in C# kein identisches Verfahren gefunden
		}

		public static T ToEnum<T>(this string s) {
			return (T)Enum.Parse(typeof(T), s);
		}

		public static bool Contains(this string s, List<string> strings) {
			bool match = false;

			foreach (string part in strings) {
				if (s.Contains(part)) {
					match = true;
				}
			}

			return match;
		}

	}
}
