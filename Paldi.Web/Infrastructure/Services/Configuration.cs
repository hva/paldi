using System.Configuration;

namespace Paldi.Web.Infrastructure.Services
{
    public class Configuration : IConfiguration
    {
        public Configuration()
        {
            ConnectionString = ConfigurationManager.AppSettings["MySQL"];
        }

        public string ConnectionString { get; }
    }
}