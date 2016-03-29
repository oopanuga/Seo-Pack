using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SeoPack.Html.OpenGraph
{
    static class Extensions
    {
        public static int OgMetadataOrder(this PropertyInfo propInfo)
        {
            var orderAttr = propInfo.GetCustomAttributes(
                typeof(OgMetadataAttribute), false) as OgMetadataAttribute[];

            if (orderAttr != null && orderAttr.Length > 0)
            {
                return orderAttr[0].DisplayOrder;
            }
            else
            {
                return Int32.MaxValue;
            }
        }

        public static bool IsOgMetadata(this PropertyInfo propInfo)
        {
            var orderAttr = propInfo.GetCustomAttributes(
                typeof(OgMetadataAttribute), false) as OgMetadataAttribute[];
            return orderAttr != null && orderAttr.Length > 0;
        }
    }
}
