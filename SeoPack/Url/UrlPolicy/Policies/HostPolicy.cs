using System;

namespace SeoPack.Url.UrlPolicy.Policies
{
    public class HostPolicy : UrlPolicyBase
    {
        private string _host;
        public HostPolicy(string host)
        {
            if(string.IsNullOrEmpty(host))
            {
                throw new ArgumentException("host not set");
            }

            _host = host;
        }

        protected override void ApplyPolicy(UriBuilder uri)
        {
            uri.Host = _host;
        }
    }
}
