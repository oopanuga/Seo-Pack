using System;

namespace SeoPack.Url.Canonicalization.Rules
{
    public class TrailingSlashRule : CanonicalRuleBase
    {
        protected override void ApplyRule(UriBuilder uri)
        {
            if (!uri.Path.EndsWith("/") && !uri.Path.Contains("."))
            {
                uri.Path += '/';
            }
        }
    }
}
