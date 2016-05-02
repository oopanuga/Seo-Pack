using System.Web;
using SeoPack.Url;
using SeoPack.Url.UrlPolicy;
using System.Web.Mvc;
using System.Web.Routing;

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
        /// <param name="isRelativeUrl">A value indicating whether to return an absolute or relative url.
        /// The default is absolute.</param>
        /// <returns>Route Seo Friendly Url.</returns>
        public static string RouteSeoFriendlyUrl(this UrlHelper urlHelper, object routeValues, bool isRelativeUrl = false)
        {
            return ToSeoFriendlyUrl(urlHelper.RouteUrl(routeValues), isRelativeUrl);
        }

        /// <summary>
        /// Generates a fully qualified Seo friendly URL for the specified route values based on a set 
        /// of predefined url policies. See <see cref="UrlPolicyConfiguration"/> on configuring url 
        /// policies.
        /// </summary>
        /// <param name="urlHelper">The URL helper.</param>
        /// <param name="routeValues">The route values.</param>
        /// <param name="isRelativeUrl">A value indicating whether to return an absolute or relative url.
        /// The default is absolute.</param>
        /// <returns>Route Seo Friendly Url.</returns>
        public static string RouteSeoFriendlyUrl(this UrlHelper urlHelper, RouteValueDictionary routeValues, bool isRelativeUrl = false)
        {
            return ToSeoFriendlyUrl(urlHelper.RouteUrl(routeValues), isRelativeUrl);
        }

        /// <summary>
        /// Generates a fully qualified Seo friendly URL for the specified route name based on a set 
        /// of predefined url policies. See <see cref="UrlPolicyConfiguration"/> on configuring url 
        /// policies.
        /// </summary>
        /// <param name="urlHelper">The URL helper.</param>
        /// <param name="routeName">Name of the route.</param>
        /// <param name="isRelativeUrl">A value indicating whether to return an absolute or relative url.
        /// The default is absolute.</param>
        /// <returns>Route Seo Friendly Url.</returns>
        public static string RouteSeoFriendlyUrl(this UrlHelper urlHelper, string routeName, bool isRelativeUrl = false)
        {
            return ToSeoFriendlyUrl(urlHelper.RouteUrl(routeName), isRelativeUrl);
        }

        /// <summary>
        /// Generates a fully qualified Seo friendly URL for the specified route values by using a route name.
        /// It does this based on a set of predefined url policies. See <see cref="UrlPolicyConfiguration"/> 
        /// on configuring url policies.
        /// </summary>
        /// <param name="urlHelper">The URL helper.</param>
        /// <param name="routeName">Name of the route.</param>
        /// <param name="routeValues">The route values.</param>
        /// <param name="isRelativeUrl">A value indicating whether to return an absolute or relative url.
        /// The default is absolute.</param>
        /// <returns>Route Seo Friendly Url.</returns>
        public static string RouteSeoFriendlyUrl(this UrlHelper urlHelper, string routeName, object routeValues, bool isRelativeUrl = false)
        {
            return ToSeoFriendlyUrl(urlHelper.RouteUrl(routeName, routeValues), isRelativeUrl);
        }

        /// <summary>
        /// Generates a fully qualified Seo friendly URL for the specified route values by using a route name.
        /// It does this based on a set of predefined url policies. See <see cref="UrlPolicyConfiguration"/> 
        /// on configuring url policies.
        /// </summary>
        /// <param name="urlHelper">The URL helper.</param>
        /// <param name="routeName">Name of the route.</param>
        /// <param name="routeValues">The route values.</param>
        /// <param name="isRelativeUrl">A value indicating whether to return an absolute or relative url.
        /// The default is absolute.</param>
        /// <returns>Route Seo Friendly Url.</returns>
        public static string RouteSeoFriendlyUrl(this UrlHelper urlHelper, string routeName, RouteValueDictionary routeValues, bool isRelativeUrl = false)
        {
            return ToSeoFriendlyUrl(urlHelper.RouteUrl(routeName, routeValues), isRelativeUrl);
        }

        /// <summary>
        /// Generates a fully qualified Seo friendly URL for the specified route values by using a route name and protocol.
        /// It does this based on a set of predefined url policies. See <see cref="UrlPolicyConfiguration"/> on configuring 
        /// url policies.
        /// </summary>
        /// <param name="urlHelper">The URL helper.</param>
        /// <param name="routeName">Name of the route.</param>
        /// <param name="routeValues">The route values.</param>
        /// <param name="protocol">The protocol.</param>
        /// <returns>Route Seo Friendly Url.</returns>
        public static string RouteSeoFriendlyUrl(this UrlHelper urlHelper, string routeName, object routeValues, string protocol)
        {
            return ToSeoFriendlyUrl(urlHelper.RouteUrl(routeName, routeValues, protocol), false);
        }

        /// <summary>
        /// Generates a fully qualified Seo friendly URL for the specified route values by using a route name, protocol and host name.
        /// It does this based on a set of predefined url policies. See <see cref="UrlPolicyConfiguration"/> on configuring url policies.
        /// </summary>
        /// <param name="urlHelper">The URL helper.</param>
        /// <param name="routeName">Name of the route.</param>
        /// <param name="routeValues">The route values.</param>
        /// <param name="protocol">The protocol.</param>
        /// <param name="hostName">Name of the host.</param>
        /// <returns>Route Seo Friendly Url.</returns>
        public static string RouteSeoFriendlyUrl(this UrlHelper urlHelper, string routeName, RouteValueDictionary routeValues, string protocol, string hostName)
        {
            return ToSeoFriendlyUrl(urlHelper.RouteUrl(routeName, routeValues, protocol, hostName), false);
        }

        /// <summary>
        /// Generates a fully qualified Seo Friendly URL to an action method by using the specified action name.
        /// It does this based on a set of predefined url policies. See <see cref="UrlPolicyConfiguration"/> on 
        /// configuring url policies.
        /// </summary>
        /// <param name="urlHelper">The URL helper.</param>
        /// <param name="actionName">Name of the action.</param>
        /// <param name="isRelativeUrl">A value indicating whether to return an absolute or relative url.
        /// The default is absolute.</param>
        /// <returns>Action Seo Friendly Url.</returns>
        public static string ActionSeoFriendlyUrl(this UrlHelper urlHelper, string actionName, bool isRelativeUrl = false)
        {
            return ToSeoFriendlyUrl(urlHelper.Action(actionName), isRelativeUrl);
        }

        /// <summary>
        /// Generates a fully qualified Seo Friendly URL to an action method by using the specified action name and route values.
        /// It does this based on a set of predefined url policies. See <see cref="UrlPolicyConfiguration"/> on configuring url 
        /// policies.
        /// </summary>
        /// <param name="urlHelper">The URL helper.</param>
        /// <param name="actionName">Name of the action.</param>
        /// <param name="routeValues">The route values.</param>
        /// <param name="isRelativeUrl">A value indicating whether to return an absolute or relative url.
        /// The default is absolute.</param>
        /// <returns>Action Seo Friendly Url.</returns>
        public static string ActionSeoFriendlyUrl(this UrlHelper urlHelper, string actionName, object routeValues, bool isRelativeUrl = false)
        {
            return ToSeoFriendlyUrl(urlHelper.Action(actionName, routeValues), isRelativeUrl);
        }

        /// <summary>
        /// Generates a fully qualified Seo Friendly URL to an action method by using the specified action name and route values.
        /// It does this based on a set of predefined url policies. See <see cref="UrlPolicyConfiguration"/> on configuring url 
        /// policies.
        /// </summary>
        /// <param name="urlHelper">The URL helper.</param>
        /// <param name="actionName">Name of the action.</param>
        /// <param name="routeValues">The route values.</param>
        /// <param name="isRelativeUrl">A value indicating whether to return an absolute or relative url.
        /// The default is absolute.</param>
        /// <returns>Action Seo Friendly Url.</returns>
        public static string ActionSeoFriendlyUrl(this UrlHelper urlHelper, string actionName, RouteValueDictionary routeValues, bool isRelativeUrl = false)
        {
            return ToSeoFriendlyUrl(urlHelper.Action(actionName, routeValues), isRelativeUrl);
        }

        /// <summary>
        /// Generates a fully qualified Seo Friendly URL to an action method by using the specified action name and controller.
        /// It does this based on a set of predefined url policies. See <see cref="UrlPolicyConfiguration"/> on configuring url 
        /// policies.
        /// </summary>
        /// <param name="urlHelper">The URL helper.</param>
        /// <param name="actionName">Name of the action.</param>
        /// <param name="controllerName">Name of the controller.</param>
        /// <param name="isRelativeUrl">A value indicating whether to return an absolute or relative url.
        /// The default is absolute.</param>
        /// <returns>Action Seo Friendly Url.</returns>
        public static string ActionSeoFriendlyUrl(this UrlHelper urlHelper, string actionName, string controllerName, bool isRelativeUrl = false)
        {
            return ToSeoFriendlyUrl(urlHelper.Action(actionName, controllerName), isRelativeUrl);
        }

        /// <summary>
        /// Generates a fully qualified Seo Friendly URL to an action method by using the specified action name, controller and route values.
        /// It does this based on a set of predefined url policies. See <see cref="UrlPolicyConfiguration"/> on configuring url policies.
        /// </summary>
        /// <param name="urlHelper">The URL helper.</param>
        /// <param name="actionName">Name of the action.</param>
        /// <param name="controllerName">Name of the controller.</param>
        /// <param name="routeValues">The route values.</param>
        /// <param name="isRelativeUrl">A value indicating whether to return an absolute or relative url.
        /// The default is absolute.</param>
        /// <returns>Action Seo Friendly Url.</returns>
        public static string ActionSeoFriendlyUrl(this UrlHelper urlHelper, string actionName, string controllerName, object routeValues, bool isRelativeUrl = false)
        {
            return ToSeoFriendlyUrl(urlHelper.Action(actionName, controllerName, routeValues), isRelativeUrl);
        }

        /// <summary>
        /// Generates a fully qualified Seo Friendly URL to an action method by using the specified action name, controller and route values.
        /// It does this based on a set of predefined url policies. See <see cref="UrlPolicyConfiguration"/> on configuring url policies.
        /// </summary>
        /// <param name="urlHelper">The URL helper.</param>
        /// <param name="actionName">Name of the action.</param>
        /// <param name="controllerName">Name of the controller.</param>
        /// <param name="routeValues">The route values.</param>
        /// <param name="isRelativeUrl">A value indicating whether to return an absolute or relative url.
        /// The default is absolute.</param>
        /// <returns>Action Seo Friendly Url.</returns>
        public static string ActionSeoFriendlyUrl(this UrlHelper urlHelper, string actionName, string controllerName, RouteValueDictionary routeValues, bool isRelativeUrl = false)
        {
            return ToSeoFriendlyUrl(urlHelper.Action(actionName, controllerName, routeValues), isRelativeUrl);
        }

        /// <summary>
        /// Generates a fully qualified Seo Friendly URL to an action method by using the specified action name, controller, route values and protocol.
        /// It does this based on a set of predefined url policies. See <see cref="UrlPolicyConfiguration"/> on configuring url policies.
        /// </summary>
        /// <param name="urlHelper">The URL helper.</param>
        /// <param name="actionName">Name of the action.</param>
        /// <param name="controllerName">Name of the controller.</param>
        /// <param name="routeValues">The route values.</param>
        /// <param name="protocol">The protocol.</param>
        /// <returns>Action Seo Friendly Url.</returns>
        public static string ActionSeoFriendlyUrl(this UrlHelper urlHelper, string actionName, string controllerName, object routeValues, string protocol)
        {
            return ToSeoFriendlyUrl(urlHelper.Action(actionName, controllerName, routeValues, protocol), false);
        }

        /// <summary>
        /// Generates a fully qualified Seo Friendly URL to an action method by using the specified action name, controller, route values, protocol.
        /// and host name. It does this based on a set of predefined url policies. See <see cref="UrlPolicyConfiguration"/> on configuring url policies.
        /// </summary>
        /// <param name="urlHelper">The URL helper.</param>
        /// <param name="actionName">Name of the action.</param>
        /// <param name="controllerName">Name of the controller.</param>
        /// <param name="routeValues">The route values.</param>
        /// <param name="protocol">The protocol.</param>
        /// <param name="hostName">Name of the host.</param>
        /// <returns>Action Seo Friendly Url.</returns>
        public static string ActionSeoFriendlyUrl(this UrlHelper urlHelper, string actionName, string controllerName, RouteValueDictionary routeValues, string protocol, string hostName)
        {
            return ToSeoFriendlyUrl(urlHelper.Action(actionName, controllerName, routeValues, protocol, hostName), false);
        }

        private static string ToSeoFriendlyUrl(string url, bool isRelativeUrl)
        {
            if (url.StartsWith("/"))
            {
                var requestUrl = HttpContext.Current.Request.Url;
                url = string.Format("{0}://{1}{2}",
                                                      requestUrl.Scheme,
                                                      requestUrl.Authority,
                                                      url);
            }

            var seoFriendlyUrl = new SeoFriendlyUrl(url).Value;

            return isRelativeUrl ? seoFriendlyUrl.PathAndQuery : seoFriendlyUrl.AbsoluteUri;
        }
    }
}
