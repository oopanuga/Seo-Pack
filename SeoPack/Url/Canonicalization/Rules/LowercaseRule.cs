
using System;

namespace SeoPack.Url.Canonicalization.Rules
{
    public class LowercaseRule : CanonicalUrlRuleBase
    {
        protected override void ApplyRule(UriBuilder uri)
        {
            uri.Path = uri.Path.ToLowerInvariant();
        }
    }
}
