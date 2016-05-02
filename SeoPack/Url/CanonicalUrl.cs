using SeoPack.Url.UrlPolicy;
using System;

namespace SeoPack.Url
{
    /// <summary>
    /// Represents a Canonical Url i.e. a url that conforms to a supplied
    /// or predefined set of url policies. See <see cref="UrlPolicyConfiguration"/> 
    /// on configuring url policies.
    /// </summary>
    public class CanonicalUrl
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
        /// Initializes a new instance of the <see cref="CanonicalUrl"/> class.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <param name="policies">The policies.</param>
        /// <exception cref="System.ArgumentException">url not set</exception>
        public CanonicalUrl(string url, params UrlPolicyBase[] policies)
        {
            if (string.IsNullOrEmpty("url"))
            {
                throw new ArgumentException("url not set");
            }

            Value = new Uri(url);
            _policies = policies;
            ApplyUrlPolicies();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CanonicalUrl"/> class.
        /// </summary>
        /// <param name="url">The URL.</param>
        public CanonicalUrl(string url)
            : this(url, UrlPolicyConfiguration.UrlPolicies)
        {
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
    }
}
