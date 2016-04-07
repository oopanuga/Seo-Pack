
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
        public static ICanonicalUrlRule[] Rules
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
    }
}
