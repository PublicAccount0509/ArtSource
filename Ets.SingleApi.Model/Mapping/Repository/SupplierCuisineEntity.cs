// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SupplierCuisineEntity.cs" company="Irdeto">
//   Copyright @ 2013
// </copyright>
// <summary>
//   Class:SupplierCuisineEntity
//   Namespace:Ets.SingleApi.Model.Repository
//   Class Funtion:Represent the class mapping the SupplierCuisineEntity table in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ets.SingleApi.Model.Repository
{
	using System;
		
    /// <summary>
    /// Class:SupplierCuisineEntity
    /// Namespace:Ets.SingleApi.Model.Repository
    /// Class Funtion:Represent the class mapping the SupplierCuisineEntity table in the database.
    /// </summary>
    /// Creator:周超
    /// Creation Date:2013/10/13 14:01:30
    /// Modifier:
    /// Last Modified:
    /// ----------------------------------------------------------------------------------------
    [Serializable]
    public class SupplierCuisineEntity
    {
		#region private member

			/// <summary>
		/// The SupplierCuisineID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int supplierCuisineId;

			/// <summary>
		/// The CuisineID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private CuisineEntity cuisine;

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
        /// Initializes a new instance of the <see cref="SupplierCuisineEntity"/> class.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public SupplierCuisineEntity()
        {
			this.supplierCuisineId = 0;
		}

		#region public member

			/// <summary>
        /// Gets or sets a value mapping the SupplierCuisineID of SupplierCuisineEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int SupplierCuisineId
		{
            get
            {
                return this.supplierCuisineId;
            }

            set
            {
                this.supplierCuisineId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the CuisineID of SupplierCuisineEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual CuisineEntity Cuisine
		{
            get
            {
                return this.cuisine;
            }

            set
            {
                this.cuisine = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the SupplierID of SupplierCuisineEntity table in the database.
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

            var castObj = (SupplierCuisineEntity)obj;
            return this.SupplierCuisineId == castObj.SupplierCuisineId;
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
			hash = 27 * hash * this.SupplierCuisineId.GetHashCode();
			return hash;
		}
	}
}