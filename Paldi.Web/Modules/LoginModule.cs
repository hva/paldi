using System;
using Nancy;
using Nancy.Authentication.Forms;
using Nancy.ModelBinding;
using Nancy.Security;
using Paldi.Web.Data;
using Paldi.Web.Infrastructure.Extensions;
using Paldi.Web.ViewModels;

namespace Paldi.Web.Modules
{
    public class LoginModule : NancyModule
    {
        public LoginModule(IUsersRepository usersRepository)
        {
            this.AssignViewBag();

            Get["/login"] = _ => View["Index.html", new LoginViewModel()];

            Get["/logout"] = _ => this.LogoutAndRedirect("/admin");

            Post["/login"] = parameters =>
            {
                this.ValidateCsrfToken();

                var model = this.Bind<LoginViewModel>();

                Guid guid;
                if (usersRepository.TryLogin(model.Login, model.Password, out guid))
                {
                    return this.LoginAndRedirect(guid, fallbackRedirectUrl: "/admin");
                }

                model.HasError = true;
                return View["Index.html", model];
            };
        }
    }
}