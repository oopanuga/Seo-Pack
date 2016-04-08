using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace SeoPack.Url.Canonicalization
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class CanonicalUrlRuleBuilder
    {
        private static List<CanonicalUrlRuleBase> _rules;

        public CanonicalUrlRuleBuilder() { }

        internal CanonicalUrlRuleBuilder(List<CanonicalUrlRuleBase> rules)
        {
            if (rules == null || !rules.Any())
                throw new ArgumentException("rules not set");

            if (_rules == null)
                _rules = new List<CanonicalUrlRuleBase>();

            _rules = rules;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        internal CanonicalUrlRuleBase[] Rules
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
        public CanonicalUrlRuleBuilder AddRule(CanonicalUrlRuleBase rule)
        {
            if (rule == null)
            {
                throw new ArgumentNullException("rule");
            }

            if (_rules == null)
                _rules = new List<CanonicalUrlRuleBase>();

            _rules.Add(rule);

            return this;
        }
    }
}
