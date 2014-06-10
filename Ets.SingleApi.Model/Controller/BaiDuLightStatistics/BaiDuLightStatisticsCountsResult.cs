namespace Ets.SingleApi.Model.Controller
{
    public class BaiDuLightStatisticsCountsResult
    {
        public int total_count { get; set; }
        public int online_count { get; set; }
        public int offline_count { get; set; }
        public int pay_suc_count { get; set; }
        public int pay_discount_suc_count { get; set; }
        public int pay_coupon_suc_count { get; set; }
        public int pay_fail_count { get; set; }
        public int pay_discount_fail_count { get; set; }
        public int pay_coupon_fail_count { get; set; }
        public int online_pay_suc_count { get; set; }
        public int online_pay_discount_suc_count { get; set; }
        public int online_pay_coupon_suc_count { get; set; }
        public int online_pay_fail_count { get; set; }
        public int online_pay_discount_fail_count { get; set; }
        public int online_pay_coupon_fail_count { get; set; }
        public int offline_pay_suc_count { get; set; }
        public int offline_pay_discount_suc_count { get; set; }
        public int offline_pay_coupon_suc_count { get; set; }
        public int offline_pay_fail_count { get; set; }
        public int offline_pay_discount_fail_count { get; set; }
        public int offline_pay_coupon_fail_count { get; set; }
    }
}