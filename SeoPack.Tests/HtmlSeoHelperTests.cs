﻿using NUnit.Framework;
using SeoPack.Helpers;
using SeoPack.Html;
using System;

namespace SeoPack.Tests
{
    [TestFixture]
    public class HtmlSeoHelperTests
    {
        [Category("HtmlSeoHelper.Image(image)")]
        public class ImageTests
        {
            [Test]
            [ExpectedException(typeof(ArgumentNullException))]
            public void Should_throw_exception_if_image_object_is_null()
            {
                var seoHelper = new HtmlSeoHelper();
                seoHelper.Image(null);
            }

            [Test]
            public void Should_return_correct_output_when_image_object_is_not_null()
            {
                var altText = "This is an image of a dog";
                var src = "http://www.seopack.com/dog.png";
                var attributes = new { @class = "dog" };
                var title = "This is an image of a dog";

                var image = new Image(src, altText, attributes);
                image.Title = title;

                var seoHelper = new HtmlSeoHelper();
                var output = seoHelper.Image(image);

                Assert.That(output.ToString(), Is.EqualTo(
                    string.Format("<img src=\"{0}\" alt=\"{1}\" title=\"{2}\" class=\"{3}\" />", src, altText, title, "dog")));
            }
        }

        [Category("HtmlSeoHelper.Anchor(anchor)")]
        public class AnchorTests
        {
            string text = "SeoPack";
            string href = "http://www.seopack.com";
            object attributes = new { @class = "bold" };
            string title = "This is the official SeoPack website";

            [Test]
            [ExpectedException(typeof(ArgumentNullException))]
            public void Should_throw_exception_if_anchor_object_is_null()
            {
                var seoHelper = new HtmlSeoHelper();
                seoHelper.Anchor(null);
            }

            [Test]
            public void Should_include_rel_nofollow_in_output_if_set_to_true()
            {
                var noFollow = true;
                var anchor = new Anchor(href, text, noFollow, attributes);
                anchor.Title = title;

                var seoHelper = new HtmlSeoHelper();
                var output = seoHelper.Anchor(anchor);

                Assert.That(output.ToString(), Is.EqualTo(
                    string.Format("<a href=\"{0}\" title=\"{1}\" rel=\"{2}\" class=\"{3}\">{4}</a>", href, title, "nofollow", "bold", text)));
            }

            [Test]
            public void Should_exclude_rel_nofollow_in_output_if_set_to_false()
            {
                var noFollow = false;
                var anchor = new Anchor(href, text, noFollow, attributes);
                anchor.Title = title;

                var seoHelper = new HtmlSeoHelper();
                var output = seoHelper.Anchor(anchor);

                Assert.That(output.ToString(), Is.EqualTo(
                    string.Format("<a href=\"{0}\" title=\"{1}\" class=\"{2}\">{3}</a>", href, title, "bold", text)));
            }
        }

        [Category("HtmlSeoHelper.ImageLink(imageLink)")]
        public class ImageLinkTests
        {
            [Test]
            [ExpectedException(typeof(ArgumentNullException))]
            public void Should_throw_exception_if_imagelink_object_is_null()
            {
                var seoHelper = new HtmlSeoHelper();
                seoHelper.ImageLink(null);
            }

            [Test]
            public void Should_return_correct_output_when_imagelink_object_not_null()
            {
                var altText = "This is an image of a dog";
                var src = "http://www.seopack.com/dog.png";
                var attributes = new { @class = "bold" };
                var nofollow = true;
                var href = "http://www.seopack.com";
                var title = "This is an image link";

                var image = new Image(src, altText);
                var imageLink = new ImageLink(image, href, nofollow, attributes);
                imageLink.Title = title;

                var seoHelper = new HtmlSeoHelper();
                var output = seoHelper.ImageLink(imageLink);

                Assert.That(output.ToString(), Is.EqualTo(
                    string.Format("<a href=\"{0}\" title=\"{1}\" rel=\"{2}\" class=\"{3}\"><img src=\"{4}\" alt=\"{5}\" /></a>", href, title, "nofollow", "bold", src, altText)));
            }
        }

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
    }
}
