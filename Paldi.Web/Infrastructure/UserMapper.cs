using System;
using Nancy;
using Nancy.Authentication.Forms;
using Nancy.Security;

namespace Paldi.Web.Infrastructure
{
    public class UserMapper : IUserMapper
    {
        public IUserIdentity GetUserFromIdentifier(Guid identifier, NancyContext context)
        {
            return identifier == new Guid("DDEDA215-648B-4886-B0F4-349A5A4794D0")
                ? new UserIdentity()
                : null;
        }
    }
}