
namespace SeoPack.Helpers
{
    public interface IUrlSeoHelper
    {
        string CanonicalUrl();

        string ToSeoFriendlyUrl(string url);
    }
}
