using System;

namespace SeoPack.Url.UrlPolicy.Policies
{
    public class NoTrailingSlashPolicy : UrlPolicyBase
    {
        protected override void ApplyPolicy(UriBuilder uri)
        {
            uri.Path = uri.Path.TrimEnd('/');
        }
    }
}