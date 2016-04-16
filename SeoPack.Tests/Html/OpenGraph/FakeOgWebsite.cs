using SeoPack.Html.OpenGraph;
using SeoPack.Html.OpenGraph.ObjectTypes.Standard;

namespace SeoPack.Tests.Html.OpenGraph
{
    public class FakeOgWebsite : Og
    {
        public FakeOgWebsite(string title, string url, OgImage[] images)
            : base(title, url, images, ObjectType.Website)
        {
        }
    }
}
