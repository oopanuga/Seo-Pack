using NUnit.Framework;
using SeoPack.Helpers;
using SeoPack.Html;
using SeoPack.Html.OpenGraph;
using SeoPack.Tests.Html.OpenGraph;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;

namespace SeoPack.Tests.Helpers
{
    [TestFixture]
    public class HtmlSeoHelperTests
    {
        [Category("HtmlSeoHelper.Image(image)")]
        public class ImageTests
        {
            [Test]
            [ExpectedException(typeof(ArgumentNullException))]
            public void Should_throw_exception_if_image_object_is_null()
            {
                var seoHelper = new HtmlSeoHelper();
                seoHelper.Image(null);
            }

            [Test]
            public void Should_return_correct_output_when_image_object_is_not_null()
            {
                var altText = "This is an image of a dog";
                var src = "http://www.seopack.com/dog.png";
                var attributes = new { @class = "dog" };
                var title = "This is an image of a dog";

                var image = new Image(src, altText, attributes);
                image.Title = title;

                var seoHelper = new HtmlSeoHelper();
                var output = seoHelper.Image(image);

                Assert.That(output.ToString(), Is.EqualTo(
                    string.Format("<img src=\"{0}\" alt=\"{1}\" title=\"{2}\" class=\"{3}\" />", src, altText, title, "dog")));
            }
        }

        [Category("HtmlSeoHelper.Anchor(anchor)")]
        public class AnchorTests
        {
            string text = "SeoPack";
            string href = "http://www.seopack.com";
            object attributes = new { @class = "bold" };
            string title = "This is the official SeoPack website";

            [Test]
            [ExpectedException(typeof(ArgumentNullException))]
            public void Should_throw_exception_if_anchor_object_is_null()
            {
                var seoHelper = new HtmlSeoHelper();
                seoHelper.Anchor(null);
            }

            [Test]
            public void Should_include_rel_nofollow_in_output_if_nofollow_is_set_to_true()
            {
                var noFollow = true;
                var anchor = new Anchor(href, text, noFollow, attributes);
                anchor.Title = title;

                var seoHelper = new HtmlSeoHelper();
                var output = seoHelper.Anchor(anchor);

                Assert.That(output.ToString(), Is.EqualTo(
                    string.Format("<a href=\"{0}\" title=\"{1}\" rel=\"{2}\" class=\"{3}\">{4}</a>", href, title, "nofollow", "bold", text)));
            }

            [Test]
            public void Should_exclude_rel_nofollow_in_output_if_nofollow_is_set_to_false()
            {
                var noFollow = false;
                var anchor = new Anchor(href, text, noFollow, attributes);
                anchor.Title = title;

                var seoHelper = new HtmlSeoHelper();
                var output = seoHelper.Anchor(anchor);

                Assert.That(output.ToString(), Is.EqualTo(
                    string.Format("<a href=\"{0}\" title=\"{1}\" class=\"{2}\">{3}</a>", href, title, "bold", text)));
            }
        }

        [Category("HtmlSeoHelper.ImageLink(imageLink)")]
        public class ImageLinkTests
        {
            [Test]
            [ExpectedException(typeof(ArgumentNullException))]
            public void Should_throw_exception_if_imagelink_object_is_null()
            {
                var seoHelper = new HtmlSeoHelper();
                seoHelper.ImageLink(null);
            }

            [Test]
            public void Should_return_correct_output_when_imagelink_object_not_null()
            {
                var altText = "This is an image of a dog";
                var src = "http://www.seopack.com/dog.png";
                var attributes = new { @class = "bold" };
                var nofollow = true;
                var href = "http://www.seopack.com";
                var title = "This is an image link";

                var image = new Image(src, altText);
                var imageLink = new ImageLink(image, href, nofollow, attributes);
                imageLink.Title = title;

                var seoHelper = new HtmlSeoHelper();
                var output = seoHelper.ImageLink(imageLink);

                Assert.That(output.ToString(), Is.EqualTo(
                    string.Format("<a href=\"{0}\" title=\"{1}\" rel=\"{2}\" class=\"{3}\"><img src=\"{4}\" alt=\"{5}\" /></a>", href, title, "nofollow", "bold", src, altText)));
            }
        }

