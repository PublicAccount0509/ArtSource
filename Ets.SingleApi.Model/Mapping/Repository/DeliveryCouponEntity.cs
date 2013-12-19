// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DeliveryCouponEntity.cs" company="Irdeto">
//   Copyright @ 2013
// </copyright>
// <summary>
//   Class:DeliveryCouponEntity
//   Namespace:Ets.SingleApi.Model.Repository
//   Class Funtion:Represent the class mapping the DeliveryCouponEntity table in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ets.SingleApi.Model.Repository
{
	using System;
		
    /// <summary>
    /// Class:DeliveryCouponEntity
    /// Namespace:Ets.SingleApi.Model.Repository
    /// Class Funtion:Represent the class mapping the DeliveryCouponEntity table in the database.
    /// </summary>
    /// Creator:周超
    /// Creation Date:2013/12/19 11:14:47
    /// Modifier:
    /// Last Modified:
    /// ----------------------------------------------------------------------------------------
    [Serializable]
    public class DeliveryCouponEntity
    {
		#region private member

			/// <summary>
		/// The DeliveryId
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/19 11:14:47
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int deliveryId;

			/// <summary>
		/// The UseCoupon
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/19 11:14:47
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string useCoupon;

			/// <summary>
		/// The RealCoupon
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/19 11:14:47
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string realCoupon;

		#endregion

		/// <summary>
        /// Initializes a new instance of the <see cref="DeliveryCouponEntity"/> class.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/19 11:14:47
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public DeliveryCouponEntity()
        {
			this.deliveryId = 0;
			this.useCoupon = string.Empty;
			this.realCoupon = string.Empty;
		}

		#region public member

			/// <summary>
        /// Gets or sets a value mapping the DeliveryId of DeliveryCouponEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/19 11:14:47
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int DeliveryId
		{
            get
            {
                return this.deliveryId;
            }

            set
            {
                this.deliveryId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the UseCoupon of DeliveryCouponEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/19 11:14:47
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string UseCoupon
		{
            get
            {
                return this.useCoupon;
            }

            set
            {
                this.useCoupon = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the RealCoupon of DeliveryCouponEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/19 11:14:47
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string RealCoupon
		{
            get
            {
                return this.realCoupon;
            }

            set
            {
                this.realCoupon = value;
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

            var castObj = (DeliveryCouponEntity)obj;
            return this.DeliveryId == castObj.DeliveryId;
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
			hash = 27 * hash * this.DeliveryId.GetHashCode();
			return hash;
		}
	}
}