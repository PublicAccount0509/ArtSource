namespace Ets.SingleApi.Services.DetailServices
{
    using System.Collections.Generic;
    using System.Linq;

    using Castle.Services.Transaction;

    using Ets.SingleApi.Model;
    using Ets.SingleApi.Model.DetailServices;
    using Ets.SingleApi.Model.Services;
    using Ets.SingleApi.Services.IDetailServices;
    using Ets.SingleApi.Utility;

    /// <summary>
    /// 类名称：OrderDetailServices
    /// 命名空间：Ets.SingleApi.Services.DetailServices
    /// 类功能：订单功能
    /// </summary>
    /// 创建者：周超
    /// 创建日期：10/22/2013 8:29 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    [Transactional]
    public class OrderDetailServices : IOrderDetailServices
    {
        /// <summary>
        /// 字段orderDetailList
        /// </summary>
        /// 创建者：周超
        /// 创建日期：10/23/2013 3:39 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly List<IOrderDetail> orderDetailList;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderDetailServices" /> class.
        /// </summary>
        /// <param name="orderDetailList">The orderDetailList</param>
        /// 创建者：周超
        /// 创建日期：10/22/2013 8:41 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public OrderDetailServices(
            List<IOrderDetail> orderDetailList)
        {
            this.orderDetailList = orderDetailList;
        }

        /// <summary>
        /// 添加外卖订单
        /// </summary>
        /// <param name="parameter">The parameter</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：10/22/2013 8:31 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [Transaction(TransactionMode.RequiresNew)]
        public DetailServicesResult<AddWaiMaiOrderModel> AddWaiMaiOrder(AddWaiMaiOrderParameter parameter)
        {
            if (parameter == null)
            {
                return new DetailServicesResult<AddWaiMaiOrderModel>
                {
                    StatusCode = (int)StatusCode.System.InvalidRequest,
                    Result = new AddWaiMaiOrderModel()
                };
            }

            var orderDetail = this.orderDetailList.FirstOrDefault(p => p.OrderType == OrderType.WaiMai);
            if (orderDetail == null)
            {
                return new DetailServicesResult<AddWaiMaiOrderModel>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidOrderTypeCode,
                    Result = new AddWaiMaiOrderModel()
                };
            }

            var dishList = parameter.DishList ?? new List<AddWaiMaiOrderDishModel>();
            var addWaiMaiOrderData = new AddWaiMaiOrderData
                {
                    UserId = parameter.UserId,
                    SupplierId = parameter.SupplierId,
                    DeliveryInstruction = parameter.DeliveryInstruction,
                    DeliveryMethodId = parameter.DeliveryMethodId,
                    DishList = dishList.Select(p => new AddWaiMaiOrderDishData
                        {
                            SupplierDishId = p.SupplierDishId,
                            Quantity = p.Quantity
                        }).ToList()
                };

            var result = orderDetail.AddOrder(addWaiMaiOrderData);
            var addWaiMaiOrderResult = result.Result as AddWaiMaiOrderResult;
            if (addWaiMaiOrderResult == null)
            {
                return new DetailServicesResult<AddWaiMaiOrderModel>
                {
                    StatusCode = (int)StatusCode.Succeed.Empty,
                    Result = new AddWaiMaiOrderModel()
                };
            }

            return new DetailServicesResult<AddWaiMaiOrderModel>
            {
                StatusCode = result.StatusCode,
                Result = new AddWaiMaiOrderModel
                    {
                        OrderId = addWaiMaiOrderResult.OrderId,
                        CustomerTotal = addWaiMaiOrderResult.CustomerTotal,
                        SupplierId = addWaiMaiOrderResult.SupplierId,
                        SupplierName = addWaiMaiOrderResult.SupplierName,
                        SupplierDishCount = addWaiMaiOrderResult.SupplierDishCount
                    }
            };
        }
    }
}