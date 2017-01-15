using System.Collections.Generic;
using Nancy.Security;

namespace Paldi.Web.Infrastructure
{
    public class UserIdentity : IUserIdentity
    {
        public UserIdentity()
        {
            UserName = "admin";
            Claims = new List<string>();
        }

        public string UserName { get; }
        public IEnumerable<string> Claims { get; }
    }
}