namespace Ets.SingleApi.Services
{
    using System.Linq;

    using Ets.SingleApi.Model;
    using Ets.SingleApi.Model.Repository;
    using Ets.SingleApi.Model.Services;
    using Ets.SingleApi.Services.IRepository;
    using Ets.SingleApi.Utility;

    /// <summary>
    /// 类名称：TangShiOrderProvider
    /// 命名空间：Ets.SingleApi.Services
    /// 类功能：堂食订单信息
    /// </summary>
    /// 创建者：周超
    /// 创建日期：10/25/2013 2:11 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class TangShiOrderProvider : IOrderProvider
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
        public OrderType OrderType
        {
            get
            {
                return OrderType.TangShi;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TangShiOrderProvider"/> class.
        /// </summary>
        /// <param name="orderNumberDtEntityRepository">The orderNumberDtEntityRepository</param>
        /// 创建者：周超
        /// 创建日期：10/25/2013 2:14 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public TangShiOrderProvider(INHibernateRepository<OrderNumberDtEntity> orderNumberDtEntityRepository)
        {
            this.orderNumberDtEntityRepository = orderNumberDtEntityRepository;
        }

        /// <summary>
        /// 取得订单是否存在以及支付支付状态
        /// </summary>
        /// <param name="orderId">订单状态</param>
        /// <returns>
        /// 返回结果 0 不存在 1 支付 2 未支付
        /// </returns>
        /// 创建者：周超
        /// 创建日期：10/23/2013 9:26 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<int> Exist(int orderId)
        {
            return new ServicesResult<int>();
        }

        /// <summary>
        /// 取得订单详情
        /// </summary>
        /// <param name="orderId">订单号</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：10/23/2013 9:26 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<IOrderDetailModel> GetOrder(int orderId)
        {
            return new ServicesResult<IOrderDetailModel>();
        }

        /// <summary>
        /// 保存订单信息
        /// </summary>
        /// <param name="shoppingCartId">购物车Id</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/20 16:01
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<string> SaveOrder(string shoppingCartId)
        {
            return new ServicesResult<string>
            {
                Result = string.Empty
            };
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
        public ServicesResult<string> GetOrderNumber()
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
    }
}