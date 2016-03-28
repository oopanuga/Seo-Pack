using System;

namespace SeoPack.Html.OpenGraph
{
    public class OgImage
    {
        public OgImage(string url)
        {
            Url = url;
        }

        [OgProperty("image")]
        public string Url { get; private set; }

        [OgProperty("image:secure_url")]
        public string SecureUrl { get; private set; }

        [OgProperty("image:type")]
        public string ImageType { get; set; }

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
