using NUnit.Framework;
using SeoPack.Html.OpenGraph;
using System;
using System.Collections.Generic;

namespace SeoPack.Tests.Html.OpenGraph
{
    [Category("Og.Constructor")]
    [TestFixture]
    public class Og_ConstructorTests
    {
        string ogImageUrl = "http://www.seopack.com/dog.png";
        string ogObjectUrl = "http://www.seopack.com";
        string title = "This is an Og object";

        [TestCase(null)]
        [TestCase("")]
        [ExpectedException(typeof(ArgumentException))]
        public void Should_throw_exception_if_title_not_set(string title)
        {
            new FakeOgWebsite(title, ogObjectUrl, new OgImage[] { new OgImage(ogImageUrl) });
        }

        [TestCase(null)]
        [TestCase("")]
        [ExpectedException(typeof(ArgumentException))]
        public void Should_throw_exception_if_url_not_set(string url)
        {
            new FakeOgWebsite(title, url, new OgImage[] { new OgImage(ogImageUrl) });
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Should_throw_exception_if_image_is_null()
        {
            OgImage[] ogImages = null;
            new FakeOgWebsite(title, ogObjectUrl, ogImages);
        }

        [Test]
        public void Should_correctly_set_properties_when_done_explicitly_or_via_constructor_arguments()
        {
            var ogImage = new OgImage(ogImageUrl);
            var website = new FakeOgWebsite(title, ogObjectUrl, new OgImage[] { ogImage });
            var ogAudio = new OgAudio("http://www.seopack.com/audio");
            var ogVideo = new OgVideo("http://www.seopack.com/video");
            var description = "some description";
            var determiner = Determiner.An;
            var siteName = "SeoPack Website";
            var locale = "en-gb";
            var alternateLocales = new List<string> { "en-us", "en-ca" };

            website.Audio = new OgAudio[] { ogAudio };
            website.Description = description;
            website.Determiner = determiner;
            website.Locale = locale;
            website.AlternateLocales = alternateLocales;
            website.SiteName = siteName;
            website.Videos = new OgVideo[] { ogVideo };

            Assert.That(website.Title, Is.EqualTo(title));
            Assert.That(website.Url, Is.EqualTo(ogObjectUrl));
            Assert.That(website.Images[0], Is.EqualTo(ogImage));
            Assert.That(website.Audio[0], Is.EqualTo(ogAudio));
            Assert.That(website.Description, Is.EqualTo(description));
            Assert.That(website.Determiner, Is.EqualTo(determiner));
            Assert.That(website.Type, Is.EqualTo(ObjectType.Website));
            Assert.That(website.Locale, Is.EqualTo(locale));
            Assert.That(website.AlternateLocales, Is.EqualTo(alternateLocales));
            Assert.That(website.SiteName, Is.EqualTo(siteName));
            Assert.That(website.Videos[0], Is.EqualTo(ogVideo));
        }
    }
}
