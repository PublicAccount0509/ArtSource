// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddrRegionEntity.cs" company="Irdeto">
//   Copyright @ 2013
// </copyright>
// <summary>
//   Class:AddrRegionEntity
//   Namespace:Ets.SingleApi.Model.Repository
//   Class Funtion:Represent the class mapping the AddrRegionEntity table in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ets.SingleApi.Model.Repository
{
	using System;
	using System.Collections.Generic;
		
    /// <summary>
    /// Class:AddrRegionEntity
    /// Namespace:Ets.SingleApi.Model.Repository
    /// Class Funtion:Represent the class mapping the AddrRegionEntity table in the database.
    /// </summary>
    /// Creator:周超
    /// Creation Date:2013/10/13 14:01:28
    /// Modifier:
    /// Last Modified:
    /// ----------------------------------------------------------------------------------------
    [Serializable]
    public class AddrRegionEntity
    {
		#region private member

			/// <summary>
		/// The RegionID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string regionId;

			/// <summary>
		/// The RegionName
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string regionName;

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
		/// The RegionNo
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int regionNo;

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
		/// The SupplierList
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private IList<SupplierEntity> supplierList;

			/// <summary>
		/// The CityID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private AddrCityEntity city;

		#endregion

		/// <summary>
        /// Initializes a new instance of the <see cref="AddrRegionEntity"/> class.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public AddrRegionEntity()
        {
			this.regionId = string.Empty;
			this.regionName = string.Empty;
			this.tags = string.Empty;
			this.regionNo = 0;
		}

		#region public member

			/// <summary>
        /// Gets or sets a value mapping the RegionID of AddrRegionEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string RegionId
		{
            get
            {
                return this.regionId;
            }

            set
            {
                this.regionId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the RegionName of AddrRegionEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string RegionName
		{
            get
            {
                return this.regionName;
            }

            set
            {
                this.regionName = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Hits of AddrRegionEntity table in the database.
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
        /// Gets or sets a value mapping the Tags of AddrRegionEntity table in the database.
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
        /// Gets or sets a value mapping the RegionNo of AddrRegionEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int RegionNo
		{
            get
            {
                return this.regionNo;
            }

            set
            {
                this.regionNo = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Addr_BusinessAreaList of AddrRegionEntity table in the database.
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
        /// Gets or sets a value mapping the SupplierList of AddrRegionEntity table in the database.
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
        /// Gets or sets a value mapping the CityID of AddrRegionEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual AddrCityEntity City
		{
            get
            {
                return this.city;
            }

            set
            {
                this.city = value;
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

            var castObj = (AddrRegionEntity)obj;
            return this.RegionId == castObj.RegionId;
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
			hash = 27 * hash * this.RegionId.GetHashCode();
			return hash;
		}
	}
}