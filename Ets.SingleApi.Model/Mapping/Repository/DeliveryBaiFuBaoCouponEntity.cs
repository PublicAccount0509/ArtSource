// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DeliveryBaiFuBaoCouponEntity.cs" company="Irdeto">
//   Copyright @ 2014
// </copyright>
// <summary>
//   Class:DeliveryBaiFuBaoCouponEntity
//   Namespace:Ets.SingleApi.Model.Repository
//   Class Funtion:Represent the class mapping the DeliveryBaiFuBaoCouponEntity table in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ets.SingleApi.Model.Repository
{
	using System;
		
    /// <summary>
    /// Class:DeliveryBaiFuBaoCouponEntity
    /// Namespace:Ets.SingleApi.Model.Repository
    /// Class Funtion:Represent the class mapping the DeliveryBaiFuBaoCouponEntity table in the database.
    /// </summary>
    /// Creator:ww
    /// Creation Date:2014/6/26 8:50:55
    /// Modifier:
    /// Last Modified:
    /// ----------------------------------------------------------------------------------------
    [Serializable]
    public class DeliveryBaiFuBaoCouponEntity
    {
		#region private member

			/// <summary>
		/// The DeliveryId
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/6/26 8:50:56
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int deliveryId;

			/// <summary>
		/// The PaidAmount
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/6/26 8:50:56
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string paIdAmount;

			/// <summary>
		/// The Coupons
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/6/26 8:50:56
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string coupons;

			/// <summary>
		/// The Promotion
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/6/26 8:50:56
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string promotion;

		#endregion

		/// <summary>
        /// Initializes a new instance of the <see cref="DeliveryBaiFuBaoCouponEntity"/> class.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/6/26 8:50:56
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public DeliveryBaiFuBaoCouponEntity()
        {
			this.deliveryId = 0;
			this.paIdAmount = string.Empty;
			this.coupons = string.Empty;
			this.promotion = string.Empty;
		}

		#region public member

			/// <summary>
        /// Gets or sets a value mapping the DeliveryId of DeliveryBaiFuBaoCouponEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/6/26 8:50:56
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
        /// Gets or sets a value mapping the PaidAmount of DeliveryBaiFuBaoCouponEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/6/26 8:50:56
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string PaIdAmount
		{
            get
            {
                return this.paIdAmount;
            }

            set
            {
                this.paIdAmount = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Coupons of DeliveryBaiFuBaoCouponEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/6/26 8:50:56
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string Coupons
		{
            get
            {
                return this.coupons;
            }

            set
            {
                this.coupons = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Promotion of DeliveryBaiFuBaoCouponEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/6/26 8:50:56
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string Promotion
		{
            get
            {
                return this.promotion;
            }

            set
            {
                this.promotion = value;
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
        /// Creator:ww
        /// Creation Date:2014/6/26 8:50:56
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public override bool Equals(object obj)
        {
            if (obj == null || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }

            var castObj = (DeliveryBaiFuBaoCouponEntity)obj;
            return this.DeliveryId == castObj.DeliveryId;
        }

		/// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        /// Creator:ww
        /// Creation Date:2014/6/26 8:50:56
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