﻿
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
        /// 商品描述。参数长度：128 字节以下
        /// </summary>
        /// <value>
        /// The Body
        /// </value>
        /// 创建者：孟祺宙 创建日期：2014/3/14 20:20
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string Body { get; set; }

        /// <summary>
        /// 附加数据，原样返回。128 字节以下
        /// </summary>
        /// <value>
        /// The Attach
        /// </value>
        /// 创建者：孟祺宙 创建日期：2014/3/14 20:22
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string Attach { get; set; }

        /// <summary>
        /// 微信OpenId
        /// </summary>
        /// <value>
        /// The WechatId
        /// </value>
        /// 创建者：孟祺宙 创建日期：2014/3/14 20:19
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string WechatId { get; set; }

        /// <summary>
        /// 内部订单号
        /// </summary>
        /// <value>
        /// The OrderId
        /// </value>
        /// 创建者：孟祺宙 创建日期：2014/3/14 18:21
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string OrderId { get; set; }

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

        /// <summary>
        /// 设置或取得回调地址
        /// </summary>
        /// <value>
        /// 回调地址
        /// </value>
        /// 创建者：孟祺宙 
        /// 创建日期：2014/3/14 19:58
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string NotifyUrl { get; set; }

        /// <summary>
        /// 订单生成的机器 IP，指用户浏览器端 IP，不是商户服务器IP，格式为 IPV4 整型。（15 字节以内）
        /// </summary>
        /// <value>
        /// The SpbillCreateIp
        /// </value>
        /// 创建者：孟祺宙 创建日期：2014/3/14 20:23
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string SpbillCreateIp { get; set; }


    }
}
