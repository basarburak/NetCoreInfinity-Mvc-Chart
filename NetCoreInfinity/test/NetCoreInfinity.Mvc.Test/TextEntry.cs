using Microsoft.AspNetCore.Razor.TagHelpers;

namespace NetCoreInfinity.Mvc.Test
{
    [HtmlTargetElement("text-entry")]
    public class TextEntryTagHelper : TagHelper
    {
        public bool Condition { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (!Condition)
            {
                output.SuppressOutput();
            }
        }
    }
}