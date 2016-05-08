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

            var requestUrl = filterContext.RequestContext
                .HttpContext.Request.Url.AbsoluteUri;

            string canonicalUrl;
            if (Requires301Redirect(requestUrl, HasNoTrailingSlashAttribute(filterContext), out canonicalUrl))
            {
                Do301Redirect(filterContext, canonicalUrl);
            }
        }

        protected virtual bool Requires301Redirect(string requestUrl, 
            bool hasNoTrailingSlashAttribute, out string canonicalUrl)
        {
            bool requires301Redirect = false;

            var canonicalUri = new CanonicalUrl(requestUrl).Value;
            canonicalUrl = canonicalUri.AbsoluteUri;
            var urlPath = canonicalUri.LocalPath;

            if (hasNoTrailingSlashAttribute)
            {
                if (urlPath.LastIndexOf('/') == urlPath.Length - 1)
                {
                    canonicalUrl = string.Format("{0}://{1}{2}{3}",
                                                          canonicalUri.Scheme,
                                                          canonicalUri.Authority,
                                                          urlPath.TrimEnd('/'),
                                                          canonicalUri.Query);
                }

                if (!requestUrl.Equals(canonicalUrl))
                {
                    requires301Redirect = true;
                }
            }
            else if (!requestUrl.Equals(canonicalUrl))
            {
                requires301Redirect = true;
            }

            return requires301Redirect;
        }

        /// <summary>
        /// Checks if the action or controller the action belongs to has the NoTrailingSlashAttribute
        /// </summary>
        /// <param name="filterContext">The filter context</param>
        /// <returns></returns>
        protected bool HasNoTrailingSlashAttribute(AuthorizationContext filterContext)
        {
            var actionDescriptor = filterContext.ActionDescriptor;
            return actionDescriptor.IsDefined(typeof(NoTrailingSlashAttribute), false) || 
                actionDescriptor.ControllerDescriptor.IsDefined(typeof(NoTrailingSlashAttribute), false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filterContext"></param>
        /// <param name="canonicalUrl"></param>
        protected void Do301Redirect(AuthorizationContext filterContext, string canonicalUrl)
        {
            filterContext.Result = new RedirectResult(canonicalUrl, true);
        }
    }
}
