using System;
using System.Web.Mvc;

namespace SeoPack.Url
{
    /// <summary>
    /// Represents a class that is used to match/comapare the request url with the supplied url.
    /// It does a redirect to the supplied url if different from the requested url.
    /// </summary>
    /// <seealso cref="System.Web.Mvc.FilterAttribute" />
    /// <seealso cref="System.Web.Mvc.IAuthorizationFilter" />
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class MatchUrlAttribute : FilterAttribute, IAuthorizationFilter, ISkipUrlPolicyCheckFilter
    {
        private readonly string _urlToMatch;
        private readonly bool _ignoreCase;

        /// <summary>
        /// Initializes a new instance of the <see cref="MatchUrlAttribute"/> class.
        /// </summary>
        /// <param name="urlToMatch">The URL to match.</param>
        /// <param name="ignoreCase">Flag indicating whether or not to ignore case when matching urls.</param>
        /// <exception cref="ArgumentException">urlToMatch not set</exception>
        public MatchUrlAttribute(string urlToMatch, bool ignoreCase = true)
        {
            if(string.IsNullOrEmpty(urlToMatch))
                throw new ArgumentException("urlToMatch not set");

            _urlToMatch = urlToMatch;
            _ignoreCase = ignoreCase;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MatchUrlAttribute"/> class.
        /// </summary>
        /// <param name="urlToMatchType">Type of the URL to match. Override ToString() on this type as ToString() 
        /// is called to get the url to match.</param>
        /// <param name="ignoreCase">Flag indicating whether or not to ignore case when matching urls.</param>
        public MatchUrlAttribute(Type urlToMatchType, bool ignoreCase = true)
            : this(GetUrlToMatch(urlToMatchType), ignoreCase)
        {
        }

        /// <summary>
        /// Called when authorization is required.
        /// </summary>
        /// <param name="filterContext">The filter context.</param>
        /// <exception cref="ArgumentNullException">filterContext</exception>
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext == null)
            {
                throw new ArgumentNullException("filterContext");
            }

            var requestUrl = filterContext
                .RequestContext.HttpContext.Request.Url.AbsoluteUri;

            bool matchFound;
            if (_ignoreCase)
                matchFound = requestUrl
                    .Equals(_urlToMatch, StringComparison.CurrentCultureIgnoreCase);
            else
                matchFound = requestUrl.Equals(_urlToMatch);

            if (!matchFound)
            {
                filterContext.Result = new RedirectResult(_urlToMatch, true);
            }
        }

        private static string GetUrlToMatch(Type urlToMatchType)
        {
            if (!urlToMatchType.IsClass)
                throw new ArgumentException("The specified type must be a class");

            var instance = Activator.CreateInstance(urlToMatchType);
            var method = urlToMatchType.GetMethod("ToString");
            return method.Invoke(instance, null) != null ? method.Invoke(instance, null).ToString() : string.Empty;
        }
    }
}
