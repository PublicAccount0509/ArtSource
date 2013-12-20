// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SupplierGroupLogoImageEntity.cs" company="Irdeto">
//   Copyright @ 2013
// </copyright>
// <summary>
//   Class:SupplierGroupLogoImageEntity
//   Namespace:Ets.SingleApi.Model.Repository
//   Class Funtion:Represent the class mapping the SupplierGroupLogoImageEntity table in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ets.SingleApi.Model.Repository
{
	using System;
		
    /// <summary>
    /// Class:SupplierGroupLogoImageEntity
    /// Namespace:Ets.SingleApi.Model.Repository
    /// Class Funtion:Represent the class mapping the SupplierGroupLogoImageEntity table in the database.
    /// </summary>
    /// Creator:周超
    /// Creation Date:2013/12/20 11:17:33
    /// Modifier:
    /// Last Modified:
    /// ----------------------------------------------------------------------------------------
    [Serializable]
    public class SupplierGroupLogoImageEntity
    {
		#region private member

			/// <summary>
		/// The LogoImageId
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/20 11:17:33
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int logoImageId;

			/// <summary>
		/// The ImagePath
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/20 11:17:33
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string imagePath;

			/// <summary>
		/// The IsDelete
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/20 11:17:33
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private bool isDelete;

			/// <summary>
		/// The Width
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/20 11:17:33
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? wIdth;

			/// <summary>
		/// The Height
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/20 11:17:33
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? height;

			/// <summary>
		/// The CreateDate
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/20 11:17:33
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private DateTime createDate;

			/// <summary>
		/// The SupplierGroupLightId
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/20 11:17:33
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private SupplierGroupLightEntity supplierGroupLight;

		#endregion

		/// <summary>
        /// Initializes a new instance of the <see cref="SupplierGroupLogoImageEntity"/> class.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/20 11:17:33
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public SupplierGroupLogoImageEntity()
        {
			this.logoImageId = 0;
			this.imagePath = string.Empty;
			this.isDelete = false;
			this.createDate = DateTime.Now;
		}

		#region public member

			/// <summary>
        /// Gets or sets a value mapping the LogoImageId of SupplierGroupLogoImageEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/20 11:17:33
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int LogoImageId
		{
            get
            {
                return this.logoImageId;
            }

            set
            {
                this.logoImageId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the ImagePath of SupplierGroupLogoImageEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/20 11:17:33
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string ImagePath
		{
            get
            {
                return this.imagePath;
            }

            set
            {
                this.imagePath = value;
            }
        }

			/// <summary>
        /// Gets or sets a value indicating whether mapping the IsDelete of SupplierGroupLogoImageEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/20 11:17:33
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
        /// Gets or sets a value mapping the Width of SupplierGroupLogoImageEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/20 11:17:33
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? WIdth
		{
            get
            {
                return this.wIdth;
            }

            set
            {
                this.wIdth = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Height of SupplierGroupLogoImageEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/20 11:17:33
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? Height
		{
            get
            {
                return this.height;
            }

            set
            {
                this.height = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the CreateDate of SupplierGroupLogoImageEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/20 11:17:33
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
        /// Gets or sets a value mapping the SupplierGroupLightId of SupplierGroupLogoImageEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/20 11:17:33
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual SupplierGroupLightEntity SupplierGroupLight
		{
            get
            {
                return this.supplierGroupLight;
            }

            set
            {
                this.supplierGroupLight = value;
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
        /// Creation Date:2013/12/20 11:17:33
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public override bool Equals(object obj)
        {
            if (obj == null || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }

            var castObj = (SupplierGroupLogoImageEntity)obj;
            return this.LogoImageId == castObj.LogoImageId;
        }

		/// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        /// Creator:周超
        /// Creation Date:2013/12/20 11:17:33
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public override int GetHashCode()
		{
			var hash = 57; 
			hash = 27 * hash * this.LogoImageId.GetHashCode();
			return hash;
		}
	}
}