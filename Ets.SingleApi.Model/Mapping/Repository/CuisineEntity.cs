// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CuisineEntity.cs" company="Irdeto">
//   Copyright @ 2013
// </copyright>
// <summary>
//   Class:CuisineEntity
//   Namespace:Ets.SingleApi.Model.Repository
//   Class Funtion:Represent the class mapping the CuisineEntity table in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ets.SingleApi.Model.Repository
{
	using System;
	using System.Collections.Generic;
		
    /// <summary>
    /// Class:CuisineEntity
    /// Namespace:Ets.SingleApi.Model.Repository
    /// Class Funtion:Represent the class mapping the CuisineEntity table in the database.
    /// </summary>
    /// Creator:周超
    /// Creation Date:2013/10/13 14:18:48
    /// Modifier:
    /// Last Modified:
    /// ----------------------------------------------------------------------------------------
    [Serializable]
    public class CuisineEntity
    {
		#region private member

			/// <summary>
		/// The CuisineID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int cuisineId;

			/// <summary>
		/// The CuisineName
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string cuisineName;

			/// <summary>
		/// The CuisineName1
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string cuisineName1;

			/// <summary>
		/// The CuisineDescription
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string cuisineDescription;

			/// <summary>
		/// The CuisineImage
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string cuisineImage;

			/// <summary>
		/// The CuisineNo
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? cuisineNo;

			/// <summary>
		/// The CuisineCategoryList
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private IList<CuisineCategoryEntity> cuisineCategoryList;

			/// <summary>
		/// The SupplierCuisineList
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private IList<SupplierCuisineEntity> supplierCuisineList;

			/// <summary>
		/// The SupplierMenuCategoryType
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private SupplierMenuCategoryEntity supplierMenuCategoryType;

		#endregion

		/// <summary>
        /// Initializes a new instance of the <see cref="CuisineEntity"/> class.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public CuisineEntity()
        {
			this.cuisineId = 0;
			this.cuisineName = string.Empty;
			this.cuisineName1 = string.Empty;
			this.cuisineDescription = string.Empty;
			this.cuisineImage = string.Empty;
		}

		#region public member

			/// <summary>
        /// Gets or sets a value mapping the CuisineID of CuisineEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int CuisineId
		{
            get
            {
                return this.cuisineId;
            }

            set
            {
                this.cuisineId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the CuisineName of CuisineEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string CuisineName
		{
            get
            {
                return this.cuisineName;
            }

            set
            {
                this.cuisineName = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the CuisineName1 of CuisineEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string CuisineName1
		{
            get
            {
                return this.cuisineName1;
            }

            set
            {
                this.cuisineName1 = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the CuisineDescription of CuisineEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string CuisineDescription
		{
            get
            {
                return this.cuisineDescription;
            }

            set
            {
                this.cuisineDescription = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the CuisineImage of CuisineEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string CuisineImage
		{
            get
            {
                return this.cuisineImage;
            }

            set
            {
                this.cuisineImage = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the CuisineNo of CuisineEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? CuisineNo
		{
            get
            {
                return this.cuisineNo;
            }

            set
            {
                this.cuisineNo = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the CuisineCategoryList of CuisineEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
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
        /// Gets or sets a value mapping the SupplierCuisineList of CuisineEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual IList<SupplierCuisineEntity> SupplierCuisineList
		{
            get
            {
                return this.supplierCuisineList;
            }

            set
            {
                this.supplierCuisineList = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the SupplierMenuCategoryType of CuisineEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual SupplierMenuCategoryEntity SupplierMenuCategoryType
		{
            get
            {
                return this.supplierMenuCategoryType;
            }

            set
            {
                this.supplierMenuCategoryType = value;
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

            var castObj = (CuisineEntity)obj;
            return this.CuisineId == castObj.CuisineId;
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
			hash = 27 * hash * this.CuisineId.GetHashCode();
			return hash;
		}
	}
}