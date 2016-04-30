using System;
using System.Web;
using SeoPack.Url;
using System.Web.Mvc;
using System.Web.Routing;
using SeoPack.Url.UrlPolicy;

namespace SeoPack.Helpers
{
    /// <summary>
    /// Represents a class that provides access to the SeoPack Url Seo Helper
    /// methods via a MVC Url Helper extension method.
    /// </summary>
    public static class UrlHelperExtensions
    {
        private static readonly UrlSeoHelper _urlSeoHelper;

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
        /// Generates a fully qualified Seo friendly URL for the specified route values based on a set 
        /// of predefined url policies. See <see cref="UrlPolicyConfiguration"/> on configuring url 
        /// policies.
        /// </summary>
        /// <param name="urlHelper">The URL helper.</param>
        /// <param name="routeValues">The route values.</param>
        /// <returns></returns>
        public static string RouteSeoFriendlyUrl(this UrlHelper urlHelper, object routeValues)
        {
            return new SeoFriendlyUrl(ToAbsoluteUrl(urlHelper.RouteUrl(routeValues))).Value.AbsoluteUri;
        }

        /// <summary>
        /// Generates a fully qualified Seo friendly URL for the specified route values based on a set 
        /// of predefined url policies. See <see cref="UrlPolicyConfiguration"/> on configuring url 
        /// policies.
        /// </summary>
        /// <param name="urlHelper">The URL helper.</param>
        /// <param name="routeValues">The route values.</param>
        /// <returns></returns>
        public static string RouteSeoFriendlyUrl(this UrlHelper urlHelper, RouteValueDictionary routeValues)
        {
            return new SeoFriendlyUrl(ToAbsoluteUrl(urlHelper.RouteUrl(routeValues))).Value.AbsoluteUri;
        }

        /// <summary>
        /// Generates a fully qualified Seo friendly URL for the specified route values based on a set 
        /// of predefined url policies. See <see cref="UrlPolicyConfiguration"/> on configuring url 
        /// policies.
        /// </summary>
        /// <param name="urlHelper">The URL helper.</param>
        /// <param name="routeName">Name of the route.</param>
        /// <returns></returns>
        public static string RouteSeoFriendlyUrl(this UrlHelper urlHelper, string routeName)
        {
            return new SeoFriendlyUrl(ToAbsoluteUrl(urlHelper.RouteUrl(routeName))).Value.AbsoluteUri;
        }

        /// <summary>
        /// Generates a fully qualified Seo friendly URL for the specified route values based on a set 
        /// of predefined url policies. See <see cref="UrlPolicyConfiguration"/> on configuring url 
        /// policies.
        /// </summary>
        /// <param name="urlHelper">The URL helper.</param>
        /// <param name="routeName">Name of the route.</param>
        /// <param name="routeValues">The route values.</param>
        /// <returns></returns>
        public static string RouteSeoFriendlyUrl(this UrlHelper urlHelper, string routeName, object routeValues)
        {
            return new SeoFriendlyUrl(ToAbsoluteUrl(urlHelper.RouteUrl(routeName, routeValues))).Value.AbsoluteUri;
        }

        /// <summary>
        /// Generates a fully qualified Seo friendly URL for the specified route values based on a set 
        /// of predefined url policies. See <see cref="UrlPolicyConfiguration"/> on configuring url 
        /// policies.
        /// </summary>
        /// <param name="urlHelper">The URL helper.</param>
        /// <param name="routeName">Name of the route.</param>
        /// <param name="routeValues">The route values.</param>
        /// <param name="protocol">The protocol.</param>
        /// <returns></returns>
        public static string RouteSeoFriendlyUrl(this UrlHelper urlHelper, string routeName, object routeValues, string protocol)
        {
            return new SeoFriendlyUrl(urlHelper.RouteUrl(routeName, routeValues, protocol)).Value.AbsoluteUri;
        }

        /// <summary>
        /// Generates a fully qualified Seo friendly URL for the specified route values based on a set 
        /// of predefined url policies. See <see cref="UrlPolicyConfiguration"/> on configuring url 
        /// policies.
        /// </summary>
        /// <param name="urlHelper">The URL helper.</param>
        /// <param name="routeName">Name of the route.</param>
        /// <param name="routeValues">The route values.</param>
        /// <param name="protocol">The protocol.</param>
        /// <param name="hostName">Name of the host.</param>
        /// <returns></returns>
        public static string RouteSeoFriendlyUrl(this UrlHelper urlHelper, string routeName, RouteValueDictionary routeValues, string protocol, string hostName)
        {
            return new SeoFriendlyUrl(urlHelper.RouteUrl(routeName, routeValues, protocol, hostName)).Value.AbsoluteUri;
        }

        private static string ToAbsoluteUrl(string route)
        {
            var requestUrl = HttpContext.Current.Request.Url;
            return string.Format("{0}://{1}/{2}",
                                                  requestUrl.Scheme,
                                                  requestUrl.Authority,
                                                  route);
        }
    }
}
