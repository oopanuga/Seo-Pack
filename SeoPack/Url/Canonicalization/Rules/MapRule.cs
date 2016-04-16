using System;
using System.Collections.Generic;

namespace SeoPack.Url.Canonicalization.Rules
{
    public class MapRule : CanonicalRuleBase
    {
        private readonly IDictionary<string, string> _urlPathMap;

        public MapRule(IDictionary<string, string> urlPathMap)
        {
            _urlPathMap = urlPathMap;
        }

        protected override void ApplyRule(UriBuilder uri)
        {
            string newUrlPath;

            if (_urlPathMap.TryGetValue(uri.Path, out newUrlPath))
            {
                uri.Path = newUrlPath;
            }
        }
    }
}