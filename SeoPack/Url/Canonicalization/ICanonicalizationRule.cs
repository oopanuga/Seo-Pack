using System;

namespace SeoPack.Url.Canonicalization
{
    /// <summary>
    /// 
    /// </summary>
    public interface ICanonicalizationRule
    {
        void Apply(UriBuilder uri);
    }
}
