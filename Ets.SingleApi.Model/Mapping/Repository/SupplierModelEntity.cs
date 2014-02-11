namespace Ets.SingleApi.Model.Repository
{
    using System;

    /// <summary>
    /// 类名称：SupplierModelEntity
    /// 命名空间：Ets.SingleApi.Model.Repository
    /// 类功能：餐厅列表
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/15 17:51
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class SupplierModelEntity
    {
        /// <summary>
        /// Gets or sets the SupplierGroupId of SupplierModelEntity
        /// </summary>
        /// <value>
        /// The SupplierGroupId
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/16 14:09
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public virtual int SupplierGroupId { get; set; }

        /// <summary>
        /// Gets or sets the SupplierId of SupplierModelEntity
        /// </summary>
        /// <value>
        /// The SupplierId
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/16 14:09
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public virtual int SupplierId { get; set; }

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
        public virtual string SupplierName { get; set; }

        /// <summary>
        /// Gets or sets the Address of SupplierModelEntity
        /// </summary>
        /// <value>
        /// The Address
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/16 14:10
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public virtual string Address { get; set; }

        /// <summary>
        /// Gets or sets the Telephone of SupplierModelEntity
        /// </summary>
        /// <value>
        /// The Telephone
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/16 14:10
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public virtual string Telephone { get; set; }

        /// <summary>
        /// Gets or sets the BaIduLat of SupplierModelEntity
        /// </summary>
        /// <value>
        /// The BaIduLat
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/16 14:10
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public virtual string BaIduLat { get; set; }

        /// <summary>
        /// Gets or sets the BaIduLong of SupplierModelEntity
        /// </summary>
        /// <value>
        /// The BaIduLong
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/16 14:10
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public virtual string BaIduLong { get; set; }

        /// <summary>
        /// Gets or sets the SupplierDescription of SupplierModelEntity
        /// </summary>
        /// <value>
        /// The SupplierDescription
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/16 14:10
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public virtual string SupplierDescription { get; set; }

        /// <summary>
        /// Gets or sets the Averageprice of SupplierModelEntity
        /// </summary>
        /// <value>
        /// The Averageprice
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/16 14:10
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public virtual int? Averageprice { get; set; }

        /// <summary>
        /// Gets or sets the ParkingInfo of SupplierModelEntity
        /// </summary>
        /// <value>
        /// The ParkingInfo
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/16 14:10
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public virtual string ParkingInfo { get; set; }

        /// <summary>
        /// Gets or sets the CuisineId of SupplierModelEntity
        /// </summary>
        /// <value>
        /// The CuisineId
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/16 14:10
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public virtual int? CuisineId { get; set; }

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
        public virtual string CuisineName { get; set; }

        /// <summary>
        /// Gets or sets the LogoUrl of SupplierModelEntity
        /// </summary>
        /// <value>
        /// The LogoUrl
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/16 14:10
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public virtual string LogoUrl { get; set; }

        /// <summary>
        /// Gets or sets the IsOpenDoor of SupplierModelEntity
        /// </summary>
        /// <value>
        /// The IsOpenDoor
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/16 14:11
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public virtual bool? IsOpenDoor { get; set; }

        /// <summary>
        /// Gets or sets the Distance of SupplierModelEntity
        /// </summary>
        /// <value>
        /// The Distance
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/16 14:30
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public virtual double? Distance { get; set; }

        /// <summary>
        /// Gets or sets the DateJoined of SupplierModelEntity
        /// </summary>
        /// <value>
        /// The DateJoined
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/18 21:52
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public virtual DateTime? DateJoined { get; set; }
    }
}