// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CategoryTypeEntity.cs" company="Irdeto">
//   Copyright @ 2013
// </copyright>
// <summary>
//   Class:CategoryTypeEntity
//   Namespace:Ets.SingleApi.Model.Repository
//   Class Funtion:Represent the class mapping the CategoryTypeEntity table in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ets.SingleApi.Model.Repository
{
	using System;
	using System.Collections.Generic;
		
    /// <summary>
    /// Class:CategoryTypeEntity
    /// Namespace:Ets.SingleApi.Model.Repository
    /// Class Funtion:Represent the class mapping the CategoryTypeEntity table in the database.
    /// </summary>
    /// Creator:周超
    /// Creation Date:2013/10/13 14:32:24
    /// Modifier:
    /// Last Modified:
    /// ----------------------------------------------------------------------------------------
    [Serializable]
    public class CategoryTypeEntity
    {
		#region private member

			/// <summary>
		/// The CategoryTypeID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:32:24
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int categoryTypeId;

			/// <summary>
		/// The CategoryType
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:32:24
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string categoryType;

			/// <summary>
		/// The CategoryList
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:32:24
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private IList<CategoryEntity> categoryList;

		#endregion

		/// <summary>
        /// Initializes a new instance of the <see cref="CategoryTypeEntity"/> class.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:32:24
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public CategoryTypeEntity()
        {
			this.categoryTypeId = 0;
			this.categoryType = string.Empty;
		}

		#region public member

			/// <summary>
        /// Gets or sets a value mapping the CategoryTypeID of CategoryTypeEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:32:24
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int CategoryTypeId
		{
            get
            {
                return this.categoryTypeId;
            }

            set
            {
                this.categoryTypeId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the CategoryType of CategoryTypeEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:32:24
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string CategoryType
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

			/// <summary>
        /// Gets or sets a value mapping the CategoryList of CategoryTypeEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:32:24
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual IList<CategoryEntity> CategoryList
		{
            get
            {
                return this.categoryList;
            }

            set
            {
                this.categoryList = value;
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
        /// Creation Date:2013/10/13 14:32:24
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public override bool Equals(object obj)
        {
            if (obj == null || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }

            var castObj = (CategoryTypeEntity)obj;
            return this.CategoryTypeId == castObj.CategoryTypeId;
        }

		/// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:32:24
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public override int GetHashCode()
		{
			var hash = 57; 
			hash = 27 * hash * this.CategoryTypeId.GetHashCode();
			return hash;
		}
	}
}