
namespace SeoPack.Helpers
{
    public interface IUrlSeoHelper
    {
        string CanonicalUrl();

        string ToCanonicalUrl(string url);
    }
}
