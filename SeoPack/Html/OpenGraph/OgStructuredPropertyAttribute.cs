using System;

namespace SeoPack.Html.OpenGraph
{
    [AttributeUsage(AttributeTargets.Property)]
    public class OgStructuredPropertyAttribute : OgMetadataAttribute
    {
        public OgStructuredPropertyAttribute(int displayOrder = 0)
            : base(displayOrder)
        {

        }
    }
}
