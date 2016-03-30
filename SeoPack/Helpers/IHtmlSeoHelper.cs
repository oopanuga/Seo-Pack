using SeoPack.Html;
using SeoPack.Html.OpenGraph;
using System.Collections.Generic;
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

        IHtmlString CanonicalLinkIfRequired(string canonicalUrl);

        IHtmlString CanonicalLinkIfRequired();

        IHtmlString OpenGraph(Og og);

        IHtmlString PaginationLink(PaginationLink pagingLink);

        IHtmlString HrefLangLink(IEnumerable<HrefLangPage> hrefLangPages);
    }
}