        [Category("HtmlSeoHelper.CanonicalLinkIfRequired(canonicalUrl)")]
        public class CanonicalLinkWithArgTests
        {
            [TestCase(null)]
            [TestCase("")]
            [ExpectedException(typeof(ArgumentException))]
            public void Should_throw_exception_if_canonicalurl_is_not_set(string canonicalUrl)
            {
                var seoHelper = new HtmlSeoHelper();
                seoHelper.CanonicalLinkIfRequired(canonicalUrl);
            }

            [Test]
            public void Should_return_a_canonicallink_if_current_url_starts_with_canonical_url_but_is_not_same_as_canonical_url()
            {
                var canonicalUrl = "http://www.seopack.com/marketplace";
                var currentPageUrl = "http://www.seopack.com/marketplace?query=seo";

                HttpContext.Current = new HttpContext(
                    new HttpRequest("", currentPageUrl, ""),
                    new HttpResponse(new StringWriter()));

                var seoHelper = new HtmlSeoHelper();
                var output = seoHelper.CanonicalLinkIfRequired(canonicalUrl);

                Assert.That(output.ToString(), Is.EqualTo(string.Format("<link rel=\"canonical\" href=\"{0}\" />", canonicalUrl)));
            }

            [Test]
            public void Should_return_an_empty_string_if_current_url_doesnt_start_with_canonical_url()
            {
                var canonicalUrl = "http://www.seopack.com/marketplace";
                var currentPageUrl = "http://www.seopack.com/blog?category=somecategory";

                HttpContext.Current = new HttpContext(
                    new HttpRequest("", currentPageUrl, ""),
                    new HttpResponse(new StringWriter()));

                var seoHelper = new HtmlSeoHelper();
                var output = seoHelper.CanonicalLinkIfRequired(canonicalUrl);

                Assert.That(output.ToString(), Is.EqualTo(string.Empty));
            }
        }

        [Category("HtmlSeoHelper.CanonicalLinkIfRequired()")]
        public class CanonicalLinkTests
        {
            [Test]
            public void Should_return_a_canonicallink_if_the_current_url_has_querystrings()
            {
                var canonicalUrl = "http://www.seopack.com/marketplace";
                var currentPageUrl = "http://www.seopack.com/marketplace?query=seo";

                HttpContext.Current = new HttpContext(
                    new HttpRequest("", currentPageUrl, ""),
                    new HttpResponse(new StringWriter()));

                var seoHelper = new HtmlSeoHelper();
                var output = seoHelper.CanonicalLinkIfRequired();

                Assert.That(output.ToString(), Is.EqualTo(string.Format("<link rel=\"canonical\" href=\"{0}\" />", canonicalUrl)));
            }

            [Test]
            public void Should_return_an_empty_string_if_the_current_url_does_not_have_querystrings()
            {
                var currentPageUrl = "http://www.seopack.com/marketplace";

                HttpContext.Current = new HttpContext(
                    new HttpRequest("", currentPageUrl, ""),
                    new HttpResponse(new StringWriter()));

                var seoHelper = new HtmlSeoHelper();
                var output = seoHelper.CanonicalLinkIfRequired();

                Assert.That(output.ToString(), Is.EqualTo(string.Empty));
            }
        }

        [Category("HtmlSeoHelper.OpenGraph(og)")]
        public class OpenGraphTests
        {
            [Test]
            [ExpectedException(typeof(ArgumentNullException))]
            public void Should_throw_exception_if_opengraph_object_is_null()
            {
                var seoHelper = new HtmlSeoHelper();
                seoHelper.Image(null);
            }

            [Test]
            public void Should_return_correct_output_when_image_object_is_not_null()
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

                website.Audio = audioUrl;
                website.Description = description;
                website.Determiner = determiner;
                website.Locale = locale;
                website.AlternateLocales = alternateLocales;
                website.SiteName = siteName;
                website.Video = videoUrl;

                var seoHelper = new HtmlSeoHelper();
                var output = seoHelper.OpenGraph(website);

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

        [Category("HtmlSeoHelper.Title(title)")]
        public class TitleTests
        {
            [TestCase(null)]
            [TestCase("")]
            [ExpectedException(typeof(ArgumentException))]
            public void Should_throw_exception_if_title_is_null_or_empty(string title)
            {
                var seoHelper = new HtmlSeoHelper();
                seoHelper.Title(title);
            }

