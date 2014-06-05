namespace Ets.SingleApi.Model.Controller
{
    using System.Collections.Generic;

    /// <summary>
    /// 类名称：AlipayPaymentVerifyRequst
    /// 命名空间：Ets.SingleApi.Model.Controller
    /// 类功能：支付宝支付后台回调验证签名参数
    /// </summary>
    /// 创建者：王巍
    /// 创建日期：6/4/2014 5:44 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class AlipayPaymentVerifyRequst : ApiRequst
    {
        /// <summary>
        /// 参数
        /// </summary>
        /// <value>
        /// The UserId
        /// </value>
        /// 创建者：王巍
        /// 创建日期：3/2/2014 3:30 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public Dictionary<string, string> Parameter { get; set; }

        /// <summary>
        /// 签名
        /// </summary>
        /// <value>
        /// The Sign
        /// </value>
        /// 创建者：王巍
        /// 创建日期：6/4/2014 5:45 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string Sign { get; set; }
    }
}