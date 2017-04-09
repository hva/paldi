using Nancy;

namespace Paldi.Web.Modules
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get["/"] = _ => View["Index.cshtml"];
        }
    }
}