using SeoPack.Url.Canonicalization;
using System.Web;

namespace SeoPack.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public class UrlSeoHelper : IUrlSeoHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string CanonicalUrl()
        {
            var canonicalUrl = HttpContext.Current.Items["CanonicalUrl"] as string;
            if (!string.IsNullOrEmpty(canonicalUrl))
            {
                return canonicalUrl;
            }
            else
            {
                var query = HttpContext.Current.Request.Url.Query;
                if (query.Length == 0)
                {
                    return string.Empty;
                }

                canonicalUrl = HttpContext.Current
                    .Request.Url.AbsoluteUri.Replace(query, "");

                return new CanonicalUrl(canonicalUrl).AbsoluteUri;
            }
        }
    }
}
