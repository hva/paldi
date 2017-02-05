using System.Configuration;

namespace Paldi.Web.Infrastructure
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