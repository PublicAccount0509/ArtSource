namespace Ets.SingleApi.Controllers.IServices
{
    using Ets.SingleApi.Model.Services;

    /// <summary>
    /// 接口名称：IDirectPayServices
    /// 命名空间：Ets.SingleApi.Controllers.IServices
    /// 接口功能：当面付
    /// </summary>
    /// 创建者：王巍
    /// 创建日期：4/30/2014 9:11 AM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public interface IDirectPayServices
    {
        /// <summary>
        /// 获取当面付订单列表
        /// </summary>
        /// <param name="source">The sourceDefault documentation</param>
        /// <param name="getDirectPayOrderListParameter">The parameterDefault documentation</param>
        /// <returns>
        /// ServicesResultList{QueueDeskModel}
        /// </returns>
        /// 创建者：王巍
        /// 创建日期：4/30/2014 10:17 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResultList<DirectPayModel> GetOrderList(string source, GetDirectPayOrderListParameter getDirectPayOrderListParameter);

        /// <summary>
        /// 获取当面付订单明细
        /// </summary>
        /// <param name="source">The sourceDefault documentation</param>
        /// <param name="orderNumber">The directPayIdDefault documentation</param>
        /// <returns>
        /// ServicesResult{DirectPayModel}
        /// </returns>
        /// 创建者：王巍
        /// 创建日期：4/30/2014 10:54 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResult<DirectPayModel> GetOrderDetail(string source, int orderNumber);

        /// <summary>
        /// 创建当面付订单
        /// </summary>
        /// <param name="source">The sourceDefault documentation</param>
        /// <param name="appKey">The appKeyDefault documentation</param>
        /// <param name="appPassword">The appPasswordDefault documentation</param>
        /// <param name="saveDirectPayParameter">The parameterDefault documentation</param>
        /// <returns>
        /// 当面付订单号
        /// </returns>
        /// 创建者：王巍
        /// 创建日期：4/30/2014 10:39 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResult<string> CreateOrder(string source, string appKey, string appPassword, SaveDirectPayParameter saveDirectPayParameter);

        /// <summary>
        /// 检查手机号支付次数是否超过上限
        /// </summary>
        /// <param name="source">The sourceDefault documentation</param>
        /// <param name="telephone">The telephoneDefault documentation</param>
        /// <param name="upperLimit">The upperLimitDefault documentation</param>
        /// <returns>
        /// True 超过上限；False 没有超过上限
        /// </returns>
        /// 创建者：王巍
        /// 创建日期：4/30/2014 10:51 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResult<bool> CheckTelePhonePayMoreThanUpperLimit(string source, string telephone, int upperLimit);

        /// <summary>
        /// 取消当面付订单
        /// </summary>
        /// <param name="source">The sourceDefault documentation</param>
        /// <param name="parameter">当面付订单Id</param>
        /// <returns>
        /// Boolean}
        /// </returns>
        /// 创建者：王巍
        /// 创建日期：5/6/2014 8:54 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResult<bool> CancelDirectPay(string source, CancelDirectPayParameter parameter);
    }
}