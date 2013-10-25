namespace Ets.SingleApi.Services
{
    using System.Linq;

    using Ets.SingleApi.Controllers.IServices;
    using Ets.SingleApi.Model.Repository;
    using Ets.SingleApi.Model.Services;
    using Ets.SingleApi.Services.IDetailServices;
    using Ets.SingleApi.Services.IRepository;
    using Ets.SingleApi.Utility;

    /// <summary>
    /// 类名称：OrderServices
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
        /// 字段customerAddressEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：10/23/2013 8:44 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<CustomerAddressEntity> customerAddressEntityRepository;

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
        /// Initializes a new instance of the <see cref="OrderServices" /> class.
        /// </summary>
        /// <param name="supplierEntityRepository">The supplierEntityRepository</param>
        /// <param name="customerEntityRepository">The customerEntityRepository</param>
        /// <param name="deliveryEntityRepository">The deliveryEntityRepository</param>
        /// <param name="customerAddressEntityRepository">The customerAddressEntityRepository</param>
        /// <param name="waiMaiOrderDetailServices">The waiMaiOrderDetailServices</param>
        /// 创建者：周超
        /// 创建日期：10/22/2013 8:30 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public OrderServices(
            INHibernateRepository<SupplierEntity> supplierEntityRepository,
            INHibernateRepository<CustomerEntity> customerEntityRepository,
            INHibernateRepository<DeliveryEntity> deliveryEntityRepository,
            INHibernateRepository<CustomerAddressEntity> customerAddressEntityRepository,
            IWaiMaiOrderDetailServices waiMaiOrderDetailServices)
        {
            this.supplierEntityRepository = supplierEntityRepository;
            this.customerEntityRepository = customerEntityRepository;
            this.deliveryEntityRepository = deliveryEntityRepository;
            this.customerAddressEntityRepository = customerAddressEntityRepository;
            this.waiMaiOrderDetailServices = waiMaiOrderDetailServices;
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
        public ServicesResult<WaiMaiOrderDetailModel> GetWaiMaiOrder(int orderId, int userId)
        {
            if (!this.customerEntityRepository.EntityQueryable.Any(p => p.LoginId == userId))
            {
                return new ServicesResult<WaiMaiOrderDetailModel>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidUserIdCode,
                    Result = new WaiMaiOrderDetailModel()
                };
            }

            if (!this.deliveryEntityRepository.EntityQueryable.Any(p => p.OrderNumber == orderId))
            {
                return new ServicesResult<WaiMaiOrderDetailModel>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidOrderIdCode,
                    Result = new WaiMaiOrderDetailModel()
                };
            }

            var result = this.waiMaiOrderDetailServices.GetOrder(orderId, userId);
            return new ServicesResult<WaiMaiOrderDetailModel>
            {
                StatusCode = result.StatusCode,
                Result = result.Result
            };
        }

        /// <summary>
        /// 添加一个外卖订单
        /// </summary>
        /// <param name="parameter">The parameter</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：10/22/2013 6:09 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<AddWaiMaiOrderModel> AddWaiMaiOrder(AddWaiMaiOrderParameter parameter)
        {
            if (parameter == null)
            {
                return new ServicesResult<AddWaiMaiOrderModel>
                {
                    StatusCode = (int)StatusCode.System.InvalidRequest,
                    Result = new AddWaiMaiOrderModel()
                };
            }

            if (!this.customerEntityRepository.EntityQueryable.Any(p => p.LoginId == parameter.UserId))
            {
                return new ServicesResult<AddWaiMaiOrderModel>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidUserIdCode,
                    Result = new AddWaiMaiOrderModel()
                };
            }

            if (!this.supplierEntityRepository.EntityQueryable.Any(p => p.SupplierId == parameter.SupplierId))
            {
                return new ServicesResult<AddWaiMaiOrderModel>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidSupplierIdCode,
                    Result = new AddWaiMaiOrderModel()
                };
            }

            var result = this.waiMaiOrderDetailServices.AddOrder(parameter);
            return new ServicesResult<AddWaiMaiOrderModel>
            {
                StatusCode = result.StatusCode,
                Result = result.Result
            };
        }

        /// <summary>
        /// 确认外卖订单
        /// </summary>
        /// <param name="parameter">订单数据</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：10/23/2013 5:32 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<ConfirmWaiMaiOrderModel> ConfirmWaiMaiOrder(ConfirmWaiMaiOrderParameter parameter)
        {
            if (parameter == null)
            {
                return new ServicesResult<ConfirmWaiMaiOrderModel>
                {
                    StatusCode = (int)StatusCode.System.InvalidRequest,
                    Result = new ConfirmWaiMaiOrderModel()
                };
            }

            if (!this.customerEntityRepository.EntityQueryable.Any(p => p.LoginId == parameter.UserId))
            {
                return new ServicesResult<ConfirmWaiMaiOrderModel>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidUserIdCode,
                    Result = new ConfirmWaiMaiOrderModel()
                };
            }

            if (!this.deliveryEntityRepository.EntityQueryable.Any(p => p.OrderNumber == parameter.OrderId))
            {
                return new ServicesResult<ConfirmWaiMaiOrderModel>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidUserIdCode,
                    Result = new ConfirmWaiMaiOrderModel()
                };
            }

            if (!this.customerAddressEntityRepository.EntityQueryable.Any(p => p.CustomerAddressId == parameter.CustomerAddressId))
            {
                return new ServicesResult<ConfirmWaiMaiOrderModel>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidSupplierIdCode,
                    Result = new ConfirmWaiMaiOrderModel()
                };
            }

            var result = this.waiMaiOrderDetailServices.ConfirmOrder(parameter);
            return new ServicesResult<ConfirmWaiMaiOrderModel>
            {
                StatusCode = result.StatusCode,
                Result = result.Result
            };
        }

        /// <summary>
        /// 订单外卖支付
        /// </summary>
        /// <param name="parameter">订单数据</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：10/23/2013 5:32 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<PaymentWaiMaiOrderModel> PaymentWaiMaiOrder(PaymentWaiMaiOrderParameter parameter)
        {
            if (parameter == null)
            {
                return new ServicesResult<PaymentWaiMaiOrderModel>
                {
                    StatusCode = (int)StatusCode.System.InvalidRequest,
                    Result = new PaymentWaiMaiOrderModel()
                };
            }

            if (!this.deliveryEntityRepository.EntityQueryable.Any(p => p.OrderNumber == parameter.OrderId))
            {
                return new ServicesResult<PaymentWaiMaiOrderModel>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidUserIdCode,
                    Result = new PaymentWaiMaiOrderModel()
                };
            }

            if (!this.customerEntityRepository.EntityQueryable.Any(p => p.LoginId == parameter.UserId))
            {
                return new ServicesResult<PaymentWaiMaiOrderModel>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidUserIdCode,
                    Result = new PaymentWaiMaiOrderModel()
                };
            }

            var result = this.waiMaiOrderDetailServices.PaymentOrder(parameter);
            return new ServicesResult<PaymentWaiMaiOrderModel>
            {
                StatusCode = result.StatusCode,
                Result = result.Result
            };
        }
    }
}