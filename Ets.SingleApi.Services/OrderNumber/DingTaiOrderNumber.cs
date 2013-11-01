﻿namespace Ets.SingleApi.Services
{
    using System.Linq;

    using Ets.SingleApi.Model;
    using Ets.SingleApi.Model.Repository;
    using Ets.SingleApi.Services.IRepository;
    using Ets.SingleApi.Utility;

    /// <summary>
    /// 类名称：DingTaiOrderNumber
    /// 命名空间：Ets.SingleApi.Services
    /// 类功能：订台订单号
    /// </summary>
    /// 创建者：周超
    /// 创建日期：10/25/2013 2:11 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class DingTaiOrderNumber : IOrderNumber
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
                return OrderType.DingTai;
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DingTaiOrderNumber"/> class.
        /// </summary>
        /// <param name="orderNumberDtEntityRepository">The orderNumberDtEntityRepository</param>
        /// 创建者：周超
        /// 创建日期：10/25/2013 2:14 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public DingTaiOrderNumber(INHibernateRepository<OrderNumberDtEntity> orderNumberDtEntityRepository)
        {
            this.orderNumberDtEntityRepository = orderNumberDtEntityRepository;
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
        public OrderNumberResult GetOrderNumber()
        {
            var entity = this.orderNumberDtEntityRepository.EntityQueryable.FirstOrDefault();
            if (entity == null)
            {
                return new OrderNumberResult
                    {
                        StatusCode = (int)StatusCode.General.OrderNumberNotFound,
                        OrderNumber = 0
                    };
            }

            var orderNumber = entity.OrderId;
            this.orderNumberDtEntityRepository.Remove(entity);
            return new OrderNumberResult
                {
                    OrderNumber = orderNumber
                };
        }
    }
}