using System.Collections.Generic;

namespace Ets.SingleApi.Services
{
    using Ets.SingleApi.Controllers.IServices;
    using Ets.SingleApi.Model;
    using Ets.SingleApi.Model.ExternalServices;
    using Ets.SingleApi.Model.Repository;
    using Ets.SingleApi.Model.Services;
    using Ets.SingleApi.Services.IExternalServices;
    using Ets.SingleApi.Services.IRepository;
    using Ets.SingleApi.Utility;
    using System;
    using System.Json;
    using System.Linq;

    public class DirectPayServices : IDirectPayServices
    {
        /// <summary>
        /// 字段queueEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：3/21/2014 2:07 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<DirectPayEntity> directPayEntityRepository;

        /// <summary>
        /// 字段sourcePathEntityRepository
        /// </summary>
        /// 创建者：王巍
        /// 创建日期：4/30/2014 2:06 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<SourcePathEntity> sourcePathEntityRepository;

        /// <summary>
        /// 字段sourceTypeEntityRepository
        /// </summary>
        /// 创建者：王巍
        /// 创建日期：4/30/2014 2:06 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<SourceTypeEntity> sourceTypeEntityRepository;

        /// <summary>
        /// 字段loginEntityRepository
        /// </summary>
        /// 创建者：王巍
        /// 创建日期：4/30/2014 2:39 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<LoginEntity> loginEntityRepository;

        /// <summary>
        /// 字段customerEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：3/21/2014 5:37 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<CustomerEntity> customerEntityRepository;

        /// <summary>
        /// 字段supplierEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：11/25/2013 3:26 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<SupplierEntity> supplierEntityRepository;

        /// <summary>
        /// 字段deskTypeEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：3/21/2014 2:07 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<PaymentDirectEntity> paymentDirectEntityRepository;

        /// <summary>
        /// 可见店铺表
        /// </summary>
        /// 创建者：王巍
        /// 创建日期：4/9/2014 1:22 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<SupplierPlatformRelationEntity> supplierPlatformRelationEntityRepository;

        /// <summary>
        /// 可见集团表
        /// </summary>
        /// 创建者：王巍
        /// 创建日期：4/9/2014 1:22 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<SupplierGroupPlatformEntity> supplierGroupPlatformEntityRepository;

        /// <summary>
        /// 当面付订单号
        /// </summary>
        /// 创建者：王巍
        /// 创建日期：4/30/2014 1:40 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<OrderNumberDpEntity> orderNumberDpEntityRepository;

        /// <summary>
        /// 字段singleApiOrdersExternalService
        /// </summary>
        /// 创建者：王巍
        /// 创建日期：4/30/2014 1:36 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly ISingleApiOrdersExternalService singleApiOrdersExternalService;

