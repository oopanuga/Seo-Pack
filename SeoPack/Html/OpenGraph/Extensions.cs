using System;
using System.Reflection;

namespace SeoPack.Html.OpenGraph
{
    internal static class Extensions
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
