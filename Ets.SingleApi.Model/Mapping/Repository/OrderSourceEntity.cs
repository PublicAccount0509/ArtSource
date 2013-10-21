// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OrderSourceEntity.cs" company="Irdeto">
//   Copyright @ 2013
// </copyright>
// <summary>
//   Class:OrderSourceEntity
//   Namespace:Ets.SingleApi.Model.Repository
//   Class Funtion:Represent the class mapping the OrderSourceEntity table in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ets.SingleApi.Model.Repository
{
	using System;
		
    /// <summary>
    /// Class:OrderSourceEntity
    /// Namespace:Ets.SingleApi.Model.Repository
    /// Class Funtion:Represent the class mapping the OrderSourceEntity table in the database.
    /// </summary>
    /// Creator:周超
    /// Creation Date:2013/10/20 22:28:32
    /// Modifier:
    /// Last Modified:
    /// ----------------------------------------------------------------------------------------
    [Serializable]
    public class OrderSourceEntity
    {
		#region private member

			/// <summary>
		/// The OrderSourceId
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/20 22:28:33
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int orderSourceId;

			/// <summary>
		/// The OrderSourceName
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/20 22:28:33
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string orderSourceName;

		#endregion

		/// <summary>
        /// Initializes a new instance of the <see cref="OrderSourceEntity"/> class.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/20 22:28:33
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public OrderSourceEntity()
        {
			this.orderSourceId = 0;
			this.orderSourceName = string.Empty;
		}

		#region public member

			/// <summary>
        /// Gets or sets a value mapping the OrderSourceId of OrderSourceEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/20 22:28:33
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int OrderSourceId
		{
            get
            {
                return this.orderSourceId;
            }

            set
            {
                this.orderSourceId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the OrderSourceName of OrderSourceEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/20 22:28:33
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string OrderSourceName
		{
            get
            {
                return this.orderSourceName;
            }

            set
            {
                this.orderSourceName = value;
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

            var castObj = (OrderSourceEntity)obj;
            return this.OrderSourceId == castObj.OrderSourceId;
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
			hash = 27 * hash * this.OrderSourceId.GetHashCode();
			return hash;
		}
	}
}