        /// <summary>
        /// Initializes a new instance of the <see cref="CuisineServices" /> class.
        /// </summary>
        /// <param name="directPayEntityRepository">The queueEntityRepository</param>
        /// <param name="sourcePathEntityRepository">The sourcePathEntityRepositoryDefault documentation</param>
        /// <param name="sourceTypeEntityRepository">The sourceTypeEntityRepositoryDefault documentation</param>
        /// <param name="loginEntityRepository">The loginEntityRepositoryDefault documentation</param>
        /// <param name="customerEntityRepository">The customerEntityRepository</param>
        /// <param name="supplierEntityRepository">The supplierEntityRepository</param>
        /// <param name="paymentDirectEntityRepository">The deskTypeEntityRepository</param>
        /// <param name="supplierPlatformRelationEntityRepository">The supplierPlatformRelationEntityRepositoryDefault documentation</param>
        /// <param name="supplierGroupPlatformEntityRepository">The supplierGroupPlatformEntityRepositoryDefault documentation</param>
        /// <param name="orderNumberDpEntityRepository">The orderNumberDpEntityRepositoryDefault documentation</param>
        /// <param name="singleApiOrdersExternalService">The singleApiOrdersExternalServiceDefault documentation</param>
        /// 创建者：周超
        /// 创建日期：2013/10/13 15:23
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public DirectPayServices(
            INHibernateRepository<DirectPayEntity> directPayEntityRepository,
            INHibernateRepository<SourcePathEntity> sourcePathEntityRepository,
            INHibernateRepository<SourceTypeEntity> sourceTypeEntityRepository,
            INHibernateRepository<LoginEntity> loginEntityRepository,
            INHibernateRepository<CustomerEntity> customerEntityRepository,
            INHibernateRepository<SupplierEntity> supplierEntityRepository,
            INHibernateRepository<PaymentDirectEntity> paymentDirectEntityRepository,
            INHibernateRepository<SupplierPlatformRelationEntity> supplierPlatformRelationEntityRepository,
            INHibernateRepository<SupplierGroupPlatformEntity> supplierGroupPlatformEntityRepository,
            INHibernateRepository<OrderNumberDpEntity> orderNumberDpEntityRepository,
            ISingleApiOrdersExternalService singleApiOrdersExternalService)
        {
            this.sourcePathEntityRepository = sourcePathEntityRepository;
            this.sourceTypeEntityRepository = sourceTypeEntityRepository;
            this.loginEntityRepository = loginEntityRepository;
            this.customerEntityRepository = customerEntityRepository;
            this.supplierEntityRepository = supplierEntityRepository;
            this.paymentDirectEntityRepository = paymentDirectEntityRepository;
            this.directPayEntityRepository = directPayEntityRepository;
            this.supplierPlatformRelationEntityRepository = supplierPlatformRelationEntityRepository;
            this.supplierGroupPlatformEntityRepository = supplierGroupPlatformEntityRepository;
            this.orderNumberDpEntityRepository = orderNumberDpEntityRepository;
            this.singleApiOrdersExternalService = singleApiOrdersExternalService;
        }

