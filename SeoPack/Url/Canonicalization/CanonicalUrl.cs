using System;

namespace SeoPack.Url.Canonicalization
{
    /// <summary>
    /// Represents a Canonical Url
    /// </summary>
    public class CanonicalUrl
    {
        private readonly CanonicalRuleBase[] _rules;

        public Uri Url { get; private set; }

        public CanonicalUrl(string url, params CanonicalRuleBase[] rules)
        {
            if (string.IsNullOrEmpty("url"))
            {
                throw new ArgumentException("url not set");
            }

            Url = new Uri(url);
            _rules = rules;
            Canonicalize();
        }

        public CanonicalUrl(string url)
            : this(url, CanonicalRuleConfiguration.Rules)
        {
        }

        public static CanonicalUrl Canonicalize(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentException("url not set");
            }

            return new CanonicalUrl(url);
        }

        private void Canonicalize()
        {
            if (_rules != null)
            {
                var urlBuilder = new UriBuilder(Url);
                foreach (var rule in _rules)
                {
                    rule.Apply(urlBuilder);
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
