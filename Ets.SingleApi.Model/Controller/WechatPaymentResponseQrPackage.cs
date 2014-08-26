
namespace Ets.SingleApi.Model.Controller
{
    using System.Xml;
    using System.Xml.Serialization;

    /// <summary>
    /// 类名称：WechatPaymentResponseQrPackage
    /// 命名空间：Ets.SingleApi.Model.Controller
    /// 类功能：
    /// </summary>
    /// 创建者：孟祺宙 
    /// 创建日期：2014/8/6 14:58
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    [XmlRoot(ElementName = "xml")]
    public class WechatPaymentResponseQrPackage
    {
        /// <summary>
        /// Gets or sets the AppId of WechatPaymentResponseQrPackage
        /// </summary>
        /// <value>
        /// The AppId
        /// </value>
        /// 创建者：孟祺宙 
        /// 创建日期：2014/8/6 14:59
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public XmlCDataSection AppId { get; set; }

        /// <summary>
        /// Gets or sets the NonceStr of WechatPaymentResponseQrPackage
        /// </summary>
        /// <value>
        /// The NonceStr
        /// </value>
        /// 创建者：孟祺宙 
        /// 创建日期：2014/8/6 14:59
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public XmlCDataSection NonceStr { get; set; }


        /// <summary>
        /// Gets or sets the TimeStamp of WechatPaymentResponseQrPackage
        /// </summary>
        /// <value>
        /// The TimeStamp
        /// </value>
        /// 创建者：孟祺宙 
        /// 创建日期：2014/8/6 14:59
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string TimeStamp { get; set; }

        /// <summary>
        /// Gets or sets the Package of WechatPaymentResponseQrPackage
        /// </summary>
        /// <value>
        /// The Package
        /// </value>
        /// 创建者：孟祺宙 
        /// 创建日期：2014/8/6 14:59
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public XmlCDataSection Package { get; set; }

        /// <summary>
        /// Gets or sets the RetCode of WechatPaymentResponseQrPackage
        /// </summary>
        /// <value>
        /// The RetCode
        /// </value>
        /// 创建者：孟祺宙 
        /// 创建日期：2014/8/6 14:59
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int RetCode { get; set; }

        /// <summary>
        /// Gets or sets the RetErrMsg of WechatPaymentResponseQrPackage
        /// </summary>
        /// <value>
        /// The RetErrMsg
        /// </value>
        /// 创建者：孟祺宙 
        /// 创建日期：2014/8/6 14:59
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public XmlCDataSection RetErrMsg { get; set; }

        /// <summary>
        /// Gets or sets the SignMethod of WechatPaymentResponseQrPackage
        /// </summary>
        /// <value>
        /// The SignMethod
        /// </value>
        /// 创建者：孟祺宙 
        /// 创建日期：2014/8/6 15:00
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public XmlCDataSection SignMethod { get; set; }

        /// <summary>
        /// Gets or sets the AppSignature of WechatPaymentResponseQrPackage
        /// </summary>
        /// <value>
        /// The AppSignature
        /// </value>
        /// 创建者：孟祺宙 
        /// 创建日期：2014/8/6 15:00
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public XmlCDataSection AppSignature { get; set; }
    }
}
