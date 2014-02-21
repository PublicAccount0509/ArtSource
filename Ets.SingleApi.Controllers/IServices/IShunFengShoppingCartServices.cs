﻿namespace Ets.SingleApi.Controllers.IServices
{
    using System.Collections.Generic;
    using Ets.SingleApi.Model;
    using Ets.SingleApi.Model.Services;
    /// <summary>
    /// 接口名称：IShunFengShoppingCartServices
    /// 命名空间：Ets.SingleApi.Controllers.IServices
    /// 接口功能：
    /// </summary>
    /// 创建者：单琪彬
    /// 创建日期：2/13/2014 5:30 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public interface IShunFengShoppingCartServices
    {
        /// <summary>
        /// 取得购物车信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="shoppingCartId">购物车Id</param>
        /// <returns>
        /// 返回购物车信息
        /// </returns>
        /// 创建者：单琪彬
        /// 创建日期：11/20/2013 11:56 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResult<HaiDiLaoShoppingCartModel> GetShoppingCart(string source, string shoppingCartId);

        /// <summary>
        /// 创建一个购物车
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="supplierId">餐厅Id</param>
        /// <param name="userId">用户Id</param>
        /// <returns>
        /// 返回一个购物车
        /// </returns>
        /// 创建者：单琪彬
        /// 创建日期：11/20/2013 11:56 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResult<string> CreateShoppingCart(string source, int supplierId, string userId);

        /// <summary>
        /// 更改商品信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="id">购物车Id</param>
        /// <param name="shoppingCartItemList">商品信息列表</param>
        /// <param name="saveDeliveryMethodId">是否即时更新DeliveryMethodId</param>
        /// <returns>
        /// 返回购物车信息
        /// </returns>
        /// 创建者：单琪彬
        /// 创建日期：11/20/2013 11:56 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResult<bool> SaveShoppingItem(string source, string id, List<ShoppingCartItem> shoppingCartItemList, bool saveDeliveryMethodId);

        /// <summary>
        /// 添加商品信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="id">购物车Id</param>
        /// <param name="shoppingCartItemList">商品信息列表</param>
        /// <param name="saveDeliveryMethodId">是否即时更新DeliveryMethodId</param>
        /// <returns>
        /// 返回购物车信息
        /// </returns>
        /// 创建者：单琪彬
        /// 创建日期：11/20/2013 11:56 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResult<bool> AddShoppingItem(string source, string id, List<ShoppingCartItem> shoppingCartItemList, bool saveDeliveryMethodId);

        /// <summary>
        /// 删除商品信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="id">购物车Id</param>
        /// <param name="shoppingCartItemList">商品信息列表</param>
        /// <param name="saveDeliveryMethodId">是否即时更新DeliveryMethodId</param>
        /// <returns>
        /// 返回购物车信息
        /// </returns>
        /// 创建者：单琪彬
        /// 创建日期：11/20/2013 11:56 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResult<bool> DeleteShoppingItem(string source, string id, List<ShoppingCartItem> shoppingCartItemList, bool saveDeliveryMethodId);

        /// <summary>
        /// 保存用户信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="id">购物车Id</param>
        /// <param name="userId">用户Id</param>
        /// <returns>
        /// 返回购物车信息
        /// </returns>
        /// 创建者：单琪彬
        /// 创建日期：11/21/2013 7:48 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResult<bool> SaveShoppingCartCustomer(string source, string id, int userId);

        /// <summary>
        /// 保存订单信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="id">购物车Id</param>
        /// <param name="shoppingCart">The shoppingCart</param>
        /// <returns>
        /// 返回购物车信息
        /// </returns>
        /// 创建者：单琪彬
        /// 创建日期：11/21/2013 7:48 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResult<bool> SaveShoppingCart(string source, string id, HaiDiLaoShoppingCartModel shoppingCart);

        /// <summary>
        /// 保存用户信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="id">购物车Id</param>
        /// <param name="shoppingCartOrder">The shoppingCartOrder</param>
        /// <param name="isCalculateCoupon">是否计算优惠</param>
        /// <param name="isValidateDeliveryTime">是否检测送餐时间</param>
        /// <returns>
        /// 返回购物车信息
        /// </returns>
        /// 创建者：单琪彬
        /// 创建日期：11/21/2013 7:48 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResult<bool> SaveShoppingCartOrder(
            string source,
            string id,
            HaiDiLaoShoppingCartOrder shoppingCartOrder,
            bool isCalculateCoupon,
            bool isValidateDeliveryTime);

        /// <summary>
        /// 保存订单配送信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="id">购物车Id</param>
        /// <param name="shoppingCartDelivery">The shoppingCartDelivery</param>
        /// <returns>
        /// 返回购物车信息
        /// </returns>
        /// 创建者：单琪彬
        /// 创建日期：11/21/2013 7:48 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResult<bool> SaveShoppingCartDelivery(string source, string id, ShoppingCartDelivery shoppingCartDelivery);

        /// <summary>
        /// 保存订单额外信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="id">购物车Id</param>
        /// <param name="shoppingCartExtra">The shoppingCartExtra</param>
        /// <returns>
        /// 返回购物车信息
        /// </returns>
        /// 创建者：单琪彬
        /// 创建日期：11/21/2013 7:48 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResult<bool> SaveShoppingCartExtra(string source, string id, ShoppingCartExtra shoppingCartExtra);

        /// <summary>
        /// 更改购物车送餐方式
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="id">购物车Id</param>
        /// <param name="deliveryMethodId">送餐方式</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：单琪彬
        /// 创建日期：11/20/2013 11:56 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResult<bool> SaveShoppingCartOrderDeliveryMethod(string source, string id, int deliveryMethodId);
        /// <summary>
        /// 激活购物车
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="orderId">The orderId</param>
        /// <returns>
        /// 返回是否激活成功
        /// </returns>
        /// 创建者：单琪彬
        /// 创建日期：2/13/2014 9:23 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResult<bool> ActivationShoppingCart(string source, int orderId);
    }
}