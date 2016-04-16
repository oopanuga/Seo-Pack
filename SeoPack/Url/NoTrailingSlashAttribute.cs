
using System;
using System.Web.Mvc;
namespace SeoPack.Url
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class NoTrailingSlashAttribute : FilterAttribute, IAuthorizationFilter
    {
        public virtual void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext == null)
            {
                throw new ArgumentNullException("filterContext");
            }

            var urlPath = filterContext.HttpContext.Request.Url.AbsolutePath;

            if (urlPath.LastIndexOf('/') == urlPath.Length - 1)
            {
                filterContext.Result = new HttpNotFoundResult();
            }
        }
    }
}
