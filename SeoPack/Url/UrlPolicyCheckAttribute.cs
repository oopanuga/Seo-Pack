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
    public class UrlPolicyCheckAttribute : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext == null)
            {
                throw new ArgumentNullException("filterContext");
            }

            if (SkipUrlPolicyCheckFilter(filterContext)) return;

            var requestUrl = filterContext.RequestContext.HttpContext.Request.Url.AbsoluteUri;
 
            var canonicalUrl = new CanonicalUrl(requestUrl).Value.AbsoluteUri;
            if (!requestUrl.Equals(canonicalUrl))
            {
                filterContext.Result = new RedirectResult(canonicalUrl, true);
            }
        }

        protected bool SkipUrlPolicyCheckFilter(AuthorizationContext filterContext)
        {
            var actionDescriptor = filterContext.ActionDescriptor;
            return actionDescriptor.IsDefined(typeof(ISkipUrlPolicyCheckFilter), true) ||
                actionDescriptor.ControllerDescriptor.IsDefined(typeof(ISkipUrlPolicyCheckFilter), true);
        }
    }
}
