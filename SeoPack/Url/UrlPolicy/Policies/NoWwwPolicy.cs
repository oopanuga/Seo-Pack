using System;

namespace SeoPack.Url.UrlPolicy.Policies
{
    public class NoWwwPolicy : UrlPolicyBase
    {
        protected override void ApplyPolicy(UriBuilder uri)
        {
            if (uri.Host.StartsWith("www.", StringComparison.InvariantCultureIgnoreCase))
            {
                uri.Host = uri.Host.Substring(4);
            }
        }
    }
}
