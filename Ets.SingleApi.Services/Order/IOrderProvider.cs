namespace Ets.SingleApi.Services
{
    using Ets.SingleApi.Model;
    using Ets.SingleApi.Model.Services;

    /// <summary>
    /// 接口名称：IOrderProvider
    /// 命名空间：Ets.SingleApi.Services
    /// 接口功能：订单添加
    /// </summary>
    /// 创建者：周超
    /// 创建日期：11/22/2013 3:23 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public interface IOrderProvider
    {
        /// <summary>
        /// 取得订单类型
        /// </summary>
        /// <value>
        /// 订单类型
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/20 16:01
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        OrderType OrderType { get; }

        /// <summary>
        /// 保存订单信息
        /// </summary>
        /// <param name="shoppingCartId">购物车Id</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/20 16:01
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResult<string> SaveOrder(string shoppingCartId);
    }
}