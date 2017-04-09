using Nancy;
using Nancy.Security;

namespace Paldi.Web.Modules
{
    public class AdminModule : NancyModule
    {
        public AdminModule() : base("admin")
        {
            this.RequiresAuthentication();

            Get["/changepassword"] = _ => View["ChangePassword.cshtml"];
        }
    }
}