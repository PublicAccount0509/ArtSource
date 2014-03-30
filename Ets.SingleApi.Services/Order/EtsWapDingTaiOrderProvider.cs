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
        /// The desk booking entity repository
        /// </summary>
        /// 创建者：苏建峰
        /// 创建日期：3/21/2014 3:25 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<DeskBookingEntity> deskBookingEntityRepository;

        /// <summary>
        /// 字段deskTypeEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：3/22/2014 9:25 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<DeskTypeEntity> deskTypeEntityRepository;

        /// <summary>
        /// 字段supplierDeskEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：3/22/2014 9:21 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<SupplierDeskEntity> supplierDeskEntityRepository;

        /// <summary>
        /// 字段supplierDeskTimeEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：3/24/2014 9:26 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<SupplierDeskTimeEntity> supplierDeskTimeEntityRepository;

        /// <summary>
        /// 字段deskTypeLockLogEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：3/25/2014 2:50 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<DeskTypeLockLogEntity> deskTypeLockLogEntityRepository;

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
        /// Initializes a new instance of the <see cref="EtsWapDingTaiOrderProvider" /> class.
        /// </summary>
        /// <param name="tableReservationEntityRepository">The table reservation entity repository.</param>
        /// <param name="paymentRecordEntityRepository">The payment record entity repository.</param>
        /// <param name="orderDetailEntityRepository">The order detail entity repository.</param>
        /// <param name="supplierEntityRepository">The supplier entity repository.</param>
        /// <param name="deskBookingEntityRepository">The desk booking entity repository.</param>
        /// <param name="deskTypeEntityRepository">The deskTypeEntityRepository</param>
        /// <param name="supplierDeskEntityRepository">The supplierDeskEntityRepository</param>
        /// <param name="supplierDeskTimeEntityRepository">The supplierDeskTimeEntityRepository</param>
        /// <param name="deskTypeLockLogEntityRepository">The deskTypeLockLogEntityRepository</param>
        /// <param name="etsWapDingTaiShoppingCartProvider">The ets wap ding tai shopping cart provider.</param>
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
            INHibernateRepository<DeskBookingEntity> deskBookingEntityRepository,
            INHibernateRepository<DeskTypeEntity> deskTypeEntityRepository,
            INHibernateRepository<SupplierDeskEntity> supplierDeskEntityRepository,
            INHibernateRepository<SupplierDeskTimeEntity> supplierDeskTimeEntityRepository,
            INHibernateRepository<DeskTypeLockLogEntity> deskTypeLockLogEntityRepository,
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
            this.deskBookingEntityRepository = deskBookingEntityRepository;
            this.deskTypeEntityRepository = deskTypeEntityRepository;
            this.supplierDeskEntityRepository = supplierDeskEntityRepository;
            this.supplierDeskTimeEntityRepository = supplierDeskTimeEntityRepository;
            this.deskTypeLockLogEntityRepository = deskTypeLockLogEntityRepository;
            this.etsWapDingTaiShoppingCartProvider = etsWapDingTaiShoppingCartProvider;
            this.shoppingCartBaseCacheServices = shoppingCartBaseCacheServices;
        }

        /// <summary>
        /// 取得订单详情
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="orderId">订单状态</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：10/23/2013 9:26 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        /// 创建者：苏建峰
        /// 创建日期：3/21/2014 1:58 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public override ServicesResult<IOrderDetailModel> GetOrder(string source, int orderId)
        {
            /*订台订单信息*/
            var tableReservationEntity = (from entity in this.tableReservationEntityRepository.EntityQueryable
                                          where entity.OrderNumber == orderId
                                          select entity).FirstOrDefault();

            if (tableReservationEntity == null)
            {
                return new ServicesResult<IOrderDetailModel>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidOrderIdCode,
                    Result = new DingTaiOrderDetailModel()
                };
            }

            /*菜品明细*/
            var dingTaiOrderDishList = (from entity in this.orderDetailEntityRepository.EntityQueryable
                                        where entity.OrderId == tableReservationEntity.TableReservationId
                                        select new DingTaiOrderDishModel
                                        {
                                            SupplierDishId = entity.SupplierDishId ?? 0,
                                            SupplierDishName = entity.SupplierDishName,
                                            Instruction = entity.SpecialInstruction,
                                            Price = entity.SupplierPrice,
                                            Quantity = entity.Quantity ?? 0
                                        }).ToList();

            /*订台信息*/
            var dingTaiOrderDesk = (from deskBookingEntity in this.deskBookingEntityRepository.EntityQueryable
                                    where deskBookingEntity.OrderNo == orderId
                                    select new DingTaiOrderDeskModel
                                   {
                                       DeskNo = deskBookingEntity.Desk.DeskNo,
                                       RoomType = deskBookingEntity.DeskType.RoomType ?? 0,// == null ? "" : (deskBookingEntity.DeskType.RoomType == 0 ? "散座" : "包房"),
                                       RoomTypeName = deskBookingEntity.DeskType == null
                                                       ? string.Empty : (deskBookingEntity.DeskType.RoomType == 0
                                                       ? deskBookingEntity.DeskType.TableType.TblTypeName : "包房"),
                                       MaxNumber = deskBookingEntity.DeskType.MaxNumber,
                                       MinNumber = deskBookingEntity.DeskType.MinNumber,
                                       TblTypeName = deskBookingEntity.DeskType.TableType.TblTypeName,
                                       LowCost = deskBookingEntity.DeskType.LowCost,
                                       DepositAmount = deskBookingEntity.DeskType.DepositAmount
                                   }
                              ).FirstOrDefault();

            /*餐厅信息*/
            var supplierId = tableReservationEntity.Supplier.SupplierId;
            var supplierEntity = this.supplierEntityRepository.FindSingleByExpression(p => p.SupplierId == supplierId);
            if (supplierEntity == null)
            {
                return new ServicesResult<IOrderDetailModel>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidSupplierIdCode,
                    Result = new DingTaiOrderDetailModel()
                };
            }

            /*餐厅地理经纬度*/
            decimal baIduLat;
            decimal.TryParse(supplierEntity.BaIduLat, out baIduLat);
            decimal baIduLong;
            decimal.TryParse(supplierEntity.BaIduLong, out baIduLong);
            var tableReservationId = tableReservationEntity.TableReservationId.ToString();

            /*支付信息*/
            var paymentEntity = this.paymentRecordEntityRepository.EntityQueryable.FirstOrDefault(p => p.OrderId == tableReservationId);
            var gender = tableReservationEntity.Contactsex;
            if (gender.IsEmptyOrNull())
            {
                gender = ServicesCommon.DefaultGender.ToString();
            }

            if (string.Equals(gender, ServicesCommon.FemaleGender, StringComparison.OrdinalIgnoreCase)
                || string.Equals(gender, "1", StringComparison.OrdinalIgnoreCase))
            {
                gender = "1";
            }
            else
            {
                gender = "0";
            }

            //总价 未折扣
            var total = tableReservationEntity.Total ?? 0;
            //总价 折扣后
            var customerTotal = tableReservationEntity.CustomerTotal ?? 0;
            //折扣
            var coupon = Math.Max(total - customerTotal, 0);

            var shoppingCartResult = this.shoppingCartBaseCacheServices.GetShoppingCartId(source, orderId);
            var shoppingCartId = shoppingCartResult == null ? string.Empty : shoppingCartResult.Result;

            var result = new DingTaiOrderDetailModel
            {
                ShoppingCartId = shoppingCartId,
                OrderId = tableReservationEntity.OrderNumber.HasValue ? tableReservationEntity.OrderNumber.Value : 0,
                OrderTypeId = (int)OrderType.DingTai,
                OrderStatusId = tableReservationEntity.TableStatus,
                DateReserved = tableReservationEntity.DateReserved.ToString("yyyy-MM-dd HH:mm"),
                Description = tableReservationEntity.OrderNotes ?? string.Empty,
                SupplierGroupId = supplierEntity.SupplierGroupId,
                SupplierId = supplierEntity.SupplierId,
                SupplierName = supplierEntity.SupplierName ?? string.Empty,
                SupplierTelephone = supplierEntity.Telephone ?? string.Empty,
                SupplierAddress = string.Format("{0}{1}", supplierEntity.Address1, supplierEntity.Address2),
                SupplierBaIduLat = baIduLat,
                SupplierBaIduLong = baIduLong,
                InvoiceTitle = tableReservationEntity.InvoiceTitle ?? string.Empty,
                IsPaid = tableReservationEntity.IsPaId ?? false,
                DishList = dingTaiOrderDishList,
                PaymentMethodId = paymentEntity == null ? null : paymentEntity.PaymentMethodId,
                IsConfirm = paymentEntity != null,
                ContactName = tableReservationEntity.ContactName,
                ContactNumber = tableReservationEntity.ContactNumber,
                Contactsex = gender,
                TabelNo = tableReservationEntity.TabelNo,
                TeaBitFee = (tableReservationEntity.TeaBitFee ?? 0).ToString("#0.00"),
                ServiceFee = (tableReservationEntity.ConsumerAmount ?? 0).ToString("#0.00"),
                Coupon = coupon.ToString("#0.00"),//折扣
                CustomerTotal = customerTotal.ToString("#0.00"),//总价 折扣后
                Total = total.ToString("#0.00"),//总价 未折扣
                DingTaiMethodId = (tableReservationEntity.Type ?? 2),//2 只订位，3 订位并点菜
                Desk = dingTaiOrderDesk
            };

            if (result.InvoiceTitle.IsEmptyOrNull())
            {
                result.InvoiceTitle = ServicesCommon.EmptyInvoiceTitle;
            }

            return new ServicesResult<IOrderDetailModel>
            {
                StatusCode = (int)StatusCode.Succeed.Ok,
                Result = result
            };
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

            /*Delivery信息*/
            var getShoppingCartDeliveryResult = this.etsWapDingTaiShoppingCartProvider.GetShoppingCartDelivery(source, shoppingCartLink.DeliveryId);
            if (getShoppingCartDeliveryResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<string>
                    {
                        StatusCode = getShoppingCartDeliveryResult.StatusCode,
                        Result = string.Empty
                    };
            }

            /*Desk信息*/
            var getShoppingCartDeskResult = this.etsWapDingTaiShoppingCartProvider.GetShoppingCartDesk(source, shoppingCartLink.DeskId);
            if (getShoppingCartDeskResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<string>
                    {
                        StatusCode = getShoppingCartDeskResult.StatusCode,
                        Result = string.Empty
                    };
            }

            var shoppingCart = getShoppingCartResult.Result;
            var supplier = getShoppingCartSupplierResult.Result;
            var customer = getShoppingCartCustomerResult.Result;
            var order = getShoppingCartOrderResult.Result;
            var delivery = getShoppingCartDeliveryResult.Result;
            var desk = getShoppingCartDeskResult.Result;

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
            /*保存订单信息*/
            var tableReservationId = this.SaveTableReservationEntity(orderId, supplier.SupplierId, customer.CustomerId, delivery, desk, order);
            /*保存菜品明细*/
            this.SaveOrderDetailEntity(customerId, tableReservationId, shoppingList);
            /*保存预订信息*/
            this.SaveDeskBookingEntity(supplier.SupplierId, orderId, desk);
            /*保存支付信息*/
            this.SavePaymentEntity(tableReservationId, order.CustomerTotalFee, order.PaymentMethodId, order.PayBank);
            /*锁定台位信息*/
            this.LockDeskType(desk.DeskTypeId, supplierId);

            this.shoppingCartBaseCacheServices.SaveShoppingCartId(source, orderId, shoppingCartId);
            this.shoppingCartBaseCacheServices.SaveShoppingCartComplete(source, shoppingCartId, true);
            return new ServicesResult<string>
            {
                StatusCode = (int)StatusCode.Succeed.Ok,
                Result = orderId.ToString()
            };
        }

        /// <summary>
        /// 锁定台位信息
        /// </summary>
        /// <param name="deskTypeId">The deskTypeId</param>
        /// <param name="supplierId">The supplierId</param>
        /// 创建者：周超
        /// 创建日期：3/22/2014 10:03 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private void LockDeskType(int deskTypeId, int supplierId)
        {
            var deskTypeEntity = this.deskTypeEntityRepository.FindSingleByExpression(p => p.Id == deskTypeId);
            if (deskTypeEntity == null)
            {
                return;
            }

            var now = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));
            var nowTime = DateTime.Now.ToString("HH:mm");

            var supplierDeskTimeList = (from supplierDeskTimeEntity in this.supplierDeskTimeEntityRepository.EntityQueryable
                                        where supplierDeskTimeEntity.SupplierId == supplierId && supplierDeskTimeEntity.IsEnable == true
                                        select new
                                        {
                                            supplierDeskTimeEntity.Id,
                                            supplierDeskTimeEntity.BeginTime,
                                            supplierDeskTimeEntity.EndTime,
                                            supplierDeskTimeEntity.TimeType
                                        }).ToList();


            var supplierDeskTime = supplierDeskTimeList.FirstOrDefault(p => string.Compare(p.BeginTime, nowTime, StringComparison.OrdinalIgnoreCase) <=
                                                          0
                                                          && string.Compare(p.EndTime, nowTime, StringComparison.OrdinalIgnoreCase) >= 0);
            if (supplierDeskTime == null)
            {
                return;
            }

            var deskBookingCount = this.deskBookingEntityRepository.EntityQueryable.Count(p => p.DeskType.Id == deskTypeId && p.SupplierId == supplierId && p.TimeType == supplierDeskTime.TimeType && p.ReservationTime >= now && p.ReservationTime < now.AddDays(1));
            var supplierDeskCount = this.supplierDeskEntityRepository.EntityQueryable.Count(p => p.DeskType.Id == deskTypeId && p.SupplierId == supplierId && p.IsDel == false && p.IsEnable);


            if (deskBookingCount < supplierDeskCount)
            {
                return;
            }

            var deskTypeLockLogEntity = this.deskTypeLockLogEntityRepository.FindSingleByExpression(
                   p =>
                   p.DeskTypeId == deskTypeId && p.SupplierId == supplierId && p.LockDate >= now && p.LockDate < now
                   && p.SupplierDeskTime.Id == supplierDeskTime.Id) ?? new DeskTypeLockLogEntity
                       {
                           CreateTime = DateTime.Now,
                           DeskTypeId = deskTypeId,
                           SupplierId = supplierId
                       };

            deskTypeLockLogEntity.LockDate = now;
            deskTypeLockLogEntity.IsDel = false;
            deskTypeLockLogEntity.CreateTime = DateTime.Now;
            deskTypeLockLogEntity.SupplierDeskTime = new SupplierDeskTimeEntity
                {
                    Id = supplierDeskTime.Id
                };

            this.deskTypeLockLogEntityRepository.Save(deskTypeLockLogEntity);
        }

        /// <summary>
        /// Gets the type of the order source.
        /// </summary>
        /// <returns>
        /// The OrderSourceType
        /// </returns>
        /// 创建者：单琪彬
        /// 创建日期：2/13/2014 3:06 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        protected override OrderSourceType GetOrderSourceType()
        {
            return OrderSourceType.EtsWap;
        }

        /// <summary>
        /// 更新订单的支付方式
        /// </summary>
        /// <param name="source">The sourceDefault documentation</param>
        /// <param name="shoppingCartId">The shoppingCartIdDefault documentation</param>
        /// <param name="paymentMethodId">The paymentMethodIdDefault documentation</param>
        /// <param name="payBank">The payBankDefault documentation</param>
        /// <returns>
        /// ServicesResult{System.Boolean}
        /// </returns>
        /// 创建者：王巍
        /// 创建日期：2/24/2014 11:08 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public override ServicesResult<bool> ModifyOrderPaymentMethod(string source, string shoppingCartId, int paymentMethodId, string payBank)
        {
            //获取ShoppingCartLink信息
            var getShoppingCartLinkResult = this.etsWapDingTaiShoppingCartProvider.GetShoppingCartLink(source, shoppingCartId);
            if (getShoppingCartLinkResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = getShoppingCartLinkResult.StatusCode,
                    Result = false
                };
            }

            var shoppingCartLink = getShoppingCartLinkResult.Result;

            //获取 订单信息
            var getShoppingCartOrderResult = this.etsWapDingTaiShoppingCartProvider.GetShoppingCartOrder(source, shoppingCartLink.OrderId);
            if (getShoppingCartOrderResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = getShoppingCartOrderResult.StatusCode,
                    Result = false
                };
            }

            //订单信息
            var orderInfo = getShoppingCartOrderResult.Result;
            //修改 缓存订单支付方式
            var modifyOrderPaymentMethodResult = this.etsWapDingTaiShoppingCartProvider.ModifyOrderPaymentMethod(source, orderInfo.Id, paymentMethodId, payBank);
            if (modifyOrderPaymentMethodResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = modifyOrderPaymentMethodResult.StatusCode,
                    Result = false
                };
            }

            return new ServicesResult<bool>
            {
                StatusCode = (int)StatusCode.Succeed.Ok,
                Result = true
            };
        }

        /// <summary>
        /// 查询订单是否完成，订单是否已支付
        /// </summary>
        /// <param name="source">The sourceDefault documentation</param>
        /// <param name="shoppingCartId">The shoppingCartIdDefault documentation</param>
        /// <returns>
        /// ServicesResult{OrderIsCompleteIsPaidModel}
        /// </returns>
        /// 创建者：王巍
        /// 创建日期：2/24/2014 8:06 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public override ServicesResult<OrderShoppingCartStatusModel> GetOrderShoppingCartStatus(string source, string shoppingCartId)
        {
            //获取ShoppingCartLink信息
            var getShoppingCartLinkResult = this.etsWapDingTaiShoppingCartProvider.GetShoppingCartLink(source, shoppingCartId);
            if (getShoppingCartLinkResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<OrderShoppingCartStatusModel>
                {
                    StatusCode = getShoppingCartLinkResult.StatusCode,
                    Result = new OrderShoppingCartStatusModel()
                };
            }

            var shoppingCartLink = getShoppingCartLinkResult.Result;

            //获取 订单信息
            var getShoppingCartOrderResult = this.etsWapDingTaiShoppingCartProvider.GetShoppingCartOrder(source, shoppingCartLink.OrderId);
            if (getShoppingCartOrderResult.StatusCode != (int)StatusCode.Succeed.Ok)
            {
                return new ServicesResult<OrderShoppingCartStatusModel>
                {
                    StatusCode = getShoppingCartOrderResult.StatusCode,
                    Result = new OrderShoppingCartStatusModel()
                };
            }

            var tableReservationEntity = this.tableReservationEntityRepository.EntityQueryable.FirstOrDefault(c => c.OrderNumber == getShoppingCartOrderResult.Result.OrderId);
            if (tableReservationEntity == null)
            {
                return new ServicesResult<OrderShoppingCartStatusModel>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidOrderIdCode,
                    Result = new OrderShoppingCartStatusModel()
                };
            }

            return new ServicesResult<OrderShoppingCartStatusModel>
            {
                StatusCode = getShoppingCartOrderResult.StatusCode,
                Result = new OrderShoppingCartStatusModel
                {
                    IsComplete = getShoppingCartOrderResult.Result.IsComplete,
                    IsPaid = tableReservationEntity.IsPaId ?? false,
                    OrderStatusId = tableReservationEntity.TableStatus ?? -1
                }
            };
        }

        /// <summary>
        /// 保存自提订单详情
        /// </summary>
        /// <param name="orderId">订单Id</param>
        /// <param name="supplierId">餐厅Id</param>
        /// <param name="customerId">The customerId</param>
        /// <param name="delivery">The delivery</param>
        /// <param name="desk">The desk</param>
        /// <param name="order">订单信息</param>
        /// <returns>
        /// 返回订单信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/22/2013 5:16 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private int SaveTableReservationEntity(int orderId, int supplierId, int customerId,
                                               ShoppingCartDelivery delivery, ShoppingCartDesk desk,
                                               EtsWapDingTaiShoppingCartOrder order)
        {
            var tableReservationEntity =
                this.tableReservationEntityRepository.FindSingleByExpression(p => p.OrderNumber == orderId) ??
                new TableReservationEntity
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
            //如果是DF只收取押金，如果是DDF则只收取菜品费
            tableReservationEntity.CustomerTotal = order.DingTaiMethodId == 2
                                                       ? desk.DepositAmount
                                                       : order.CustomerTotalFee;
            tableReservationEntity.Total = order.DingTaiMethodId == 2 ? desk.DepositAmount : order.TotalFee;
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
        /// 保存订单详情（菜品明细）信息
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

        /// <summary>
        /// 保存订台预订信息
        /// </summary>
        /// <param name="supplierId">The supplierId</param>
        /// <param name="orderId">The order identifier.</param>
        /// <param name="desk">The desk.</param>
        /// 创建者：苏建峰
        /// 创建日期：3/21/2014 3:18 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private void SaveDeskBookingEntity(int supplierId, int orderId, ShoppingCartDesk desk)
        {
            if (desk.BookingDate == null)
            {
                return;
            }

            if (desk.BookingTime.IsEmptyOrNull())
            {
                return;
            }

            if (desk.DeskTypeId == 0)
            {
                return;
            }

            var nowTime = desk.BookingDate.Value.AddHours(double.Parse(desk.BookingTime.Split(':')[0]))
                    .AddMinutes(double.Parse(desk.BookingTime.Split(':')[1]));
            var supplierDeskTimeList = (from supplierDeskTimeEntity in this.supplierDeskTimeEntityRepository.EntityQueryable
                                        where supplierDeskTimeEntity.SupplierId == supplierId && supplierDeskTimeEntity.IsEnable == true
                                        select new
                                        {
                                            supplierDeskTimeEntity.Id,
                                            supplierDeskTimeEntity.BeginTime,
                                            supplierDeskTimeEntity.EndTime,
                                            supplierDeskTimeEntity.TimeType
                                        }).ToList();


            var supplierDeskTime = supplierDeskTimeList.FirstOrDefault(p => string.Compare(p.BeginTime, nowTime.ToString("HH:mm"), StringComparison.OrdinalIgnoreCase) <=
                                                          0
                                                          && string.Compare(p.EndTime, nowTime.ToString("HH:mm"), StringComparison.OrdinalIgnoreCase) >= 0);

            var deskBookingEntity = this.deskBookingEntityRepository.EntityQueryable.FirstOrDefault(
                p => p.OrderNo == orderId)
                                    ?? new DeskBookingEntity
                                        {
                                            OrderNo = orderId,
                                            BookType = false, //0台位  1排队
                                            CreateTime = DateTime.Now
                                        };

            deskBookingEntity.SupplierId = supplierId;
            deskBookingEntity.DeskType = new DeskTypeEntity { Id = desk.DeskTypeId };
            deskBookingEntity.NumberOfPeople = desk.PeopleCount;
            deskBookingEntity.ReservationTime = nowTime;
            deskBookingEntity.TimeType = supplierDeskTime == null ? null : supplierDeskTime.TimeType;

            this.deskBookingEntityRepository.Save(deskBookingEntity);
        }
    }
}
