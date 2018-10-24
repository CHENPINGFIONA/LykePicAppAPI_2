using System.IO;
using System.Text;

namespace System.Security.Cryptography
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

        public static string EncryptPassword(string plainText)
        {
            return EncryptBySha256(plainText);
        }
    }
}
