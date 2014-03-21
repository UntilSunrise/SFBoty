using System;

namespace Assert {
	public static class Asserts {
		public static void AreEqual(Object exepted, Object current) {
			if (!exepted.Equals(current)) {
				throw new AssertException();
			}
		}
		public static void AreEqual(double exepted, double current) {
			if (!exepted.Equals(current)) {
				throw new AssertException();
			}
		}
		public static void AreEqual(float exepted, float current) {
			if (!exepted.Equals(current)) {
				throw new AssertException();
			}
		}
		public static void AreEqual(int exepted, int current) {
			if (!exepted.Equals(current)) {
				throw new AssertException();
			}
		}
		public static void AreEqual(string exepted, string current) {
			if (!exepted.Equals(current)) {
				throw new AssertException();
			}
		}

		public static void AreEqual(Object exepted, Object current, string message) {
			if (!exepted.Equals(current)) {
				throw new AssertException(message);
			}
		}
		public static void AreEqual(double exepted, double current, string message) {
			if (!exepted.Equals(current)) {
				throw new AssertException(message);
			}
		}
		public static void AreEqual(float exepted, float current, string message) {
			if (!exepted.Equals(current)) {
				throw new AssertException(message);
			}
		}
		public static void AreEqual(int exepted, int current, string message) {
			if (!exepted.Equals(current)) {
				throw new AssertException(message);
			}
		}
		public static void AreEqual(string exepted, string current, string message) {
			if (!exepted.Equals(current)) {
				throw new AssertException(message);
			}
		}

		public static void AreNotEqual(Object exepted, Object current) {
			if (exepted.Equals(current)) {
				throw new AssertException();
			}
		}
		public static void AreNotEqual(double exepted, double current) {
			if (exepted.Equals(current)) {
				throw new AssertException();
			}
		}
		public static void AreNotEqual(float exepted, float current) {
			if (exepted.Equals(current)) {
				throw new AssertException();
			}
		}
		public static void AreNotEqual(int exepted, int current) {
			if (exepted.Equals(current)) {
				throw new AssertException();
			}
		}
		public static void AreNotEqual(string exepted, string current) {
			if (exepted.Equals(current)) {
				throw new AssertException();
			}
		}

		public static void AreNotEqual(Object exepted, Object current, string message) {
			if (exepted.Equals(current)) {
				throw new AssertException(message);
			}
		}
		public static void AreNotEqual(double exepted, double current, string message) {
			if (exepted.Equals(current)) {
				throw new AssertException(message);
			}
		}
		public static void AreNotEqual(float exepted, float current, string message) {
			if (exepted.Equals(current)) {
				throw new AssertException(message);
			}
		}
		public static void AreNotEqual(int exepted, int current, string message) {
			if (exepted.Equals(current)) {
				throw new AssertException(message);
			}
		}
		public static void AreNotEqual(string exepted, string current, string message) {
			if (exepted.Equals(current)) {
				throw new AssertException(message);
			}
		}

		public static void AreSame(Object exepted, Object current) {
			if (!Object.ReferenceEquals(exepted, current)) {
				throw new AssertException();
			}
		}
		public static void AreSame(Object exepted, Object current, string message) {
			if (!Object.ReferenceEquals(exepted, current)) {
				throw new AssertException(message);
			}
		}

		public static void AreNotSame(Object exepted, Object current) {
			if (Object.ReferenceEquals(exepted, current)) {
				throw new AssertException();
			}
		}
		public static void AreNotSame(Object exepted, Object current, string message) {
			if (Object.ReferenceEquals(exepted, current)) {
				throw new AssertException(message);
			}
		}

		public static void IsTrue(bool condition) {
			if (!condition) {
				throw new AssertException();
			}
		}
		public static void IsTrue(bool condition, string message) {
			if (!condition) {
				throw new AssertException(message);
			}
		}

		public static void IsFalse(bool condition) {
			if (condition) {
				throw new AssertException();
			}
		}
		public static void IsFalse(bool condition, string message) {
			if (condition) {
				throw new AssertException(message);
			}
		}

		public static void IsInstanceOfType(object o, Type t) {
			if (typeof(object) != t) {
				throw new AssertException();
			}
		}
		public static void IsInstanceOfType(object o, Type t, string message) {
			if (typeof(object) != t) {
				throw new AssertException(message);
			}
		}

		public static void IsNotInstanceOfType(object o, Type t) {
			if (typeof(object) == t) {
				throw new AssertException();
			}
		}
		public static void IsNotInstanceOfType(object o, Type t, string message) {
			if (typeof(object) == t) {
				throw new AssertException(message);
			}
		}

		public static void IsNull(object o) {
			if (o != null) {
				throw new AssertException();
			}
		}
		public static void IsNull(double? d) {
			if (d != null) {
				throw new AssertException();
			}
		}
		public static void IsNull(float? f) {
			if (f != null) {
				throw new AssertException();
			}
		}
		public static void IsNull(int? i) {
			if (i != null) {
				throw new AssertException();
			}
		}
		public static void IsNull(string s) {
			if (!String.IsNullOrEmpty(s)) {
				throw new AssertException();
			}
		}

		public static void IsNull(object o, string message) {
			if (o != null) {
				throw new AssertException(message);
			}
		}
		public static void IsNull(double? d, string message) {
			if (d != null) {
				throw new AssertException(message);
			}
		}
		public static void IsNull(float? f, string message) {
			if (f != null) {
				throw new AssertException(message);
			}
		}
		public static void IsNull(int? i, string message) {
			if (i != null) {
				throw new AssertException(message);
			}
		}
		public static void IsNull(string s, string message) {
			if (!String.IsNullOrEmpty(s)) {
				throw new AssertException(message);
			}
		}

		public static void IsNotNull(object o) {
			if (o == null) {
				throw new AssertException();
			}
		}
		public static void IsNotNull(double? d) {
			if (d == null) {
				throw new AssertException();
			}
		}
		public static void IsNotNull(float? f) {
			if (f == null) {
				throw new AssertException();
			}
		}
		public static void IsNotNull(int? i) {
			if (i == null) {
				throw new AssertException();
			}
		}
		public static void IsNotNull(string s) {
			if (String.IsNullOrEmpty(s)) {
				throw new AssertException();
			}
		}

		public static void IsNotNull(object o, string message) {
			if (o == null) {
				throw new AssertException(message);
			}
		}
		public static void IsNotNull(double? d, string message) {
			if (d == null) {
				throw new AssertException(message);
			}
		}
		public static void IsNotNull(float? f, string message) {
			if (f == null) {
				throw new AssertException(message);
			}
		}
		public static void IsNotNull(int? i, string message) {
			if (i == null) {
				throw new AssertException(message);
			}
		}
		public static void IsNotNull(string s, string message) {
			if (String.IsNullOrEmpty(s)) {
				throw new AssertException(message);
			}
		}
	}
}
