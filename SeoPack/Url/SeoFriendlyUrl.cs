using System;
using SeoPack.Url.UrlPolicy;

namespace SeoPack.Url
{
    /// <summary>
    /// Represents a Seo Friendly Url
    /// </summary>
    public class SeoFriendlyUrl
    {
        private readonly UrlPolicyBase[] _policies;

        public Uri Url { get; private set; }

        public SeoFriendlyUrl(string url, params UrlPolicyBase[] policies)
        {
            if (string.IsNullOrEmpty("url"))
            {
                throw new ArgumentException("url not set");
            }

            Url = new Uri(url);
            _policies = policies;
            ApplyUrlPolicies();
        }

        public SeoFriendlyUrl(string url)
            : this(url, UrlPolicyConfiguration.UrlPolicies)
        {
        }

        public static SeoFriendlyUrl ApplyUrlPolicies(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentException("url not set");
            }

            return new SeoFriendlyUrl(url);
        }

        private void ApplyUrlPolicies()
        {
            if (_policies != null)
            {
                var urlBuilder = new UriBuilder(Url);
                foreach (var policy in _policies)
                {
                    policy.Apply(urlBuilder);
                }

                Url = urlBuilder.Uri;
            }
        }

        public override string ToString()
        {
            return Url.AbsoluteUri;
        }
    }
}
