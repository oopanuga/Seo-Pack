using SeoPack.Html.OpenGraph;
using SeoPack.Html.OpenGraph.ObjectTypes.Standard;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SeoPack.Tests.Html.OpenGraph
{
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

    public class SeoPackWebsite : Website
    {
        public SeoPackWebsite(string title, string url, OgImage image)
            : base(title, url, image)
        {
        }

        public string ContactPageUrl { get; set; }

        [OgStructuredProperty]
        public Address Address { get; set; }

        [OgProperty("aboutus")]
        public AboutUs AboutUs { get; set; }

        [OgProperty("contact_number")]
        public List<PhoneNumber> ContactNumbers { get; set; }

        [OgProperty("start_date")]
        public DateTime? StartDate { get; set; }

        [OgProperty("website_type")]
        public WebsiteType WebsiteType { get; set; }
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
