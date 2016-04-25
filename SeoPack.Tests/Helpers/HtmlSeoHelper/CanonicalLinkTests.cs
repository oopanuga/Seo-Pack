using NUnit.Framework;
using System;
using System.IO;
using System.Web;

namespace SeoPack.Tests.Helpers.HtmlSeoHelper
{
    [Category("HtmlSeoHelper.CanonicalLinkIfRequired")]
    [TestFixture]
    public class CanonicalLinkTests
    {
        [TestCase(null)]
        [TestCase("")]
        [ExpectedException(typeof(ArgumentException))]
        public void Should_throw_exception_if_canonicalurl_is_not_set(string canonicalUrl)
        {
            var seoHelper = new SeoPack.Helpers.HtmlSeoHelper();
            seoHelper.CanonicalLinkIfRequired(canonicalUrl);
        }

        [Test]
        public void Should_return_seo_compliant_canonicallink_when_not_on_canonical_version_of_page_and_current_page_url_starts_with_canonical_url()
        {
            var canonicalUrl = "http://www.seopack.com/marketplace";
            var currentPageUrl = "http://www.seopack.com/marketplace?query=seo";

            HttpContext.Current = new HttpContext(
                new HttpRequest("", currentPageUrl, ""),
                new HttpResponse(new StringWriter()));

            var seoHelper = new SeoPack.Helpers.HtmlSeoHelper();
            var output = seoHelper.CanonicalLinkIfRequired(canonicalUrl);

            Assert.That(output.ToString(), Is.EqualTo(string.Format("<link rel=\"canonical\" href=\"{0}\" />", canonicalUrl)));
        }

        [Test]
        public void Should_return_an_empty_string_when_on_canonical_version_of_page()
        {
            var canonicalUrl = "http://www.seopack.com/marketplace";
            var currentPageUrl = "http://www.seopack.com/marketplace";

            HttpContext.Current = new HttpContext(
                new HttpRequest("", currentPageUrl, ""),
                new HttpResponse(new StringWriter()));

            var seoHelper = new SeoPack.Helpers.HtmlSeoHelper();
            var output = seoHelper.CanonicalLinkIfRequired(canonicalUrl);

            Assert.That(output.ToString(), Is.EqualTo(string.Empty));
        }

        [Test]
        public void Should_return_an_empty_string_when_current_page_url_does_not_start_with_canonical_url()
        {
            var canonicalUrl = "http://www.seopack.com/marketplace";
            var currentPageUrl = "http://www.seopack.com/blog?category=somecategory";

            HttpContext.Current = new HttpContext(
                new HttpRequest("", currentPageUrl, ""),
                new HttpResponse(new StringWriter()));

            var seoHelper = new SeoPack.Helpers.HtmlSeoHelper();
            var output = seoHelper.CanonicalLinkIfRequired(canonicalUrl);

            Assert.That(output.ToString(), Is.EqualTo(string.Empty));
        }

        [Test]
        public void Should_return_seo_compliant_canonicallink_if_inferred_canonical_url_is_not_the_same_as_the_current_page_url()
        {
            var canonicalUrl = "http://www.seopack.com/marketplace";
            var currentPageUrl = "http://www.seopack.com/marketplace?query=seo";

            HttpContext.Current = new HttpContext(
                new HttpRequest("", currentPageUrl, ""),
                new HttpResponse(new StringWriter()));

            var seoHelper = new SeoPack.Helpers.HtmlSeoHelper();
            var output = seoHelper.CanonicalLinkIfRequired();

            Assert.That(output.ToString(), Is.EqualTo(string.Format("<link rel=\"canonical\" href=\"{0}\" />", canonicalUrl)));
        }

        [Test]
        public void Should_return_an_empty_string_if_inferred_canonical_url_is_the_same_as_the_current_page_url()
        {
            var currentPageUrl = "http://WWW.seopack.com/marketplace";

            HttpContext.Current = new HttpContext(
                new HttpRequest("", currentPageUrl, ""),
                new HttpResponse(new StringWriter()));

            var seoHelper = new SeoPack.Helpers.HtmlSeoHelper();
            var output = seoHelper.CanonicalLinkIfRequired();

            Assert.That(output.ToString(), Is.EqualTo(string.Empty));
        }
    }
}
