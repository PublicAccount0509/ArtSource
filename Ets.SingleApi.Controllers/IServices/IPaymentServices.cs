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
    }
}