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
    /// 
    /// </summary>
    public static class HtmlSeoHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public static IHtmlString Title(string title)
        {
            if (string.IsNullOrEmpty(title))
            {
                throw new ArgumentException("title not set");
            }

            if (title.Length < 50 || title.Length > 60)
            {
                throw new ArgumentException(
                    "title must be between 50 and 60 characters in length");
            }

            var tag = new TagBuilder("title");
            tag.SetInnerText(title);

            return MvcHtmlString.Create(tag.ToString());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="metaDescription"></param>
        /// <returns></returns>
        public static IHtmlString MetaDescription(string metaDescription)
        {
            if (string.IsNullOrEmpty(metaDescription))
            {
                throw new ArgumentException("metaDescription not set");
            }

            if (metaDescription.Length > 155)
            {
                throw new ArgumentException(
                    "metaDescription cannot be more than 155 characters in length");
            }

            var tag = new TagBuilder("meta");
            tag.MergeAttribute("name", "description");
            tag.MergeAttribute("content", metaDescription);

            return MvcHtmlString.Create(tag.ToString(TagRenderMode.SelfClosing));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        public static IHtmlString Image(SeoPack.Html.Image image)
        {
            if (image == null)
            {
                throw new ArgumentNullException("image");
            }

            return MvcHtmlString.Create(BuildImageTag(image)
                .ToString(TagRenderMode.SelfClosing));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="anchor"></param>
        /// <returns></returns>
        public static IHtmlString Anchor(Anchor anchor)
        {
            if (anchor == null)
            {
                throw new ArgumentNullException("anchor");
            }

            return MvcHtmlString.Create(BuildAnchorTag(anchor).ToString());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="imageLink"></param>
        /// <returns></returns>
        public static IHtmlString ImageLink(ImageLink imageLink)
        {
            if (imageLink == null)
            {
                throw new ArgumentNullException("imageLink");
            }

            var anchorTag = BuildAnchorTag((Anchor)imageLink);

            anchorTag.InnerHtml = BuildImageTag(imageLink.Image).ToString();

            return MvcHtmlString.Create(anchorTag.ToString(TagRenderMode.SelfClosing));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="canonicalUrl"></param>
        /// <returns></returns>
        public static IHtmlString CanonicalLink(Uri canonicalUrl)
        {
            if (canonicalUrl == null)
            {
                throw new ArgumentNullException("canonicalUrl");
            }

            var currentPageUrl = HttpContext.Current.Request.Url.AbsoluteUri.ToLower();

            if (currentPageUrl.Equals(canonicalUrl.AbsoluteUri.ToLower()))
                return MvcHtmlString.Create(string.Empty);

            if (!currentPageUrl.StartsWith(canonicalUrl.AbsoluteUri.ToLower()))
                return MvcHtmlString.Create(string.Empty);

            return BuildCanonicalLink(canonicalUrl.AbsoluteUri);
        }

        public static IHtmlString CanonicalLink()
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
        public static IHtmlString OpenGraph(Og og)
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
        public static IHtmlString PagingLink(PagingLink pagingLink)
        {
            if (pagingLink == null)
            {
                throw new ArgumentNullException("pagingLink");
            }

            var str = new StringBuilder();
            int firstPage = 1;

            if (pagingLink.PageIsZeroBased)
            {
                pagingLink.RecordCount--;
                firstPage = 0;
            }

            if (pagingLink.CurrentPage < pagingLink.RecordCount)
            {
                var tag = new TagBuilder("link");
                tag.MergeAttribute("rel", "next");
                tag.MergeAttribute("heref",
                    string.Format(pagingLink.UrlFormat, pagingLink.CurrentPage + 1));

                str.Append(tag.ToString(TagRenderMode.SelfClosing));
            }

            if (pagingLink.CurrentPage > firstPage)
            {
                var tag = new TagBuilder("link");
                tag.MergeAttribute("rel", "prev");
                tag.MergeAttribute("heref",
                    string.Format(pagingLink.UrlFormat, pagingLink.CurrentPage - 1));

                str.Append(tag.ToString(TagRenderMode.SelfClosing));
            }

            return MvcHtmlString.Create(str.ToString());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hrefLangLinks"></param>
        /// <returns></returns>
        public static IHtmlString HrefLangLink(List<HrefLangLink> hrefLangLinks)
        {
            if (hrefLangLinks == null)
            {
                throw new ArgumentNullException("hrefLangLinks");
            }

            TagBuilder tag;
            var currentPageUrl = HttpContext.Current.Request.Url.AbsoluteUri.ToLower();
            var foundUrl = hrefLangLinks.SingleOrDefault(
                x => x.CanonicalUrl.AbsoluteUri.ToLower() == currentPageUrl);

            if (foundUrl == null)
                return MvcHtmlString.Create(string.Empty);

            var str = new StringBuilder();

            tag = new TagBuilder("link");
            tag.MergeAttribute("rel", "alternate");
            tag.MergeAttribute("href", foundUrl.CanonicalUrl.AbsoluteUri);
            tag.MergeAttribute("hreflang", foundUrl.Language);
            str.Append(tag.ToString(TagRenderMode.SelfClosing));

            var otherUrlsWithSamePageName = hrefLangLinks.Where(x =>
                x.PageName.ToLower() == foundUrl.PageName.ToLower() &&
                x.CanonicalUrl.AbsoluteUri.Equals(foundUrl.CanonicalUrl.AbsoluteUri,
                StringComparison.CurrentCultureIgnoreCase));

            foreach (var otherUrl in otherUrlsWithSamePageName)
            {
                tag = new TagBuilder("link");
                tag.MergeAttribute("rel", "alternate");
                tag.MergeAttribute("href", otherUrl.CanonicalUrl.AbsoluteUri);
                tag.MergeAttribute("hreflang", otherUrl.Language);
                str.Append(tag.ToString(TagRenderMode.SelfClosing));
            }

            return MvcHtmlString.Create(str.ToString());
        }

        #region Private Methods

        private static TagBuilder BuildAnchorTag(Anchor anchor)
        {
            var tag = new TagBuilder("a");

            if (anchor.NoFollow)
            {
                tag.MergeAttribute("rel", "nofollow");
            }

            tag.MergeAttribute("href", anchor.Href);
            tag.MergeAttribute("title", anchor.Title);

            if (!string.IsNullOrEmpty(anchor.Text))
            {
                tag.SetInnerText(anchor.Text);
            }

            return tag;
        }

        private static TagBuilder BuildImageTag(SeoPack.Html.Image image)
        {
            var tag = new TagBuilder("img");
            tag.MergeAttribute("src", image.Src);
            tag.MergeAttribute("alt", image.AltText);

            if (image.Attributes != null)
            {
                foreach (var pair in DictionaryFromAnonymousObject(image.Attributes))
                {
                    tag.MergeAttribute(pair.Key, pair.Value);
                }
            }

            return tag;
        }

        private static IDictionary<string, string> DictionaryFromAnonymousObject(object o)
        {
            IDictionary<string, string> dic = new Dictionary<string, string>();
            var properties = o.GetType().GetProperties();
            foreach (PropertyInfo prop in properties)
            {
                dic.Add(prop.Name, prop.GetValue(o, null) as string);
            }
            return dic;
        }

        private static IHtmlString BuildCanonicalLink(string canonicalUrl)
        {
            var tag = new TagBuilder("link");
            tag.MergeAttribute("rel", "canonical");
            tag.MergeAttribute("href", canonicalUrl);

            return MvcHtmlString.Create(tag.ToString(TagRenderMode.SelfClosing));
        }

        #endregion
    }
}
