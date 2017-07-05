using Nancy.ViewEngines.Razor;

namespace Paldi.Web.ViewHelpers
{
    public static class FormExtensions
    {
        public static Form Form(this HtmlHelpers helpers, bool withAntiForgeryToken)
        {
            if (withAntiForgeryToken)
            {
                var token = helpers.RenderContext.GetCsrfToken();
                return new Form(token);
            }

            return new Form();
        }
    }
}