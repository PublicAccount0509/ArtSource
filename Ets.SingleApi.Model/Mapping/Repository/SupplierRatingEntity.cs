// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SupplierRatingEntity.cs" company="Irdeto">
//   Copyright @ 2013
// </copyright>
// <summary>
//   Class:SupplierRatingEntity
//   Namespace:Ets.SingleApi.Model.Repository
//   Class Funtion:Represent the class mapping the SupplierRatingEntity table in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ets.SingleApi.Model.Repository
{
	using System;
		
    /// <summary>
    /// Class:SupplierRatingEntity
    /// Namespace:Ets.SingleApi.Model.Repository
    /// Class Funtion:Represent the class mapping the SupplierRatingEntity table in the database.
    /// </summary>
    /// Creator:周超
    /// Creation Date:2013/10/13 14:01:30
    /// Modifier:
    /// Last Modified:
    /// ----------------------------------------------------------------------------------------
    [Serializable]
    public class SupplierRatingEntity
    {
		#region private member

			/// <summary>
		/// The SupplierRatingID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int supplierRatingId;

			/// <summary>
		/// The Rating
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? rating;

			/// <summary>
		/// The VoteCount
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? voteCount;

			/// <summary>
		/// The CustomerID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? customerId;

			/// <summary>
		/// The SupplierCommentID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? supplierCommentId;

			/// <summary>
		/// The DateAdded
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private DateTime? dateAdded;

			/// <summary>
		/// The RatingTypeID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private RatingTypeEntity ratingType;

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
        /// Initializes a new instance of the <see cref="SupplierRatingEntity"/> class.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public SupplierRatingEntity()
        {
			this.supplierRatingId = 0;
		}

		#region public member

			/// <summary>
        /// Gets or sets a value mapping the SupplierRatingID of SupplierRatingEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int SupplierRatingId
		{
            get
            {
                return this.supplierRatingId;
            }

            set
            {
                this.supplierRatingId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Rating of SupplierRatingEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? Rating
		{
            get
            {
                return this.rating;
            }

            set
            {
                this.rating = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the VoteCount of SupplierRatingEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? VoteCount
		{
            get
            {
                return this.voteCount;
            }

            set
            {
                this.voteCount = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the CustomerID of SupplierRatingEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
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
        /// Gets or sets a value mapping the SupplierCommentID of SupplierRatingEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? SupplierCommentId
		{
            get
            {
                return this.supplierCommentId;
            }

            set
            {
                this.supplierCommentId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the DateAdded of SupplierRatingEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual DateTime? DateAdded
		{
            get
            {
                return this.dateAdded;
            }

            set
            {
                this.dateAdded = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the RatingTypeID of SupplierRatingEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual RatingTypeEntity RatingType
		{
            get
            {
                return this.ratingType;
            }

            set
            {
                this.ratingType = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the SupplierID of SupplierRatingEntity table in the database.
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

            var castObj = (SupplierRatingEntity)obj;
            return this.SupplierRatingId == castObj.SupplierRatingId;
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
			hash = 27 * hash * this.SupplierRatingId.GetHashCode();
			return hash;
		}
	}
}