            [TestCase("The is the official SeoPack website")]//35
            [TestCase("The is the official SeoPack website. We've got to")]//49
            [TestCase("The is the official SeoPack website. We've got tons of nice t")]//61
            [ExpectedException(typeof(ArgumentException))]
            public void Should_throw_exception_if_validate_length_is_true_and_title_is_not_between_50_and_60_characters_in_length(string title)
            {
                var seoHelper = new HtmlSeoHelper();
                seoHelper.Title(title, true);
            }

            [TestCase("The is the official SeoPack website. We've got ton")]//50
            [TestCase("The is the official SeoPack website. We've got tons")]//51
            [TestCase("The is the official SeoPack website. We've got tons of nice ")]//60
            public void Should_return_the_correct_output_if_validate_length_is_true_and_title_is_between_50_and_60_characters_in_length(string title)
            {
                var seoHelper = new HtmlSeoHelper();
                var output = seoHelper.Title(title, true);

                Assert.That(output.ToString(), Is.EqualTo(string.Format("<title>{0}</title>", title)));
            }

            [TestCase("The is the official SeoPack website")]//35
            [TestCase("The is the official SeoPack website. We've got to")]//49
            [TestCase("The is the official SeoPack website. We've got tons of nice t")]//61
            public void Should_return_the_correct_output_if_validate_length_is_false_and_title_is_not_between_50_and_60_characters_in_length(string title)
            {
                var seoHelper = new HtmlSeoHelper();
                var output = seoHelper.Title(title, false);

                Assert.That(output.ToString(), Is.EqualTo(string.Format("<title>{0}</title>", title)));
            }
        }

        [Category("HtmlSeoHelper.MetaDescription(description)")]
        public class MetaDescriptionTests
        {
            [TestCase(null)]
            [TestCase("")]
            [ExpectedException(typeof(ArgumentException))]
            public void Should_throw_exception_if_meta_description_is_null_or_empty(string description)
            {
                var seoHelper = new HtmlSeoHelper();
                seoHelper.MetaDescription(description);
            }

            [TestCase("The is the official SeoPack website. We've got tonThe is the official SeoPack website. " +
                "We've got tonThe is the official SeoPack website. We've got ton123456")]//156
            [TestCase("The is the official SeoPack website. We've got tonThe is the official SeoPack website. " +
                "We've got tonThe is the official SeoPack website. We've got ton1234567")]//157
            [ExpectedException(typeof(ArgumentException))]
            public void Should_throw_exception_if_validate_length_is_true_and_description_is_greater_than_155_characters_in_length(string description)
            {
                var seoHelper = new HtmlSeoHelper();
                seoHelper.MetaDescription(description, true);
            }

            [TestCase("The is the official SeoPack website. We've got tonThe is the official SeoPack website. " +
                "We've got tonThe is the official SeoPack website. We've got ton12345")]//155
            [TestCase("The is the official SeoPack website. We've got tonThe is the official SeoPack website. " +
                "We've got tonThe is the official SeoPack website. We've got ton1234")]//154
            public void Should_return_the_correct_output_if_validate_length_is_true_and_description_is_less_than_or_equal_to_155_characters_in_length(string description)
            {
                var seoHelper = new HtmlSeoHelper();
                var output = seoHelper.MetaDescription(description, true);

                Assert.That(output.ToString(), Is.EqualTo(string.Format("<meta name=\"description\" content=\"{0}\">", description)));
            }

            [TestCase("The is the official SeoPack website. We've got tonThe is the official SeoPack website. " +
                "We've got tonThe is the official SeoPack website. We've got ton123456")]//156
            [TestCase("The is the official SeoPack website. We've got tonThe is the official SeoPack website. " +
                "We've got tonThe is the official SeoPack website. We've got ton1234567")]//157
            public void Should_return_correct_output_if_validate_length_is_false_and_description_is_greater_than_155_characters_in_length(string description)
            {
                var seoHelper = new HtmlSeoHelper();
                var output = seoHelper.MetaDescription(description, false);

                Assert.That(output.ToString(), Is.EqualTo(string.Format("<meta name=\"description\" content=\"{0}\">", description)));
            }
        }
    }
}
