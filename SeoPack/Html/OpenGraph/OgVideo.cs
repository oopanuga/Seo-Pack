using System;

namespace SeoPack.Html.OpenGraph
{
    public class OgVideo
    {
        public OgVideo(Uri url)
        {
            Url = url;
        }

        [OgProperty("video")]
        public Uri Url { get; private set; }

        [OgProperty("video:secure_url")]
        public Uri SecureUrl { get; private set; }

        [OgProperty("video:type")]
        public string ImageType { get; set; }

        [OgProperty("video:width")]
        public int Width { get; set; }

        [OgProperty("video:height")]
        public int Height { get; set; }

        public override string ToString()
        {
            return Url.AbsoluteUri;
        }
    }
}
