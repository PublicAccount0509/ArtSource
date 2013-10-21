// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PublicTransportEntity.cs" company="Irdeto">
//   Copyright @ 2013
// </copyright>
// <summary>
//   Class:PublicTransportEntity
//   Namespace:Ets.SingleApi.Model.Repository
//   Class Funtion:Represent the class mapping the PublicTransportEntity table in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ets.SingleApi.Model.Repository
{
	using System;
	using System.Collections.Generic;
		
    /// <summary>
    /// Class:PublicTransportEntity
    /// Namespace:Ets.SingleApi.Model.Repository
    /// Class Funtion:Represent the class mapping the PublicTransportEntity table in the database.
    /// </summary>
    /// Creator:周超
    /// Creation Date:2013/10/13 14:18:48
    /// Modifier:
    /// Last Modified:
    /// ----------------------------------------------------------------------------------------
    [Serializable]
    public class PublicTransportEntity
    {
		#region private member

			/// <summary>
		/// The PublicTransportID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int publicTransportId;

			/// <summary>
		/// The PublicTransportName
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string publicTransportName;

			/// <summary>
		/// The PublicTransportType
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string publicTransportType;

			/// <summary>
		/// The SupplierTransportList
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private IList<SupplierTransportEntity> supplierTransportList;

			/// <summary>
		/// The TransportStationList
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private IList<TransportStationEntity> transportStationList;

			/// <summary>
		/// The CityID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private AddrCityEntity city;

		#endregion

		/// <summary>
        /// Initializes a new instance of the <see cref="PublicTransportEntity"/> class.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public PublicTransportEntity()
        {
			this.publicTransportId = 0;
			this.publicTransportName = string.Empty;
			this.publicTransportType = string.Empty;
		}

		#region public member

			/// <summary>
        /// Gets or sets a value mapping the PublicTransportID of PublicTransportEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int PublicTransportId
		{
            get
            {
                return this.publicTransportId;
            }

            set
            {
                this.publicTransportId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the PublicTransportName of PublicTransportEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string PublicTransportName
		{
            get
            {
                return this.publicTransportName;
            }

            set
            {
                this.publicTransportName = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the PublicTransportType of PublicTransportEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string PublicTransportType
		{
            get
            {
                return this.publicTransportType;
            }

            set
            {
                this.publicTransportType = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the SupplierTransportList of PublicTransportEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual IList<SupplierTransportEntity> SupplierTransportList
		{
            get
            {
                return this.supplierTransportList;
            }

            set
            {
                this.supplierTransportList = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the TransportStationList of PublicTransportEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual IList<TransportStationEntity> TransportStationList
		{
            get
            {
                return this.transportStationList;
            }

            set
            {
                this.transportStationList = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the CityID of PublicTransportEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
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
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public override bool Equals(object obj)
        {
            if (obj == null || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }

            var castObj = (PublicTransportEntity)obj;
            return this.PublicTransportId == castObj.PublicTransportId;
        }

		/// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public override int GetHashCode()
		{
			var hash = 57; 
			hash = 27 * hash * this.PublicTransportId.GetHashCode();
			return hash;
		}
	}
}