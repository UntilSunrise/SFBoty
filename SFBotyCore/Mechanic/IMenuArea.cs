using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFBoty.Mechanic.Account;
using System.Net;

namespace SFBoty.Mechanic {
	public interface IMenuArea {
		void Initialize(Account.Account account, WebClient refClient);
		void PerformArea();
		void Dispose();
	}
}
