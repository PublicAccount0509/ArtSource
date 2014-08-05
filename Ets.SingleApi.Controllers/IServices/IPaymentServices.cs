using Ets.SingleApi.Model.Controller;

namespace Ets.SingleApi.Controllers.IServices
{
    using Ets.SingleApi.Model.Services;

    /// <summary>
    /// 接口名称：IPaymentServices
    /// 命名空间：Ets.SingleApi.Controllers.IServices
    /// 接口功能：支付功能
    /// </summary>
    /// 创建者：周超
    /// 创建日期：10/28/2013 3:23 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public interface IPaymentServices
    {
        /// <summary>
        /// 支付功能
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="parameter">The parameter</param>
        /// <returns>
        /// 返回支付交易号
        /// </returns>
        /// 创建者：周超
        /// 创建日期：10/28/2013 3:23 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResult<string> UmPayment(string source, UmPaymentParameter parameter);

        /// <summary>
        /// 支付状态
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="parameter">The parameter</param>
        /// <returns>
        /// 返回支付状态
        /// </returns>
        /// 创建者：周超
        /// 创建日期：10/29/2013 4:17 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResult<bool> UmPaymentState(string source, UmPaymentStateParameter parameter);

        /// <summary>
        /// 获取百付宝支付请求Url
        /// </summary>
        /// <param name="source">The sourceDefault documentation</param>
        /// <param name="parameter">The parameterDefault documentation</param>
        /// <returns>
        /// 百付宝支付请求Url
        /// </returns>
        /// 创建者：王巍
        /// 创建日期：2/14/2014 9:55 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResult<string> BaiFuBaoPayment(string source, BaiFuBaoPaymentParameter parameter);

        /// <summary>
        /// 百付宝支付状态
        /// </summary>
        /// <param name="source">The sourceDefault documentation</param>
        /// <param name="parameter">The parameterDefault documentation</param>
        /// <returns>
        /// The Boolean}
        /// </returns>
        /// 创建者：王巍
        /// 创建日期：2/11/2014 1:46 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResult<bool> BaiFuBaoPaymentState(string source, BaiFuBaoPaymentStateParameter parameter);

        /// <summary>
        /// 百付宝支付后台回调验证签名
        /// </summary>
        /// <param name="source">The sourceDefault documentation</param>
        /// <param name="parameter">The parameterDefault documentation</param>
        /// <returns>
        /// Boolean}
        /// </returns>
        /// 创建者：王巍
        /// 创建日期：6/4/2014 4:03 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResult<bool> BaiFuBaoPaymentVerify(string source, BaiFuBaoReturnParameter parameter);

        /// <summary>
        /// 获取支付宝支付请求Url
        /// </summary>
        /// <param name="source">The sourceDefault documentation</param>
        /// <param name="parameter">The parameterDefault documentation</param>
        /// <returns>
        /// 百付宝支付请求Url
        /// </returns>
        /// 创建者：王巍
        /// 创建日期：2/14/2014 9:55 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResult<string> AlipayPayment(string source, AlipayPaymentParameter parameter);

        /// <summary>
        /// 支付宝支付状态
        /// </summary>
        /// <param name="source">The sourceDefault documentation</param>
        /// <param name="parameter">The parameterDefault documentation</param>
        /// <returns>
        /// The Boolean}
        /// </returns>
        /// 创建者：王巍
        /// 创建日期：2/11/2014 1:46 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResult<bool> AlipayPaymentState(string source, AlipayPaymentStateParameter parameter);

        /// <summary>
        /// 百付宝支付后台回调验证签名
        /// </summary>
        /// <param name="source">The sourceDefault documentation</param>
        /// <param name="parameter">The parameterDefault documentation</param>
        /// <returns>
        /// Boolean}
        /// </returns>
        /// 创建者：王巍
        /// 创建日期：6/4/2014 6:00 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResult<bool> AlipayPaymentVerify(string source, AlipayPaymentReturnParameter parameter);

        ///// <summary>
        ///// 获取新浪微博支付请求Url
        ///// </summary>
        ///// <param name="source">The sourceDefault documentation</param>
        ///// <param name="parameter">The parameterDefault documentation</param>
        ///// <returns>
        ///// 新浪微博支付请求Url
        ///// </returns>
        ///// 创建者：王巍
        ///// 创建日期：2/14/2014 9:55 AM
        ///// 修改者：
        ///// 修改时间：
        ///// ----------------------------------------------------------------------------------------
        //ServicesResult<string> SinaWeiBoPayment(string source, SinaWeiBoPaymentParameter parameter);

        ///// <summary>
        ///// 新浪微博支付状态
        ///// </summary>
        ///// <param name="source">The sourceDefault documentation</param>
        ///// <param name="parameter">The parameterDefault documentation</param>
        ///// <returns>
        ///// The Boolean}
        ///// </returns>
        ///// 创建者：王巍
        ///// 创建日期：2/11/2014 1:46 PM
        ///// 修改者：
        ///// 修改时间：
        ///// ----------------------------------------------------------------------------------------
        //ServicesResult<bool> SinaWeiBoPaymentState(string source, SinaWeiBoPaymentStateParameter parameter);


        /// <summary>
        ///微信支付请求JSON参数
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="parameter">The parameter</param>
        /// <returns>
        /// String}
        /// </returns>
        /// 创建者：孟祺宙 
        /// 创建日期：2014/3/17 10:40
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResult<string> WechatPayment(string source, WechatPaymentParameter parameter);

        /// <summary>
        /// 微信支付状态
        /// </summary>
        /// <param name="source">The sourceDefault documentation</param>
        /// <param name="parameter">The parameterDefault documentation</param>
        /// <returns>
        /// The Boolean}
        /// </returns>
        /// 创建者：孟祺宙
        /// 创建日期：3/10/2014 5:58 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResult<bool> WeChatPaymentState(string source, WechatPaymentStateParameter parameter);

        /// <summary>
        /// 微信外卖支付回调通知
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="parameter">The parameter</param>
        /// <returns>
        /// Boolean}
        /// </returns>
        /// 创建者：孟祺宙 创建日期：2014/3/19 15:16
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResult<bool> WechatPaymentDeliveryNotify(string source, WechatPaymentStateParameter parameter);

        /// <summary>
        /// 微信二维码支付
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="parameter">The parameter</param>
        /// <returns>
        /// String}
        /// </returns>
        /// 创建者：孟祺宙 
        /// 创建日期：2014/8/5 16:57
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResult<string> WechatPaymentQr(string source, WechatPaymentParameterQr parameter);

    }
}