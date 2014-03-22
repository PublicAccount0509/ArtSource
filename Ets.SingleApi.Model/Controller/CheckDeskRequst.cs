using System;

namespace Ets.SingleApi.Model.Controller
{
    using System.Collections.Generic;

    /// <summary>
    /// 类名称：CheckDeskRequst
    /// 命名空间：Ets.SingleApi.Model.Controller
    /// 类功能：检查订台台位是否被锁定实体
    /// </summary>
    /// 创建者：苏建峰
    /// 创建日期：3/22/2014 11:13 AM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class CheckDeskRequst : ApiRequst
    {
        /// <summary>
        /// 台位类型Id
        /// </summary>
        /// <value>
        /// The desk type identifier.
        /// </value>
        /// 创建者：苏建峰
        /// 创建日期：3/22/2014 11:15 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int DeskTypeId { get; set; }

        /// <summary>
        /// 预订日期
        /// </summary>
        /// <value>
        /// The booking date.
        /// </value>
        /// 创建者：苏建峰
        /// 创建日期：3/22/2014 11:15 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public DateTime BookingDate { get; set; }

        /// <summary>
        /// 预订时间
        /// </summary>
        /// <value>
        /// The booking time.
        /// </value>
        /// 创建者：苏建峰
        /// 创建日期：3/22/2014 11:16 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string BookingTime { get; set; }
    }
}