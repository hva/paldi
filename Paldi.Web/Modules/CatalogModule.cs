using System;
using Nancy;
using Paldi.Web.Data.Entities;
using Paldi.Web.Data.Repos.Interfaces;
using Paldi.Web.Models;

namespace Paldi.Web.Modules
{
    public class CatalogModule : NancyModule
    {
        public CatalogModule(Func<NavigationModel> createModel, ICatalogRepository catalogRepository)
            : base("catalog")
        {
            Get["/"] = _ => View["Index.sshtml", createModel().With(Context)];

            Get["/{section}"] = parameters =>
            {
                CatalogSection section;
                if (!catalogRepository.TryFindSection(parameters.Section, out section))
                {
                    return HttpStatusCode.NotFound;
                }

                var model = createModel().With(Context).With("Section", section);
                return View["Section.sshtml", model];
            };
        }
    }
}