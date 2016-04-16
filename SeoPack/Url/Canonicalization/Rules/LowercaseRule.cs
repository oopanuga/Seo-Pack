
using System;

namespace SeoPack.Url.Canonicalization.Rules
{
    public class LowercaseRule : CanonicalRuleBase
    {
        protected override void ApplyRule(UriBuilder uri)
        {
            uri.Path = uri.Path.ToLowerInvariant();
        }
    }
}
