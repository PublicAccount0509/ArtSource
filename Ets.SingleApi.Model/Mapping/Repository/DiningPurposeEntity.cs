// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DiningPurposeEntity.cs" company="Irdeto">
//   Copyright @ 2013
// </copyright>
// <summary>
//   Class:DiningPurposeEntity
//   Namespace:Ets.SingleApi.Model.Repository
//   Class Funtion:Represent the class mapping the DiningPurposeEntity table in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ets.SingleApi.Model.Repository
{
	using System;
	using System.Collections.Generic;
		
    /// <summary>
    /// Class:DiningPurposeEntity
    /// Namespace:Ets.SingleApi.Model.Repository
    /// Class Funtion:Represent the class mapping the DiningPurposeEntity table in the database.
    /// </summary>
    /// Creator:周超
    /// Creation Date:2013/10/13 14:18:48
    /// Modifier:
    /// Last Modified:
    /// ----------------------------------------------------------------------------------------
    [Serializable]
    public class DiningPurposeEntity
    {
		#region private member

			/// <summary>
		/// The DiningPurposeID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int diningPurposeId;

			/// <summary>
		/// The DiningPurpose
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string diningPurpose;

			/// <summary>
		/// The CommentDiningPurposeList
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private IList<CommentDiningPurposeEntity> commentDiningPurposeList;

			/// <summary>
		/// The SupplierDiningPurposeList
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private IList<SupplierDiningPurposeEntity> supplierDiningPurposeList;

		#endregion

		/// <summary>
        /// Initializes a new instance of the <see cref="DiningPurposeEntity"/> class.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public DiningPurposeEntity()
        {
			this.diningPurposeId = 0;
			this.diningPurpose = string.Empty;
		}

		#region public member

			/// <summary>
        /// Gets or sets a value mapping the DiningPurposeID of DiningPurposeEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int DiningPurposeId
		{
            get
            {
                return this.diningPurposeId;
            }

            set
            {
                this.diningPurposeId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the DiningPurpose of DiningPurposeEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string DiningPurpose
		{
            get
            {
                return this.diningPurpose;
            }

            set
            {
                this.diningPurpose = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the CommentDiningPurposeList of DiningPurposeEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual IList<CommentDiningPurposeEntity> CommentDiningPurposeList
		{
            get
            {
                return this.commentDiningPurposeList;
            }

            set
            {
                this.commentDiningPurposeList = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the SupplierDiningPurposeList of DiningPurposeEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual IList<SupplierDiningPurposeEntity> SupplierDiningPurposeList
		{
            get
            {
                return this.supplierDiningPurposeList;
            }

            set
            {
                this.supplierDiningPurposeList = value;
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

            var castObj = (DiningPurposeEntity)obj;
            return this.DiningPurposeId == castObj.DiningPurposeId;
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
			hash = 27 * hash * this.DiningPurposeId.GetHashCode();
			return hash;
		}
	}
}