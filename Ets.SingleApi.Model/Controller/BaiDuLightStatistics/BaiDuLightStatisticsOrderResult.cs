namespace Ets.SingleApi.Model.Controller
{
    public class BaiDuLightStatisticsOrderResult
    {
        public string bd_ref_id { get; set; }
        public string bd_from_id { get; set; }
        public string bd_channel_id { get; set; }
        public string bd_subpage { get; set; }
        public BaiDuLightStatisticsCountsResult counts { get; set; }
        public BaiDuLightStatisticsIncomesResult incomes { get; set; }

    }
}