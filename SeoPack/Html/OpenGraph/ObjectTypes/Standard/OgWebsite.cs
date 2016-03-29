
namespace SeoPack.Html.OpenGraph.ObjectTypes.Standard
{
    public class Website : Og
    {
        public Website(string title, string url, OgImage[] images)
            : base(title, url, images, ObjectType.Website)
        {
        }
    }
}
