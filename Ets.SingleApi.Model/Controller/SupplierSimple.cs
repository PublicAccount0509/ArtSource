namespace Ets.SingleApi.Model.Controller
{
    /// <summary>
    /// 类名称：SupplierSimple
    /// 命名空间：Ets.SingleApi.Model.Controller
    /// 类功能：餐厅基本信息
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/15 17:51
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class SupplierSimple
    {
        /// <summary>
        /// Gets or sets the SupplierId of Supplier
        /// </summary>
        /// <value>
        /// The SupplierId
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/16 14:09
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int SupplierId { get; set; }

        /// <summary>
        /// Gets or sets the SupplierGroupId of SupplierDetailModel
        /// </summary>
        /// <value>
        /// The SupplierGroupId
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/22 9:37
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int? SupplierGroupId { get; set; }

        /// <summary>
        /// Gets or sets the name of the supplier.
        /// </summary>
        /// <value>
        /// The name of the supplier.
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/16 14:09
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string SupplierName { get; set; }

        /// <summary>
        /// Gets or sets the Address of Supplier
        /// </summary>
        /// <value>
        /// The Address
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/16 14:10
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the Telephone of Supplier
        /// </summary>
        /// <value>
        /// The Telephone
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/16 14:10
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string Telephone { get; set; }

        /// <summary>
        /// Gets or sets the SupplierDescription of SupplierDetail
        /// </summary>
        /// <value>
        /// The SupplierDescription
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/16 14:10
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string SupplierDescription { get; set; }

        /// <summary>
        /// Gets or sets the Averageprice of Supplier
        /// </summary>
        /// <value>
        /// The Averageprice
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/16 14:10
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public double? Averageprice { get; set; }

        /// <summary>
        /// Gets or sets the PackagingFee of SupplierDetail
        /// </summary>
        /// <value>
        /// The PackagingFee
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/22/2013 4:36 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public decimal PackagingFee { get; set; }

        /// <summary>
        /// Gets or sets the FixedDeliveryCharge of SupplierDetail
        /// </summary>
        /// <value>
        /// The FixedDeliveryCharge
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/22/2013 4:36 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int FixedDeliveryCharge { get; set; }

        /// <summary>
        /// Gets or sets the FreeDeliveryLine of SupplierDetail
        /// </summary>
        /// <value>
        /// The FreeDeliveryLine
        /// </value>
        /// 创建者：周超
        /// 创建日期：11/11/2013 11:00 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public decimal FreeDeliveryLine { get; set; }

        /// <summary>
        /// Gets or sets the DelMinOrderAmount of SupplierDetail
        /// </summary>
        /// <value>
        /// The DelMinOrderAmount
        /// </value>
        /// 创建者：周超
        /// 创建日期：11/11/2013 11:01 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int DelMinOrderAmount { get; set; }

        /// <summary>
        /// Gets or sets the BaIduLat of SupplierDetail
        /// </summary>
        /// <value>
        /// The BaIduLat
        /// </value>
        /// 创建者：周超
        /// 创建日期：11/12/2013 4:01 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public decimal BaIduLat { get; set; }

        /// <summary>
        /// Gets or sets the BaIduLong of SupplierDetail
        /// </summary>
        /// <value>
        /// The BaIduLong
        /// </value>
        /// 创建者：周超
        /// 创建日期：11/12/2013 4:01 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public decimal BaIduLong { get; set; }
    }
}