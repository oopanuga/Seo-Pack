using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace SeoPack.Html.OpenGraph
{
    /// <summary>
    /// Represents a class that serializes an open graph object to Html.
    /// </summary>
    public class OgHtmlSerializer : OgSerializerBase<IHtmlString>
    {
        /// <summary>
        /// Serializes the supplied open graph object to Html.
        /// </summary>
        /// <param name="properties">A dictionary of open graph properties.</param>
        /// <returns>The html string.</returns>
        protected override IHtmlString Serialize(IEnumerable<OgProperty> properties)
        {
            var tagString = new StringBuilder();

            foreach (var property in properties)
            {
                tagString.Append(BuildOpenGraphTag(property.Name, property.Value));
            }

            return MvcHtmlString.Create(tagString.ToString());
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
