using System;

namespace SeoPack.Html.OpenGraph
{
    public class OgAudio : IMediaProperty
    {
        public OgAudio(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentException("url not set");
            }

            Url = url;
        }

        [OgProperty("audio")]
        public string Url { get; private set; }

        [OgProperty("audio:secure_url")]
        public string SecureUrl { get; set; }

        [OgProperty("audio:type")]
        public string Type { get; set; }
    }
}
