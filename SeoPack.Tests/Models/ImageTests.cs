using NUnit.Framework;
using SeoPack.Html;
using System;

namespace SeoPack.Tests.Models
{
    [TestFixture]
    public class ImageTests
    {
        [Category("ImageTests.Constructor")]
        public class Constructor
        {
            string altText = "This is an image of a dog";
            string src = "http://www.seopack.com/dog.png";

            [TestCase("")]
            [TestCase(null)]
            [ExpectedException(typeof(ArgumentException))]
            public void Should_throw_exception_when_src_not_supplied(string src)
            {
                new Image(src, altText);
            }

            [TestCase("")]
            [TestCase(null)]
            [ExpectedException(typeof(ArgumentException))]
            public void Should_throw_exception_when_alttext_not_supplied(string altText)
            {
                new Image(src, altText);
            }

            [Test]
            public void Should_set_appropriate_properties_when_instantiated()
            {
                var attributes = new { @class = "dog" };
                var title = "This is an image of a dog";

                var image = new Image(src, altText, attributes);
                image.Title = title;

                Assert.That(image.Src, Is.EqualTo(src));
                Assert.That(image.AltText, Is.EqualTo(altText));
                Assert.That(image.Attributes, Is.EqualTo(attributes));
                Assert.That(image.Title, Is.EqualTo(title));
            }
        }
    }
}
