using SeoPack.Html;
using SeoPack.Html.OpenGraph.ObjectTypes.Standard;
using System.Collections.Generic;
using System.Web;

namespace SeoPack.Helpers
{
    public interface IHtmlSeoHelper
    {
        IHtmlString Title(string titl);

        IHtmlString MetaDescription(string metaDescription);

        IHtmlString Image(Image image);

        IHtmlString Anchor(Anchor anchor);

        IHtmlString ImageLink(ImageLink imageLink);

        IHtmlString CanonicalLinkIfRequired(string canonicalUrl);

        IHtmlString CanonicalLinkIfRequired();

        IHtmlString OpenGraph(Og og);

        IHtmlString PaginationLink(PaginationLink pagingLink);

        IHtmlString HrefLangLink(IEnumerable<HrefLangPage> hrefLangPages);
    }
}
