using System;

namespace SeoPack.Url.Canonicalization
{
    public abstract class CanonicalRuleBase
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
