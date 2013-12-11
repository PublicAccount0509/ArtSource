// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SupplierTimeTableEntity.cs" company="Irdeto">
//   Copyright @ 2013
// </copyright>
// <summary>
//   Class:SupplierTimeTableEntity
//   Namespace:Ets.SingleApi.Model.Repository
//   Class Funtion:Represent the class mapping the SupplierTimeTableEntity table in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ets.SingleApi.Model.Repository
{
	using System;
		
    /// <summary>
    /// Class:SupplierTimeTableEntity
    /// Namespace:Ets.SingleApi.Model.Repository
    /// Class Funtion:Represent the class mapping the SupplierTimeTableEntity table in the database.
    /// </summary>
    /// Creator:周超
    /// Creation Date:2013/12/11 14:27:52
    /// Modifier:
    /// Last Modified:
    /// ----------------------------------------------------------------------------------------
    [Serializable]
    public class SupplierTimeTableEntity
    {
		#region private member

			/// <summary>
		/// The SupplierTimeTableID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/11 14:27:54
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int supplierTimeTableId;

			/// <summary>
		/// The SupplierID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/11 14:27:54
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int supplierId;

			/// <summary>
		/// The TimeTableID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/11 14:27:54
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int timeTableId;

			/// <summary>
		/// The Day
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/11 14:27:54
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int day;

		#endregion

		/// <summary>
        /// Initializes a new instance of the <see cref="SupplierTimeTableEntity"/> class.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/11 14:27:54
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public SupplierTimeTableEntity()
        {
			this.supplierTimeTableId = 0;
			this.supplierId = 0;
			this.timeTableId = 0;
			this.day = 0;
		}

		#region public member

			/// <summary>
        /// Gets or sets a value mapping the SupplierTimeTableID of SupplierTimeTableEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/11 14:27:54
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int SupplierTimeTableId
		{
            get
            {
                return this.supplierTimeTableId;
            }

            set
            {
                this.supplierTimeTableId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the SupplierID of SupplierTimeTableEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/11 14:27:54
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
        /// Gets or sets a value mapping the TimeTableID of SupplierTimeTableEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/11 14:27:54
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int TimeTableId
		{
            get
            {
                return this.timeTableId;
            }

            set
            {
                this.timeTableId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Day of SupplierTimeTableEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/11 14:27:54
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int Day
		{
            get
            {
                return this.day;
            }

            set
            {
                this.day = value;
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
        /// Creation Date:2013/12/11 14:27:54
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public override bool Equals(object obj)
        {
            if (obj == null || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }

            var castObj = (SupplierTimeTableEntity)obj;
            return this.SupplierTimeTableId == castObj.SupplierTimeTableId;
        }

		/// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        /// Creator:周超
        /// Creation Date:2013/12/11 14:27:54
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public override int GetHashCode()
		{
			var hash = 57; 
			hash = 27 * hash * this.SupplierTimeTableId.GetHashCode();
			return hash;
		}
	}
}