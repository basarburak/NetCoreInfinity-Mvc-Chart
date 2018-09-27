namespace NetCoreInfinity.Mvc.Models
{
    public class HighChartsLine : BaseChartModel
    {
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string[] Categories { get; set; }
        public long[] Values { get; set; }
        public string ChartId { get; set; }
        public string LineTitle { get; set; }
        public string DataAdress { get; set; }
    }
}
