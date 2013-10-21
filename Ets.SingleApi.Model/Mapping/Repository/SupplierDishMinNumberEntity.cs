// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SupplierDishMinNumberEntity.cs" company="Irdeto">
//   Copyright @ 2013
// </copyright>
// <summary>
//   Class:SupplierDishMinNumberEntity
//   Namespace:Ets.SingleApi.Model.Repository
//   Class Funtion:Represent the class mapping the SupplierDishMinNumberEntity table in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ets.SingleApi.Model.Repository
{
	using System;
		
    /// <summary>
    /// Class:SupplierDishMinNumberEntity
    /// Namespace:Ets.SingleApi.Model.Repository
    /// Class Funtion:Represent the class mapping the SupplierDishMinNumberEntity table in the database.
    /// </summary>
    /// Creator:周超
    /// Creation Date:2013/10/13 14:18:48
    /// Modifier:
    /// Last Modified:
    /// ----------------------------------------------------------------------------------------
    [Serializable]
    public class SupplierDishMinNumberEntity
    {
		#region private member

			/// <summary>
		/// The supplierdishMinNumberID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int supplierdishMinNumberId;

			/// <summary>
		/// The DishMinNumber
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? dishMinNumber;

			/// <summary>
		/// The supplierDishID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private SupplierDishEntity supplierDish;

		#endregion

		/// <summary>
        /// Initializes a new instance of the <see cref="SupplierDishMinNumberEntity"/> class.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public SupplierDishMinNumberEntity()
        {
			this.supplierdishMinNumberId = 0;
		}

		#region public member

			/// <summary>
        /// Gets or sets a value mapping the supplierdishMinNumberID of SupplierDishMinNumberEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int SupplierdishMinNumberId
		{
            get
            {
                return this.supplierdishMinNumberId;
            }

            set
            {
                this.supplierdishMinNumberId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the DishMinNumber of SupplierDishMinNumberEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? DishMinNumber
		{
            get
            {
                return this.dishMinNumber;
            }

            set
            {
                this.dishMinNumber = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the supplierDishID of SupplierDishMinNumberEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual SupplierDishEntity SupplierDish
		{
            get
            {
                return this.supplierDish;
            }

            set
            {
                this.supplierDish = value;
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

            var castObj = (SupplierDishMinNumberEntity)obj;
            return this.SupplierdishMinNumberId == castObj.SupplierdishMinNumberId;
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
			hash = 27 * hash * this.SupplierdishMinNumberId.GetHashCode();
			return hash;
		}
	}
}