using System;

namespace SeoPack.Url.Canonicalization.Rules
{
    public class NoTrailingSlashRule : CanonicalRuleBase
    {
        protected override void ApplyRule(UriBuilder uri)
        {
            uri.Path = uri.Path.TrimEnd('/');
        }
    }
}