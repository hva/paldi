using System.Collections.Generic;
using Paldi.Web.Data.Entities;

namespace Paldi.Web.Data.Repositories
{
    public interface ICatalogRepository
    {
        bool TryFindSection(string slug, out CatalogSection section);
        IEnumerable<CatalogSection> GetSections();
    }
}