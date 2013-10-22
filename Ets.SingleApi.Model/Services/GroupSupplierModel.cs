namespace Ets.SingleApi.Model.Services
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// 类名称：GroupSupplierModel
    /// 命名空间：Ets.SingleApi.Model.Services
    /// 类功能：集团餐厅列表
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/15 17:51
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class GroupSupplierModel
    {
        /// <summary>
        /// Gets or sets the SupplierId of GroupSupplierModel
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
        /// Gets or sets the Address of GroupSupplierModel
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
        /// Gets or sets the Telephone of GroupSupplierModel
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
        /// Gets or sets the SupplierDescription of GroupSupplierModel
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
        /// Gets or sets the Averageprice of GroupSupplierModel
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
        /// Gets or sets the ParkingInfo of GroupSupplierModel
        /// </summary>
        /// <value>
        /// The ParkingInfo
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/16 14:10
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string ParkingInfo { get; set; }

        /// <summary>
        /// Gets or sets the CuisineId of GroupSupplierModel
        /// </summary>
        /// <value>
        /// The CuisineId
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/16 14:10
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int? CuisineId { get; set; }

        /// <summary>
        /// Gets or sets the IsOpenDoor of GroupSupplierModel
        /// </summary>
        /// <value>
        /// The IsOpenDoor
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/16 14:11
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public bool? IsOpenDoor { get; set; }

        /// <summary>
        /// Gets or sets the DateJoined of GroupSupplierModel
        /// </summary>
        /// <value>
        /// The DateJoined
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/18 21:52
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public DateTime? DateJoined { get; set; }

        /// <summary>
        /// Gets or sets the SupplierFeatureList of GroupSupplierModel
        /// </summary>
        /// <value>
        /// The SupplierFeatureList
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/22/2013 11:36 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public List<SupplierFeatureModel> SupplierFeatureList { get; set; }
    }
}