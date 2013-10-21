// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OrderStatusEntity.cs" company="Irdeto">
//   Copyright @ 2013
// </copyright>
// <summary>
//   Class:OrderStatusEntity
//   Namespace:Ets.SingleApi.Model.Repository
//   Class Funtion:Represent the class mapping the OrderStatusEntity table in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ets.SingleApi.Model.Repository
{
	using System;
		
    /// <summary>
    /// Class:OrderStatusEntity
    /// Namespace:Ets.SingleApi.Model.Repository
    /// Class Funtion:Represent the class mapping the OrderStatusEntity table in the database.
    /// </summary>
    /// Creator:周超
    /// Creation Date:2013/10/20 22:28:33
    /// Modifier:
    /// Last Modified:
    /// ----------------------------------------------------------------------------------------
    [Serializable]
    public class OrderStatusEntity
    {
		#region private member

			/// <summary>
		/// The OrderStatusID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/20 22:28:33
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int orderStatusId;

			/// <summary>
		/// The OrderStatus
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/20 22:28:33
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string orderStatus;

		#endregion

		/// <summary>
        /// Initializes a new instance of the <see cref="OrderStatusEntity"/> class.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/20 22:28:33
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public OrderStatusEntity()
        {
			this.orderStatusId = 0;
			this.orderStatus = string.Empty;
		}

		#region public member

			/// <summary>
        /// Gets or sets a value mapping the OrderStatusID of OrderStatusEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/20 22:28:33
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int OrderStatusId
		{
            get
            {
                return this.orderStatusId;
            }

            set
            {
                this.orderStatusId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the OrderStatus of OrderStatusEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/20 22:28:33
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string OrderStatus
		{
            get
            {
                return this.orderStatus;
            }

            set
            {
                this.orderStatus = value;
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
        /// Creation Date:2013/10/20 22:28:33
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public override bool Equals(object obj)
        {
            if (obj == null || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }

            var castObj = (OrderStatusEntity)obj;
            return this.OrderStatusId == castObj.OrderStatusId;
        }

		/// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        /// Creator:周超
        /// Creation Date:2013/10/20 22:28:33
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public override int GetHashCode()
		{
			var hash = 57; 
			hash = 27 * hash * this.OrderStatusId.GetHashCode();
			return hash;
		}
	}
}