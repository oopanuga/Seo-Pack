using NUnit.Framework;
using SeoPack.Html.OpenGraph;
using System;

namespace SeoPack.Tests.Html.OpenGraph
{
    [TestFixture]
    public class OgTests
    {
        [Category("Og.Constructor")]
        public class Constructor
        {
            string ogImageUrl = "http://www.seopack.com/dog.png";
            string ogObjectUrl = "http://www.seopack.com";
            string title = "This is an Og object";

            [TestCase(null)]
            [TestCase("")]
            [ExpectedException(typeof(ArgumentException))]
            public void Should_throw_exception_if_title_not_set(string title)
            {
                new FakeOgWebsite(title, ogObjectUrl, new OgImage(ogImageUrl));
            }

            [TestCase(null)]
            [TestCase("")]
            [ExpectedException(typeof(ArgumentException))]
            public void Should_throw_exception_if_url_not_set(string url)
            {
                new FakeOgWebsite(title, url, new OgImage(ogImageUrl));
            }

            [Test]
            [ExpectedException(typeof(ArgumentNullException))]
            public void Should_throw_exception_if_image_is_null()
            {
                OgImage ogImage = null;
                new FakeOgWebsite(title, ogObjectUrl, ogImage);
            }

            [Test]
            public void Should_correctly_set_properties_when_set_explicitly_and_via_constructor_arguments()
            {
                var ogImage = new OgImage(ogImageUrl);
                var website = new FakeOgWebsite(title, ogObjectUrl, ogImage);
                var audioUrl = "http://www.seopack.com/audio";
                var description = "some description";
                var determiner = Determiner.An;

                website.Audio = audioUrl;
                website.Description = description;
                website.Determiner = determiner;

                Assert.That(website.Title, Is.EqualTo(title));
                Assert.That(website.Url, Is.EqualTo(ogObjectUrl));
                Assert.That(website.Image, Is.EqualTo(ogImage));
                Assert.That(website.Audio, Is.EqualTo(audioUrl));
                Assert.That(website.Description, Is.EqualTo(description));
                Assert.That(website.Determiner, Is.EqualTo(determiner));
                Assert.That(website.Type, Is.EqualTo(ObjectType.Website));
            }
        }
    }
}
