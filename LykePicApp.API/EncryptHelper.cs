using Liphsoft.Crypto.Argon2;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace LykePicApp.API
{
    public sealed class EncryptHelper
    {
        static byte[] bytes = ASCIIEncoding.ASCII.GetBytes("ZeroCool");

        public static string EncryptBySha256(string plainText)
        {
            using (SHA256 sha256 = SHA256Managed.Create())
            {
                byte[] plainTextBytes = Encoding.Default.GetBytes(plainText);
                byte[] hashBytes = sha256.ComputeHash(plainTextBytes);

                var sb = new StringBuilder();
                for (int i = 0, j = hashBytes.Length; i < j; i++)
                {
                    sb.AppendFormat("{0:x2}", hashBytes[i]);
                }

                return sb.ToString();
            }
        }

        public static string EncryptByArgon2(string plainText)
        {
            // default is 65536 (in KiB)
            var hasher = new PasswordHasher();
            return hasher.Hash(plainText);
        }

        public static string EncryptPassword(string plainText, string plainSalt)
        {
            var cypherSalt = EncryptByArgon2(plainSalt);
            return EncryptByArgon2(string.Format("{0}{1}", plainText, cypherSalt));
        }
    }
}
