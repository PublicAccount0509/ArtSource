namespace Ets.SingleApi.Model.Controller
{
    using System;

    /// <summary>
    /// 类名称：SupplierDetail
    /// 命名空间：Ets.SingleApi.Model.Services
    /// 类功能：餐厅列表
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/15 17:51
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class SupplierDetail
    {
        /// <summary>
        /// Gets or sets the SupplierId of SupplierDetail
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
        /// Gets or sets the Address of SupplierDetail
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
        /// Gets or sets the Telephone of SupplierDetail
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
        /// Gets or sets the Averageprice of SupplierDetail
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
        /// Gets or sets the ParkingInfo of SupplierDetail
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
        /// Gets or sets the name of the cuisine.
        /// </summary>
        /// <value>
        /// The name of the cuisine.
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/16 14:10
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string CuisineName { get; set; }

        /// <summary>
        /// Gets or sets the LogoUrl of SupplierDetail
        /// </summary>
        /// <value>
        /// The LogoUrl
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/16 14:10
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string LogoUrl { get; set; }

        /// <summary>
        /// Gets or sets the IsOpenDoor of SupplierDetail
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
        /// Gets or sets the DateJoined of SupplierDetail
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
        /// Gets or sets the ServiceTime of SupplierDetail
        /// </summary>
        /// <value>
        /// The ServiceTime
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/19 23:31
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string ServiceTime { get; set; }

        /// <summary>
        /// Gets or sets the ChainCount of SupplierModel
        /// </summary>
        /// <value>
        /// The ChainCount
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/20 9:08
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public int ChainCount { get; set; }

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

        /// <summary>
        /// Gets or sets the Fax of SupplierDetail
        /// </summary>
        /// <value>
        /// The Fax
        /// </value>
        /// 创建者：周超
        /// 创建日期：11/20/2013 2:46 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string Fax { get; set; }

        /// <summary>
        /// Gets or sets the Email of SupplierDetail
        /// </summary>
        /// <value>
        /// The Email
        /// </value>
        /// 创建者：周超
        /// 创建日期：11/20/2013 2:46 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the TakeawaySpecialOffersSummary of SupplierDetail
        /// </summary>
        /// <value>
        /// The TakeawaySpecialOffersSummary
        /// </value>
        /// 创建者：周超
        /// 创建日期：11/20/2013 2:46 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string TakeawaySpecialOffersSummary { get; set; }

        /// <summary>
        /// Gets or sets the PublicTransport of SupplierDetail
        /// </summary>
        /// <value>
        /// The PublicTransport
        /// </value>
        /// 创建者：周超
        /// 创建日期：11/20/2013 2:46 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string PublicTransport { get; set; }

        /// <summary>
        /// Gets or sets the SupplierDiningPurpose of SupplierDetail
        /// </summary>
        /// <value>
        /// The SupplierDiningPurpose
        /// </value>
        /// 创建者：周超
        /// 创建日期：11/20/2013 4:20 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public string SupplierDiningPurpose { get; set; }

        /// <summary>
        /// Gets or sets the PackLadder of SupplierDetail
        /// </summary>
        /// <value>
        /// The PackLadder
        /// </value>
        /// 创建者：周超
        /// 创建日期：11/20/2013 2:46 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public decimal PackLadder { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether
        /// </summary>
        /// <value>
        /// The IsWaiMai
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/22/2013 12:12 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public bool IsWaiMai { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether
        /// </summary>
        /// <value>
        /// The IsDingTai
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/22/2013 12:12 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public bool IsDingTai { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether
        /// </summary>
        /// <value>
        /// The IsTangShi
        /// </value>
        /// 创建者：周超
        /// 创建日期：10/22/2013 12:12 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public bool IsTangShi { get; set; }
    }
}