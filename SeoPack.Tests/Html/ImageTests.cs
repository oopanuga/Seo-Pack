﻿using NUnit.Framework;
using SeoPack.Html;
using System;

namespace SeoPack.Tests.Html
{
    [Category("Image.Constructor")]
    [TestFixture]
    public class Image_ConstructorTests
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
        public void Should_correctly_set_properties_when_done_explicitly_or_via_constructor_arguments()
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
