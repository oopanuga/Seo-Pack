using System;
using System.Collections.Generic;
using System.Linq;

namespace SeoPack.Url.Canonicalization
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class CanonicalizationRuleManager
    {
        private List<ICanonicalizationRule> _rules;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ICanonicalizationRule[] GetRules()
        {
            if (_rules == null)
                return null;
            else
                return _rules.ToArray();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rule"></param>
        public CanonicalizationRuleManager AddRule(ICanonicalizationRule rule)
        {
            if (rule == null)
            {
                throw new ArgumentNullException("rule");
            }

            if (_rules == null)
                _rules = new List<ICanonicalizationRule>();

            if (!_rules.Any(x => x.GetType() == rule.GetType()))
            {
                _rules.Add(rule);
            }

            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rule"></param>
        public void RemoveRule(ICanonicalizationRule rule)
        {
            if (rule == null)
            {
                throw new ArgumentNullException("rule");
            }

            var ruleToRemove = _rules.SingleOrDefault(x => x.GetType() == rule.GetType());

            if (ruleToRemove != null)
            {
                _rules.Remove(ruleToRemove);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void ClearRules()
        {
            if (_rules == null) return;

            _rules.Clear();
        }
    }
}
