using Nancy;

namespace Paldi.Web.Modules
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            After += ctx => ctx.ViewBag.Title = "Палди";

            Get["/"] = parameters => View["index"];
        }
    }
}