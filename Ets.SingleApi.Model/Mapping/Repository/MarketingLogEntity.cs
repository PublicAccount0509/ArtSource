// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MarketingLogEntity.cs" company="Irdeto">
//   Copyright @ 2013
// </copyright>
// <summary>
//   Class:MarketingLogEntity
//   Namespace:Ets.SingleApi.Model.Repository
//   Class Funtion:Represent the class mapping the MarketingLogEntity table in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ets.SingleApi.Model.Repository
{
	using System;
		
    /// <summary>
    /// Class:MarketingLogEntity
    /// Namespace:Ets.SingleApi.Model.Repository
    /// Class Funtion:Represent the class mapping the MarketingLogEntity table in the database.
    /// </summary>
    /// Creator:周超
    /// Creation Date:2013/10/13 14:18:48
    /// Modifier:
    /// Last Modified:
    /// ----------------------------------------------------------------------------------------
    [Serializable]
    public class MarketingLogEntity
    {
		#region private member

			/// <summary>
		/// The MarketingLogID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int marketingLogId;

			/// <summary>
		/// The CustomerID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? customerId;

			/// <summary>
		/// The SupplierID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? supplierId;

			/// <summary>
		/// The AddDateTime
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private DateTime? addDateTime;

			/// <summary>
		/// The MarketingMessageID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private MarketingMessageEntity marketingMessage;

		#endregion

		/// <summary>
        /// Initializes a new instance of the <see cref="MarketingLogEntity"/> class.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public MarketingLogEntity()
        {
			this.marketingLogId = 0;
		}

		#region public member

			/// <summary>
        /// Gets or sets a value mapping the MarketingLogID of MarketingLogEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int MarketingLogId
		{
            get
            {
                return this.marketingLogId;
            }

            set
            {
                this.marketingLogId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the CustomerID of MarketingLogEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? CustomerId
		{
            get
            {
                return this.customerId;
            }

            set
            {
                this.customerId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the SupplierID of MarketingLogEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? SupplierId
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
        /// Gets or sets a value mapping the AddDateTime of MarketingLogEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual DateTime? AddDateTime
		{
            get
            {
                return this.addDateTime;
            }

            set
            {
                this.addDateTime = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the MarketingMessageID of MarketingLogEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual MarketingMessageEntity MarketingMessage
		{
            get
            {
                return this.marketingMessage;
            }

            set
            {
                this.marketingMessage = value;
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
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public override bool Equals(object obj)
        {
            if (obj == null || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }

            var castObj = (MarketingLogEntity)obj;
            return this.MarketingLogId == castObj.MarketingLogId;
        }

		/// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public override int GetHashCode()
		{
			var hash = 57; 
			hash = 27 * hash * this.MarketingLogId.GetHashCode();
			return hash;
		}
	}
}