using Nancy;
using Nancy.Security;
using Paldi.Web.Infrastructure.Extensions;

namespace Paldi.Web.Modules
{
    public class AdminModule : NancyModule
    {
        public AdminModule() : base("admin")
        {
            this.AssignViewBag();
            this.RequiresAuthentication();

            Get["/"] = _ => View["index"];
        }
    }
}