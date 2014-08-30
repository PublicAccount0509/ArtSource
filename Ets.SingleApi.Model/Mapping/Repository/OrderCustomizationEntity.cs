// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OrderCustomizationEntity.cs" company="Irdeto">
//   Copyright @ 2014
// </copyright>
// <summary>
//   Class:OrderCustomizationEntity
//   Namespace:Ets.SingleApi.Model.Repository
//   Class Funtion:Represent the class mapping the OrderCustomizationEntity table in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ets.SingleApi.Model.Repository
{
	using System;
		
    /// <summary>
    /// Class:OrderCustomizationEntity
    /// Namespace:Ets.SingleApi.Model.Repository
    /// Class Funtion:Represent the class mapping the OrderCustomizationEntity table in the database.
    /// </summary>
    /// Creator:周超
    /// Creation Date:2014/8/30 16:22:37
    /// Modifier:
    /// Last Modified:
    /// ----------------------------------------------------------------------------------------
    [Serializable]
    public class OrderCustomizationEntity
    {
		#region private member

			/// <summary>
		/// The OrderCustomizationID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/8/30 16:22:37
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int orderCustomizationId;

			/// <summary>
		/// The OrderID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/8/30 16:22:37
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int orderId;

			/// <summary>
		/// The OptionID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/8/30 16:22:37
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int optionId;

			/// <summary>
		/// The Number
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/8/30 16:22:37
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? number;

			/// <summary>
		/// The Price
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/8/30 16:22:37
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private decimal? price;

			/// <summary>
		/// The Describe
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/8/30 16:22:37
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string describe;

		#endregion

		/// <summary>
        /// Initializes a new instance of the <see cref="OrderCustomizationEntity"/> class.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/8/30 16:22:37
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public OrderCustomizationEntity()
        {
			this.orderCustomizationId = 0;
			this.orderId = 0;
			this.optionId = 0;
			this.describe = string.Empty;
		}

		#region public member

			/// <summary>
        /// Gets or sets a value mapping the OrderCustomizationID of OrderCustomizationEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/8/30 16:22:37
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int OrderCustomizationId
		{
            get
            {
                return this.orderCustomizationId;
            }

            set
            {
                this.orderCustomizationId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the OrderID of OrderCustomizationEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/8/30 16:22:37
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

			/// <summary>
        /// Gets or sets a value mapping the OptionID of OrderCustomizationEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/8/30 16:22:37
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int OptionId
		{
            get
            {
                return this.optionId;
            }

            set
            {
                this.optionId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Number of OrderCustomizationEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/8/30 16:22:37
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? Number
		{
            get
            {
                return this.number;
            }

            set
            {
                this.number = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Price of OrderCustomizationEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/8/30 16:22:37
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual decimal? Price
		{
            get
            {
                return this.price;
            }

            set
            {
                this.price = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Describe of OrderCustomizationEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/8/30 16:22:37
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string Describe
		{
            get
            {
                return this.describe;
            }

            set
            {
                this.describe = value;
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
        /// Creation Date:2014/8/30 16:22:37
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public override bool Equals(object obj)
        {
            if (obj == null || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }

            var castObj = (OrderCustomizationEntity)obj;
            return this.OrderCustomizationId == castObj.OrderCustomizationId;
        }

		/// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        /// Creator:周超
        /// Creation Date:2014/8/30 16:22:37
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public override int GetHashCode()
		{
			var hash = 57; 
			hash = 27 * hash * this.OrderCustomizationId.GetHashCode();
			return hash;
		}
	}
}