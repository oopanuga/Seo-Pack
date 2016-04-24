using System;
using System.Web.Mvc;

namespace SeoPack.Url.Canonicalization
{
    [AttributeUsage(AttributeTargets.Method)]
    public class CanonicalUrlAttribute : ActionFilterAttribute
    {
        private string _urlPath;

        public CanonicalUrlAttribute(string urlPath)
        {
            if (string.IsNullOrEmpty(urlPath))
            {
                throw new ArgumentException("url not set");
            }

            _urlPath = urlPath;
        }

        public CanonicalUrlAttribute()
        {
            _urlPath = string.Empty;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string fullUrl;

            if (string.IsNullOrEmpty(_urlPath))
            {
                fullUrl = filterContext.RequestContext.HttpContext.Request.Url.AbsoluteUri;
                var query = filterContext.RequestContext.HttpContext.Request.Url.Query;
                if (query.Length > 0)
                {
                    fullUrl = fullUrl.Replace(query, "");
                }
            }
            else
            {
                var currentPageUrl = filterContext.RequestContext.HttpContext.Request.Url;
                fullUrl = string.Format("{0}://{1}/{2}", 
                    currentPageUrl.Scheme, currentPageUrl.Authority, _urlPath.Trim('/'));
            }
            
            if (fullUrl.IndexOf("{") != -1)
            {
                foreach (var actionParam in filterContext.ActionParameters)
                {
                    UpdateUrlPlaceholders(actionParam.Key, actionParam.Value, ref fullUrl);
                }
            }

            var canonicalUrl = new CanonicalUrl(fullUrl).Url.AbsoluteUri;
            filterContext.RequestContext.HttpContext.Items["CanonicalUrl"] = canonicalUrl;

            base.OnActionExecuting(filterContext);
        }

        private void UpdateUrlPlaceholders(string key, object value, ref string fullUrl)
        {
            var type = value.GetType();

            if (!type.Equals(typeof(string)) && !type.IsPrimitive)
            {
                foreach (var property in type.GetProperties())
                {
                    var propertyValue = property.GetValue(value, null);
                    if (propertyValue == null) continue;

                    UpdateUrlPlaceholders(property.Name, propertyValue, ref fullUrl);
                }
            }
            else
            {
                fullUrl = fullUrl.Replace("{" + key + "}",
                    value.ToString(), StringComparison.InvariantCultureIgnoreCase);

            }
        }
    }
}
