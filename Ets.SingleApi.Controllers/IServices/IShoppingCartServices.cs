namespace Ets.SingleApi.Controllers.IServices
{
    using System.Collections.Generic;

    using Ets.SingleApi.Model;
    using Ets.SingleApi.Model.Services;

    /// <summary>
    /// 接口名称：IShoppingCartServices
    /// 命名空间：Ets.SingleApi.Controllers.IServices
    /// 接口功能：购物车服务
    /// </summary>
    /// 创建者：周超
    /// 创建日期：11/20/2013 11:49 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public interface IShoppingCartServices
    {
        /// <summary>
        /// 取得购物车信息
        /// </summary>
        /// <param name="shoppingCartId">购物车Id</param>
        /// <returns>
        /// 返回购物车信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/20/2013 11:56 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResult<ShoppingCartModel> GetShoppingCart(string shoppingCartId);

        /// <summary>
        /// 创建一个购物车
        /// </summary>
        /// <param name="supplierId">餐厅Id</param>
        /// <param name="userId">用户Id</param>
        /// <returns>
        /// 返回一个购物车
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/20/2013 11:56 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResult<string> CreateShoppingCart(int supplierId, string userId);

        /// <summary>
        /// 更改商品信息
        /// </summary>
        /// <param name="id">购物车Id</param>
        /// <param name="shoppingCartItemList">商品信息列表</param>
        /// <returns>
        /// 返回购物车信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/20/2013 11:56 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResult<bool> SaveShoppingItem(string id, List<ShoppingCartItem> shoppingCartItemList);

        /// <summary>
        /// 添加商品信息
        /// </summary>
        /// <param name="id">购物车Id</param>
        /// <param name="shoppingCartItemList">商品信息列表</param>
        /// <returns>
        /// 返回购物车信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/20/2013 11:56 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResult<bool> AddShoppingItem(string id, List<ShoppingCartItem> shoppingCartItemList);

        /// <summary>
        /// 删除商品信息
        /// </summary>
        /// <param name="id">购物车Id</param>
        /// <param name="shoppingCartItemList">商品信息列表</param>
        /// <returns>
        /// 返回购物车信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/20/2013 11:56 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResult<bool> DeleteShoppingItem(string id, List<ShoppingCartItem> shoppingCartItemList);

        /// <summary>
        /// 保存用户信息
        /// </summary>
        /// <param name="id">购物车Id</param>
        /// <param name="userId">用户Id</param>
        /// <returns>
        /// 返回购物车信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 7:48 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResult<bool> SaveShoppingCartCustomer(string id, int userId);

        /// <summary>
        /// 保存订单信息
        /// </summary>
        /// <param name="id">购物车Id</param>
        /// <param name="shoppingCartOrder">The shoppingCartOrder</param>
        /// <returns>
        /// 返回购物车信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 7:48 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResult<bool> SaveShoppingCartOrder(string id, ShoppingCartOrder shoppingCartOrder);

        /// <summary>
        /// 保存订单配送信息
        /// </summary>
        /// <param name="id">购物车Id</param>
        /// <param name="shoppingCartDelivery">The shoppingCartOrder</param>
        /// <returns>
        /// 返回购物车信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 7:48 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResult<bool> SaveShoppingCartDelivery(string id, ShoppingCartDelivery shoppingCartDelivery);

        /// <summary>
        /// 更改购物车送餐方式
        /// </summary>
        /// <param name="id">购物车Id</param>
        /// <param name="deliveryMethodId">送餐方式</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/20/2013 11:56 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResult<bool> SaveShoppingCartOrderDeliveryMethod(string id, int deliveryMethodId);
    }
}