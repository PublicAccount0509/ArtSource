﻿namespace Ets.SingleApi.Services.ICacheServices
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

        /// <summary>
        /// 保存供应商信息
        /// </summary>
        /// <param name="type">购物车类型</param>
        /// <param name="business">供应商信息</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 11:06 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        CacheServicesResult<bool> SaveShoppingCartBusiness(int type, IShoppingCartBusiness business);

        /// <summary>
        /// 取得顾客信息
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 11:06 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        CacheServicesResult<ShoppingCartCustomer> GetShoppingCartCustomer(int userId);

        /// <summary>
        /// 保存顾客信息
        /// </summary>
        /// <param name="customer">顾客信息</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 11:06 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        CacheServicesResult<bool> SaveShoppingCartCustomer(ShoppingCartCustomer customer);

        /// <summary>
        /// 取得订单信息
        /// </summary>
        /// <param name="id">订单唯一标识符</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 11:06 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        CacheServicesResult<ShoppingCartOrder> GetShoppingCartOrder(string id);

        /// <summary>
        /// 保存订单信息
        /// </summary>
        /// <param name="order">订单信息</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 11:06 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        CacheServicesResult<bool> SaveShoppingCartOrder(ShoppingCartOrder order);

        /// <summary>
        /// 取得购物车信息
        /// </summary>
        /// <param name="id">购物车唯一标识符</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 11:06 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        CacheServicesResult<ShoppingCart> GetShoppingCart(string id);

        /// <summary>
        /// 保存购物车信息
        /// </summary>
        /// <param name="shoppingCart">购物车信息</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 11:06 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        CacheServicesResult<bool> SaveShoppingCart(ShoppingCart shoppingCart);

        /// <summary>
        /// 获取购物车关联信息
        /// </summary>
        /// <param name="shoppingCartLinkId">购物车关联Id</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 2:08 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        CacheServicesResult<ShoppingCartLink> GetShoppingCartLink(string shoppingCartLinkId);

        /// <summary>
        /// 保存购物车关联信息
        /// </summary>
        /// <param name="shoppingCartLink">购物车关联信息</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 11:06 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        CacheServicesResult<bool> SaveShoppingCartLink(ShoppingCartLink shoppingCartLink);
    }
}