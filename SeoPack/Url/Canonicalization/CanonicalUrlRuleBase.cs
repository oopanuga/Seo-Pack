using System;

namespace SeoPack.Url.Canonicalization
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class CanonicalUrlRuleBase
    {
        public void Apply(UriBuilder uri)
        {
            if(uri == null)
            {
                throw new ArgumentNullException("uri");
            }

            ApplyRule(uri);
        }

        protected abstract void ApplyRule(UriBuilder uri);
    }
}
