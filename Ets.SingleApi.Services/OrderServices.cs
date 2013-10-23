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
        /// 字段orderDetailServices
        /// </summary>
        /// 创建者：周超
        /// 创建日期：10/22/2013 8:30 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly IOrderDetailServices orderDetailServices;

        /// <summary>
        /// Initializes a new instance of the <see cref="OrderServices" /> class.
        /// </summary>
        /// <param name="supplierEntityRepository">The supplierEntityRepository</param>
        /// <param name="customerEntityRepository">The customerEntityRepository</param>
        /// <param name="orderDetailServices">The orderDetailServices</param>
        /// 创建者：周超
        /// 创建日期：10/22/2013 8:30 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public OrderServices(
            INHibernateRepository<SupplierEntity> supplierEntityRepository,
            INHibernateRepository<CustomerEntity> customerEntityRepository,
            IOrderDetailServices orderDetailServices)
        {
            this.supplierEntityRepository = supplierEntityRepository;
            this.customerEntityRepository = customerEntityRepository;
            this.orderDetailServices = orderDetailServices;
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
                    StatusCode = (int)StatusCode.System.InvalidRequest
                };
            }

            if (!this.customerEntityRepository.EntityQueryable.Any(p => p.LoginId == parameter.UserId))
            {
                return new ServicesResult<AddWaiMaiOrderModel>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidUserIdCode
                };
            }

            if (!this.supplierEntityRepository.EntityQueryable.Any(p => p.SupplierId == parameter.SupplierId))
            {
                return new ServicesResult<AddWaiMaiOrderModel>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidSupplierIdCode
                };
            }

            var result = this.orderDetailServices.AddWaiMaiOrder(parameter);
            return new ServicesResult<AddWaiMaiOrderModel>
            {
                StatusCode = result.StatusCode,
                Result = result.Result
            };
        }
    }
}