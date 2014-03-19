// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DeskTypeLockLogEntity.cs" company="Irdeto">
//   Copyright @ 2014
// </copyright>
// <summary>
//   Class:DeskTypeLockLogEntity
//   Namespace:Ets.SingleApi.Model.Repository
//   Class Funtion:Represent the class mapping the DeskTypeLockLogEntity table in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ets.SingleApi.Model.Repository
{
	using System;
		
    /// <summary>
    /// Class:DeskTypeLockLogEntity
    /// Namespace:Ets.SingleApi.Model.Repository
    /// Class Funtion:Represent the class mapping the DeskTypeLockLogEntity table in the database.
    /// </summary>
    /// Creator:ww
    /// Creation Date:2014-3-19 10:42:45
    /// Modifier:
    /// Last Modified:
    /// ----------------------------------------------------------------------------------------
    [Serializable]
    public class DeskTypeLockLogEntity
    {
		#region private member

			/// <summary>
		/// The Id
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-19 10:42:45
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int id;

			/// <summary>
		/// The IsDel
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-19 10:42:45
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private bool isDel;

			/// <summary>
		/// The LockDate
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-19 10:42:45
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private DateTime lockDate;

			/// <summary>
		/// The CreateTime
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-19 10:42:45
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private DateTime createTime;

			/// <summary>
		/// The SupplierId
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-19 10:42:45
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int supplierId;

			/// <summary>
		/// The DeskTypeId
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-19 10:42:45
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int deskTypeId;

			/// <summary>
		/// The SupplierDeskTimeId
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-19 10:42:45
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private SupplierDeskTimeEntity supplierDeskTime;

		#endregion

		/// <summary>
        /// Initializes a new instance of the <see cref="DeskTypeLockLogEntity"/> class.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-19 10:42:45
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public DeskTypeLockLogEntity()
        {
			this.id = 0;
			this.isDel = false;
			this.lockDate = DateTime.Now;
			this.createTime = DateTime.Now;
			this.supplierId = 0;
			this.deskTypeId = 0;
		}

		#region public member

			/// <summary>
        /// Gets or sets a value mapping the Id of DeskTypeLockLogEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-19 10:42:45
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
        /// Gets or sets a value indicating whether mapping the IsDel of DeskTypeLockLogEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-19 10:42:45
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
        /// Gets or sets a value mapping the LockDate of DeskTypeLockLogEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-19 10:42:45
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual DateTime LockDate
		{
            get
            {
                return this.lockDate;
            }

            set
            {
                this.lockDate = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the CreateTime of DeskTypeLockLogEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-19 10:42:45
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
        /// Gets or sets a value mapping the SupplierId of DeskTypeLockLogEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-19 10:42:45
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
        /// Gets or sets a value mapping the DeskTypeId of DeskTypeLockLogEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-19 10:42:45
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int DeskTypeId
		{
            get
            {
                return this.deskTypeId;
            }

            set
            {
                this.deskTypeId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the SupplierDeskTimeId of DeskTypeLockLogEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-19 10:42:45
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual SupplierDeskTimeEntity SupplierDeskTime
		{
            get
            {
                return this.supplierDeskTime;
            }

            set
            {
                this.supplierDeskTime = value;
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
        /// Creation Date:2014-3-19 10:42:45
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public override bool Equals(object obj)
        {
            if (obj == null || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }

            var castObj = (DeskTypeLockLogEntity)obj;
            return this.Id == castObj.Id;
        }

		/// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        /// Creator:ww
        /// Creation Date:2014-3-19 10:42:45
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