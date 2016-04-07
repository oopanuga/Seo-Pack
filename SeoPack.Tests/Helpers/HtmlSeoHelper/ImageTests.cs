using NUnit.Framework;
using SeoPack.Helpers;
using SeoPack.Html;
using System;

namespace SeoPack.Tests.Helpers.HtmlSeoHelperTests
{
    [Category("HtmlSeoHelper.Image")]
    [TestFixture]
    public class HtmlSeoHelper_ImageTests
    {
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Should_throw_exception_if_image_object_is_null()
        {
            var seoHelper = new HtmlSeoHelper();
            seoHelper.Image(null);
        }

        [Test]
        public void Should_return_seo_compliant_image_tag_if_image_object_is_not_null()
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
}
