using System;

namespace SeoPack.Html
{
    public class AnchorBase
    {
        protected AnchorBase(string href, bool noFollow = false, object attributes = null)
        {
            if (string.IsNullOrEmpty(href))
            {
                throw new ArgumentException("href not set");
            }

            Href = href;
            Attributes = attributes;
            NoFollow = noFollow;
        }

        public string Href { get; private set; }
        public object Attributes { get; set; }
        public string Title { get; set; }
        public bool NoFollow { get; set; }
    }
}
