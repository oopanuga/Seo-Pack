using System;
using System.Collections.Generic;

namespace SeoPack.Html.OpenGraph.ObjectTypes.Standard
{
    public class OgBook : Og
    {
        public OgBook(string title, Uri url, OgImage image)
            : base(title, url, image, ObjectType.Book)
        {
        }

        [OgProperty("book:author")]
        public Uri AuthorUrl { get; set; }

        [OgProperty("book:isbn")]
        public string ISBN { get; set; }

        [OgProperty("book:release_date")]
        public DateTime? ReleaseDate { get; set; }

        [OgProperty("book:tag")]
        public IEnumerable<string> Tags { get; set; }
    }
}
