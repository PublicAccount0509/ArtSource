
namespace Ets.SingleApi.Model.Controller
{
    using System.Xml;
    using System.Xml.Serialization;

    /// <summary>
    /// 类名称：WechatPaymentRequestQrPackage
    /// 命名空间：Ets.SingleApi.Model.Controller
    /// 类功能：
    /// </summary>
    /// 创建者：孟祺宙 
    /// 创建日期：2014/8/6 9:48
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    [XmlRoot(ElementName = "xml")]
    public class WechatPaymentRequestQrPackage
    {

        /// <summary>
        /// Gets or sets the OpenId of WechatPaymentRequestQrPackage
        /// </summary>
        /// <value>
        /// The OpenId
        /// </value>
        /// 创建者：孟祺宙 
        /// 创建日期：2014/8/6 15:04
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public XmlCDataSection OpenId { get; set; }

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
        public XmlCDataSection AppId { get; set; }

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
        public XmlCDataSection ProductId { get; set; }

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
        public XmlCDataSection NonceStr { get; set; }

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
        public XmlCDataSection AppSignature { get; set; }

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
        public XmlCDataSection SignMethod { get; set; }
    }
}
