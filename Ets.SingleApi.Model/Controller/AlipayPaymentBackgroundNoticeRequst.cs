using System.Collections.Generic;

namespace Ets.SingleApi.Model.Controller
{
    /// <summary>
    /// 类名称：AlipayPaymentBackgroundNoticeRequst
    /// 命名空间：Ets.SingleApi.Model.Controller
    /// 类功能：支付宝支付回调通知参数
    /// </summary>
    /// 创建者：王巍
    /// 创建日期：6/5/2014 9:16 AM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class AlipayPaymentBackgroundNoticeRequst : ApiRequst
    {
        public string Service { get; set; }
        public string Sign { get; set; }
        public string SecId { get; set; }
        public string V { get; set; }
        public string NotifyData { get; set; }
    }
}