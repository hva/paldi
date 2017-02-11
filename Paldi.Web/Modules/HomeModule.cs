using Nancy;
using Paldi.Web.Infrastructure.Extensions;

namespace Paldi.Web.Modules
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            this.AssignViewBag();

            Get["/"] = _ => View["Index.html"];
        }
    }
}