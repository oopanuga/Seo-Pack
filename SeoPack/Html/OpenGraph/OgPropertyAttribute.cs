using System;

namespace SeoPack.Html.OpenGraph
{
    [AttributeUsage(AttributeTargets.Property)]
    public class OgPropertyAttribute : Attribute
    {
        public OgPropertyAttribute(string name)
        {
            if(string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("name not set");
            }

            Name = string.Format("og:{0}", name.Replace("og:", ""));
        }
        public string Name { get; private set; }
    }
}
