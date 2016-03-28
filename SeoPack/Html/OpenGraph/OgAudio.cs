using System;

namespace SeoPack.Html.OpenGraph
{
    public class OgAudio
    {
        public OgAudio(string url)
        {
            Url = url;
        }

        [OgProperty("audio")]
        public string Url { get; private set; }

        [OgProperty("audio:secure_url")]
        public string SecureUrl { get; private set; }

        [OgProperty("audio:type")]
        public string ImageType { get; set; }

        public override string ToString()
        {
            return Url;
        }
    }
}
