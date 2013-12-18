// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PackageSelectedDetailEntity.cs" company="Irdeto">
//   Copyright @ 2013
// </copyright>
// <summary>
//   Class:PackageSelectedDetailEntity
//   Namespace:Ets.SingleApi.Model.Repository
//   Class Funtion:Represent the class mapping the PackageSelectedDetailEntity table in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ets.SingleApi.Model.Repository
{
	using System;
		
    /// <summary>
    /// Class:PackageSelectedDetailEntity
    /// Namespace:Ets.SingleApi.Model.Repository
    /// Class Funtion:Represent the class mapping the PackageSelectedDetailEntity table in the database.
    /// </summary>
    /// Creator:周超
    /// Creation Date:2013/12/17 17:42:39
    /// Modifier:
    /// Last Modified:
    /// ----------------------------------------------------------------------------------------
    [Serializable]
    public class PackageSelectedDetailEntity
    {
		#region private member

			/// <summary>
		/// The PackageSelectedDetailID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/17 17:42:39
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int packageSelectedDetailId;

			/// <summary>
		/// The DishName
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/17 17:42:39
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string dishName;

			/// <summary>
		/// The DishNum
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/17 17:42:39
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int dishNum;

			/// <summary>
		/// The DishPrice
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/17 17:42:39
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private decimal? dishPrice;

			/// <summary>
		/// The DeliveryID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/17 17:42:39
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? deliveryId;

			/// <summary>
		/// The PackageSelectedID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/17 17:42:39
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private PackageSelectedEntity packageSelected;

		#endregion

		/// <summary>
        /// Initializes a new instance of the <see cref="PackageSelectedDetailEntity"/> class.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/17 17:42:39
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public PackageSelectedDetailEntity()
        {
			this.packageSelectedDetailId = 0;
			this.dishName = string.Empty;
			this.dishNum = 0;
		}

		#region public member

			/// <summary>
        /// Gets or sets a value mapping the PackageSelectedDetailID of PackageSelectedDetailEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/17 17:42:39
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int PackageSelectedDetailId
		{
            get
            {
                return this.packageSelectedDetailId;
            }

            set
            {
                this.packageSelectedDetailId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the DishName of PackageSelectedDetailEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/17 17:42:39
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string DishName
		{
            get
            {
                return this.dishName;
            }

            set
            {
                this.dishName = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the DishNum of PackageSelectedDetailEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/17 17:42:39
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int DishNum
		{
            get
            {
                return this.dishNum;
            }

            set
            {
                this.dishNum = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the DishPrice of PackageSelectedDetailEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/17 17:42:39
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual decimal? DishPrice
		{
            get
            {
                return this.dishPrice;
            }

            set
            {
                this.dishPrice = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the DeliveryID of PackageSelectedDetailEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/17 17:42:39
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? DeliveryId
		{
            get
            {
                return this.deliveryId;
            }

            set
            {
                this.deliveryId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the PackageSelectedID of PackageSelectedDetailEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/17 17:42:39
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual PackageSelectedEntity PackageSelected
		{
            get
            {
                return this.packageSelected;
            }

            set
            {
                this.packageSelected = value;
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

            var castObj = (PackageSelectedDetailEntity)obj;
            return this.PackageSelectedDetailId == castObj.PackageSelectedDetailId;
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
			hash = 27 * hash * this.PackageSelectedDetailId.GetHashCode();
			return hash;
		}
	}
}