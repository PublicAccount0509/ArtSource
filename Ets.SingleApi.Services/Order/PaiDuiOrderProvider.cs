using System.Linq;
using Ets.SingleApi.Model;
using Ets.SingleApi.Model.Controller;
using Ets.SingleApi.Model.Repository;
using Ets.SingleApi.Model.Services;
using Ets.SingleApi.Services.IRepository;
using Ets.SingleApi.Utility;

namespace Ets.SingleApi.Services
{
    /// <summary>
    /// 类名称：DingTaiOrderProvider
    /// 命名空间：Ets.SingleApi.Services
    /// 类功能：排队订单信息
    /// </summary>
    /// 创建者：苏建峰
    /// 创建日期：3/19/2014 10:31 AM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class PaiDuiOrderProvider : IOrderProvider
    {
        /// <summary>
        /// 字段orderNumberDtEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：10/25/2013 2:14 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<OrderNumberDtEntity> orderNumberDtEntityRepository;

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
                    OrderSourceType = OrderSourceType.Default
                };
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DingTaiOrderProvider"/> class.
        /// </summary>
        /// <param name="orderNumberDtEntityRepository">The orderNumberDtEntityRepository</param>
        /// 创建者：周超
        /// 创建日期：10/25/2013 2:14 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public PaiDuiOrderProvider(
            INHibernateRepository<OrderNumberDtEntity> orderNumberDtEntityRepository)
        {
            this.orderNumberDtEntityRepository = orderNumberDtEntityRepository;
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
            return new ServicesResult<int>();
        }

        /// <summary>
        /// 取得订单详情
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="orderId">订单号</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：10/23/2013 9:26 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<IOrderDetailModel> GetOrder(string source, int orderId)
        {
            return new ServicesResult<IOrderDetailModel>();
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
        public ServicesResult<string> SaveOrder(string source, string shoppingCartId, string appKey, string appPassword)
        {
            return new ServicesResult<string>
            {
                Result = string.Empty
            };
        }

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
        public ServicesResult<string> SaveTempOrder(SaveTangShiOrdersParameter tangShiOrdersParameter, string appKey,
                                                    string appPassword)
        {
            return new ServicesResult<string>
            {
                Result = string.Empty
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
            var entity = this.orderNumberDtEntityRepository.EntityQueryable.FirstOrDefault();
            if (entity == null)
            {
                return new ServicesResult<string>
                {
                    StatusCode = (int)StatusCode.General.OrderNumberNotFound,
                    Result = string.Empty
                };
            }

            var orderNumber = entity.OrderId;
            this.orderNumberDtEntityRepository.Remove(entity);
            return new ServicesResult<string>
                {
                    Result = orderNumber.ToString()
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
        public ServicesResult<bool> IsActivation(string source, int orderId)
        {
            return new ServicesResult<bool>();
        }

        /// <summary>
        /// 更新订单的支付方式
        /// </summary>
        /// <param name="source">The sourceDefault documentation</param>
        /// <param name="shoppingCartId">The shoppingCartIdDefault documentation</param>
        /// <param name="paymentMethodId">The paymentMethodIdDefault documentation</param>
        /// <param name="payBank">The payBankDefault documentation</param>
        /// <returns>
        /// Boolean}
        /// </returns>
        /// 创建者：王巍
        /// 创建日期：2/24/2014 9:26 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<bool> ModifyOrderPaymentMethod(string source, string shoppingCartId, int paymentMethodId, string payBank)
        {
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
        public ServicesResult<OrderShoppingCartStatusModel> GetOrderShoppingCartStatus(string source, string shoppingCartId)
        {
            return new ServicesResult<OrderShoppingCartStatusModel>
                {
                    StatusCode = (int)StatusCode.Succeed.Ok,
                    Result = new OrderShoppingCartStatusModel
                        {
                            IsComplete = true,
                            IsPaid = true,
                            OrderStatusId = 1
                        }
                };
        }
    }
}