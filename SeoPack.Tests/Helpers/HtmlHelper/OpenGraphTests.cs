using System;
using System.Collections.Generic;
using System.Web.Mvc;
using NUnit.Framework;
using SeoPack.Helpers;
using SeoPack.Html.OpenGraph;
using SeoPack.Tests.Html.OpenGraph;

namespace SeoPack.Tests.Helpers.HtmlHelper
{
    [Category("HtmlSeoHelper.OpenGraph")]
    [TestFixture]
    public class OpenGraphTests
    {
        private System.Web.Mvc.HtmlHelper _htmlHelper;

        [SetUp]
        public void SetUp()
        {
            _htmlHelper =
                Helpers.CreateHtmlHelper<string>(
                        new ViewDataDictionary("Hello World"));
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Should_throw_exception_if_opengraph_object_is_null()
        {
            _htmlHelper.SpImage(null);
        }

        [Test]
        public void Should_return_seo_compliant_opengraph_tag_when_image_object_is_not_null()
        {
            string ogImageUrl = "http://www.seopack.com/dog.png";
            string ogObjectUrl = "http://www.seopack.com";
            string title = "This is an Og object";

            var ogImage = new OgImage(ogImageUrl);
            var website = new FakeOgWebsite(title, ogObjectUrl, new OgImage[] { ogImage });
            var audioUrl = "http://www.seopack.com/audio";
            var videoUrl = "http://www.seopack.com/video";
            var description = "some description";
            var determiner = Determiner.An;
            var siteName = "SeoPack Website";
            var locale = "en-gb";
            var alternateLocales = new List<string> { "en-us", "en-ca" };

            website.Audio = new OgAudio[] { new OgAudio(audioUrl) };
            website.Description = description;
            website.Determiner = determiner;
            website.Locale = locale;
            website.AlternateLocales = alternateLocales;
            website.SiteName = siteName;
            website.Videos = new OgVideo[] { new OgVideo(videoUrl) };

            var output = _htmlHelper.SpOpenGraph(website);

            string expectedOutput = "<meta property=\"og:title\" content=\"This is an Og object\">"
                + "<meta property=\"og:type\" content=\"website\">"
                + "<meta property=\"og:url\" content=\"http://www.seopack.com\">"
                + "<meta property=\"og:image\" content=\"http://www.seopack.com/dog.png\">"
                + "<meta property=\"og:audio\" content=\"http://www.seopack.com/audio\">"
                + "<meta property=\"og:description\" content=\"some description\">"
                + "<meta property=\"og:determiner\" content=\"an\">"
                + "<meta property=\"og:locale\" content=\"en-gb\">"
                + "<meta property=\"og:locale:alternate\" content=\"en-us\">"
                + "<meta property=\"og:locale:alternate\" content=\"en-ca\">"
                + "<meta property=\"og:site_name\" content=\"SeoPack Website\">"
                + "<meta property=\"og:video\" content=\"http://www.seopack.com/video\">";

            Assert.That(output.ToString(), Is.EqualTo(expectedOutput));
        }
    }
}
