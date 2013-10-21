// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SupplierMenuCategoryEntity.cs" company="Irdeto">
//   Copyright @ 2013
// </copyright>
// <summary>
//   Class:SupplierMenuCategoryEntity
//   Namespace:Ets.SingleApi.Model.Repository
//   Class Funtion:Represent the class mapping the SupplierMenuCategoryEntity table in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ets.SingleApi.Model.Repository
{
	using System;
	using System.Collections.Generic;
		
    /// <summary>
    /// Class:SupplierMenuCategoryEntity
    /// Namespace:Ets.SingleApi.Model.Repository
    /// Class Funtion:Represent the class mapping the SupplierMenuCategoryEntity table in the database.
    /// </summary>
    /// Creator:周超
    /// Creation Date:2013/10/13 14:23:32
    /// Modifier:
    /// Last Modified:
    /// ----------------------------------------------------------------------------------------
    [Serializable]
    public class SupplierMenuCategoryEntity
    {
		#region private member

			/// <summary>
		/// The SupplierMenuCategoryId
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:23:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int supplierMenuCategoryId;

			/// <summary>
		/// The SupplierId
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:23:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private decimal? supplierId;

			/// <summary>
		/// The SupplierMenuCategoryName
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:23:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string supplierMenuCategoryName;

			/// <summary>
		/// The SupplierMenuCategoryDescription
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:23:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string supplierMenuCategoryDescription;

			/// <summary>
		/// The SupplierMenuCategoryOrder
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:23:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? supplierMenuCategoryOrder;

			/// <summary>
		/// The SupplierMenuCategoryOldId
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:23:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? supplierMenuCategoryOldId;

			/// <summary>
		/// The CuisineList
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:23:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private IList<CuisineEntity> cuisineList;

			/// <summary>
		/// The SupplierMenuCategoryTypeID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:23:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private SupplierMenuCategoryTypeEntity supplierMenuCategoryType;

		#endregion

		/// <summary>
        /// Initializes a new instance of the <see cref="SupplierMenuCategoryEntity"/> class.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:23:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public SupplierMenuCategoryEntity()
        {
			this.supplierMenuCategoryId = 0;
			this.supplierMenuCategoryName = string.Empty;
			this.supplierMenuCategoryDescription = string.Empty;
		}

		#region public member

			/// <summary>
        /// Gets or sets a value mapping the SupplierMenuCategoryId of SupplierMenuCategoryEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:23:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int SupplierMenuCategoryId
		{
            get
            {
                return this.supplierMenuCategoryId;
            }

            set
            {
                this.supplierMenuCategoryId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the SupplierId of SupplierMenuCategoryEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:23:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual decimal? SupplierId
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
        /// Gets or sets a value mapping the SupplierMenuCategoryName of SupplierMenuCategoryEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:23:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string SupplierMenuCategoryName
		{
            get
            {
                return this.supplierMenuCategoryName;
            }

            set
            {
                this.supplierMenuCategoryName = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the SupplierMenuCategoryDescription of SupplierMenuCategoryEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:23:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string SupplierMenuCategoryDescription
		{
            get
            {
                return this.supplierMenuCategoryDescription;
            }

            set
            {
                this.supplierMenuCategoryDescription = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the SupplierMenuCategoryOrder of SupplierMenuCategoryEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:23:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? SupplierMenuCategoryOrder
		{
            get
            {
                return this.supplierMenuCategoryOrder;
            }

            set
            {
                this.supplierMenuCategoryOrder = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the SupplierMenuCategoryOldId of SupplierMenuCategoryEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:23:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? SupplierMenuCategoryOldId
		{
            get
            {
                return this.supplierMenuCategoryOldId;
            }

            set
            {
                this.supplierMenuCategoryOldId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the CuisineList of SupplierMenuCategoryEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:23:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual IList<CuisineEntity> CuisineList
		{
            get
            {
                return this.cuisineList;
            }

            set
            {
                this.cuisineList = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the SupplierMenuCategoryTypeID of SupplierMenuCategoryEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:23:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual SupplierMenuCategoryTypeEntity SupplierMenuCategoryType
		{
            get
            {
                return this.supplierMenuCategoryType;
            }

            set
            {
                this.supplierMenuCategoryType = value;
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
        /// Creator:周超
        /// Creation Date:2013/10/13 14:23:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public override bool Equals(object obj)
        {
            if (obj == null || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }

            var castObj = (SupplierMenuCategoryEntity)obj;
            return this.SupplierMenuCategoryId == castObj.SupplierMenuCategoryId;
        }

		/// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:23:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public override int GetHashCode()
		{
			var hash = 57; 
			hash = 27 * hash * this.SupplierMenuCategoryId.GetHashCode();
			return hash;
		}
	}
}