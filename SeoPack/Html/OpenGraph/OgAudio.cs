using System;

namespace SeoPack.Html.OpenGraph
{
    public class OgAudio
    {
        public OgAudio(Uri url)
        {
            Url = url;
        }

        [OgProperty("audio")]
        public Uri Url { get; private set; }

        [OgProperty("audio:secure_url")]
        public Uri SecureUrl { get; private set; }

        [OgProperty("audio:type")]
        public string ImageType { get; set; }

        public override string ToString()
        {
            return Url.AbsoluteUri;
        }
    }
}
