﻿namespace Ets.SingleApi.Hosting.Contracts
{
    using System.ComponentModel;
    using System.ServiceModel;

    using Ets.SingleApi.Model.Controller;
    using Ets.SingleApi.Model.Services;

    /// <summary>
    /// 接口名称：IEtsWapDingTaiShoppingCartService
    /// 命名空间：Ets.SingleApi.Hosting.Contracts
    /// 接口功能：订台购物车
    /// </summary>
    /// 创建者：周超
    /// 创建日期：12/9/2013 3:06 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    [ServiceContract]
    public interface IEtsWapDingTaiShoppingCartService
    {
        /// <summary>
        /// 创建一个购物车
        /// </summary>
        /// <param name="id">购物车Id</param>
        /// <returns>
        /// 返回购物车信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/20/2013 11:56 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [OperationContract]
        [Description("方法功能：根据购物车Id获取购物车信息；参数说明：id（购物车Id）；返回结果：购物车信息")]
        Response<EtsWapDingTaiShoppingCartModel> ShoppingCart(string id);

        /// <summary>
        /// 保存购物车信息
        /// </summary>
        /// <param name="id">购物车Id</param>
        /// <param name="requst">购物车信息</param>
        /// <returns>
        /// 返回购物车信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/20/2013 11:56 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [OperationContract]
        [Description("方法功能：保存购物车信息；参数说明：id（购物车Id）；返回结果：购物车信息")]
        Response<EtsWapDingTaiShoppingCartModel> SaveShoppingCart(string id, EtsWapDingTaiShoppingCartRequst requst);

        /// <summary>
        /// 创建一个购物车
        /// </summary>
        /// <param name="supplierId">餐厅Id</param>
        /// <param name="userId">用户的唯一标识</param>
        /// <param name="orderId">The orderId</param>
        /// <returns>
        /// 返回购物车信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/20/2013 11:56 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [OperationContract]
        [Description("方法功能：保存购物车信息；参数说明：supplierId（餐厅Id），userId（用户的唯一标识）；返回结果：购物车信息")]
        Response<EtsWapDingTaiShoppingCartModel> Create(int supplierId, string userId, int orderId);

        /// <summary>
        /// 关联顾客信息
        /// </summary>
        /// <param name="id">购物车Id</param>
        /// <param name="userId">用户Id</param>
        /// <returns>
        /// 返回购物车信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 9:29 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [OperationContract]
        [Description("方法功能：关联顾客信息；参数说明：id（购物车Id），userId（用户Id）；返回结果：购物车信息")]
        Response<EtsWapDingTaiShoppingCartModel> Customer(string id, int userId);

        /// <summary>
        /// 保存送餐信息
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="requst">The requst</param>
        /// <returns>
        /// 返回购物车信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 9:29 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [OperationContract]
        [Description("方法功能：保存送餐信息；参数说明：id（购物车Id）；返回结果：购物车信息")]
        Response<EtsWapDingTaiShoppingCartModel> Delivery(string id, EtsWapDingTaiShoppingCartDeliveryRequst requst);

        /// <summary>
        /// 保存全部商品信息
        /// </summary>
        /// <param name="id">购物车Id</param>
        /// <param name="requst">商品信息</param>
        /// <param name="saveDeliveryMethodId">是否即时更新DeliveryMethodId</param>
        /// <returns>
        /// 返回购物车信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 9:25 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [OperationContract]
        [Description("方法功能：保存全部商品信息；参数说明：id（购物车Id），saveDeliveryMethodId（是否即时更新DeliveryMethodId，默认值true）；返回结果：购物车信息")]
        Response<EtsWapDingTaiShoppingCartModel> Shopping(string id, EtsWapDingTaiShoppingCartShoppingRequst requst, bool saveDeliveryMethodId);

        /// <summary>
        /// 添加商品信息
        /// </summary>
        /// <param name="id">购物车Id</param>
        /// <param name="requst">商品信息</param>
        /// <param name="saveDeliveryMethodId">是否即时更新DeliveryMethodId</param>
        /// <returns>
        /// 返回购物车信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 9:25 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [OperationContract]
        [Description("方法功能：添加商品信息；参数说明：id（购物车Id），saveDeliveryMethodId（是否即时更新DeliveryMethodId，默认值true）；返回结果：购物车信息")]
        Response<EtsWapDingTaiShoppingCartModel> AddShopping(string id, EtsWapDingTaiShoppingCartShoppingRequst requst, bool saveDeliveryMethodId);

        /// <summary>
        /// 删除商品信息
        /// </summary>
        /// <param name="id">购物车Id</param>
        /// <param name="requst">商品信息</param>
        /// <param name="saveDeliveryMethodId">是否即时更新DeliveryMethodId</param>
        /// <returns>
        /// 返回购物车信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 9:25 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [OperationContract]
        [Description("方法功能：删除商品信息；参数说明：id（购物车Id），saveDeliveryMethodId（是否即时更新DeliveryMethodId，默认值true）；返回结果：购物车信息")]
        Response<EtsWapDingTaiShoppingCartModel> DeleteShopping(string id, EtsWapDingTaiShoppingCartShoppingRequst requst, bool saveDeliveryMethodId);

        /// <summary>
        /// 保存确认订单信息
        /// </summary>
        /// <param name="id">购物车Id</param>
        /// <param name="requst">The requst.</param>
        /// <param name="isCalculateCoupon">if set to <c>true</c> [is calculate coupon].</param>
        /// <returns></returns>
        /// 创建者：苏建峰
        /// 创建日期：3/20/2014 10:01 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [OperationContract]
        [Description("方法功能：保存确认订单信息；参数说明：id（购物车Id）；返回结果：购物车信息")]
        Response<EtsWapDingTaiShoppingCartModel> SaveOrderConfirm(string id, EtsWapDingTaiShoppingCartOrderConfirmRequst requst, bool isCalculateCoupon);

        /// <summary>
        /// 保存订单信息
        /// </summary>
        /// <param name="id">购物车Id</param>
        /// <param name="requst">订单信息</param>
        /// <param name="isCalculateCoupon">是否计算优惠</param>
        /// <param name="isValidateDeliveryTime">是否检测送餐时间</param>
        /// <returns>
        /// 返回购物车信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/21/2013 9:25 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [OperationContract]
        [Description("方法功能：保存订单信息；参数说明：id（购物车Id），isCalculateCoupon（是否计算优惠，默认值false）, isValidateDeliveryTime（是否检测送餐时间，默认值true）；返回结果：购物车信息")]
        Response<EtsWapDingTaiShoppingCartModel> Order(string id, EtsWapDingTaiShoppingCartOrderRequst requst, bool isCalculateCoupon, bool isValidateDeliveryTime);
    }
}