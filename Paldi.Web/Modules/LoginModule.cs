using System;
using Nancy;
using Nancy.Authentication.Forms;
using Nancy.ModelBinding;
using Nancy.Security;
using Paldi.Web.Data;
using Paldi.Web.Models;

namespace Paldi.Web.Modules
{
    public class LoginModule : NancyModule
    {
        private const string key = "Login";

        public LoginModule(IUsersRepository usersRepository, Func<NavigationModel> createModel)
        {
            Get["/login"] = _ => View["Index.sshtml", createModel().Extend(Context, key, new LoginModel())];

            Get["/logout"] = _ => this.LogoutAndRedirect("/");

            Post["/login"] = parameters =>
            {
                this.ValidateCsrfToken();

                var model = this.Bind<LoginModel>();

                if (!string.IsNullOrEmpty(model.Password))
                {
                    Guid guid;
                    if (usersRepository.TryLogin(model.Login, model.Password, out guid))
                    {
                        return this.LoginAndRedirect(guid);
                    }
                }

                model.HasError = true;
                return View["Index.sshtml", createModel().Extend(Context, key, model)];
            };
        }
    }
}