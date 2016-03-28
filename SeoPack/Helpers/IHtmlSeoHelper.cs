using SeoPack.Html;
using SeoPack.Html.OpenGraph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace SeoPack.Helpers
{
    public interface IHtmlSeoHelper
    {
        IHtmlString Title(string title, bool validateLength = false);

        IHtmlString MetaDescription(string metaDescription, bool validateLength = false);

        IHtmlString Image(SeoPack.Html.Image image);

        IHtmlString Anchor(Anchor anchor);

        IHtmlString ImageLink(ImageLink imageLink);

        IHtmlString CanonicalLink(string canonicalUrl);

        IHtmlString CanonicalLink();

        IHtmlString OpenGraph(Og og);

        IHtmlString PagingLink(PagingLink pagingLink);

        IHtmlString HrefLangLink(List<HrefLangLink> hrefLangLinks);
    }
}
