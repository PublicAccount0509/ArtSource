
namespace Ets.SingleApi.Services.Payment
{
    /// <summary>
    /// 类名称：AlipayPaymentDataQr
    /// 命名空间：Ets.SingleApi.Services.Payment
    /// 类功能：支付宝二维码支付
    /// </summary>
    /// 创建者：黄磊 
    /// 创建日期：2014/10/27 14:13
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class AlipayPaymentDataQr : IPaymentData
    {

        /// <summary>
        /// Gets or sets the Productid of WechatPaymentDataQr
        /// </summary>
        /// <value>
        /// The Productid
        /// </value>
        /// 创建者：黄磊 
        /// 创建日期：2014/10/27 14:13
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string Productid { get; set; }

        /// <summary>
        /// 用户应付金额
        /// </summary>
        /// <value>
        /// The CustomerTotal
        /// </value>
        /// 创建者：黄磊 
        /// 创建日期：2014/10/30 16:05
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public decimal CustomerTotal { get; set; }

        /// <summary>
        /// 设备号或者MAC地址
        /// </summary>
        /// <value>
        /// The DeviceNumber
        /// </value>
        /// 创建者：黄磊 
        /// 创建日期：2014/10/28 13:13
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string DeviceNumber { get; set; }

    }
}
