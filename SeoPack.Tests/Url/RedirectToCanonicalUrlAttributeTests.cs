using NUnit.Framework;
using SeoPack.Url;
using SeoPack.Url.UrlPolicy;
using System.IO;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SeoPack.Tests.Url
{
    [Category("RedirectToCanonicalUrlAttribute.OnAuthorization")]
    [TestFixture]
    public class RedirectToCanonicalUrlAttributeTests
    {
        [SetUp]
        public void Setup()
        {
            UrlPolicyConfiguration.Configure().NoTrailingSlashPolicy().WwwPolicy();
        }

        [Test] public void Should_do_a_permanent_redirect_to_the_canonical_version_of_the_requested_url_if_it_doesnt_conform_to_the_predefined_url_policies()
        {
            var redirectToCanonicalUrlAttribute = new RedirectToCanonicalUrlAttribute();
            var authorizationContext = new AuthorizationContext();
            var canonicalUrl = "http://www.contactly.com/2/3";

            var httpContext = new HttpContext(
                new HttpRequest("", "http://contactly.com/2/3", ""),
                new HttpResponse(new StringWriter()));

            authorizationContext.RequestContext = new RequestContext
            {
                HttpContext = new HttpContextWrapper(httpContext)
            };

            redirectToCanonicalUrlAttribute.OnAuthorization(authorizationContext);

            var redirectResult = authorizationContext.Result as RedirectResult;

            Assert.That(redirectResult, Is.Not.Null);
            Assert.That(redirectResult.Url, Is.EqualTo(canonicalUrl));
            Assert.That(redirectResult.Permanent, Is.EqualTo(true));
        }

        [Test]
        public void Should_not_do_a_redirect_if_the_requested_url_conforms_to_the_predefined_url_policies()
        {
            var redirectToCanonicalUrlAttribute = new RedirectToCanonicalUrlAttribute();
            var authorizationContext = new AuthorizationContext();
            var canonicalUrl = "http://www.contactly.com/2/3";

            var httpContext = new HttpContext(
                new HttpRequest("", "http://www.contactly.com/2/3", ""),
                new HttpResponse(new StringWriter()));

            authorizationContext.RequestContext = new RequestContext
            {
                HttpContext = new HttpContextWrapper(httpContext)
            };

            redirectToCanonicalUrlAttribute.OnAuthorization(authorizationContext);

            var redirectResult = authorizationContext.Result as RedirectResult;

            Assert.That(redirectResult, Is.Null);
        }
    }
}
