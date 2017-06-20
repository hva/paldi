using Nancy.ViewEngines.Razor;

namespace Paldi.Web.ViewHelpers
{
    public class Form : IHtmlString
    {
        private readonly TagBuilder form;

        public Form()
        {
            form = new TagBuilder("form")
                .WithAttribute("method", "POST")
                .WithCssClass("form-horizontal")
            ;
        }

        public string ToHtmlString()
        {
            return form.ToString();
        }

        public Form WithText(string name, string value, string placeholder, bool autofocus = false)
        {
            var input = new TagBuilder("input")
                .WithAttribute("type", "text")
                .WithAttribute("name", name)
                .WithAttribute("value", value)
                .WithAttribute(placeholder, "autofocus")
                .WithCssClass("form-control")
            ;

            if (autofocus)
            {
                input.WithAttribute("autofocus", "autofocus");
            }

            var formGroup = DecorateWithFormGroup(input);
            form.Add(formGroup);
            return this;
        }

        private static TagBuilder DecorateWithFormGroup(TagBuilder inner)
        {
            var div1 = new TagBuilder("div").WithCssClass("col-xs-12 col-md-4");
            var div2 = new TagBuilder("div").WithCssClass("form-group");
            return inner.DecorateWith(div1).DecorateWith(div2);
        }
    }
}