using SeoPack.Html.OpenGraph;
using SeoPack.Html.OpenGraph.ObjectTypes.Standard;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SeoPack.Tests.Html.OpenGraph
{
    public class SeoPackWebsite : Website
    {
        public SeoPackWebsite(string title, string url, OgImage[] images)
            : base(title, url, images)
        {
        }

        [OgProperty("aboutus", 20)]
        public AboutUs AboutUs { get; set; }

        [OgStructuredProperty(21)]
        public Product[] Products { get; set; }

        [OgStructuredProperty(22)]
        public Address Address { get; set; }

        [OgProperty("contact_number", 23)]
        public List<PhoneNumber> ContactNumbers { get; set; }

        [OgProperty("start_date", 24)]
        public DateTime? StartDate { get; set; }

        [OgProperty("website_type", 25)]
        public WebsiteType WebsiteType { get; set; }

        public string ContactPageUrl { get; set; }
    }

    public enum AddressType
    {
        [Description("home address")]
        Home,
        [Description("office address")]
        Office,
        [Description("other address")]
        Other
    }

    public enum WebsiteType
    {
        Game,
        News,
        Developer
    }

    public class Product
    {
        [OgProperty("product")]
        public string Name { get; set; }
        [OgProperty("product:description")]
        public string Description { get; set; }
    }

    public class Address
    {
        [OgProperty("line1")]
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string PostCode { get; set; }
        public string Country { get; set; }

        [OgProperty("address_type")]
        public AddressType AddressType { get; set; }

        public override string ToString()
        {
            return "SeoPack website with an address";
        }
    }

    public class AboutUs
    {
        [OgProperty("aboutus")]
        public string Url { get; set; }

        [OgProperty("founder")]
        public string Founder { get; set; }

        [OgProperty("director")]
        public string Director { get; set; }

        public override string ToString()
        {
            return "SeoPack rocks!!!";
        }
    }

    public class PhoneNumber
    {
        public string CountryCode { get; set; }
        public string Number { get; set; }

        public override string ToString()
        {
            return Number;
        }
    }
}
