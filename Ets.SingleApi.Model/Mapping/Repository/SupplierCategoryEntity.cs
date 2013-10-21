// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SupplierCategoryEntity.cs" company="Irdeto">
//   Copyright @ 2013
// </copyright>
// <summary>
//   Class:SupplierCategoryEntity
//   Namespace:Ets.SingleApi.Model.Repository
//   Class Funtion:Represent the class mapping the SupplierCategoryEntity table in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ets.SingleApi.Model.Repository
{
	using System;
		
    /// <summary>
    /// Class:SupplierCategoryEntity
    /// Namespace:Ets.SingleApi.Model.Repository
    /// Class Funtion:Represent the class mapping the SupplierCategoryEntity table in the database.
    /// </summary>
    /// Creator:周超
    /// Creation Date:2013/10/13 14:32:24
    /// Modifier:
    /// Last Modified:
    /// ----------------------------------------------------------------------------------------
    [Serializable]
    public class SupplierCategoryEntity
    {
		#region private member

			/// <summary>
		/// The SupplierCategoryID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:32:24
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int supplierCategoryId;

			/// <summary>
		/// The SupplierID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:32:24
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int supplierId;

			/// <summary>
		/// The CategoryOrder
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:32:24
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int categoryOrder;

			/// <summary>
		/// The SupplierMenuCategoryId
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:32:24
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? supplierMenuCategoryId;

			/// <summary>
		/// The CategoryID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:32:24
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private CategoryEntity category;

		#endregion

		/// <summary>
        /// Initializes a new instance of the <see cref="SupplierCategoryEntity"/> class.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:32:24
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public SupplierCategoryEntity()
        {
			this.supplierCategoryId = 0;
			this.supplierId = 0;
			this.categoryOrder = 0;
		}

		#region public member

			/// <summary>
        /// Gets or sets a value mapping the SupplierCategoryID of SupplierCategoryEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:32:24
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int SupplierCategoryId
		{
            get
            {
                return this.supplierCategoryId;
            }

            set
            {
                this.supplierCategoryId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the SupplierID of SupplierCategoryEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:32:24
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
        /// Gets or sets a value mapping the CategoryOrder of SupplierCategoryEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:32:24
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int CategoryOrder
		{
            get
            {
                return this.categoryOrder;
            }

            set
            {
                this.categoryOrder = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the SupplierMenuCategoryId of SupplierCategoryEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:32:24
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? SupplierMenuCategoryId
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
        /// Gets or sets a value mapping the CategoryID of SupplierCategoryEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:32:24
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual CategoryEntity Category
		{
            get
            {
                return this.category;
            }

            set
            {
                this.category = value;
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
        /// Creation Date:2013/10/13 14:32:24
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public override bool Equals(object obj)
        {
            if (obj == null || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }

            var castObj = (SupplierCategoryEntity)obj;
            return this.SupplierCategoryId == castObj.SupplierCategoryId;
        }

		/// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:32:24
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public override int GetHashCode()
		{
			var hash = 57; 
			hash = 27 * hash * this.SupplierCategoryId.GetHashCode();
			return hash;
		}
	}
}