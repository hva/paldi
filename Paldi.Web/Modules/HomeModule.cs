using System;
using Nancy;
using Paldi.Web.Models;

namespace Paldi.Web.Modules
{
    public class HomeModule : NancyModule
    {
        public HomeModule(Func<NavigationModel> createModel)
        {
            Get["/"] = _ => View["Index.sshtml", createModel().Extend(Context)];
        }
    }
}