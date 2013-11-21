namespace Ets.SingleApi.Services
{
    using Ets.SingleApi.Model;

    /// <summary>
    /// 接口名称：IShoppingCartBusinessService
    /// 命名空间：Ets.SingleApi.Services.ShoppingCart
    /// 接口功能：购物车供应商数据
    /// </summary>
    /// 创建者：周超
    /// 创建日期：11/21/2013 10:20 AM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public interface IShoppingCartBusinessService
    {
        /// <summary>
        /// 购物车类型
        /// </summary>
        /// <value>
        /// 购物车类型
        /// </value>
        /// 创建者：周超
        /// 创建日期：11/21/2013 10:25 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        BusinessType BusinessType { get; }

        /// <summary>
        /// 取得供应商信息
        /// </summary>
        /// <param name="businessId">供应商Id</param>
        /// <returns>
        /// 供应商信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 10:25 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ShoppingCartResult<IShoppingCartBusiness> GetShoppingCartBusiness(int businessId);
    }
}