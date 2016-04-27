using System.Collections.Generic;
using System.Linq;

namespace SeoPack.Url.UrlPolicy
{
    /// <summary>
    /// Represents a class used to configure a set of url policies that define the characteristics
    /// of a Seo Friendly Url. See <see cref="SeoFriendlyUrl"/>
    /// </summary>
    public static class UrlPolicyConfiguration
    {
        private static UrlPolicyBuilder _builder;

        /// <summary>
        /// Gets the configured URL policies.
        /// </summary>
        /// <value>
        /// The URL policies.
        /// </value>
        public static UrlPolicyBase[] UrlPolicies
        {
            get
            {
                if (_builder == null) return null;
                return _builder.UrlPolicies;
            }
        }

        /// <summary>
        /// Returns a url policy builder used to subsequently configure selected/added URL policies.
        /// </summary>
        /// <returns>The url policy builder.</returns>
        public static UrlPolicyBuilder Configure()
        {
            _builder = new UrlPolicyBuilder();
            return _builder;
        }

        /// <summary>
        /// Configures url policies based on the supplied URL policies.
        /// </summary>
        /// <param name="urlPolicies">The URL policies.</param>
        public static void Configure(IEnumerable<UrlPolicyBase> urlPolicies)
        {
            _builder = new UrlPolicyBuilder(urlPolicies.ToList());
        }
    }
}
