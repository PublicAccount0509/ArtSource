// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PackageClassificationEntity.cs" company="Irdeto">
//   Copyright @ 2013
// </copyright>
// <summary>
//   Class:PackageClassificationEntity
//   Namespace:Ets.SingleApi.Model.Repository
//   Class Funtion:Represent the class mapping the PackageClassificationEntity table in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ets.SingleApi.Model.Repository
{
	using System;
		
    /// <summary>
    /// Class:PackageClassificationEntity
    /// Namespace:Ets.SingleApi.Model.Repository
    /// Class Funtion:Represent the class mapping the PackageClassificationEntity table in the database.
    /// </summary>
    /// Creator:周超
    /// Creation Date:2013/12/17 17:42:38
    /// Modifier:
    /// Last Modified:
    /// ----------------------------------------------------------------------------------------
    [Serializable]
    public class PackageClassificationEntity
    {
		#region private member

			/// <summary>
		/// The PackageClassificationID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/17 17:42:38
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int packageClassificationId;

			/// <summary>
		/// The SupplierID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/17 17:42:38
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? supplierId;

			/// <summary>
		/// The ClassificationName
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/17 17:42:38
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string classificationName;

			/// <summary>
		/// The ClassificationNum
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/17 17:42:38
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? classificationNum;

			/// <summary>
		/// The PackageID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/17 17:42:38
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? packageId;

			/// <summary>
		/// The isChoose
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/17 17:42:38
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? isChoose;

			/// <summary>
		/// The CategoryID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/17 17:42:38
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? categoryId;

			/// <summary>
		/// The IsEnabled
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/17 17:42:38
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private bool? isEnabled;

		#endregion

		/// <summary>
        /// Initializes a new instance of the <see cref="PackageClassificationEntity"/> class.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/17 17:42:38
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public PackageClassificationEntity()
        {
			this.packageClassificationId = 0;
			this.classificationName = string.Empty;
		}

		#region public member

			/// <summary>
        /// Gets or sets a value mapping the PackageClassificationID of PackageClassificationEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/17 17:42:38
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
        /// Gets or sets a value mapping the SupplierID of PackageClassificationEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/17 17:42:38
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? SupplierId
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
        /// Gets or sets a value mapping the ClassificationName of PackageClassificationEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/17 17:42:38
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string ClassificationName
		{
            get
            {
                return this.classificationName;
            }

            set
            {
                this.classificationName = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the ClassificationNum of PackageClassificationEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/17 17:42:38
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? ClassificationNum
		{
            get
            {
                return this.classificationNum;
            }

            set
            {
                this.classificationNum = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the PackageID of PackageClassificationEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/17 17:42:38
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? PackageId
		{
            get
            {
                return this.packageId;
            }

            set
            {
                this.packageId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the isChoose of PackageClassificationEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/17 17:42:38
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? IsChoose
		{
            get
            {
                return this.isChoose;
            }

            set
            {
                this.isChoose = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the CategoryID of PackageClassificationEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/17 17:42:38
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? CategoryId
		{
            get
            {
                return this.categoryId;
            }

            set
            {
                this.categoryId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value indicating whether mapping the IsEnabled of PackageClassificationEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/17 17:42:38
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual bool? IsEnabled
		{
            get
            {
                return this.isEnabled;
            }

            set
            {
                this.isEnabled = value;
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
        /// Creation Date:2013/12/17 17:42:38
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public override bool Equals(object obj)
        {
            if (obj == null || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }

            var castObj = (PackageClassificationEntity)obj;
            return this.PackageClassificationId == castObj.PackageClassificationId;
        }

		/// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        /// Creator:周超
        /// Creation Date:2013/12/17 17:42:38
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public override int GetHashCode()
		{
			var hash = 57; 
			hash = 27 * hash * this.PackageClassificationId.GetHashCode();
			return hash;
		}
	}
}