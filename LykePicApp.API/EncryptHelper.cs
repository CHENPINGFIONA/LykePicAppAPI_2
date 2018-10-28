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

        public static string EncryptPassword(string plainText, string plainSalt)
        {
            var cypherSalt = EncryptBySha256(plainSalt);
            return EncryptBySha256(string.Format(plainText, cypherSalt));
        }
    }
}
