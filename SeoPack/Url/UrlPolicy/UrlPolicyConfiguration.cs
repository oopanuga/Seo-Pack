using System.Collections.Generic;
using System.Linq;

namespace SeoPack.Url.UrlPolicy
{
    public static class UrlPolicyConfiguration
    {
        private static UrlPolicyBuilder _builder;

        public static UrlPolicyBase[] UrlPolicies
        {
            get
            {
                if (_builder == null) return null;
                return _builder.UrlPolicies;
            }
        }

        public static UrlPolicyBuilder Configure()
        {
            _builder = new UrlPolicyBuilder();
            return _builder;
        }

        public static void Configure(IEnumerable<UrlPolicyBase> urlPolicies)
        {
            _builder = new UrlPolicyBuilder(urlPolicies.ToList());
        }
    }
}
