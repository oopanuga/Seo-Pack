using System;

namespace SeoPack.Html.OpenGraph
{
    [AttributeUsage(AttributeTargets.Property, Inherited = true, AllowMultiple = false)]
    public class OgPropertyAttribute : OgMetadataAttribute
    {
        public OgPropertyAttribute(string name, int displayOrder = 0)
            : base(displayOrder)
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
