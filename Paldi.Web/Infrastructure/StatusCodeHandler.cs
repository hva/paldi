using System;
using Nancy;
using Nancy.ErrorHandling;
using Nancy.ViewEngines;
using Paldi.Web.Models;

namespace Paldi.Web.Infrastructure
{
    public class StatusCodeHandler : IStatusCodeHandler
    {
        private readonly IViewRenderer viewRenderer;
        private readonly Func<NavigationModel> createModel;

        public StatusCodeHandler(IViewRenderer viewRenderer, Func<NavigationModel> createModel)
        {
            this.viewRenderer = viewRenderer;
            this.createModel = createModel;
        }

        public bool HandlesStatusCode(HttpStatusCode statusCode, NancyContext context)
        {
            return statusCode == HttpStatusCode.NotFound;
        }

        public void Handle(HttpStatusCode statusCode, NancyContext context)
        {
            var response = viewRenderer.RenderView(context, "404.sshtml", createModel().With(context));
            response.StatusCode = statusCode;
            context.Response = response;
        }
    }
}