﻿using System;
using System.Configuration;
using System.Linq;
using Dapper;
using MySql.Data.MySqlClient;
using Nancy.Security;
using Paldi.Web.Data.Entities;
using Paldi.Web.Infrastructure;
using Paldi.Web.Services;

namespace Paldi.Web.Data.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly string connectionString;
        private readonly IPasswordService passwordService;

        public UsersRepository(IPasswordService passwordService)
        {
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            this.passwordService = passwordService;
        }

        public bool TryLogin(string login, string password, out Guid guid)
        {
            guid = Guid.Empty;
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                var p = new { Login = login };
                var user = connection.Query<User>("SELECT guid, hash PasswordHash FROM users WHERE login = @Login", p).FirstOrDefault();
                if (user == null)
                {
                    return false;
                }
                if (!passwordService.VerifyPasswordHash(user.PasswordHash, password))
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
    }
}