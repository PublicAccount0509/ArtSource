// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CardEntity.cs" company="Irdeto">
//   Copyright @ 2013
// </copyright>
// <summary>
//   Class:CardEntity
//   Namespace:Ets.SingleApi.Model.Repository
//   Class Funtion:Represent the class mapping the CardEntity table in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ets.SingleApi.Model.Repository
{
	using System;
		
    /// <summary>
    /// Class:CardEntity
    /// Namespace:Ets.SingleApi.Model.Repository
    /// Class Funtion:Represent the class mapping the CardEntity table in the database.
    /// </summary>
    /// Creator:周超
    /// Creation Date:2013/10/13 14:23:32
    /// Modifier:
    /// Last Modified:
    /// ----------------------------------------------------------------------------------------
    [Serializable]
    public class CardEntity
    {
		#region private member

			/// <summary>
		/// The CardID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:23:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int cardId;

			/// <summary>
		/// The CardTypeID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:23:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? cardTypeId;

			/// <summary>
		/// The CardNo
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:23:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string cardNo;

			/// <summary>
		/// The CardHolderName
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:23:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string cardHolderName;

			/// <summary>
		/// The CardValidFromDate
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:23:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private DateTime? cardValIdFromDate;

			/// <summary>
		/// The CardExpiryDate
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:23:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private DateTime cardExpiryDate;

			/// <summary>
		/// The IssueNo
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:23:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? issueNo;

			/// <summary>
		/// The CardSecurityCode
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:23:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int cardSecurityCode;

			/// <summary>
		/// The IsDefault
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:23:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private bool? isDefault;

			/// <summary>
		/// The CustomerID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:23:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private CustomerEntity customer;

		#endregion

		/// <summary>
        /// Initializes a new instance of the <see cref="CardEntity"/> class.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:23:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public CardEntity()
        {
			this.cardId = 0;
			this.cardNo = string.Empty;
			this.cardHolderName = string.Empty;
			this.cardExpiryDate = DateTime.Now;
			this.cardSecurityCode = 0;
		}

		#region public member

			/// <summary>
        /// Gets or sets a value mapping the CardID of CardEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:23:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int CardId
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
        /// Gets or sets a value mapping the CardTypeID of CardEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:23:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? CardTypeId
		{
            get
            {
                return this.cardTypeId;
            }

            set
            {
                this.cardTypeId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the CardNo of CardEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:23:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string CardNo
		{
            get
            {
                return this.cardNo;
            }

            set
            {
                this.cardNo = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the CardHolderName of CardEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:23:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string CardHolderName
		{
            get
            {
                return this.cardHolderName;
            }

            set
            {
                this.cardHolderName = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the CardValidFromDate of CardEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:23:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual DateTime? CardValIdFromDate
		{
            get
            {
                return this.cardValIdFromDate;
            }

            set
            {
                this.cardValIdFromDate = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the CardExpiryDate of CardEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:23:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual DateTime CardExpiryDate
		{
            get
            {
                return this.cardExpiryDate;
            }

            set
            {
                this.cardExpiryDate = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the IssueNo of CardEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:23:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? IssueNo
		{
            get
            {
                return this.issueNo;
            }

            set
            {
                this.issueNo = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the CardSecurityCode of CardEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:23:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int CardSecurityCode
		{
            get
            {
                return this.cardSecurityCode;
            }

            set
            {
                this.cardSecurityCode = value;
            }
        }

			/// <summary>
        /// Gets or sets a value indicating whether mapping the IsDefault of CardEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:23:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual bool? IsDefault
		{
            get
            {
                return this.isDefault;
            }

            set
            {
                this.isDefault = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the CustomerID of CardEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:23:32
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

		#endregion

			/// <summary>
        /// Determines whether the specified is equal to this instance.
        /// </summary>
        /// <param name="obj">The to compare with this instance.</param>
        /// <returns>
        /// true if the specified is equal to this instance; otherwise,false.
        /// </returns>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:23:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public override bool Equals(object obj)
        {
            if (obj == null || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }

            var castObj = (CardEntity)obj;
            return this.CardId == castObj.CardId;
        }

		/// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:23:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public override int GetHashCode()
		{
			var hash = 57; 
			hash = 27 * hash * this.CardId.GetHashCode();
			return hash;
		}
	}
}