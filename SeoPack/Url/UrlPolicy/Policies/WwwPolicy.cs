using System;

namespace SeoPack.Url.UrlPolicy.Policies
{
    public class WwwPolicy : UrlPolicyBase
    {
        protected override void ApplyPolicy(UriBuilder uri)
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
