// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PaymentEntity.cs" company="Irdeto">
//   Copyright @ 2013
// </copyright>
// <summary>
//   Class:PaymentEntity
//   Namespace:Ets.SingleApi.Model.Repository
//   Class Funtion:Represent the class mapping the PaymentEntity table in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ets.SingleApi.Model.Repository
{
	using System;
		
    /// <summary>
    /// Class:PaymentEntity
    /// Namespace:Ets.SingleApi.Model.Repository
    /// Class Funtion:Represent the class mapping the PaymentEntity table in the database.
    /// </summary>
    /// Creator:周超
    /// Creation Date:2013/10/13 14:32:24
    /// Modifier:
    /// Last Modified:
    /// ----------------------------------------------------------------------------------------
    [Serializable]
    public class PaymentEntity
    {
		#region private member

			/// <summary>
		/// The PaymentID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:32:24
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int paymentId;

			/// <summary>
		/// The PaymentTypeID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:32:24
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int paymentTypeId;

			/// <summary>
		/// The Amount
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:32:24
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private decimal amount;

			/// <summary>
		/// The PaymentDate
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:32:24
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private DateTime paymentDate;

			/// <summary>
		/// The TransactionCode
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:32:24
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string transactionCode;

			/// <summary>
		/// The CardID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:32:24
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string cardId;

			/// <summary>
		/// The PaymentMethodID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:32:24
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int paymentMethodId;

			/// <summary>
		/// The Authorized
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:32:24
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private bool? authorized;

			/// <summary>
		/// The CVV
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:32:24
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? cVV;

			/// <summary>
		/// The AVS
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:32:24
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string aVS;

			/// <summary>
		/// The PC
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:32:24
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? pC;

			/// <summary>
		/// The AuthCode
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:32:24
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string authCode;

			/// <summary>
		/// The VoicePayResponse
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:32:24
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string voicePayResponse;

			/// <summary>
		/// The TransactionFee
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:32:24
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private decimal? transactionFee;

			/// <summary>
		/// The MethodChangeHistory
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:32:24
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string methodChangeHistory;

			/// <summary>
		/// The payBank
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:32:24
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string payBank;

			/// <summary>
		/// The DeliveryID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:32:24
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private DeliveryEntity delivery;

		#endregion

		/// <summary>
        /// Initializes a new instance of the <see cref="PaymentEntity"/> class.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:32:24
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public PaymentEntity()
        {
			this.paymentId = 0;
			this.paymentTypeId = 0;
			this.amount = 0;
			this.paymentDate = DateTime.Now;
			this.transactionCode = string.Empty;
			this.cardId = string.Empty;
			this.paymentMethodId = 0;
			this.aVS = string.Empty;
			this.authCode = string.Empty;
			this.voicePayResponse = string.Empty;
			this.methodChangeHistory = string.Empty;
			this.payBank = string.Empty;
		}

		#region public member

			/// <summary>
        /// Gets or sets a value mapping the PaymentID of PaymentEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:32:24
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int PaymentId
		{
            get
            {
                return this.paymentId;
            }

            set
            {
                this.paymentId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the PaymentTypeID of PaymentEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:32:24
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int PaymentTypeId
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
        /// Gets or sets a value mapping the Amount of PaymentEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:32:24
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual decimal Amount
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
        /// Gets or sets a value mapping the PaymentDate of PaymentEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:32:24
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual DateTime PaymentDate
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
        /// Gets or sets a value mapping the TransactionCode of PaymentEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:32:24
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string TransactionCode
		{
            get
            {
                return this.transactionCode;
            }

            set
            {
                this.transactionCode = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the CardID of PaymentEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:32:24
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string CardId
		{
            get
            {
                return this.cardId;
            }

            set
            {
                this.cardId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the PaymentMethodID of PaymentEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:32:24
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int PaymentMethodId
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
        /// Gets or sets a value indicating whether mapping the Authorized of PaymentEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:32:24
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual bool? Authorized
		{
            get
            {
                return this.authorized;
            }

            set
            {
                this.authorized = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the CVV of PaymentEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:32:24
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? CVV
		{
            get
            {
                return this.cVV;
            }

            set
            {
                this.cVV = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the AVS of PaymentEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:32:24
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string AVS
		{
            get
            {
                return this.aVS;
            }

            set
            {
                this.aVS = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the PC of PaymentEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:32:24
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? PC
		{
            get
            {
                return this.pC;
            }

            set
            {
                this.pC = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the AuthCode of PaymentEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:32:24
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string AuthCode
		{
            get
            {
                return this.authCode;
            }

            set
            {
                this.authCode = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the VoicePayResponse of PaymentEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:32:24
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string VoicePayResponse
		{
            get
            {
                return this.voicePayResponse;
            }

            set
            {
                this.voicePayResponse = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the TransactionFee of PaymentEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:32:24
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual decimal? TransactionFee
		{
            get
            {
                return this.transactionFee;
            }

            set
            {
                this.transactionFee = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the MethodChangeHistory of PaymentEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:32:24
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string MethodChangeHistory
		{
            get
            {
                return this.methodChangeHistory;
            }

            set
            {
                this.methodChangeHistory = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the payBank of PaymentEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:32:24
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
        /// Gets or sets a value mapping the DeliveryID of PaymentEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:32:24
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual DeliveryEntity Delivery
		{
            get
            {
                return this.delivery;
            }

            set
            {
                this.delivery = value;
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
        /// Creation Date:2013/10/13 14:32:24
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public override bool Equals(object obj)
        {
            if (obj == null || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }

            var castObj = (PaymentEntity)obj;
            return this.PaymentId == castObj.PaymentId;
        }

		/// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:32:24
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public override int GetHashCode()
		{
			var hash = 57; 
			hash = 27 * hash * this.PaymentId.GetHashCode();
			return hash;
		}
	}
}