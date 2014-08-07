using System.Json;
using Ets.SingleApi.Model.Controller;
using Ets.SingleApi.Model.ExternalServices;
using Ets.SingleApi.Services.IExternalServices;

namespace Ets.SingleApi.Services
{
    using System.Linq;

    using Ets.SingleApi.Model;
    using Ets.SingleApi.Model.Repository;
    using Ets.SingleApi.Model.Services;
    using Ets.SingleApi.Services.IRepository;
    using Ets.SingleApi.Utility;

    /// <summary>
    /// 类名称：DingTaiOrderProvider
    /// 命名空间：Ets.SingleApi.Services
    /// 类功能：订台订单信息
    /// </summary>
    /// 创建者：周超
    /// 创建日期：10/25/2013 2:11 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public abstract class DingTaiOrderProvider : IOrderProvider
    {

        /// <summary>
        /// 字段orderNumberDtEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：11/23/2013 12:13 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<OrderNumberDtEntity> orderNumberDtEntityRepository;

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
        /// Initializes a new instance of the <see cref="TangShiOrderProvider" /> class.
        /// </summary>
        /// <param name="orderNumberDtEntityRepository">The orderNumberDtEntityRepository</param>
        /// <param name="singleApiOrdersExternalService">The singleApiOrdersExternalService</param>
        /// 创建者：周超
        /// 创建日期：10/22/2013 8:41 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        protected DingTaiOrderProvider(
            INHibernateRepository<OrderNumberDtEntity> orderNumberDtEntityRepository,
            ISingleApiOrdersExternalService singleApiOrdersExternalService)
        {
            this.orderNumberDtEntityRepository = orderNumberDtEntityRepository;
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
                        OrderType = OrderType.DingTai,
                        OrderSourceType = this.GetOrderSourceType()
                    };
            }
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
        public abstract ServicesResult<bool> ModifyOrderPaymentMethod(string source, string shoppingCartId,
                                                                      int paymentMethodId, string payBank);

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
        public abstract ServicesResult<OrderShoppingCartStatusModel> GetOrderShoppingCartStatus(string source,
                                                                                                string shoppingCartId);

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
        public abstract ServicesResult<string> SaveOrder(string source, string shoppingCartId, string appKey,
                                                         string appPassword);

        /// <summary>
        /// 保存订单信息
        /// </summary>
        /// <param name="tangShiOrdersParameter">The tangShiOrdersParameter</param>
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
        public abstract ServicesResult<string> SaveTempOrder(SaveTangShiOrdersParameter tangShiOrdersParameter, string appKey, string appPassword);
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
            var entity = this.orderNumberDtEntityRepository.EntityQueryable.FirstOrDefault();
            if (entity == null)
            {
                return 0;
            }

            var orderNumber = entity.OrderId;
            this.orderNumberDtEntityRepository.Remove(entity);
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
                new OrderNumberExternalUrlParameter {OrderType = (int) this.OrderProviderType.OrderType},
                string.Empty,
                new SingleApiExternalServiceAuthenParameter
                    {
                        AppKey = appKey,
                        AppPassword = appPassword,
                        Source = source
                    });

            var data = result.Result;
            var jsonValue = JsonValue.Parse(data);
            if (jsonValue == null || jsonValue["Message"] == null)
            {
                return 0;
            }

            if (jsonValue["Message"]["StatusCode"] != (int) StatusCode.Succeed.Ok)
            {
                return 0;
            }

            int orderNumber;
            int.TryParse(jsonValue["Result"], out orderNumber);
            return orderNumber;
        }


        public ServicesResult<TangShiOrderBaseModel> GetOrderBase(string source, int orderId)
        {
            throw new System.NotImplementedException();
        }
    }
}