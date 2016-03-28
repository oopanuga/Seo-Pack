using System;

namespace SeoPack.Html.OpenGraph.ObjectTypes.Standard
{
    public class Website : Og
    {
        public Website(string title, string url, OgImage image)
            : base(title, url, image, ObjectType.Website)
        {
        }
    }
}
