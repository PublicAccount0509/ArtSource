// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CommentDiningPurposeEntity.cs" company="Irdeto">
//   Copyright @ 2013
// </copyright>
// <summary>
//   Class:CommentDiningPurposeEntity
//   Namespace:Ets.SingleApi.Model.Repository
//   Class Funtion:Represent the class mapping the CommentDiningPurposeEntity table in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ets.SingleApi.Model.Repository
{
	using System;
		
    /// <summary>
    /// Class:CommentDiningPurposeEntity
    /// Namespace:Ets.SingleApi.Model.Repository
    /// Class Funtion:Represent the class mapping the CommentDiningPurposeEntity table in the database.
    /// </summary>
    /// Creator:周超
    /// Creation Date:2013/10/13 14:23:32
    /// Modifier:
    /// Last Modified:
    /// ----------------------------------------------------------------------------------------
    [Serializable]
    public class CommentDiningPurposeEntity
    {
		#region private member

			/// <summary>
		/// The DiningPurposeID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:23:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int diningPurposeId;

			/// <summary>
		/// The SupplierCommentID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:23:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int supplierCommentId;

			/// <summary>
		/// The DiningPurposeID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:23:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private DiningPurposeEntity diningPurpose;

			/// <summary>
		/// The SupplierCommentID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:23:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private SupplierCommentEntity supplierComment;

		#endregion

		/// <summary>
        /// Initializes a new instance of the <see cref="CommentDiningPurposeEntity"/> class.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:23:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public CommentDiningPurposeEntity()
        {
			this.diningPurposeId = 0;
			this.supplierCommentId = 0;
		}

		#region public member

			/// <summary>
        /// Gets or sets a value mapping the DiningPurposeID of CommentDiningPurposeEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:23:32
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
        /// Gets or sets a value mapping the SupplierCommentID of CommentDiningPurposeEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:23:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int SupplierCommentId
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
        /// Gets or sets a value mapping the DiningPurposeID of CommentDiningPurposeEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:23:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual DiningPurposeEntity DiningPurpose
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
        /// Gets or sets a value mapping the SupplierCommentID of CommentDiningPurposeEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:23:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual SupplierCommentEntity SupplierComment
		{
            get
            {
                return this.supplierComment;
            }

            set
            {
                this.supplierComment = value;
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

            var castObj = (CommentDiningPurposeEntity)obj;
            return this.DiningPurposeId == castObj.DiningPurposeId && this.SupplierCommentId == castObj.SupplierCommentId;
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
			hash = 27 * hash * this.DiningPurposeId.GetHashCode();
			hash = 27 * hash * this.SupplierCommentId.GetHashCode();
			return hash;
		}
	}
}