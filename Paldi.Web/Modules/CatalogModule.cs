using System;
using Nancy;
using Paldi.Web.Data.Entities;
using Paldi.Web.Data.Repos.Interfaces;
using Paldi.Web.Models;

namespace Paldi.Web.Modules
{
    public class CatalogModule : NancyModule
    {
        public CatalogModule(Func<BaseModel> createModel, ICatalogRepository catalogRepository)
            : base("catalog")
        {
            Get["/"] = _ => View["Index.sshtml", createModel()];

            Get["/{section}"] = parameters =>
            {
                CatalogSection section;
                if (!catalogRepository.TryFindSection(parameters.Section, out section))
                {
                    return HttpStatusCode.NotFound;
                }

                return View["Section.sshtml", createModel()];
            };
        }
    }
}