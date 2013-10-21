// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SupplierLocationEntity.cs" company="Irdeto">
//   Copyright @ 2013
// </copyright>
// <summary>
//   Class:SupplierLocationEntity
//   Namespace:Ets.SingleApi.Model.Repository
//   Class Funtion:Represent the class mapping the SupplierLocationEntity table in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ets.SingleApi.Model.Repository
{
	using System;
		
    /// <summary>
    /// Class:SupplierLocationEntity
    /// Namespace:Ets.SingleApi.Model.Repository
    /// Class Funtion:Represent the class mapping the SupplierLocationEntity table in the database.
    /// </summary>
    /// Creator:周超
    /// Creation Date:2013/10/13 14:01:30
    /// Modifier:
    /// Last Modified:
    /// ----------------------------------------------------------------------------------------
    [Serializable]
    public class SupplierLocationEntity
    {
		#region private member

			/// <summary>
		/// The SupplierLocationID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int supplierLocationId;

			/// <summary>
		/// The LocationID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private LocationEntity location;

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
        /// Initializes a new instance of the <see cref="SupplierLocationEntity"/> class.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public SupplierLocationEntity()
        {
			this.supplierLocationId = 0;
		}

		#region public member

			/// <summary>
        /// Gets or sets a value mapping the SupplierLocationID of SupplierLocationEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int SupplierLocationId
		{
            get
            {
                return this.supplierLocationId;
            }

            set
            {
                this.supplierLocationId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the LocationID of SupplierLocationEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual LocationEntity Location
		{
            get
            {
                return this.location;
            }

            set
            {
                this.location = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the SupplierID of SupplierLocationEntity table in the database.
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

            var castObj = (SupplierLocationEntity)obj;
            return this.SupplierLocationId == castObj.SupplierLocationId;
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
			hash = 27 * hash * this.SupplierLocationId.GetHashCode();
			return hash;
		}
	}
}