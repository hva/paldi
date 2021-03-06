﻿using System.Xml.Linq;

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

        public TagBuilder WithCssClass(string className)
        {
            var attr = tag.Attribute("class");
            if (attr == null)
            {
                tag.Add(new XAttribute("class", className));
            }
            else
            {
                attr.Value = string.Concat(attr.Value, " ", className);
            }
            return this;
        }

        public TagBuilder SetInnerText(string text)
        {
            tag.Value = text;
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