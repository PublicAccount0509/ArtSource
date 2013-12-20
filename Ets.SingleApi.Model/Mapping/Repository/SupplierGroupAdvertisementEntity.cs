// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SupplierGroupAdvertisementEntity.cs" company="Irdeto">
//   Copyright @ 2013
// </copyright>
// <summary>
//   Class:SupplierGroupAdvertisementEntity
//   Namespace:Ets.SingleApi.Model.Repository
//   Class Funtion:Represent the class mapping the SupplierGroupAdvertisementEntity table in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ets.SingleApi.Model.Repository
{
	using System;
		
    /// <summary>
    /// Class:SupplierGroupAdvertisementEntity
    /// Namespace:Ets.SingleApi.Model.Repository
    /// Class Funtion:Represent the class mapping the SupplierGroupAdvertisementEntity table in the database.
    /// </summary>
    /// Creator:周超
    /// Creation Date:2013/12/20 11:17:32
    /// Modifier:
    /// Last Modified:
    /// ----------------------------------------------------------------------------------------
    [Serializable]
    public class SupplierGroupAdvertisementEntity
    {
		#region private member

			/// <summary>
		/// The AdvertisementId
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/20 11:17:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int advertisementId;

			/// <summary>
		/// The ImagePath
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/20 11:17:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string imagePath;

			/// <summary>
		/// The Width
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/20 11:17:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? wIdth;

			/// <summary>
		/// The Height
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/20 11:17:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? height;

			/// <summary>
		/// The IsDetele
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/20 11:17:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private bool isDetele;

			/// <summary>
		/// The CreateDate
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/20 11:17:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private DateTime createDate;

			/// <summary>
		/// The SupplierGroupLightId
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/20 11:17:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private SupplierGroupLightEntity supplierGroupLight;

		#endregion

		/// <summary>
        /// Initializes a new instance of the <see cref="SupplierGroupAdvertisementEntity"/> class.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/20 11:17:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public SupplierGroupAdvertisementEntity()
        {
			this.advertisementId = 0;
			this.imagePath = string.Empty;
			this.isDetele = false;
			this.createDate = DateTime.Now;
		}

		#region public member

			/// <summary>
        /// Gets or sets a value mapping the AdvertisementId of SupplierGroupAdvertisementEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/20 11:17:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int AdvertisementId
		{
            get
            {
                return this.advertisementId;
            }

            set
            {
                this.advertisementId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the ImagePath of SupplierGroupAdvertisementEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/20 11:17:32
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
        /// Gets or sets a value mapping the Width of SupplierGroupAdvertisementEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/20 11:17:32
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
        /// Gets or sets a value mapping the Height of SupplierGroupAdvertisementEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/20 11:17:32
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
        /// Gets or sets a value indicating whether mapping the IsDetele of SupplierGroupAdvertisementEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/20 11:17:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual bool IsDetele
		{
            get
            {
                return this.isDetele;
            }

            set
            {
                this.isDetele = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the CreateDate of SupplierGroupAdvertisementEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/20 11:17:32
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
        /// Gets or sets a value mapping the SupplierGroupLightId of SupplierGroupAdvertisementEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/20 11:17:32
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
        /// Creation Date:2013/12/20 11:17:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public override bool Equals(object obj)
        {
            if (obj == null || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }

            var castObj = (SupplierGroupAdvertisementEntity)obj;
            return this.AdvertisementId == castObj.AdvertisementId;
        }

		/// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        /// Creator:周超
        /// Creation Date:2013/12/20 11:17:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public override int GetHashCode()
		{
			var hash = 57; 
			hash = 27 * hash * this.AdvertisementId.GetHashCode();
			return hash;
		}
	}
}