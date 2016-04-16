using System;

namespace SeoPack.Url.Canonicalization.Rules
{
    public class HostRule : CanonicalRuleBase
    {
        private string _host;
        public HostRule(string host)
        {
            if(string.IsNullOrEmpty(host))
            {
                throw new ArgumentException("host not set");
            }

            _host = host;
        }

        protected override void ApplyRule(UriBuilder uri)
        {
            uri.Host = _host;
        }
    }
}
