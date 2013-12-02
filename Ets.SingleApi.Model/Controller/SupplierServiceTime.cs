namespace Ets.SingleApi.Model.Controller
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// 类名称：SupplierServiceTime
    /// 命名空间：Ets.SingleApi.Model.Controller
    /// 类功能：餐厅营业时间
    /// </summary>
    /// 创建者：周超
    /// 创建日期：12/2/2013 11:36 AM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class SupplierServiceTime
    {
        /// <summary>
        /// 设置或取得餐厅Id
        /// </summary>
        /// <value>
        /// 餐厅Id
        /// </value>
        /// 创建者：周超
        /// 创建日期：12/2/2013 11:36 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int SupplierId { get; set; }

        /// <summary>
        /// 设置或取得餐厅营业日期
        /// </summary>
        /// <value>
        /// 餐厅营业日期
        /// </value>
        /// 创建者：周超
        /// 创建日期：12/2/2013 11:37 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string ServiceDate { get; set; }

        /// <summary>
        /// 设置或取得营业时间列表
        /// </summary>
        /// <value>
        /// 营业时间列表
        /// </value>
        /// 创建者：周超
        /// 创建日期：12/2/2013 11:37 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public List<string> ServiceTimeList { get; set; }
    }
}