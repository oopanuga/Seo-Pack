using System.Web;
using SeoPack.Url;
using SeoPack.Url.UrlPolicy;

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
        /// isn't the case then it will return the current page url stripped off any querystrings and make it Seo Friendly
        /// using the predefined url policies. See <see cref="UrlPolicyConfiguration"/> on configuring url policies.
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

            return new SeoFriendlyUrl(canonicalUrl).Value.ToString();
        }

        /// <summary>
        /// It makes a url Seo Friendly by making it conform to a set of predefined url policies.
        /// See <see cref="UrlPolicyConfiguration"/> on configuring url policies.
        /// </summary>
        /// <param name="url">The url to make Seo Friendly.</param>
        /// <returns>The seo friendly url.</returns>
        public string ToSeoFriendlyUrl(string url)
        {
            return new SeoFriendlyUrl(url).Value.ToString();
        }
    }
}
