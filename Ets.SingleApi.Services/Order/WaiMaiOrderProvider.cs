namespace Ets.SingleApi.Services
{
    using System.Linq;
    using Ets.SingleApi.Model;
    using Ets.SingleApi.Model.Repository;
    using Ets.SingleApi.Model.Services;
    using Ets.SingleApi.Services.IRepository;
    using Ets.SingleApi.Utility;
    using Ets.SingleApi.Model.ExternalServices;
    using Ets.SingleApi.Services.IExternalServices;

    /// <summary>
    /// 类名称：WaiMaiOrderProvider
    /// 命名空间：Ets.SingleApi.Services
    /// 类功能：外卖订单
    /// </summary>
    /// 创建者：周超
    /// 创建日期：11/22/2013 3:25 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public abstract class WaiMaiOrderProvider : IOrderProvider
    {
        /// <summary>
        /// 字段deliveryEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：10/22/2013 8:41 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<DeliveryEntity> deliveryEntityRepository;

        /// <summary>
        /// 字段orderNumberDcEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：11/23/2013 12:13 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<OrderNumberDcEntity> orderNumberDcEntityRepository;

        /// <summary>
        /// 字段singleApiOrdersExternalService
        /// </summary>
        /// 创建者：周超
        /// 创建日期：3/2/2014 7:04 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly ISingleApiOrdersExternalService singleApiOrdersExternalService;

        /// <summary>
        /// Initializes a new instance of the <see cref="WaiMaiOrderProvider" /> class.
        /// </summary>
        /// <param name="deliveryEntityRepository">The deliveryEntityRepository</param>
        /// <param name="orderNumberDcEntityRepository">The orderNumberDcEntityRepository</param>
        /// <param name="singleApiOrdersExternalService">The singleApiOrdersExternalService</param>
        /// 创建者：周超
        /// 创建日期：10/22/2013 8:41 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        protected WaiMaiOrderProvider(
            INHibernateRepository<DeliveryEntity> deliveryEntityRepository,
            INHibernateRepository<OrderNumberDcEntity> orderNumberDcEntityRepository,
            ISingleApiOrdersExternalService singleApiOrdersExternalService)
        {
            this.deliveryEntityRepository = deliveryEntityRepository;
            this.orderNumberDcEntityRepository = orderNumberDcEntityRepository;
            this.singleApiOrdersExternalService = singleApiOrdersExternalService;
        }

        /// <summary>
        /// 取得订单类型
        /// </summary>
        /// <value>
        /// 订单类型
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/20 16:01
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public OrderProviderType OrderProviderType
        {
            get
            {
                return new OrderProviderType
                {
                    OrderType = OrderType.WaiMai,
                    OrderSourceType = this.GetOrderSourceType()
                };
            }
        }

        /// <summary>
        /// 取得订单是否存在以及支付支付状态
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="orderId">订单状态</param>
        /// <returns>
        /// 返回结果 0 不存在 1 支付 2 未支付
        /// </returns>
        /// 创建者：周超
        /// 创建日期：10/23/2013 9:26 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<int> Exist(string source, int orderId)
        {
            var deliveryEntity = (from entity in this.deliveryEntityRepository.EntityQueryable
                                  where entity.OrderNumber == orderId
                                  select entity).FirstOrDefault();

            if (deliveryEntity == null)
            {
                return new ServicesResult<int>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidOrderIdCode
                };
            }

            return new ServicesResult<int>
            {
                StatusCode = (int)StatusCode.Succeed.Ok,
                Result = deliveryEntity.IsPaId == true ? 1 : 2
            };
        }

        /// <summary>
        /// 取得一个订单号
        /// </summary>
        /// <param name="source">The source</param>
        /// <returns>
        /// 订单号
        /// </returns>
        /// 创建者：周超
        /// 创建日期：10/25/2013 2:09 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<string> GetOrderNumber(string source)
        {
            var orderId = this.GetOrderNumberId(source, string.Empty, string.Empty);
            if (orderId <= 0)
            {
                return new ServicesResult<string>
                {
                    StatusCode = (int)StatusCode.General.OrderNumberNotFound,
                    Result = string.Empty
                };
            }

            return new ServicesResult<string>
                {
                    Result = orderId.ToString()
                };
        }

        /// <summary>
        /// 更改支付状态
        /// </summary>
        /// <param name="source">The sourceDefault documentation</param>
        /// <param name="orderId"></param>
        /// <param name="isPaId">The  isPaId indicates whether</param>
        /// <returns>
        /// Boolean}
        /// </returns>
        /// 创建者：王巍
        /// 创建日期：1/26/2014 10:50 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<bool> SaveOrderPaId(string source, int orderId, bool isPaId)
        {
            var deliveryEntity = this.deliveryEntityRepository.FindSingleByExpression(p => p.OrderNumber == orderId);
            if (deliveryEntity == null)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidOrderIdCode,
                    Result = false
                };
            }

            deliveryEntity.IsPaId = true;
            this.deliveryEntityRepository.Save(deliveryEntity);

            return new ServicesResult<bool>
            {
                StatusCode = (int)StatusCode.Succeed.Ok,
                Result = true
            };
        }

        /// <summary>
        /// 判断是否可以激活购物车
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="orderId">The orderId</param>
        /// <returns>
        /// 返回判断结果
        /// </returns>
        /// 创建者：单琪彬
        /// 创建日期：2/13/2014 11:55 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        /// <exception cref="System.NotImplementedException"></exception>
        public ServicesResult<bool> IsActivation(string source, int orderId)
        {
            var deliveryEntity = (from entity in this.deliveryEntityRepository.EntityQueryable
                                  where entity.OrderNumber == orderId
                                  select entity).FirstOrDefault();
            if (deliveryEntity == null)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidOrderIdCode,
                    Result = false
                };
            }
            return new ServicesResult<bool>
                {
                    StatusCode = (int)StatusCode.Succeed.Ok,
                    Result =
                        ServicesCommon.IsActivationOrderStatusIdList.Contains(deliveryEntity.OrderStatusId) &&
                        deliveryEntity.IsPaId != true
                };
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
        public abstract ServicesResult<bool> ModifyOrderPaymentMethod(string source, string shoppingCartId, int paymentMethodId, string payBank);

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
        public abstract ServicesResult<OrderShoppingCartStatusModel> GetOrderShoppingCartStatus(string source, string shoppingCartId);

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
        public abstract ServicesResult<IOrderDetailModel> GetOrder(string source, int orderId);

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
        public abstract ServicesResult<string> SaveOrder(string source, string shoppingCartId, string appKey, string appPassword);

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
        protected abstract OrderSourceType GetOrderSourceType();

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
        protected int GetOrderNumberId(string source, string appKey, string appPassword)
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
            var entity = this.orderNumberDcEntityRepository.EntityQueryable.FirstOrDefault();
            if (entity == null)
            {
                return 0;
            }

            var orderNumber = entity.OrderId;
            this.orderNumberDcEntityRepository.Remove(entity);
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
                  new OrderNumberExternalUrlParameter { OrderType = (int)this.OrderProviderType.OrderType },
                  string.Empty,
                  new SingleApiExternalServiceAuthenParameter { AppKey = appKey, AppPassword = appPassword, Source = source });

            int orderNumber;
            int.TryParse(result.Result, out orderNumber);
            return orderNumber;
        }
    }
}