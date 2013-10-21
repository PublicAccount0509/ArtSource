// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddrProvinceEntity.cs" company="Irdeto">
//   Copyright @ 2013
// </copyright>
// <summary>
//   Class:AddrProvinceEntity
//   Namespace:Ets.SingleApi.Model.Repository
//   Class Funtion:Represent the class mapping the AddrProvinceEntity table in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ets.SingleApi.Model.Repository
{
	using System;
	using System.Collections.Generic;
		
    /// <summary>
    /// Class:AddrProvinceEntity
    /// Namespace:Ets.SingleApi.Model.Repository
    /// Class Funtion:Represent the class mapping the AddrProvinceEntity table in the database.
    /// </summary>
    /// Creator:周超
    /// Creation Date:2013/10/13 14:01:28
    /// Modifier:
    /// Last Modified:
    /// ----------------------------------------------------------------------------------------
    [Serializable]
    public class AddrProvinceEntity
    {
		#region private member

			/// <summary>
		/// The ProvinceID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string provinceId;

			/// <summary>
		/// The ProvinceName
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string provinceName;

			/// <summary>
		/// The Hits
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private long? hits;

			/// <summary>
		/// The Tags
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string tags;

			/// <summary>
		/// The Addr_CityList
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private IList<AddrCityEntity> addrCityList;

			/// <summary>
		/// The SupplierList
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private IList<SupplierEntity> supplierList;

			/// <summary>
		/// The CountryID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private CountryEntity country;

		#endregion

		/// <summary>
        /// Initializes a new instance of the <see cref="AddrProvinceEntity"/> class.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public AddrProvinceEntity()
        {
			this.provinceId = string.Empty;
			this.provinceName = string.Empty;
			this.tags = string.Empty;
		}

		#region public member

			/// <summary>
        /// Gets or sets a value mapping the ProvinceID of AddrProvinceEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string ProvinceId
		{
            get
            {
                return this.provinceId;
            }

            set
            {
                this.provinceId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the ProvinceName of AddrProvinceEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string ProvinceName
		{
            get
            {
                return this.provinceName;
            }

            set
            {
                this.provinceName = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Hits of AddrProvinceEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual long? Hits
		{
            get
            {
                return this.hits;
            }

            set
            {
                this.hits = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Tags of AddrProvinceEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string Tags
		{
            get
            {
                return this.tags;
            }

            set
            {
                this.tags = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Addr_CityList of AddrProvinceEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual IList<AddrCityEntity> AddrCityList
		{
            get
            {
                return this.addrCityList;
            }

            set
            {
                this.addrCityList = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the SupplierList of AddrProvinceEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual IList<SupplierEntity> SupplierList
		{
            get
            {
                return this.supplierList;
            }

            set
            {
                this.supplierList = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the CountryID of AddrProvinceEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual CountryEntity Country
		{
            get
            {
                return this.country;
            }

            set
            {
                this.country = value;
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
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public override bool Equals(object obj)
        {
            if (obj == null || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }

            var castObj = (AddrProvinceEntity)obj;
            return this.ProvinceId == castObj.ProvinceId;
        }

		/// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public override int GetHashCode()
		{
			var hash = 57; 
			hash = 27 * hash * this.ProvinceId.GetHashCode();
			return hash;
		}
	}
}