using SeoPack.Url.UrlPolicy.Policies;
using System.Collections.Generic;

namespace SeoPack.Url.UrlPolicy
{
    public static class UrlPolicyBuilderExtensions
    {
        public static UrlPolicyBuilder WwwPolicy(this UrlPolicyBuilder builder)
        {
            builder.AddUrlPolicy(new WwwPolicy());
            return builder;
        }

        public static UrlPolicyBuilder HostPolicy(this UrlPolicyBuilder builder, string host)
        {
            builder.AddUrlPolicy(new HostPolicy(host));
            return builder;
        }

        public static UrlPolicyBuilder LowercasePolicy(this UrlPolicyBuilder builder)
        {
            builder.AddUrlPolicy(new LowercasePolicy());
            return builder;
        }

        public static UrlPolicyBuilder MapPolicy(this UrlPolicyBuilder builder, IDictionary<string, string> urlPathMap)
        {
            builder.AddUrlPolicy(new MapPolicy(urlPathMap));
            return builder;
        }

        public static UrlPolicyBuilder NoTrailingSlashPolicy(this UrlPolicyBuilder builder)
        {
            builder.AddUrlPolicy(new NoTrailingSlashPolicy());
            return builder;
        }

        public static UrlPolicyBuilder NoWwwPolicy(this UrlPolicyBuilder builder)
        {
            builder.AddUrlPolicy(new NoWwwPolicy());
            return builder;
        }

        public static UrlPolicyBuilder PatternPolicy(this UrlPolicyBuilder builder, string regex, string replacement)
        {
            builder.AddUrlPolicy(new PatternPolicy(regex, replacement));
            return builder;
        }

        public static UrlPolicyBuilder TrailingSlashPolicy(this UrlPolicyBuilder builder)
        {
            builder.AddUrlPolicy(new TrailingSlashPolicy());
            return builder;
        }
    }
}
