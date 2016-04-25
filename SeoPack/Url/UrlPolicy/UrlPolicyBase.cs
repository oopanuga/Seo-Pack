using System;

namespace SeoPack.Url.UrlPolicy
{
    public abstract class UrlPolicyBase
    {
        public void Apply(UriBuilder uri)
        {
            if(uri == null)
            {
                throw new ArgumentNullException("uri");
            }

            ApplyPolicy(uri);
        }

        protected abstract void ApplyPolicy(UriBuilder uri);
    }
}
