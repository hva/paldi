using System;
using System.Security.Cryptography;
using Paldi.Web.Infrastructure.Services.Interfaces;

namespace Paldi.Web.Infrastructure.Services
{
    public class PasswordService : IPasswordService
    {
        private const int saltLength = 16;
        private const int hashLength = 32;
        private const int iterations = 5000;

        public string HashPassword(string password)
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[saltLength]);

            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations);
            byte[] hash = pbkdf2.GetBytes(hashLength);

            byte[] hashBytes = new byte[saltLength + hashLength];
            Array.Copy(salt, 0, hashBytes, 0, saltLength);
            Array.Copy(hash, 0, hashBytes, saltLength, hashLength);

            return Convert.ToBase64String(hashBytes);
        }

        public bool VerifyPasswordHash(string savedPasswordHash, string password)
        {
            byte[] hashBytes = Convert.FromBase64String(savedPasswordHash);

            // Get the salt
            byte[] salt = new byte[saltLength];
            Array.Copy(hashBytes, 0, salt, 0, saltLength);

            // Compute the hash on the password the user entered
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations);
            byte[] hash = pbkdf2.GetBytes(hashLength);

            // Compare the results
            for (int i = 0; i < hashLength; i++)
            {
                if (hashBytes[i + saltLength] != hash[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}