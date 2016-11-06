using System;
using System.Web.Mvc;
using NUnit.Framework;
using SeoPack.Helpers;

namespace SeoPack.Tests.Helpers.HtmlHelper
{
    [Category("HtmlSeoHelper.MetaDescription")]
    [TestFixture]
    public class MetaDescriptionTests
    {
        private System.Web.Mvc.HtmlHelper _htmlHelper;

        [SetUp]
        public void SetUp()
        {
            _htmlHelper =
                Helpers.CreateHtmlHelper<string>(
                        new ViewDataDictionary("Hello World"));
        }

        [TestCase(null)]
        [TestCase("")]
        [ExpectedException(typeof(ArgumentException))]
        public void Should_throw_exception_if_meta_description_is_null_or_empty(string description)
        {
            _htmlHelper.SpMetaDescription(description);
        }

        [TestCase("The is the official SeoPack website. We've got tonThe is the official SeoPack website. " +
            "We've got tonThe is the official SeoPack website. We've got ton123456")]//156
        [TestCase("The is the official SeoPack website. We've got tonThe is the official SeoPack website. " +
            "We've got tonThe is the official SeoPack website. We've got ton1234567")]//157
        [ExpectedException(typeof(ArgumentException))]
        public void Should_throw_exception_if_description_is_greater_than_155_characters_in_length(string description)
        {
            _htmlHelper.SpMetaDescription(description);
        }

        [TestCase("The is the official SeoPack website. We've got tonThe is the official SeoPack website. " +
            "We've got tonThe is the official SeoPack website. We've got ton1234")]//154
        [TestCase("The is the official SeoPack website. We've got tonThe is the official SeoPack website. " +
            "We've got tonThe is the official SeoPack website. We've got ton12345")]//155
        public void Should_return_correct_output_if_description_is_155_characters_or_less(string description)
        {
            var output = _htmlHelper.SpMetaDescription(description);

            Assert.That(output.ToString(), Is.EqualTo(string.Format("<meta name=\"description\" content=\"{0}\">", description)));
        }
    }
}
