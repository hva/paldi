using Nancy;
using Nancy.Security;

namespace Paldi.Web.Modules
{
    public class AdminModule : NancyModule
    {
        public AdminModule() : base("admin")
        {
            this.RequiresAuthentication();

            Get["/"] = _ => View["index"];
        }
    }
}