using System;
using System.Collections.Generic;
using System.Linq;

namespace SeoPack.Url.UrlPolicy
{
    public sealed class UrlPolicyBuilder
    {
        private static List<UrlPolicyBase> _urlPolicies;

        public UrlPolicyBuilder() { }

        internal UrlPolicyBuilder(List<UrlPolicyBase> urlPolicies)
        {
            if (urlPolicies == null || !urlPolicies.Any())
                throw new ArgumentException("urlPolicies not set");

            if (_urlPolicies == null)
                _urlPolicies = new List<UrlPolicyBase>();

            _urlPolicies = urlPolicies;
        }

        internal UrlPolicyBase[] UrlPolicies
        {
            get
            {
                if (_urlPolicies == null)
                    return null;
                else
                    return _urlPolicies.ToArray();
            }
        }

        public UrlPolicyBuilder AddUrlPolicy(UrlPolicyBase urlPolicy)
        {
            if (urlPolicy == null)
            {
                throw new ArgumentNullException("urlPolicy");
            }

            if (_urlPolicies == null)
                _urlPolicies = new List<UrlPolicyBase>();

            _urlPolicies.Add(urlPolicy);

            return this;
        }
    }
}
