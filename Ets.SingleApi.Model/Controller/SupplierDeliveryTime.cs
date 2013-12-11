namespace Ets.SingleApi.Model.Controller
{
    using System.Collections.Generic;

    /// <summary>
    /// 类名称：SupplierDeliveryTime
    /// 命名空间：Ets.SingleApi.Model.Controller
    /// 类功能：餐厅送餐时间
    /// </summary>
    /// 创建者：周超
    /// 创建日期：12/2/2013 11:36 AM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class SupplierDeliveryTime
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
        /// 设置或取得餐厅送餐日期
        /// </summary>
        /// <value>
        /// 餐厅送餐日期
        /// </value>
        /// 创建者：周超
        /// 创建日期：12/2/2013 11:37 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string DeliveryDate { get; set; }

        /// <summary>
        /// 设置或取得餐厅送餐时间
        /// </summary>
        /// <value>
        /// 餐厅送餐时间
        /// </value>
        /// 创建者：周超
        /// 创建日期：12/2/2013 11:37 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string DeliveryTime { get; set; }

        /// <summary>
        /// 设置或取得送餐时间列表
        /// </summary>
        /// <value>
        /// 送餐时间列表
        /// </value>
        /// 创建者：周超
        /// 创建日期：12/2/2013 11:37 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public List<string> DeliveryTimeList { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SupplierDeliveryTime"/> class.
        /// </summary>
        /// 创建者：周超
        /// 创建日期：12/2/2013 11:45 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public SupplierDeliveryTime()
        {
            this.DeliveryTimeList = new List<string>();
        }
    }
}