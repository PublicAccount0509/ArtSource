// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DeliveryChargeForExtraMilesEntity.cs" company="Irdeto">
//   Copyright @ 2013
// </copyright>
// <summary>
//   Class:DeliveryChargeForExtraMilesEntity
//   Namespace:Ets.SingleApi.Model.Repository
//   Class Funtion:Represent the class mapping the DeliveryChargeForExtraMilesEntity table in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ets.SingleApi.Model.Repository
{
	using System;
		
    /// <summary>
    /// Class:DeliveryChargeForExtraMilesEntity
    /// Namespace:Ets.SingleApi.Model.Repository
    /// Class Funtion:Represent the class mapping the DeliveryChargeForExtraMilesEntity table in the database.
    /// </summary>
    /// Creator:周超
    /// Creation Date:2013/12/19 11:14:46
    /// Modifier:
    /// Last Modified:
    /// ----------------------------------------------------------------------------------------
    [Serializable]
    public class DeliveryChargeForExtraMilesEntity
    {
		#region private member

			/// <summary>
		/// The DCMChargeID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/19 11:14:47
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int dCMChargeId;

			/// <summary>
		/// The SupplierID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/19 11:14:47
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? supplierId;

			/// <summary>
		/// The ExtraMiles
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/19 11:14:47
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? extraMiles;

			/// <summary>
		/// The DeliveryCharge
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/19 11:14:47
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private decimal? deliveryCharge;

		#endregion

		/// <summary>
        /// Initializes a new instance of the <see cref="DeliveryChargeForExtraMilesEntity"/> class.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/19 11:14:47
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public DeliveryChargeForExtraMilesEntity()
        {
			this.dCMChargeId = 0;
		}

		#region public member

			/// <summary>
        /// Gets or sets a value mapping the DCMChargeID of DeliveryChargeForExtraMilesEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/19 11:14:47
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int DCMChargeId
		{
            get
            {
                return this.dCMChargeId;
            }

            set
            {
                this.dCMChargeId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the SupplierID of DeliveryChargeForExtraMilesEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/19 11:14:47
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? SupplierId
		{
            get
            {
                return this.supplierId;
            }

            set
            {
                this.supplierId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the ExtraMiles of DeliveryChargeForExtraMilesEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/19 11:14:47
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? ExtraMiles
		{
            get
            {
                return this.extraMiles;
            }

            set
            {
                this.extraMiles = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the DeliveryCharge of DeliveryChargeForExtraMilesEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/19 11:14:47
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual decimal? DeliveryCharge
		{
            get
            {
                return this.deliveryCharge;
            }

            set
            {
                this.deliveryCharge = value;
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
        /// Creation Date:2013/12/19 11:14:47
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public override bool Equals(object obj)
        {
            if (obj == null || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }

            var castObj = (DeliveryChargeForExtraMilesEntity)obj;
            return this.DCMChargeId == castObj.DCMChargeId;
        }

		/// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        /// Creator:周超
        /// Creation Date:2013/12/19 11:14:47
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public override int GetHashCode()
		{
			var hash = 57; 
			hash = 27 * hash * this.DCMChargeId.GetHashCode();
			return hash;
		}
	}
}