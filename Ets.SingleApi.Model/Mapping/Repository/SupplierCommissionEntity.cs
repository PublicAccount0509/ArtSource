// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SupplierCommissionEntity.cs" company="Irdeto">
//   Copyright @ 2013
// </copyright>
// <summary>
//   Class:SupplierCommissionEntity
//   Namespace:Ets.SingleApi.Model.Repository
//   Class Funtion:Represent the class mapping the SupplierCommissionEntity table in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ets.SingleApi.Model.Repository
{
	using System;
		
    /// <summary>
    /// Class:SupplierCommissionEntity
    /// Namespace:Ets.SingleApi.Model.Repository
    /// Class Funtion:Represent the class mapping the SupplierCommissionEntity table in the database.
    /// </summary>
    /// Creator:周超
    /// Creation Date:2013/10/13 14:01:30
    /// Modifier:
    /// Last Modified:
    /// ----------------------------------------------------------------------------------------
    [Serializable]
    public class SupplierCommissionEntity
    {
		#region private member

			/// <summary>
		/// The SupplierCommissionID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int supplierCommissionId;

			/// <summary>
		/// The DeliveryID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int deliveryId;

			/// <summary>
		/// The Total
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private decimal total;

			/// <summary>
		/// The Commission
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private decimal commission;

			/// <summary>
		/// The IsPaid
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private bool isPaId;

			/// <summary>
		/// The Canncelled
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private bool? canncelled;

			/// <summary>
		/// The DateAdded
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private DateTime? dateAdded;

			/// <summary>
		/// The DatePaid
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private DateTime? datePaId;

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
        /// Initializes a new instance of the <see cref="SupplierCommissionEntity"/> class.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public SupplierCommissionEntity()
        {
			this.supplierCommissionId = 0;
			this.deliveryId = 0;
			this.total = 0;
			this.commission = 0;
			this.isPaId = false;
		}

		#region public member

			/// <summary>
        /// Gets or sets a value mapping the SupplierCommissionID of SupplierCommissionEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int SupplierCommissionId
		{
            get
            {
                return this.supplierCommissionId;
            }

            set
            {
                this.supplierCommissionId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the DeliveryID of SupplierCommissionEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int DeliveryId
		{
            get
            {
                return this.deliveryId;
            }

            set
            {
                this.deliveryId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Total of SupplierCommissionEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual decimal Total
		{
            get
            {
                return this.total;
            }

            set
            {
                this.total = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Commission of SupplierCommissionEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual decimal Commission
		{
            get
            {
                return this.commission;
            }

            set
            {
                this.commission = value;
            }
        }

			/// <summary>
        /// Gets or sets a value indicating whether mapping the IsPaid of SupplierCommissionEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual bool IsPaId
		{
            get
            {
                return this.isPaId;
            }

            set
            {
                this.isPaId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value indicating whether mapping the Canncelled of SupplierCommissionEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual bool? Canncelled
		{
            get
            {
                return this.canncelled;
            }

            set
            {
                this.canncelled = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the DateAdded of SupplierCommissionEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual DateTime? DateAdded
		{
            get
            {
                return this.dateAdded;
            }

            set
            {
                this.dateAdded = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the DatePaid of SupplierCommissionEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual DateTime? DatePaId
		{
            get
            {
                return this.datePaId;
            }

            set
            {
                this.datePaId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the SupplierID of SupplierCommissionEntity table in the database.
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

            var castObj = (SupplierCommissionEntity)obj;
            return this.SupplierCommissionId == castObj.SupplierCommissionId;
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
			hash = 27 * hash * this.SupplierCommissionId.GetHashCode();
			return hash;
		}
	}
}