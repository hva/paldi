using System;
using Nancy;
using Paldi.Web.Models;

namespace Paldi.Web.Modules
{
    public class CatalogModule : NancyModule
    {
        public CatalogModule(Func<NavigationModel> createModel) : base("catalog")
        {
            Get["/"] = _ => View["Index.sshtml", createModel().Extend(Context)];

            Get["/{section}"] = _ => View["Index.sshtml", createModel().Extend(Context)];
        }
    }
}