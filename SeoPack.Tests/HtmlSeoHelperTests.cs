using NUnit.Framework;
using SeoPack.Helpers;
using System;

namespace SeoPack.Tests
{
    [TestFixture]
    public class HtmlSeoHelperTests
    {
        [Category("HtmlSeoHelper.Title(title)")]
        public class Title
        {
            [TestCase(null)]
            [TestCase("")]
            [ExpectedException(typeof(ArgumentException))]
            public void Should_throw_exception_if_title_is_null_or_empty(string title)
            {
                var seoHelper = new HtmlSeoHelper();
                seoHelper.Title(title);
            }

            [TestCase("The is the official SeoPack website")]//35
            [TestCase("The is the official SeoPack website. We've got to")]//49
            [TestCase("The is the official SeoPack website. We've got tons of nice t")]//61
            [ExpectedException(typeof(ArgumentException))]
            public void Should_throw_exception_if_validate_length_is_true_and_title_is_not_between_50_and_60_characters_in_length(string title)
            {
                var seoHelper = new HtmlSeoHelper();
                seoHelper.Title(title, true);
            }

            [TestCase("The is the official SeoPack website. We've got ton")]//50
            [TestCase("The is the official SeoPack website. We've got tons")]//51
            [TestCase("The is the official SeoPack website. We've got tons of nice ")]//60
            public void Should_return_the_correct_output_if_validate_length_is_true_and_title_is_between_50_and_60_characters_in_length(string title)
            {
                var seoHelper = new HtmlSeoHelper();
                var output = seoHelper.Title(title, true);

                Assert.That(output.ToString(), Is.EqualTo(string.Format("<title>{0}</title>", title)));
            }

            [TestCase("The is the official SeoPack website")]//35
            [TestCase("The is the official SeoPack website. We've got to")]//49
            [TestCase("The is the official SeoPack website. We've got tons of nice t")]//61
            public void Should_return_the_correct_output_if_validate_length_is_false_and_title_is_not_between_50_and_60_characters_in_length(string title)
            {
                var seoHelper = new HtmlSeoHelper();
                var output = seoHelper.Title(title, false);

                Assert.That(output.ToString(), Is.EqualTo(string.Format("<title>{0}</title>", title)));
            }
        }

        [Category("HtmlSeoHelper.MetaDescription(description)")]
        public class MetaDescription
        {
            [TestCase(null)]
            [TestCase("")]
            [ExpectedException(typeof(ArgumentException))]
            public void Should_throw_exception_if_meta_description_is_null_or_empty(string description)
            {
                var seoHelper = new HtmlSeoHelper();
                seoHelper.MetaDescription(description);
            }

            [TestCase("The is the official SeoPack website. We've got tonThe is the official SeoPack website. " + 
                "We've got tonThe is the official SeoPack website. We've got ton123456")]//156
            [TestCase("The is the official SeoPack website. We've got tonThe is the official SeoPack website. " + 
                "We've got tonThe is the official SeoPack website. We've got ton1234567")]//157
            [ExpectedException(typeof(ArgumentException))]
            public void Should_throw_exception_if_validate_length_is_true_and_description_is_greater_than_155_characters_in_length(string description)
            {
                var seoHelper = new HtmlSeoHelper();
                seoHelper.MetaDescription(description, true);
            }

            [TestCase("The is the official SeoPack website. We've got tonThe is the official SeoPack website. " + 
                "We've got tonThe is the official SeoPack website. We've got ton12345")]//155
            [TestCase("The is the official SeoPack website. We've got tonThe is the official SeoPack website. " + 
                "We've got tonThe is the official SeoPack website. We've got ton1234")]//154
            public void Should_return_the_correct_output_if_validate_length_is_true_and_description_is_less_than_or_equal_to_155_characters_in_length(string description)
            {
                var seoHelper = new HtmlSeoHelper();
                var output = seoHelper.MetaDescription(description, true);

                Assert.That(output.ToString(), Is.EqualTo(string.Format("<meta name=\"description\" content=\"{0}\">", description)));
            }

            [TestCase("The is the official SeoPack website. We've got tonThe is the official SeoPack website. " +
                "We've got tonThe is the official SeoPack website. We've got ton123456")]//156
            [TestCase("The is the official SeoPack website. We've got tonThe is the official SeoPack website. " +
                "We've got tonThe is the official SeoPack website. We've got ton1234567")]//157
            public void Should_return_correct_output_if_validate_length_is_false_and_description_is_greater_than_155_characters_in_length(string description)
            {
                var seoHelper = new HtmlSeoHelper();
                var output = seoHelper.MetaDescription(description, false);

                Assert.That(output.ToString(), Is.EqualTo(string.Format("<meta name=\"description\" content=\"{0}\">", description)));
            }
        }

        [Category("HtmlSeoHelper.Image(image)")]
        public class ImageTests
        {
            //[ExpectedException(typeof(ArgumentNullException))]
            //public void Should_throw_exception_if_image_object_is_null()
            //{
            //    var seoHelper = new HtmlSeoHelper();
            //    seoHelper.Image(new Image();
            //}
        }
    }
}
