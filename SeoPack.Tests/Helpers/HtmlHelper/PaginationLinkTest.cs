﻿using System;
using System.Web.Mvc;
using NUnit.Framework;
using SeoPack.Helpers;
using SeoPack.Html;

namespace SeoPack.Tests.Helpers.HtmlHelper
{
    [Category("HtmlSeoHelper.PaginationLink")]
    [TestFixture]
    public class PaginationLinkTest
    {
        private int currentPage;
        private int recordCount;
        private string urlFormat;
        private bool pageIsZeroBased;
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
        public void Should_throw_exception_if_paginationlink_object_is_null()
        {
            _htmlHelper.SpPaginationLink(null);
        }

        [Test]
        public void Should_return_rel_prev_and_rel_next_pagination_links_when_currentpage_is_not_first_page_and_is_less_than_recordcount()
        {
            currentPage = 3;
            recordCount = 10;
            urlFormat = "http://www.seopack.com/result?page={0}";
            pageIsZeroBased = true;

            var paginationLink = new PaginationLink(currentPage, recordCount, urlFormat, pageIsZeroBased);

            var output = _htmlHelper.SpPaginationLink(paginationLink);

            Assert.That(output.ToString(), Is.EqualTo(
                "<link rel=\"prev\" heref=\"http://www.seopack.com/result?page=2\" /><link rel=\"next\" heref=\"http://www.seopack.com/result?page=4\" />"));
        }

        [TestCase(true)]
        [TestCase(false)]
        public void Should_return_only_rel_next_pagination_link_when_currentpage_is_first_page_and_is_less_than_recordcount(bool pageIsZeroBased)
        {
            currentPage = pageIsZeroBased ? 0 : 1;
            recordCount = 10;
            urlFormat = "http://www.seopack.com/result?page={0}";

            var paginationLink = new PaginationLink(currentPage, recordCount, urlFormat, pageIsZeroBased);

            var output = _htmlHelper.SpPaginationLink(paginationLink);
            
            if (pageIsZeroBased)
            {
                Assert.That(output.ToString(), Is.EqualTo(
                "<link rel=\"next\" heref=\"http://www.seopack.com/result?page=1\" />"));
            }
            else
            {
                Assert.That(output.ToString(), Is.EqualTo(
                "<link rel=\"next\" heref=\"http://www.seopack.com/result?page=2\" />"));
            }
        }

        [TestCase(true)]
        [TestCase(false)]
        public void Should_return_only_rel_prev_pagination_link_when_currentpage_is_equal_to_last_page(bool pageIsZeroBased)
        {
            currentPage = pageIsZeroBased ? 9 : 10;
            recordCount = 10;
            urlFormat = "http://www.seopack.com/result?page={0}";

            var paginationLink = new PaginationLink(currentPage, recordCount, urlFormat, pageIsZeroBased);

            var output = _htmlHelper.SpPaginationLink(paginationLink);

            if (pageIsZeroBased)
            {
                Assert.That(output.ToString(), Is.EqualTo(
                "<link rel=\"prev\" heref=\"http://www.seopack.com/result?page=8\" />"));
            }
            else
            {
                Assert.That(output.ToString(), Is.EqualTo(
                "<link rel=\"prev\" heref=\"http://www.seopack.com/result?page=9\" />"));
            }
        }
    }
}
