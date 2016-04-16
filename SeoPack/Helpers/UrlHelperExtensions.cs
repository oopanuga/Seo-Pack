using System.Web.Mvc;

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
        /// <param name="urlHelperHelper">An instance of the MVC Url Helper.</param>
        /// <returns>An instance of the Url Seo Helper class.</returns>
        public static UrlSeoHelper UnpackSeo(this UrlHelper urlHelperHelper)
        {
            return _urlSeoHelper;
        }
    }
}
