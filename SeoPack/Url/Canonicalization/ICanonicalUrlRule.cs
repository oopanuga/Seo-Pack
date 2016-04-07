using System;

namespace SeoPack.Url.Canonicalization
{
    /// <summary>
    /// 
    /// </summary>
    public interface ICanonicalUrlRule
    {
        void Apply(UriBuilder uri);
    }
}
