// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FeatureEntity.cs" company="Irdeto">
//   Copyright @ 2013
// </copyright>
// <summary>
//   Class:FeatureEntity
//   Namespace:Ets.SingleApi.Model.Repository
//   Class Funtion:Represent the class mapping the FeatureEntity table in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ets.SingleApi.Model.Repository
{
	using System;
	using System.Collections.Generic;
		
    /// <summary>
    /// Class:FeatureEntity
    /// Namespace:Ets.SingleApi.Model.Repository
    /// Class Funtion:Represent the class mapping the FeatureEntity table in the database.
    /// </summary>
    /// Creator:周超
    /// Creation Date:2013/10/13 14:18:48
    /// Modifier:
    /// Last Modified:
    /// ----------------------------------------------------------------------------------------
    [Serializable]
    public class FeatureEntity
    {
		#region private member

			/// <summary>
		/// The FeatureID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int featureId;

			/// <summary>
		/// The Feature
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string feature;

			/// <summary>
		/// The DateAdded
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private DateTime dateAdded;

			/// <summary>
		/// The ParentId
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? parentId;

			/// <summary>
		/// The IsDefault
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private bool? isDefault;

			/// <summary>
		/// The ImagePath
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string imagePath;

			/// <summary>
		/// The HolidayBackupSupplierList
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private IList<HolidayBackupSupplierEntity> holIdayBackupSupplierList;

			/// <summary>
		/// The SupplierFeatureList
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private IList<SupplierFeatureEntity> supplierFeatureList;

		#endregion

		/// <summary>
        /// Initializes a new instance of the <see cref="FeatureEntity"/> class.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public FeatureEntity()
        {
			this.featureId = 0;
			this.feature = string.Empty;
			this.dateAdded = DateTime.Now;
			this.imagePath = string.Empty;
		}

		#region public member

			/// <summary>
        /// Gets or sets a value mapping the FeatureID of FeatureEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int FeatureId
		{
            get
            {
                return this.featureId;
            }

            set
            {
                this.featureId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Feature of FeatureEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string Feature
		{
            get
            {
                return this.feature;
            }

            set
            {
                this.feature = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the DateAdded of FeatureEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual DateTime DateAdded
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
        /// Gets or sets a value mapping the ParentId of FeatureEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? ParentId
		{
            get
            {
                return this.parentId;
            }

            set
            {
                this.parentId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value indicating whether mapping the IsDefault of FeatureEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual bool? IsDefault
		{
            get
            {
                return this.isDefault;
            }

            set
            {
                this.isDefault = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the ImagePath of FeatureEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string ImagePath
		{
            get
            {
                return this.imagePath;
            }

            set
            {
                this.imagePath = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the HolidayBackupSupplierList of FeatureEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual IList<HolidayBackupSupplierEntity> HolIdayBackupSupplierList
		{
            get
            {
                return this.holIdayBackupSupplierList;
            }

            set
            {
                this.holIdayBackupSupplierList = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the SupplierFeatureList of FeatureEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual IList<SupplierFeatureEntity> SupplierFeatureList
		{
            get
            {
                return this.supplierFeatureList;
            }

            set
            {
                this.supplierFeatureList = value;
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

            var castObj = (FeatureEntity)obj;
            return this.FeatureId == castObj.FeatureId;
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
			hash = 27 * hash * this.FeatureId.GetHashCode();
			return hash;
		}
	}
}