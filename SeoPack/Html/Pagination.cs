using System;

namespace SeoPack.Html
{
    public class Pagination
    {
        public Pagination(int currentPage, int recordCount, string urlFormat, bool pageIsZeroBased = false)
        {
            if (recordCount <= 0)
            {
                throw new ArgumentException("recordCount must be greater than 0");
            }

            if(string.IsNullOrEmpty(urlFormat))
            {
                throw new ArgumentException("urlFormat not set");
            }

            if (currentPage > recordCount)
            {
                throw new ArgumentException(
                    "currntPage cannot be greater than recordCount");
            }

            CurrentPage = currentPage;
            RecordCount = recordCount;
            UrlFormat = urlFormat;
            PageIsZeroBased = pageIsZeroBased;
        }

        public int CurrentPage { get; private set; }
        public int RecordCount { get; private set; }
        public string UrlFormat { get; private set; }
        public bool PageIsZeroBased { get; set; }
    }
}
