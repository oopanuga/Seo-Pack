using NUnit.Framework;
using SeoPack.Html;
using System;

namespace SeoPack.Tests.Html
{
    [TestFixture]
    public class AnchorTests
    {
        [Category("Anchor.Constructor")]
        public class Constructor
        {
            string text = "SeoPack";
            string href = "http://www.seopack.com";

            [TestCase("")]
            [TestCase(null)]
            [ExpectedException(typeof(ArgumentException))]
            public void Should_throw_exception_when_src_not_supplied(string href)
            {
                new Anchor(href, text);
            }

            [TestCase("")]
            [TestCase(null)]
            [ExpectedException(typeof(ArgumentException))]
            public void Should_throw_exception_when_text_not_supplied(string text)
            {
                new Anchor(href, text);
            }

            [Test]
            public void Should_correctly_set_properties_when_done_explicitly_or_via_constructor_arguments()
            {
                var attributes = new { @class = "bold" };
                var title = "This is the official SeoPack website";
                var noFollow = true;

                var anchor = new Anchor(href, text, noFollow, attributes);
                anchor.Title = title;

                Assert.That(anchor.Href, Is.EqualTo(href));
                Assert.That(anchor.Text, Is.EqualTo(text));
                Assert.That(anchor.NoFollow, Is.EqualTo(noFollow));
                Assert.That(anchor.Attributes, Is.EqualTo(attributes));
                Assert.That(anchor.Title, Is.EqualTo(title));
            }
        }
    }
}
