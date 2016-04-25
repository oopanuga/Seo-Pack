using System;
using System.Web.Mvc;

namespace SeoPack.Url.Canonicalization
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class RedirectToCanonicalUrlAttribute : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext == null)
            {
                throw new ArgumentNullException("filterContext");
            }

            var url = filterContext.RequestContext.HttpContext.Request.Url.AbsoluteUri;
            var canonicalUrl = SeoFriendlyUrl.ApplyUrlPolicies(url).Url.ToString();

            if(!url.Equals(canonicalUrl))
            {
                filterContext.Result = new RedirectResult(canonicalUrl, true);
            }
        }
    }
}
