using System;
using System.Collections.Generic;
using System.Linq;

namespace SeoPack.Url.Canonicalization
{
    public sealed class CanonicalRuleBuilder
    {
        private static List<CanonicalRuleBase> _rules;

        public CanonicalRuleBuilder() { }

        internal CanonicalRuleBuilder(List<CanonicalRuleBase> rules)
        {
            if (rules == null || !rules.Any())
                throw new ArgumentException("rules not set");

            if (_rules == null)
                _rules = new List<CanonicalRuleBase>();

            _rules = rules;
        }

        internal CanonicalRuleBase[] Rules
        {
            get
            {
                if (_rules == null)
                    return null;
                else
                    return _rules.ToArray();
            }
        }

        public CanonicalRuleBuilder AddRule(CanonicalRuleBase rule)
        {
            if (rule == null)
            {
                throw new ArgumentNullException("rule");
            }

            if (_rules == null)
                _rules = new List<CanonicalRuleBase>();

            _rules.Add(rule);

            return this;
        }
    }
}
