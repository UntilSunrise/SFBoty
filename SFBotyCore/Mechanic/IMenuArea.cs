using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFBotyCore.Mechanic.Account;
using System.Net;
using SFBotyCore.Mechanic.Areas;

namespace SFBotyCore.Mechanic {
	public interface IMenuArea {
		void Initialize(Account.Account account, WebClient refClient);
		void PerformArea();
		void Dispose();

		event EventHandler<MessageEventsArgs> MessageOutput;
		event EventHandler<MessageEventsArgs> ExtendedLog;
	}
}
