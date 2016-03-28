﻿using NUnit.Framework;
using System;
using System.Collections.Generic;

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

                Assert.That(output, Is.StringContaining(FormatOgAttributes("title", website.Title)));
                Assert.That(output, Is.StringContaining(FormatOgAttributes("url", website.Url)));
                Assert.That(output, Is.StringContaining(FormatOgAttributes("image", website.Image.Url)));
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

                Assert.That(output, Is.StringContaining(FormatOgAttributes("line1", website.Address.Line1)));
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

                Assert.That(output, Is.StringContaining(FormatOgAttributes("address", website.Address.ToString())));
            }

            [Test]
            public void Should_not_call_tostring_on_a_complex_property_if_it_has_a_member_thats_been_marked_with_the_same_ogproperty_attribute()
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

                Assert.That(output, Is.StringContaining(FormatOgAttributes("aboutus", website.AboutUs.Url)));
                Assert.That(output, Is.Not.StringContaining(website.AboutUs.ToString()));
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

            private static SeoPackWebsite SetupWebsiteOpenGraphObject()
            {
                var websiteTitle = "The SeoPack website";
                var websiteUrl = "http://www.seopackweb.com";
                var websiteImageUrl = "http://www.seopackweb.com/seopack.png";
                var websiteContactPageUrl = "http://www.seopackweb.com/contactus";

                var website = new SeoPackWebsite(
                    websiteTitle,
                    websiteUrl,
                    new Html.OpenGraph.OgImage(websiteImageUrl))
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
}
