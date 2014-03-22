// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SupplierDeskTimeEntity.cs" company="Irdeto">
//   Copyright @ 2014
// </copyright>
// <summary>
//   Class:SupplierDeskTimeEntity
//   Namespace:Ets.SingleApi.Model.Repository
//   Class Funtion:Represent the class mapping the SupplierDeskTimeEntity table in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ets.SingleApi.Model.Repository
{
	using System;
	using System.Collections.Generic;
		
    /// <summary>
    /// Class:SupplierDeskTimeEntity
    /// Namespace:Ets.SingleApi.Model.Repository
    /// Class Funtion:Represent the class mapping the SupplierDeskTimeEntity table in the database.
    /// </summary>
    /// Creator:ww
    /// Creation Date:2014-3-21 15:03:39
    /// Modifier:
    /// Last Modified:
    /// ----------------------------------------------------------------------------------------
    [Serializable]
    public class SupplierDeskTimeEntity
    {
		#region private member

			/// <summary>
		/// The Id
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-21 15:03:39
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int id;

			/// <summary>
		/// The TimeName
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-21 15:03:39
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string timeName;

			/// <summary>
		/// The BeginTime
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-21 15:03:39
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string beginTime;

			/// <summary>
		/// The EndTime
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-21 15:03:39
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string endTime;

			/// <summary>
		/// The SupplierId
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-21 15:03:39
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int supplierId;

			/// <summary>
		/// The CreateTime
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-21 15:03:39
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private DateTime createTime;

			/// <summary>
		/// The UpdateTime
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-21 15:03:39
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private DateTime updateTime;

			/// <summary>
		/// The Description
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-21 15:03:39
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string description;

			/// <summary>
		/// The IsSpecial
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-21 15:03:39
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private bool? isSpecial;

			/// <summary>
		/// The IsEnable
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-21 15:03:39
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private bool? isEnable;

			/// <summary>
		/// The TimeType
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-21 15:03:39
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? timeType;

			/// <summary>
		/// The DeskTypeLockLogList
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-21 15:03:39
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private IList<DeskTypeLockLogEntity> deskTypeLockLogList;

		#endregion

		/// <summary>
        /// Initializes a new instance of the <see cref="SupplierDeskTimeEntity"/> class.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-21 15:03:39
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public SupplierDeskTimeEntity()
        {
			this.id = 0;
			this.timeName = string.Empty;
			this.beginTime = string.Empty;
			this.endTime = string.Empty;
			this.supplierId = 0;
			this.createTime = DateTime.Now;
			this.updateTime = DateTime.Now;
			this.description = string.Empty;
		}

		#region public member

			/// <summary>
        /// Gets or sets a value mapping the Id of SupplierDeskTimeEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-21 15:03:39
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
        /// Gets or sets a value mapping the TimeName of SupplierDeskTimeEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-21 15:03:39
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string TimeName
		{
            get
            {
                return this.timeName;
            }

            set
            {
                this.timeName = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the BeginTime of SupplierDeskTimeEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-21 15:03:39
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string BeginTime
		{
            get
            {
                return this.beginTime;
            }

            set
            {
                this.beginTime = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the EndTime of SupplierDeskTimeEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-21 15:03:39
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string EndTime
		{
            get
            {
                return this.endTime;
            }

            set
            {
                this.endTime = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the SupplierId of SupplierDeskTimeEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-21 15:03:39
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
        /// Gets or sets a value mapping the CreateTime of SupplierDeskTimeEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-21 15:03:39
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
        /// Gets or sets a value mapping the UpdateTime of SupplierDeskTimeEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-21 15:03:39
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
        /// Gets or sets a value mapping the Description of SupplierDeskTimeEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-21 15:03:39
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
        /// Gets or sets a value indicating whether mapping the IsSpecial of SupplierDeskTimeEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-21 15:03:39
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual bool? IsSpecial
		{
            get
            {
                return this.isSpecial;
            }

            set
            {
                this.isSpecial = value;
            }
        }

			/// <summary>
        /// Gets or sets a value indicating whether mapping the IsEnable of SupplierDeskTimeEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-21 15:03:39
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual bool? IsEnable
		{
            get
            {
                return this.isEnable;
            }

            set
            {
                this.isEnable = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the TimeType of SupplierDeskTimeEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-21 15:03:39
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? TimeType
		{
            get
            {
                return this.timeType;
            }

            set
            {
                this.timeType = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the DeskTypeLockLogList of SupplierDeskTimeEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-21 15:03:39
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual IList<DeskTypeLockLogEntity> DeskTypeLockLogList
		{
            get
            {
                return this.deskTypeLockLogList;
            }

            set
            {
                this.deskTypeLockLogList = value;
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
        /// Creation Date:2014-3-21 15:03:39
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public override bool Equals(object obj)
        {
            if (obj == null || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }

            var castObj = (SupplierDeskTimeEntity)obj;
            return this.Id == castObj.Id;
        }

		/// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        /// Creator:ww
        /// Creation Date:2014-3-21 15:03:39
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