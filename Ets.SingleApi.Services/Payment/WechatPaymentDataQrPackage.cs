
namespace Ets.SingleApi.Services.Payment
{
    /// <summary>
    /// 类名称：WechatPaymentDataQrPackage
    /// 命名空间：Ets.SingleApi.Services.Payment
    /// 类功能：
    /// </summary>
    /// 创建者：孟祺宙
    /// 创建日期：2014/8/6 10:41
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class WechatPaymentDataQrPackage : IPaymentData
    {

        /// <summary>
        /// Gets or sets the OpenId of WechatPaymentRequestQrPackage
        /// </summary>
        /// <value>
        /// The OpenId
        /// </value>
        /// 创建者：孟祺宙 
        /// 创建日期：2014/8/6 9:48
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string OpenId { get; set; }

        /// <summary>
        /// Gets or sets the AppId of WechatPaymentRequestQrPackage
        /// </summary>
        /// <value>
        /// The AppId
        /// </value>
        /// 创建者：孟祺宙 
        /// 创建日期：2014/8/6 9:48
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string AppId { get; set; }

        /// <summary>
        /// Gets or sets the IsSubscribe of WechatPaymentRequestQrPackage
        /// </summary>
        /// <value>
        /// The IsSubscribe
        /// </value>
        /// 创建者：孟祺宙 
        /// 创建日期：2014/8/6 9:51
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string IsSubscribe { get; set; }

        /// <summary>
        /// Gets or sets the ProductId of WechatPaymentRequestQrPackage
        /// </summary>
        /// <value>
        /// The ProductId
        /// </value>
        /// 创建者：孟祺宙 
        /// 创建日期：2014/8/6 9:51
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string ProductId { get; set; }

        /// <summary>
        /// Gets or sets the TimeStamp of WechatPaymentRequestQrPackage
        /// </summary>
        /// <value>
        /// The TimeStamp
        /// </value>
        /// 创建者：孟祺宙 
        /// 创建日期：2014/8/6 9:51
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string TimeStamp { get; set; }

        /// <summary>
        /// Gets or sets the NonceStr of WechatPaymentRequestQrPackage
        /// </summary>
        /// <value>
        /// The NonceStr
        /// </value>
        /// 创建者：孟祺宙 
        /// 创建日期：2014/8/6 9:51
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string NonceStr { get; set; }

        /// <summary>
        /// Gets or sets the AppSignature of WechatPaymentRequestQrPackage
        /// </summary>
        /// <value>
        /// The AppSignature
        /// </value>
        /// 创建者：孟祺宙 
        /// 创建日期：2014/8/6 9:52
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string AppSignature { get; set; }

        /// <summary>
        /// Gets or sets the SignMethod of WechatPaymentRequestQrPackage
        /// </summary>
        /// <value>
        /// The SignMethod
        /// </value>
        /// 创建者：孟祺宙 
        /// 创建日期：2014/8/6 9:52
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string SignMethod { get; set; }

        /// <summary>
        /// Gets or sets the SpbillCreateIp of WechatPaymentDataQrPackage
        /// </summary>
        /// <value>
        /// The SpbillCreateIp
        /// </value>
        /// 创建者：孟祺宙 
        /// 创建日期：2014/8/6 15:46
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string SpbillCreateIp { get; set; }

        /// <summary>
        /// Gets or sets the TotalFee of WechatPaymentDataQrPackage
        /// </summary>
        /// <value>
        /// The TotalFee
        /// </value>
        /// 创建者：孟祺宙 
        /// 创建日期：2014/8/6 15:46
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public decimal TotalFee { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether
        /// </summary>
        /// <value>
        /// The IsConfirm
        /// </value>
        /// 创建者：孟祺宙 
        /// 创建日期：2014/8/6 15:46
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public bool IsConfirm { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether
        /// </summary>
        /// <value>
        /// The IsPaid
        /// </value>
        /// 创建者：孟祺宙 
        /// 创建日期：2014/8/6 17:43
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public bool IsPaid { get; set; }

        /// <summary>
        /// 订单类型：0 外卖，1 堂食，2 订台
        /// </summary>
        /// <value>
        /// The OrderType
        /// </value>
        /// 创建者：孟祺宙 
        /// 创建日期：2014/8/7 10:23
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int OrderType { get; set; }
    }
}
