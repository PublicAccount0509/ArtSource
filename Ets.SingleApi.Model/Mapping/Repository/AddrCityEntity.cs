// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddrCityEntity.cs" company="Irdeto">
//   Copyright @ 2013
// </copyright>
// <summary>
//   Class:AddrCityEntity
//   Namespace:Ets.SingleApi.Model.Repository
//   Class Funtion:Represent the class mapping the AddrCityEntity table in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ets.SingleApi.Model.Repository
{
	using System;
	using System.Collections.Generic;
		
    /// <summary>
    /// Class:AddrCityEntity
    /// Namespace:Ets.SingleApi.Model.Repository
    /// Class Funtion:Represent the class mapping the AddrCityEntity table in the database.
    /// </summary>
    /// Creator:周超
    /// Creation Date:2013/10/13 14:01:28
    /// Modifier:
    /// Last Modified:
    /// ----------------------------------------------------------------------------------------
    [Serializable]
    public class AddrCityEntity
    {
		#region private member

			/// <summary>
		/// The CityID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string cityId;

			/// <summary>
		/// The CityName
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string cityName;

			/// <summary>
		/// The LongY
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string longY;

			/// <summary>
		/// The LatX
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string latX;

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
		/// The IsActivated
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private bool? isActivated;

			/// <summary>
		/// The Addr_BusinessAreaList
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private IList<AddrBusinessAreaEntity> addrBusinessAreaList;

			/// <summary>
		/// The Addr_RegionList
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private IList<AddrRegionEntity> addrRegionList;

			/// <summary>
		/// The PublicTransportList
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private IList<PublicTransportEntity> publicTransportList;

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
		/// The ProvinceID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private AddrProvinceEntity province;

		#endregion

		/// <summary>
        /// Initializes a new instance of the <see cref="AddrCityEntity"/> class.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public AddrCityEntity()
        {
			this.cityId = string.Empty;
			this.cityName = string.Empty;
			this.longY = string.Empty;
			this.latX = string.Empty;
			this.tags = string.Empty;
		}

		#region public member

			/// <summary>
        /// Gets or sets a value mapping the CityID of AddrCityEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string CityId
		{
            get
            {
                return this.cityId;
            }

            set
            {
                this.cityId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the CityName of AddrCityEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string CityName
		{
            get
            {
                return this.cityName;
            }

            set
            {
                this.cityName = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the LongY of AddrCityEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string LongY
		{
            get
            {
                return this.longY;
            }

            set
            {
                this.longY = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the LatX of AddrCityEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string LatX
		{
            get
            {
                return this.latX;
            }

            set
            {
                this.latX = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Hits of AddrCityEntity table in the database.
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
        /// Gets or sets a value mapping the Tags of AddrCityEntity table in the database.
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
        /// Gets or sets a value indicating whether mapping the IsActivated of AddrCityEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual bool? IsActivated
		{
            get
            {
                return this.isActivated;
            }

            set
            {
                this.isActivated = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Addr_BusinessAreaList of AddrCityEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual IList<AddrBusinessAreaEntity> AddrBusinessAreaList
		{
            get
            {
                return this.addrBusinessAreaList;
            }

            set
            {
                this.addrBusinessAreaList = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Addr_RegionList of AddrCityEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual IList<AddrRegionEntity> AddrRegionList
		{
            get
            {
                return this.addrRegionList;
            }

            set
            {
                this.addrRegionList = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the PublicTransportList of AddrCityEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual IList<PublicTransportEntity> PublicTransportList
		{
            get
            {
                return this.publicTransportList;
            }

            set
            {
                this.publicTransportList = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the SupplierList of AddrCityEntity table in the database.
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
        /// Gets or sets a value mapping the ProvinceID of AddrCityEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual AddrProvinceEntity Province
		{
            get
            {
                return this.province;
            }

            set
            {
                this.province = value;
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

            var castObj = (AddrCityEntity)obj;
            return this.CityId == castObj.CityId;
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
			hash = 27 * hash * this.CityId.GetHashCode();
			return hash;
		}
	}
}