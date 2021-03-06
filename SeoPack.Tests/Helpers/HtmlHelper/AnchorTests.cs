﻿using System;
using System.Web.Mvc;
using NUnit.Framework;
using SeoPack.Helpers;
using SeoPack.Html;

namespace SeoPack.Tests.Helpers.HtmlHelper
{
    [Category("HtmlSeoHelper.Anchor")]
    [TestFixture]
    public class AnchorTests
    {
        string text = "SeoPack";
        string href = "http://www.seopack.com";
        object attributes = new { @class = "bold" };
        string title = "This is the official SeoPack website";
        private System.Web.Mvc.HtmlHelper _htmlHelper;

        [SetUp]
        public void SetUp()
        {
            _htmlHelper =
                Helpers.CreateHtmlHelper<string>(
                        new ViewDataDictionary("Hello World"));
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Should_throw_exception_if_anchor_object_is_null()
        {
            _htmlHelper.SpAnchor(null);
        }

        [Test]
        public void Should_include_rel_nofollow_in_anchor_tag_if_nofollow_is_set_to_true()
        {
            var noFollow = true;
            var anchor = new Anchor(href, text, noFollow, attributes);
            anchor.Title = title;

            var output = _htmlHelper.SpAnchor(anchor);

            Assert.That(output.ToString(), Is.EqualTo(
                string.Format("<a href=\"{0}\" title=\"{1}\" rel=\"{2}\" class=\"{3}\">{4}</a>", href, title, "nofollow", "bold", text)));
        }

        [Test]
        public void Should_exclude_rel_nofollow_in_anchor_tag_if_nofollow_is_set_to_false()
        {
            var noFollow = false;
            var anchor = new Anchor(href, text, noFollow, attributes);
            anchor.Title = title;

            var output = _htmlHelper.SpAnchor(anchor);

            Assert.That(output.ToString(), Is.EqualTo(
                string.Format("<a href=\"{0}\" title=\"{1}\" class=\"{2}\">{3}</a>", href, title, "bold", text)));
        }

        [Test]
        public void Should_convert_underscores_to_hyphens_in_attribute_names()
        {
            var attributes = new { text_font_weight = "bold" };
            var noFollow = false;
            var anchor = new Anchor(href, text, noFollow, attributes);
            anchor.Title = title;

            var output = _htmlHelper.SpAnchor(anchor);

            Assert.That(output.ToString(), Is.EqualTo(
                string.Format("<a href=\"{0}\" title=\"{1}\" text-font-weight=\"{2}\">{3}</a>", href, title, "bold", text)));
        }
    }
}
