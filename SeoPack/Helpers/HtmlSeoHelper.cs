using SeoPack.Html;
using SeoPack.Html.OpenGraph;
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
        /// Returns an seo compliant title tag.
        /// </summary>
        /// <param name="title">The inner text of the title tag.</param>
        /// <param name="validateLength">A flag that indicates whether or not to validate the 
        /// length of the title. The title must be between 50 and 60 characters in length</param>
        /// <returns>The html string.</returns>
        public IHtmlString Title(string title, bool validateLength = false)
        {
            if (string.IsNullOrEmpty(title))
            {
                throw new ArgumentException("title not set");
            }

            if (validateLength)
            {
                if (title.Length < 50 || title.Length > 60)
                {
                    throw new ArgumentException(
                        "title must be between 50 and 60 characters in length");
                }
            }

            var htmlElement = new HtmlElement("title");
            htmlElement.SetInnerText(title);

            return MvcHtmlString.Create(htmlElement.ToString());
        }

        /// <summary>
        /// Returns an seo compliant meta description tag.
        /// </summary>
        /// <param name="description">The content of the description meta tag.</param>
        /// <param name="validateLength">A flag that indicates whether or not to validate the 
        /// length of the description. The description must be less than or equal to 155 characters
        /// in length</param>
        /// <returns>The html string.</returns>
        public IHtmlString MetaDescription(string description, bool validateLength = false)
        {
            if (string.IsNullOrEmpty(description))
            {
                throw new ArgumentException("description not set");
            }

            if (validateLength)
            {
                if (description.Length > 155)
                {
                    throw new ArgumentException(
                        "description cannot be more than 155 characters in length");
                }
            }

            var htmlElement = new HtmlElement("meta");
            htmlElement.AddAttribute("name", "description");
            htmlElement.AddAttribute("content", description);

            return MvcHtmlString.Create(htmlElement.ToString());
        }

        /// <summary>
        /// Returns an seo compliant image tag.
        /// </summary>
        /// <param name="image">Data used to build an image tag.</param>
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
        /// Returns an seo compliant anchor tag.
        /// </summary>
        /// <param name="anchor">Data used to build an anchor tag.</param>
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
        /// Returns an seo compliant image link.
        /// </summary>
        /// <param name="imageLink">Data used to build an anchor tag.</param>
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
        /// 
        /// </summary>
        /// <param name="canonicalUrl"></param>
        /// <returns></returns>
        public IHtmlString CanonicalLink(string canonicalUrl)
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

        public IHtmlString CanonicalLink()
        {
            var query = HttpContext.Current.Request.Url.Query;
            var canonicalUrl = "";
            if (query.Length > 0)
                canonicalUrl = HttpContext.Current.Request.Url.AbsoluteUri.Replace(query, "");
            else
                canonicalUrl = HttpContext.Current.Request.Url.AbsoluteUri;

            return BuildCanonicalLink(canonicalUrl);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="og"></param>
        /// <returns></returns>
        public IHtmlString OpenGraph(Og og)
        {
            if (og == null)
            {
                throw new ArgumentNullException("og");
            }

            return new OgHtmlSerializer().Serialize(og);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pagingLink"></param>
        /// <returns></returns>
        public IHtmlString PaginationAttributes(Pagination pagingLink)
        {
            if (pagingLink == null)
            {
                throw new ArgumentNullException("pagingLink");
            }

            var str = new StringBuilder();
            int firstPage = 1;
            int recordCount = pagingLink.RecordCount;

            if (pagingLink.PageIsZeroBased)
            {
                recordCount--;
                firstPage = 0;
            }

            if (pagingLink.CurrentPage < recordCount)
            {
                var htmlElement = new HtmlElement("link");
                htmlElement.AddAttribute("rel", "next");
                htmlElement.AddAttribute("heref",
                    string.Format(pagingLink.UrlFormat, pagingLink.CurrentPage + 1));

                str.Append(htmlElement.ToString());
            }

            if (pagingLink.CurrentPage > firstPage)
            {
                var htmlElement = new HtmlElement("link");
                htmlElement.AddAttribute("rel", "prev");
                htmlElement.AddAttribute("heref",
                    string.Format(pagingLink.UrlFormat, pagingLink.CurrentPage - 1));

                str.Append(htmlElement.ToString());
            }

            return MvcHtmlString.Create(str.ToString());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hrefLangLinks"></param>
        /// <returns></returns>
        public IHtmlString HrefLangLink(List<HrefLangLink> hrefLangLinks)
        {
            if (hrefLangLinks == null)
            {
                throw new ArgumentNullException("hrefLangLinks");
            }

            HtmlElement htmlElement;
            var currentPageUrl = HttpContext.Current.Request.Url.AbsoluteUri.ToLower();
            var foundUrl = hrefLangLinks.SingleOrDefault(
                x => x.CanonicalUrl.ToLower() == currentPageUrl);

            if (foundUrl == null)
                return MvcHtmlString.Create(string.Empty);

            var str = new StringBuilder();

            htmlElement = new HtmlElement("link");
            htmlElement.AddAttribute("rel", "alternate");
            htmlElement.AddAttribute("href", foundUrl.CanonicalUrl);
            htmlElement.AddAttribute("hreflang", foundUrl.Language);
            str.Append(htmlElement.ToString());

            var otherUrlsWithSamePageName = hrefLangLinks.Where(x =>
                x.PageName.ToLower() == foundUrl.PageName.ToLower() &&
                x.CanonicalUrl.Equals(foundUrl.CanonicalUrl,
                StringComparison.CurrentCultureIgnoreCase));

            foreach (var otherUrl in otherUrlsWithSamePageName)
            {
                htmlElement = new HtmlElement("link");
                htmlElement.AddAttribute("rel", "alternate");
                htmlElement.AddAttribute("href", otherUrl.CanonicalUrl);
                htmlElement.AddAttribute("hreflang", otherUrl.Language);
                str.Append(htmlElement.ToString());
            }

            return MvcHtmlString.Create(str.ToString());
        }

        #region Private Methods

        private HtmlElement BuildAnchorTag(AnchorBase anchor, string anchorText = "")
        {
            var htmlElement = new HtmlElement("a");
            htmlElement.AddAttribute("href", anchor.Href);

            if(!string.IsNullOrEmpty(anchor.Title))
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
                foreach (var pair in DictionaryFromAnonymousObject(anchor.Attributes))
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
                foreach (var pair in DictionaryFromAnonymousObject(image.Attributes))
                {
                    htmlElement.AddAttribute(pair.Key, pair.Value);
                }
            }

            return htmlElement;
        }

        private IDictionary<string, string> DictionaryFromAnonymousObject(object o)
        {
            IDictionary<string, string> dic = new Dictionary<string, string>();
            var properties = o.GetType().GetProperties();
            foreach (PropertyInfo prop in properties)
            {
                dic.Add(prop.Name, prop.GetValue(o, null) as string);
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
