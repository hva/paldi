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
        public LoginModule(IUsersRepository usersRepository, Func<LoginModel> createModel)
        {
            Get["/login"] = _ => View["Index.sshtml", createModel()];

            Get["/logout"] = _ => this.LogoutAndRedirect("/");

            Post["/login"] = parameters =>
            {
                this.ValidateCsrfToken();

                var model = createModel();
                this.BindTo(model);

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