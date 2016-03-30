using SeoPack.Html.OpenGraph;

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
