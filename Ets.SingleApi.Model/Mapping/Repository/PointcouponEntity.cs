// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PointcouponEntity.cs" company="Irdeto">
//   Copyright @ 2013
// </copyright>
// <summary>
//   Class:PointcouponEntity
//   Namespace:Ets.SingleApi.Model.Repository
//   Class Funtion:Represent the class mapping the PointcouponEntity table in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ets.SingleApi.Model.Repository
{
	using System;
	using System.Collections.Generic;
		
    /// <summary>
    /// Class:PointcouponEntity
    /// Namespace:Ets.SingleApi.Model.Repository
    /// Class Funtion:Represent the class mapping the PointcouponEntity table in the database.
    /// </summary>
    /// Creator:周超
    /// Creation Date:2013/10/13 14:18:48
    /// Modifier:
    /// Last Modified:
    /// ----------------------------------------------------------------------------------------
    [Serializable]
    public class PointcouponEntity
    {
		#region private member

			/// <summary>
		/// The PointCouponID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int pointCouponId;

			/// <summary>
		/// The PointCouponName
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string pointCouponName;

			/// <summary>
		/// The Type
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? type;

			/// <summary>
		/// The BaseNumber
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? baseNumber;

			/// <summary>
		/// The ReturnNumber
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? returnNumber;

			/// <summary>
		/// The BeginTime
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private DateTime? beginTime;

			/// <summary>
		/// The EndTime
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private DateTime? endTime;

			/// <summary>
		/// The SendBeginTime
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private DateTime? sendBeginTime;

			/// <summary>
		/// The SendEndTime
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private DateTime? sendEndTime;

			/// <summary>
		/// The Note
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string note;

			/// <summary>
		/// The IsOpen
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private bool? isOpen;

			/// <summary>
		/// The IsDeleted
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private bool? isDeleted;

			/// <summary>
		/// The CreateDtateTime
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private DateTime? createDtateTime;

			/// <summary>
		/// The PointCouponSupplier_RList
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private IList<PointCouponSupplierREntity> pointCouponSupplierRList;

		#endregion

		/// <summary>
        /// Initializes a new instance of the <see cref="PointcouponEntity"/> class.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public PointcouponEntity()
        {
			this.pointCouponId = 0;
			this.pointCouponName = string.Empty;
			this.note = string.Empty;
		}

		#region public member

			/// <summary>
        /// Gets or sets a value mapping the PointCouponID of PointcouponEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int PointCouponId
		{
            get
            {
                return this.pointCouponId;
            }

            set
            {
                this.pointCouponId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the PointCouponName of PointcouponEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string PointCouponName
		{
            get
            {
                return this.pointCouponName;
            }

            set
            {
                this.pointCouponName = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Type of PointcouponEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? Type
		{
            get
            {
                return this.type;
            }

            set
            {
                this.type = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the BaseNumber of PointcouponEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? BaseNumber
		{
            get
            {
                return this.baseNumber;
            }

            set
            {
                this.baseNumber = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the ReturnNumber of PointcouponEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? ReturnNumber
		{
            get
            {
                return this.returnNumber;
            }

            set
            {
                this.returnNumber = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the BeginTime of PointcouponEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual DateTime? BeginTime
		{
            get
            {
                return this.beginTime;
            }

            set
            {
                this.beginTime = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the EndTime of PointcouponEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual DateTime? EndTime
		{
            get
            {
                return this.endTime;
            }

            set
            {
                this.endTime = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the SendBeginTime of PointcouponEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual DateTime? SendBeginTime
		{
            get
            {
                return this.sendBeginTime;
            }

            set
            {
                this.sendBeginTime = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the SendEndTime of PointcouponEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual DateTime? SendEndTime
		{
            get
            {
                return this.sendEndTime;
            }

            set
            {
                this.sendEndTime = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Note of PointcouponEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
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
        /// Gets or sets a value indicating whether mapping the IsOpen of PointcouponEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual bool? IsOpen
		{
            get
            {
                return this.isOpen;
            }

            set
            {
                this.isOpen = value;
            }
        }

			/// <summary>
        /// Gets or sets a value indicating whether mapping the IsDeleted of PointcouponEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual bool? IsDeleted
		{
            get
            {
                return this.isDeleted;
            }

            set
            {
                this.isDeleted = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the CreateDtateTime of PointcouponEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual DateTime? CreateDtateTime
		{
            get
            {
                return this.createDtateTime;
            }

            set
            {
                this.createDtateTime = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the PointCouponSupplier_RList of PointcouponEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual IList<PointCouponSupplierREntity> PointCouponSupplierRList
		{
            get
            {
                return this.pointCouponSupplierRList;
            }

            set
            {
                this.pointCouponSupplierRList = value;
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

            var castObj = (PointcouponEntity)obj;
            return this.PointCouponId == castObj.PointCouponId;
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
			hash = 27 * hash * this.PointCouponId.GetHashCode();
			return hash;
		}
	}
}