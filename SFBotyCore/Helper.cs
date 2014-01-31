using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SFBotyCore {
	public static class Helper {

		public static int GetGoldMountFromGoldCurve(int statAmount, int[] goldCurve) {
			int gold = goldCurve[statAmount];
			return gold <= 0 || gold > 10000000 || statAmount > 15000 ? 10000000 : gold;
		}

		public static int GetGoldMountFromGoldCurve(int statAmount) {
			return GetGoldMountFromGoldCurve(statAmount, GoldCurve);
		}

		private static int[] _goldcurve;
		public static int[] GoldCurve {
			get {
				if (_goldcurve == null)
					_goldcurve = CalcGoldCurve();
				return _goldcurve;
			}
		}
		public static int[] CalcGoldCurve() {
			int priceLimit = 10000000;

			bool attPriceLimitation = false;
			int[] GoldKurve = new int[15001];
			int[] TrueAttPreis = new int[15001];
			GoldKurve[1] = 25;
			GoldKurve[2] = 50;
			GoldKurve[3] = 75;
			int i = 4;
			while (i <= 15000) {
				GoldKurve[i] = (((GoldKurve[(i - 1)]) + ((GoldKurve[((i / 2))] / 3))) + ((GoldKurve[((i / 3))] / 4)));
				GoldKurve[i] = ((GoldKurve[i] / 5));
				GoldKurve[i] = (GoldKurve[i] * 5);
				i = (i + 1);
			};
			i = 0;
			while (i <= 15000) {
				TrueAttPreis[i] = GoldKurve[((1 + (i / 5)))];
				i = (i + 1);
			};
			i = 0;
			while (i <= 14996) {
				if (attPriceLimitation) {
					TrueAttPreis[i] = priceLimit;
				} else {
					TrueAttPreis[i] = (((((TrueAttPreis[i]) + (TrueAttPreis[(i + 1)])) + (TrueAttPreis[(i + 2)])) + (TrueAttPreis[(i + 3)])) + (TrueAttPreis[(i + 4)]));
					TrueAttPreis[i] = ((TrueAttPreis[i] / 5));
					TrueAttPreis[i] = ((TrueAttPreis[i] / 5));
					TrueAttPreis[i] = ((TrueAttPreis[i] * 5));
					if (TrueAttPreis[i] > priceLimit) {
						TrueAttPreis[i] = priceLimit;
						attPriceLimitation = true;
					};
				};
				i = (i + 1);
			};

			return TrueAttPreis;
		}
	}
}
