using System.Xml.Linq;

namespace Paldi.Web.ViewHelpers
{
    public class TagBuilder
    {
        private readonly XElement tag;

        public TagBuilder(string tagName)
        {
            tag = new XElement(tagName);
        }

        public override string ToString()
        {
            return tag.ToString();
        }

        public XElement ToXElement()
        {
            return tag;
        }

        public TagBuilder WithAttribute(string name, string value)
        {
            tag.Add(new XAttribute(name, value ?? string.Empty));
            return this;
        }

        public TagBuilder WithCssClass(string name)
        {
            tag.Add(new XAttribute("class", name));
            return this;
        }


        public TagBuilder Add(TagBuilder inner)
        {
            tag.Add(inner.ToXElement());
            return this;
        }

        public TagBuilder DecorateWith(TagBuilder outer)
        {
            var inner = ToXElement();
            outer.ToXElement().Add(inner);
            return outer;
        }
    }
}