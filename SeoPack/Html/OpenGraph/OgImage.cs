using System;

namespace SeoPack.Html.OpenGraph
{
    public class OgImage : IMediaProperty
    {
        public OgImage(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentException("url not set");
            }

            Url = url;
        }

        [OgProperty("image")]
        public string Url { get; private set; }

        [OgProperty("image:secure_url")]
        public string SecureUrl { get; set; }

        [OgProperty("image:type")]
        public string Type { get; set; }

        [OgProperty("image:width")]
        public int Width { get; set; }

        [OgProperty("image:height")]
        public int Height { get; set; }

        public override string ToString()
        {
            return Url;
        }
    }
}
