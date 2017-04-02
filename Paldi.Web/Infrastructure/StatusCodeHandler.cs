using Nancy;
using Nancy.ErrorHandling;
using Nancy.ViewEngines;
using Paldi.Web.Data.Repos.Interfaces;
using Paldi.Web.Models;

namespace Paldi.Web.Infrastructure
{
    public class StatusCodeHandler : IStatusCodeHandler
    {
        private readonly IViewRenderer viewRenderer;
        private readonly ICatalogRepository catalogRepository;

        public StatusCodeHandler(IViewRenderer viewRenderer, ICatalogRepository catalogRepository)
        {
            this.viewRenderer = viewRenderer;
            this.catalogRepository = catalogRepository;
        }

        public bool HandlesStatusCode(HttpStatusCode statusCode, NancyContext context)
        {
            return statusCode == HttpStatusCode.NotFound;
        }

        public void Handle(HttpStatusCode statusCode, NancyContext context)
        {
            var response = viewRenderer.RenderView(context, "404.cshtml", new BaseModel(context.CurrentUser, catalogRepository));
            response.StatusCode = statusCode;
            context.Response = response;
        }
    }
}