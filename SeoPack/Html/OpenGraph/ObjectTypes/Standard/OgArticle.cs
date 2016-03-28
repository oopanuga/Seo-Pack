using System;
using System.Collections.Generic;

namespace SeoPack.Html.OpenGraph.ObjectTypes.Standard
{
    public class OgArticle : Og
    {
        public OgArticle(string title, string url, OgImage image)
            : base(title, url, image, ObjectType.Article)
        {
        }

        [OgProperty("article:author")]
        public IEnumerable<string> AuthorUrls { get; set; }

        [OgProperty("article:expiration_time")] 
        public DateTime? ExpirationTime { get; set; }

        [OgProperty("article:modified_time")]
        public DateTime? ModifiedTime { get; set; }

        [OgProperty("article:published_time")]
        public DateTime? PublishedTime { get; set; }

        [OgProperty("article:publisher")]
        public string PublisherUrl { get; set; }

        [OgProperty("article:section")]
        public string Section { get; set; }

        [OgProperty("article:tag")]
        public IEnumerable<string> Tags { get; set; }
    }
}
      