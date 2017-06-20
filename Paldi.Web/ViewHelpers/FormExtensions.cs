using Nancy.ViewEngines.Razor;

namespace Paldi.Web.ViewHelpers
{
    public static class FormExtensions
    {
        public static Form Form(this HtmlHelpers helpers)
        {
            return new Form();
        }
    }
}