using System.Collections.Generic;
using Nancy.Security;

namespace Paldi.Web.Infrastructure
{
    public class UserIdentity : IUserIdentity
    {
        public UserIdentity(string userName)
        {
            UserName = userName;
            Claims = new List<string>();
        }

        public string UserName { get; }
        public IEnumerable<string> Claims { get; }
    }
}