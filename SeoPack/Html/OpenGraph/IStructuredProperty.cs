
namespace SeoPack.Html.OpenGraph
{
    public interface IStructuredProperty
    {
        string Url { get; }
        string SecureUrl { get; set; }
        string Type { get; set; }
    }
}
