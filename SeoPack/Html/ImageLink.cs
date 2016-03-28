using System;

namespace SeoPack.Html
{
    public class ImageLink : AnchorBase
    {
        public ImageLink(string href, Image image, bool noFollow = false, object attributes = null)
            : base(href, noFollow, attributes)
        {
            if (image == null)
            {
                throw new ArgumentNullException("image");
            }

            Image = image;
        }

        public Image Image { get; private set; }
    }
}
