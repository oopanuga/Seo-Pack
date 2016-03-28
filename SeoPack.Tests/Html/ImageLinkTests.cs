using NUnit.Framework;
using SeoPack.Html;
using System;

namespace SeoPack.Tests.Html
{
    [TestFixture]
    public class ImageLinkTests
    {
        [Category("ImageLink.Constructor")]
        public class Constructor
        {
            string href = "http://www.seopack.com";

            [Test]
            [ExpectedException(typeof(ArgumentNullException))]
            public void Should_throw_exception_when_image_not_supplied()
            {
                var attributes = new { @class = "bold" };
                var nofollow = true;
                Image image = null;
                new ImageLink(image, href, nofollow, attributes);
            }

            [Test]
            public void Should_correctly_set_properties_when_set_explicitly_and_via_constructor_arguments()
            {
                var altText = "This is an image of a dog";
                var src = "http://www.seopack.com/dog.png";
                var attributes = new { @class = "bold" };
                var nofollow = true;

                var image = new Image(src, altText);
                var imageLink = new ImageLink(image, href, nofollow, attributes);

                Assert.That(imageLink.Image, Is.EqualTo(image));
            }
        }
    }
}
