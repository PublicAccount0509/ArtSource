// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SupplierTransportEntity.cs" company="Irdeto">
//   Copyright @ 2013
// </copyright>
// <summary>
//   Class:SupplierTransportEntity
//   Namespace:Ets.SingleApi.Model.Repository
//   Class Funtion:Represent the class mapping the SupplierTransportEntity table in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ets.SingleApi.Model.Repository
{
	using System;
		
    /// <summary>
    /// Class:SupplierTransportEntity
    /// Namespace:Ets.SingleApi.Model.Repository
    /// Class Funtion:Represent the class mapping the SupplierTransportEntity table in the database.
    /// </summary>
    /// Creator:周超
    /// Creation Date:2013/10/13 14:01:30
    /// Modifier:
    /// Last Modified:
    /// ----------------------------------------------------------------------------------------
    [Serializable]
    public class SupplierTransportEntity
    {
		#region private member

			/// <summary>
		/// The SupplierID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int supplierId;

			/// <summary>
		/// The PublicTransportID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int publicTransportId;

			/// <summary>
		/// The PublicTransportID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private PublicTransportEntity publicTransport;

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
        /// Initializes a new instance of the <see cref="SupplierTransportEntity"/> class.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public SupplierTransportEntity()
        {
			this.supplierId = 0;
			this.publicTransportId = 0;
		}

		#region public member

			/// <summary>
        /// Gets or sets a value mapping the SupplierID of SupplierTransportEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
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
        /// Gets or sets a value mapping the PublicTransportID of SupplierTransportEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int PublicTransportId
		{
            get
            {
                return this.publicTransportId;
            }

            set
            {
                this.publicTransportId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the PublicTransportID of SupplierTransportEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual PublicTransportEntity PublicTransport
		{
            get
            {
                return this.publicTransport;
            }

            set
            {
                this.publicTransport = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the SupplierID of SupplierTransportEntity table in the database.
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

            var castObj = (SupplierTransportEntity)obj;
            return this.SupplierId == castObj.SupplierId && this.PublicTransportId == castObj.PublicTransportId;
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
			hash = 27 * hash * this.SupplierId.GetHashCode();
			hash = 27 * hash * this.PublicTransportId.GetHashCode();
			return hash;
		}
	}
}