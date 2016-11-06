
using System;
using System.Web.Mvc;

namespace SeoPack.Url
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class NoTrailingSlashAttribute : FilterAttribute, IAuthorizationFilter, ISkipUrlPolicyCheckFilter
    {
        public virtual void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext == null)
            {
                throw new ArgumentNullException("filterContext");
            }

            var uri = new CanonicalUrl(filterContext.HttpContext.Request.Url.AbsoluteUri).Value;
            var canonicalUrl = string.Format("{0}://{1}{2}{3}",
            uri.Scheme, uri.Authority, uri.AbsolutePath.TrimEnd('/'), uri.Query);

            if (!filterContext.HttpContext.Request.Url.AbsoluteUri.Equals(canonicalUrl))
            {
                filterContext.Result = new RedirectResult(canonicalUrl, true);
            }
        }
    }
}
