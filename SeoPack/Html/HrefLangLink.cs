using System;

namespace SeoPack.Html
{
    public class HrefLangLink
    {
        const string defaultLanguage = "x-default";

        public HrefLangLink(string canonicalUrl, string language)
        {
            if (string.IsNullOrEmpty(canonicalUrl))
            {
                throw new ArgumentException("canonicalUrl not set");
            }

            if (string.IsNullOrEmpty(language))
            {
                throw new ArgumentException("language not set");
            }

            CanonicalUrl = canonicalUrl;
            Language = language;
        }

        public HrefLangLink(string canonicalUrl) : this(canonicalUrl, defaultLanguage) { }

        public string CanonicalUrl { get; private set; }
        public string Language { get; private set; }
        public bool IsDefault { get { return Language == defaultLanguage; } }

        public override bool Equals(object obj)
        {
            var hrefLangLink = obj as HrefLangLink;

            if (hrefLangLink == null) return false;

            return hrefLangLink.CanonicalUrl.Equals(this.CanonicalUrl, StringComparison.CurrentCultureIgnoreCase);
        }
    }
}
