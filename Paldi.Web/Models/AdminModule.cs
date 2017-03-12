using System;
using Nancy;
using Nancy.Security;

namespace Paldi.Web.Models
{
    public class AdminModule : NancyModule
    {
        public AdminModule(Func<NavigationModel> createModel) : base("admin")
        {
            this.RequiresAuthentication();

            Get["/changepassword"] = _ => View["ChangePassword.sshtml", createModel().With(Context)];
        }
    }
}