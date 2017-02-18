using Nancy;

namespace Paldi.Web.Infrastructure.Extensions
{
    public static class ViewBagExtensions
    {
        public static void AssignViewBag(this INancyModule module)
        {
            module.After += context =>
            {
            };
        }
    }
}