namespace Ets.SingleApi.Services.Payment
{
    /// <summary>
    /// 类名称：BaiFuBaoPaymentQueryData
    /// 命名空间：Ets.SingleApi.Services.Payment
    /// 类功能：百付宝查询订单支付状态
    /// </summary>
    /// 创建者：王巍
    /// 创建日期：2/14/2014 2:47 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class BaiFuBaoPaymentQueryData : IPaymentData
    {
        public int OrderId { get; set; }
    }
}
