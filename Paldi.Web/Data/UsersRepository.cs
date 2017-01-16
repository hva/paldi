using System;
using System.Linq;
using System.Security.Cryptography;
using Dapper;
using MySql.Data.MySqlClient;
using Nancy.Security;
using Paldi.Web.Entities;
using Paldi.Web.Infrastructure;

namespace Paldi.Web.Data
{
    public class UsersRepository : IUsersRepository
    {
        private readonly string connectionString;

        public UsersRepository(IConfiguration configuration)
        {
            connectionString = configuration.ConnectionString;
        }

        public bool TryLogin(string login, string password, out Guid guid)
        {
            guid = Guid.Empty;
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                var p = new { Login = login };
                var user = connection.Query<User>("SELECT guid, password FROM users WHERE login = @Login", p).FirstOrDefault();
                if (user == null)
                {
                    return false;
                }
                if (!VerifyPasswordHash(user.Password, password))
                {
                    return false;
                }
                guid = new Guid(user.Guid);
                return true;
            }
        }

        public IUserIdentity Find(Guid guid)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                var p = new { Guid = guid };
                var user = connection.Query<User>("SELECT login FROM users WHERE guid = @Guid", p).FirstOrDefault();
                return (user == null)
                    ? null
                    : new UserIdentity(user.Login);
            }
        }

        private static bool VerifyPasswordHash(string savedPasswordHash, string password)
        {
            byte[] hashBytes = Convert.FromBase64String(savedPasswordHash);

            // Get the salt
            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);

            // Compute the hash on the password the user entered
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);

            // Compare the results
            for (int i = 0; i < 20; i++)
            {
                if (hashBytes[i + 16] != hash[i])
                {
                    return false;
                }
            }
            return true;
        }

        private static string HashPassword(string password)
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);

            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);

            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            return Convert.ToBase64String(hashBytes);
        }
    }
}