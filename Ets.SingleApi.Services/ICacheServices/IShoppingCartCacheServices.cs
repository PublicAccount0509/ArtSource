namespace Ets.SingleApi.Services.ICacheServices
{
    using Ets.SingleApi.Model;
    using Ets.SingleApi.Model.CacheServices;

    /// <summary>
    /// 接口名称：IShoppingCartCacheServices
    /// 命名空间：Ets.SingleApi.Services.ICacheServices
    /// 接口功能：购物车缓存信息
    /// </summary>
    /// 创建者：周超
    /// 创建日期：11/21/2013 11:06 AM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public interface IShoppingCartCacheServices
    {
        /// <summary>
        /// 取得供应商信息
        /// </summary>
        /// <param name="type">购物车类型</param>
        /// <param name="businessId">供应商Id</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 11:06 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        CacheServicesResult<IShoppingCartBusiness> GetShoppingCartBusiness(int type, int businessId);
    }
}