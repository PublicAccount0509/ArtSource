using System.Collections.Generic;

namespace Ets.SingleApi.Model.Controller
{
    public class BaiDuLightStatisticsResult
    {
        public int appid { get; set; }
        public string date { get; set; }
        public string lostfields { get; set; }
        public List<BaiDuLightStatisticsOrderResult> orders { get; set; }
    }
}