using SeoPack.Url.UrlPolicy;
using System;
using System.Web;

namespace SeoPack.Url
{
    /// <summary>
    /// Represents a Seo Friendly Url i.e. a url that conforms to a supplied
    /// or predefined set of url policies. See <see cref="UrlPolicyConfiguration"/> 
    /// on configuring url policies.
    /// </summary>
    public class SeoFriendlyUrl
    {
        private readonly UrlPolicyBase[] _policies;

        /// <summary>
        /// Gets the url value.
        /// </summary>
        /// <value>
        /// The url value.
        /// </value>
        public Uri Value { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SeoFriendlyUrl"/> class.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="policies">The policies.</param>
        /// <exception cref="System.ArgumentException">url not set</exception>
        public SeoFriendlyUrl(string url, params UrlPolicyBase[] policies)
        {
            if (string.IsNullOrEmpty("url"))
            {
                throw new ArgumentException("url not set");
            }

            Value = new Uri(url.StartsWith("/") ? ToAbsoluteUrl(url) : url);
            _policies = policies;
            ApplyUrlPolicies();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SeoFriendlyUrl"/> class.
        /// </summary>
        /// <param name="url">The URL.</param>
        public SeoFriendlyUrl(string url)
            : this(url, UrlPolicyConfiguration.UrlPolicies)
        {
        }

        /// <summary>
        /// Applies the URL policies.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentException">url not set</exception>
        public static SeoFriendlyUrl ApplyUrlPolicies(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentException("url not set");
            }

            return new SeoFriendlyUrl(url);
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return Value.AbsoluteUri;
        }

        private void ApplyUrlPolicies()
        {
            if (_policies != null)
            {
                var urlBuilder = new UriBuilder(Value);
                foreach (var policy in _policies)
                {
                    policy.Apply(urlBuilder);
                }

                Value = urlBuilder.Uri;
            }
        }

        private string ToAbsoluteUrl(string relativeUrl)
        {
            var requestUrl = HttpContext.Current.Request.Url;
            return string.Format("{0}://{1}{2}",
                                                  requestUrl.Scheme,
                                                  requestUrl.Authority,
                                                  relativeUrl);
        }
    }
}
