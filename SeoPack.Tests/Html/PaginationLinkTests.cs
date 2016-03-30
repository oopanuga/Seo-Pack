using NUnit.Framework;
using SeoPack.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeoPack.Tests.Html
{
    [TestFixture]
    public class PaginationLinkTests
    {
        [Category("PaginationLink.Constructor")]
        public class Constructor
        {
            private int currentPage;
            private int recordCount;
            private string urlFormat;
            private bool pageIsZeroBased;

            [TestCase(true)]
            [TestCase(false)]
            [ExpectedException(typeof(ArgumentException))]
            public void Should_throw_exception_when_currentpage_is_less_than_zero(bool pageIsZeroBased)
            {
                try
                {
                    currentPage = -1;
                    recordCount = 10;
                    urlFormat = "http://www.seopack.com/result?page={0}";

                    new PaginationLink(currentPage, recordCount, urlFormat, pageIsZeroBased);
                }
                catch (ArgumentException ex)
                {
                    Assert.That(ex.Message, Is.EqualTo(string.Format("currentPage cannot be less than {0}", pageIsZeroBased ? "0" : "1")));
                    throw;
                }
            }

            [Test]
            [ExpectedException(typeof(ArgumentException))]
            public void Should_throw_exception_when_currentpage_is_equal_to_zero_and_pageiszerobased_is_false()
            {
                try
                {
                    currentPage = 0;
                    recordCount = 10;
                    urlFormat = "http://www.seopack.com/result?page={0}";
                    pageIsZeroBased = false;

                    new PaginationLink(currentPage, recordCount, urlFormat, pageIsZeroBased);
                }
                catch (ArgumentException ex)
                {
                    Assert.That(ex.Message, Is.EqualTo("currentPage cannot be less than 1"));
                    throw;
                }
            }

            [Test]
            public void Should_set_properties_when_currentpage_is_equal_to_zero_and_pageiszerobased_is_true()
            {
                currentPage = 0;
                recordCount = 10;
                urlFormat = "http://www.seopack.com/result?page={0}";
                pageIsZeroBased = true;

                var paginationLink = new PaginationLink(currentPage, recordCount, urlFormat, pageIsZeroBased);

                Assert.That(paginationLink.CurrentPage, Is.EqualTo(currentPage));
                Assert.That(paginationLink.PageIsZeroBased, Is.EqualTo(pageIsZeroBased));
                Assert.That(paginationLink.RecordCount, Is.EqualTo(recordCount));
                Assert.That(paginationLink.UrlFormat, Is.EqualTo(urlFormat));
            }

            [TestCase(-1)]
            [TestCase(0)]
            [ExpectedException(typeof(ArgumentException))]
            public void Should_throw_exception_when_recordcount_is_less_than_or_equal_to_zero(int recordCount)
            {
                currentPage = 1;
                urlFormat = "http://www.seopack.com/result?page={0}";
                pageIsZeroBased = true;

                new PaginationLink(currentPage, recordCount, urlFormat, pageIsZeroBased);
            }

            [TestCase(null)]
            [TestCase("")]
            [ExpectedException(typeof(ArgumentException))]
            public void Should_throw_exception_when_urlformat_is_null_or_empty(string urlFormat)
            {
                currentPage = 1;
                recordCount = 10;
                pageIsZeroBased = true;

                new PaginationLink(currentPage, recordCount, urlFormat, pageIsZeroBased);
            }

            [Test]
            [ExpectedException(typeof(ArgumentException))]
            public void Should_throw_exception_when_current_page_is_greater_than_recordcount()
            {
                currentPage = 5;
                recordCount = 2;
                urlFormat = "http://www.seopack.com/result?page={0}";
                pageIsZeroBased = true;

                new PaginationLink(currentPage, recordCount, urlFormat, pageIsZeroBased);
            }

            [Test]
            public void Should_correctly_set_properties_using_constructor_arguments()
            {
                currentPage = 1;
                recordCount = 10;
                urlFormat = "http://www.seopack.com/result?page={0}";
                pageIsZeroBased = true;

                var paginationLink = new PaginationLink(currentPage, recordCount, urlFormat, pageIsZeroBased);

                Assert.That(paginationLink.CurrentPage, Is.EqualTo(currentPage));
                Assert.That(paginationLink.PageIsZeroBased, Is.EqualTo(pageIsZeroBased));
                Assert.That(paginationLink.RecordCount, Is.EqualTo(recordCount));
                Assert.That(paginationLink.UrlFormat, Is.EqualTo(urlFormat));
            }
        }
    }
}
