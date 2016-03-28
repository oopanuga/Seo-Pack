using SeoPack.Html;
using SeoPack.Html.OpenGraph;
using System.Collections.Generic;
using System.Text;

namespace SeoPack.Tests.Html.OpenGraph
{
    public class OgTestSerializer : OgSerializerBase<string>
    {
        protected override string Serialize(IEnumerable<OgProperty> properties)
        {
            var tagString = new StringBuilder();

            foreach (var property in properties)
            {
                tagString.Append(BuildOpenGraphTag(property.Name, property.Value));
            }

            return tagString.ToString();
        }

        private string BuildOpenGraphTag(string propertyName, string content)
        {
            var htmlElement = new HtmlElement("meta");
            htmlElement.AddAttribute("property", propertyName.ToLower());
            htmlElement.AddAttribute("content", content);
            return htmlElement.ToString();
        }
    }
}
