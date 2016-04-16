
using System.Collections.Generic;
using System.Linq;

namespace SeoPack.Url.Canonicalization
{
    public static class CanonicalRuleConfiguration
    {
        private static CanonicalRuleBuilder _builder;

        public static CanonicalRuleBase[] Rules
        {
            get
            {
                if (_builder == null) return null;
                return _builder.Rules;
            }
        }

        public static CanonicalRuleBuilder Configure()
        {
            _builder = new CanonicalRuleBuilder();
            return _builder;
        }

        public static void Configure(IEnumerable<CanonicalRuleBase> rules)
        {
            _builder = new CanonicalRuleBuilder(rules.ToList());
        }
    }
}
