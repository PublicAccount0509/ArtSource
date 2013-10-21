// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TransportStationEntity.cs" company="Irdeto">
//   Copyright @ 2013
// </copyright>
// <summary>
//   Class:TransportStationEntity
//   Namespace:Ets.SingleApi.Model.Repository
//   Class Funtion:Represent the class mapping the TransportStationEntity table in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ets.SingleApi.Model.Repository
{
	using System;
	using System.Collections.Generic;
		
    /// <summary>
    /// Class:TransportStationEntity
    /// Namespace:Ets.SingleApi.Model.Repository
    /// Class Funtion:Represent the class mapping the TransportStationEntity table in the database.
    /// </summary>
    /// Creator:周超
    /// Creation Date:2013/10/13 14:18:48
    /// Modifier:
    /// Last Modified:
    /// ----------------------------------------------------------------------------------------
    [Serializable]
    public class TransportStationEntity
    {
		#region private member

			/// <summary>
		/// The TransportStationID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int transportStationId;

			/// <summary>
		/// The TransportStationName
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string transportStationName;

			/// <summary>
		/// The SupplierStationList
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private IList<SupplierStationEntity> supplierStationList;

			/// <summary>
		/// The PublicTransportID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private PublicTransportEntity publicTransport;

		#endregion

		/// <summary>
        /// Initializes a new instance of the <see cref="TransportStationEntity"/> class.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public TransportStationEntity()
        {
			this.transportStationId = 0;
			this.transportStationName = string.Empty;
		}

		#region public member

			/// <summary>
        /// Gets or sets a value mapping the TransportStationID of TransportStationEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int TransportStationId
		{
            get
            {
                return this.transportStationId;
            }

            set
            {
                this.transportStationId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the TransportStationName of TransportStationEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string TransportStationName
		{
            get
            {
                return this.transportStationName;
            }

            set
            {
                this.transportStationName = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the SupplierStationList of TransportStationEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual IList<SupplierStationEntity> SupplierStationList
		{
            get
            {
                return this.supplierStationList;
            }

            set
            {
                this.supplierStationList = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the PublicTransportID of TransportStationEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual PublicTransportEntity PublicTransport
		{
            get
            {
                return this.publicTransport;
            }

            set
            {
                this.publicTransport = value;
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

            var castObj = (TransportStationEntity)obj;
            return this.TransportStationId == castObj.TransportStationId;
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
			hash = 27 * hash * this.TransportStationId.GetHashCode();
			return hash;
		}
	}
}