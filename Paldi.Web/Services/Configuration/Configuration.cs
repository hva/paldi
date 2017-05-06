using System.Configuration;

namespace Paldi.Web.Services.Configuration
{
    public class Config : IConfig
    {
        public Config()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public string ConnectionString { get; }
    }
}