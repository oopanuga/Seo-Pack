using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace SeoPack.Html
{
    public class HrefLangPage
    {
        private List<HrefLangLink> _hrefLangLinks;

        public HrefLangPage(string pageName)
        {
            if (string.IsNullOrEmpty(pageName))
            {
                throw new ArgumentException("pageName not set");
            }

            _hrefLangLinks = new List<HrefLangLink>();
            PageName = pageName;
        }

        public string PageName { get; private set; }

        public ReadOnlyCollection<HrefLangLink> HrefLangLinks { get { return _hrefLangLinks.AsReadOnly(); } }

        public void AddHrefLangLink(HrefLangLink hrefLangLink)
        {
            if (hrefLangLink == null)
            {
                throw new ArgumentNullException("hrefLangLink");
            }

            if (HrefLangLinks.Any(x => x.Equals(hrefLangLink)))
            {
                throw new ArgumentException("HrefLangLink already exists in collection");
            }

            if (hrefLangLink.IsDefault && HrefLangLinks.Any(x => x.IsDefault))
            {
                throw new ArgumentException("Cannot have more than one default language: x-default");
            }

            _hrefLangLinks.Add(hrefLangLink);
        }

        public void RemoveHrefLangLink(HrefLangLink hrefLangLink)
        {
            if (hrefLangLink == null)
            {
                throw new ArgumentNullException("hrefLangLink");
            }

            var hrefLangLinkToRemove = _hrefLangLinks.SingleOrDefault(x => x.Equals(hrefLangLink));

            if (hrefLangLinkToRemove != null)
            {
                _hrefLangLinks.Remove(hrefLangLinkToRemove);
            }
        }

        public void ClearHrefLangLinks()
        {
            _hrefLangLinks.Clear();
        }
    }
}
