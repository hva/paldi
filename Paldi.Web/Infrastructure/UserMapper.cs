using System;
using Nancy;
using Nancy.Authentication.Forms;
using Nancy.Security;
using Paldi.Web.Data.Repos.Interfaces;

namespace Paldi.Web.Infrastructure
{
    public class UserMapper : IUserMapper
    {
        private readonly IUsersRepository usersRepository;

        public UserMapper(IUsersRepository usersRepository)
        {
            this.usersRepository = usersRepository;
        }

        public IUserIdentity GetUserFromIdentifier(Guid identifier, NancyContext context)
        {
            return usersRepository.Find(identifier);
        }
    }
}