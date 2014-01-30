using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assert {
	public class AssertException : Exception {
		public AssertException(string message)
			: base(message) {

		}

		public AssertException()
			: base() {

		}
	}
}
