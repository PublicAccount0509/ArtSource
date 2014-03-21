using System;
using System.Collections.Generic;
using System.Linq;
using Castle.Services.Transaction;
using Ets.SingleApi.Model;
using Ets.SingleApi.Model.Repository;
using Ets.SingleApi.Model.Services;
using Ets.SingleApi.Services.ICacheServices;
using Ets.SingleApi.Services.IExternalServices;
using Ets.SingleApi.Services.IRepository;
using Ets.SingleApi.Utility;

namespace Ets.SingleApi.Services
{
    /// <summary>
    /// 类名称：EtsWapDingTaiOrderProvider
    /// 命名空间：Ets.SingleApi.Services
    /// 类功能：订台订单
    /// </summary>
    /// 创建者：苏建峰
    /// 创建日期：3/18/2014 12:00 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    [Transactional]
    public class EtsWapDingTaiOrderProvider : DingTaiOrderProvider
    {
        /// <summary>
        /// 字段tableReservationEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：10/22/2013 8:41 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<TableReservationEntity> tableReservationEntityRepository;

        /// <summary>
        /// 字段paymentEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：11/9/2013 10:30 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<PaymentRecordEntity> paymentRecordEntityRepository;

        /// <summary>
        /// 字段orderDetailEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：10/22/2013 8:41 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<OrderDetailEntity> orderDetailEntityRepository;

        /// <summary>
        /// 字段supplierEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：10/23/2013 4:32 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<SupplierEntity> supplierEntityRepository;

        /// <summary>
        /// 字段etsWapShoppingCartProvider
        /// </summary>
        /// 创建者：周超
        /// 创建日期：11/22/2013 3:26 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly IEtsWapDingTaiShoppingCartProvider etsWapDingTaiShoppingCartProvider;

        /// <summary>
        /// The shopping cart base cache services
        /// </summary>
        /// 创建者：苏建峰
        /// 创建日期：3/20/2014 10:32 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly IShoppingCartBaseCacheServices shoppingCartBaseCacheServices;

        /// <summary>
        /// Initializes a new instance of the <see cref="EtsWapDingTaiOrderProvider"/> class.
        /// </summary>
        /// <param name="tableReservationEntityRepository">The table reservation entity repository.</param>
        /// <param name="paymentRecordEntityRepository">The payment record entity repository.</param>
        /// <param name="orderDetailEntityRepository">The order detail entity repository.</param>
        /// <param name="supplierEntityRepository">The supplier entity repository.</param>
        /// <param name="etsWapShoppingCartProvider">The ets wap shopping cart provider.</param>
        /// <param name="shoppingCartBaseCacheServices">The shopping cart base cache services.</param>
        /// <param name="orderNumberDtEntityRepository">The order number dt entity repository.</param>
        /// <param name="singleApiOrdersExternalService">The single API orders external service.</param>
        /// 创建者：苏建峰
        /// 创建日期：3/20/2014 10:39 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public EtsWapDingTaiOrderProvider(
            INHibernateRepository<TableReservationEntity> tableReservationEntityRepository,
            INHibernateRepository<PaymentRecordEntity> paymentRecordEntityRepository,
            INHibernateRepository<OrderDetailEntity> orderDetailEntityRepository,
            INHibernateRepository<SupplierEntity> supplierEntityRepository,
            IEtsWapDingTaiShoppingCartProvider etsWapDingTaiShoppingCartProvider,
            IShoppingCartBaseCacheServices shoppingCartBaseCacheServices,
            INHibernateRepository<OrderNumberDtEntity> orderNumberDtEntityRepository,
              ISingleApiOrdersExternalService singleApiOrdersExternalService)
            : base(orderNumberDtEntityRepository, singleApiOrdersExternalService)
        {
            this.tableReservationEntityRepository = tableReservationEntityRepository;
            this.paymentRecordEntityRepository = paymentRecordEntityRepository;
            this.orderDetailEntityRepository = orderDetailEntityRepository;
            this.supplierEntityRepository = supplierEntityRepository;
            this.etsWapDingTaiShoppingCartProvider = etsWapDingTaiShoppingCartProvider;
            this.shoppingCartBaseCacheServices = shoppingCartBaseCacheServices;
        }

