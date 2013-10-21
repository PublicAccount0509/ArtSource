// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SupplierCouponEntity.cs" company="Irdeto">
//   Copyright @ 2013
// </copyright>
// <summary>
//   Class:SupplierCouponEntity
//   Namespace:Ets.SingleApi.Model.Repository
//   Class Funtion:Represent the class mapping the SupplierCouponEntity table in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ets.SingleApi.Model.Repository
{
	using System;
	using System.Collections.Generic;
		
    /// <summary>
    /// Class:SupplierCouponEntity
    /// Namespace:Ets.SingleApi.Model.Repository
    /// Class Funtion:Represent the class mapping the SupplierCouponEntity table in the database.
    /// </summary>
    /// Creator:周超
    /// Creation Date:2013/10/13 14:01:30
    /// Modifier:
    /// Last Modified:
    /// ----------------------------------------------------------------------------------------
    [Serializable]
    public class SupplierCouponEntity
    {
		#region private member

			/// <summary>
		/// The Id
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int id;

			/// <summary>
		/// The SupplierCouponTypeID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int supplierCouponTypeId;

			/// <summary>
		/// The OneUserMax
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? oneUserMax;

			/// <summary>
		/// The NumberMaxUse
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? numberMaxUse;

			/// <summary>
		/// The BeginDate
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private DateTime? beginDate;

			/// <summary>
		/// The EndDate
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private DateTime? endDate;

			/// <summary>
		/// The Discount
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private decimal? discount;

			/// <summary>
		/// The RateLower
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private decimal? rateLower;

			/// <summary>
		/// The RateHigh
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private decimal? rateHigh;

			/// <summary>
		/// The Description
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string description;

			/// <summary>
		/// The CreateTime
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private DateTime? createTime;

			/// <summary>
		/// The TakeoutDiscount
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private decimal? takeoutDiscount;

			/// <summary>
		/// The TakeoutCouponTypeID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? takeoutCouponTypeId;

			/// <summary>
		/// The TakeoutRateLower
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private decimal? takeoutRateLower;

			/// <summary>
		/// The TakeoutRateHigh
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private decimal? takeoutRateHigh;

			/// <summary>
		/// The TakeoutDescription
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string takeoutDescription;

			/// <summary>
		/// The SupplierCouponTimeList
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private IList<SupplierCouponTimeEntity> supplierCouponTimeList;

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
        /// Initializes a new instance of the <see cref="SupplierCouponEntity"/> class.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public SupplierCouponEntity()
        {
			this.id = 0;
			this.supplierCouponTypeId = 0;
			this.description = string.Empty;
			this.takeoutDescription = string.Empty;
		}

		#region public member

			/// <summary>
        /// Gets or sets a value mapping the Id of SupplierCouponEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int Id
		{
            get
            {
                return this.id;
            }

            set
            {
                this.id = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the SupplierCouponTypeID of SupplierCouponEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int SupplierCouponTypeId
		{
            get
            {
                return this.supplierCouponTypeId;
            }

            set
            {
                this.supplierCouponTypeId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the OneUserMax of SupplierCouponEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? OneUserMax
		{
            get
            {
                return this.oneUserMax;
            }

            set
            {
                this.oneUserMax = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the NumberMaxUse of SupplierCouponEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? NumberMaxUse
		{
            get
            {
                return this.numberMaxUse;
            }

            set
            {
                this.numberMaxUse = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the BeginDate of SupplierCouponEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual DateTime? BeginDate
		{
            get
            {
                return this.beginDate;
            }

            set
            {
                this.beginDate = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the EndDate of SupplierCouponEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual DateTime? EndDate
		{
            get
            {
                return this.endDate;
            }

            set
            {
                this.endDate = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Discount of SupplierCouponEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
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
        /// Gets or sets a value mapping the RateLower of SupplierCouponEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual decimal? RateLower
		{
            get
            {
                return this.rateLower;
            }

            set
            {
                this.rateLower = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the RateHigh of SupplierCouponEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual decimal? RateHigh
		{
            get
            {
                return this.rateHigh;
            }

            set
            {
                this.rateHigh = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Description of SupplierCouponEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string Description
		{
            get
            {
                return this.description;
            }

            set
            {
                this.description = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the CreateTime of SupplierCouponEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual DateTime? CreateTime
		{
            get
            {
                return this.createTime;
            }

            set
            {
                this.createTime = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the TakeoutDiscount of SupplierCouponEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual decimal? TakeoutDiscount
		{
            get
            {
                return this.takeoutDiscount;
            }

            set
            {
                this.takeoutDiscount = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the TakeoutCouponTypeID of SupplierCouponEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? TakeoutCouponTypeId
		{
            get
            {
                return this.takeoutCouponTypeId;
            }

            set
            {
                this.takeoutCouponTypeId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the TakeoutRateLower of SupplierCouponEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual decimal? TakeoutRateLower
		{
            get
            {
                return this.takeoutRateLower;
            }

            set
            {
                this.takeoutRateLower = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the TakeoutRateHigh of SupplierCouponEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual decimal? TakeoutRateHigh
		{
            get
            {
                return this.takeoutRateHigh;
            }

            set
            {
                this.takeoutRateHigh = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the TakeoutDescription of SupplierCouponEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string TakeoutDescription
		{
            get
            {
                return this.takeoutDescription;
            }

            set
            {
                this.takeoutDescription = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the SupplierCouponTimeList of SupplierCouponEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual IList<SupplierCouponTimeEntity> SupplierCouponTimeList
		{
            get
            {
                return this.supplierCouponTimeList;
            }

            set
            {
                this.supplierCouponTimeList = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the SupplierID of SupplierCouponEntity table in the database.
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

            var castObj = (SupplierCouponEntity)obj;
            return this.Id == castObj.Id;
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
			hash = 27 * hash * this.Id.GetHashCode();
			return hash;
		}
	}
}