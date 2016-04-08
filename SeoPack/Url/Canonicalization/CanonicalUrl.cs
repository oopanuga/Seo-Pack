using System;

namespace SeoPack.Url.Canonicalization
{
    /// <summary>
    /// 
    /// </summary>
    public class CanonicalUrl : Uri
    {
        private CanonicalUrlRuleBase[] _rules;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <param name="rules"></param>
        public CanonicalUrl(string url, params CanonicalUrlRuleBase[] rules)
            : base(url)
        {
            _rules = rules;
            Canonicalize();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        public CanonicalUrl(string url)
            : this(url, CanonicalUrlRuleConfiguration.Rules)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
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
                var urlBuildeer = new UriBuilder(this);
                foreach (var rule in _rules)
                {
                    rule.Apply(urlBuildeer);
                }
            }
        }

        public override string ToString()
        {
            return AbsoluteUri;
        }
    }
}
