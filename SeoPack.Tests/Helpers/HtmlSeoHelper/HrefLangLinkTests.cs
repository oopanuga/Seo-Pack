using NUnit.Framework;
using SeoPack.Html;
using System.Collections.Generic;
using System.IO;
using System.Web;

namespace SeoPack.Tests.Helpers.HtmlSeoHelper
{
    [Category("HtmlSeoHelper.HrefLangLink")]
    [TestFixture]
    public class HrefLangLinkTests
    {
        [Test]
        public void Should_display_hreflanglinks_only_when_on_canonical_version_of_page()
        {
            var gbLang = "en-gb";
            var usLang = "en-us";
            var marketplacePageName = "Marketplace";
            var aboutUsPageName = "AboutUs";

            HttpContext.Current = new HttpContext(
                new HttpRequest("", "http://www.seopack.com/gb/marketplace", ""),
                new HttpResponse(new StringWriter()));


            var hrefLangPages = new List<HrefLangPage>();

            var marketingPage = new HrefLangPage(marketplacePageName);
            marketingPage.AddHrefLangLink(new HrefLangLink("http://www.seopack.com/marketplace"));
            marketingPage.AddHrefLangLink(new HrefLangLink("http://www.seopack.com/gb/marketplace", gbLang));
            marketingPage.AddHrefLangLink(new HrefLangLink("http://www.seopack.com/us/marketplace", usLang));
            hrefLangPages.Add(marketingPage);

            var aboutUsPage = new HrefLangPage(aboutUsPageName);
            aboutUsPage.AddHrefLangLink(new HrefLangLink("http://www.seopack.com/aboutus"));
            aboutUsPage.AddHrefLangLink(new HrefLangLink("http://www.seopack.com/gb/aboutus", gbLang));
            aboutUsPage.AddHrefLangLink(new HrefLangLink("http://www.seopack.com/us/aboutus", usLang));
            hrefLangPages.Add(aboutUsPage);

            var seoHelper = new SeoPack.Helpers.HtmlSeoHelper();
            var output = seoHelper.HrefLangLink(hrefLangPages);

            Assert.That(output.ToString(), Is.EqualTo("<link rel=\"alternate\" hreflang=\"x-default\" href=\"http://www.seopack.com/marketplace\" />" +
                "<link rel=\"alternate\" hreflang=\"en-gb\" href=\"http://www.seopack.com/gb/marketplace\" /><link rel=\"alternate\" hreflang=\"en-us\" href=\"http://www.seopack.com/us/marketplace\" />"));
        }
    }
}
