using System;
using Nancy;
using Nancy.Authentication.Forms;
using Nancy.ModelBinding;
using Paldi.Web.ViewModels;

namespace Paldi.Web.Modules
{
    public class LoginModule : NancyModule
    {
        public LoginModule()
        {
            Get["/login"] = _ => View["index", new LoginViewModel()];

            Get["/logout"] = _ => this.LogoutAndRedirect("/admin");

            Post["/login"] = parameters =>
            {
                var model = this.Bind<LoginViewModel>();

                if (model.Login == model.Password && model.Password == "admin")
                {
                    return this.LoginAndRedirect(new Guid("DDEDA215-648B-4886-B0F4-349A5A4794D0"), fallbackRedirectUrl: "/admin");
                }

                model.HasError = true;
                return View["index", model];
            };
        }
    }
}