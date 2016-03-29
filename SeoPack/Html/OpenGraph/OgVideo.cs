using System;

namespace SeoPack.Html.OpenGraph
{
    public class OgVideo : IMediaProperty
    {
        public OgVideo(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentException("url not set");
            }

            Url = url;
        }

        [OgProperty("video")]
        public string Url { get; private set; }

        [OgProperty("video:secure_url")]
        public string SecureUrl { get; set; }

        [OgProperty("video:type")]
        public string Type { get; set; }

        [OgProperty("video:width")]
        public int Width { get; set; }

        [OgProperty("video:height")]
        public int Height { get; set; }

        public override string ToString()
        {
            return Url;
        }
    }
}
