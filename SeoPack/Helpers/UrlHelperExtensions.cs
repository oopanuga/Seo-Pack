using System.Web.Mvc;
using System.Web.Routing;
using SeoPack.Url.Canonicalization;

namespace SeoPack.Helpers
{
    /// <summary>
    /// Represents a class that provides access to the SeoPack Url Seo Helper
    /// methods via a MVC Url Helper extension method.
    /// </summary>
    public static class UrlHelperExtensions
    {
        private static UrlSeoHelper _urlSeoHelper;

        static UrlHelperExtensions()
        {
            _urlSeoHelper = new UrlSeoHelper();
        }

        /// <summary>
        /// Provides access to the SeoPack Url Seo Helper methods.
        /// </summary>
        /// <param name="urlHelper">An instance of the MVC Url Helper.</param>
        /// <returns>An instance of the Url Seo Helper class.</returns>
        public static UrlSeoHelper UnpackSeo(this UrlHelper urlHelper)
        {
            return _urlSeoHelper;
        }

        /// <summary>
        /// Generates a fully qualified canonical URL for the specified route values.
        /// </summary>
        /// <param name="urlHelper">The URL helper.</param>
        /// <param name="routeValues">The route values.</param>
        /// <returns></returns>
        public static string RouteCanonicalUrl(this UrlHelper urlHelper, object routeValues)
        {
            return CanonicalUrl.Canonicalize(urlHelper.RouteUrl(routeValues)).Url.AbsoluteUri;
        }

        /// <summary>
        /// Generates a fully qualified canonical URL for the specified route values.
        /// </summary>
        /// <param name="urlHelper">The URL helper.</param>
        /// <param name="routeValues">The route values.</param>
        /// <returns></returns>
        public static string RouteCanonicalUrl(this UrlHelper urlHelper, RouteValueDictionary routeValues)
        {
            return CanonicalUrl.Canonicalize(urlHelper.RouteUrl(routeValues)).Url.AbsoluteUri;
        }

        /// <summary>
        /// Generates a fully qualified canonical URL for the specified route values.
        /// </summary>
        /// <param name="urlHelper">The URL helper.</param>
        /// <param name="routeName">Name of the route.</param>
        /// <returns></returns>
        public static string RouteCanonicalUrl(this UrlHelper urlHelper, string routeName)
        {
            return CanonicalUrl.Canonicalize(urlHelper.RouteUrl(routeName)).Url.AbsoluteUri;
        }

        /// <summary>
        /// Generates a fully qualified canonical URL for the specified route values.
        /// </summary>
        /// <param name="urlHelper">The URL helper.</param>
        /// <param name="routeName">Name of the route.</param>
        /// <param name="routeValues">The route values.</param>
        /// <returns></returns>
        public static string RouteCanonicalUrl(this UrlHelper urlHelper, string routeName, object routeValues)
        {
            return CanonicalUrl.Canonicalize(urlHelper.RouteUrl(routeName, routeValues)).Url.AbsoluteUri;
        }

        /// <summary>
        /// Generates a fully qualified canonical URL for the specified route values.
        /// </summary>
        /// <param name="urlHelper">The URL helper.</param>
        /// <param name="routeName">Name of the route.</param>
        /// <param name="routeValues">The route values.</param>
        /// <param name="protocol">The protocol.</param>
        /// <returns></returns>
        public static string RouteCanonicalUrl(this UrlHelper urlHelper, string routeName, object routeValues, string protocol)
        {
            return CanonicalUrl.Canonicalize(urlHelper.RouteUrl(routeName, routeValues, protocol)).Url.AbsoluteUri;
        }

        /// <summary>
        /// Generates a fully qualified canonical URL for the specified route values.
        /// </summary>
        /// <param name="urlHelper">The URL helper.</param>
        /// <param name="routeName">Name of the route.</param>
        /// <param name="routeValues">The route values.</param>
        /// <param name="protocol">The protocol.</param>
        /// <param name="hostName">Name of the host.</param>
        /// <returns></returns>
        public static string RouteCanonicalUrl(this UrlHelper urlHelper, string routeName, RouteValueDictionary routeValues, string protocol, string hostName)
        {
            return CanonicalUrl.Canonicalize(urlHelper.RouteUrl(routeName, routeValues, protocol, hostName)).Url.AbsoluteUri;
        }
    }
}
