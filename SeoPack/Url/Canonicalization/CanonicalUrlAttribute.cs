using System;
using System.Web.Mvc;

namespace SeoPack.Url.Canonicalization
{
    /// <summary>
    /// 
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
    public class CanonicalUrlAttribute : ActionFilterAttribute
    {
        private string _urlSegment;
        private string _fullUrl;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="urlSegment"></param>
        public CanonicalUrlAttribute(string urlSegment)
        {
            if (string.IsNullOrEmpty(urlSegment))
            {
                throw new ArgumentException("url not set");
            }

            _urlSegment = urlSegment;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filterContext"></param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (_urlSegment.IndexOf("{") != -1)
            {
                _fullUrl = string.Empty;

                if (_urlSegment.IndexOf("http") != -1)
                {
                    _fullUrl = _urlSegment;
                }
                else
                {
                    var currentPageUrl = filterContext.RequestContext.HttpContext.Request.Url;

                    _fullUrl = string.Format("{0}://{1}/{2}",
                        currentPageUrl.Scheme, currentPageUrl.Authority, _urlSegment);
                }

                foreach (var actionParam in filterContext.ActionParameters)
                {
                    if (_fullUrl.Contains(actionParam.Key.ToLower()))
                    {
                        UpdateUrlPlaceholders(actionParam.Key, actionParam.Value);
                    }
                }
            }
            
            var canonicalUrl = new CanonicalUrl(_fullUrl).AbsoluteUri;
            filterContext.RequestContext.HttpContext.Items["CanonicalUrl"] = canonicalUrl;
            filterContext.Controller.ViewData["CanonicalUrl"] = canonicalUrl;

            base.OnActionExecuting(filterContext);
        }

        private void UpdateUrlPlaceholders(string key, object value)
        {
            var type = value.GetType();

            if (!type.Equals(typeof(string)) && !type.IsPrimitive)
            {
                foreach (var property in type.GetProperties())
                {
                    var propertyValue = property.GetValue(value, null);
                    if (propertyValue == null) continue;
                    var propertyType = property.PropertyType;

                    if (!propertyType.Equals(typeof(string)) && !propertyType.IsPrimitive)
                    {
                        UpdateUrlPlaceholders(key, propertyValue);
                        continue;
                    }
                }
            }

            _fullUrl = _fullUrl.Replace("{" + key + "}", value.ToString(), 
                StringComparison.InvariantCultureIgnoreCase);
        }
    }
}
