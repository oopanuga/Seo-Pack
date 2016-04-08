using System;

namespace SeoPack.Url.Canonicalization.Rules
{
    public class TrailingSlashRule : CanonicalUrlRuleBase
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
