using System;
using Nancy;
using Nancy.Authentication.Forms;
using Nancy.ModelBinding;
using Nancy.Security;
using Paldi.Web.Data.Repos.Interfaces;
using Paldi.Web.Models;
using Paldi.Web.Models.Login;

namespace Paldi.Web.Modules
{
    public class LoginModule : NancyModule
    {
        public LoginModule(IUsersRepository usersRepository, Func<BaseModel> createModel)
        {
            Get["/login"] = _ => View[
                "Index.sshtml",
                createModel().With(new LoginModel())
            ];

            Get["/logout"] = _ => this.LogoutAndRedirect("/");

            Post["/login"] = parameters =>
            {
                this.ValidateCsrfToken();

                var request = this.Bind<LoginRequest>();
                if (!string.IsNullOrEmpty(request.Password))
                {
                    Guid guid;
                    if (usersRepository.TryLogin(request.Login, request.Password, out guid))
                    {
                        return this.LoginAndRedirect(guid);
                    }
                }

                return View[
                    "Index.sshtml",
                    createModel().With(new LoginModel
                    {
                        HasError = true,
                        Login = request.Login
                    })
                ];
            };
        }
    }
}