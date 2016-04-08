using SeoPack.Url.Canonicalization.Rules;
using System.Collections.Generic;

namespace SeoPack.Url.Canonicalization
{
    public static class CanonicalUrlRuleBuilderExtensions
    {
        public static CanonicalUrlRuleBuilder WwwRule(this CanonicalUrlRuleBuilder builder)
        {
            builder.AddRule(new WwwRule());
            return builder;
        }

        public static CanonicalUrlRuleBuilder HostRule(this CanonicalUrlRuleBuilder builder, string host)
        {
            builder.AddRule(new HostRule(host));
            return builder;
        }

        public static CanonicalUrlRuleBuilder LowercaseRule(this CanonicalUrlRuleBuilder builder)
        {
            builder.AddRule(new LowercaseRule());
            return builder;
        }

        public static CanonicalUrlRuleBuilder MapRule(this CanonicalUrlRuleBuilder builder, IDictionary<string, string> urlPathMap)
        {
            builder.AddRule(new MapRule(urlPathMap));
            return builder;
        }

        public static CanonicalUrlRuleBuilder NoTrailingSlashRule(this CanonicalUrlRuleBuilder builder)
        {
            builder.AddRule(new NoTrailingSlashRule());
            return builder;
        }

        public static CanonicalUrlRuleBuilder NoWwwRule(this CanonicalUrlRuleBuilder builder)
        {
            builder.AddRule(new NoWwwRule());
            return builder;
        }

        public static CanonicalUrlRuleBuilder PatternRule(this CanonicalUrlRuleBuilder builder, string regex, string replacement)
        {
            builder.AddRule(new PatternRule(regex, replacement));
            return builder;
        }

        public static CanonicalUrlRuleBuilder TrailingSlashRule(this CanonicalUrlRuleBuilder builder)
        {
            builder.AddRule(new TrailingSlashRule());
            return builder;
        }
    }
}
