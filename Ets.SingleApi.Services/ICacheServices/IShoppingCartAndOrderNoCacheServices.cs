namespace Ets.SingleApi.Services.ICacheServices
{
    using Ets.SingleApi.Model.CacheServices;
    /// <summary>
    /// 接口名称：IShoppingCartAndOrderNoCacheServices
    /// 命名空间：Ets.SingleApi.Services.ICacheServices
    /// 接口功能：保存订单编号和购物车编号关系
    /// </summary>
    /// 创建者：单琪彬
    /// 创建日期：2/12/2014 4:58 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public interface IShoppingCartAndOrderNoCacheServices
    {
        /// <summary>
        /// 保存订单编号和购物车编号对应关系
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="orderId"></param>
        /// <param name="shoppingcartId"></param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 11:06 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        CacheServicesResult<bool> SaveShoppingCartAndOrderNoLink(string source, string orderId, string shoppingcartId);
        /// <summary>
        /// 根据订单编号查询对应购物车编号
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="orderId">The orderId</param>
        /// <returns>
        /// 返回购物车编号
        /// </returns>
        /// 创建者：单琪彬
        /// 创建日期：2/12/2014 5:41 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        CacheServicesResult<string> GetShoppingCartIdByOrderId(string source, string orderId);
    }
}
