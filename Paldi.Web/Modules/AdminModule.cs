using System;
using Nancy;
using Nancy.Security;
using Paldi.Web.Models;

namespace Paldi.Web.Modules
{
    public class AdminModule : NancyModule
    {
        public AdminModule(Func<BaseModel> createModel) : base("admin")
        {
            this.RequiresAuthentication();

            Get["/changepassword"] = _ => View["ChangePassword.sshtml", createModel()];
        }
    }
}