// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PackageNameEntity.cs" company="Irdeto">
//   Copyright @ 2013
// </copyright>
// <summary>
//   Class:PackageNameEntity
//   Namespace:Ets.SingleApi.Model.Repository
//   Class Funtion:Represent the class mapping the PackageNameEntity table in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ets.SingleApi.Model.Repository
{
	using System;
	using System.Collections.Generic;
		
    /// <summary>
    /// Class:PackageNameEntity
    /// Namespace:Ets.SingleApi.Model.Repository
    /// Class Funtion:Represent the class mapping the PackageNameEntity table in the database.
    /// </summary>
    /// Creator:周超
    /// Creation Date:2013/12/17 17:42:39
    /// Modifier:
    /// Last Modified:
    /// ----------------------------------------------------------------------------------------
    [Serializable]
    public class PackageNameEntity
    {
		#region private member

			/// <summary>
		/// The PackageID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/17 17:42:39
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int packageId;

			/// <summary>
		/// The SupplierID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/17 17:42:39
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int supplierId;

			/// <summary>
		/// The PackageNames
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/17 17:42:39
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string packageNames;

			/// <summary>
		/// The PackagePrice
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/17 17:42:39
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private decimal? packagePrice;

			/// <summary>
		/// The PackageNote
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/17 17:42:39
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string packageNote;

			/// <summary>
		/// The ImageUrl
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/17 17:42:39
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string imageUrl;

			/// <summary>
		/// The IsEnabled
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/17 17:42:39
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private bool? isEnabled;

			/// <summary>
		/// The PackageSelectedList
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/17 17:42:39
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private IList<PackageSelectedEntity> packageSelectedList;

		#endregion

		/// <summary>
        /// Initializes a new instance of the <see cref="PackageNameEntity"/> class.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/17 17:42:39
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public PackageNameEntity()
        {
			this.packageId = 0;
			this.supplierId = 0;
			this.packageNames = string.Empty;
			this.packageNote = string.Empty;
			this.imageUrl = string.Empty;
		}

		#region public member

			/// <summary>
        /// Gets or sets a value mapping the PackageID of PackageNameEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/17 17:42:39
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int PackageId
		{
            get
            {
                return this.packageId;
            }

            set
            {
                this.packageId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the SupplierID of PackageNameEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/17 17:42:39
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
        /// Gets or sets a value mapping the PackageNames of PackageNameEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/17 17:42:39
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string PackageNames
		{
            get
            {
                return this.packageNames;
            }

            set
            {
                this.packageNames = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the PackagePrice of PackageNameEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/17 17:42:39
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual decimal? PackagePrice
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
        /// Gets or sets a value mapping the PackageNote of PackageNameEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/17 17:42:39
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string PackageNote
		{
            get
            {
                return this.packageNote;
            }

            set
            {
                this.packageNote = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the ImageUrl of PackageNameEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/17 17:42:39
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string ImageUrl
		{
            get
            {
                return this.imageUrl;
            }

            set
            {
                this.imageUrl = value;
            }
        }

			/// <summary>
        /// Gets or sets a value indicating whether mapping the IsEnabled of PackageNameEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/17 17:42:39
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual bool? IsEnabled
		{
            get
            {
                return this.isEnabled;
            }

            set
            {
                this.isEnabled = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the PackageSelectedList of PackageNameEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/17 17:42:39
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual IList<PackageSelectedEntity> PackageSelectedList
		{
            get
            {
                return this.packageSelectedList;
            }

            set
            {
                this.packageSelectedList = value;
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

            var castObj = (PackageNameEntity)obj;
            return this.PackageId == castObj.PackageId;
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
			hash = 27 * hash * this.PackageId.GetHashCode();
			return hash;
		}
	}
}