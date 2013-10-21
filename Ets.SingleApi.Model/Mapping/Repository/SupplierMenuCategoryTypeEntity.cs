// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SupplierMenuCategoryTypeEntity.cs" company="Irdeto">
//   Copyright @ 2013
// </copyright>
// <summary>
//   Class:SupplierMenuCategoryTypeEntity
//   Namespace:Ets.SingleApi.Model.Repository
//   Class Funtion:Represent the class mapping the SupplierMenuCategoryTypeEntity table in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ets.SingleApi.Model.Repository
{
	using System;
	using System.Collections.Generic;
		
    /// <summary>
    /// Class:SupplierMenuCategoryTypeEntity
    /// Namespace:Ets.SingleApi.Model.Repository
    /// Class Funtion:Represent the class mapping the SupplierMenuCategoryTypeEntity table in the database.
    /// </summary>
    /// Creator:周超
    /// Creation Date:2013/10/13 14:27:05
    /// Modifier:
    /// Last Modified:
    /// ----------------------------------------------------------------------------------------
    [Serializable]
    public class SupplierMenuCategoryTypeEntity
    {
		#region private member

			/// <summary>
		/// The SupplierMenuCategoryTypeID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int supplierMenuCategoryTypeId;

			/// <summary>
		/// The SupplierMenuCategoryType
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string supplierMenuCategoryType;

			/// <summary>
		/// The SupplierMenuCategoryList
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private IList<SupplierMenuCategoryEntity> supplierMenuCategoryList;

		#endregion

		/// <summary>
        /// Initializes a new instance of the <see cref="SupplierMenuCategoryTypeEntity"/> class.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public SupplierMenuCategoryTypeEntity()
        {
			this.supplierMenuCategoryTypeId = 0;
			this.supplierMenuCategoryType = string.Empty;
		}

		#region public member

			/// <summary>
        /// Gets or sets a value mapping the SupplierMenuCategoryTypeID of SupplierMenuCategoryTypeEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int SupplierMenuCategoryTypeId
		{
            get
            {
                return this.supplierMenuCategoryTypeId;
            }

            set
            {
                this.supplierMenuCategoryTypeId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the SupplierMenuCategoryType of SupplierMenuCategoryTypeEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string SupplierMenuCategoryType
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

			/// <summary>
        /// Gets or sets a value mapping the SupplierMenuCategoryList of SupplierMenuCategoryTypeEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual IList<SupplierMenuCategoryEntity> SupplierMenuCategoryList
		{
            get
            {
                return this.supplierMenuCategoryList;
            }

            set
            {
                this.supplierMenuCategoryList = value;
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
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public override bool Equals(object obj)
        {
            if (obj == null || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }

            var castObj = (SupplierMenuCategoryTypeEntity)obj;
            return this.SupplierMenuCategoryTypeId == castObj.SupplierMenuCategoryTypeId;
        }

		/// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public override int GetHashCode()
		{
			var hash = 57; 
			hash = 27 * hash * this.SupplierMenuCategoryTypeId.GetHashCode();
			return hash;
		}
	}
}