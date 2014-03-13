using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using SFBotyCore.Mechanic.Account;

namespace SFBotyCore {
	public static class CryptManager {
		private static string PasswordHash = "P@@Sw0rd";
		private static string SaltKey = "S@LT&KEY";
		private static string VIKey = "@1B2c3D4e5F6g7H8";

		public static void Init(string text) {
			CryptManager.SaltKey = GetSalt(text);
			CryptManager.PasswordHash = GetHashSha256(text);
			CryptManager.VIKey = string.Concat(CryptManager.SaltKey, CryptManager.PasswordHash).Substring(0, 16);
		}

		public static void Init(AccountSettings settings) {
			CryptManager.Init(string.Concat(settings.PasswordHash, settings.Server, settings.Username));
		}

		public static string Encrypt(string plainText) {
			byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);

			byte[] keyBytes = new Rfc2898DeriveBytes(PasswordHash, Encoding.ASCII.GetBytes(SaltKey)).GetBytes(256 / 8);
			var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.Zeros };
			var encryptor = symmetricKey.CreateEncryptor(keyBytes, Encoding.ASCII.GetBytes(VIKey));

			byte[] cipherTextBytes;

			using (var memoryStream = new MemoryStream()) {
				using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write)) {
					cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
					cryptoStream.FlushFinalBlock();
					cipherTextBytes = memoryStream.ToArray();
					cryptoStream.Close();
				}
				memoryStream.Close();
			}
			return Convert.ToBase64String(cipherTextBytes);
		}

		public static string Decrypt(string encryptedText) {
			byte[] cipherTextBytes = Convert.FromBase64String(encryptedText);
			byte[] keyBytes = new Rfc2898DeriveBytes(PasswordHash, Encoding.ASCII.GetBytes(SaltKey)).GetBytes(256 / 8);
			var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.None };

			var decryptor = symmetricKey.CreateDecryptor(keyBytes, Encoding.ASCII.GetBytes(VIKey));
			var memoryStream = new MemoryStream(cipherTextBytes);
			var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
			byte[] plainTextBytes = new byte[cipherTextBytes.Length];

			int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
			memoryStream.Close();
			cryptoStream.Close();
			return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount).TrimEnd("\0".ToCharArray());
		}

		private static string GetSalt(string text) {
			return Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(text));
		}

		private static string GetHashSha256(string text) {
			byte[] bytes = Encoding.Unicode.GetBytes(text);
			SHA256Managed hashstring = new SHA256Managed();
			byte[] hash = hashstring.ComputeHash(bytes);
			string hashString = string.Empty;
			foreach (byte x in hash) {
				hashString += String.Format("{0:x2}", x);
			}
			return hashString;
		}
	}
}
