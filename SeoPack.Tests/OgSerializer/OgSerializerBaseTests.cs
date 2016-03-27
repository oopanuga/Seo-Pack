using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeoPack.Tests.OgSerializer
{
    [TestFixture]
    public class OgSerializerBaseTests
    {
        [Category("OgSerializerBase.Serialize()")]
        public class Serialize
        {
            [Test]
            [ExpectedException(typeof(ArgumentNullException))]
            public void Should_throw_exception_if_open_graph_object_is_null()
            {
                var serializer = new OgTestSerializer();
                serializer.Serialize(null);
            }

            [Test]
            public void Should_read_data_from_only_properties_marked_with_the_ogproperty_attribute()
            {
                var website = SetupWebsiteOpenGraphObject();

                var serializer = new OgTestSerializer();
                var output = serializer.Serialize(website);

                Assert.That(output, Is.StringContaining(website.Title));
                Assert.That(output, Is.StringContaining(website.Url.ToString()));
                Assert.That(output, Is.StringContaining(website.Image.Url.ToString()));
                Assert.That(output, Is.Not.StringContaining(website.ContactPageUrl.ToString()));
            }

            [Test]
            public void Should_recursively_read_data_from_members_of_complex_properties_marked_with_the_ogproperty_attribute()
            {
                var website = SetupWebsiteOpenGraphObject();
                website.Address = new Address()
                {
                    Country = "UK",
                    Line1 = "House on a hill",
                    PostCode = "AAA11ZZZ"
                };

                var serializer = new OgTestSerializer();
                var output = serializer.Serialize(website);

                Assert.That(output, Is.StringContaining(website.Address.Line1.ToString()));
            }

            [Test]
            public void Should_call_tostring_on_a_complex_property_if_it_does_not_have_a_member_thats_been_marked_with_the_same_ogproperty_attribute()
            {
                var website = SetupWebsiteOpenGraphObject();
                website.Address = new Address()
                {
                    Country = "UK",
                    Line1 = "House on a hill",
                    PostCode = "AAA11ZZZ"
                };

                var serializer = new OgTestSerializer();
                var output = serializer.Serialize(website);

                Assert.That(output, Is.StringContaining(website.Address.ToString()));
            }

            [Test]
            public void Should_not_call_tostring_on_a_complex_property_if_it_has_a_member_thats_been_marked_with_the_same_ogproperty_attribute()
            {
                var website = SetupWebsiteOpenGraphObject();
                website.AboutUs = new AboutUs()
                {
                    Url = new Uri("http://www.seopackweb.com/aboutus"),
                    Founder = "Me",
                    Director = "Me"
                };

                var serializer = new OgTestSerializer();
                var output = serializer.Serialize(website);

                Assert.That(output, Is.StringContaining(website.AboutUs.Url.ToString()));
                Assert.That(output, Is.Not.StringContaining(website.AboutUs.ToString()));
            }

            private static SeoPackWebsite SetupWebsiteOpenGraphObject()
            {
                var websiteTitle = "The SeoPack website";
                var websiteUrl = new Uri("http://www.seopackweb.com");
                var websiteImageUrl = new Uri("http://www.seopackweb.com/seopack.png");
                var websiteContactPageUrl = new Uri("http://www.seopackweb.com/contactus");

                var website = new SeoPackWebsite(
                    websiteTitle,
                    websiteUrl,
                    new Html.OpenGraph.StructuredProperties.OgImage(websiteImageUrl))
                {
                    ContactPageUrl = websiteContactPageUrl
                };
                return website;
            }
        }
    }
}
