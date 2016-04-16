using System;
using System.Collections.Generic;

namespace SeoPack.Html.OpenGraph.ObjectTypes.Standard
{
    /// <summary>
    /// This object type represents a book or publication. This is an appropriate 
    /// type for ebooks, as well as traditional paperback or hardback books
    /// </summary>
    /// <seealso cref="Og" />
    public class OgBook : Og
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OgBook"/> class.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="url">The URL.</param>
        /// <param name="images">The images.</param>
        public OgBook(string title, string url, OgImage[] images)
            : base(title, url, images, ObjectType.Book)
        {
        }

        /// <summary>
        /// Gets or sets an array of urls to the objects representing the authors of the book.
        /// </summary>
        /// <value>
        /// The author URL.
        /// </value>
        [OgProperty("book:author")]
        public string AuthorUrl { get; set; }

        /// <summary>
        /// Gets or sets the International Standard Book Number (ISBN) for the book.
        /// </summary>
        /// <value>
        /// The isbn.
        /// </value>
        [OgProperty("book:isbn")]
        public string Isbn { get; set; }

        /// <summary>
        /// Gets or sets a time representing when the book was released.
        /// </summary>
        /// <value>
        /// The release date.
        /// </value>
        [OgProperty("book:release_date")]
        public DateTime? ReleaseDate { get; set; }

        /// <summary>
        /// Gets or sets tag words associated with this book.
        /// </summary>
        /// <value>
        /// The tags.
        /// </value>
        [OgProperty("book:tag")]
        public IEnumerable<string> Tags { get; set; }
    }
}
