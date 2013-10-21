// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RatingTypeEntity.cs" company="Irdeto">
//   Copyright @ 2013
// </copyright>
// <summary>
//   Class:RatingTypeEntity
//   Namespace:Ets.SingleApi.Model.Repository
//   Class Funtion:Represent the class mapping the RatingTypeEntity table in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ets.SingleApi.Model.Repository
{
	using System;
	using System.Collections.Generic;
		
    /// <summary>
    /// Class:RatingTypeEntity
    /// Namespace:Ets.SingleApi.Model.Repository
    /// Class Funtion:Represent the class mapping the RatingTypeEntity table in the database.
    /// </summary>
    /// Creator:周超
    /// Creation Date:2013/10/13 14:18:48
    /// Modifier:
    /// Last Modified:
    /// ----------------------------------------------------------------------------------------
    [Serializable]
    public class RatingTypeEntity
    {
		#region private member

			/// <summary>
		/// The RatingTypeID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int ratingTypeId;

			/// <summary>
		/// The RatingTypeName
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string ratingTypeName;

			/// <summary>
		/// The RatingTypeName1
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string ratingTypeName1;

			/// <summary>
		/// The SupplierRatingList
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private IList<SupplierRatingEntity> supplierRatingList;

		#endregion

		/// <summary>
        /// Initializes a new instance of the <see cref="RatingTypeEntity"/> class.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public RatingTypeEntity()
        {
			this.ratingTypeId = 0;
			this.ratingTypeName = string.Empty;
			this.ratingTypeName1 = string.Empty;
		}

		#region public member

			/// <summary>
        /// Gets or sets a value mapping the RatingTypeID of RatingTypeEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int RatingTypeId
		{
            get
            {
                return this.ratingTypeId;
            }

            set
            {
                this.ratingTypeId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the RatingTypeName of RatingTypeEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string RatingTypeName
		{
            get
            {
                return this.ratingTypeName;
            }

            set
            {
                this.ratingTypeName = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the RatingTypeName1 of RatingTypeEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string RatingTypeName1
		{
            get
            {
                return this.ratingTypeName1;
            }

            set
            {
                this.ratingTypeName1 = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the SupplierRatingList of RatingTypeEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual IList<SupplierRatingEntity> SupplierRatingList
		{
            get
            {
                return this.supplierRatingList;
            }

            set
            {
                this.supplierRatingList = value;
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

            var castObj = (RatingTypeEntity)obj;
            return this.RatingTypeId == castObj.RatingTypeId;
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
			hash = 27 * hash * this.RatingTypeId.GetHashCode();
			return hash;
		}
	}
}