using System;

namespace SeoPack.Html.OpenGraph
{
    public abstract class Og
    {
        protected Og(string title, string url, OgImage image, ObjectType objectType)
        {
            if(string.IsNullOrEmpty(title))
            {
                throw new ArgumentException("title not set");
            }

            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentException("url not set");
            }

            if (image == null)
            {
                throw new ArgumentNullException("image");
            }

            Title = title;
            Url = url;
            Image = image;
            Type = objectType;
        }

        [OgProperty("title")]
        public string Title { get; private set; }

        [OgProperty("type")]
        protected ObjectType Type { get; private set; }

        [OgProperty("image")]
        public OgImage Image { get; private set; }

        [OgProperty("url")]
        public string Url { get; private set; }

        [OgProperty("audio")]
        public string Audio { get; set; }

        [OgProperty("description")]
        public string Description { get; set; }

        [OgProperty("determiner")]
        public Determiner Determiner { get; set; }
    }
}
