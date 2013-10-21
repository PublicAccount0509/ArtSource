// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LocationTypeEntity.cs" company="Irdeto">
//   Copyright @ 2013
// </copyright>
// <summary>
//   Class:LocationTypeEntity
//   Namespace:Ets.SingleApi.Model.Repository
//   Class Funtion:Represent the class mapping the LocationTypeEntity table in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ets.SingleApi.Model.Repository
{
	using System;
	using System.Collections.Generic;
		
    /// <summary>
    /// Class:LocationTypeEntity
    /// Namespace:Ets.SingleApi.Model.Repository
    /// Class Funtion:Represent the class mapping the LocationTypeEntity table in the database.
    /// </summary>
    /// Creator:周超
    /// Creation Date:2013/10/13 14:23:32
    /// Modifier:
    /// Last Modified:
    /// ----------------------------------------------------------------------------------------
    [Serializable]
    public class LocationTypeEntity
    {
		#region private member

			/// <summary>
		/// The LocationTypeID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:23:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int locationTypeId;

			/// <summary>
		/// The LocationType
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:23:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string locationType;

			/// <summary>
		/// The LocationList
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:23:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private IList<LocationEntity> locationList;

		#endregion

		/// <summary>
        /// Initializes a new instance of the <see cref="LocationTypeEntity"/> class.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:23:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public LocationTypeEntity()
        {
			this.locationTypeId = 0;
			this.locationType = string.Empty;
		}

		#region public member

			/// <summary>
        /// Gets or sets a value mapping the LocationTypeID of LocationTypeEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:23:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int LocationTypeId
		{
            get
            {
                return this.locationTypeId;
            }

            set
            {
                this.locationTypeId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the LocationType of LocationTypeEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:23:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string LocationType
		{
            get
            {
                return this.locationType;
            }

            set
            {
                this.locationType = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the LocationList of LocationTypeEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:23:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual IList<LocationEntity> LocationList
		{
            get
            {
                return this.locationList;
            }

            set
            {
                this.locationList = value;
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
        /// Creation Date:2013/10/13 14:23:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public override bool Equals(object obj)
        {
            if (obj == null || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }

            var castObj = (LocationTypeEntity)obj;
            return this.LocationTypeId == castObj.LocationTypeId;
        }

		/// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:23:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public override int GetHashCode()
		{
			var hash = 57; 
			hash = 27 * hash * this.LocationTypeId.GetHashCode();
			return hash;
		}
	}
}