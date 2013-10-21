// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MarketingAllowanceEntity.cs" company="Irdeto">
//   Copyright @ 2013
// </copyright>
// <summary>
//   Class:MarketingAllowanceEntity
//   Namespace:Ets.SingleApi.Model.Repository
//   Class Funtion:Represent the class mapping the MarketingAllowanceEntity table in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ets.SingleApi.Model.Repository
{
	using System;
		
    /// <summary>
    /// Class:MarketingAllowanceEntity
    /// Namespace:Ets.SingleApi.Model.Repository
    /// Class Funtion:Represent the class mapping the MarketingAllowanceEntity table in the database.
    /// </summary>
    /// Creator:周超
    /// Creation Date:2013/10/13 14:01:29
    /// Modifier:
    /// Last Modified:
    /// ----------------------------------------------------------------------------------------
    [Serializable]
    public class MarketingAllowanceEntity
    {
		#region private member

			/// <summary>
		/// The MarketingAllowanceID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int marketingAllowanceId;

			/// <summary>
		/// The MarketingAllowed
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private bool marketingAllowed;

			/// <summary>
		/// The CustomerID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private CustomerEntity customer;

			/// <summary>
		/// The SupplierID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private SupplierEntity supplier;

		#endregion

		/// <summary>
        /// Initializes a new instance of the <see cref="MarketingAllowanceEntity"/> class.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public MarketingAllowanceEntity()
        {
			this.marketingAllowanceId = 0;
			this.marketingAllowed = false;
		}

		#region public member

			/// <summary>
        /// Gets or sets a value mapping the MarketingAllowanceID of MarketingAllowanceEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int MarketingAllowanceId
		{
            get
            {
                return this.marketingAllowanceId;
            }

            set
            {
                this.marketingAllowanceId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value indicating whether mapping the MarketingAllowed of MarketingAllowanceEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual bool MarketingAllowed
		{
            get
            {
                return this.marketingAllowed;
            }

            set
            {
                this.marketingAllowed = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the CustomerID of MarketingAllowanceEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
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
        /// Gets or sets a value mapping the SupplierID of MarketingAllowanceEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
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
        /// Creation Date:2013/10/13 14:01:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public override bool Equals(object obj)
        {
            if (obj == null || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }

            var castObj = (MarketingAllowanceEntity)obj;
            return this.MarketingAllowanceId == castObj.MarketingAllowanceId;
        }

		/// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public override int GetHashCode()
		{
			var hash = 57; 
			hash = 27 * hash * this.MarketingAllowanceId.GetHashCode();
			return hash;
		}
	}
}