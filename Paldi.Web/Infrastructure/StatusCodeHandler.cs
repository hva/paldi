﻿using Nancy;
using Nancy.ErrorHandling;
using Nancy.ViewEngines;

namespace Paldi.Web.Infrastructure
{
    public class StatusCodeHandler : IStatusCodeHandler
    {
        private readonly IViewRenderer viewRenderer;

        public StatusCodeHandler(IViewRenderer viewRenderer)
        {
            this.viewRenderer = viewRenderer;
        }

        public bool HandlesStatusCode(HttpStatusCode statusCode, NancyContext context)
        {
            return statusCode == HttpStatusCode.NotFound;
        }

        public void Handle(HttpStatusCode statusCode, NancyContext context)
        {
            var response = viewRenderer.RenderView(context, "404.cshtml");
            response.StatusCode = statusCode;
            context.Response = response;
        }
    }
}