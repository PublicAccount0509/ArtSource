namespace Ets.SingleApi.Services.ICacheServices
{
    using Ets.SingleApi.Model;
    using Ets.SingleApi.Model.CacheServices;

    /// <summary>
    /// 接口名称：IEtsWapTangShiShoppingCartCacheServices
    /// 命名空间：Ets.SingleApi.Services.ICacheServices
    /// 接口功能：购物车缓存信息
    /// </summary>
    /// 创建者：周超
    /// 创建日期：11/21/2013 11:06 AM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public interface IEtsWapTangShiShoppingCartCacheServices
    {
        /// <summary>
        /// 取得餐厅信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="supplierId">餐厅Id</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 11:06 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        CacheServicesResult<ShoppingCartSupplier> GetShoppingCartSupplier(string source, int supplierId);

        /// <summary>
        /// 保存餐厅信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="supplier">餐厅信息</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 11:06 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        CacheServicesResult<bool> SaveShoppingCartSupplier(string source, ShoppingCartSupplier supplier);

        /// <summary>
        /// 取得顾客信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="userId">用户Id</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 11:06 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        CacheServicesResult<ShoppingCartCustomer> GetShoppingCartCustomer(string source, int userId);

        /// <summary>
        /// 保存顾客信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="customer">顾客信息</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 11:06 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        CacheServicesResult<bool> SaveShoppingCartCustomer(string source, ShoppingCartCustomer customer);

        /// <summary>
        /// 取得订单信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="id">订单唯一标识符</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 11:06 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        CacheServicesResult<EtsWapTangShiShoppingCartOrder> GetShoppingCartOrder(string source, string id);

        /// <summary>
        /// 保存订单信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="order">订单信息</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 11:06 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        CacheServicesResult<bool> SaveShoppingCartOrder(string source, EtsWapTangShiShoppingCartOrder order);

        /// <summary>
        /// 取得购物车信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="id">购物车唯一标识符</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 11:06 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        CacheServicesResult<EtsWapTangShiShoppingCart> GetShoppingCart(string source, string id);

        /// <summary>
        /// 保存购物车信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="shoppingCart">购物车信息</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 11:06 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        CacheServicesResult<bool> SaveShoppingCart(string source, EtsWapTangShiShoppingCart shoppingCart);

        /// <summary>
        /// 获取订单配送信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="id">订单配送信息唯一标识符</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 2:08 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        CacheServicesResult<ShoppingCartDelivery> GetShoppingCartDelivery(string source, string id);

        /// <summary>
        /// 保存订单配送信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="shoppingCartDelivery">订单配送信息</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 2:08 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        CacheServicesResult<bool> SaveShoppingCartDelivery(string source, ShoppingCartDelivery shoppingCartDelivery);

        /// <summary>
        /// 获取购物车关联信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="shoppingCartLinkId">购物车关联Id</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 2:08 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        CacheServicesResult<EtsWapTangShiShoppingCartLink> GetShoppingCartLink(string source, string shoppingCartLinkId);

        /// <summary>
        /// 保存购物车关联信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="shoppingCartLink">购物车关联信息</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 2:08 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        CacheServicesResult<bool> SaveShoppingCartLink(string source, EtsWapTangShiShoppingCartLink shoppingCartLink);
    }
}