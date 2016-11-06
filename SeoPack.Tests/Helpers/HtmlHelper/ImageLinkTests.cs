using System;
using System.Web.Mvc;
using NUnit.Framework;
using SeoPack.Helpers;
using SeoPack.Html;

namespace SeoPack.Tests.Helpers.HtmlHelper
{
    [Category("HtmlSeoHelper.ImageLink")]
    [TestFixture]
    public class ImageLinkTests
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
        public void Should_throw_exception_if_imagelink_object_is_null()
        {
            _htmlHelper.SpImageLink(null);
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

            var output = _htmlHelper.SpImageLink(imageLink);

            Assert.That(output.ToString(), Is.EqualTo(
                string.Format("<a href=\"{0}\" title=\"{1}\" rel=\"{2}\" class=\"{3}\"><img src=\"{4}\" alt=\"{5}\" /></a>", href, title, "nofollow", "bold", src, altText)));
        }
    }
}
