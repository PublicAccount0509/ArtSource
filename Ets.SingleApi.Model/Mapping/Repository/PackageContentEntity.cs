// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PackageContentEntity.cs" company="Irdeto">
//   Copyright @ 2013
// </copyright>
// <summary>
//   Class:PackageContentEntity
//   Namespace:Ets.SingleApi.Model.Repository
//   Class Funtion:Represent the class mapping the PackageContentEntity table in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ets.SingleApi.Model.Repository
{
	using System;
		
    /// <summary>
    /// Class:PackageContentEntity
    /// Namespace:Ets.SingleApi.Model.Repository
    /// Class Funtion:Represent the class mapping the PackageContentEntity table in the database.
    /// </summary>
    /// Creator:周超
    /// Creation Date:2013/12/17 17:42:39
    /// Modifier:
    /// Last Modified:
    /// ----------------------------------------------------------------------------------------
    [Serializable]
    public class PackageContentEntity
    {
		#region private member

			/// <summary>
		/// The PackageContentID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/17 17:42:39
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int packageContentId;

			/// <summary>
		/// The PackageClassificationID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/17 17:42:39
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int packageClassificationId;

			/// <summary>
		/// The DefaultNum
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/17 17:42:39
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? defaultNum;

			/// <summary>
		/// The SelectNumber
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/17 17:42:39
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? selectNumber;

			/// <summary>
		/// The SupplierID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/17 17:42:39
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private SupplierEntity supplier;

			/// <summary>
		/// The SupplierDishID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/17 17:42:39
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private SupplierDishEntity supplierDish;

		#endregion

		/// <summary>
        /// Initializes a new instance of the <see cref="PackageContentEntity"/> class.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/17 17:42:39
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public PackageContentEntity()
        {
			this.packageContentId = 0;
			this.packageClassificationId = 0;
		}

		#region public member

			/// <summary>
        /// Gets or sets a value mapping the PackageContentID of PackageContentEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/17 17:42:39
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int PackageContentId
		{
            get
            {
                return this.packageContentId;
            }

            set
            {
                this.packageContentId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the PackageClassificationID of PackageContentEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/17 17:42:39
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int PackageClassificationId
		{
            get
            {
                return this.packageClassificationId;
            }

            set
            {
                this.packageClassificationId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the DefaultNum of PackageContentEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/17 17:42:39
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? DefaultNum
		{
            get
            {
                return this.defaultNum;
            }

            set
            {
                this.defaultNum = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the SelectNumber of PackageContentEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/17 17:42:39
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? SelectNumber
		{
            get
            {
                return this.selectNumber;
            }

            set
            {
                this.selectNumber = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the SupplierID of PackageContentEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/17 17:42:39
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
        /// Gets or sets a value mapping the SupplierDishID of PackageContentEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/17 17:42:39
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

            var castObj = (PackageContentEntity)obj;
            return this.PackageContentId == castObj.PackageContentId;
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
			hash = 27 * hash * this.PackageContentId.GetHashCode();
			return hash;
		}
	}
}