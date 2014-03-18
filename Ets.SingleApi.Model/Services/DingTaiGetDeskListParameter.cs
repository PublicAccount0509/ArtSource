using System;

namespace Ets.SingleApi.Model.Services
{
    /// <summary>
    /// 类名称：GetGroupSupplierListParameter
    /// 命名空间：Ets.SingleApi.Model.Services
    /// 类功能：方法GetDeskList传入的参数
    /// </summary>
    /// 创建者：苏建峰
    /// 创建日期：3/18/2014 6:05 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class DingTaiGetDeskListParameter
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
        /// 预订时间
        /// </summary>
        /// <value>
        /// The supplier identifier.
        /// </value>
        /// 创建者：苏建峰
        /// 创建日期：3/18/2014 6:14 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public DateTime BookingTime { get; set; }

        /// <summary>
        /// 预订人数
        /// </summary>
        /// <value>
        /// The supplier identifier.
        /// </value>
        /// 创建者：苏建峰
        /// 创建日期：3/18/2014 6:14 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int PeopleCount { get; set; }
    }
}