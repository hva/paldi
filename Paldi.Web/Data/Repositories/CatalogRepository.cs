using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Dapper;
using MySql.Data.MySqlClient;
using Paldi.Web.Data.Entities;

namespace Paldi.Web.Data.Repositories
{
    public class CatalogRepository : ICatalogRepository
    {
        private readonly string connectionString;

        public CatalogRepository()
        {
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public bool TryFindSection(string slug, out CatalogSection section)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                section = connection.QueryFirstOrDefault<CatalogSection>(
                    "SELECT guid, slug, name FROM catalog_sections WHERE slug = @Slug",
                    new { Slug = slug }
                );
                return section != null;
            }
        }

        public IEnumerable<CatalogSection> GetSections()
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                return connection.Query<CatalogSection>("SELECT guid, slug, name FROM catalog_sections").ToArray();
            }
        }
    }
}