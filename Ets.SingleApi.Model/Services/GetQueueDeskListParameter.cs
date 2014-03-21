using System;

namespace Ets.SingleApi.Model.Services
{
    /// <summary>
    /// 类名称：QueueDeskListParameter
    /// 命名空间：Ets.SingleApi.Model.Services
    /// 类功能：方法GetQueueDeskList传入的参数
    /// </summary>
    /// 创建者：苏建峰
    /// 创建日期：3/18/2014 6:05 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class GetQueueDeskListParameter
    {
        /// <summary>
        /// 餐厅Id
        /// </summary>
        /// <value>
        /// The supplier identifier.
        /// </value>
        /// 创建者：苏建峰
        /// 创建日期：3/18/2014 6:14 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int SupplierId { get; set; }

        /// <summary>
        /// 排队日期
        /// </summary>
        /// <value>
        /// 排队日期
        /// </value>
        /// 创建者：苏建峰
        /// 创建日期：3/18/2014 6:14 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public DateTime QueueDate { get; set; }

        /// <summary>
        /// 用户Id
        /// </summary>
        /// <value>
        /// 用户Id
        /// </value>
        /// 创建者：苏建峰
        /// 创建日期：3/19/2014 2:08 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int? UserId { get; set; }
    }
}