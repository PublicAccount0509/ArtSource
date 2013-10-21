// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CategoryEntity.cs" company="Irdeto">
//   Copyright @ 2013
// </copyright>
// <summary>
//   Class:CategoryEntity
//   Namespace:Ets.SingleApi.Model.Repository
//   Class Funtion:Represent the class mapping the CategoryEntity table in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ets.SingleApi.Model.Repository
{
	using System;
	using System.Collections.Generic;
		
    /// <summary>
    /// Class:CategoryEntity
    /// Namespace:Ets.SingleApi.Model.Repository
    /// Class Funtion:Represent the class mapping the CategoryEntity table in the database.
    /// </summary>
    /// Creator:周超
    /// Creation Date:2013/10/13 14:27:05
    /// Modifier:
    /// Last Modified:
    /// ----------------------------------------------------------------------------------------
    [Serializable]
    public class CategoryEntity
    {
		#region private member

			/// <summary>
		/// The CategoryID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int categoryId;

			/// <summary>
		/// The SupplierID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? supplierId;

			/// <summary>
		/// The CategoryName
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string categoryName;

			/// <summary>
		/// The CategoryDescription
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string categoryDescription;

			/// <summary>
		/// The CategoryImage
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string categoryImage;

			/// <summary>
		/// The CategoryNo
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? categoryNo;

			/// <summary>
		/// The categoryOldId
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private decimal? categoryOldId;

			/// <summary>
		/// The SupplierMenuCategoryId
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? supplierMenuCategoryId;

			/// <summary>
		/// The CuisineCategoryList
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private IList<CuisineCategoryEntity> cuisineCategoryList;

			/// <summary>
		/// The SupplierCategoryList
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private IList<SupplierCategoryEntity> supplierCategoryList;

			/// <summary>
		/// The CategoryTypeID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private CategoryTypeEntity categoryType;

		#endregion

		/// <summary>
        /// Initializes a new instance of the <see cref="CategoryEntity"/> class.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public CategoryEntity()
        {
			this.categoryId = 0;
			this.categoryName = string.Empty;
			this.categoryDescription = string.Empty;
			this.categoryImage = string.Empty;
		}

		#region public member

			/// <summary>
        /// Gets or sets a value mapping the CategoryID of CategoryEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int CategoryId
		{
            get
            {
                return this.categoryId;
            }

            set
            {
                this.categoryId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the SupplierID of CategoryEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? SupplierId
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
        /// Gets or sets a value mapping the CategoryName of CategoryEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string CategoryName
		{
            get
            {
                return this.categoryName;
            }

            set
            {
                this.categoryName = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the CategoryDescription of CategoryEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string CategoryDescription
		{
            get
            {
                return this.categoryDescription;
            }

            set
            {
                this.categoryDescription = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the CategoryImage of CategoryEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string CategoryImage
		{
            get
            {
                return this.categoryImage;
            }

            set
            {
                this.categoryImage = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the CategoryNo of CategoryEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? CategoryNo
		{
            get
            {
                return this.categoryNo;
            }

            set
            {
                this.categoryNo = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the categoryOldId of CategoryEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual decimal? CategoryOldId
		{
            get
            {
                return this.categoryOldId;
            }

            set
            {
                this.categoryOldId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the SupplierMenuCategoryId of CategoryEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? SupplierMenuCategoryId
		{
            get
            {
                return this.supplierMenuCategoryId;
            }

            set
            {
                this.supplierMenuCategoryId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the CuisineCategoryList of CategoryEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual IList<CuisineCategoryEntity> CuisineCategoryList
		{
            get
            {
                return this.cuisineCategoryList;
            }

            set
            {
                this.cuisineCategoryList = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the SupplierCategoryList of CategoryEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual IList<SupplierCategoryEntity> SupplierCategoryList
		{
            get
            {
                return this.supplierCategoryList;
            }

            set
            {
                this.supplierCategoryList = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the CategoryTypeID of CategoryEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual CategoryTypeEntity CategoryType
		{
            get
            {
                return this.categoryType;
            }

            set
            {
                this.categoryType = value;
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
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public override bool Equals(object obj)
        {
            if (obj == null || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }

            var castObj = (CategoryEntity)obj;
            return this.CategoryId == castObj.CategoryId;
        }

		/// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public override int GetHashCode()
		{
			var hash = 57; 
			hash = 27 * hash * this.CategoryId.GetHashCode();
			return hash;
		}
	}
}