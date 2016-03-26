using SeoPack.Html.OpenGraph.StructuredProperties;
using System;

namespace SeoPack.Html.OpenGraph.ObjectTypes.Standard
{
    public class Website : Og
    {
        public Website(string title, Uri url, OgImage image)
            : base(title, url, image, ObjectType.Website)
        {
        }
    }
}
