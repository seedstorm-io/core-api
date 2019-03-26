using Microsoft.AspNetCore.Identity;
using SeedStorm.Core.Entities;
using System;

namespace SeedStorm.Core.Service
{
    public class BCryptPasswordHasher : IPasswordHasher<ApplicationUser>
    {
        public string HashPassword(ApplicationUser user, string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, 10);
        }

        public PasswordVerificationResult VerifyHashedPassword(ApplicationUser user, string hashedPassword, string providedPassword)
        {
            if (BCrypt.Net.BCrypt.Verify(providedPassword, hashedPassword))
            {
                return PasswordVerificationResult.Success;
            }
            return PasswordVerificationResult.Failed;
        }

        /*[Obsolete]
        private static string SaltPassword(ApplicationUser user, string password)
        {
            return string.Concat("777", password, "$$$");
        }*/
    }
}
