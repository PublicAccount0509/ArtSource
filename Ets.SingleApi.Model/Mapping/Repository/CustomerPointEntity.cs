// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CustomerPointEntity.cs" company="Irdeto">
//   Copyright @ 2013
// </copyright>
// <summary>
//   Class:CustomerPointEntity
//   Namespace:Ets.SingleApi.Model.Repository
//   Class Funtion:Represent the class mapping the CustomerPointEntity table in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ets.SingleApi.Model.Repository
{
	using System;
		
    /// <summary>
    /// Class:CustomerPointEntity
    /// Namespace:Ets.SingleApi.Model.Repository
    /// Class Funtion:Represent the class mapping the CustomerPointEntity table in the database.
    /// </summary>
    /// Creator:周超
    /// Creation Date:2013/10/13 14:01:28
    /// Modifier:
    /// Last Modified:
    /// ----------------------------------------------------------------------------------------
    [Serializable]
    public class CustomerPointEntity
    {
		#region private member

			/// <summary>
		/// The PointId
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int pointId;

			/// <summary>
		/// The Point
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private decimal? point;

			/// <summary>
		/// The PointDatetime
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private DateTime? pointDatetime;

			/// <summary>
		/// The CustomerId
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private CustomerEntity customer;

			/// <summary>
		/// The SupplierId
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private SupplierEntity supplier;

		#endregion

		/// <summary>
        /// Initializes a new instance of the <see cref="CustomerPointEntity"/> class.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public CustomerPointEntity()
        {
			this.pointId = 0;
		}

		#region public member

			/// <summary>
        /// Gets or sets a value mapping the PointId of CustomerPointEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int PointId
		{
            get
            {
                return this.pointId;
            }

            set
            {
                this.pointId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Point of CustomerPointEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual decimal? Point
		{
            get
            {
                return this.point;
            }

            set
            {
                this.point = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the PointDatetime of CustomerPointEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual DateTime? PointDatetime
		{
            get
            {
                return this.pointDatetime;
            }

            set
            {
                this.pointDatetime = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the CustomerId of CustomerPointEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual CustomerEntity Customer
		{
            get
            {
                return this.customer;
            }

            set
            {
                this.customer = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the SupplierId of CustomerPointEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
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
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public override bool Equals(object obj)
        {
            if (obj == null || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }

            var castObj = (CustomerPointEntity)obj;
            return this.PointId == castObj.PointId;
        }

		/// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public override int GetHashCode()
		{
			var hash = 57; 
			hash = 27 * hash * this.PointId.GetHashCode();
			return hash;
		}
	}
}