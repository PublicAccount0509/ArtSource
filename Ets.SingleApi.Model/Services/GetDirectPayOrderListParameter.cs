namespace Ets.SingleApi.Model.Services
{
    using System;

    /// <summary>
    /// 类名称：GetDirectPayOrderListParameter
    /// 命名空间：Ets.SingleApi.Model.Services
    /// 类功能：当面付查询参数
    /// </summary>
    /// 创建者：王巍
    /// 创建日期：4/30/2014 9:14 AM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class GetDirectPayOrderListParameter
    {
        /// <summary>
        /// 餐厅Id
        /// </summary>
        /// <value>
        /// The SupplierId
        /// </value>
        /// 创建者：王巍
        /// 创建日期：4/30/2014 9:14 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int SupplierId { get; set; }

        /// <summary>
        /// 当面付日期
        /// </summary>
        /// <value>
        /// The DirectPayDate
        /// </value>
        /// 创建者：王巍
        /// 创建日期：4/30/2014 10:17 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public DateTime DirectPayDate { get; set; }

        /// <summary>
        /// 用户Id
        /// </summary>
        /// <value>
        /// The UserId
        /// </value>
        /// 创建者：王巍
        /// 创建日期：4/30/2014 10:17 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int? UserId { get; set; }
    }
}