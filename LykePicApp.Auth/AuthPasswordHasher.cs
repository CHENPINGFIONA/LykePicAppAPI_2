using LykePicApp.BAL;
using Microsoft.AspNet.Identity;
using System.Security.Cryptography;

namespace LykePicApp.Auth
{
    public sealed class AuthPasswordHasher : PasswordHasher
    {
        public override PasswordVerificationResult VerifyHashedPassword(string hashedPassword, string providedHashedPassword)
        {
            if (providedHashedPassword.Equals(hashedPassword))
            {
                return PasswordVerificationResult.Success;
            }

            return PasswordVerificationResult.Failed;
        }
    }
}
