using System;
using System.Collections.Generic;
using System.Linq;

namespace SeoPack.Html.OpenGraph.ObjectTypes.Standard
{
    /// <summary>
    /// This object represents the base for a standard open graph object type. It comprises 
    /// both basic and optional metadata.
    /// </summary>
    public abstract class Og
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Og"/> class.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <param name="url">The URL.</param>
        /// <param name="images">The images.</param>
        /// <param name="objectType">Type of the object.</param>
        /// <exception cref="System.ArgumentException">
        /// title not set
        /// or
        /// url not set
        /// or
        /// objectType cannot be Unknown
        /// </exception>
        /// <exception cref="System.ArgumentNullException">images</exception>
        protected Og(string title, string url, OgImage[] images, ObjectType objectType)
        {
            if (string.IsNullOrEmpty(title))
            {
                throw new ArgumentException("title not set");
            }

            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentException("url not set");
            }

            if (images == null || !images.Any())
            {
                throw new ArgumentNullException("images");
            }

            if (objectType == ObjectType.Unknown)
            {
                throw new ArgumentException("objectType cannot be Unknown");
            }

            Title = title;
            Url = url;
            Images = images;
            Type = objectType;
        }

        /// <summary>
        /// Gets the title of your object as it should appear within the graph, e.g., "The Rock".
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        [OgProperty("title", 1)]
        public string Title { get; private set; }

        /// <summary>
        /// Gets the type of your object, e.g., "video.movie". Depending on the type you specify, 
        /// other properties may also be required.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        [OgProperty("type", 2)]
        public ObjectType Type { get; private set; }

        /// <summary>
        /// Gets the canonical URL of your object that will be used as its permanent ID in the graph, 
        /// e.g., "http://www.imdb.com/title/tt0117500/"
        /// </summary>
        /// <value>
        /// The URL.
        /// </value>
        [OgProperty("url", 3)]
        public string Url { get; private set; }

        /// <summary>
        /// Gets an image URL which should represent your object within the graph.
        /// </summary>
        /// <value>
        /// The images.
        /// </value>
        [OgStructuredProperty(4)]
        public OgImage[] Images { get; private set; }

        /// <summary>
        /// Gets or sets a URL to an audio file to accompany this object.
        /// </summary>
        /// <value>
        /// The audio.
        /// </value>
        [OgStructuredProperty(5)]
        public OgAudio[] Audio { get; set; }

        /// <summary>
        /// Gets or sets a one to two sentence description of your object.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        [OgProperty("description", 6)]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the word that appears before this object's title in a sentence. It returns 
        /// an enum of type <see cref="SeoPack.Html.OpenGraph.Determiner"/> . If auto is chosen, the 
        /// consumer of your data should chose between "a" or "an". Default is "" (blank).
        /// </summary>
        /// <value>
        /// The determiner.
        /// </value>
        [OgProperty("determiner", 7)]
        public Determiner? Determiner { get; set; }

        /// <summary>
        /// Gets or sets the locale these tags are marked up in. Of the format language_TERRITORY. 
        /// Default is en_US.
        /// </summary>
        /// <value>
        /// The locale.
        /// </value>
        [OgProperty("locale", 8)]
        public string Locale { get; set; }

        /// <summary>
        /// Gets or sets an array of other locales this page is available in.
        /// </summary>
        /// <value>
        /// The alternate locales.
        /// </value>
        [OgProperty("locale:alternate", 9)]
        public IEnumerable<string> AlternateLocales { get; set; }

        /// <summary>
        /// Gets or sets the name which should be displayed for the overall site. e.g., "IMDb".
        /// </summary>
        /// <value>
        /// The name of the site.
        /// </value>
        [OgProperty("site_name", 10)]
        public string SiteName { get; set; }

        /// <summary>
        /// Gets or sets a URL to a video file that complements this object.
        /// </summary>
        /// <value>
        /// The videos.
        /// </value>
        [OgStructuredProperty(11)]
        public OgVideo[] Videos { get; set; }
    }
}
