using System;

namespace SeoPack.Html
{
    public class Anchor : AnchorBase
    {
        public Anchor(string href, string text, bool noFollow = false, object attributes = null)
            : base(href, noFollow, attributes)
        {
            if (string.IsNullOrEmpty(text))
            {
                throw new ArgumentException("text not set");
            }

            Text = text;
        }

        public string Text { get; private set; }
    }
}
