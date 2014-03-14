
namespace Ets.SingleApi.Services.Payment
{

    /// <summary>
    /// 类名称：WechatPaymentData
    /// 命名空间：Ets.SingleApi.Services.Payment
    /// 类功能：支付请求参数类
    /// </summary>
    /// 创建者：孟祺宙 
    /// 创建日期：2014/3/14 18:20
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class WechatPaymentData : IPaymentData
    {
        /// <summary>
        /// 获取
        /// </summary>
        /// <value>
        /// The OrderId
        /// </value>
        /// 创建者：孟祺宙 创建日期：2014/3/14 18:21
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int OrderId { get; set; }

        /// <summary>
        /// 设置或取得支付金额
        /// </summary>
        /// <value>
        /// The Amount
        /// </value>
        /// 创建者：孟祺宙 
        /// 创建日期：2014/3/14 18:25
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public decimal Amount { get; set; }
    }
}
