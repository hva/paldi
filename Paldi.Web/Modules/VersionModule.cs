using System.Diagnostics;
using System.Reflection;
using Nancy;

namespace Paldi.Web.Modules
{
    public class VersionModule : NancyModule
    {
        public VersionModule() : base("api/version")
        {
            Get["/"] = Index;
        }

        private object Index(object arg)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var info = FileVersionInfo.GetVersionInfo(assembly.Location);
            var data = new
            {
                version = info.FileVersion,
                build = info.ProductVersion,
            };
            return Response.AsJson(data);
        }
    }
}