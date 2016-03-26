using System;

namespace SeoPack.Html.OpenGraph
{
    [AttributeUsage(AttributeTargets.Property)]
    public class OgPropertyAttribute : Attribute
    {
        public OgPropertyAttribute(string name)
        {
            Name = string.Format("og:{0}", name.Replace("og:", ""));
        }
        public string Name { get; private set; }
    }
}
