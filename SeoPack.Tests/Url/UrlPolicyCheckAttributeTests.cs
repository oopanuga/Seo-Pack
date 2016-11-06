using System;
using NUnit.Framework;
using SeoPack.Url;
using SeoPack.Url.UrlPolicy;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Moq;

namespace SeoPack.Tests.Url
{
    [Category("UrlPolicyCheckAttribute.OnAuthorization")]
    [TestFixture]
    public class UrlPolicyCheckAttributeTests
    {
        [SetUp]
        public void Setup()
        {
            UrlPolicyConfiguration.Configure().TrailingSlashPolicy().WwwPolicy();
        }

        [Test] public void Should_do_a_301_redirect_to_canonical_version_of_url_if_requested_url_not_canonical()
        {
            var requestUrl = "http://contactly.com/2/3/";
            var skipUrlPolicyCheckFilter = false;
            var filterContext = SetupAuthorizationContext(requestUrl, skipUrlPolicyCheckFilter);
            var canonicalUrl = "http://www.contactly.com/2/3/";

            var sut = new UrlPolicyCheckAttribute();
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
            var skipUrlPolicyCheckFilter = false;
            var filterContext = SetupAuthorizationContext(requestUrl, skipUrlPolicyCheckFilter);

            var sut = new UrlPolicyCheckAttribute();
            sut.OnAuthorization(filterContext);

            var redirectResult = filterContext.Result as RedirectResult;

            Assert.That(redirectResult, Is.Null);
        }

        [Test]
        public void Should_skip_url_policy_check_filter_if_controller_action_has_been_marked_with_skip_url_policy_check_filter_interface()
        {
            var skipUrlPolicyCheckFilter = true;
            var requestUrl = "http://contactly.com/sitemap.xml/";
            var filterContext = SetupAuthorizationContext(requestUrl, skipUrlPolicyCheckFilter);

            var sut = new UrlPolicyCheckAttribute();
            sut.OnAuthorization(filterContext);

            var redirectResult = filterContext.Result as RedirectResult;

            Assert.That(redirectResult, Is.Null);
        }

        private AuthorizationContext SetupAuthorizationContext(string url, bool skipUrlPolicyCheckFilter)
        {
            var context = new Mock<HttpContextBase>();
            var request = new Mock<HttpRequestBase>();

            request.Setup(x => x.HttpMethod).Returns("GET");
            request.Setup(x => x.Url).Returns(new Uri(url));
            context.Setup(x => x.Request).Returns(request.Object);

            var controller = new Mock<ControllerBase>();
            var controllerDescriptor = new Mock<ControllerDescriptor>();
            var actionDescriptor = new Mock<ActionDescriptor>();
            var controllerContext = new ControllerContext(context.Object, new RouteData(), controller.Object);
            var filterContext = new AuthorizationContext(controllerContext, actionDescriptor.Object);

            actionDescriptor.Setup(x => x.IsDefined(It.IsAny<Type>(), true)).Returns(skipUrlPolicyCheckFilter);
            controllerDescriptor.Setup(x => x.IsDefined(It.IsAny<Type>(), true)).Returns(skipUrlPolicyCheckFilter);
            actionDescriptor.Setup(x => x.ControllerDescriptor).Returns(controllerDescriptor.Object);

            return filterContext;
        }
    }
}
