// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PackageSelectedEntity.cs" company="Irdeto">
//   Copyright @ 2013
// </copyright>
// <summary>
//   Class:PackageSelectedEntity
//   Namespace:Ets.SingleApi.Model.Repository
//   Class Funtion:Represent the class mapping the PackageSelectedEntity table in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ets.SingleApi.Model.Repository
{
	using System;
	using System.Collections.Generic;
		
    /// <summary>
    /// Class:PackageSelectedEntity
    /// Namespace:Ets.SingleApi.Model.Repository
    /// Class Funtion:Represent the class mapping the PackageSelectedEntity table in the database.
    /// </summary>
    /// Creator:周超
    /// Creation Date:2013/12/17 17:42:39
    /// Modifier:
    /// Last Modified:
    /// ----------------------------------------------------------------------------------------
    [Serializable]
    public class PackageSelectedEntity
    {
		#region private member

			/// <summary>
		/// The PackageSelectedID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/17 17:42:39
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int packageSelectedId;

			/// <summary>
		/// The PackageName
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/17 17:42:39
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string packageName;

			/// <summary>
		/// The PackagePrice
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/17 17:42:39
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private decimal packagePrice;

			/// <summary>
		/// The PackageNum
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/17 17:42:39
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int packageNum;

			/// <summary>
		/// The Comment
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/17 17:42:39
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string comment;

			/// <summary>
		/// The PackageSelectedDetailList
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/17 17:42:39
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private IList<PackageSelectedDetailEntity> packageSelectedDetailList;

			/// <summary>
		/// The DeliveryID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/17 17:42:39
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private DeliveryEntity delivery;

			/// <summary>
		/// The PackageID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/17 17:42:39
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private PackageNameEntity package;

			/// <summary>
		/// The SupplierID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/17 17:42:39
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private SupplierEntity supplier;

		#endregion

		/// <summary>
        /// Initializes a new instance of the <see cref="PackageSelectedEntity"/> class.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/17 17:42:39
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public PackageSelectedEntity()
        {
			this.packageSelectedId = 0;
			this.packageName = string.Empty;
			this.packagePrice = 0;
			this.packageNum = 0;
			this.comment = string.Empty;
		}

		#region public member

			/// <summary>
        /// Gets or sets a value mapping the PackageSelectedID of PackageSelectedEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/17 17:42:39
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int PackageSelectedId
		{
            get
            {
                return this.packageSelectedId;
            }

            set
            {
                this.packageSelectedId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the PackageName of PackageSelectedEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/17 17:42:39
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string PackageName
		{
            get
            {
                return this.packageName;
            }

            set
            {
                this.packageName = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the PackagePrice of PackageSelectedEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/17 17:42:39
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual decimal PackagePrice
		{
            get
            {
                return this.packagePrice;
            }

            set
            {
                this.packagePrice = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the PackageNum of PackageSelectedEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/17 17:42:39
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int PackageNum
		{
            get
            {
                return this.packageNum;
            }

            set
            {
                this.packageNum = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Comment of PackageSelectedEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/17 17:42:39
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
        /// Gets or sets a value mapping the PackageSelectedDetailList of PackageSelectedEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/17 17:42:39
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual IList<PackageSelectedDetailEntity> PackageSelectedDetailList
		{
            get
            {
                return this.packageSelectedDetailList;
            }

            set
            {
                this.packageSelectedDetailList = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the DeliveryID of PackageSelectedEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/17 17:42:39
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

			/// <summary>
        /// Gets or sets a value mapping the PackageID of PackageSelectedEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/17 17:42:39
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual PackageNameEntity Package
		{
            get
            {
                return this.package;
            }

            set
            {
                this.package = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the SupplierID of PackageSelectedEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/17 17:42:39
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
        /// Creation Date:2013/12/17 17:42:39
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public override bool Equals(object obj)
        {
            if (obj == null || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }

            var castObj = (PackageSelectedEntity)obj;
            return this.PackageSelectedId == castObj.PackageSelectedId;
        }

		/// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        /// Creator:周超
        /// Creation Date:2013/12/17 17:42:39
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public override int GetHashCode()
		{
			var hash = 57; 
			hash = 27 * hash * this.PackageSelectedId.GetHashCode();
			return hash;
		}
	}
}