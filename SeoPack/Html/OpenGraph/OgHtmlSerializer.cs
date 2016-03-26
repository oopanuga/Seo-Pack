using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace SeoPack.Html.OpenGraph
{
    public class OgHtmlSerializer : OgSerializerBase<IHtmlString>
    {
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
            var tagBuilder = new TagBuilder("meta");
            tagBuilder.MergeAttribute("property", propertyName.ToLower());
            tagBuilder.MergeAttribute("content", content.ToLower());
            return tagBuilder.ToString(TagRenderMode.SelfClosing);
        }
    }
}
