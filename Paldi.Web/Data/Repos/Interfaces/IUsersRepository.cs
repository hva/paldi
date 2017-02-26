using System;
using Nancy.Security;

namespace Paldi.Web.Data.Repos.Interfaces
{
    public interface IUsersRepository
    {
        bool TryLogin(string login, string password, out Guid guid);
        IUserIdentity Find(Guid guid);
    }
}