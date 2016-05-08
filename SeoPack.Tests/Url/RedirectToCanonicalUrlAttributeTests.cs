using System;
using System.Collections.Specialized;
using NUnit.Framework;
using SeoPack.Url;
using SeoPack.Url.UrlPolicy;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Moq;

namespace SeoPack.Tests.Url
{
    [Category("RedirectToCanonicalUrlAttribute.OnAuthorization")]
    [TestFixture]
    public class RedirectToCanonicalUrlAttributeTests
    {
        [SetUp]
        public void Setup()
        {
            UrlPolicyConfiguration.Configure().TrailingSlashPolicy().WwwPolicy();
        }

        [Test] public void Should_do_a_301_redirect_to_canonical_version_of_url_if_requested_url_not_canonical()
        {
            var requestUrl = "http://contactly.com/2/3/";
            var hasNoTrailingSlashAttribute = false;
            var filterContext = SetupAuthorizationContext(requestUrl, hasNoTrailingSlashAttribute);
            var canonicalUrl = "http://www.contactly.com/2/3/";

            var sut = new RedirectToCanonicalUrlAttribute();
            sut.OnAuthorization(filterContext);

            var redirectResult = filterContext.Result as RedirectResult;

            Assert.That(redirectResult, Is.Not.Null);
            Assert.That(redirectResult.Url, Is.EqualTo(canonicalUrl));
            Assert.That(redirectResult.Permanent, Is.EqualTo(true));
        }

        [Test]
        public void Should_not_do_a_301_redirect_to_canonical_version_of_url_if_requested_url_is_already_canonical()
        {
            var requestUrl = "http://www.contactly.com/2/3/";
            var hasNoTrailingSlashAttribute = false;
            var filterContext = SetupAuthorizationContext(requestUrl, hasNoTrailingSlashAttribute);
            var canonicalUrl = "http://www.contactly.com/2/3/";

            var sut = new RedirectToCanonicalUrlAttribute();
            sut.OnAuthorization(filterContext);

            var redirectResult = filterContext.Result as RedirectResult;

            Assert.That(redirectResult, Is.Null);
        }

        [TestCase("http://contactly.com/sitemap.xml", "http://www.contactly.com/sitemap.xml")]
        [TestCase("http://contactly.com/sitemap.xml/?userid=4", "http://www.contactly.com/sitemap.xml?userid=4")]
        public void Should_do_a_301_redirect_to_canonical_version_of_url_with_no_traling_slash_if_action_has_notrailingslash_attribute(string requestUrl, string canonicalUrl)
        {
            var hasNoTrailingSlashAttribute = true;
            var filterContext = SetupAuthorizationContext(requestUrl, hasNoTrailingSlashAttribute);

            var sut = new RedirectToCanonicalUrlAttribute();
            sut.OnAuthorization(filterContext);

            var redirectResult = filterContext.Result as RedirectResult;

            Assert.That(redirectResult, Is.Not.Null);
            Assert.That(redirectResult.Url, Is.EqualTo(canonicalUrl));
            Assert.That(redirectResult.Permanent, Is.EqualTo(true));
        }

        [Test]
        public void Should_not_do_a_301_redirect_to_canonical_version_of_url_if_request_url_is_same_as_canonical_one_and_action_has_notrailingslash_attribute()
        {
            var requestUrl = "http://www.contactly.com/sitemap.xml";
            var hasNoTrailingSlashAttribute = true;
            var filterContext = SetupAuthorizationContext(requestUrl, hasNoTrailingSlashAttribute);
            var canonicalUrl = "http://www.contactly.com/sitemap.xml";

            var sut = new RedirectToCanonicalUrlAttribute();
            sut.OnAuthorization(filterContext);

            var redirectResult = filterContext.Result as RedirectResult;

            Assert.That(redirectResult, Is.Null);
        }

        private AuthorizationContext SetupAuthorizationContext(string url, bool hasNoTrailingSlashAttribute)
        {
            var context = new Mock<HttpContextBase>();
            var request = new Mock<HttpRequestBase>();
            var headers = new NameValueCollection
            {
                {"Special-Header-Name", "false"}
            };
            request.Setup(x => x.Headers).Returns(headers);
            request.Setup(x => x.HttpMethod).Returns("GET");
            request.Setup(x => x.Url).Returns(new Uri(url));
            request.Setup(x => x.RawUrl).Returns("/home/index");
            context.Setup(x => x.Request).Returns(request.Object);

            var controller = new Mock<ControllerBase>();
            var controllerDescriptor = new Mock<ControllerDescriptor>();
            var actionDescriptor = new Mock<ActionDescriptor>();
            var controllerContext = new ControllerContext(context.Object, new RouteData(), controller.Object);
            var filterContext = new AuthorizationContext(controllerContext, actionDescriptor.Object);

            actionDescriptor.Setup(x => x.IsDefined(It.IsAny<Type>(), false)).Returns(hasNoTrailingSlashAttribute);
            controllerDescriptor.Setup(x => x.IsDefined(It.IsAny<Type>(), false)).Returns(hasNoTrailingSlashAttribute);
            actionDescriptor.Setup(x => x.ControllerDescriptor).Returns(controllerDescriptor.Object);

            return filterContext;
        }
    }
}
