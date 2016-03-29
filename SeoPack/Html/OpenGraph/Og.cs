using System;
using System.Collections;
using System.Collections.Generic;

namespace SeoPack.Html.OpenGraph
{
    public abstract class Og
    {
        protected Og(string title, string url, OgImage image, ObjectType objectType)
        {
            if (string.IsNullOrEmpty(title))
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

            if (objectType == ObjectType.Unknown)
            {
                throw new ArgumentException("objectType cannot be Unknown");
            }

            Title = title;
            Url = url;
            Image = image;
            Type = objectType;
        }

        [OgProperty("title", 1)]
        public string Title { get; private set; }

        [OgProperty("type", 2)]
        public ObjectType Type { get; private set; }

        [OgProperty("url", 3)]
        public string Url { get; private set; }

        [OgStructuredProperty(4)]
        public OgImage Image { get; private set; }

        [OgProperty("audio", 5)]
        public string Audio { get; set; }

        [OgProperty("description", 6)]
        public string Description { get; set; }

        [OgProperty("determiner", 7)]
        public Determiner? Determiner { get; set; }

        [OgProperty("locale", 8)]
        public string Locale { get; set; }

        [OgProperty("locale:alternate", 9)]
        public IEnumerable<string> AlternateLocales { get; set; }

        [OgProperty("site_name", 10)]
        public string SiteName { get; set; }

        [OgProperty("video", 11)]
        public string Video { get; set; }
    }
}
