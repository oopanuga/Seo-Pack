using System;
using System.Web.Mvc;

namespace SeoPack.Url.Canonicalization
{
    /// <summary>
    /// 
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = true, AllowMultiple = false)]
    public class RedirectToCanonicalUrlAttribute : FilterAttribute, IAuthorizationFilter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filterContext"></param>
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext == null)
            {
                throw new ArgumentNullException("filterContext");
            }

            var url = filterContext.RequestContext.HttpContext.Request.Url.AbsoluteUri;
            var canonicalUrl = CanonicalUrl.Canonicalize(url).AbsoluteUri;

            if(!url.Equals(canonicalUrl))
            {
                filterContext.Result = new RedirectResult(canonicalUrl, true);
            }
        }
    }
}
