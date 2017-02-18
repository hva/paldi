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

            Get["/login"] = _ => View["Index.sshtml", new LoginViewModel()];

            Get["/logout"] = _ => this.LogoutAndRedirect("/");

            Post["/login"] = parameters =>
            {
                this.ValidateCsrfToken();

                var model = this.Bind<LoginViewModel>();

                if (!string.IsNullOrEmpty(model.Password))
                {
                    Guid guid;
                    if (usersRepository.TryLogin(model.Login, model.Password, out guid))
                    {
                        return this.LoginAndRedirect(guid);
                    }
                }

                model.HasError = true;
                return View["Index.sshtml", model];
            };
        }
    }
}