        /// <summary>
        /// 获取当面付订单列表
        /// </summary>
        /// <param name="source">The sourceDefault documentation</param>
        /// <param name="getDirectPayOrderListParameter">The parameterDefault documentation</param>
        /// <returns>
        /// ServicesResultList{QueueDeskModel}
        /// </returns>
        /// 创建者：王巍
        /// 创建日期：4/30/2014 10:17 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResultList<DirectPayModel> GetOrderList(string source, GetDirectPayOrderListParameter getDirectPayOrderListParameter)
        {
            if (getDirectPayOrderListParameter == null)
            {
                return new ServicesResultList<DirectPayModel>
                {
                    StatusCode = (int)StatusCode.System.InvalidRequest,
                    Result = new List<DirectPayModel>()
                };
            }

            var directPayTemp = (from directPay in this.directPayEntityRepository.EntityQueryable
                                 from supplier in this.supplierEntityRepository.EntityQueryable
                                 from customerEntity in this.customerEntityRepository.EntityQueryable
                                 where directPay.SupplierId == supplier.SupplierId
                                     && directPay.CustomerId == customerEntity.CustomerId
                                     && customerEntity.LoginId == getDirectPayOrderListParameter.UserId
                                 select new
                                 {
                                     directPay.DirectPayId,
                                     supplier.SupplierId,
                                     supplier.SupplierName,
                                     directPay.OrderNumber,
                                     directPay.OrderStateId,
                                     directPay.IsPaId,
                                     CeateDate = directPay.DateAdded,
                                     supplier.SupplierGroupId,
                                     PayableAmount = directPay.Total,
                                     ActualPaidAmount = directPay.CustomerTotal,
                                     directPay.CustomerCouponTotal,
                                     directPay.SupplierCouponTotal,
                                     directPay.Cancelled
                                 });

            var directPayIdList = directPayTemp.Select(p => p.DirectPayId).ToList();

            var paymentList = (from payment in this.paymentDirectEntityRepository.EntityQueryable
                               where directPayIdList.Contains(payment.DirectPay.DirectPayId)
                               select new
                               {
                                   payment.PaymentMethodId,
                                   payment.DirectPay.DirectPayId
                               }).ToList();

            if (getDirectPayOrderListParameter.Cancelled != null)
            {
                directPayTemp = directPayTemp.Where(p => p.Cancelled == getDirectPayOrderListParameter.Cancelled);
            }

            if (getDirectPayOrderListParameter.DirectPayStartDate != null)
            {
                directPayTemp = directPayTemp.Where(p => p.CeateDate >= getDirectPayOrderListParameter.DirectPayStartDate.Value);
            }

            if (getDirectPayOrderListParameter.DirectPayEndDate != null)
            {
                directPayTemp = directPayTemp.Where(p => p.CeateDate < getDirectPayOrderListParameter.DirectPayEndDate.Value);
            }

            if (getDirectPayOrderListParameter.SupplierGroupId != null)
            {
                directPayTemp = directPayTemp.Where(p => p.SupplierGroupId == getDirectPayOrderListParameter.SupplierGroupId);
            }

            if (getDirectPayOrderListParameter.IsEtaoshi)
            {
                //显示 可见集团列表，可见店铺列表
                directPayTemp = (from queryable in directPayTemp
                                 from supplierGroupPlatform in supplierGroupPlatformEntityRepository.EntityQueryable
                                 from supplierPlatformRelation in supplierPlatformRelationEntityRepository.EntityQueryable
                                 where queryable.SupplierGroupId == supplierGroupPlatform.SupplierGroupId
                                       && supplierGroupPlatform.PlatformId == getDirectPayOrderListParameter.PlatformId
                                       && queryable.SupplierId == supplierPlatformRelation.SupplierId
                                       && supplierPlatformRelation.PlatformId == getDirectPayOrderListParameter.PlatformId
                                 select new
                                 {
                                     queryable.DirectPayId,
                                     queryable.SupplierId,
                                     queryable.SupplierName,
                                     queryable.OrderNumber,
                                     queryable.OrderStateId,
                                     queryable.IsPaId,
                                     queryable.CeateDate,
                                     queryable.SupplierGroupId,
                                     queryable.PayableAmount,
                                     queryable.ActualPaidAmount,
                                     queryable.CustomerCouponTotal,
                                     queryable.SupplierCouponTotal,
                                     queryable.Cancelled
                                 });
            }

            if (getDirectPayOrderListParameter.SupplierId != null)
            {
                directPayTemp = directPayTemp.Where(p => p.SupplierId == getDirectPayOrderListParameter.SupplierId);
            }

            directPayTemp = directPayTemp.OrderByDescending(p => p.CeateDate);
            if (getDirectPayOrderListParameter.PageIndex != null)
            {
                directPayTemp = directPayTemp.Skip((getDirectPayOrderListParameter.PageIndex.Value - 1) * getDirectPayOrderListParameter.PageSize).Take(getDirectPayOrderListParameter.PageSize);
            }

            var directPayList = directPayTemp.ToList();

            var result = directPayList.Select(p => new DirectPayModel
            {
                DirectPayId = p.DirectPayId,
                SupplierId = p.SupplierId,
                SupplierName = p.SupplierName,
                OrderId = p.OrderNumber,
                OrderStatusId = p.OrderStateId,
                IsPaid = p.IsPaId,
                CreateDate = p.CeateDate,
                PayableAmount = p.PayableAmount,
                ActualPaidAmount = p.ActualPaidAmount,
                CustomerCouponTotal = p.CustomerCouponTotal,
                SupplierCouponTotal = p.SupplierCouponTotal,
                OrderType = (int)OrderType.DirectPay,
                PaymentMethodId = paymentList.Where(c => c.DirectPayId == p.DirectPayId).Select(s => s.PaymentMethodId).FirstOrDefault(),
                Cancelled = p.Cancelled
            }).ToList();

            return new ServicesResultList<DirectPayModel>
            {
                Result = result
            };
        }

