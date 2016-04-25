using System;

namespace SeoPack.Url.UrlPolicy.Policies
{
    public class LowercasePolicy : UrlPolicyBase
    {
        protected override void ApplyPolicy(UriBuilder uri)
        {
            uri.Path = uri.Path.ToLowerInvariant();
        }
    }
}
