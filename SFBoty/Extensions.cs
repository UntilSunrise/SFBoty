using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SFBoty.Mechanic {
	public static class Extensions {
		public static void Invoke<TControl>(this TControl control, Action action) where TControl : Control {
			if (!control.InvokeRequired) {
				action();
			} else {
				control.Invoke(action);
			}
		}
	}
}
