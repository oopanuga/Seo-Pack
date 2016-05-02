using System;
using System.Web.Mvc;

namespace SeoPack.Url
{
    /// <summary>
    /// Represents a class that does a permanent redirect to the Canonical version of the 
    /// requested url if the requested url is different i.e. doesn't conform to the predefined
    /// url policies.
    /// </summary>
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
            var canonicalUrl = new CanonicalUrl(url).Value.AbsoluteUri;

            if(!url.Equals(canonicalUrl))
            {
                filterContext.Result = new RedirectResult(canonicalUrl, true);
            }
        }
    }
}
