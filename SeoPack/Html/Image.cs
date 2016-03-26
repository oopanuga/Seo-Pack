using System;

namespace SeoPack.Html
{
    public class Image
    {
        public Image(string src, string altText, object attributes = null)
        {
            if(string.IsNullOrEmpty(src))
            {
                throw new ArgumentException("src not set");
            }

            if (string.IsNullOrEmpty(altText))
            {
                throw new ArgumentException("altText not set");
            }

            Src = src;
            AltText = altText;
            Attributes = attributes;
        }

        public string Src { get; private set; }
        public string AltText { get; private set; }
        public object Attributes { get; set; }
    }
}
