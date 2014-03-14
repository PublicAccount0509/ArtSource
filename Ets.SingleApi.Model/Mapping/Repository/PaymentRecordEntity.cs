// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PaymentRecordEntity.cs" company="Irdeto">
//   Copyright @ 2014
// </copyright>
// <summary>
//   Class:PaymentRecordEntity
//   Namespace:Ets.SingleApi.Model.Repository
//   Class Funtion:Represent the class mapping the PaymentRecordEntity table in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ets.SingleApi.Model.Repository
{
	using System;
		
    /// <summary>
    /// Class:PaymentRecordEntity
    /// Namespace:Ets.SingleApi.Model.Repository
    /// Class Funtion:Represent the class mapping the PaymentRecordEntity table in the database.
    /// </summary>
    /// Creator:周超
    /// Creation Date:2014/3/13 19:30:08
    /// Modifier:
    /// Last Modified:
    /// ----------------------------------------------------------------------------------------
    [Serializable]
    public class PaymentRecordEntity
    {
		#region private member

			/// <summary>
		/// The PaymentRecordId
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/3/13 19:30:08
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int paymentRecordId;

			/// <summary>
		/// The PaymentTypeId
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/3/13 19:30:08
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? paymentTypeId;

			/// <summary>
		/// The OrderId
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/3/13 19:30:08
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string orderId;

			/// <summary>
		/// The Amount
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/3/13 19:30:08
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private decimal? amount;

			/// <summary>
		/// The PaymentDate
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/3/13 19:30:08
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private DateTime? paymentDate;

			/// <summary>
		/// The PaymentMethodId
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/3/13 19:30:08
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? paymentMethodId;

			/// <summary>
		/// The PayBank
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/3/13 19:30:08
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string payBank;

			/// <summary>
		/// The OrderTypeId
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/3/13 19:30:08
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? orderTypeId;

		#endregion

		/// <summary>
        /// Initializes a new instance of the <see cref="PaymentRecordEntity"/> class.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/3/13 19:30:08
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public PaymentRecordEntity()
        {
			this.paymentRecordId = 0;
			this.orderId = string.Empty;
			this.payBank = string.Empty;
		}

		#region public member

			/// <summary>
        /// Gets or sets a value mapping the PaymentRecordId of PaymentRecordEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/3/13 19:30:08
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int PaymentRecordId
		{
            get
            {
                return this.paymentRecordId;
            }

            set
            {
                this.paymentRecordId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the PaymentTypeId of PaymentRecordEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/3/13 19:30:08
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? PaymentTypeId
		{
            get
            {
                return this.paymentTypeId;
            }

            set
            {
                this.paymentTypeId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the OrderId of PaymentRecordEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/3/13 19:30:08
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string OrderId
		{
            get
            {
                return this.orderId;
            }

            set
            {
                this.orderId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Amount of PaymentRecordEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/3/13 19:30:08
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual decimal? Amount
		{
            get
            {
                return this.amount;
            }

            set
            {
                this.amount = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the PaymentDate of PaymentRecordEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/3/13 19:30:08
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual DateTime? PaymentDate
		{
            get
            {
                return this.paymentDate;
            }

            set
            {
                this.paymentDate = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the PaymentMethodId of PaymentRecordEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/3/13 19:30:08
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? PaymentMethodId
		{
            get
            {
                return this.paymentMethodId;
            }

            set
            {
                this.paymentMethodId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the PayBank of PaymentRecordEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/3/13 19:30:08
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string PayBank
		{
            get
            {
                return this.payBank;
            }

            set
            {
                this.payBank = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the OrderTypeId of PaymentRecordEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/3/13 19:30:08
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? OrderTypeId
		{
            get
            {
                return this.orderTypeId;
            }

            set
            {
                this.orderTypeId = value;
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
        /// Creation Date:2014/3/13 19:30:08
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public override bool Equals(object obj)
        {
            if (obj == null || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }

            var castObj = (PaymentRecordEntity)obj;
            return this.PaymentRecordId == castObj.PaymentRecordId;
        }

		/// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        /// Creator:周超
        /// Creation Date:2014/3/13 19:30:08
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public override int GetHashCode()
		{
			var hash = 57; 
			hash = 27 * hash * this.PaymentRecordId.GetHashCode();
			return hash;
		}
	}
}