        /// <summary>
        /// 获取当面付订单明细
        /// </summary>
        /// <param name="source">The sourceDefault documentation</param>
        /// <param name="orderNumber">The directPayIdDefault documentation</param>
        /// <returns>
        /// ServicesResult{DirectPayModel}
        /// </returns>
        /// 创建者：王巍
        /// 创建日期：4/30/2014 10:54 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<DirectPayModel> GetOrderDetail(string source, int orderNumber)
        {
            var directPayEntity = (from directPay in this.directPayEntityRepository.EntityQueryable
                                   from supplier in this.supplierEntityRepository.EntityQueryable
                                   where directPay.SupplierId == supplier.SupplierId
                                         && directPay.OrderNumber == orderNumber
                                   select new
                                       {
                                           directPay.DirectPayId,
                                           directPay.OrderNumber,
                                           directPay.SupplierId,
                                           supplier.SupplierName,
                                           directPay.OrderStateId,
                                           directPay.Cancelled,
                                           IsPaid = directPay.IsPaId,
                                           Telephone = directPay.ContactPhone,
                                           CreateDate = directPay.DateAdded,
                                           PayableAmount = directPay.Total,
                                           ActualPaidAmount = directPay.CustomerTotal
                                       }
                    ).FirstOrDefault();

            if (directPayEntity == null)
            {
                return new ServicesResult<DirectPayModel>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidOrderIdCode,
                    Result = new DirectPayModel()
                };
            }

            var paymentEntity = this.paymentDirectEntityRepository.EntityQueryable.FirstOrDefault(p => p.DirectPay.DirectPayId == directPayEntity.DirectPayId);

            var result = new DirectPayModel
                {
                    SupplierId = directPayEntity.SupplierId ?? 0,
                    SupplierName = directPayEntity.SupplierName,
                    PaymentMethodId = paymentEntity == null ? 0 : paymentEntity.PaymentMethodId,
                    OrderType = (int) OrderType.DirectPay,
                    DirectPayId = directPayEntity.DirectPayId,
                    IsPaid = directPayEntity.IsPaid,
                    ActualPaidAmount = directPayEntity.ActualPaidAmount,
                    PayableAmount = directPayEntity.PayableAmount,
                    OrderId = directPayEntity.OrderNumber,
                    CreateDate = directPayEntity.CreateDate,
                    PaymentDate =paymentEntity == null ? (DateTime?)null : paymentEntity.PaymentDate,
                    OrderStatusId = directPayEntity.OrderStateId,
                    Cancelled = directPayEntity.Cancelled,
                    Telephone = directPayEntity.Telephone
                };

            return new ServicesResult<DirectPayModel>
                {
                    StatusCode = (int)StatusCode.Succeed.Ok,
                    Result = result
                };
        }

        /// <summary>
        /// 创建当面付订单
        /// </summary>
        /// <param name="source">The sourceDefault documentation</param>
        /// <param name="appKey"></param>
        /// <param name="appPassword"></param>
        /// <param name="saveDirectPayParameter">The parameterDefault documentation</param>
        /// <returns>
        /// 当面付订单号
        /// </returns>
        /// 创建者：王巍
        /// 创建日期：4/30/2014 10:39 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<string> CreateOrder(string source, string appKey, string appPassword, SaveDirectPayParameter saveDirectPayParameter)
        {
            //校验SupplierId合法性
            var supplierId = saveDirectPayParameter.SupplierId;
            var supplierEntity = this.supplierEntityRepository.FindSingleByExpression(p => p.SupplierId == supplierId);
            if (supplierEntity == null)
            {
                return new ServicesResult<string>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidSupplierIdCode,
                    Result = string.Empty
                };
            }

            //获取OrderId
            var orderId = this.GetOrderNumberId(source, appKey, appPassword);
            if (orderId <= 0)
            {
                return new ServicesResult<string>
                {
                    StatusCode = (int)StatusCode.General.OrderNumberNotFound,
                    Result = string.Empty
                };
            }

            //校验UserId合法性
            var tempLogin = this.loginEntityRepository.EntityQueryable
                                .Where(p => p.LoginId == saveDirectPayParameter.UserId && p.IsEnabled)
                                .Select(p => new { UserId = p.LoginId }).FirstOrDefault();

