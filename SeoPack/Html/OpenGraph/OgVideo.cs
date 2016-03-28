using System;

namespace SeoPack.Html.OpenGraph
{
    public class OgVideo
    {
        public OgVideo(string url)
        {
            Url = url;
        }

        [OgProperty("video")]
        public string Url { get; private set; }

        [OgProperty("video:secure_url")]
        public string SecureUrl { get; private set; }

        [OgProperty("video:type")]
        public string ImageType { get; set; }

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
