using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFBotyCore.Mechanic.Account;
using System.Net;

namespace SFBotyCore.Mechanic {
	public interface IMenuArea {
		void Initialize(Account.Account account, WebClient refClient);
		void PerformArea();
		void Dispose();
	}
}
