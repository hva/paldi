using Nancy;
using Paldi.Web.Data.Repositories;

namespace Paldi.Web.Infrastructure
{
    public static class ContextExtensions
    {
        private const string catalogRepositoryKey = "CatalogRepository";

        public static void SetCatalogRepository(this NancyContext context, ICatalogRepository catalogRepository)
        {
            context.Items[catalogRepositoryKey] = catalogRepository;
        }

        public static ICatalogRepository GetCatalogRepository(this NancyContext context)
        {
            object obj;
            context.Items.TryGetValue(catalogRepositoryKey, out obj);
            return obj as ICatalogRepository;
        }
    }
}