using System;

namespace SeoPack.Html
{
    public class Anchor
    {
        public Anchor(string href, string text, bool noFollow = false, object attributes = null)
        {
            if (string.IsNullOrEmpty(href))
            {
                throw new ArgumentException("href not set");
            }


            if (string.IsNullOrEmpty(text))
            {
                throw new ArgumentException("text not set");
            }

            Href = href;
            Text = text;
            Attributes = attributes;
            NoFollow = noFollow;
        }

        internal Anchor(string href, object attributes = null)
        {
            if (string.IsNullOrEmpty(href))
            {
                throw new ArgumentException("href not set");
            }

            Href = href;
            Attributes = attributes;
        }

        public string Href { get; private set; }
        public string Text { get; private set; }
        public object Attributes { get; set; }
        public string Title { get; set; }
        public bool NoFollow { get; set; }

        public static explicit operator Anchor(ImageLink imageLink)
        {
            return new Anchor(imageLink.LinkHref, imageLink.LinkAttributes);
        }
    }
}
