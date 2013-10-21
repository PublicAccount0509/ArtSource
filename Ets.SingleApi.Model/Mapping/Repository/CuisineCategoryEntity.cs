// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CuisineCategoryEntity.cs" company="Irdeto">
//   Copyright @ 2013
// </copyright>
// <summary>
//   Class:CuisineCategoryEntity
//   Namespace:Ets.SingleApi.Model.Repository
//   Class Funtion:Represent the class mapping the CuisineCategoryEntity table in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ets.SingleApi.Model.Repository
{
	using System;
		
    /// <summary>
    /// Class:CuisineCategoryEntity
    /// Namespace:Ets.SingleApi.Model.Repository
    /// Class Funtion:Represent the class mapping the CuisineCategoryEntity table in the database.
    /// </summary>
    /// Creator:周超
    /// Creation Date:2013/10/13 14:23:32
    /// Modifier:
    /// Last Modified:
    /// ----------------------------------------------------------------------------------------
    [Serializable]
    public class CuisineCategoryEntity
    {
		#region private member

			/// <summary>
		/// The CuisineCategoryID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:23:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int cuisineCategoryId;

			/// <summary>
		/// The CategoryID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:23:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private CategoryEntity category;

			/// <summary>
		/// The CuisineID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:23:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private CuisineEntity cuisine;

		#endregion

		/// <summary>
        /// Initializes a new instance of the <see cref="CuisineCategoryEntity"/> class.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:23:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public CuisineCategoryEntity()
        {
			this.cuisineCategoryId = 0;
		}

		#region public member

			/// <summary>
        /// Gets or sets a value mapping the CuisineCategoryID of CuisineCategoryEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:23:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int CuisineCategoryId
		{
            get
            {
                return this.cuisineCategoryId;
            }

            set
            {
                this.cuisineCategoryId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the CategoryID of CuisineCategoryEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:23:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual CategoryEntity Category
		{
            get
            {
                return this.category;
            }

            set
            {
                this.category = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the CuisineID of CuisineCategoryEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:23:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual CuisineEntity Cuisine
		{
            get
            {
                return this.cuisine;
            }

            set
            {
                this.cuisine = value;
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

            var castObj = (CuisineCategoryEntity)obj;
            return this.CuisineCategoryId == castObj.CuisineCategoryId;
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
			hash = 27 * hash * this.CuisineCategoryId.GetHashCode();
			return hash;
		}
	}
}