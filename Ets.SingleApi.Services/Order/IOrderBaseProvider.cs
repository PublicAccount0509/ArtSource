namespace Ets.SingleApi.Services
{
    using Ets.SingleApi.Model;
    using Ets.SingleApi.Model.Services;

    /// <summary>
    /// 接口名称：IOrderBaseProvider
    /// 命名空间：Ets.SingleApi.Services
    /// 接口功能：提供订单基本信息
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2/28/2014 3:20 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public interface IOrderBaseProvider
    {
        /// <summary>
        /// 取得订单类型
        /// </summary>
        /// <value>
        /// 订单类型
        /// </value>
        /// 创建者：周超
        /// 创建日期：2/28/2014 3:26 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        OrderType OrderType { get; }

        /// <summary>
        /// 取得一个订单号
        /// </summary>
        /// <param name="source">应用来源</param>
        /// <returns>
        /// 订单号
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2/28/2014 3:26 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResult<string> GetOrderNumber(string source);

        /// <summary>
        /// 取得订单是否存在以及支付支付状态
        /// </summary>
        /// <param name="source">应用来源</param>
        /// <param name="orderId">订单状态</param>
        /// <returns>
        /// 返回结果 0 不存在 1 支付 2 未支付
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2/28/2014 3:26 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResult<int> Exist(string source, int orderId);

        /// <summary>
        /// 保存支付状态
        /// </summary>
        /// <param name="source">应用来源</param>
        /// <param name="orderId">订单号</param>
        /// <param name="isPaid">支付状态</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2/28/2014 3:26 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResult<bool> SaveOrderPaid(string source, int orderId, bool isPaid);

        /// <summary>
        /// 保存订单的支付方式
        /// </summary>
        /// <param name="source">应用来源</param>
        /// <param name="orderId">订单号</param>
        /// <param name="paymentMethodId">支付方式</param>
        /// <param name="payBank">备注</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2/28/2014 3:26 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResult<bool> SaveOrderPaymentMethod(string source, int orderId, int paymentMethodId, string payBank);

        /// <summary>
        /// 当前订单是否可以修改
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="orderId">The orderId</param>
        /// <returns>
        /// 返回结果，空字串可以修改；否则，不可修改。
        /// </returns>
        /// 创建者：单琪彬
        /// 创建日期：2/13/2014 11:55 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResult<string> GetOrderEditFlag(string source, int orderId);

        /// <summary>
        /// 取消订单
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="orderId">The orderId</param>
        /// <returns>
        /// 返回结果，true取消成功；false取消失败。
        /// </returns>
        /// 创建者：周超
        /// 创建日期：3/15/2014 2:00 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResult<bool> CancelOrder(string source, int orderId);

        /// <summary>
        /// 保存百付宝优惠支付返回，支付现金金额，优惠金额，立减金额，所有单位为“分”
        /// </summary>
        /// <param name="source">The sourceDefault documentation</param>
        /// <param name="orderId">订单号</param>
        /// <param name="paidAmount">支付现金金额 单位:分</param>
        /// <param name="coupons">优惠金额 单位:分</param>
        /// <param name="promotion">立减金额 单位:分</param>
        /// <returns>
        /// Boolean}
        /// </returns>
        /// 创建者：王巍
        /// 创建日期：6/26/2014 9:21 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResult<bool> SavDeliveryBaiFuBaoCoupon(string source, int orderId, string paidAmount, string coupons, string promotion);
    }
}