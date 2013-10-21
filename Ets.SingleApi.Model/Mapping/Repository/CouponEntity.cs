// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CouponEntity.cs" company="Irdeto">
//   Copyright @ 2013
// </copyright>
// <summary>
//   Class:CouponEntity
//   Namespace:Ets.SingleApi.Model.Repository
//   Class Funtion:Represent the class mapping the CouponEntity table in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ets.SingleApi.Model.Repository
{
	using System;
		
    /// <summary>
    /// Class:CouponEntity
    /// Namespace:Ets.SingleApi.Model.Repository
    /// Class Funtion:Represent the class mapping the CouponEntity table in the database.
    /// </summary>
    /// Creator:周超
    /// Creation Date:2013/10/13 14:01:28
    /// Modifier:
    /// Last Modified:
    /// ----------------------------------------------------------------------------------------
    [Serializable]
    public class CouponEntity
    {
		#region private member

			/// <summary>
		/// The CouponID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int couponId;

			/// <summary>
		/// The CouponCode
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string couponCode;

			/// <summary>
		/// The CouponTypeId
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int couponTypeId;

			/// <summary>
		/// The IsSingleUse
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private bool isSingleUse;

			/// <summary>
		/// The NumberUses
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int numberUses;

			/// <summary>
		/// The ExpirationDate
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private DateTime? expirationDate;

			/// <summary>
		/// The Discount
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private decimal? discount;

			/// <summary>
		/// The IsBulk
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private bool? isBulk;

			/// <summary>
		/// The StartDate
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private DateTime? startDate;

			/// <summary>
		/// The UsePermissions
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string usePermissions;

			/// <summary>
		/// The UseRules
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int useRules;

			/// <summary>
		/// The Note
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string note;

			/// <summary>
		/// The SupplierID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private SupplierEntity supplier;

		#endregion

		/// <summary>
        /// Initializes a new instance of the <see cref="CouponEntity"/> class.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public CouponEntity()
        {
			this.couponId = 0;
			this.couponCode = string.Empty;
			this.couponTypeId = 0;
			this.isSingleUse = false;
			this.numberUses = 0;
			this.usePermissions = "0";
			this.useRules = 2;
			this.note = string.Empty;
		}

		#region public member

			/// <summary>
        /// Gets or sets a value mapping the CouponID of CouponEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int CouponId
		{
            get
            {
                return this.couponId;
            }

            set
            {
                this.couponId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the CouponCode of CouponEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string CouponCode
		{
            get
            {
                return this.couponCode;
            }

            set
            {
                this.couponCode = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the CouponTypeId of CouponEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int CouponTypeId
		{
            get
            {
                return this.couponTypeId;
            }

            set
            {
                this.couponTypeId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value indicating whether mapping the IsSingleUse of CouponEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual bool IsSingleUse
		{
            get
            {
                return this.isSingleUse;
            }

            set
            {
                this.isSingleUse = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the NumberUses of CouponEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int NumberUses
		{
            get
            {
                return this.numberUses;
            }

            set
            {
                this.numberUses = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the ExpirationDate of CouponEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual DateTime? ExpirationDate
		{
            get
            {
                return this.expirationDate;
            }

            set
            {
                this.expirationDate = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Discount of CouponEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual decimal? Discount
		{
            get
            {
                return this.discount;
            }

            set
            {
                this.discount = value;
            }
        }

			/// <summary>
        /// Gets or sets a value indicating whether mapping the IsBulk of CouponEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual bool? IsBulk
		{
            get
            {
                return this.isBulk;
            }

            set
            {
                this.isBulk = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the StartDate of CouponEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual DateTime? StartDate
		{
            get
            {
                return this.startDate;
            }

            set
            {
                this.startDate = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the UsePermissions of CouponEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string UsePermissions
		{
            get
            {
                return this.usePermissions;
            }

            set
            {
                this.usePermissions = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the UseRules of CouponEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int UseRules
		{
            get
            {
                return this.useRules;
            }

            set
            {
                this.useRules = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Note of CouponEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string Note
		{
            get
            {
                return this.note;
            }

            set
            {
                this.note = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the SupplierID of CouponEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
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
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public override bool Equals(object obj)
        {
            if (obj == null || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }

            var castObj = (CouponEntity)obj;
            return this.CouponId == castObj.CouponId;
        }

		/// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public override int GetHashCode()
		{
			var hash = 57; 
			hash = 27 * hash * this.CouponId.GetHashCode();
			return hash;
		}
	}
}