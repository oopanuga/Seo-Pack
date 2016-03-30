using NUnit.Framework;
using SeoPack.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeoPack.Tests.Html
{
    [TestFixture]
    public class HrefLangLinkTests
    {
        [Category("HrefLangLink.Constructor(canonicalUrl and language)")]
        public class ConstructorWithOnlyCanonicalUrlAndLanguage
        {
            string canonicalUrl = "http://www.seopack.com";
            string language = "en-gb";

            [TestCase("")]
            [TestCase(null)]
            [ExpectedException(typeof(ArgumentException))]
            public void Should_throw_exception_when_canonicalurl_not_supplied(string canonicalUrl)
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
            public void Should_return_false_for_isdefault_language_is_supplied()
            {
                var hrefLangLink = new HrefLangLink(canonicalUrl, language);

                Assert.That(hrefLangLink.CanonicalUrl, Is.EqualTo(canonicalUrl));
                Assert.That(hrefLangLink.Language, Is.EqualTo(language));
                Assert.That(hrefLangLink.IsDefault, Is.EqualTo(false));
            }
        }

        [Category("HrefLangLink.Constructor(canonicalUrl)")]
        public class ConstructorWithOnlyCanonicalUrl
        {
            string canonicalUrl = "http://www.seopack.com";
            string language = "x-default";

            [TestCase("")]
            [TestCase(null)]
            [ExpectedException(typeof(ArgumentException))]
            public void Should_throw_exception_when_canonicalurl_not_supplied(string canonicalUrl)
            {
                new HrefLangLink(canonicalUrl);
            }

            [Test]
            public void Should_return_false_for_isdefault_and_xdefault_for_language_when_not_supplied()
            {
                var hrefLangLink = new HrefLangLink(canonicalUrl);

                Assert.That(hrefLangLink.CanonicalUrl, Is.EqualTo(canonicalUrl));
                Assert.That(hrefLangLink.Language, Is.EqualTo(language));
                Assert.That(hrefLangLink.IsDefault, Is.EqualTo(true));
            }
        }
    }
}
