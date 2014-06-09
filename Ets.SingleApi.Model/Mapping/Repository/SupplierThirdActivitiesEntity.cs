// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SupplierThirdActivitiesEntity.cs" company="Irdeto">
//   Copyright @ 2014
// </copyright>
// <summary>
//   Class:SupplierThirdActivitiesEntity
//   Namespace:Ets.SingleApi.Model.Repository
//   Class Funtion:Represent the class mapping the SupplierThirdActivitiesEntity table in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ets.SingleApi.Model.Repository
{
	using System;
		
    /// <summary>
    /// Class:SupplierThirdActivitiesEntity
    /// Namespace:Ets.SingleApi.Model.Repository
    /// Class Funtion:Represent the class mapping the SupplierThirdActivitiesEntity table in the database.
    /// </summary>
    /// Creator:周超
    /// Creation Date:2014/6/9 9:58:20
    /// Modifier:
    /// Last Modified:
    /// ----------------------------------------------------------------------------------------
    [Serializable]
    public class SupplierThirdActivitiesEntity
    {
		#region private member

			/// <summary>
		/// The SupplierThirdActivitieId
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/6/9 9:58:20
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int supplierThirdActivitieId;

			/// <summary>
		/// The IsDelete
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/6/9 9:58:20
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private bool isDelete;

			/// <summary>
		/// The CreateDate
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/6/9 9:58:20
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private DateTime createDate;

			/// <summary>
		/// The SupplierId
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/6/9 9:58:20
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private SupplierEntity supplier;

			/// <summary>
		/// The ThirdActivitieId
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/6/9 9:58:20
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private ThirdActivitiesEntity thirdActivitie;

		#endregion

		/// <summary>
        /// Initializes a new instance of the <see cref="SupplierThirdActivitiesEntity"/> class.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/6/9 9:58:20
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public SupplierThirdActivitiesEntity()
        {
			this.supplierThirdActivitieId = 0;
			this.isDelete = false;
			this.createDate = DateTime.Now;
		}

		#region public member

			/// <summary>
        /// Gets or sets a value mapping the SupplierThirdActivitieId of SupplierThirdActivitiesEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/6/9 9:58:20
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int SupplierThirdActivitieId
		{
            get
            {
                return this.supplierThirdActivitieId;
            }

            set
            {
                this.supplierThirdActivitieId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value indicating whether mapping the IsDelete of SupplierThirdActivitiesEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/6/9 9:58:20
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual bool IsDelete
		{
            get
            {
                return this.isDelete;
            }

            set
            {
                this.isDelete = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the CreateDate of SupplierThirdActivitiesEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/6/9 9:58:20
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual DateTime CreateDate
		{
            get
            {
                return this.createDate;
            }

            set
            {
                this.createDate = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the SupplierId of SupplierThirdActivitiesEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/6/9 9:58:20
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual SupplierEntity Supplier
		{
            get
            {
                return this.supplier;
            }

            set
            {
                this.supplier = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the ThirdActivitieId of SupplierThirdActivitiesEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/6/9 9:58:20
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual ThirdActivitiesEntity ThirdActivitie
		{
            get
            {
                return this.thirdActivitie;
            }

            set
            {
                this.thirdActivitie = value;
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
        /// Creation Date:2014/6/9 9:58:20
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public override bool Equals(object obj)
        {
            if (obj == null || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }

            var castObj = (SupplierThirdActivitiesEntity)obj;
            return this.SupplierThirdActivitieId == castObj.SupplierThirdActivitieId;
        }

		/// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        /// Creator:周超
        /// Creation Date:2014/6/9 9:58:20
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public override int GetHashCode()
		{
			var hash = 57; 
			hash = 27 * hash * this.SupplierThirdActivitieId.GetHashCode();
			return hash;
		}
	}
}