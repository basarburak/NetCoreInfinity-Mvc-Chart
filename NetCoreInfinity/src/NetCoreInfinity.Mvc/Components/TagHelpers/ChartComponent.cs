using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using NetCoreInfinity.Mvc.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace NetCoreInfinity.Mvc.Components.TagHelpers
{
    [HtmlTargetElement("netcoreinfinity-chart")]
    public class ChartComponent : TagHelper
    {
        private readonly IHtmlHelper _helper;

        public ChartComponent(IHtmlHelper helper)
        {
            _helper = helper;
        }

        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string ChartId { get; set; }
        public string LineTitle { get; set; }
        public bool MockData { get; set; }
        public string Data { get; set; }

        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            (_helper as IViewContextAware).Contextualize(ViewContext);
            output.TagName = "div";
            output.TagMode = TagMode.StartTagAndEndTag;

            var viewModel = new HighChartsLine();

            if (MockData)
            {
                viewModel.Categories = new string[] { "Ocak", "Subat", "Mart" };
                viewModel.Values = new long[] { 10, 45, 68 };
            }
            else
            {
                //using (var httpClient = new HttpClient())
                //{
                //    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //    var response = await httpClient.GetAsync(Data);
                //    string jsonResult = await response.Content.ReadAsStringAsync();
                //}
            }

            viewModel.ChartId = ChartId;
            viewModel.Title = Title;
            viewModel.LineTitle = LineTitle;
            viewModel.SubTitle = SubTitle;
            viewModel.DataAdress = Data;

            var partialView = "~/Views/_ChartComponent.cshtml";
            var content = await _helper.PartialAsync(partialView, viewModel);
            output.Content.SetHtmlContent(content);
        }
    }
}