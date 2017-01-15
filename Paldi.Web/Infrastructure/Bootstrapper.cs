using Nancy;
using Nancy.Authentication.Forms;
using Nancy.Bootstrapper;
using Nancy.TinyIoc;

namespace Paldi.Web.Infrastructure
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {
            var formsAuthConfiguration =
                new FormsAuthenticationConfiguration()
                {
                    RedirectUrl = "~/login",
                    UserMapper = container.Resolve<IUserMapper>(),
                };

            FormsAuthentication.Enable(pipelines, formsAuthConfiguration);

            base.ApplicationStartup(container, pipelines);
        }

        protected override void RequestStartup(TinyIoCContainer container, IPipelines pipelines, NancyContext context)
        {
            context.ViewBag.Title = "Палди";

            base.RequestStartup(container, pipelines, context);
        }
    }
}