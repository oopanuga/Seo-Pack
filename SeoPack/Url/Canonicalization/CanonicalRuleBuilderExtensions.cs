using SeoPack.Url.Canonicalization.Rules;
using System.Collections.Generic;

namespace SeoPack.Url.Canonicalization
{
    public static class CanonicalRuleBuilderExtensions
    {
        public static CanonicalRuleBuilder WwwRule(this CanonicalRuleBuilder builder)
        {
            builder.AddRule(new WwwRule());
            return builder;
        }

        public static CanonicalRuleBuilder HostRule(this CanonicalRuleBuilder builder, string host)
        {
            builder.AddRule(new HostRule(host));
            return builder;
        }

        public static CanonicalRuleBuilder LowercaseRule(this CanonicalRuleBuilder builder)
        {
            builder.AddRule(new LowercaseRule());
            return builder;
        }

        public static CanonicalRuleBuilder MapRule(this CanonicalRuleBuilder builder, IDictionary<string, string> urlPathMap)
        {
            builder.AddRule(new MapRule(urlPathMap));
            return builder;
        }

        public static CanonicalRuleBuilder NoTrailingSlashRule(this CanonicalRuleBuilder builder)
        {
            builder.AddRule(new NoTrailingSlashRule());
            return builder;
        }

        public static CanonicalRuleBuilder NoWwwRule(this CanonicalRuleBuilder builder)
        {
            builder.AddRule(new NoWwwRule());
            return builder;
        }

        public static CanonicalRuleBuilder PatternRule(this CanonicalRuleBuilder builder, string regex, string replacement)
        {
            builder.AddRule(new PatternRule(regex, replacement));
            return builder;
        }

        public static CanonicalRuleBuilder TrailingSlashRule(this CanonicalRuleBuilder builder)
        {
            builder.AddRule(new TrailingSlashRule());
            return builder;
        }
    }
}
