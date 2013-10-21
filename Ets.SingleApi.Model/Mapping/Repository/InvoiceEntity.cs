// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InvoiceEntity.cs" company="Irdeto">
//   Copyright @ 2013
// </copyright>
// <summary>
//   Class:InvoiceEntity
//   Namespace:Ets.SingleApi.Model.Repository
//   Class Funtion:Represent the class mapping the InvoiceEntity table in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ets.SingleApi.Model.Repository
{
	using System;
	using System.Collections.Generic;
		
    /// <summary>
    /// Class:InvoiceEntity
    /// Namespace:Ets.SingleApi.Model.Repository
    /// Class Funtion:Represent the class mapping the InvoiceEntity table in the database.
    /// </summary>
    /// Creator:周超
    /// Creation Date:2013/10/13 14:01:28
    /// Modifier:
    /// Last Modified:
    /// ----------------------------------------------------------------------------------------
    [Serializable]
    public class InvoiceEntity
    {
		#region private member

			/// <summary>
		/// The InvoiceID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int invoiceId;

			/// <summary>
		/// The InvoiceDueDate
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private DateTime? invoiceDueDate;

			/// <summary>
		/// The InvoiceIssuedDates
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private DateTime? invoiceIssuedDates;

			/// <summary>
		/// The InvoiceStartDate
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private DateTime? invoiceStartDate;

			/// <summary>
		/// The InvoiceEndDate
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private DateTime? invoiceEndDate;

			/// <summary>
		/// The InvoiceStatus
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? invoiceStatus;

			/// <summary>
		/// The TransactionFeeTotal
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private decimal? transactionFeeTotal;

			/// <summary>
		/// The CardFeeTotal
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private decimal? cardFeeTotal;

			/// <summary>
		/// The CommissionFeeTotal
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private decimal? commissionFeeTotal;

			/// <summary>
		/// The TableBookingFeeTotal
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private decimal? tableBookingFeeTotal;

			/// <summary>
		/// The InvoiceNetAmount
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private decimal? invoiceNetAmount;

			/// <summary>
		/// The InvoiceVatAmount
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private decimal? invoiceVatAmount;

			/// <summary>
		/// The InvoiceTotalAmount
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private decimal? invoiceTotalAmount;

			/// <summary>
		/// The DateCreated
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private DateTime? dateCreated;

			/// <summary>
		/// The totCashOrder
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private decimal? totCashOrder;

			/// <summary>
		/// The totcardOrder
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private decimal? totcardOrder;

			/// <summary>
		/// The InvoiceNo
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string invoiceNo;

			/// <summary>
		/// The StatementList
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private IList<StatementEntity> statementList;

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
        /// Initializes a new instance of the <see cref="InvoiceEntity"/> class.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public InvoiceEntity()
        {
			this.invoiceId = 0;
			this.invoiceNo = string.Empty;
		}

		#region public member

			/// <summary>
        /// Gets or sets a value mapping the InvoiceID of InvoiceEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int InvoiceId
		{
            get
            {
                return this.invoiceId;
            }

            set
            {
                this.invoiceId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the InvoiceDueDate of InvoiceEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual DateTime? InvoiceDueDate
		{
            get
            {
                return this.invoiceDueDate;
            }

            set
            {
                this.invoiceDueDate = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the InvoiceIssuedDates of InvoiceEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual DateTime? InvoiceIssuedDates
		{
            get
            {
                return this.invoiceIssuedDates;
            }

            set
            {
                this.invoiceIssuedDates = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the InvoiceStartDate of InvoiceEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual DateTime? InvoiceStartDate
		{
            get
            {
                return this.invoiceStartDate;
            }

            set
            {
                this.invoiceStartDate = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the InvoiceEndDate of InvoiceEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual DateTime? InvoiceEndDate
		{
            get
            {
                return this.invoiceEndDate;
            }

            set
            {
                this.invoiceEndDate = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the InvoiceStatus of InvoiceEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? InvoiceStatus
		{
            get
            {
                return this.invoiceStatus;
            }

            set
            {
                this.invoiceStatus = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the TransactionFeeTotal of InvoiceEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual decimal? TransactionFeeTotal
		{
            get
            {
                return this.transactionFeeTotal;
            }

            set
            {
                this.transactionFeeTotal = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the CardFeeTotal of InvoiceEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual decimal? CardFeeTotal
		{
            get
            {
                return this.cardFeeTotal;
            }

            set
            {
                this.cardFeeTotal = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the CommissionFeeTotal of InvoiceEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual decimal? CommissionFeeTotal
		{
            get
            {
                return this.commissionFeeTotal;
            }

            set
            {
                this.commissionFeeTotal = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the TableBookingFeeTotal of InvoiceEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual decimal? TableBookingFeeTotal
		{
            get
            {
                return this.tableBookingFeeTotal;
            }

            set
            {
                this.tableBookingFeeTotal = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the InvoiceNetAmount of InvoiceEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual decimal? InvoiceNetAmount
		{
            get
            {
                return this.invoiceNetAmount;
            }

            set
            {
                this.invoiceNetAmount = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the InvoiceVatAmount of InvoiceEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual decimal? InvoiceVatAmount
		{
            get
            {
                return this.invoiceVatAmount;
            }

            set
            {
                this.invoiceVatAmount = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the InvoiceTotalAmount of InvoiceEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual decimal? InvoiceTotalAmount
		{
            get
            {
                return this.invoiceTotalAmount;
            }

            set
            {
                this.invoiceTotalAmount = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the DateCreated of InvoiceEntity table in the database.
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
        /// Gets or sets a value mapping the totCashOrder of InvoiceEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual decimal? TotCashOrder
		{
            get
            {
                return this.totCashOrder;
            }

            set
            {
                this.totCashOrder = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the totcardOrder of InvoiceEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual decimal? TotcardOrder
		{
            get
            {
                return this.totcardOrder;
            }

            set
            {
                this.totcardOrder = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the InvoiceNo of InvoiceEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string InvoiceNo
		{
            get
            {
                return this.invoiceNo;
            }

            set
            {
                this.invoiceNo = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the StatementList of InvoiceEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual IList<StatementEntity> StatementList
		{
            get
            {
                return this.statementList;
            }

            set
            {
                this.statementList = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the SupplierID of InvoiceEntity table in the database.
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

            var castObj = (InvoiceEntity)obj;
            return this.InvoiceId == castObj.InvoiceId;
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
			hash = 27 * hash * this.InvoiceId.GetHashCode();
			return hash;
		}
	}
}