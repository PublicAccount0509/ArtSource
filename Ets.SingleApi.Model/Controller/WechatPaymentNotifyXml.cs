

namespace Ets.SingleApi.Model.Controller
{
    using System;
    using System.Xml.Serialization;

    /// <summary>
    /// 类名称：用于接收支付后通知 Post
    /// 命名空间：Ets.WapNew.Model.Services.Payment
    /// 类功能：
    /// </summary>
    /// 创建者：孟祺宙 创建日期：2014/3/17 18:53
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    [Serializable]
    [XmlType("xml")]
    public class WechatPaymentNotifyXml
    {
        public string OpenId { get; set; }
        public string AppId { get; set; }
        public int IsSubscribe { get; set; }
        public long TimeStamp { get; set; }
        public string NonceStr { get; set; }
        public string AppSignature { get; set; }
        public string SignMethod { get; set; }

        override public string ToString()
        {
            string str = String.Empty;
            str = String.Concat(str, "OpenId = ", OpenId, "\r\n");
            str = String.Concat(str, "AppId = ", AppId, "\r\n");
            str = String.Concat(str, "IsSubscribe = ", IsSubscribe, "\r\n");
            str = String.Concat(str, "TimeStamp = ", TimeStamp, "\r\n");
            str = String.Concat(str, "NonceStr = ", NonceStr, "\r\n");
            str = String.Concat(str, "AppSignature = ", AppSignature, "\r\n");
            str = String.Concat(str, "SignMethod = ", SignMethod, "\r\n");
            return str;
        }
    }
}
