using System;
using Nancy;
using Nancy.Authentication.Forms;
using Nancy.ModelBinding;
using Nancy.Security;
using Paldi.Web.Models;
using Paldi.Web.Models.Login;

namespace Paldi.Web.Modules
{
    public class LoginModule : NancyModule
    {
        public LoginModule(Func<BaseModel> createModel, LoginRequestValidator validator)
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
                if (validator.Validate(request).IsValid)
                {
                    return this.LoginAndRedirect(validator.LastGuid);
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