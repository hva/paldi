using System;
using Nancy;
using Nancy.Authentication.Forms;
using Nancy.ModelBinding;
using Paldi.Web.Data;
using Paldi.Web.ViewModels;

namespace Paldi.Web.Modules
{
    public class LoginModule : NancyModule
    {
        public LoginModule(IUsersRepository usersRepository)
        {
            Get["/login"] = _ => View["index", new LoginViewModel()];

            Get["/logout"] = _ => this.LogoutAndRedirect("/admin");

            Post["/login"] = parameters =>
            {
                var model = this.Bind<LoginViewModel>();

                Guid guid;
                if (usersRepository.TryLogin(model.Login, model.Password, out guid))
                {
                    return this.LoginAndRedirect(guid, fallbackRedirectUrl: "/admin");
                }

                model.HasError = true;
                return View["index", model];
            };
        }
    }
}