using Nancy;
using Paldi.Web.Data.Entities;
using Paldi.Web.Data.Repos.Interfaces;

namespace Paldi.Web.Modules
{
    public class CatalogModule : NancyModule
    {
        public CatalogModule(ICatalogRepository catalogRepository)
            : base("catalog")
        {
            Get["/"] = _ => View["Index.cshtml"];

            Get["/{section}"] = parameters =>
            {
                CatalogSection section;
                if (!catalogRepository.TryFindSection(parameters.Section, out section))
                {
                    return HttpStatusCode.NotFound;
                }

                return View["Section.cshtml", section];
            };
        }
    }
}