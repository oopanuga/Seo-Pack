using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeoPack.Html
{
    public class HtmlElement
    {
        List<HtmlAttribute> attributes;

        public HtmlElement(string elementName)
        {
            if (string.IsNullOrEmpty(elementName))
            {
                throw new ArgumentException("elementName not set");
            }

            Name = elementName;
            attributes = new List<HtmlAttribute>();
        }

        public string Name { get; private set; }

        public string InnerText { get; set; }

        public string InnerHtml { get; set; }

        public void AddAttribute(string name, string value)
        {
            attributes.Add(new HtmlAttribute(name, value));
        }

        public void SetInnerText(string innerText)
        {
            if (string.IsNullOrEmpty(innerText))
                throw new ArgumentException("innerText not set");

            InnerText = innerText;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendFormat("<{0}{1}", Name, attributes.Count > 0 ? " " : "");

            for (int i = 0; i < attributes.Count; i++)
            {
                stringBuilder.AppendFormat("{0}=\"{1}\"{2}",
                    attributes[i].Name,
                    attributes[i].Value,
                    i == (attributes.Count - 1) ? "" : " ");
            }

            if (!string.IsNullOrEmpty(InnerText))
            {
                stringBuilder.AppendFormat(">{0}", InnerText);
                stringBuilder.AppendFormat("</{0}>", Name);
            }
            else if (!string.IsNullOrEmpty(InnerHtml))
            {
                stringBuilder.AppendFormat(">{0}", InnerHtml);
                stringBuilder.AppendFormat("</{0}>", Name);
            }
            else
            {
                if (attributes.Any(x => x.Name.ToLower().Equals("content")))
                    stringBuilder.Append(">");
                else
                    stringBuilder.Append(" />");
            }

            return stringBuilder.ToString();
        }

        private class HtmlAttribute
        {
            public HtmlAttribute(string name, string value)
            {
                if (string.IsNullOrEmpty(name))
                {
                    throw new ArgumentException("name not set");
                }

                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("value not set");
                }

                Name = name;
                Value = value;
            }

            public string Name { get; private set; }
            public string Value { get; private set; }
        }
    }
}
