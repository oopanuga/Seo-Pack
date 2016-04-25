using System;
using System.Collections.Generic;

namespace SeoPack.Url.UrlPolicy.Policies
{
    public class MapPolicy : UrlPolicyBase
    {
        private readonly IDictionary<string, string> _urlPathMap;

        public MapPolicy(IDictionary<string, string> urlPathMap)
        {
            _urlPathMap = urlPathMap;
        }

        protected override void ApplyPolicy(UriBuilder uri)
        {
            string newUrlPath;

            if (_urlPathMap.TryGetValue(uri.Path, out newUrlPath))
            {
                uri.Path = newUrlPath;
            }
        }
    }
}