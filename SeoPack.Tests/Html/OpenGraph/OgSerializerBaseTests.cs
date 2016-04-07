using NUnit.Framework;
using SeoPack.Html.OpenGraph;
using System;
using System.Collections.Generic;

namespace SeoPack.Tests.Html.OpenGraph
{
    [Category("OgSerializerBase.Serialize")]
    [TestFixture]
    public class OgSerializerBase_SerializeTests
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

            Assert.That(output, Is.StringContaining(FormatOgAttributes("title", website.Title)));
            Assert.That(output, Is.StringContaining(FormatOgAttributes("url", website.Url)));
            Assert.That(output, Is.StringContaining(FormatOgAttributes("image", website.Images[0].Url)));
            Assert.That(output, Is.Not.StringContaining(website.ContactPageUrl.ToString()));
        }

        [Test]
        public void Should_recursively_read_data_from_members_of_complex_properties_marked_with_the_ogstructuredproperty_attribute()
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

            Assert.That(output, Is.StringContaining(FormatOgAttributes("line1", website.Address.Line1)));
        }

        [Test]
        public void Should_call_tostring_on_a_complex_property_thats_been_marked_with_the_ogproperty_attribute()
        {
            var website = SetupWebsiteOpenGraphObject();
            website.AboutUs = new AboutUs()
            {
                Url = "http://www.seopackweb.com/aboutus",
                Founder = "Me",
                Director = "Me"
            };

            var serializer = new OgTestSerializer();
            var output = serializer.Serialize(website);

            Assert.That(output, Is.StringContaining(FormatOgAttributes("aboutus", website.AboutUs.ToString())));
        }

        [Test]
        public void Should_not_call_tostring_on_a_complex_property_marked_with_the_ogstructuredproperty_attribute()
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

            Assert.That(output, Is.Not.StringContaining(website.Address.ToString()));
        }

        [Test]
        public void Should_read_array_of_data_if_ogproperty_type_is_array_and_has_more_than_one_item()
        {
            var website = SetupWebsiteOpenGraphObject();
            website.ContactNumbers = new List<PhoneNumber>();
            website.ContactNumbers.Add(new PhoneNumber()
            {
                Number = "1111111111"
            });
            website.ContactNumbers.Add(new PhoneNumber()
            {
                Number = "2222222222"
            });

            var serializer = new OgTestSerializer();
            var output = serializer.Serialize(website);

            Assert.That(output, Is.StringContaining(FormatOgAttributes("contact_number", website.ContactNumbers[0].Number)));
            Assert.That(output, Is.StringContaining(FormatOgAttributes("contact_number", website.ContactNumbers[1].Number)));
        }

        [Test]
        public void Should_read_array_of_data_if_ogstructuredproperty_type_is_array_and_has_more_than_one_item()
        {
            var website = SetupWebsiteOpenGraphObject();
            var products = new List<Product>();

            products.Add(new Product()
            {
                Name = "Prod 1",
                Description = "Description for Prod 1"
            });
            products.Add(new Product()
            {
                Name = "Prod 2",
                Description = "Description for Prod 2"
            });

            website.Products = products.ToArray();

            var serializer = new OgTestSerializer();
            var output = serializer.Serialize(website);

            Assert.That(output, Is.StringContaining(FormatOgAttributes("product", website.Products[0].Name)));
            Assert.That(output, Is.StringContaining(FormatOgAttributes("product:description", website.Products[0].Description)));
            Assert.That(output, Is.StringContaining(FormatOgAttributes("product", website.Products[1].Name)));
            Assert.That(output, Is.StringContaining(FormatOgAttributes("product:description", website.Products[1].Description)));
        }

        [Test]
        public void Should_properly_format_date_without_time_component_if_ogproperty_type_is_datetime()
        {
            var website = SetupWebsiteOpenGraphObject();
            website.StartDate = new DateTime(1900, 11, 1);

            var serializer = new OgTestSerializer();
            var output = serializer.Serialize(website);

            Assert.That(output, Is.StringContaining(FormatOgAttributes("start_date", "1900-11-01")));
        }

        [Test]
        public void Should_properly_format_date_with_time_component_if_ogproperty_type_is_datetime()
        {
            var website = SetupWebsiteOpenGraphObject();
            website.StartDate = new DateTime(1900, 11, 1, 11, 20, 45);

            var serializer = new OgTestSerializer();
            var output = serializer.Serialize(website);

            Assert.That(output, Is.StringContaining(FormatOgAttributes("start_date", "1900-11-01T11:20:45Z")));
        }

        [Test]
        public void Should_exclude_properties_that_dont_have_a_value()
        {
            var website = SetupWebsiteOpenGraphObject();
            website.Determiner = null;
            var determinerPropertyName = "derterminer";

            var serializer = new OgTestSerializer();
            var output = serializer.Serialize(website);

            Assert.That(output, Is.Not.StringContaining(determinerPropertyName));
        }

        [Test]
        public void Should_use_description_text_of_enum_if_present()
        {
            var website = SetupWebsiteOpenGraphObject();
            website.Address = new Address()
            {
                Country = "UK",
                Line1 = "House on a hill",
                PostCode = "AAA11ZZZ",
                AddressType = AddressType.Office
            };

            var serializer = new OgTestSerializer();
            var output = serializer.Serialize(website);

            Assert.That(output, Is.StringContaining(FormatOgAttributes("address_type", "office address")));
        }

        [Test]
        public void Should_use_string_value_of_enum_if_description_text_is_not_present()
        {
            var website = SetupWebsiteOpenGraphObject();
            website.WebsiteType = WebsiteType.Developer;

            var serializer = new OgTestSerializer();
            var output = serializer.Serialize(website);

            Assert.That(output, Is.StringContaining(FormatOgAttributes("website_type", "developer")));
        }

        private static SeoPackWebsite SetupWebsiteOpenGraphObject()
        {
            var websiteTitle = "The SeoPack website";
            var websiteUrl = "http://www.seopackweb.com";
            var websiteImageUrl = "http://www.seopackweb.com/seopack.png";
            var websiteContactPageUrl = "http://www.seopackweb.com/contactus";

            var website = new SeoPackWebsite(
                websiteTitle,
                websiteUrl,
                new OgImage[] { new OgImage(websiteImageUrl) })
            {
                ContactPageUrl = websiteContactPageUrl
            };
            return website;
        }

        private string FormatOgAttributes(string propertyName, string content)
        {
            return string.Format("property=\"og:{0}\" content=\"{1}\"", propertyName, content);
        }
    }
}
