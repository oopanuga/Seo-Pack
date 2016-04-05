using System.Web.Mvc;

namespace SeoPack.Helpers
{
    public static class UrlHelperExtensions
    {
        private static UrlSeoHelper _urlSeoHelper;

        static UrlHelperExtensions()
        {
            _urlSeoHelper = new UrlSeoHelper();
        }

        public static UrlSeoHelper UnpackSeo(this UrlHelper htmlHelper)
        {
            return _urlSeoHelper;
        }
    }
}
