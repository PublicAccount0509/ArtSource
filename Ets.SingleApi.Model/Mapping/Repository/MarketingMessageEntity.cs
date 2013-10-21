// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MarketingMessageEntity.cs" company="Irdeto">
//   Copyright @ 2013
// </copyright>
// <summary>
//   Class:MarketingMessageEntity
//   Namespace:Ets.SingleApi.Model.Repository
//   Class Funtion:Represent the class mapping the MarketingMessageEntity table in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ets.SingleApi.Model.Repository
{
	using System;
	using System.Collections.Generic;
		
    /// <summary>
    /// Class:MarketingMessageEntity
    /// Namespace:Ets.SingleApi.Model.Repository
    /// Class Funtion:Represent the class mapping the MarketingMessageEntity table in the database.
    /// </summary>
    /// Creator:周超
    /// Creation Date:2013/10/13 14:01:29
    /// Modifier:
    /// Last Modified:
    /// ----------------------------------------------------------------------------------------
    [Serializable]
    public class MarketingMessageEntity
    {
		#region private member

			/// <summary>
		/// The MarketingMessageID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int marketingMessageId;

			/// <summary>
		/// The Title
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string title;

			/// <summary>
		/// The Content
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string content;

			/// <summary>
		/// The AddDateTime
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private DateTime? addDateTime;

			/// <summary>
		/// The MarketingLogList
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private IList<MarketingLogEntity> marketingLogList;

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
        /// Initializes a new instance of the <see cref="MarketingMessageEntity"/> class.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public MarketingMessageEntity()
        {
			this.marketingMessageId = 0;
			this.title = string.Empty;
			this.content = string.Empty;
		}

		#region public member

			/// <summary>
        /// Gets or sets a value mapping the MarketingMessageID of MarketingMessageEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int MarketingMessageId
		{
            get
            {
                return this.marketingMessageId;
            }

            set
            {
                this.marketingMessageId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Title of MarketingMessageEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string Title
		{
            get
            {
                return this.title;
            }

            set
            {
                this.title = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Content of MarketingMessageEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string Content
		{
            get
            {
                return this.content;
            }

            set
            {
                this.content = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the AddDateTime of MarketingMessageEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
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
        /// Gets or sets a value mapping the MarketingLogList of MarketingMessageEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual IList<MarketingLogEntity> MarketingLogList
		{
            get
            {
                return this.marketingLogList;
            }

            set
            {
                this.marketingLogList = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the SupplierID of MarketingMessageEntity table in the database.
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

            var castObj = (MarketingMessageEntity)obj;
            return this.MarketingMessageId == castObj.MarketingMessageId;
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
			hash = 27 * hash * this.MarketingMessageId.GetHashCode();
			return hash;
		}
	}
}