using System;
using NUnit.Framework;
using SeoPack.Html;

namespace SeoPack.Tests.Helpers.HtmlSeoHelper
{
    [Category("HtmlSeoHelper.ImageLink")]
    [TestFixture]
    public class HtmlSeoHelper_ImageLinkTests
    {
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Should_throw_exception_if_imagelink_object_is_null()
        {
            var seoHelper = new SeoPack.Helpers.HtmlSeoHelper();
            seoHelper.ImageLink(null);
        }

        [Test]
        public void Should_return_seo_compliant_imagelink_when_imagelink_object_not_null()
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

            var seoHelper = new SeoPack.Helpers.HtmlSeoHelper();
            var output = seoHelper.ImageLink(imageLink);

            Assert.That(output.ToString(), Is.EqualTo(
                string.Format("<a href=\"{0}\" title=\"{1}\" rel=\"{2}\" class=\"{3}\"><img src=\"{4}\" alt=\"{5}\" /></a>", href, title, "nofollow", "bold", src, altText)));
        }
    }
}
