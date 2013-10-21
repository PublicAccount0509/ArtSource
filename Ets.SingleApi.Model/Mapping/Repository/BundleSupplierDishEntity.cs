// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BundleSupplierDishEntity.cs" company="Irdeto">
//   Copyright @ 2013
// </copyright>
// <summary>
//   Class:BundleSupplierDishEntity
//   Namespace:Ets.SingleApi.Model.Repository
//   Class Funtion:Represent the class mapping the BundleSupplierDishEntity table in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ets.SingleApi.Model.Repository
{
	using System;
		
    /// <summary>
    /// Class:BundleSupplierDishEntity
    /// Namespace:Ets.SingleApi.Model.Repository
    /// Class Funtion:Represent the class mapping the BundleSupplierDishEntity table in the database.
    /// </summary>
    /// Creator:周超
    /// Creation Date:2013/10/13 14:18:47
    /// Modifier:
    /// Last Modified:
    /// ----------------------------------------------------------------------------------------
    [Serializable]
    public class BundleSupplierDishEntity
    {
		#region private member

			/// <summary>
		/// The SupplierDishID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:47
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int supplierDishId;

			/// <summary>
		/// The BundleID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:47
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int bundleId;

			/// <summary>
		/// The BundleID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:47
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private BundleEntity bundle;

			/// <summary>
		/// The SupplierDishID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:47
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private SupplierDishEntity supplierDish;

		#endregion

		/// <summary>
        /// Initializes a new instance of the <see cref="BundleSupplierDishEntity"/> class.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:47
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public BundleSupplierDishEntity()
        {
			this.supplierDishId = 0;
			this.bundleId = 0;
		}

		#region public member

			/// <summary>
        /// Gets or sets a value mapping the SupplierDishID of BundleSupplierDishEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:47
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int SupplierDishId
		{
            get
            {
                return this.supplierDishId;
            }

            set
            {
                this.supplierDishId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the BundleID of BundleSupplierDishEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:47
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int BundleId
		{
            get
            {
                return this.bundleId;
            }

            set
            {
                this.bundleId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the BundleID of BundleSupplierDishEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:47
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual BundleEntity Bundle
		{
            get
            {
                return this.bundle;
            }

            set
            {
                this.bundle = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the SupplierDishID of BundleSupplierDishEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:47
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual SupplierDishEntity SupplierDish
		{
            get
            {
                return this.supplierDish;
            }

            set
            {
                this.supplierDish = value;
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
        /// Creation Date:2013/10/13 14:18:47
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public override bool Equals(object obj)
        {
            if (obj == null || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }

            var castObj = (BundleSupplierDishEntity)obj;
            return this.SupplierDishId == castObj.SupplierDishId && this.BundleId == castObj.BundleId;
        }

		/// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:47
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public override int GetHashCode()
		{
			var hash = 57; 
			hash = 27 * hash * this.SupplierDishId.GetHashCode();
			hash = 27 * hash * this.BundleId.GetHashCode();
			return hash;
		}
	}
}