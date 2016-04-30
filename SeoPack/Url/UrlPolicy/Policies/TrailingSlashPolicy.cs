using System;

namespace SeoPack.Url.UrlPolicy.Policies
{
    public class TrailingSlashPolicy : UrlPolicyBase
    {
        protected override void ApplyPolicy(UriBuilder uri)
        {
            if (!uri.Path.EndsWith("/")/* && !uri.Path.Contains(".")*/)
            {
                uri.Path += '/';
            }
        }
    }
}
