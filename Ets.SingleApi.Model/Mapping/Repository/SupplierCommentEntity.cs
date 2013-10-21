// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SupplierCommentEntity.cs" company="Irdeto">
//   Copyright @ 2013
// </copyright>
// <summary>
//   Class:SupplierCommentEntity
//   Namespace:Ets.SingleApi.Model.Repository
//   Class Funtion:Represent the class mapping the SupplierCommentEntity table in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ets.SingleApi.Model.Repository
{
	using System;
	using System.Collections.Generic;
		
    /// <summary>
    /// Class:SupplierCommentEntity
    /// Namespace:Ets.SingleApi.Model.Repository
    /// Class Funtion:Represent the class mapping the SupplierCommentEntity table in the database.
    /// </summary>
    /// Creator:周超
    /// Creation Date:2013/10/13 14:23:32
    /// Modifier:
    /// Last Modified:
    /// ----------------------------------------------------------------------------------------
    [Serializable]
    public class SupplierCommentEntity
    {
		#region private member

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
		/// The SupplierID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:23:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int supplierId;

			/// <summary>
		/// The Comment
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:23:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string comment;

			/// <summary>
		/// The DateAdded
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:23:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private DateTime? dateAdded;

			/// <summary>
		/// The AverageConsumption
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:23:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? averageConsumption;

			/// <summary>
		/// The Tags
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:23:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string tags;

			/// <summary>
		/// The CommentImage
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:23:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string commentImage;

			/// <summary>
		/// The UserBaiduLat
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:23:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string userBaIduLat;

			/// <summary>
		/// The UserBaiduLong
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:23:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string userBaIduLong;

			/// <summary>
		/// The UserAddress
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:23:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string userAddress;

			/// <summary>
		/// The Source
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:23:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string source;

			/// <summary>
		/// The ISDelete
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:23:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? iSDelete;

			/// <summary>
		/// The CommentDiningPurposeList
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:23:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private IList<CommentDiningPurposeEntity> commentDiningPurposeList;

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
        /// Initializes a new instance of the <see cref="SupplierCommentEntity"/> class.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:23:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public SupplierCommentEntity()
        {
			this.supplierCommentId = 0;
			this.supplierId = 0;
			this.comment = string.Empty;
			this.tags = string.Empty;
			this.commentImage = string.Empty;
			this.userBaIduLat = string.Empty;
			this.userBaIduLong = string.Empty;
			this.userAddress = string.Empty;
			this.source = string.Empty;
		}

		#region public member

			/// <summary>
        /// Gets or sets a value mapping the SupplierCommentID of SupplierCommentEntity table in the database.
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
        /// Gets or sets a value mapping the SupplierID of SupplierCommentEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:23:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int SupplierId
		{
            get
            {
                return this.supplierId;
            }

            set
            {
                this.supplierId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Comment of SupplierCommentEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:23:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string Comment
		{
            get
            {
                return this.comment;
            }

            set
            {
                this.comment = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the DateAdded of SupplierCommentEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:23:32
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
        /// Gets or sets a value mapping the AverageConsumption of SupplierCommentEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:23:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? AverageConsumption
		{
            get
            {
                return this.averageConsumption;
            }

            set
            {
                this.averageConsumption = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Tags of SupplierCommentEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:23:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string Tags
		{
            get
            {
                return this.tags;
            }

            set
            {
                this.tags = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the CommentImage of SupplierCommentEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:23:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string CommentImage
		{
            get
            {
                return this.commentImage;
            }

            set
            {
                this.commentImage = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the UserBaiduLat of SupplierCommentEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:23:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string UserBaIduLat
		{
            get
            {
                return this.userBaIduLat;
            }

            set
            {
                this.userBaIduLat = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the UserBaiduLong of SupplierCommentEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:23:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string UserBaIduLong
		{
            get
            {
                return this.userBaIduLong;
            }

            set
            {
                this.userBaIduLong = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the UserAddress of SupplierCommentEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:23:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string UserAddress
		{
            get
            {
                return this.userAddress;
            }

            set
            {
                this.userAddress = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Source of SupplierCommentEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:23:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string Source
		{
            get
            {
                return this.source;
            }

            set
            {
                this.source = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the ISDelete of SupplierCommentEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:23:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? ISDelete
		{
            get
            {
                return this.iSDelete;
            }

            set
            {
                this.iSDelete = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the CommentDiningPurposeList of SupplierCommentEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:23:32
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
        /// Gets or sets a value mapping the CustomerID of SupplierCommentEntity table in the database.
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

            var castObj = (SupplierCommentEntity)obj;
            return this.SupplierCommentId == castObj.SupplierCommentId;
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
			hash = 27 * hash * this.SupplierCommentId.GetHashCode();
			return hash;
		}
	}
}