        public override ServicesResult<IOrderDetailModel> GetOrder(string source, int orderId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 保存订单信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="shoppingCartId">购物车Id</param>
        /// <param name="appKey">The appKey</param>
        /// <param name="appPassword">The appPassword</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/20 16:01
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [Transaction(TransactionMode.RequiresNew)]
        public override ServicesResult<string> SaveOrder(string source, string shoppingCartId, string appKey, string appPassword)
        {
            var getShoppingCartLinkResult = this.etsWapDingTaiShoppingCartProvider.GetShoppingCartLink(source, shoppingCartId);
            if (getShoppingCartLinkResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<string>
                {
                    StatusCode = getShoppingCartLinkResult.StatusCode,
                    Result = string.Empty
                };
            }

            /*购物车信息*/
            var shoppingCartLink = getShoppingCartLinkResult.Result;
            var getShoppingCartResult = this.etsWapDingTaiShoppingCartProvider.GetShoppingCart(source, shoppingCartLink.ShoppingCartId);
            if (getShoppingCartResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<string>
                {
                    StatusCode = getShoppingCartResult.StatusCode,
                    Result = string.Empty
                };
            }

            /*商户信息*/
            var getShoppingCartSupplierResult = this.etsWapDingTaiShoppingCartProvider.GetShoppingCartSupplier(source, shoppingCartLink.SupplierId);
            if (getShoppingCartSupplierResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<string>
                {
                    StatusCode = getShoppingCartSupplierResult.StatusCode,
                    Result = string.Empty
                };
            }

            /*用户信息*/
            var getShoppingCartCustomerResult = this.etsWapDingTaiShoppingCartProvider.GetShoppingCartCustomer(source, shoppingCartLink.UserId);
            if (getShoppingCartCustomerResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<string>
                {
                    StatusCode = getShoppingCartCustomerResult.StatusCode,
                    Result = string.Empty
                };
            }

            /*订单信息*/
            var getShoppingCartOrderResult = this.etsWapDingTaiShoppingCartProvider.GetShoppingCartOrder(source, shoppingCartLink.OrderId);
            if (getShoppingCartOrderResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<string>
                {
                    StatusCode = getShoppingCartOrderResult.StatusCode,
                    Result = string.Empty
                };
            }

            /*Delivery信息表*/
            var getShoppingCartDeliveryResult = this.etsWapDingTaiShoppingCartProvider.GetShoppingCartDelivery(source, shoppingCartLink.DeliveryId);
            if (getShoppingCartDeliveryResult.StatusCode != (int) StatusCode.Succeed.Ok)
            {
                return new ServicesResult<string>
                    {
                        StatusCode = getShoppingCartDeliveryResult.StatusCode,
                        Result = string.Empty
                    };
            }

            var shoppingCart = getShoppingCartResult.Result;
            var supplier = getShoppingCartSupplierResult.Result;
            var customer = getShoppingCartCustomerResult.Result;
            var order = getShoppingCartOrderResult.Result;
            var delivery = getShoppingCartDeliveryResult.Result;
           

            var shoppingCartBase = this.shoppingCartBaseCacheServices.GetShoppingCartBase(source, shoppingCartId);
            if (shoppingCartBase.Result.IsComplete)
            {
                return new ServicesResult<string>
                {
                    Result = shoppingCartBase.Result.OrderNumber.ToString()
                };
            }

            var shoppingList = shoppingCart.ShoppingList ?? new List<ShoppingCartItem>();
            /*if (shoppingList.Count == 0)
            {
                return new ServicesResult<string>
                {
                    StatusCode = (int)StatusCode.Validate.EmptyShoppingCartCode,
                    Result = string.Empty
                };
            }*/

            var supplierId = supplier.SupplierId;
            var supplierEntity = this.supplierEntityRepository.FindSingleByExpression(p => p.SupplierId == supplierId);
            if (supplierEntity == null)
            {
                return new ServicesResult<string>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidSupplierIdCode,
                    Result = string.Empty
                };
            }

            
            var orderId = shoppingCartBase.Result.OrderNumber <= 0 ? this.GetOrderNumberId(source, appKey, appPassword) : shoppingCartBase.Result.OrderNumber;
            if (orderId <= 0)
            {
                return new ServicesResult<string>
                {
                    StatusCode = (int)StatusCode.General.OrderNumberNotFound,
                    Result = string.Empty
                };
            }

            var customerId = customer.CustomerId;
            var tableReservationId = this.SaveTableReservationEntity(orderId, supplier.SupplierId, customer.CustomerId, delivery, order);
            this.SaveOrderDetailEntity(customerId, tableReservationId, shoppingList);
            this.SavePaymentEntity(tableReservationId, order.CustomerTotalFee, order.PaymentMethodId, order.PayBank);

            /*var deliveryId = order.DeliveryMethodId == ServicesCommon.PickUpDeliveryMethodId
                ? this.SavePickUpDeliveryEntity(orderId, supplier.SupplierId, customer.CustomerId, delivery, order)
                : this.SaveDeliveryEntity(orderId, supplier.SupplierId, customer.CustomerId, delivery, order);*/

            //this.SaveSupplierCommission(deliveryId, totalFee, supplierEntity);
            //this.SaveOrderEntity(customerId, deliveryId, shoppingList);
            //this.SavePaymentEntity(deliveryId, order.CustomerTotalFee, order.PaymentMethodId, order.PayBank);



            this.shoppingCartBaseCacheServices.SaveShoppingCartId(source, orderId, shoppingCartId);
            this.shoppingCartBaseCacheServices.SaveShoppingCartComplete(source, shoppingCartId, true);
            return new ServicesResult<string>
            {
                StatusCode = (int)StatusCode.Succeed.Ok,
                Result = orderId.ToString()
            };
        }

        protected override OrderSourceType GetOrderSourceType()
        {
            throw new NotImplementedException();
        }

        public override ServicesResult<bool> ModifyOrderPaymentMethod(string source, string shoppingCartId, int paymentMethodId, string payBank)
        {
            throw new NotImplementedException();
        }

