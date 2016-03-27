using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace SeoPack.Helpers
{
    public static class HtmlHelperExtensions
    {
        private static HtmlSeoHelper _htmlSeoHelper;

        static HtmlHelperExtensions()
        {
            _htmlSeoHelper = new HtmlSeoHelper();
        }

        public static HtmlSeoHelper UnpackSeo(this HtmlHelper htmlHelper)
        {
            return _htmlSeoHelper;
        }
    }
}
