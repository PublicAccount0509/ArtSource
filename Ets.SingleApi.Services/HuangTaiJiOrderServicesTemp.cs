namespace Ets.SingleApi.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Ets.SingleApi.Controllers.IServices;
    using Ets.SingleApi.Model;
    using Ets.SingleApi.Model.Repository;
    using Ets.SingleApi.Model.Services;
    using Ets.SingleApi.Services.IDetailServices;
    using Ets.SingleApi.Services.IRepository;
    using Ets.SingleApi.Utility;

    /// <summary>
    /// 类名称：HuangTaiJiOrderServicesTemp
    /// 命名空间：Ets.SingleApi.Services
    /// 类功能：订单功能
    /// </summary>
    /// 创建者：殷超
    /// 创建日期：10/22/2013 6:16 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class HuangTaiJiOrderServicesTemp : IHuangTaiJiOrderServicesTemp
    {
        /// <summary>
        /// 字段supplierEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：10/22/2013 8:45 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<SupplierEntity> supplierEntityRepository;

        /// <summary>
        /// 字段customerEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：10/22/2013 8:47 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<CustomerEntity> customerEntityRepository;

        /// <summary>
        /// 字段deliveryEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：10/23/2013 8:44 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<DeliveryEntity> deliveryEntityRepository;

        /// <summary>
        /// 字段paymentEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：11/22/2013 3:39 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<PaymentEntity> paymentEntityRepository;

        /// <summary>
        /// 字段deliveryAddressEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：11/22/2013 3:39 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<DeliveryAddressEntity> deliveryAddressEntityRepository;

        /// <summary>
        /// 字段waiMaiOrderDetailServices
        /// </summary>
        /// 创建者：周超
        /// 创建日期：10/22/2013 8:30 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly IWaiMaiOrderDetailServices waiMaiOrderDetailServices;

        /// <summary>
        /// 字段orderNumberList
        /// </summary>
        /// 创建者：周超
        /// 创建日期：10/31/2013 9:09 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly List<IOrderNumber> orderNumberList;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderServicesTemp" /> class.
        /// </summary>
        /// <param name="supplierEntityRepository">The supplierEntityRepository</param>
        /// <param name="customerEntityRepository">The customerEntityRepository</param>
        /// <param name="deliveryEntityRepository">The deliveryEntityRepository</param>
        /// <param name="paymentEntityRepository">The paymentEntityRepository</param>
        /// <param name="deliveryAddressEntityRepository">The deliveryAddressEntityRepository</param>
        /// <param name="waiMaiOrderDetailServices">The waiMaiOrderDetailServices</param>
        /// <param name="orderNumberList">The orderNumberList</param>
        /// 创建者：周超
        /// 创建日期：10/22/2013 8:30 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public HuangTaiJiOrderServicesTemp(
            INHibernateRepository<SupplierEntity> supplierEntityRepository,
            INHibernateRepository<CustomerEntity> customerEntityRepository,
            INHibernateRepository<DeliveryEntity> deliveryEntityRepository,
            INHibernateRepository<PaymentEntity> paymentEntityRepository,
            INHibernateRepository<DeliveryAddressEntity> deliveryAddressEntityRepository,
            IWaiMaiOrderDetailServices waiMaiOrderDetailServices,
            List<IOrderNumber> orderNumberList)
        {
            this.supplierEntityRepository = supplierEntityRepository;
            this.customerEntityRepository = customerEntityRepository;
            this.deliveryEntityRepository = deliveryEntityRepository;
            this.paymentEntityRepository = paymentEntityRepository;
            this.deliveryAddressEntityRepository = deliveryAddressEntityRepository;
            this.waiMaiOrderDetailServices = waiMaiOrderDetailServices;
            this.orderNumberList = orderNumberList;
        }

        /// <summary>
        /// 取得外卖订单详情
        /// </summary>
        /// <param name="orderId">The orderId</param>
        /// <param name="userId">The userId</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：10/23/2013 9:26 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<HuangTaiJiWaiMaiOrderDetailModel> GetWaiMaiOrder(int orderId, int userId)
        {
            var customer = this.customerEntityRepository.EntityQueryable.Where(p => p.LoginId == userId).Select(p => new { p.CustomerId, p.LoginId }).FirstOrDefault();
            if (customer == null)
            {
                return new ServicesResult<HuangTaiJiWaiMaiOrderDetailModel>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidUserIdCode,
                    Result = new HuangTaiJiWaiMaiOrderDetailModel()
                };
            }

            var deliveryEntity = (from entity in this.deliveryEntityRepository.EntityQueryable
                                  where entity.OrderNumber == orderId && entity.CustomerId == customer.CustomerId
                                  select entity).FirstOrDefault();

            if (deliveryEntity == null)
            {
                return new ServicesResult<HuangTaiJiWaiMaiOrderDetailModel>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidOrderIdCode,
                    Result = new HuangTaiJiWaiMaiOrderDetailModel()
                };
            }

            var waiMaiOrderDishList = deliveryEntity.OrderList.Select(p => new HuangTaiJiWaiMaiOrderDishModel
            {
                SupplierDishId = p.SupplierDishId,
                SupplierDishName = p.SupplierDishName,
                Price = p.SupplierPrice,
                Quantity = p.Quantity,
                OrderParentId = p.OrderSource,
                SpecialInstruction = p.SpecialInstruction,
                OrderId = p.OrderId
            }).ToList();

            // 级联获取子order信息
            getOrderInfoCascade(waiMaiOrderDishList, deliveryEntity);

            var supplierId = deliveryEntity.SupplierId;
            var supplierEntity = this.supplierEntityRepository.FindSingleByExpression(p => p.SupplierId == supplierId);
            if (supplierEntity == null)
            {
                return new ServicesResult<HuangTaiJiWaiMaiOrderDetailModel>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidSupplierIdCode,
                    Result = new HuangTaiJiWaiMaiOrderDetailModel()
                };
            }

            decimal baIduLat;
            decimal.TryParse(supplierEntity.BaIduLat, out baIduLat);
            decimal baIduLong;
            decimal.TryParse(supplierEntity.BaIduLong, out baIduLong);

            var paymentEntity = this.paymentEntityRepository.EntityQueryable.FirstOrDefault(p => p.Delivery.DeliveryId == deliveryEntity.DeliveryId);
            var deliveryAddressEntity = this.deliveryAddressEntityRepository.EntityQueryable.FirstOrDefault(p => p.DeliveryAddressId == deliveryEntity.DeliveryAddressId);
            var result = new HuangTaiJiWaiMaiOrderDetailModel
            {
                OrderId = deliveryEntity.OrderNumber.HasValue ? deliveryEntity.OrderNumber.Value : 0,
                OrderTypeId = (int)OrderType.WaiMai,
                OrderStatusId = deliveryEntity.OrderStatusId,
                DateReserved = deliveryEntity.DateAdded == null ? string.Empty : deliveryEntity.DateAdded.Value.ToString("yyyy-MM-dd HH:mm"),
                DeliveryTime = deliveryEntity.DeliveryDate == null ? string.Empty : deliveryEntity.DeliveryDate.Value.ToString("yyyy-MM-dd HH:mm"),
                DeliveryInstruction = deliveryEntity.DeliveryInstruction ?? string.Empty,
                CustomerTotal = (deliveryEntity.CustomerTotal ?? 0).ToString("#0.00"),
                Total = (deliveryEntity.Total ?? 0).ToString("#0.00"),
                Coupon = Math.Max(((deliveryEntity.Total ?? 0) - (deliveryEntity.CustomerTotal ?? 0)), 0).ToString("#0.00"),
                Commission = "0.00",
                RealSupplierType = deliveryEntity.RealSupplierType,
                SupplierId = supplierEntity.SupplierId,
                SupplierName = supplierEntity.SupplierName ?? string.Empty,
                SupplierTelephone = supplierEntity.Telephone ?? string.Empty,
                SupplierAddress = string.Format("{0}{1}", supplierEntity.Address1, supplierEntity.Address2),
                SupplierBaIduLat = baIduLat,
                SupplierBaIduLong = baIduLong,
                DeliveryMethodId = deliveryEntity.DeliveryMethodId,
                InvoiceTitle = deliveryEntity.InvoiceTitle ?? string.Empty,
                IsPaid = deliveryEntity.IsPaId ?? false,
                DishList = waiMaiOrderDishList,
                PaymentMethodId = paymentEntity == null ? (int?)null : paymentEntity.PaymentMethodId,
                IsConfirm = paymentEntity != null,
                DeliveryAddress = deliveryAddressEntity == null ? string.Empty : string.Format("{0}{1}", deliveryAddressEntity.Address1, deliveryAddressEntity.Address2),
            };

            return new ServicesResult<HuangTaiJiWaiMaiOrderDetailModel>
            {
                StatusCode = (int)StatusCode.Succeed.Ok,
                Result = result
            };
        }

        // 根据orderSource产生级联关系
        private void getOrderInfoCascade(List<HuangTaiJiWaiMaiOrderDishModel> waiMaiOrderDishList, DeliveryEntity deliveryEntity)
        {
            // 根据一级订单ID，查询对应的子订单
            if (waiMaiOrderDishList != null)
            {
                foreach (HuangTaiJiWaiMaiOrderDishModel model in waiMaiOrderDishList)
                {
                    // orderSource暂时被作为pid使用 TODO
                    var childWaiMaiOrderDishList = deliveryEntity.OrderList.Where(p => p.OrderSource == model.OrderId).Select(p => new HuangTaiJiWaiMaiOrderDishModel
                    {
                        OrderId = p.OrderId,
                        SupplierDishId = p.SupplierDishId,
                        SupplierDishName = p.SupplierDishName,
                        SpecialInstruction = p.SpecialInstruction,
                        Price = p.SupplierPrice,
                        Quantity = p.Quantity,
                        OrderParentId = p.OrderSource
                    }).ToList();

                    if (childWaiMaiOrderDishList != null && childWaiMaiOrderDishList.Count > 0)
                    {
                        getOrderInfoCascade(childWaiMaiOrderDishList, deliveryEntity);
                        model.list = childWaiMaiOrderDishList;
                    }
                }
            }
        }

        ///// <summary>
        ///// 添加一个外卖订单
        ///// </summary>
        ///// <param name="parameter">The parameter</param>
        ///// <returns>
        ///// 返回结果
        ///// </returns>
        ///// 创建者：周超
        ///// 创建日期：10/22/2013 6:09 PM
        ///// 修改者：
        ///// 修改时间：
        ///// ----------------------------------------------------------------------------------------
        //public ServicesResult<AddWaiMaiOrderModel> AddWaiMaiOrder(AddWaiMaiOrderParameter parameter)
        //{
        //    if (parameter == null)
        //    {
        //        return new ServicesResult<AddWaiMaiOrderModel>
        //        {
        //            StatusCode = (int)StatusCode.System.InvalidRequest,
        //            Result = new AddWaiMaiOrderModel()
        //        };
        //    }

        //    if (!this.customerEntityRepository.EntityQueryable.Any(p => p.LoginId == parameter.UserId))
        //    {
        //        return new ServicesResult<AddWaiMaiOrderModel>
        //        {
        //            StatusCode = (int)StatusCode.Validate.InvalidUserIdCode,
        //            Result = new AddWaiMaiOrderModel()
        //        };
        //    }

        //    if (!this.supplierEntityRepository.EntityQueryable.Any(p => p.SupplierId == parameter.SupplierId))
        //    {
        //        return new ServicesResult<AddWaiMaiOrderModel>
        //        {
        //            StatusCode = (int)StatusCode.Validate.InvalidSupplierIdCode,
        //            Result = new AddWaiMaiOrderModel()
        //        };
        //    }

        //    var result = this.waiMaiOrderDetailServices.AddOrder(parameter);
        //    return new ServicesResult<AddWaiMaiOrderModel>
        //    {
        //        StatusCode = result.StatusCode,
        //        Result = result.Result
        //    };
        //}

        ///// <summary>
        ///// 确认外卖订单
        ///// </summary>
        ///// <param name="parameter">订单数据</param>
        ///// <returns>
        ///// 返回结果
        ///// </returns>
        ///// 创建者：周超
        ///// 创建日期：10/23/2013 5:32 PM
        ///// 修改者：
        ///// 修改时间：
        ///// ----------------------------------------------------------------------------------------
        //public ServicesResult<ConfirmWaiMaiOrderModel> ConfirmWaiMaiOrder(ConfirmWaiMaiOrderParameter parameter)
        //{
        //    if (parameter == null)
        //    {
        //        return new ServicesResult<ConfirmWaiMaiOrderModel>
        //        {
        //            StatusCode = (int)StatusCode.System.InvalidRequest,
        //            Result = new ConfirmWaiMaiOrderModel()
        //        };
        //    }

        //    if (!this.customerEntityRepository.EntityQueryable.Any(p => p.LoginId == parameter.UserId))
        //    {
        //        return new ServicesResult<ConfirmWaiMaiOrderModel>
        //        {
        //            StatusCode = (int)StatusCode.Validate.InvalidUserIdCode,
        //            Result = new ConfirmWaiMaiOrderModel()
        //        };
        //    }

        //    if (!this.deliveryEntityRepository.EntityQueryable.Any(p => p.OrderNumber == parameter.OrderId))
        //    {
        //        return new ServicesResult<ConfirmWaiMaiOrderModel>
        //        {
        //            StatusCode = (int)StatusCode.Validate.InvalidUserIdCode,
        //            Result = new ConfirmWaiMaiOrderModel()
        //        };
        //    }

        //    var result = this.waiMaiOrderDetailServices.ConfirmOrder(parameter);
        //    return new ServicesResult<ConfirmWaiMaiOrderModel>
        //    {
        //        StatusCode = result.StatusCode,
        //        Result = result.Result
        //    };
        //}

        ///// <summary>
        ///// 订单外卖支付
        ///// </summary>
        ///// <param name="parameter">订单数据</param>
        ///// <returns>
        ///// 返回结果
        ///// </returns>
        ///// 创建者：周超
        ///// 创建日期：10/23/2013 5:32 PM
        ///// 修改者：
        ///// 修改时间：
        ///// ----------------------------------------------------------------------------------------
        //public ServicesResult<PaymentWaiMaiOrderModel> PaymentWaiMaiOrder(PaymentWaiMaiOrderParameter parameter)
        //{
        //    if (parameter == null)
        //    {
        //        return new ServicesResult<PaymentWaiMaiOrderModel>
        //        {
        //            StatusCode = (int)StatusCode.System.InvalidRequest,
        //            Result = new PaymentWaiMaiOrderModel()
        //        };
        //    }

        //    if (!this.deliveryEntityRepository.EntityQueryable.Any(p => p.OrderNumber == parameter.OrderId))
        //    {
        //        return new ServicesResult<PaymentWaiMaiOrderModel>
        //        {
        //            StatusCode = (int)StatusCode.Validate.InvalidUserIdCode,
        //            Result = new PaymentWaiMaiOrderModel()
        //        };
        //    }

        //    if (!this.customerEntityRepository.EntityQueryable.Any(p => p.LoginId == parameter.UserId))
        //    {
        //        return new ServicesResult<PaymentWaiMaiOrderModel>
        //        {
        //            StatusCode = (int)StatusCode.Validate.InvalidUserIdCode,
        //            Result = new PaymentWaiMaiOrderModel()
        //        };
        //    }

        //    var result = this.waiMaiOrderDetailServices.PaymentOrder(parameter);
        //    return new ServicesResult<PaymentWaiMaiOrderModel>
        //    {
        //        StatusCode = result.StatusCode,
        //        Result = result.Result
        //    };
        //}

        ///// <summary>
        ///// 获取订单号
        ///// </summary>
        ///// <param name="orderType">订单类型：0 外卖，1 堂食，2 订台</param>
        ///// <returns>
        ///// 返回结果
        ///// </returns>
        ///// 创建者：周超
        ///// 创建日期：10/31/2013 9:01 PM
        ///// 修改者：
        ///// 修改时间：
        ///// ----------------------------------------------------------------------------------------
        //public ServicesResult<string> GetOrderNumber(int orderType)
        //{
        //    var orderNumber = this.orderNumberList.FirstOrDefault(p => p.OrderType == (OrderType)orderType);
        //    if (orderNumber == null)
        //    {
        //        return new ServicesResult<string>
        //            {
        //                StatusCode = (int)StatusCode.Validate.InvalidOrderTypeCode
        //            };
        //    }

        //    var result = orderNumber.GetOrderNumber();
        //    return new ServicesResult<string>
        //    {
        //        StatusCode = result.StatusCode,
        //        Result = result.OrderNumber.ToString()
        //    };
        //}
    }
}