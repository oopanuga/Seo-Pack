using NUnit.Framework;
using SeoPack.Url;
using SeoPack.Url.UrlPolicy;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SeoPack.Tests.Url
{
    [Category("CanonicalUrlAttribute.OnActionExecuting")]
    [TestFixture]
    public class CanonicalUrlAttributeTests
    {
        [SetUp]
        public void Setup()
        {
            UrlPolicyConfiguration.Configure().NoTrailingSlashPolicy().WwwPolicy();
        }

        [Test]
        public void Should_inject_data_into_placeholders_in_supplied_url_path_and_expose_the_canonical_url_as_a_http_context_item()
        {
            var canonicalUrlAttribute = new CanonicalUrlAttribute("{userid}/{addressid}");
            var actionExecutingContext = new ActionExecutingContext();
            var canonicalUrl = "http://www.contactly.com/2/3";

            AddUserObjectToActionParameters(actionExecutingContext);
            SetHttpContext(actionExecutingContext, "http://www.contactly.com");

            canonicalUrlAttribute.OnActionExecuting(actionExecutingContext);

            Assert.That(actionExecutingContext.RequestContext.HttpContext.Items["CanonicalUrl"], Is.EqualTo(canonicalUrl));
        }

        [Test]
        public void Should_append_supplied_url_path_to_main_url()
        {
            var canonicalUrlAttribute = new CanonicalUrlAttribute("{userid}/{addressid}");
            var actionExecutingContext = new ActionExecutingContext();
            var canonicalUrl = "http://www.contactly.com/2/3";

            AddUserObjectToActionParameters(actionExecutingContext);
            SetHttpContext(actionExecutingContext, "http://www.contactly.com");

            canonicalUrlAttribute.OnActionExecuting(actionExecutingContext);

            Assert.That(actionExecutingContext.RequestContext.HttpContext.Items["CanonicalUrl"], Is.EqualTo(canonicalUrl));
        }

        [Test]
        public void Should_use_main_url_stripped_off_querystrings_for_canonical_url_if_url_path_not_supplied()
        {            
            var canonicalUrlAttribute = new CanonicalUrlAttribute();
            var actionExecutingContext = new ActionExecutingContext();
            var canonicalUrl = "http://www.contactly.com/data";

            AddUserObjectToActionParameters(actionExecutingContext);
            SetHttpContext(actionExecutingContext, "http://www.contactly.com/data?userid=2&addressid=4");

            canonicalUrlAttribute.OnActionExecuting(actionExecutingContext);

            Assert.That(actionExecutingContext.RequestContext.HttpContext.Items["CanonicalUrl"], Is.EqualTo(canonicalUrl));
        }

        [Test]
        public void Should_trim_any_trailing_or_leading_slashes_from_supplied_url_path()
        {
            var canonicalUrlAttribute = new CanonicalUrlAttribute("/{userid}/{addressid}/");
            var actionExecutingContext = new ActionExecutingContext();
            var canonicalUrl = "http://www.contactly.com/2/3";

            AddUserObjectToActionParameters(actionExecutingContext);
            SetHttpContext(actionExecutingContext, "http://www.contactly.com");

            canonicalUrlAttribute.OnActionExecuting(actionExecutingContext);

            Assert.That(actionExecutingContext.RequestContext.HttpContext.Items["CanonicalUrl"], Is.EqualTo(canonicalUrl));
        }

        [Test]
        public void Should_canonicalize_url_using_predefined_url_policies()
        {
            var canonicalUrlAttribute = new CanonicalUrlAttribute("/{userid}/{addressid}/");
            var actionExecutingContext = new ActionExecutingContext();
            var canonicalUrl = "http://contactly.com/2/3/";

            AddUserObjectToActionParameters(actionExecutingContext);
            SetHttpContext(actionExecutingContext, "http://www.contactly.com");

            UrlPolicyConfiguration.Configure().TrailingSlashPolicy().NoWwwPolicy();

            canonicalUrlAttribute.OnActionExecuting(actionExecutingContext);

            Assert.That(actionExecutingContext.RequestContext.HttpContext.Items["CanonicalUrl"], Is.EqualTo(canonicalUrl));
        }

        #region Helpers

        private void SetHttpContext(ActionExecutingContext actionExecutingContext, string requestUrl)
        {
            var httpContext = new HttpContext(
                new HttpRequest("", requestUrl, ""),
                new HttpResponse(new StringWriter()));

            actionExecutingContext.RequestContext = new RequestContext();
            actionExecutingContext.RequestContext.HttpContext = new HttpContextWrapper(httpContext);
        }

        private void AddUserObjectToActionParameters(ActionExecutingContext actionExecutingContext)
        {
            var user = new User()
            {
                UserId = 2,
                Name = "John Doe",
                Address = new Address()
                {
                    AddressId = 3,
                    Address1 = "House on a hill",
                    Address2 = "Hilltop City",
                    Country = "UK",
                    PostCode = "12345"
                }
            };
            actionExecutingContext.ActionParameters = new Dictionary<string, object>();
            actionExecutingContext.ActionParameters.Add("user", user);
        } 

        #endregion
    }

    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }
    }

    public class Address
    {
        public int AddressId { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Country { get; set; }
        public string PostCode { get; set; }
    }
}
