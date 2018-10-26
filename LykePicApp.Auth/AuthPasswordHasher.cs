﻿using LykePicApp.BAL;
using Microsoft.AspNet.Identity;
using System.Security.Cryptography;

namespace LykePicApp.Auth
{
    public sealed class AuthPasswordHasher : PasswordHasher
    {
        public override string HashPassword(string password)
        {
            return EncryptHelper.EncryptPassword(password);
        }

        public override PasswordVerificationResult VerifyHashedPassword(string hashedPassword, string providedPassword)
        {
            if (EncryptHelper.EncryptPassword(providedPassword).Equals(hashedPassword))
            {
                return PasswordVerificationResult.Success;
            }

            return PasswordVerificationResult.Failed;
        }
    }
}
