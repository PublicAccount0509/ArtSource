// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SupplierDishGroupEntity.cs" company="Irdeto">
//   Copyright @ 2013
// </copyright>
// <summary>
//   Class:SupplierDishGroupEntity
//   Namespace:Ets.SingleApi.Model.Repository
//   Class Funtion:Represent the class mapping the SupplierDishGroupEntity table in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ets.SingleApi.Model.Repository
{
	using System;
		
    /// <summary>
    /// Class:SupplierDishGroupEntity
    /// Namespace:Ets.SingleApi.Model.Repository
    /// Class Funtion:Represent the class mapping the SupplierDishGroupEntity table in the database.
    /// </summary>
    /// Creator:周超
    /// Creation Date:2013/12/25 15:16:51
    /// Modifier:
    /// Last Modified:
    /// ----------------------------------------------------------------------------------------
    [Serializable]
    public class SupplierDishGroupEntity
    {
		#region private member

			/// <summary>
		/// The SupplierDishGroupId
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/25 15:16:51
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int supplierDishGroupId;

			/// <summary>
		/// The MainSupplierDish
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/25 15:16:51
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? mainSupplierDish;

			/// <summary>
		/// The SubSupplierDish
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/25 15:16:51
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? subSupplierDish;

		#endregion

		/// <summary>
        /// Initializes a new instance of the <see cref="SupplierDishGroupEntity"/> class.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/25 15:16:51
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public SupplierDishGroupEntity()
        {
			this.supplierDishGroupId = 0;
		}

		#region public member

			/// <summary>
        /// Gets or sets a value mapping the SupplierDishGroupId of SupplierDishGroupEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/25 15:16:51
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int SupplierDishGroupId
		{
            get
            {
                return this.supplierDishGroupId;
            }

            set
            {
                this.supplierDishGroupId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the MainSupplierDish of SupplierDishGroupEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/25 15:16:51
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? MainSupplierDish
		{
            get
            {
                return this.mainSupplierDish;
            }

            set
            {
                this.mainSupplierDish = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the SubSupplierDish of SupplierDishGroupEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/25 15:16:51
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? SubSupplierDish
		{
            get
            {
                return this.subSupplierDish;
            }

            set
            {
                this.subSupplierDish = value;
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

            var castObj = (SupplierDishGroupEntity)obj;
            return this.SupplierDishGroupId == castObj.SupplierDishGroupId;
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
			hash = 27 * hash * this.SupplierDishGroupId.GetHashCode();
			return hash;
		}
	}
}