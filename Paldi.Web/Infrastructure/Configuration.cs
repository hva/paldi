using System.Configuration;

namespace Paldi.Web.Infrastructure
{
    public class Configuration : IConfiguration
    {
        public Configuration()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
        }

        public string ConnectionString { get; }
    }
}