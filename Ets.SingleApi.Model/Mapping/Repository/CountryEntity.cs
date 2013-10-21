// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CountryEntity.cs" company="Irdeto">
//   Copyright @ 2013
// </copyright>
// <summary>
//   Class:CountryEntity
//   Namespace:Ets.SingleApi.Model.Repository
//   Class Funtion:Represent the class mapping the CountryEntity table in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ets.SingleApi.Model.Repository
{
	using System;
	using System.Collections.Generic;
		
    /// <summary>
    /// Class:CountryEntity
    /// Namespace:Ets.SingleApi.Model.Repository
    /// Class Funtion:Represent the class mapping the CountryEntity table in the database.
    /// </summary>
    /// Creator:周超
    /// Creation Date:2013/10/13 14:01:28
    /// Modifier:
    /// Last Modified:
    /// ----------------------------------------------------------------------------------------
    [Serializable]
    public class CountryEntity
    {
		#region private member

			/// <summary>
		/// The CountryID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int countryId;

			/// <summary>
		/// The CountryName
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string countryName;

			/// <summary>
		/// The Addr_ProvinceList
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private IList<AddrProvinceEntity> addrProvinceList;

		#endregion

		/// <summary>
        /// Initializes a new instance of the <see cref="CountryEntity"/> class.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public CountryEntity()
        {
			this.countryId = 0;
			this.countryName = string.Empty;
		}

		#region public member

			/// <summary>
        /// Gets or sets a value mapping the CountryID of CountryEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int CountryId
		{
            get
            {
                return this.countryId;
            }

            set
            {
                this.countryId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the CountryName of CountryEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string CountryName
		{
            get
            {
                return this.countryName;
            }

            set
            {
                this.countryName = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Addr_ProvinceList of CountryEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual IList<AddrProvinceEntity> AddrProvinceList
		{
            get
            {
                return this.addrProvinceList;
            }

            set
            {
                this.addrProvinceList = value;
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

            var castObj = (CountryEntity)obj;
            return this.CountryId == castObj.CountryId;
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
			hash = 27 * hash * this.CountryId.GetHashCode();
			return hash;
		}
	}
}