// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DeskTypeEntity.cs" company="Irdeto">
//   Copyright @ 2014
// </copyright>
// <summary>
//   Class:DeskTypeEntity
//   Namespace:Ets.SingleApi.Model.Repository
//   Class Funtion:Represent the class mapping the DeskTypeEntity table in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ets.SingleApi.Model.Repository
{
	using System;
	using System.Collections.Generic;
		
    /// <summary>
    /// Class:DeskTypeEntity
    /// Namespace:Ets.SingleApi.Model.Repository
    /// Class Funtion:Represent the class mapping the DeskTypeEntity table in the database.
    /// </summary>
    /// Creator:ww
    /// Creation Date:2014-3-20 16:37:43
    /// Modifier:
    /// Last Modified:
    /// ----------------------------------------------------------------------------------------
    [Serializable]
    public class DeskTypeEntity
    {
		#region private member

			/// <summary>
		/// The Id
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-20 16:37:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int id;

			/// <summary>
		/// The DeskTypeName
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-20 16:37:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string deskTypeName;

			/// <summary>
		/// The RoomType
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-20 16:37:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? roomType;

			/// <summary>
		/// The MaxNumber
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-20 16:37:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int maxNumber;

			/// <summary>
		/// The MinNumber
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-20 16:37:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int minNumber;

			/// <summary>
		/// The LowCost
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-20 16:37:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private decimal? lowCost;

			/// <summary>
		/// The IsLock
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-20 16:37:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private bool isLock;

			/// <summary>
		/// The IsDel
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-20 16:37:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private bool isDel;

			/// <summary>
		/// The SupplierId
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-20 16:37:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int supplierId;

			/// <summary>
		/// The CreateTime
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-20 16:37:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private DateTime createTime;

			/// <summary>
		/// The UpdateTime
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-20 16:37:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private DateTime updateTime;

			/// <summary>
		/// The Description
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-20 16:37:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string description;

			/// <summary>
		/// The DepositAmount
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-20 16:37:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private decimal? depositAmount;

			/// <summary>
		/// The BoxName
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-20 16:37:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string boxName;

			/// <summary>
		/// The QueueDeskTypeLockLogList
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-20 16:37:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private IList<QueueDeskTypeLockLogEntity> queueDeskTypeLockLogList;

			/// <summary>
		/// The SupplierDeskList
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-20 16:37:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private IList<SupplierDeskEntity> supplierDeskList;

			/// <summary>
		/// The TableTypeId
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-20 16:37:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private TableTypeEntity tableType;

		#endregion

		/// <summary>
        /// Initializes a new instance of the <see cref="DeskTypeEntity"/> class.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-20 16:37:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public DeskTypeEntity()
        {
			this.id = 0;
			this.deskTypeName = string.Empty;
			this.maxNumber = 0;
			this.minNumber = 0;
			this.isLock = false;
			this.isDel = false;
			this.supplierId = 0;
			this.createTime = DateTime.Now;
			this.updateTime = DateTime.Now;
			this.description = string.Empty;
			this.boxName = string.Empty;
		}

		#region public member

			/// <summary>
        /// Gets or sets a value mapping the Id of DeskTypeEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-20 16:37:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int Id
		{
            get
            {
                return this.id;
            }

            set
            {
                this.id = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the DeskTypeName of DeskTypeEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-20 16:37:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string DeskTypeName
		{
            get
            {
                return this.deskTypeName;
            }

            set
            {
                this.deskTypeName = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the RoomType of DeskTypeEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-20 16:37:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? RoomType
		{
            get
            {
                return this.roomType;
            }

            set
            {
                this.roomType = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the MaxNumber of DeskTypeEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-20 16:37:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int MaxNumber
		{
            get
            {
                return this.maxNumber;
            }

            set
            {
                this.maxNumber = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the MinNumber of DeskTypeEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-20 16:37:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int MinNumber
		{
            get
            {
                return this.minNumber;
            }

            set
            {
                this.minNumber = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the LowCost of DeskTypeEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-20 16:37:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual decimal? LowCost
		{
            get
            {
                return this.lowCost;
            }

            set
            {
                this.lowCost = value;
            }
        }

			/// <summary>
        /// Gets or sets a value indicating whether mapping the IsLock of DeskTypeEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-20 16:37:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual bool IsLock
		{
            get
            {
                return this.isLock;
            }

            set
            {
                this.isLock = value;
            }
        }

			/// <summary>
        /// Gets or sets a value indicating whether mapping the IsDel of DeskTypeEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-20 16:37:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual bool IsDel
		{
            get
            {
                return this.isDel;
            }

            set
            {
                this.isDel = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the SupplierId of DeskTypeEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-20 16:37:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int SupplierId
		{
            get
            {
                return this.supplierId;
            }

            set
            {
                this.supplierId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the CreateTime of DeskTypeEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-20 16:37:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual DateTime CreateTime
		{
            get
            {
                return this.createTime;
            }

            set
            {
                this.createTime = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the UpdateTime of DeskTypeEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-20 16:37:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual DateTime UpdateTime
		{
            get
            {
                return this.updateTime;
            }

            set
            {
                this.updateTime = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Description of DeskTypeEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-20 16:37:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string Description
		{
            get
            {
                return this.description;
            }

            set
            {
                this.description = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the DepositAmount of DeskTypeEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-20 16:37:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual decimal? DepositAmount
		{
            get
            {
                return this.depositAmount;
            }

            set
            {
                this.depositAmount = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the BoxName of DeskTypeEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-20 16:37:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string BoxName
		{
            get
            {
                return this.boxName;
            }

            set
            {
                this.boxName = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the QueueDeskTypeLockLogList of DeskTypeEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-20 16:37:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual IList<QueueDeskTypeLockLogEntity> QueueDeskTypeLockLogList
		{
            get
            {
                return this.queueDeskTypeLockLogList;
            }

            set
            {
                this.queueDeskTypeLockLogList = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the SupplierDeskList of DeskTypeEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-20 16:37:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual IList<SupplierDeskEntity> SupplierDeskList
		{
            get
            {
                return this.supplierDeskList;
            }

            set
            {
                this.supplierDeskList = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the TableTypeId of DeskTypeEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-20 16:37:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual TableTypeEntity TableType
		{
            get
            {
                return this.tableType;
            }

            set
            {
                this.tableType = value;
            }
        }

		#endregion

			/// <summary>
        /// Determines whether the specified is equal to this instance.
        /// </summary>
        /// <param name="obj">The to compare with this instance.</param>
        /// <returns>
        /// true if the specified is equal to this instance; otherwise,false.
        /// </returns>
        /// Creator:ww
        /// Creation Date:2014-3-20 16:37:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public override bool Equals(object obj)
        {
            if (obj == null || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }

            var castObj = (DeskTypeEntity)obj;
            return this.Id == castObj.Id;
        }

		/// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        /// Creator:ww
        /// Creation Date:2014-3-20 16:37:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public override int GetHashCode()
		{
			var hash = 57; 
			hash = 27 * hash * this.Id.GetHashCode();
			return hash;
		}
	}
}