namespace Ets.SingleApi.Services
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
        /// Initializes a new instance of the <see cref="OrderServices" /> class.
        /// </summary>
        /// <param name="orderProviderList">The orderProviderList</param>
        /// 创建者：周超
        /// 创建日期：10/22/2013 8:30 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public OrderServices(
            List<IOrderProvider> orderProviderList)
        {
            this.orderProviderList = orderProviderList;
        }

        /// <summary>
        /// 取得订单详情
        /// </summary>
        /// <param name="orderId">订单号</param>
        /// <param name="userId">用户Id</param>
        /// <param name="orderType">订单类型：0 外卖，1 堂食，2 订台</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：10/23/2013 9:26 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<IOrderDetailModel> GetOrder(int orderId, int userId, int orderType)
        {
            var orderProvider = this.orderProviderList.FirstOrDefault(p => p.OrderType == (OrderType)orderType);
            if (orderProvider == null)
            {
                return new ServicesResult<IOrderDetailModel>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidOrderTypeCode
                };
            }

            var result = orderProvider.GetOrder(orderId, userId);
            return new ServicesResult<IOrderDetailModel>
            {
                StatusCode = result.StatusCode,
                Result = result.Result
            };
        }

        /// <summary>
        /// 保存订单信息
        /// </summary>
        /// <param name="shoppingCartId">购物车Id</param>
        /// <param name="orderType">订单类型：0 外卖，1 堂食，2 订台</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/20 16:01
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<string> SaveOrder(string shoppingCartId, int orderType)
        {
            var orderProvider = this.orderProviderList.FirstOrDefault(p => p.OrderType == (OrderType)orderType);
            if (orderProvider == null)
            {
                return new ServicesResult<string>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidOrderTypeCode
                };
            }

            var result = orderProvider.SaveOrder(shoppingCartId);
            return new ServicesResult<string>
            {
                StatusCode = result.StatusCode,
                Result = result.Result
            };
        }

        /// <summary>
        /// 获取订单号
        /// </summary>
        /// <param name="orderType">订单类型：0 外卖，1 堂食，2 订台</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：10/31/2013 9:01 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<string> GetOrderNumber(int orderType)
        {
            var orderProvider = this.orderProviderList.FirstOrDefault(p => p.OrderType == (OrderType)orderType);
            if (orderProvider == null)
            {
                return new ServicesResult<string>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidOrderTypeCode
                };
            }

            var result = orderProvider.GetOrderNumber();
            return new ServicesResult<string>
            {
                StatusCode = result.StatusCode,
                Result = result.Result
            };
        }
    }
}