using System;
using System.Web.Mvc;
using NUnit.Framework;
using SeoPack.Helpers;

namespace SeoPack.Tests.Helpers.HtmlHelper
{
    [Category("HtmlSeoHelper.Title")]
    [TestFixture]
    public class TitleTests
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
        public void Should_throw_exception_if_title_is_null_or_empty(string title)
        {
            _htmlHelper.SpTitle(title);
        }

        [TestCase("The is the official SeoPack website. We've got tons of nice goodies for")]//71
        [TestCase("The is the official SeoPack website. We've got tons of nice goodies for y")]//73
        [ExpectedException(typeof(ArgumentException))]
        public void Should_throw_exception_if_title_is_more_than_70_characters_in_length(string title)
        {
            _htmlHelper.SpTitle(title);
        }

        [TestCase("The is the official SeoPack website. We've got tons of nice goodies f")]//69
        [TestCase("The is the official SeoPack website. We've got tons of nice goodies fo")]//70
        public void Should_return_the_correct_output_if_title_is_70_or_characters_or_less(string title)
        {
            var output = _htmlHelper.SpTitle(title);

            Assert.That(output.ToString(), Is.EqualTo(string.Format("<title>{0}</title>", title)));
        }
    }
}
