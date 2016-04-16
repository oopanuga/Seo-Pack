using SeoPack.Url.Canonicalization;
using System.Web;

namespace SeoPack.Helpers
{
    /// <summary>
    /// Represents a Url Seo Helper for generating SEO friendly urls.
    /// </summary>
    public class UrlSeoHelper : IUrlSeoHelper
    {
        /// <summary>
        /// Attempts to get the canonical url of the current page from the HttpContext.Current.Items["CanonicalUrl"]
        /// if the canonical url path was set in the <see cref="CanonicalUrlAttribute"/> on the action method. If this 
        /// isn't the case then it will return the current page url stripped off any querystrings and canonicalize it
        /// using the predefined canonical url rules. See <see cref="CanonicalRuleConfiguration"/> on configuring 
        /// canonical url rules.
        /// </summary>
        /// <returns>The canonical url.</returns>
        public string CanonicalUrl()
        {
            var canonicalUrl = HttpContext.Current.Items["CanonicalUrl"] as string;
            if (!string.IsNullOrEmpty(canonicalUrl))
            {
                return canonicalUrl;
            }

            canonicalUrl = HttpContext.Current.Request.Url.AbsoluteUri;

            var query = HttpContext.Current.Request.Url.Query;
            if (query.Length > 0)
            {
                canonicalUrl = canonicalUrl.Replace(query, "");
            }

            return new CanonicalUrl(canonicalUrl).Url.ToString();
        }

        /// <summary>
        /// It makes the supplied url canonical by making it conform to a set of predefined 
        /// canonical url rules. See <see cref="CanonicalRuleConfiguration"/> on configuring
        /// canonical url rules.
        /// </summary>
        /// <param name="url">The url to canonicalize.</param>
        /// <returns>The canonicalized url.</returns>
        public string Canonicalize(string url)
        {
            return new CanonicalUrl(url).Url.ToString();
        }
    }
}
