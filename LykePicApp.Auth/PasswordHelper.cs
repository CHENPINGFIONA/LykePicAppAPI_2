using Isopoh.Cryptography.Argon2;
using Isopoh.Cryptography.SecureArray;
using System;
using System.Text;

namespace LykePicApp.Auth
{
    public sealed class PasswordHelper
    {
        public static bool VerifyPassword(string password, string salt, string hashPassword)
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] saltBytes = Encoding.UTF8.GetBytes(salt + "12345678");
            return Argon2.Verify(hashPassword, passwordBytes, saltBytes);
        }

        public static string EncryptPassword(string plainText, string salt)
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(plainText);
            byte[] saltBytes = Encoding.UTF8.GetBytes(salt + "12345678");
            var config = new Argon2Config
            {
                Type = Argon2Type.DataIndependentAddressing,
                Version = Argon2Version.Nineteen,
                TimeCost = 10,
                MemoryCost = 32768,
                Lanes = 5,
                Threads = Environment.ProcessorCount,
                Password = passwordBytes,
                Salt = saltBytes, // >= 8 bytes if not null
                HashLength = 20 // >= 4
            };
            var argon2A = new Argon2(config);

            using (SecureArray<byte> hashA = argon2A.Hash())
            {
                return config.EncodeString(hashA.Buffer);
            }
        }
    }
}
