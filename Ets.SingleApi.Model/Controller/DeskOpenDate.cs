using System;

namespace Ets.SingleApi.Model.Controller
{
    using System.Collections.Generic;

    /// <summary>
    /// 类名称：DeskOpenDate
    /// 命名空间：Ets.SingleApi.Model.Controller
    /// 类功能：餐厅订台开放日期
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/19 18:10
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class DeskOpenDate
    {
        /// <summary>
        /// 餐厅订台开放日期
        /// </summary>
        /// <value>
        /// The date.
        /// </value>
        /// 创建者：苏建峰
        /// 创建日期：3/22/2014 7:20 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public DateTime Date { get; set; }

        /// <summary>
        /// 是否已经被锁定
        /// </summary>
        /// <value>
        ///   <c>true</c> if [is lock]; otherwise, <c>false</c>.
        /// </value>
        /// 创建者：苏建峰
        /// 创建日期：3/22/2014 7:22 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public bool IsLock { get; set; }
    }
}