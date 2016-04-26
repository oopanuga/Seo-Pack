using SeoPack.Html;
using SeoPack.Html.OpenGraph;
using SeoPack.Html.OpenGraph.ObjectTypes.Standard;
using SeoPack.Url;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace SeoPack.Helpers
{
    /// <summary>
    /// Represents a Html Seo Helper for generating SEO compliant html.
    /// </summary>
    public class HtmlSeoHelper : IHtmlSeoHelper
    {
        /// <summary>
        /// Returns a seo compliant title tag.
        /// </summary>
        /// <param name="title">The inner text of the title tag. The length 
        /// of the title. The title must be 70 characters or less.</param>
        /// <returns>The html string.</returns>
        public IHtmlString Title(string title)
        {
            if (string.IsNullOrEmpty(title))
            {
                throw new ArgumentException("title not set");
            }

            if (title.Length > 70)
            {
                throw new ArgumentException(
                    "title must be 70 characters or less");
            }

            var htmlElement = new HtmlElement("title");
            htmlElement.SetInnerText(title);

            return MvcHtmlString.Create(htmlElement.ToString());
        }

        /// <summary>
        /// Returns a seo compliant meta description tag.
        /// </summary>
        /// <param name="description">The content of the description meta tag. 
        /// The length of the description. The description must be 155 characters or less.</param>
        /// <returns>The html string.</returns>
        public IHtmlString MetaDescription(string description)
        {
            if (string.IsNullOrEmpty(description))
            {
                throw new ArgumentException("description not set");
            }

            if (description.Length > 155)
            {
                throw new ArgumentException(
                    "description must be 155 characters or less");
            }

            var htmlElement = new HtmlElement("meta");
            htmlElement.AddAttribute("name", "description");
            htmlElement.AddAttribute("content", description);

            return MvcHtmlString.Create(htmlElement.ToString());
        }

        /// <summary>
        /// Returns a seo compliant image tag.
        /// </summary>
        /// <param name="image">The image object.</param>
        /// <returns>The html string.</returns>
        public IHtmlString Image(Image image)
        {
            if (image == null)
            {
                throw new ArgumentNullException("image");
            }

            return MvcHtmlString.Create(BuildImageTag(image)
                .ToString());
        }

        /// <summary>
        /// Returns a seo compliant anchor tag.
        /// </summary>
        /// <param name="anchor">The anchor object.</param>
        /// <returns>The html string.</returns>
        public IHtmlString Anchor(Anchor anchor)
        {
            if (anchor == null)
            {
                throw new ArgumentNullException("anchor");
            }

            return MvcHtmlString.Create(BuildAnchorTag(anchor, anchor.Text).ToString());
        }

        /// <summary>
        /// Returns a seo compliant image link.
        /// </summary>
        /// <param name="imageLink">The imageLink object.</param>
        /// <returns>The html string.</returns>
        public IHtmlString ImageLink(ImageLink imageLink)
        {
            if (imageLink == null)
            {
                throw new ArgumentNullException("imageLink");
            }

            var anchorTag = BuildAnchorTag(imageLink);

            anchorTag.InnerHtml = BuildImageTag(imageLink.Image).ToString();

            return MvcHtmlString.Create(anchorTag.ToString());
        }

        /// <summary>
        /// Returns a seo compliant canonical link if the current page url begins with the 
        /// supplied canonical url but is not the same as the supplied canonical url.
        /// </summary>
        /// <param name="canonicalUrl">The canonical url.</param>
        /// <returns>The html string.</returns>
        public IHtmlString CanonicalLinkIfRequired(string canonicalUrl)
        {
            if (string.IsNullOrEmpty(canonicalUrl))
            {
                throw new ArgumentException("canonicalUrl not set");
            }

            var currentPageUrl = HttpContext.Current.Request.Url.AbsoluteUri.ToLower();

            if (currentPageUrl.Equals(canonicalUrl.ToLower()))
                return MvcHtmlString.Create(string.Empty);

            if (!currentPageUrl.StartsWith(canonicalUrl.ToLower()))
                return MvcHtmlString.Create(string.Empty);

            return BuildCanonicalLink(canonicalUrl);
        }

        /// <summary>
        /// It returns a seo compliant canonical link only if the current page url is not the 
        /// same as the deduced canonical url. It calls UrlHelper.CanonicalUrl() to get the 
        /// deduced canonical url and then it builds a Seo compliant Canonical Link off of it. 
        /// </summary>
        /// <returns>The html string.</returns>
        public IHtmlString CanonicalLinkIfRequired()
        {
            var canonicalUrl = new UrlSeoHelper().CanonicalUrl();

            var canonicalizedCurrentPageUrl = 
                new SeoFriendlyUrl(HttpContext.Current.Request.Url.AbsoluteUri).Value.ToString();

            if (canonicalizedCurrentPageUrl == canonicalUrl)
                return MvcHtmlString.Create(string.Empty);

            return BuildCanonicalLink(canonicalUrl);
        }

        /// <summary>
        /// Returns a seo compliant opengraph tag.
        /// </summary>
        /// <param name="og">The opengraph object.</param>
        /// <returns>The html string.</returns>
        public IHtmlString OpenGraph(Og og)
        {
            if (og == null)
            {
                throw new ArgumentNullException("og");
            }

            return new OgHtmlSerializer().Serialize(og);
        }

        /// <summary>
        /// Returns a seo compliant rel=next and/or rel=prev pagination link.
        /// </summary>
        /// <param name="paginationLink">The pagination link object.</param>
        /// <returns>The html string.</returns>
        public IHtmlString PaginationLink(PaginationLink paginationLink)
        {
            if (paginationLink == null)
            {
                throw new ArgumentNullException("paginationLink");
            }

            var str = new StringBuilder();
            int firstPage = 1;
            int recordCount = paginationLink.RecordCount;

            if (paginationLink.PageIsZeroBased)
            {
                recordCount--;
                firstPage = 0;
            }

            if (paginationLink.CurrentPage > firstPage)
            {
                var htmlElement = new HtmlElement("link");
                htmlElement.AddAttribute("rel", "prev");
                htmlElement.AddAttribute("heref",
                    string.Format(paginationLink.UrlFormat, paginationLink.CurrentPage - 1));

                str.Append(htmlElement.ToString());
            }

            if (paginationLink.CurrentPage < recordCount)
            {
                var htmlElement = new HtmlElement("link");
                htmlElement.AddAttribute("rel", "next");
                htmlElement.AddAttribute("heref",
                    string.Format(paginationLink.UrlFormat, paginationLink.CurrentPage + 1));

                str.Append(htmlElement.ToString());
            }

            return MvcHtmlString.Create(str.ToString());
        }

        /// <summary>
        /// Returns a seo compliant href lang link.
        /// </summary>
        /// <param name="hrefLangPages">A collection of pages with href lang link objects.</param>
        /// <returns>The html string.</returns>
        public IHtmlString HrefLangLink(IEnumerable<HrefLangPage> hrefLangPages)
        {
            if (hrefLangPages == null || !hrefLangPages.Any())
            {
                throw new ArgumentException("hrefLangPages not set");
            }

            if (hrefLangPages
                .GroupBy(x => x.PageName.ToLower())
                .Where(x => x.Count() > 1)
                .Select(x => x.Key).Count() > 1)
            {
                throw new ArgumentException("Href lang page names should be unique");
            }

            HtmlElement htmlElement;
            var currentPageUrl = HttpContext.Current.Request.Url.AbsoluteUri.ToLower();
            HrefLangLink foundLink = null;
            HrefLangPage foundPage = null;

            foreach (var page in hrefLangPages)
            {
                foundLink = page.HrefLangLinks.First(
                    x => x.CanonicalUrl.ToLower() == currentPageUrl);

                if (foundLink != null)
                {
                    foundPage = page;
                    break;
                }
            }

            if (foundLink == null)
                return MvcHtmlString.Create(string.Empty);

            var str = new StringBuilder();

            foreach (var link in foundPage
                                .HrefLangLinks
                                .OrderByDescending(x => x.IsDefault)
                                .ThenBy(x => x.Language))
            {
                htmlElement = new HtmlElement("link");
                htmlElement.AddAttribute("rel", "alternate");
                htmlElement.AddAttribute("hreflang", link.Language);
                htmlElement.AddAttribute("href", link.CanonicalUrl);
                str.Append(htmlElement.ToString());
            }

            return MvcHtmlString.Create(str.ToString());
        }

        #region Private Methods

        private HtmlElement BuildAnchorTag(AnchorBase anchor, string anchorText = "")
        {
            var htmlElement = new HtmlElement("a");
            htmlElement.AddAttribute("href", anchor.Href);

            if (!string.IsNullOrEmpty(anchor.Title))
            {
                htmlElement.AddAttribute("title", anchor.Title);
            }

            if (anchor.NoFollow)
            {
                htmlElement.AddAttribute("rel", "nofollow");
            }

            if (!string.IsNullOrEmpty(anchorText))
            {
                htmlElement.SetInnerText(anchorText);
            }

            if (anchor.Attributes != null)
            {
                foreach (var pair in AnonymousObjectToHtmlAttributes(anchor.Attributes))
                {
                    htmlElement.AddAttribute(pair.Key, pair.Value);
                }
            }

            return htmlElement;
        }

        private HtmlElement BuildImageTag(SeoPack.Html.Image image)
        {
            var htmlElement = new HtmlElement("img");
            htmlElement.AddAttribute("src", image.Src);
            htmlElement.AddAttribute("alt", image.AltText);

            if (!string.IsNullOrEmpty(image.Title))
            {
                htmlElement.AddAttribute("title", image.Title);
            }

            if (image.Attributes != null)
            {
                foreach (var pair in AnonymousObjectToHtmlAttributes(image.Attributes))
                {
                    htmlElement.AddAttribute(pair.Key, pair.Value);
                }
            }

            return htmlElement;
        }

        private IDictionary<string, string> AnonymousObjectToHtmlAttributes(object o)
        {
            IDictionary<string, string> dic = new Dictionary<string, string>();
            var properties = o.GetType().GetProperties();
            foreach (PropertyInfo prop in properties)
            {
                dic.Add(prop.Name.Replace("_", "-"), prop.GetValue(o, null) as string);
            }
            return dic;
        }

        private IHtmlString BuildCanonicalLink(string canonicalUrl)
        {
            var htmlElement = new HtmlElement("link");
            htmlElement.AddAttribute("rel", "canonical");
            htmlElement.AddAttribute("href", canonicalUrl);

            return MvcHtmlString.Create(htmlElement.ToString());
        }

        #endregion
    }
}
