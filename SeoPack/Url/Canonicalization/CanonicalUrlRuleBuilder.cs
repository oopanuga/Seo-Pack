using System;
using System.Collections.Generic;
using System.Linq;

namespace SeoPack.Url.Canonicalization
{
    /// <summary>
    /// 
    /// </summary>
    public class CanonicalUrlRuleBuilder
    {
        private static List<ICanonicalUrlRule> _rules;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        internal ICanonicalUrlRule[] Rules
        {
            get
            {
                if (_rules == null)
                    return null;
                else
                    return _rules.ToArray();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rule"></param>
        public CanonicalUrlRuleBuilder AddRule(ICanonicalUrlRule rule)
        {
            if (rule == null)
            {
                throw new ArgumentNullException("rule");
            }

            if (_rules == null)
                _rules = new List<ICanonicalUrlRule>();

            if (!_rules.Any(x => x.GetType() == rule.GetType()))
            {
                _rules.Add(rule);
            }

            return this;
        }
    }
}
