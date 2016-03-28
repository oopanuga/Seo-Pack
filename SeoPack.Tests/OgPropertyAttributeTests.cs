using NUnit.Framework;
using SeoPack.Html.OpenGraph;
using System;

namespace SeoPack.Tests
{
    [TestFixture]
    public class OgPropertyAttributeTests
    {
        [Category("OgPropertyAttribute(name)")]
        public class Constructor
        {
            [Test]
            public void Should_not_duplicate_og_colon_prefix_when_supplied_by_caller()
            {
                var propertyName = "og:title";
                var ogpa = new OgPropertyAttribute("og:title");

                Assert.That(ogpa.Name, Is.EqualTo(propertyName));
            }

            [Test]
            public void Should_prepend_og_colon_prefix_when_not_supplied_by_caller()
            {
                var propertyName = "og:title";
                var ogpa = new OgPropertyAttribute("title");

                Assert.That(ogpa.Name, Is.EqualTo(propertyName));
            }

            [Test]
            [ExpectedException(typeof(ArgumentException))]
            public void Should_throw_exception_when_property_name_not_supplied_by_caller()
            {
                var ogpa = new OgPropertyAttribute(string.Empty);
            }
        }
    }
}
