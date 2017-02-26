using Nancy;
using Nancy.Authentication.Forms;
using Nancy.Bootstrapper;
using Nancy.Security;
using Nancy.TinyIoc;

namespace Paldi.Web.Infrastructure
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {
            Csrf.Enable(pipelines);

            FormsAuthentication.Enable(pipelines, new FormsAuthenticationConfiguration
            {
                RedirectUrl = "~/login",
                UserMapper = container.Resolve<IUserMapper>(),
            });

            base.ApplicationStartup(container, pipelines);
        }
    }
}