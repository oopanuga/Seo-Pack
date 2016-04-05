using System;
using System.Collections.Generic;
using System.Linq;

namespace SeoPack.Url.Canonicalization
{
    /// <summary>
    /// 
    /// </summary>
    public class CanonicalUrl : Uri
    {
        private static CanonicalizationRuleManager _ruleManager;
        private List<ICanonicalizationRule> _canonicalizationRules;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <param name="canonicalizationRules"></param>
        public CanonicalUrl(string url,
            params ICanonicalizationRule[] canonicalizationRules)
            : base(url)
        {
            _canonicalizationRules = canonicalizationRules != null
                ? canonicalizationRules.ToList() : null;

            Canonicalize();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        public CanonicalUrl(string url)
            : this(url, _ruleManager != null
            ? _ruleManager.GetRules() : null)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public ICanonicalizationRule[] Rules
        {
            get
            {
                if (_canonicalizationRules == null)
                    return null;
                else
                    return _canonicalizationRules.ToArray();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static CanonicalizationRuleManager RuleManager
        {
            get
            {
                if (_ruleManager == null)
                {
                    _ruleManager = 
                        new CanonicalizationRuleManager();
                }

                return _ruleManager;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static CanonicalUrl Canonicalize(string url)
        {
            if(string.IsNullOrEmpty(url))
            {
                throw new ArgumentException("url not set");
            }

            return new CanonicalUrl(url);
        }

        private void Canonicalize()
        {
            if (_canonicalizationRules != null)
            {
                var urlBuildeer = new UriBuilder(this);
                foreach (var rule in _canonicalizationRules)
                {
                    rule.Apply(urlBuildeer);
                }
            }
        }

        public override string ToString()
        {
            return AbsoluteUri;
        }
    }
}
