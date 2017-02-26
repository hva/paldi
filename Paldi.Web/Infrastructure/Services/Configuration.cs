using System.Configuration;

namespace Paldi.Web.Infrastructure.Services
{
    public class Configuration : IConfiguration
    {
        public Configuration()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public string ConnectionString { get; }
    }
}