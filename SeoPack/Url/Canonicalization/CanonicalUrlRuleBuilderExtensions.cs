using SeoPack.Url.Canonicalization.Rules;

namespace SeoPack.Url.Canonicalization
{
    public static class CanonicalUrlRuleBuilderExtensions
    {
        public static CanonicalUrlRuleBuilder WwwRule(this CanonicalUrlRuleBuilder builder)
        {
            builder.AddRule(new WwwRule());
            return builder;
        }

        public static CanonicalUrlRuleBuilder HostRule(this CanonicalUrlRuleBuilder builder)
        {
            builder.AddRule(new HostRule());
            return builder;
        }

        public static CanonicalUrlRuleBuilder LowercaseRule(this CanonicalUrlRuleBuilder builder)
        {
            builder.AddRule(new LowercaseRule());
            return builder;
        }

        public static CanonicalUrlRuleBuilder MapRule(this CanonicalUrlRuleBuilder builder)
        {
            builder.AddRule(new MapRule());
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

        public static CanonicalUrlRuleBuilder PatternRule(this CanonicalUrlRuleBuilder builder)
        {
            builder.AddRule(new PatternRule());
            return builder;
        }

        public static CanonicalUrlRuleBuilder TrailingSlashRule(this CanonicalUrlRuleBuilder builder)
        {
            builder.AddRule(new TrailingSlashRule());
            return builder;
        }
    }
}
