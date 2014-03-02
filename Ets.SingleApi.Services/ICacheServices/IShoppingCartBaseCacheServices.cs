namespace Ets.SingleApi.Services.ICacheServices
{
    using Ets.SingleApi.Model;
    using Ets.SingleApi.Model.CacheServices;

    /// <summary>
    /// 接口名称：IShoppingCartBaseCacheServices
    /// 命名空间：Ets.SingleApi.Services.ICacheServices
    /// 接口功能：保存购物车基本信息
    /// </summary>
    /// 创建者：单琪彬
    /// 创建日期：2/12/2014 4:58 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public interface IShoppingCartBaseCacheServices
    {
        /// <summary>
        /// 保存订单编号
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="orderId"></param>
        /// <param name="shoppingCartId"></param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 11:06 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        CacheServicesResult<bool> SaveShoppingCartId(string source, int orderId, string shoppingCartId);

        /// <summary>
        /// 更改订单状态
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="shoppingCartId">The shoppingCartId</param>
        /// <param name="complete">The  complete indicates whether</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 11:06 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        CacheServicesResult<bool> SaveShoppingCartComplete(string source, string shoppingCartId, bool complete);

        /// <summary>
        /// 获取购物车基本信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="shoppingCartId">The shoppingCartId</param>
        /// <returns>
        /// 返回购物车基本信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：3/2/2014 3:22 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        CacheServicesResult<ShoppingCartBase> GetShoppingCartBase(string source, string shoppingCartId);

        /// <summary>
        /// 根据订单编号查询对应购物车编号
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="orderId">The orderId</param>
        /// <returns>
        /// 返回购物车编号
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2/12/2014 5:41 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        CacheServicesResult<string> GetShoppingCartId(string source, string orderId);

        /// <summary>
        /// 绑定一个购物车编号
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="supplierId">The supplierId</param>
        /// <param name="userId">The userId</param>
        /// <returns>
        /// 返回购物车编号
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2/12/2014 5:41 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        CacheServicesResult<BindShoppingCartResult> BindShoppingCartId(string source, string supplierId, string userId);
    }
}