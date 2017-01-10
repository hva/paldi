using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Paldi.Web.Startup))]

namespace Paldi.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseNancy();
        }
    }
}
