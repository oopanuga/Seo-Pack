using NUnit.Framework;
using SeoPack.Html;
using System;

namespace SeoPack.Tests.Html
{
    [Category("HrefLangLink.Constructor")]
    [TestFixture]
    public class HrefLangLink_ConstructorTests
    {
        string canonicalUrl = "http://www.seopack.com";
        string language = "en-gb";

        [TestCase("")]
        [TestCase(null)]
        [ExpectedException(typeof(ArgumentException))]
        public void Should_throw_exception_when_canonicalurl_not_supplied_constructor_1(string canonicalUrl)
        {
            new HrefLangLink(canonicalUrl, language);
        }

        [TestCase("")]
        [TestCase(null)]
        [ExpectedException(typeof(ArgumentException))]
        public void Should_throw_exception_when_language_not_supplied(string language)
        {
            new HrefLangLink(canonicalUrl, language);
        }

        [Test]
        public void Should_return_false_when_language_is_supplied()
        {
            var hrefLangLink = new HrefLangLink(canonicalUrl, language);

            Assert.That(hrefLangLink.CanonicalUrl, Is.EqualTo(canonicalUrl));
            Assert.That(hrefLangLink.Language, Is.EqualTo(language));
            Assert.That(hrefLangLink.IsDefault, Is.EqualTo(false));
        }

        [TestCase("")]
        [TestCase(null)]
        [ExpectedException(typeof(ArgumentException))]
        public void Should_throw_exception_when_canonicalurl_not_supplied_constructor_2(string canonicalUrl)
        {
            new HrefLangLink(canonicalUrl);
        }

        [Test]
        public void Should_have_isdefault_value_of_false_and_language_value_of_xdefault_when_language_not_supplied()
        {
            var hrefLangLink = new HrefLangLink(canonicalUrl);

            Assert.That(hrefLangLink.CanonicalUrl, Is.EqualTo(canonicalUrl));
            Assert.That(hrefLangLink.Language, Is.EqualTo("x-default"));
            Assert.That(hrefLangLink.IsDefault, Is.EqualTo(true));
        }
    }
}
