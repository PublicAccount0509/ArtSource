// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddrBusinessAreaEntity.cs" company="Irdeto">
//   Copyright @ 2013
// </copyright>
// <summary>
//   Class:AddrBusinessAreaEntity
//   Namespace:Ets.SingleApi.Model.Repository
//   Class Funtion:Represent the class mapping the AddrBusinessAreaEntity table in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ets.SingleApi.Model.Repository
{
	using System;
	using System.Collections.Generic;
		
    /// <summary>
    /// Class:AddrBusinessAreaEntity
    /// Namespace:Ets.SingleApi.Model.Repository
    /// Class Funtion:Represent the class mapping the AddrBusinessAreaEntity table in the database.
    /// </summary>
    /// Creator:周超
    /// Creation Date:2013/10/13 14:01:28
    /// Modifier:
    /// Last Modified:
    /// ----------------------------------------------------------------------------------------
    [Serializable]
    public class AddrBusinessAreaEntity
    {
		#region private member

			/// <summary>
		/// The BusinessAreaID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string businessAreaId;

			/// <summary>
		/// The BusinessAreaName
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string businessAreaName;

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
		/// The BusinessAreaNo
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int businessAreaNo;

			/// <summary>
		/// The RegionCode
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string regionCode;

			/// <summary>
		/// The SupplierBusinessAreaList
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private IList<SupplierBusinessAreaEntity> supplierBusinessAreaList;

			/// <summary>
		/// The CityID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private AddrCityEntity city;

			/// <summary>
		/// The RegionID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private AddrRegionEntity region;

		#endregion

		/// <summary>
        /// Initializes a new instance of the <see cref="AddrBusinessAreaEntity"/> class.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public AddrBusinessAreaEntity()
        {
			this.businessAreaId = string.Empty;
			this.businessAreaName = string.Empty;
			this.longY = string.Empty;
			this.latX = string.Empty;
			this.tags = string.Empty;
			this.businessAreaNo = 0;
			this.regionCode = string.Empty;
		}

		#region public member

			/// <summary>
        /// Gets or sets a value mapping the BusinessAreaID of AddrBusinessAreaEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string BusinessAreaId
		{
            get
            {
                return this.businessAreaId;
            }

            set
            {
                this.businessAreaId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the BusinessAreaName of AddrBusinessAreaEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string BusinessAreaName
		{
            get
            {
                return this.businessAreaName;
            }

            set
            {
                this.businessAreaName = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the LongY of AddrBusinessAreaEntity table in the database.
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
        /// Gets or sets a value mapping the LatX of AddrBusinessAreaEntity table in the database.
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
        /// Gets or sets a value mapping the Hits of AddrBusinessAreaEntity table in the database.
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
        /// Gets or sets a value mapping the Tags of AddrBusinessAreaEntity table in the database.
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
        /// Gets or sets a value mapping the BusinessAreaNo of AddrBusinessAreaEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int BusinessAreaNo
		{
            get
            {
                return this.businessAreaNo;
            }

            set
            {
                this.businessAreaNo = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the RegionCode of AddrBusinessAreaEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string RegionCode
		{
            get
            {
                return this.regionCode;
            }

            set
            {
                this.regionCode = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the SupplierBusinessAreaList of AddrBusinessAreaEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual IList<SupplierBusinessAreaEntity> SupplierBusinessAreaList
		{
            get
            {
                return this.supplierBusinessAreaList;
            }

            set
            {
                this.supplierBusinessAreaList = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the CityID of AddrBusinessAreaEntity table in the database.
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

			/// <summary>
        /// Gets or sets a value mapping the RegionID of AddrBusinessAreaEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual AddrRegionEntity Region
		{
            get
            {
                return this.region;
            }

            set
            {
                this.region = value;
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

            var castObj = (AddrBusinessAreaEntity)obj;
            return this.BusinessAreaId == castObj.BusinessAreaId;
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
			hash = 27 * hash * this.BusinessAreaId.GetHashCode();
			return hash;
		}
	}
}