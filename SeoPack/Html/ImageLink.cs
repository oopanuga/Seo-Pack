using System;

namespace SeoPack.Html
{
    public class ImageLink
    {
        public ImageLink(string linkHref, Image image, object linkAttributes = null)
        {
            if(string.IsNullOrEmpty(linkHref))
            {
                throw new ArgumentException("linkHref not set");
            }

            if (image == null)
            {
                throw new ArgumentNullException("image");
            }

            LinkHref = linkHref;
            LinkAttributes = linkAttributes;
            Image = image;
        }

        public string LinkHref { get; private set; }
        public string LinkTitle { get; set; }
        public object LinkAttributes { get; set; }
        public Image Image { get; private set; }
    }
}
