using System;
using NUnit.Framework;

namespace SeoPack.Tests.Helpers.HtmlSeoHelper
{
    [Category("HtmlSeoHelper.Title")]
    [TestFixture]
    public class TitleTests
    {
        [TestCase(null)]
        [TestCase("")]
        [ExpectedException(typeof(ArgumentException))]
        public void Should_throw_exception_if_title_is_null_or_empty(string title)
        {
            var seoHelper = new SeoPack.Helpers.HtmlSeoHelper();
            seoHelper.Title(title);
        }

        [TestCase("The is the official SeoPack website. We've got tons of nice goodies for")]//71
        [TestCase("The is the official SeoPack website. We've got tons of nice goodies for y")]//73
        [ExpectedException(typeof(ArgumentException))]
        public void Should_throw_exception_if_title_is_more_than_70_characters_in_length(string title)
        {
            var seoHelper = new SeoPack.Helpers.HtmlSeoHelper();
            seoHelper.Title(title);
        }

        [TestCase("The is the official SeoPack website. We've got tons of nice goodies f")]//69
        [TestCase("The is the official SeoPack website. We've got tons of nice goodies fo")]//70
        public void Should_return_the_correct_output_if_title_is_70_or_characters_or_less(string title)
        {
            var seoHelper = new SeoPack.Helpers.HtmlSeoHelper();
            var output = seoHelper.Title(title);

            Assert.That(output.ToString(), Is.EqualTo(string.Format("<title>{0}</title>", title)));
        }
    }
}
