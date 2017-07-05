using System.Collections.Generic;
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

        public Form(KeyValuePair<string, string> token) : this()
        {
            var input = new TagBuilder("input")
                .WithAttribute("type", "hidden")
                .WithAttribute("name", token.Key)
                .WithAttribute("value", token.Value)
            ;
            form.Add(input);
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
                .WithAttribute("placeholder", placeholder)
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

        public Form WithPassword(string name, string placeholder)
        {
            var input = new TagBuilder("input")
                .WithAttribute("type", "password")
                .WithAttribute("name", name)
                .WithAttribute("placeholder", placeholder)
                .WithCssClass("form-control")
            ;

            var formGroup = DecorateWithFormGroup(input);
            form.Add(formGroup);
            return this;
        }

        public Form WithSubmit(string text)
        {
            var input = new TagBuilder("button")
                .WithAttribute("type", "submit")
                .WithCssClass("btn btn-primary")
                .SetInnerText(text)
            ;

            var formGroup = DecorateWithFormGroup(input);
            form.Add(formGroup);
            return this;
        }

        private static TagBuilder DecorateWithFormGroup(TagBuilder inner)
        {
            var div1 = new TagBuilder("div").WithCssClass("col-xs-12 col-sm-4");
            var div2 = new TagBuilder("div").WithCssClass("form-group");
            return inner.DecorateWith(div1).DecorateWith(div2);
        }
    }
}