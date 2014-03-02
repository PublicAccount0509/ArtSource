using System.Linq;
using Ets.SingleApi.Model;
using Ets.SingleApi.Model.Repository;
using Ets.SingleApi.Model.Services;
using Ets.SingleApi.Services.IRepository;
using Ets.SingleApi.Utility;

namespace Ets.SingleApi.Services
{
    /// <summary>
    /// 类名称：DingTaiOrderBaseProvider
    /// 命名空间：Ets.SingleApi.Services.Order
    /// 类功能：
    /// </summary>
    /// 创建者：单琪彬
    /// 创建日期：2/28/2014 4:20 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class DingTaiOrderBaseProvider : IOrderBaseProvider
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
        /// Initializes a new instance of the <see cref="DingTaiOrderBaseProvider"/> class.
        /// </summary>
        /// <param name="orderNumberDtEntityRepository">The orderNumberDtEntityRepository</param>
        /// 创建者：周超
        /// 创建日期：10/25/2013 2:14 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public DingTaiOrderBaseProvider(
            INHibernateRepository<OrderNumberDtEntity> orderNumberDtEntityRepository)
        {
            this.orderNumberDtEntityRepository = orderNumberDtEntityRepository;
        }


        public OrderType OrderType
        {
            get { return OrderType.DingTai; }
        }

        /// <summary>
        /// 取得一个订单号
        /// </summary>
        /// <param name="source">应用来源</param>
        /// <returns>
        /// 订单号
        /// </returns>
        /// 创建者：单琪彬
        /// 创建日期：2/28/2014 4:10 PM
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
        /// 取得订单是否存在以及支付支付状态
        /// </summary>
        /// <param name="source">应用来源</param>
        /// <param name="orderId">订单状态</param>
        /// <returns>
        /// 返回结果 0 不存在 1 支付 2 未支付
        /// </returns>
        /// 创建者：单琪彬
        /// 创建日期：2/28/2014 4:11 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<int> Exist(string source, int orderId)
        {
            return new ServicesResult<int>();
        }


        /// <summary>
        /// 保存支付状态
        /// </summary>
        /// <param name="source">应用来源</param>
        /// <param name="orderId">订单号</param>
        /// <param name="isPaid">支付状态</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：单琪彬
        /// 创建日期：2/28/2014 4:24 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<bool> SaveOrderPaid(string source, int orderId, bool isPaid)
        {
            return new ServicesResult<bool>();
        }

        /// <summary>
        /// 保存订单的支付方式
        /// </summary>
        /// <param name="source">应用来源</param>
        /// <param name="orderId">订单号</param>
        /// <param name="paymentMethodId">支付方式</param>
        /// <param name="payBank">备注</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：单琪彬
        /// 创建日期：2/28/2014 4:24 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<bool> SaveOrderPaymentMethod(string source, int orderId, int paymentMethodId, string payBank)
        {
            return new ServicesResult<bool>();
        }
    }
}
