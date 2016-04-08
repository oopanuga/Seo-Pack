
using System.Collections.Generic;
using System.Linq;
using System;

namespace SeoPack.Url.Canonicalization
{
    /// <summary>
    /// 
    /// </summary>
    public static class CanonicalUrlRuleConfiguration
    {
        private static CanonicalUrlRuleBuilder _builder;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static CanonicalUrlRuleBase[] Rules
        {
            get
            {
                if (_builder == null) return null;
                return _builder.Rules;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static CanonicalUrlRuleBuilder Configure()
        {
            _builder = new CanonicalUrlRuleBuilder();
            return _builder;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rules"></param>
        public static void Configure(IEnumerable<CanonicalUrlRuleBase> rules)
        {
            _builder = new CanonicalUrlRuleBuilder(rules.ToList());
        }
    }
}
