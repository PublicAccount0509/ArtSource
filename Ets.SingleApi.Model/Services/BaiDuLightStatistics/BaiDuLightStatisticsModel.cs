namespace Ets.SingleApi.Model.Services
{
    public class BaiDuLightStatisticsModel
    {
        public int total_count { get; set; }
        public int online_count { get; set; }
        public int offline_count { get; set; }
        public int pay_suc_count { get; set; }
        public int pay_fail_count { get; set; }
        public int online_pay_suc_count { get; set; }
        public int online_pay_fail_count { get; set; }
        public int offline_pay_suc_count { get; set; }
        public int offline_pay_fail_count { get; set; }

        public string pay_suc_incomes { get; set; }
        public string pay_fail_incomes { get; set; }
        public string online_pay_suc_incomes { get; set; }
        public string online_pay_fail_incomes { get; set; }
        public string offline_pay_suc_incomes { get; set; }
        public string offline_pay_fail_incomes { get; set; }
    }
}