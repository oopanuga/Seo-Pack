using System;

namespace SeoPack.Html.OpenGraph
{
    [AttributeUsage(AttributeTargets.Property, Inherited = true, AllowMultiple = false)]
    public class OgStructuredPropertyAttribute : OgMetadataAttribute
    {
        public OgStructuredPropertyAttribute(int displayOrder = 0)
            : base(displayOrder)
        {

        }
    }
}
