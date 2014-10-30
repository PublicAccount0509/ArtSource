﻿namespace Ets.SingleApi.Services
{
    using System.Collections.Generic;
    using System.Json;
    using System.Linq;

    using Ets.SingleApi.Controllers.IServices;
    using Ets.SingleApi.Model;
    using Ets.SingleApi.Model.ExternalServices;
    using Ets.SingleApi.Model.Services;
    using Ets.SingleApi.Services.ICacheServices;
    using Ets.SingleApi.Services.IExternalServices;
    using Ets.SingleApi.Utility;

    /// <summary>
    /// 类名称：OrderServicesTemp
    /// 命名空间：Ets.SingleApi.Services
    /// 类功能：订单功能
    /// </summary>
    /// 创建者：周超
    /// 创建日期：10/22/2013 6:16 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class OrderServices : IOrderServices
    {
        /// <summary>
        /// 字段orderProviderList
        /// </summary>
        /// 创建者：周超
        /// 创建日期：11/23/2013 12:10 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly List<IOrderProvider> orderProviderList;

        /// <summary>
        /// 字段orderBaseProviderList
        /// </summary>
        /// 创建者：单琪彬
        /// 创建日期：2/28/2014 4:53 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly List<IOrderBaseProvider> orderBaseProviderList;

        /// <summary>
        /// 字段shoppingCartBaseCacheServices
        /// </summary>
        /// 创建者：周超
        /// 创建日期：3/2/2014 7:27 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly IShoppingCartBaseCacheServices shoppingCartBaseCacheServices;

        /// <summary>
        /// 字段singleApiOrdersExternalService
        /// </summary>
        /// 创建者：周超
        /// 创建日期：3/2/2014 11:10 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly ISingleApiOrdersExternalService singleApiOrdersExternalService;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderServices" /> class.
        /// </summary>
        /// <param name="orderProviderList">The orderProviderList</param>
        /// <param name="orderBaseProviderList">The orderBaseProviderList</param>
        /// <param name="shoppingCartBaseCacheServices">The shoppingCartBaseCacheServices</param>
        /// <param name="singleApiOrdersExternalService">The singleApiOrdersExternalService</param>
        /// 创建者：周超
        /// 创建日期：10/22/2013 8:30 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public OrderServices(
            List<IOrderProvider> orderProviderList,
            List<IOrderBaseProvider> orderBaseProviderList,
            IShoppingCartBaseCacheServices shoppingCartBaseCacheServices,
            ISingleApiOrdersExternalService singleApiOrdersExternalService)
        {
            this.orderProviderList = orderProviderList;
            this.orderBaseProviderList = orderBaseProviderList;
            this.shoppingCartBaseCacheServices = shoppingCartBaseCacheServices;
            this.singleApiOrdersExternalService = singleApiOrdersExternalService;
        }

        /// <summary>
        /// 取得订单是否存在以及支付支付状态
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="orderId">订单状态</param>
        /// <param name="orderType">订单类型：0 外卖，1 堂食，2 订台</param>
        /// <param name="orderSourceType">订单来源：0 默认类型，1 海底捞；默认为 0</param>
        /// <returns>
        /// 返回结果 0 不存在 1 支付 2 未支付
        /// </returns>
        /// 创建者：周超
        /// 创建日期：10/23/2013 9:26 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<int> Exist(string source, int orderId, int orderType, int orderSourceType)
        {
            var orderBaseProvider = this.orderBaseProviderList.FirstOrDefault(p => p.OrderType == (OrderType)orderType);
            if (orderBaseProvider == null)
            {
                return new ServicesResult<int>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidOrderTypeCode
                };
            }

            var result = orderBaseProvider.Exist(source, orderId);
            return new ServicesResult<int>
            {
                StatusCode = result.StatusCode,
                Result = result.Result
            };
        }

        /// <summary>
        /// 取得订单详情
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="orderId">订单号</param>
        /// <param name="orderType">订单类型：0 外卖，1 堂食，2 订台</param>
        /// <param name="orderSourceType">订单来源：0 默认类型，1 海底捞；默认为 0</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：10/23/2013 9:26 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<IOrderDetailModel> GetOrder(string source, int orderId, int orderType, int orderSourceType)
        {
            var orderProvider = this.orderProviderList.FirstOrDefault(p => p.OrderProviderType.OrderType == (OrderType)orderType && p.OrderProviderType.OrderSourceType == (OrderSourceType)orderSourceType);
            if (orderProvider == null)
            {
                return new ServicesResult<IOrderDetailModel>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidOrderTypeCode
                };
            }

            var result = orderProvider.GetOrder(source, orderId);
            return new ServicesResult<IOrderDetailModel>
            {
                StatusCode = result.StatusCode,
                Result = result.Result
            };
        }
        /// <summary>
        /// 取得订单基本信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="orderId">订单号</param>
        /// <param name="orderType">订单类型：0 外卖，1 堂食，2 订台</param>
        /// <param name="orderSourceType">订单来源：0 默认类型，1 海底捞；默认为 0</param>
        /// <returns>
        /// ServicesResult{IOrderModel}
        /// </returns>
        /// 创建者：孟祺宙
        /// 创建日期：2014/8/6 13:48
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<TangShiOrderBaseModel> GetOrderBase(string source, int orderId, int orderType, int orderSourceType)
        {
            var orderProvider = this.orderProviderList.FirstOrDefault(p => p.OrderProviderType.OrderType == (OrderType)orderType && p.OrderProviderType.OrderSourceType == (OrderSourceType)orderSourceType);
            if (orderProvider == null)
            {
                return new ServicesResult<TangShiOrderBaseModel>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidOrderTypeCode
                };
            }

            var result = orderProvider.GetOrderBase(source, orderId);
            return new ServicesResult<TangShiOrderBaseModel>
            {
                StatusCode = result.StatusCode,
                Result = result.Result
            };
        }

        /// <summary>
        /// 保存订单信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="shoppingCartId">购物车Id</param>
        /// <param name="appKey">The appKey</param>
        /// <param name="appPassword">The appPassword</param>
        /// <param name="orderType">订单类型：0 外卖，1 堂食，2 订台</param>
        /// <param name="orderSourceType">订单来源：0 默认类型，1 海底捞；默认为 0</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/20 16:01
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<string> SaveOrder(string source, string shoppingCartId, string appKey, string appPassword, int orderType, int orderSourceType)
        {
            var orderProvider = this.orderProviderList.FirstOrDefault(p => p.OrderProviderType.OrderType == (OrderType)orderType && p.OrderProviderType.OrderSourceType == (OrderSourceType)orderSourceType);
            if (orderProvider == null)
            {
                return new ServicesResult<string>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidOrderTypeCode
                };
            }

            var result = orderProvider.SaveOrder(source, shoppingCartId, appKey, appPassword);
            return new ServicesResult<string>
            {
                StatusCode = result.StatusCode,
                Result = result.Result
            };
        }

        /// <summary>
        /// 保存堂食订单信息
        /// </summary>
        /// <param name="tangShiOrdersParameter"></param>
        /// <param name="appKey">The appKey</param>
        /// <param name="appPassword">The appPassword</param>
        /// <returns>
        /// 保存堂食订单信息
        /// </returns>
        /// 创建者：单琪彬
        /// 创建日期：5/14/2014 10:07 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<string> SaveTempOrder(SaveTangShiOrdersParameter tangShiOrdersParameter, string appKey, string appPassword)
        {
            var orderProvider = this.orderProviderList.FirstOrDefault(p => p.OrderProviderType.OrderType == OrderType.TangShi && p.OrderProviderType.OrderSourceType == OrderSourceType.EtsWap);
            if (orderProvider == null)
            {
                return new ServicesResult<string>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidOrderTypeCode
                };
            }

            var result = orderProvider.SaveTempOrder(tangShiOrdersParameter, appKey, appPassword);
            return new ServicesResult<string>
            {
                StatusCode = result.StatusCode,
                Result = result.Result
            };
        }
        /// <summary>
        /// 获取订单号
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="appKey">The appKey</param>
        /// <param name="appPassword">The appPassword</param>
        /// <param name="orderType">订单类型：0 外卖，1 堂食，2 订台</param>
        /// <param name="orderSourceType">订单来源：0 默认类型，1 海底捞；默认为 0</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：10/31/2013 9:01 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<string> GetOrderNumber(string source, string appKey, string appPassword, int orderType, int orderSourceType)
        {
            var result = ServicesCommon.FromServerEnable
                       ? this.GetServerOrderNumber(source, appKey, appPassword, orderType)
                       : this.GetLocalOrderNumber(source, orderType);

            return new ServicesResult<string>
            {
                StatusCode = result.StatusCode,
                Result = result.Result
            };
        }

        /// <summary>
        /// 更改支付状态
        /// </summary>
        /// <param name="source">The sourceDefault documentation</param>
        /// <param name="orderType">Type of the order.</param>
        /// <param name="orderSourceType">Type of the order source.</param>
        /// <param name="orderId">The orderIdDefault documentation</param>
        /// <param name="isPaId">The  isPaId indicates whether</param>
        /// <returns>
        /// Boolean}
        /// </returns>
        /// 创建者：王巍
        /// 创建日期：1/26/2014 10:54 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<bool> SaveOrderPaId(string source, int orderType, int orderSourceType, int orderId, bool isPaId)
        {
            var orderBaseProvider = this.orderBaseProviderList.FirstOrDefault(p => p.OrderType == (OrderType)orderType);
            if (orderBaseProvider == null)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidOrderTypeCode
                };
            }

            var result = orderBaseProvider.SaveOrderPaid(source, orderId, isPaId);
            return new ServicesResult<bool>
            {
                StatusCode = result.StatusCode,
                Result = result.Result
            };
        }

        /// <summary>
        /// 当前订单是否可以修改
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="orderType">Type of the order.</param>
        /// <param name="orderSourceType">Type of the order source.</param>
        /// <param name="orderId">The orderId</param>
        /// <returns>
        /// 返回结果，空字串可以修改；否则，不可修改。
        /// </returns>
        /// 创建者：单琪彬
        /// 创建日期：2/13/2014 11:55 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<string> GetOrderEditFlag(string source, int orderType, int orderSourceType, int orderId)
        {
            var orderBaseProvider = this.orderBaseProviderList.FirstOrDefault(p => p.OrderType == (OrderType)orderType);
            if (orderBaseProvider == null)
            {
                return new ServicesResult<string>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidOrderTypeCode,
                    Result = string.Empty
                };
            }

            var result = orderBaseProvider.GetOrderEditFlag(source, orderId);
            return new ServicesResult<string>
            {
                StatusCode = result.StatusCode,
                Result = result.Result
            };
        }

        /// <summary>
        /// 取消订单
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="orderType">Type of the order.</param>
        /// <param name="orderSourceType">Type of the order source.</param>
        /// <param name="orderId">The orderId</param>
        /// <returns>
        /// 返回结果，true取消成功；false取消失败。
        /// </returns>
        /// 创建者：周超
        /// 创建日期：3/15/2014 2:00 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<bool> CancelOrder(string source, int orderType, int orderSourceType, int orderId)
        {
            var orderBaseProvider = this.orderBaseProviderList.FirstOrDefault(p => p.OrderType == (OrderType)orderType);
            if (orderBaseProvider == null)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidOrderTypeCode
                };
            }

            var cancelOrderResult = orderBaseProvider.CancelOrder(source, orderId);
            if (cancelOrderResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = cancelOrderResult.StatusCode
                };
            }

            var getShoppingCartIdResult = this.shoppingCartBaseCacheServices.GetShoppingCartId(source, orderId);
            var shoppingCartId = getShoppingCartIdResult == null ? string.Empty : getShoppingCartIdResult.Result;
            this.shoppingCartBaseCacheServices.SaveShoppingCartComplete(source, shoppingCartId, true);
            return new ServicesResult<bool>
            {
                StatusCode = (int)StatusCode.Succeed.Ok,
                Result = true
            };
        }

        /// <summary>
        /// 更新订单的支付方式
        /// </summary>
        /// <param name="source">The sourceDefault documentation</param>
        /// <param name="shoppingCartId">The shoppingCartIdDefault documentation</param>
        /// <param name="paymentMethodId">The paymentMethodIdDefault documentation</param>
        /// <param name="payBank">The payBankDefault documentation</param>
        /// <param name="orderType">Type of the order.</param>
        /// <param name="orderSourceType">Type of the order source.</param>
        /// <returns>
        /// Boolean}
        /// </returns>
        /// 创建者：王巍
        /// 创建日期：2/24/2014 9:22 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<bool> ModifyOrderPaymentMethod(string source, string shoppingCartId, int paymentMethodId, string payBank,
                                                       int orderType, int orderSourceType)
        {
            var shoppingCartBase = this.shoppingCartBaseCacheServices.GetShoppingCartBase(source, shoppingCartId);
            if (shoppingCartBase.Result == null)
            {
                return new ServicesResult<bool>
                    {
                        StatusCode = (int)StatusCode.Validate.InvalidShoppingCartIdCode
                    };
            }

            if (shoppingCartBase.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = shoppingCartBase.StatusCode
                };
            }

            var orderBaseProvider = this.orderBaseProviderList.FirstOrDefault(p => p.OrderType == (OrderType)orderType);
            if (orderBaseProvider == null)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidOrderTypeCode
                };
            }

            var orderProvider = this.orderProviderList.FirstOrDefault(p => p.OrderProviderType.OrderType == (OrderType)orderType && p.OrderProviderType.OrderSourceType == (OrderSourceType)orderSourceType);
            if (orderProvider == null)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidOrderTypeCode
                };
            }

            var orderId = shoppingCartBase.Result.OrderNumber;
            var saveOrderPaymentMethodResult = orderBaseProvider.SaveOrderPaymentMethod(source, orderId, paymentMethodId, payBank);
            if (saveOrderPaymentMethodResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = saveOrderPaymentMethodResult.StatusCode
                };
            }

            var result = orderProvider.ModifyOrderPaymentMethod(source, shoppingCartId, paymentMethodId, payBank);
            return new ServicesResult<bool>
            {
                StatusCode = result.StatusCode,
                Result = result.Result
            };
        }

        /// <summary>
        /// 更新订单的支付方式
        /// </summary>
        /// <param name="source">The sourceDefault documentation</param>
        /// <param name="orderId">订单号</param>
        /// <param name="paymentMethodId">The paymentMethodIdDefault documentation</param>
        /// <param name="payBank">The payBankDefault documentation</param>
        /// <param name="orderType">Type of the order.</param>
        /// <param name="orderSourceType">Type of the order source.</param>
        /// <returns>
        /// Boolean}
        /// </returns>
        /// 创建者：王巍
        /// 创建日期：5/20/2014 1:37 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<bool> ModifyOrderPaymentMethodByOrderId(string source, int orderId, int paymentMethodId, string payBank,
                                                                int orderType, int orderSourceType)
        {

            var orderBaseProvider = this.orderBaseProviderList.FirstOrDefault(p => p.OrderType == (OrderType)orderType);
            if (orderBaseProvider == null)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidOrderTypeCode
                };
            }

            var orderProvider = this.orderProviderList.FirstOrDefault(p => p.OrderProviderType.OrderType == (OrderType)orderType && p.OrderProviderType.OrderSourceType == (OrderSourceType)orderSourceType);
            if (orderProvider == null)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidOrderTypeCode
                };
            }
            
            //保存订单支付方式
            var saveOrderPaymentMethodResult = orderBaseProvider.SaveOrderPaymentMethod(source, orderId, paymentMethodId, payBank);
            if (saveOrderPaymentMethodResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = saveOrderPaymentMethodResult.StatusCode
                };
            }

            //获取购物车Id 通过订单号
            var shoppingCartBase = this.shoppingCartBaseCacheServices.GetShoppingCartId(source, orderId);
            if (shoppingCartBase != null && shoppingCartBase.StatusCode == (int)StatusCode.Succeed.Ok && shoppingCartBase.Result != null)
            {
                var shoppingCartId = shoppingCartBase.Result;

                //修改购物车中订单支付状态
                var result = orderProvider.ModifyOrderPaymentMethod(source, shoppingCartId, paymentMethodId, payBank);

                return new ServicesResult<bool>
                {
                    StatusCode = result.StatusCode,
                    Result = result.Result
                };
            }

            return new ServicesResult<bool>
            {
                StatusCode = saveOrderPaymentMethodResult.StatusCode,
                Result = saveOrderPaymentMethodResult.Result
            };
        }

        /// <summary>
        /// 查询订单是否完成，订单是否已支付
        /// </summary>
        /// <param name="source">The sourceDefault documentation</param>
        /// <param name="shoppingCartId">The shoppingCartIdDefault documentation</param>
        /// <param name="orderType">Type of the order.</param>
        /// <param name="orderSourceType">Type of the order source.</param>
        /// <returns>
        /// ServicesResult{OrderIsCompleteIsPaidModel}
        /// </returns>
        /// 创建者：王巍
        /// 创建日期：2/24/2014 8:03 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<OrderShoppingCartStatusModel> GetOrderShoppingCartStatus(string source, string shoppingCartId, int orderType, int orderSourceType)
        {
            var orderProvider = this.orderProviderList.FirstOrDefault(p => p.OrderProviderType.OrderType == (OrderType)orderType && p.OrderProviderType.OrderSourceType == (OrderSourceType)orderSourceType);
            if (orderProvider == null)
            {
                return new ServicesResult<OrderShoppingCartStatusModel>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidOrderTypeCode,
                    Result = new OrderShoppingCartStatusModel()
                };
            }

            var result = orderProvider.GetOrderShoppingCartStatus(source, shoppingCartId);
            return new ServicesResult<OrderShoppingCartStatusModel>
            {
                StatusCode = result.StatusCode,
                Result = result.Result
            };
        }

        /// <summary>
        /// 保存百付宝优惠支付返回，支付现金金额，优惠金额，立减金额，所有单位为“分”
        /// </summary>
        /// <param name="source">The sourceDefault documentation</param>
        /// <param name="orderId">The orderIdDefault documentation</param>
        /// <param name="paidAmount">The paidAmountDefault documentation</param>
        /// <param name="coupons">The couponsDefault documentation</param>
        /// <param name="promotion">The promotionDefault documentation</param>
        /// <param name="orderType">Type of the order.</param>
        /// <returns>
        /// Boolean}
        /// </returns>
        /// 创建者：王巍
        /// 创建日期：6/26/2014 9:19 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<bool> SavDeliveryBaiFuBaoCoupon(string source, int orderId, string paidAmount, string coupons, string promotion,
                                                        int orderType)
        {
            var orderBaseProvider = this.orderBaseProviderList.FirstOrDefault(p => p.OrderType == (OrderType)orderType);
            if (orderBaseProvider == null)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidOrderTypeCode
                };
            }

            var result = orderBaseProvider.SavDeliveryBaiFuBaoCoupon(source, orderId,paidAmount,coupons,promotion);

            return new ServicesResult<bool>
            {
                StatusCode = result.StatusCode,
                Result = result.Result
            };
        }

        /// <summary>
        /// 从本地获取订单号
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="orderType">Type of the order.</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：3/2/2014 11:33 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private ServicesResult<string> GetLocalOrderNumber(string source, int orderType)
        {
            var orderBaseProvider = this.orderBaseProviderList.FirstOrDefault(p => p.OrderType == (OrderType)orderType);
            if (orderBaseProvider == null)
            {
                return new ServicesResult<string>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidOrderTypeCode
                };
            }

            var result = orderBaseProvider.GetOrderNumber(source);
            return new ServicesResult<string>
            {
                StatusCode = result.StatusCode,
                Result = result.Result
            };
        }

        /// <summary>
        /// 从服务器获取订单号
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="appKey">The appKey</param>
        /// <param name="appPassword">The appPassword</param>
        /// <param name="orderType">Type of the order.</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：3/2/2014 11:34 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private ServicesResult<string> GetServerOrderNumber(string source, string appKey, string appPassword, int orderType)
        {
            var result = this.singleApiOrdersExternalService.OrderNumber(
                  new OrderNumberExternalUrlParameter { OrderType = orderType },
                  string.Empty,
                  new SingleApiExternalServiceAuthenParameter { AppKey = appKey, AppPassword = appPassword, Source = source });

            var data = result.Result;
            var jsonValue = JsonValue.Parse(data);
            if (jsonValue == null || jsonValue["Message"] == null)
            {
                return new ServicesResult<string>();
            }

            if (jsonValue["Message"]["StatusCode"] != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<string>
                    {
                        StatusCode = jsonValue["Message"]["StatusCode"]
                    };
            }

            return new ServicesResult<string>
            {
                StatusCode = result.StatusCode,
                Result = jsonValue["Result"]
            };
        }



    }
}