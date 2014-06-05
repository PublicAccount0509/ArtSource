namespace Ets.SingleApi.Services.Payment
{
    using System.Collections.Generic;

    /// <summary>
    /// 类名称：AlipayPaymentBackgroundNoticeData
    /// 命名空间：Ets.SingleApi.Services.Payment
    /// 类功能：支付宝支付后台回调请求参数
    /// </summary>
    /// 创建者：王巍
    /// 创建日期：6/5/2014 9:26 AM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class AlipayPaymentBackgroundNoticeData : IPaymentData
    {
        public Dictionary<string, string> Request { get; set; }

        public string Sign { get; set; }
    }
}
