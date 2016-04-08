using System;

namespace SeoPack.Url.Canonicalization.Rules
{
    public class WwwRule : CanonicalUrlRuleBase
    {
        protected override void ApplyRule(UriBuilder uri)
        {
            if (uri.Uri.HostNameType == UriHostNameType.Dns 
                && !uri.Host.StartsWith("www.", StringComparison.InvariantCultureIgnoreCase) 
                && !uri.Host.Equals("localhost", StringComparison.InvariantCultureIgnoreCase))
            {
                uri.Host = "www." + uri.Host;
            }
        }
    }
}
