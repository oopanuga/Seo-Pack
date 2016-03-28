using System;

namespace SeoPack.Html
{
    public class HrefLangLink
    {
        public HrefLangLink(string pageName, string canonicalUrl, string language)
        {
            if (string.IsNullOrEmpty(pageName))
            {
                throw new ArgumentException("pageName not set");
            }

            if (canonicalUrl == null)
            {
                throw new ArgumentException("canonicalUrl not set");
            }

            if (string.IsNullOrEmpty(language))
            {
                throw new ArgumentException("language not set");
            }

            PageName = pageName;
            CanonicalUrl = canonicalUrl;
            Language = language;
        }

        public string PageName { get; private set; }
        public string CanonicalUrl { get; private set; }
        public string Language { get; private set; }
    }
}
