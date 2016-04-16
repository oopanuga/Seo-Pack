
namespace SeoPack.Html.OpenGraph.ObjectTypes.Standard
{
    /// <summary>
    /// This object represents a website.
    /// </summary>
    /// <seealso cref="Og" />
    public class Website : Og
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Website"/> class.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="url">The URL.</param>
        /// <param name="images">The images.</param>
        public Website(string title, string url, OgImage[] images)
            : base(title, url, images, ObjectType.Website)
        {
        }
    }
}
