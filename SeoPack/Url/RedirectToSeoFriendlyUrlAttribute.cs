using System;
using System.Web.Mvc;

namespace SeoPack.Url
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class RedirectToSeoFriendlyUrlAttribute : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext == null)
            {
                throw new ArgumentNullException("filterContext");
            }

            var url = filterContext.RequestContext.HttpContext.Request.Url.AbsoluteUri;
            var seoFriendlyUrl = new SeoFriendlyUrl(url).Value.AbsoluteUri;

            if(!url.Equals(seoFriendlyUrl))
            {
                filterContext.Result = new RedirectResult(seoFriendlyUrl, true);
            }
        }
    }
}