        public override ServicesResult<OrderShoppingCartStatusModel> GetOrderShoppingCartStatus(string source, string shoppingCartId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 保存自提订单详情
        /// </summary>
        /// <param name="orderId">订单Id</param>
        /// <param name="supplierId">餐厅Id</param>
        /// <param name="customerId">The customerId</param>
        /// <param name="delivery">The delivery</param>
        /// <param name="order">订单信息</param>
        /// <returns>
        /// 返回订单信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/22/2013 5:16 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private int SaveTableReservationEntity(int orderId, int supplierId, int customerId, ShoppingCartDelivery delivery, EtsWapDingTaiShoppingCartOrder order)
        {
            var tableReservationEntity = this.tableReservationEntityRepository.FindSingleByExpression(p => p.OrderNumber == orderId) ?? new TableReservationEntity
            {
                Supplier = new SupplierEntity
                {
                    SupplierId = supplierId
                },

                CustomerId = customerId,
                OrderNumber = orderId,
                TableStatus = 1,
                DateReserved = DateTime.Now,
                IsPaId = false,
                IsRating = false,
                Cancelled = false,
                IsAdd = false,
                IsDeal = true,
                IsReminder = true,
                IsService = true
            };

            tableReservationEntity.Type = order.DingTaiMethodId;
            tableReservationEntity.OrderNotes = order.OrderInstruction;
            tableReservationEntity.CustomerTotal = order.CustomerTotalFee;
            tableReservationEntity.Total = order.TotalFee;
            tableReservationEntity.ConsumerAmount = order.ServiceFee;
            tableReservationEntity.TeaBitFee = order.TeaBitFee;
            tableReservationEntity.ModifyDate = DateTime.Now;
            tableReservationEntity.NumberOfPeople = order.DinnerNumber;
            tableReservationEntity.TabelNo = order.SeatNumber;
            tableReservationEntity.CouponCode = order.CouponCode;
            tableReservationEntity.ContactNumber = delivery.Telephone;
            tableReservationEntity.Contactsex = delivery.Gender;
            tableReservationEntity.ContactName = delivery.Name;
            tableReservationEntity.InvoiceRequired = order.InvoiceRequired;
            tableReservationEntity.InvoiceTitle = order.InvoiceTitle;
            tableReservationEntity.Path = order.Path;
            tableReservationEntity.TemplateId = order.Template;

            this.tableReservationEntityRepository.Save(tableReservationEntity);
            return tableReservationEntity.TableReservationId;
        }

        /// <summary>
        /// 保存订单详情信息
        /// </summary>
        /// <param name="customerId">顾客Id</param>
        /// <param name="orderId">订单Id</param>
        /// <param name="shoppingList">商品列表</param>
        /// 创建者：周超
        /// 创建日期：11/22/2013 5:26 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private void SaveOrderDetailEntity(int customerId, int orderId, IEnumerable<ShoppingCartItem> shoppingList)
        {
            var removeOrderList = this.orderDetailEntityRepository.FindByExpression(p => p.CustomerId == customerId && p.OrderId == orderId).ToList();
            this.orderDetailEntityRepository.Remove(removeOrderList);

            var orderList = (from dish in shoppingList
                             select new OrderDetailEntity
                             {
                                 OrderId = orderId,
                                 CustomerId = customerId,
                                 SupplierDishId = dish.ItemId,
                                 Quantity = dish.Quantity,
                                 SupplierPrice = dish.Price,
                                 SupplierDishName = dish.ItemName,
                                 Total = dish.Price * dish.Quantity,
                                 SpecialInstruction = dish.Instruction,
                                 OrderDate = DateTime.Now,
                                 IsAdd = false,
                                 OrderType = 1
                             }).ToList();

            this.orderDetailEntityRepository.Save(orderList);
        }

        /// <summary>
        /// 保存支付信息
        /// </summary>
        /// <param name="orderId">订单Id</param>
        /// <param name="customerTotal">支付总金额</param>
        /// <param name="paymentMethodId">支付方式</param>
        /// <param name="payBank">The payBank</param>
        /// 创建者：周超
        /// 创建日期：11/23/2013 11:07 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private void SavePaymentEntity(int orderId, decimal customerTotal, int paymentMethodId, string payBank)
        {
            if (paymentMethodId <= 0)
            {
                return;
            }

            var tableReservationId = orderId.ToString();
            var paymentRecordEntity = this.paymentRecordEntityRepository.EntityQueryable.FirstOrDefault(p => p.OrderId == tableReservationId)
                                 ?? new PaymentRecordEntity
                                 {
                                     PaymentTypeId = 1,
                                     OrderId = tableReservationId,
                                     PaymentDate = DateTime.Now
                                 };

            paymentRecordEntity.Amount = customerTotal;
            paymentRecordEntity.OrderTypeId = 1; //订台 2 堂食 1
            paymentRecordEntity.PaymentMethodId = paymentMethodId;
            paymentRecordEntity.PayBank = payBank;
            this.paymentRecordEntityRepository.Save(paymentRecordEntity);
        }
    }
}
