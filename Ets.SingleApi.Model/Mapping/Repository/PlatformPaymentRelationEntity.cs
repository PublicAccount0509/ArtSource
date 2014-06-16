// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PlatformPaymentRelationEntity.cs" company="Irdeto">
//   Copyright @ 2014
// </copyright>
// <summary>
//   Class:PlatformPaymentRelationEntity
//   Namespace:Ets.SingleApi.Model.Repository
//   Class Funtion:Represent the class mapping the PlatformPaymentRelationEntity table in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ets.SingleApi.Model.Repository
{
	using System;
		
    /// <summary>
    /// Class:PlatformPaymentRelationEntity
    /// Namespace:Ets.SingleApi.Model.Repository
    /// Class Funtion:Represent the class mapping the PlatformPaymentRelationEntity table in the database.
    /// </summary>
    /// Creator:ww
    /// Creation Date:2014/6/16 12:26:50
    /// Modifier:
    /// Last Modified:
    /// ----------------------------------------------------------------------------------------
    [Serializable]
    public class PlatformPaymentRelationEntity
    {
		#region private member

			/// <summary>
		/// The id
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/6/16 12:26:50
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int id;

			/// <summary>
		/// The PlatformId
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/6/16 12:26:50
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? platformId;

			/// <summary>
		/// The PaymentMethodId
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/6/16 12:26:50
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? paymentMethodId;

		#endregion

		/// <summary>
        /// Initializes a new instance of the <see cref="PlatformPaymentRelationEntity"/> class.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/6/16 12:26:50
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public PlatformPaymentRelationEntity()
        {
			this.id = 0;
		}

		#region public member

			/// <summary>
        /// Gets or sets a value mapping the id of PlatformPaymentRelationEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/6/16 12:26:50
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int Id
		{
            get
            {
                return this.id;
            }

            set
            {
                this.id = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the PlatformId of PlatformPaymentRelationEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/6/16 12:26:50
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? PlatformId
		{
            get
            {
                return this.platformId;
            }

            set
            {
                this.platformId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the PaymentMethodId of PlatformPaymentRelationEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/6/16 12:26:50
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? PaymentMethodId
		{
            get
            {
                return this.paymentMethodId;
            }

            set
            {
                this.paymentMethodId = value;
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
        /// Creation Date:2014/6/16 12:26:50
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public override bool Equals(object obj)
        {
            if (obj == null || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }

            var castObj = (PlatformPaymentRelationEntity)obj;
            return this.Id == castObj.Id;
        }

		/// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        /// Creator:ww
        /// Creation Date:2014/6/16 12:26:50
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public override int GetHashCode()
		{
			var hash = 57; 
			hash = 27 * hash * this.Id.GetHashCode();
			return hash;
		}
	}
}