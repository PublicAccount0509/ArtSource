// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SupplierDishCustomizationEntity.cs" company="Irdeto">
//   Copyright @ 2013
// </copyright>
// <summary>
//   Class:SupplierDishCustomizationEntity
//   Namespace:Ets.SingleApi.Model.Repository
//   Class Funtion:Represent the class mapping the SupplierDishCustomizationEntity table in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ets.SingleApi.Model.Repository
{
	using System;
		
    /// <summary>
    /// Class:SupplierDishCustomizationEntity
    /// Namespace:Ets.SingleApi.Model.Repository
    /// Class Funtion:Represent the class mapping the SupplierDishCustomizationEntity table in the database.
    /// </summary>
    /// Creator:周超
    /// Creation Date:2013/12/25 15:16:51
    /// Modifier:
    /// Last Modified:
    /// ----------------------------------------------------------------------------------------
    [Serializable]
    public class SupplierDishCustomizationEntity
    {
		#region private member

			/// <summary>
		/// The SupplierDishCustomizationID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/25 15:16:51
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int supplierDishCustomizationId;

			/// <summary>
		/// The SupplierDishID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/25 15:16:51
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int supplierDishId;

			/// <summary>
		/// The OptionGroupID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/25 15:16:51
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int optionGroupId;

			/// <summary>
		/// The IsDropdown
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/25 15:16:51
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? isDropdown;

			/// <summary>
		/// The minValue
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/25 15:16:51
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private decimal? minValue;

			/// <summary>
		/// The maxValue
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/25 15:16:51
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private decimal? maxValue;

		#endregion

		/// <summary>
        /// Initializes a new instance of the <see cref="SupplierDishCustomizationEntity"/> class.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/25 15:16:51
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public SupplierDishCustomizationEntity()
        {
			this.supplierDishCustomizationId = 0;
			this.supplierDishId = 0;
			this.optionGroupId = 0;
		}

		#region public member

			/// <summary>
        /// Gets or sets a value mapping the SupplierDishCustomizationID of SupplierDishCustomizationEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/25 15:16:51
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int SupplierDishCustomizationId
		{
            get
            {
                return this.supplierDishCustomizationId;
            }

            set
            {
                this.supplierDishCustomizationId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the SupplierDishID of SupplierDishCustomizationEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/25 15:16:51
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int SupplierDishId
		{
            get
            {
                return this.supplierDishId;
            }

            set
            {
                this.supplierDishId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the OptionGroupID of SupplierDishCustomizationEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/25 15:16:51
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int OptionGroupId
		{
            get
            {
                return this.optionGroupId;
            }

            set
            {
                this.optionGroupId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the IsDropdown of SupplierDishCustomizationEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/25 15:16:51
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? IsDropdown
		{
            get
            {
                return this.isDropdown;
            }

            set
            {
                this.isDropdown = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the minValue of SupplierDishCustomizationEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/25 15:16:51
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual decimal? MinValue
		{
            get
            {
                return this.minValue;
            }

            set
            {
                this.minValue = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the maxValue of SupplierDishCustomizationEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/25 15:16:51
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual decimal? MaxValue
		{
            get
            {
                return this.maxValue;
            }

            set
            {
                this.maxValue = value;
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
        /// Creation Date:2013/12/25 15:16:51
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public override bool Equals(object obj)
        {
            if (obj == null || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }

            var castObj = (SupplierDishCustomizationEntity)obj;
            return this.SupplierDishCustomizationId == castObj.SupplierDishCustomizationId;
        }

		/// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        /// Creator:周超
        /// Creation Date:2013/12/25 15:16:51
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public override int GetHashCode()
		{
			var hash = 57; 
			hash = 27 * hash * this.SupplierDishCustomizationId.GetHashCode();
			return hash;
		}
	}
}