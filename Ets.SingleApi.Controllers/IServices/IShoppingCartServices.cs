namespace Ets.SingleApi.Controllers.IServices
{
    using Ets.SingleApi.Model;
    using Ets.SingleApi.Model.Services;

    /// <summary>
    /// 接口名称：IShoppingCartServices
    /// 命名空间：Ets.SingleApi.Controllers.IServices
    /// 接口功能：购物车基本信息
    /// </summary>
    /// 创建者：周超
    /// 创建日期：11/15/2013 1:19 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public interface IShoppingCartServices
    {
        /// <summary>
        /// 更改购物车状态
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="shoppingCartId">The shoppingCartId</param>
        /// <param name="complete">The  complete indicates whether</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/20/2013 11:56 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResult<bool> SaveShoppingCartComplete(string source, string shoppingCartId, bool complete);

        /// <summary>
        /// 取得购物车基本信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="shoppingCartId">The shoppingCartId</param>
        /// <returns>
        /// 返回购物车基本信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/20/2013 11:56 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResult<ShoppingCartBase> GetShoppingCartBase(string source, string shoppingCartId);

        /// <summary>
        /// 取得购物车Id
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="orderId">The orderId</param>
        /// <returns>
        /// 返回购物车Id
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/20/2013 11:56 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResult<string> GetShoppingCartId(string source, int orderId);
    }
}