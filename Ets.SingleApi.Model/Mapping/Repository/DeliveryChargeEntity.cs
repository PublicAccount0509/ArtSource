// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DeliveryChargeEntity.cs" company="Irdeto">
//   Copyright @ 2013
// </copyright>
// <summary>
//   Class:DeliveryChargeEntity
//   Namespace:Ets.SingleApi.Model.Repository
//   Class Funtion:Represent the class mapping the DeliveryChargeEntity table in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ets.SingleApi.Model.Repository
{
	using System;
		
    /// <summary>
    /// Class:DeliveryChargeEntity
    /// Namespace:Ets.SingleApi.Model.Repository
    /// Class Funtion:Represent the class mapping the DeliveryChargeEntity table in the database.
    /// </summary>
    /// Creator:周超
    /// Creation Date:2013/12/19 11:14:45
    /// Modifier:
    /// Last Modified:
    /// ----------------------------------------------------------------------------------------
    [Serializable]
    public class DeliveryChargeEntity
    {
		#region private member

			/// <summary>
		/// The DCChargeID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/19 11:14:46
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int dCChargeId;

			/// <summary>
		/// The SupplierID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/19 11:14:46
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? supplierId;

			/// <summary>
		/// The Miles
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/19 11:14:46
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? miles;

			/// <summary>
		/// The DeliveryCharge
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/19 11:14:46
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private decimal? deliveryCharge;

		#endregion

		/// <summary>
        /// Initializes a new instance of the <see cref="DeliveryChargeEntity"/> class.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/19 11:14:46
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public DeliveryChargeEntity()
        {
			this.dCChargeId = 0;
		}

		#region public member

			/// <summary>
        /// Gets or sets a value mapping the DCChargeID of DeliveryChargeEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/19 11:14:46
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int DCChargeId
		{
            get
            {
                return this.dCChargeId;
            }

            set
            {
                this.dCChargeId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the SupplierID of DeliveryChargeEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/19 11:14:46
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
        /// Gets or sets a value mapping the Miles of DeliveryChargeEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/19 11:14:46
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? Miles
		{
            get
            {
                return this.miles;
            }

            set
            {
                this.miles = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the DeliveryCharge of DeliveryChargeEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/19 11:14:46
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
        /// Creation Date:2013/12/19 11:14:46
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public override bool Equals(object obj)
        {
            if (obj == null || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }

            var castObj = (DeliveryChargeEntity)obj;
            return this.DCChargeId == castObj.DCChargeId;
        }

		/// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        /// Creator:周超
        /// Creation Date:2013/12/19 11:14:46
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public override int GetHashCode()
		{
			var hash = 57; 
			hash = 27 * hash * this.DCChargeId.GetHashCode();
			return hash;
		}
	}
}