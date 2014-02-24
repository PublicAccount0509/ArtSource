namespace Ets.SingleApi.Services
{
    using System;

    using Ets.SingleApi.Model;
    using Ets.SingleApi.Model.Services;

    /// <summary>
    /// 接口名称：IHaiDiLaoShoppingCartProvider
    /// 命名空间：Ets.SingleApi.Services
    /// 接口功能：购物车功能
    /// </summary>
    /// 创建者：周超
    /// 创建日期：11/21/2013 2:37 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public interface IHaiDiLaoShoppingCartProvider
    {
        /// <summary>
        /// 获取餐厅信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="supplierId">餐厅Id</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 2:07 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResult<ShoppingCartSupplier> GetShoppingCartSupplier(string source, int supplierId);

        /// <summary>
        /// 获取购物车顾客信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="userId">用户Id</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 2:08 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResult<ShoppingCartCustomer> GetShoppingCartCustomer(string source, int? userId);

        /// <summary>
        /// 获取购物车信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="id">购物车唯一标识符</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 2:08 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResult<ShoppingCart> GetShoppingCart(string source, string id);

        /// <summary>
        /// 获取海底捞订单信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="id">订单唯一标识符</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 2:08 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResult<HaiDiLaoShoppingCartOrder> GetShoppingCartOrder(string source, string id);

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
        ServicesResult<ShoppingCartDelivery> GetShoppingCartDelivery(string source, string id);

        /// <summary>
        /// 获取订单额外信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="id">订单额外信息唯一标识符</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 2:08 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResult<ShoppingCartExtra> GetShoppingCartExtra(string source, string id);

        /// <summary>
        /// 获取海底捞购物车关联信息
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
        ServicesResult<HaiDiLaoShoppingCartLink> GetShoppingCartLink(string source, string shoppingCartLinkId);

        /// <summary>
        /// 获取海底捞购物车关联信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="supplierId">餐厅Id</param>
        /// <param name="anonymityId">匿名用户Id</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 2:08 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResult<HaiDiLaoShoppingCartLink> GetShoppingCartLink(string source, int supplierId, string anonymityId);

        /// <summary>
        /// 保存购物车信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="shoppingCart">购物车信息</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 2:08 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResult<bool> SaveShoppingCart(string source, ShoppingCart shoppingCart);

        /// <summary>
        /// 保存海底捞订单信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="shoppingCartOrder">订单信息</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 2:08 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResult<bool> SaveShoppingCartOrder(string source, HaiDiLaoShoppingCartOrder shoppingCartOrder);

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
        ServicesResult<bool> SaveShoppingCartDelivery(string source, ShoppingCartDelivery shoppingCartDelivery);

        /// <summary>
        /// 保存订单额外信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="shoppingCartExtra">订单额外信息</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 2:08 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResult<bool> SaveShoppingCartExtra(string source, ShoppingCartExtra shoppingCartExtra);

        /// <summary>
        /// 保存海底捞购物车关联信息
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
        ServicesResult<bool> SaveShoppingCartLink(string source, HaiDiLaoShoppingCartLink shoppingCartLink);

        /// <summary>
        /// 将订单状态设置为完成状态
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="orderId">订单Id</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 2:08 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResult<bool> CompleteShoppingCartOrder(string source, string orderId);

        /// <summary>
        /// 验证送餐时间
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="supplierId">餐厅Id</param>
        /// <param name="deliveryTime">送餐时间</param>
        /// <param name="now">当前时间</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：12/2/2013 6:35 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResult<bool> ValidateDeliveryTime(string source, int supplierId, DateTime deliveryTime, DateTime now);

        /// <summary>
        /// 验证取餐时间
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="supplierId">餐厅Id</param>
        /// <param name="pickUpTime">取餐时间</param>
        /// <param name="now">当前时间</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：12/2/2013 6:35 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResult<bool> ValidatePickUpTime(string source, int supplierId, DateTime pickUpTime, DateTime now);
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

        /// <summary>
        /// 更改支付方式
        /// </summary>
        /// <param name="source">The sourceDefault documentation</param>
        /// <param name="orderId">The orderIdDefault documentation</param>
        /// <param name="paymentMethodId">The paymentMethodIdDefault documentation</param>
        /// <param name="payBank">The payBankDefault documentation</param>
        /// <returns>
        /// Boolean}
        /// </returns>
        /// 创建者：王巍
        /// 创建日期：2/24/2014 10:33 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResult<bool> ModifyOrderPaymentMethod(string source, string orderId, int paymentMethodId,string payBank);
    }
}