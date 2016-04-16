using System.Web.Mvc;

namespace SeoPack.Helpers
{
    /// <summary>
    /// Represents a class that provides access to the SeoPack Html Seo Helper
    /// methods via a MVC Html Helper extension method.
    /// </summary>
    public static class HtmlHelperExtensions
    {
        private static HtmlSeoHelper _htmlSeoHelper;

        static HtmlHelperExtensions()
        {
            _htmlSeoHelper = new HtmlSeoHelper();
        }

        /// <summary>
        /// Provides access to the SeoPack Html Seo Helper methods.
        /// </summary>
        /// <param name="htmlHelper">An instance of the MVC Html Helper.</param>
        /// <returns>An instance of the Html Seo Helper class.</returns>
        public static HtmlSeoHelper UnpackSeo(this HtmlHelper htmlHelper)
        {
            return _htmlSeoHelper;
        }
    }
}
