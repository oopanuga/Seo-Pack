
using System;
namespace SeoPack.Html.OpenGraph
{
    public class OgProperty
    {
        public OgProperty(string name, string value)
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
