﻿namespace Ets.SingleApi.Services
{
    using System.Collections.Generic;
    using System.Linq;

    using Ets.SingleApi.Controllers.IServices;
    using Ets.SingleApi.Model;
    using Ets.SingleApi.Model.Services;
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
        /// Initializes a new instance of the <see cref="OrderServices" /> class.
        /// </summary>
        /// <param name="orderProviderList">The orderProviderList</param>
        /// <param name="orderBaseProviderList"></param>
        /// 创建者：周超
        /// 创建日期：10/22/2013 8:30 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public OrderServices(
            List<IOrderProvider> orderProviderList,
            List<IOrderBaseProvider> orderBaseProviderList)
        {
            this.orderProviderList = orderProviderList;
            this.orderBaseProviderList = orderBaseProviderList;
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
        /// 保存订单信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="shoppingCartId">购物车Id</param>
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
        public ServicesResult<string> SaveOrder(string source, string shoppingCartId, int orderType, int orderSourceType)
        {
            var orderProvider = this.orderProviderList.FirstOrDefault(p => p.OrderProviderType.OrderType == (OrderType)orderType && p.OrderProviderType.OrderSourceType == (OrderSourceType)orderSourceType);
            if (orderProvider == null)
            {
                return new ServicesResult<string>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidOrderTypeCode
                };
            }

            var result = orderProvider.SaveOrder(source, shoppingCartId);
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
        public ServicesResult<string> GetOrderNumber(string source, int orderType, int orderSourceType)
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
            var orderProvider = this.orderProviderList.FirstOrDefault(p => p.OrderProviderType.OrderType == (OrderType)orderType && p.OrderProviderType.OrderSourceType == (OrderSourceType)orderSourceType);
            if (orderProvider == null)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidOrderTypeCode
                };
            }

            var result = orderProvider.SaveOrderPaId(source, orderId, isPaId);
            return new ServicesResult<bool>
            {
                StatusCode = result.StatusCode,
                Result = result.Result
            };
        }

        /// <summary>
        /// 是否可以激活购物车信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="orderType">Type of the order.</param>
        /// <param name="orderSourceType">Type of the order source.</param>
        /// <param name="orderId">The orderId</param>
        /// <returns></returns>
        /// 创建者：单琪彬
        /// 创建日期：2/13/2014 3:59 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<bool> IsActivation(string source, int orderType, int orderSourceType, int orderId)
        {
            var orderProvider = this.orderProviderList.FirstOrDefault(p => p.OrderProviderType.OrderType == (OrderType)orderType && p.OrderProviderType.OrderSourceType == (OrderSourceType)orderSourceType);
            if (orderProvider == null)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidOrderTypeCode
                };
            }

            var result = orderProvider.IsActivation(source, orderId);
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
            var orderProvider = this.orderProviderList.FirstOrDefault(p => p.OrderProviderType.OrderType == (OrderType)orderType && p.OrderProviderType.OrderSourceType == (OrderSourceType)orderSourceType);
            if (orderProvider == null)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidOrderTypeCode
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
        public ServicesResult<OrderShoppingCartStatusModel> GetOrderShoppingCartStatus(string source, string shoppingCartId, int orderType,
                                                                       int orderSourceType)
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
    }
}