            if (tempLogin == null)
            {
                return new ServicesResult<string>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidUserIdCode,
                };
            }

            //获取UserId 对应的CustomerId
            var customer = this.customerEntityRepository.EntityQueryable
                               .Where(p => p.LoginId == saveDirectPayParameter.UserId)
                               .Select(p => new { p.CustomerId }).FirstOrDefault();

            if (customer == null)
            {
                return new ServicesResult<string>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidUserIdCode
                };
            }

            //保存当面付订单信息
            var directPayId = this.SaveDirectPayEntity(
                                        orderId, customer.CustomerId, saveDirectPayParameter);

            //保存当面付订单支付信息
            this.SavePaymentDirectEntity(directPayId, saveDirectPayParameter.Total, saveDirectPayParameter.PaymentMethodId, saveDirectPayParameter.PayBank);

            return new ServicesResult<string>
            {
                StatusCode = (int)StatusCode.Succeed.Ok,
                Result = orderId.ToString()
            };
        }

        /// <summary>
        /// 检查手机号支付次数是否超过上限
        /// </summary>
        /// <param name="source">The sourceDefault documentation</param>
        /// <param name="phoneNo">电话号码</param>
        /// <param name="upperLimit">当面付支付上限</param>
        /// <returns>
        /// True 超过或等于上限；False 没有超过上限
        /// </returns>
        /// 创建者：王巍
        /// 创建日期：4/30/2014 10:51 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<bool> CheckTelePhonePayMoreThanUpperLimit(string source, string phoneNo, int upperLimit)
        {
            var directPayList = this.directPayEntityRepository.EntityQueryable
                         .Where(c => c.ContactPhone == phoneNo && c.DateAdded.Date == DateTime.Now.Date && c.Cancelled == false)
                         .Select(s => new { s.ContactPhone, s.DateAdded })
                         .ToList();

            return new ServicesResult<bool>
                {
                    StatusCode = (int)StatusCode.Succeed.Ok,
                    Result = directPayList.Count() >= upperLimit
                };
        }

        /// <summary>
        /// 取消当面付订单
        /// </summary>
        /// <param name="source">The sourceDefault documentation</param>
        /// <param name="parameter">当面付订单Id</param>
        /// <returns>
        /// Boolean}
        /// </returns>
        /// 创建者：王巍
        /// 创建日期：5/6/2014 8:54 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<bool> CancelDirectPay(string source, CancelDirectPayParameter parameter)
        {
            if (parameter == null)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = (int)StatusCode.System.InvalidRequest,
                    Result = false
                };
            }
            var result = (from directPay in this.directPayEntityRepository.EntityQueryable
                          where directPay.DirectPayId == parameter.DirectPayId
                          select directPay).FirstOrDefault();

            if (result == null)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidQueueIdCode,
                    Result = false
                };
            }

            if (result.OrderStateId != 0)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidCancelledQueueStateIdCode,
                    Result = false
                };
            }

            if (result.Cancelled == true)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = (int)StatusCode.Validate.AleadyCancelledQueueCode,
                    Result = false
                };
            }

            result.Cancelled = true;

            this.directPayEntityRepository.Save(result);

            return new ServicesResult<bool>
            {
                Result = true
            };
        }

        /// <summary>
        /// 保存当面付订单信息
        /// </summary>
        /// <param name="orderId">The orderIdDefault documentation</param>
        /// <param name="customerId">The customerIdDefault documentation</param>
        /// <param name="saveDirectPayParameter">The saveDirectPayParameterDefault documentation</param>
        /// <returns>
        /// 当面付订单号
        /// </returns>
        /// 创建者：王巍
        /// 创建日期：4/30/2014 2:29 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private int SaveDirectPayEntity(int orderId, int customerId, SaveDirectPayParameter saveDirectPayParameter)
        {
            var directPayEntity = this.directPayEntityRepository.FindSingleByExpression(p => p.OrderNumber == orderId) ?? new DirectPayEntity
            {
                SupplierId = saveDirectPayParameter.SupplierId,
                CustomerId = customerId,
                OrderNumber = orderId,
                DateAdded = DateTime.Now,
                OrderStateId = 0,
                IsPaId = false,
                Cancelled = false
            };

            directPayEntity.ContactPhone = saveDirectPayParameter.Telephone;
            directPayEntity.Template = this.sourceTypeEntityRepository.EntityQueryable.FirstOrDefault(p => p.Value == saveDirectPayParameter.Template);
            directPayEntity.Path = this.sourcePathEntityRepository.EntityQueryable.FirstOrDefault(p => p.Value == saveDirectPayParameter.SourceType);
            directPayEntity.IPAddress = saveDirectPayParameter.IPAddress;
            directPayEntity.CustomerCouponTotal = saveDirectPayParameter.CustomerCouponTotal;//用户优惠金额
            directPayEntity.SupplierCouponTotal = saveDirectPayParameter.SupplierCouponTotal;//餐厅优惠金额
            directPayEntity.CouponTotal = saveDirectPayParameter.CustomerCouponTotal + saveDirectPayParameter.SupplierCouponTotal;//优惠总金额
            directPayEntity.CustomerTotal = saveDirectPayParameter.CustomerTotal;//用户实付金额
            directPayEntity.Total = saveDirectPayParameter.Total;//应付总金额 = 用户优惠金额 + 餐厅优惠金额 + 客户实际消费金额

            this.directPayEntityRepository.Save(directPayEntity);

            return directPayEntity.DirectPayId;
        }

        /// <summary>
        /// 保存支付信息
        /// </summary>
        /// <param name="directPayId">订单Id</param>
        /// <param name="amount">支付总金额</param>
        /// <param name="paymentMethodId">支付方式</param>
        /// <param name="payBank">支付银行</param>
        /// 创建者：周超
        /// 创建日期：11/23/2013 11:07 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private void SavePaymentDirectEntity(int directPayId, decimal amount, int paymentMethodId, string payBank)
        {
            if (paymentMethodId <= 0)
            {
                return;
            }

            var paymentEntity = this.paymentDirectEntityRepository.EntityQueryable.FirstOrDefault(p => p.DirectPay.DirectPayId == directPayId)
                                 ?? new PaymentDirectEntity
                                 {
                                     PaymentTypeId = 1,
                                     DirectPay = new DirectPayEntity { DirectPayId = directPayId },
                                     TransactionCode = string.Empty,
                                     CardId = string.Empty,
                                     Authorized = false,
                                     CVV = 0,
                                     AVS = string.Empty,
                                     PC = 0,
                                     AuthCode = string.Empty,
                                     VoicePayResponse = string.Empty,
                                     TransactionFee = 0
                                 };

            paymentEntity.Amount = amount;
            paymentEntity.MethodChangeHistory = paymentEntity.PaymentMethodId.ToString();
            paymentEntity.PaymentMethodId = paymentMethodId;
            paymentEntity.PayBank = payBank;

            this.paymentDirectEntityRepository.Save(paymentEntity);
        }

        /// <summary>
        /// 取得一个订单号
        /// </summary>
        /// <returns>
        /// 订单号
        /// </returns>
        /// 创建者：周超
        /// 创建日期：10/25/2013 2:09 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private int GetOrderNumberId(string source, string appKey, string appPassword)
        {
            return ServicesCommon.FromServerEnable
                       ? this.GetServerOrderNumber(source, appKey, appPassword)
                       : this.GetLocalOrderNumber();
        }

        /// <summary>
        /// 从本地获取订单号
        /// </summary>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：3/2/2014 11:33 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private int GetLocalOrderNumber()
        {
            var entity = this.orderNumberDpEntityRepository.EntityQueryable.FirstOrDefault();
            if (entity == null)
            {
                return 0;
            }

            var orderNumber = entity.OrderId;
            this.orderNumberDpEntityRepository.Remove(entity);
            return orderNumber;
        }

        /// <summary>
        /// 从服务器获取订单号
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="appKey">The appKey</param>
        /// <param name="appPassword">The appPassword</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：3/2/2014 11:34 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private int GetServerOrderNumber(string source, string appKey, string appPassword)
        {
            var result = this.singleApiOrdersExternalService.OrderNumber(
                  new OrderNumberExternalUrlParameter { OrderType = (int)OrderType.DirectPay },
                  string.Empty,
                  new SingleApiExternalServiceAuthenParameter { AppKey = appKey, AppPassword = appPassword, Source = source });

            var data = result.Result;
            var jsonValue = JsonValue.Parse(data);
            if (jsonValue == null || jsonValue["Message"] == null)
            {
                return 0;
            }

            if (jsonValue["Message"]["StatusCode"] != (int)StatusCode.Succeed.Ok)
            {
                return 0;
            }

            int orderNumber;
            int.TryParse(jsonValue["Result"], out orderNumber);
            return orderNumber;
        }
    }
}