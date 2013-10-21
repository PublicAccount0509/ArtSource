// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StatementEntity.cs" company="Irdeto">
//   Copyright @ 2013
// </copyright>
// <summary>
//   Class:StatementEntity
//   Namespace:Ets.SingleApi.Model.Repository
//   Class Funtion:Represent the class mapping the StatementEntity table in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ets.SingleApi.Model.Repository
{
	using System;
		
    /// <summary>
    /// Class:StatementEntity
    /// Namespace:Ets.SingleApi.Model.Repository
    /// Class Funtion:Represent the class mapping the StatementEntity table in the database.
    /// </summary>
    /// Creator:周超
    /// Creation Date:2013/10/13 14:01:29
    /// Modifier:
    /// Last Modified:
    /// ----------------------------------------------------------------------------------------
    [Serializable]
    public class StatementEntity
    {
		#region private member

			/// <summary>
		/// The StatementID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int statementId;

			/// <summary>
		/// The StatementIssuedDate
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private DateTime? statementIssuedDate;

			/// <summary>
		/// The StatementStartDate
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private DateTime? statementStartDate;

			/// <summary>
		/// The StatementEndDate
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private DateTime? statementEndDate;

			/// <summary>
		/// The AllOrdersTotalAmount
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private decimal? allOrdersTotalAmount;

			/// <summary>
		/// The CardOrdersNetAmount
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private decimal? cardOrdersNetAmount;

			/// <summary>
		/// The CardOrdersVatAmount
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private decimal? cardOrdersVatAmount;

			/// <summary>
		/// The CardOrdersTotalAmount
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private decimal? cardOrdersTotalAmount;

			/// <summary>
		/// The Balance
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private decimal? balance;

			/// <summary>
		/// The DateCreated
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private DateTime? dateCreated;

			/// <summary>
		/// The InvoiceID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private InvoiceEntity invoice;

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
        /// Initializes a new instance of the <see cref="StatementEntity"/> class.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public StatementEntity()
        {
			this.statementId = 0;
		}

		#region public member

			/// <summary>
        /// Gets or sets a value mapping the StatementID of StatementEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int StatementId
		{
            get
            {
                return this.statementId;
            }

            set
            {
                this.statementId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the StatementIssuedDate of StatementEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual DateTime? StatementIssuedDate
		{
            get
            {
                return this.statementIssuedDate;
            }

            set
            {
                this.statementIssuedDate = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the StatementStartDate of StatementEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual DateTime? StatementStartDate
		{
            get
            {
                return this.statementStartDate;
            }

            set
            {
                this.statementStartDate = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the StatementEndDate of StatementEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual DateTime? StatementEndDate
		{
            get
            {
                return this.statementEndDate;
            }

            set
            {
                this.statementEndDate = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the AllOrdersTotalAmount of StatementEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual decimal? AllOrdersTotalAmount
		{
            get
            {
                return this.allOrdersTotalAmount;
            }

            set
            {
                this.allOrdersTotalAmount = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the CardOrdersNetAmount of StatementEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual decimal? CardOrdersNetAmount
		{
            get
            {
                return this.cardOrdersNetAmount;
            }

            set
            {
                this.cardOrdersNetAmount = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the CardOrdersVatAmount of StatementEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual decimal? CardOrdersVatAmount
		{
            get
            {
                return this.cardOrdersVatAmount;
            }

            set
            {
                this.cardOrdersVatAmount = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the CardOrdersTotalAmount of StatementEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual decimal? CardOrdersTotalAmount
		{
            get
            {
                return this.cardOrdersTotalAmount;
            }

            set
            {
                this.cardOrdersTotalAmount = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Balance of StatementEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual decimal? Balance
		{
            get
            {
                return this.balance;
            }

            set
            {
                this.balance = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the DateCreated of StatementEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual DateTime? DateCreated
		{
            get
            {
                return this.dateCreated;
            }

            set
            {
                this.dateCreated = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the InvoiceID of StatementEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual InvoiceEntity Invoice
		{
            get
            {
                return this.invoice;
            }

            set
            {
                this.invoice = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the SupplierID of StatementEntity table in the database.
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

            var castObj = (StatementEntity)obj;
            return this.StatementId == castObj.StatementId;
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
			hash = 27 * hash * this.StatementId.GetHashCode();
			return hash;
		}
	}
}