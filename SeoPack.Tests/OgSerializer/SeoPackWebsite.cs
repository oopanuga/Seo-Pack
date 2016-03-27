using SeoPack.Html.OpenGraph;
using SeoPack.Html.OpenGraph.ObjectTypes.Standard;
using SeoPack.Html.OpenGraph.StructuredProperties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeoPack.Tests.OgSerializer
{
    public class SeoPackWebsite : Website
    {
        public SeoPackWebsite(string title, Uri url, OgImage image)
            : base(title, url, image)
        {
        }

        public Uri ContactPageUrl { get; set; }

        [OgProperty("address")]
        public Address Address { get; set; }

        [OgProperty("aboutus")]
        public AboutUs AboutUs { get; set; }
    }

    public class Address
    {
        [OgProperty("line1")]
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string PostCode { get; set; }
        public string Country { get; set; }

        public override string ToString()
        {
            return "SeoPack website with an address";
        }
    }

    public class AboutUs
    {
        [OgProperty("aboutus")]
        public Uri Url { get; set; }

        [OgProperty("founder")]
        public string Founder { get; set; }

        [OgProperty("director")]
        public string Director { get; set; }

        public override string ToString()
        {
            return "SeoPack rocks!!!";
        }
    }
}
