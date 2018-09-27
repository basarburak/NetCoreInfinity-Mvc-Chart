using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace NetCoreInfinity.Mvc.Components.TagHelpers
{
    [HtmlTargetElement("netcoreinfinity-chart-script")]
    public class ChartScript : TagHelper
    {
        private readonly IHtmlHelper _helper;

        public ChartScript(IHtmlHelper helper)
        {
            _helper = helper;
        }

        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            (_helper as IViewContextAware).Contextualize(ViewContext);
            output.TagName = "div";
            output.TagMode = TagMode.StartTagAndEndTag;

            var partialView = "~/Views/_ChartScript.cshtml";
            var content = await _helper.PartialAsync(partialView);
            output.Content.SetHtmlContent(content);
        }
    }
}
