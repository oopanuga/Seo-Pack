using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeoPack.Html.OpenGraph
{
    public abstract class OgMetadataAttribute: Attribute
    {
        protected OgMetadataAttribute(int displayOrder = 0)
        {
            DisplayOrder = displayOrder;
        }

        public int DisplayOrder { get; private set; }
    }
}
