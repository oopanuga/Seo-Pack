using SeoPack.Url;
using SeoPack.Url.UrlPolicy;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SeoPack.Helpers
{
    /// <summary>
    /// Represents a class that provides access to the SeoPack Url Seo Helper
    /// methods via a MVC Url Helper extension method.
    /// </summary>F
    public static class UrlHelperExtensions
    {
        /// <summary>
        /// Generates a fully qualified Canonical URL for the specified route values based on a set 
        /// of predefined url policies. See <see cref="UrlPolicyConfiguration"/> on configuring url 
        /// policies.
        /// </summary>
        /// <param name="urlHelper">The URL helper.</param>
        /// <param name="routeValues">The route values.</param>
        /// <param name="isRelativeUrl">A value indicating whether to return an absolute or relative url.
        /// The default is absolute.</param>
        /// <returns>Route Canonical Url.</returns>
        public static string SpRouteUrl(this UrlHelper urlHelper, object routeValues, bool isRelativeUrl = false)
        {
            return ToCanonicalUrl(urlHelper.RouteUrl(routeValues), isRelativeUrl);
        }

        /// <summary>
        /// Generates a fully qualified Canonical URL for the specified route values based on a set 
        /// of predefined url policies. See <see cref="UrlPolicyConfiguration"/> on configuring url 
        /// policies.
        /// </summary>
        /// <param name="urlHelper">The URL helper.</param>
        /// <param name="routeValues">The route values.</param>
        /// <param name="isRelativeUrl">A value indicating whether to return an absolute or relative url.
        /// The default is absolute.</param>
        /// <returns>Route Canonical Url.</returns>
        public static string SpRouteUrl(this UrlHelper urlHelper, RouteValueDictionary routeValues, bool isRelativeUrl = false)
        {
            return ToCanonicalUrl(urlHelper.RouteUrl(routeValues), isRelativeUrl);
        }

        /// <summary>
        /// Generates a fully qualified Canonical URL for the specified route name based on a set 
        /// of predefined url policies. See <see cref="UrlPolicyConfiguration"/> on configuring url 
        /// policies.
        /// </summary>
        /// <param name="urlHelper">The URL helper.</param>
        /// <param name="routeName">Name of the route.</param>
        /// <param name="isRelativeUrl">A value indicating whether to return an absolute or relative url.
        /// The default is absolute.</param>
        /// <returns>Route Canonical Url.</returns>
        public static string SpRouteUrl(this UrlHelper urlHelper, string routeName, bool isRelativeUrl = false)
        {
            return ToCanonicalUrl(urlHelper.RouteUrl(routeName), isRelativeUrl);
        }

        /// <summary>
        /// Generates a fully qualified Canonical URL for the specified route values by using a route name.
        /// It does this based on a set of predefined url policies. See <see cref="UrlPolicyConfiguration"/> 
        /// on configuring url policies.
        /// </summary>
        /// <param name="urlHelper">The URL helper.</param>
        /// <param name="routeName">Name of the route.</param>
        /// <param name="routeValues">The route values.</param>
        /// <param name="isRelativeUrl">A value indicating whether to return an absolute or relative url.
        /// The default is absolute.</param>
        /// <returns>Route Canonical Url.</returns>
        public static string SpRouteUrl(this UrlHelper urlHelper, string routeName, object routeValues, bool isRelativeUrl = false)
        {
            return ToCanonicalUrl(urlHelper.RouteUrl(routeName, routeValues), isRelativeUrl);
        }

        /// <summary>
        /// Generates a fully qualified Canonical URL for the specified route values by using a route name.
        /// It does this based on a set of predefined url policies. See <see cref="UrlPolicyConfiguration"/> 
        /// on configuring url policies.
        /// </summary>
        /// <param name="urlHelper">The URL helper.</param>
        /// <param name="routeName">Name of the route.</param>
        /// <param name="routeValues">The route values.</param>
        /// <param name="isRelativeUrl">A value indicating whether to return an absolute or relative url.
        /// The default is absolute.</param>
        /// <returns>Route Canonical Url.</returns>
        public static string SpRouteUrl(this UrlHelper urlHelper, string routeName, RouteValueDictionary routeValues, bool isRelativeUrl = false)
        {
            return ToCanonicalUrl(urlHelper.RouteUrl(routeName, routeValues), isRelativeUrl);
        }

        /// <summary>
        /// Generates a fully qualified Canonical URL for the specified route values by using a route name and protocol.
        /// It does this based on a set of predefined url policies. See <see cref="UrlPolicyConfiguration"/> on configuring 
        /// url policies.
        /// </summary>
        /// <param name="urlHelper">The URL helper.</param>
        /// <param name="routeName">Name of the route.</param>
        /// <param name="routeValues">The route values.</param>
        /// <param name="protocol">The protocol.</param>
        /// <returns>Route Canonical Url.</returns>
        public static string SpRouteUrl(this UrlHelper urlHelper, string routeName, object routeValues, string protocol)
        {
            return ToCanonicalUrl(urlHelper.RouteUrl(routeName, routeValues, protocol), false);
        }

        /// <summary>
        /// Generates a fully qualified Canonical URL for the specified route values by using a route name, protocol and host name.
        /// It does this based on a set of predefined url policies. See <see cref="UrlPolicyConfiguration"/> on configuring url policies.
        /// </summary>
        /// <param name="urlHelper">The URL helper.</param>
        /// <param name="routeName">Name of the route.</param>
        /// <param name="routeValues">The route values.</param>
        /// <param name="protocol">The protocol.</param>
        /// <param name="hostName">Name of the host.</param>
        /// <returns>Route Canonical Url.</returns>
        public static string SpRouteUrl(this UrlHelper urlHelper, string routeName, RouteValueDictionary routeValues, string protocol, string hostName)
        {
            return ToCanonicalUrl(urlHelper.RouteUrl(routeName, routeValues, protocol, hostName), false);
        }

        /// <summary>
        /// Generates a fully qualified Canonical URL to an action method by using the specified action name.
        /// It does this based on a set of predefined url policies. See <see cref="UrlPolicyConfiguration"/> on 
        /// configuring url policies.
        /// </summary>
        /// <param name="urlHelper">The URL helper.</param>
        /// <param name="actionName">Name of the action.</param>
        /// <param name="isRelativeUrl">A value indicating whether to return an absolute or relative url.
        /// The default is absolute.</param>
        /// <returns>Action Canonical Url.</returns>
        public static string SpActionUrl(this UrlHelper urlHelper, string actionName, bool isRelativeUrl = false)
        {
            return ToCanonicalUrl(urlHelper.Action(actionName), isRelativeUrl);
        }

        /// <summary>
        /// Generates a fully qualified Canonical URL to an action method by using the specified action name and route values.
        /// It does this based on a set of predefined url policies. See <see cref="UrlPolicyConfiguration"/> on configuring url 
        /// policies.
        /// </summary>
        /// <param name="urlHelper">The URL helper.</param>
        /// <param name="actionName">Name of the action.</param>
        /// <param name="routeValues">The route values.</param>
        /// <param name="isRelativeUrl">A value indicating whether to return an absolute or relative url.
        /// The default is absolute.</param>
        /// <returns>Action Canonical Url.</returns>
        public static string SpActionUrl(this UrlHelper urlHelper, string actionName, object routeValues, bool isRelativeUrl = false)
        {
            return ToCanonicalUrl(urlHelper.Action(actionName, routeValues), isRelativeUrl);
        }

        /// <summary>
        /// Generates a fully qualified Canonical URL to an action method by using the specified action name and route values.
        /// It does this based on a set of predefined url policies. See <see cref="UrlPolicyConfiguration"/> on configuring url 
        /// policies.
        /// </summary>
        /// <param name="urlHelper">The URL helper.</param>
        /// <param name="actionName">Name of the action.</param>
        /// <param name="routeValues">The route values.</param>
        /// <param name="isRelativeUrl">A value indicating whether to return an absolute or relative url.
        /// The default is absolute.</param>
        /// <returns>Action Canonical Url.</returns>
        public static string SpActionUrl(this UrlHelper urlHelper, string actionName, RouteValueDictionary routeValues, bool isRelativeUrl = false)
        {
            return ToCanonicalUrl(urlHelper.Action(actionName, routeValues), isRelativeUrl);
        }

        /// <summary>
        /// Generates a fully qualified Canonical URL to an action method by using the specified action name and controller.
        /// It does this based on a set of predefined url policies. See <see cref="UrlPolicyConfiguration"/> on configuring url 
        /// policies.
        /// </summary>
        /// <param name="urlHelper">The URL helper.</param>
        /// <param name="actionName">Name of the action.</param>
        /// <param name="controllerName">Name of the controller.</param>
        /// <param name="isRelativeUrl">A value indicating whether to return an absolute or relative url.
        /// The default is absolute.</param>
        /// <returns>Action Canonical Url.</returns>
        public static string SpActionUrl(this UrlHelper urlHelper, string actionName, string controllerName, bool isRelativeUrl = false)
        {
            return ToCanonicalUrl(urlHelper.Action(actionName, controllerName), isRelativeUrl);
        }

        /// <summary>
        /// Generates a fully qualified Canonical URL to an action method by using the specified action name, controller and route values.
        /// It does this based on a set of predefined url policies. See <see cref="UrlPolicyConfiguration"/> on configuring url policies.
        /// </summary>
        /// <param name="urlHelper">The URL helper.</param>
        /// <param name="actionName">Name of the action.</param>
        /// <param name="controllerName">Name of the controller.</param>
        /// <param name="routeValues">The route values.</param>
        /// <param name="isRelativeUrl">A value indicating whether to return an absolute or relative url.
        /// The default is absolute.</param>
        /// <returns>Action Canonical Url.</returns>
        public static string SpActionUrl(this UrlHelper urlHelper, string actionName, string controllerName, object routeValues, bool isRelativeUrl = false)
        {
            return ToCanonicalUrl(urlHelper.Action(actionName, controllerName, routeValues), isRelativeUrl);
        }

        /// <summary>
        /// Generates a fully qualified Canonical URL to an action method by using the specified action name, controller and route values.
        /// It does this based on a set of predefined url policies. See <see cref="UrlPolicyConfiguration"/> on configuring url policies.
        /// </summary>
        /// <param name="urlHelper">The URL helper.</param>
        /// <param name="actionName">Name of the action.</param>
        /// <param name="controllerName">Name of the controller.</param>
        /// <param name="routeValues">The route values.</param>
        /// <param name="isRelativeUrl">A value indicating whether to return an absolute or relative url.
        /// The default is absolute.</param>
        /// <returns>Action Canonical Url.</returns>
        public static string SpActionUrl(this UrlHelper urlHelper, string actionName, string controllerName, RouteValueDictionary routeValues, bool isRelativeUrl = false)
        {
            return ToCanonicalUrl(urlHelper.Action(actionName, controllerName, routeValues), isRelativeUrl);
        }

        /// <summary>
        /// Generates a fully qualified Canonical URL to an action method by using the specified action name, controller, route values and protocol.
        /// It does this based on a set of predefined url policies. See <see cref="UrlPolicyConfiguration"/> on configuring url policies.
        /// </summary>
        /// <param name="urlHelper">The URL helper.</param>
        /// <param name="actionName">Name of the action.</param>
        /// <param name="controllerName">Name of the controller.</param>
        /// <param name="routeValues">The route values.</param>
        /// <param name="protocol">The protocol.</param>
        /// <returns>Action Canonical Url.</returns>
        public static string SpActionUrl(this UrlHelper urlHelper, string actionName, string controllerName, object routeValues, string protocol)
        {
            return ToCanonicalUrl(urlHelper.Action(actionName, controllerName, routeValues, protocol), false);
        }

        /// <summary>
        /// Generates a fully qualified Canonical URL to an action method by using the specified action name, controller, route values, protocol.
        /// and host name. It does this based on a set of predefined url policies. See <see cref="UrlPolicyConfiguration"/> on configuring url policies.
        /// </summary>
        /// <param name="urlHelper">The URL helper.</param>
        /// <param name="actionName">Name of the action.</param>
        /// <param name="controllerName">Name of the controller.</param>
        /// <param name="routeValues">The route values.</param>
        /// <param name="protocol">The protocol.</param>
        /// <param name="hostName">Name of the host.</param>
        /// <returns>Action Canonical Url.</returns>
        public static string SpActionUrl(this UrlHelper urlHelper, string actionName, string controllerName, RouteValueDictionary routeValues, string protocol, string hostName)
        {
            return ToCanonicalUrl(urlHelper.Action(actionName, controllerName, routeValues, protocol, hostName), false);
        }

        /// <summary>
        /// Attempts to get the canonical url of the current page from the HttpContext.Current.Items["CanonicalUrl"]
        /// if the canonical url path was set in the <see cref="CanonicalUrlAttribute"/> on the action method. If this 
        /// isn't the case then it will return the current page url stripped off any querystrings and make it Canonical
        /// using the predefined url policies. See <see cref="UrlPolicyConfiguration"/> on configuring url policies.
        /// </summary>
        /// <param name="urlHelper">The URL helper.</param>
        /// <returns>The canonical url.</returns>
        public static string CanonicalUrl(this UrlHelper urlHelper)
        {
            var canonicalUrl = HttpContext.Current.Items["CanonicalUrl"] as string;
            if (!string.IsNullOrEmpty(canonicalUrl))
            {
                return canonicalUrl;
            }

            canonicalUrl = HttpContext.Current.Request.Url.AbsoluteUri;

            var query = HttpContext.Current.Request.Url.Query;
            if (query.Length > 0)
            {
                canonicalUrl = canonicalUrl.Replace(query, "");
            }

            return new CanonicalUrl(canonicalUrl).Value.ToString();
        }

        /// <summary>
        /// It makes a url Canonical by making it conform to a set of predefined url policies.
        /// See <see cref="UrlPolicyConfiguration"/> on configuring url policies.
        /// </summary>
        /// <param name="urlHelper">The URL helper.</param>
        /// <param name="url">The url to make Canonical.</param>
        /// <returns>The canonical url.</returns>
        public static string ToCanonicalUrl(this UrlHelper urlHelper, string url)
        {
            return new CanonicalUrl(url).Value.ToString();
        }

        private static string ToCanonicalUrl(string url, bool isRelativeUrl)
        {
            if (url.StartsWith("/"))
            {
                var requestUrl = HttpContext.Current.Request.Url;
                url = string.Format("{0}://{1}{2}",
                                                      requestUrl.Scheme,
                                                      requestUrl.Authority,
                                                      url);
            }

            var canonicalUrl = new CanonicalUrl(url).Value;

            return isRelativeUrl ? canonicalUrl.PathAndQuery : canonicalUrl.AbsoluteUri;
        }
    }
}
