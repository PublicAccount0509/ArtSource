namespace Ets.SingleApi.Controllers.IServices
{
    using Ets.SingleApi.Model;
    using Ets.SingleApi.Model.Services;

    /// <summary>
    /// 接口名称：IOrderServices
    /// 命名空间：Ets.SingleApi.Controllers.IServices
    /// 接口功能：订单功能
    /// </summary>
    /// 创建者：周超
    /// 创建日期：10/22/2013 6:05 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public interface IOrderServices
    {
        /// <summary>
        /// 取得订单是否存在以及支付支付状态
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="orderId">订单状态</param>
        /// <param name="orderType">订单类型：0 外卖，1 堂食，2 订台</param>
        /// <param name="orderSourceType">订单来源：0 默认类型，1 海底捞；默认为 0</param>
        /// <returns>
        /// 返回结果 0 不存在 1 支付 2 未支付
        /// </returns>
        /// 创建者：周超
        /// 创建日期：10/23/2013 9:26 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResult<int> Exist(string source, int orderId, int orderType, int orderSourceType);

        /// <summary>
        /// 取得订单详情
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="orderId">订单号</param>
        /// <param name="orderType">订单类型：0 外卖，1 堂食，2 订台</param>
        /// <param name="orderSourceType">订单来源：0 默认类型，1 海底捞；默认为 0</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：10/23/2013 9:26 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResult<IOrderDetailModel> GetOrder(string source, int orderId, int orderType, int orderSourceType);

        /// <summary>
        /// 保存订单信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="shoppingCartId">购物车Id</param>
        /// <param name="orderType">订单类型：0 外卖，1 堂食，2 订台</param>
        /// <param name="orderSourceType">订单来源：0 默认类型，1 海底捞；默认为 0</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/20 16:01
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResult<string> SaveOrder(string source, string shoppingCartId, int orderType, int orderSourceType);

        /// <summary>
        /// 获取订单号
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="orderType">订单类型：0 外卖，1 堂食，2 订台</param>
        /// <param name="orderSourceType">订单来源：0 默认类型，1 海底捞；默认为 0</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：10/31/2013 9:01 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResult<string> GetOrderNumber(string source, int orderType, int orderSourceType);

        /// <summary>
        /// 更改支付状态
        /// </summary>
        /// <param name="source">The sourceDefault documentation</param>
        /// <param name="orderType">Type of the order.</param>
        /// <param name="orderSourceType">Type of the order source.</param>
        /// <param name="orderId">The orderIdDefault documentation</param>
        /// <param name="isPaId">The  isPaId indicates whether</param>
        /// <returns>
        /// Boolean}
        /// </returns>
        /// 创建者：王巍
        /// 创建日期：1/26/2014 10:54 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResult<bool> SaveOrderPaId(string source, int orderType, int orderSourceType, int orderId, bool isPaId);

        /// <summary>
        /// 是否可以激活购物车信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="orderType">Type of the order.</param>
        /// <param name="orderSourceType">Type of the order source.</param>
        /// <param name="orderId">The orderId</param>
        /// <returns></returns>
        /// 创建者：单琪彬
        /// 创建日期：2/13/2014 3:59 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResult<bool> IsActivation(string source, int orderType, int orderSourceType, int orderId);
    }
}