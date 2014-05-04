// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OrderNumberDpEntity.cs" company="Irdeto">
//   Copyright @ 2014
// </copyright>
// <summary>
//   Class:OrderNumberDpEntity
//   Namespace:Ets.SingleApi.Model.Repository
//   Class Funtion:Represent the class mapping the OrderNumberDpEntity table in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ets.SingleApi.Model.Repository
{
	using System;
		
    /// <summary>
    /// Class:OrderNumberDpEntity
    /// Namespace:Ets.SingleApi.Model.Repository
    /// Class Funtion:Represent the class mapping the OrderNumberDpEntity table in the database.
    /// </summary>
    /// Creator:周超
    /// Creation Date:2014/4/29 13:20:01
    /// Modifier:
    /// Last Modified:
    /// ----------------------------------------------------------------------------------------
    [Serializable]
    public class OrderNumberDpEntity
    {
		#region private member

			/// <summary>
		/// The OrderId
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/4/29 13:20:01
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int orderId;

		#endregion

		/// <summary>
        /// Initializes a new instance of the <see cref="OrderNumberDpEntity"/> class.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/4/29 13:20:01
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public OrderNumberDpEntity()
        {
			this.orderId = 0;
		}

		#region public member

			/// <summary>
        /// Gets or sets a value mapping the OrderId of OrderNumberDpEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/4/29 13:20:01
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int OrderId
		{
            get
            {
                return this.orderId;
            }

            set
            {
                this.orderId = value;
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
        /// Creation Date:2014/4/29 13:20:01
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public override bool Equals(object obj)
        {
            if (obj == null || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }

            var castObj = (OrderNumberDpEntity)obj;
            return this.OrderId == castObj.OrderId;
        }

		/// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        /// Creator:周超
        /// Creation Date:2014/4/29 13:20:01
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public override int GetHashCode()
		{
			var hash = 57; 
			return hash;
		}
	}
}