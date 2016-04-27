using System.IO;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using NUnit.Framework;
using SeoPack.Url;
using SeoPack.Url.UrlPolicy;

namespace SeoPack.Tests.Url
{
    [Category("RedirectToSeoFriendlyUrlAttribute.OnAuthorization")]
    [TestFixture]
    public class RedirectToSeoFriendlyUrlAttributeTests
    {
        [SetUp]
        public void Setup()
        {
            UrlPolicyConfiguration.Configure().NoTrailingSlashPolicy().WwwPolicy();
        }

        [Test] public void Should_do_a_permanent_redirect_to_the_seo_friendly_version_of_the_requested_url_if_it_doesnt_conform_to_the_predefined_url_policies()
        {
            var redirectToSeoFriendlyUrlAttribute = new RedirectToSeoFriendlyUrlAttribute();
            var authorizationContext = new AuthorizationContext();
            var seoFriendlyUrl = "http://www.contactly.com/2/3";

            var httpContext = new HttpContext(
                new HttpRequest("", "http://contactly.com/2/3", ""),
                new HttpResponse(new StringWriter()));

            authorizationContext.RequestContext = new RequestContext
            {
                HttpContext = new HttpContextWrapper(httpContext)
            };

            redirectToSeoFriendlyUrlAttribute.OnAuthorization(authorizationContext);

            var redirectResult = authorizationContext.Result as RedirectResult;

            Assert.That(redirectResult, Is.Not.Null);
            Assert.That(redirectResult.Url, Is.EqualTo(seoFriendlyUrl));
            Assert.That(redirectResult.Permanent, Is.EqualTo(true));
        }

        [Test]
        public void Should_not_do_a_redirect_if_the_requested_url_conforms_to_the_predefined_url_policies()
        {
            var redirectToSeoFriendlyUrlAttribute = new RedirectToSeoFriendlyUrlAttribute();
            var authorizationContext = new AuthorizationContext();
            var seoFriendlyUrl = "http://www.contactly.com/2/3";

            var httpContext = new HttpContext(
                new HttpRequest("", "http://www.contactly.com/2/3", ""),
                new HttpResponse(new StringWriter()));

            authorizationContext.RequestContext = new RequestContext
            {
                HttpContext = new HttpContextWrapper(httpContext)
            };

            redirectToSeoFriendlyUrlAttribute.OnAuthorization(authorizationContext);

            var redirectResult = authorizationContext.Result as RedirectResult;

            Assert.That(redirectResult, Is.Null);
        }
    }
}
