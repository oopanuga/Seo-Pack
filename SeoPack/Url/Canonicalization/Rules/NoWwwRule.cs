using System;

namespace SeoPack.Url.Canonicalization.Rules
{
    public class NoWwwRule : CanonicalUrlRuleBase
    {
        protected override void ApplyRule(UriBuilder uri)
        {
            if (uri.Host.StartsWith("www.", StringComparison.InvariantCultureIgnoreCase))
            {
                uri.Host = uri.Host.Substring(4);
            }
        }
    }
}
