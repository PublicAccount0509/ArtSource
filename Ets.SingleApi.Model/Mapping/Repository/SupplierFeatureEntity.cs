// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SupplierFeatureEntity.cs" company="Irdeto">
//   Copyright @ 2013
// </copyright>
// <summary>
//   Class:SupplierFeatureEntity
//   Namespace:Ets.SingleApi.Model.Repository
//   Class Funtion:Represent the class mapping the SupplierFeatureEntity table in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ets.SingleApi.Model.Repository
{
	using System;
		
    /// <summary>
    /// Class:SupplierFeatureEntity
    /// Namespace:Ets.SingleApi.Model.Repository
    /// Class Funtion:Represent the class mapping the SupplierFeatureEntity table in the database.
    /// </summary>
    /// Creator:周超
    /// Creation Date:2013/10/13 14:01:30
    /// Modifier:
    /// Last Modified:
    /// ----------------------------------------------------------------------------------------
    [Serializable]
    public class SupplierFeatureEntity
    {
		#region private member

			/// <summary>
		/// The SupplierFeatureID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int supplierFeatureId;

			/// <summary>
		/// The IsEnabled
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private bool? isEnabled;

			/// <summary>
		/// The DateUpdated
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private DateTime? dateUpdated;

			/// <summary>
		/// The FeatureID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private FeatureEntity feature;

			/// <summary>
		/// The SupplierID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private SupplierEntity supplier;

		#endregion

		/// <summary>
        /// Initializes a new instance of the <see cref="SupplierFeatureEntity"/> class.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public SupplierFeatureEntity()
        {
			this.supplierFeatureId = 0;
		}

		#region public member

			/// <summary>
        /// Gets or sets a value mapping the SupplierFeatureID of SupplierFeatureEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int SupplierFeatureId
		{
            get
            {
                return this.supplierFeatureId;
            }

            set
            {
                this.supplierFeatureId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value indicating whether mapping the IsEnabled of SupplierFeatureEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual bool? IsEnabled
		{
            get
            {
                return this.isEnabled;
            }

            set
            {
                this.isEnabled = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the DateUpdated of SupplierFeatureEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual DateTime? DateUpdated
		{
            get
            {
                return this.dateUpdated;
            }

            set
            {
                this.dateUpdated = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the FeatureID of SupplierFeatureEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual FeatureEntity Feature
		{
            get
            {
                return this.feature;
            }

            set
            {
                this.feature = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the SupplierID of SupplierFeatureEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual SupplierEntity Supplier
		{
            get
            {
                return this.supplier;
            }

            set
            {
                this.supplier = value;
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
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public override bool Equals(object obj)
        {
            if (obj == null || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }

            var castObj = (SupplierFeatureEntity)obj;
            return this.SupplierFeatureId == castObj.SupplierFeatureId;
        }

		/// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public override int GetHashCode()
		{
			var hash = 57; 
			hash = 27 * hash * this.SupplierFeatureId.GetHashCode();
			return hash;
		}
	}
}