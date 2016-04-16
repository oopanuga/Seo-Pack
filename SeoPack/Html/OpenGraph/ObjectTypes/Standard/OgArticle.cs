using System;
using System.Collections.Generic;

namespace SeoPack.Html.OpenGraph.ObjectTypes.Standard
{
    /// <summary>
    /// This object represents an article on a website. It is the preferred type for blog posts and news stories.
    /// </summary>
    /// <seealso cref="Og" />
    public class OgArticle : Og
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OgArticle"/> class.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="url">The URL.</param>
        /// <param name="images">The images.</param>
        public OgArticle(string title, string url, OgImage[] images)
            : base(title, url, images, ObjectType.Article)
        {
        }

        /// <summary>
        /// Gets or sets an array of profile URLs or IDs of the authors for this article.
        /// </summary>
        /// <value>
        /// The author urls.
        /// </value>
        [OgProperty("article:author")]
        public IEnumerable<string> AuthorUrls { get; set; }

        /// <summary>
        /// Gets or sets a time representing when the article expired (or will expire).
        /// </summary>
        /// <value>
        /// The expiration time.
        /// </value>
        [OgProperty("article:expiration_time")] 
        public DateTime? ExpirationTime { get; set; }

        /// <summary>
        /// Gets or sets a time representing when the article was last modified.
        /// </summary>
        /// <value>
        /// The modified time.
        /// </value>
        [OgProperty("article:modified_time")]
        public DateTime? ModifiedTime { get; set; }

        /// <summary>
        /// Gets or sets a time representing when the article was published.
        /// </summary>
        /// <value>
        /// The published time.
        /// </value>
        [OgProperty("article:published_time")]
        public DateTime? PublishedTime { get; set; }

        /// <summary>
        /// Gets or sets a page URL or ID of the publishing entity.
        /// </summary>
        /// <value>
        /// The publisher URL.
        /// </value>
        [OgProperty("article:publisher")]
        public string PublisherUrl { get; set; }

        /// <summary>
        /// Gets or sets the section of your website to which the article belongs, such as 'Lifestyle' or 'Sports'.
        /// </summary>
        /// <value>
        /// The section.
        /// </value>
        [OgProperty("article:section")]
        public string Section { get; set; }

        /// <summary>
        /// Gets or sets an array of keywords relevant to the article.
        /// </summary>
        /// <value>
        /// The tags.
        /// </value>
        [OgProperty("article:tag")]
        public IEnumerable<string> Tags { get; set; }
    }
}
      