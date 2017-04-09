using Nancy;
using Nancy.Authentication.Forms;
using Nancy.ModelBinding;
using Nancy.Security;
using Paldi.Web.Models.Login;

namespace Paldi.Web.Modules
{
    public class LoginModule : NancyModule
    {
        public LoginModule(LoginRequestValidator validator)
        {
            Get["/login"] = _ => View["Index.cshtml", new LoginModel()];

            Get["/logout"] = _ => this.LogoutAndRedirect("/");

            Post["/login"] = parameters =>
            {
                this.ValidateCsrfToken();

                var request = this.Bind<LoginRequest>();
                if (validator.Validate(request).IsValid)
                {
                    return this.LoginAndRedirect(validator.LastGuid);
                }

                return View["Index.cshtml", new LoginModel {
                    HasError = true,
                    Login = request.Login,
                }];
            };
        }
    }
}