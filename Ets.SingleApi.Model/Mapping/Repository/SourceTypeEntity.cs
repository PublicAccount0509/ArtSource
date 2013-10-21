// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SourceTypeEntity.cs" company="Irdeto">
//   Copyright @ 2013
// </copyright>
// <summary>
//   Class:SourceTypeEntity
//   Namespace:Ets.SingleApi.Model.Repository
//   Class Funtion:Represent the class mapping the SourceTypeEntity table in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ets.SingleApi.Model.Repository
{
	using System;
	using System.Collections.Generic;
		
    /// <summary>
    /// Class:SourceTypeEntity
    /// Namespace:Ets.SingleApi.Model.Repository
    /// Class Funtion:Represent the class mapping the SourceTypeEntity table in the database.
    /// </summary>
    /// Creator:周超
    /// Creation Date:2013/10/13 14:23:32
    /// Modifier:
    /// Last Modified:
    /// ----------------------------------------------------------------------------------------
    [Serializable]
    public class SourceTypeEntity
    {
		#region private member

			/// <summary>
		/// The Id
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:23:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int id;

			/// <summary>
		/// The Value
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:23:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string value;

			/// <summary>
		/// The Text
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:23:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string text;

			/// <summary>
		/// The CustomerList
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:23:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private IList<CustomerEntity> customerList;

			/// <summary>
		/// The DeliveryList
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:23:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private IList<DeliveryEntity> deliveryList1;

			/// <summary>
		/// The DeliveryList
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:23:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private IList<DeliveryEntity> deliveryList;

		#endregion

		/// <summary>
        /// Initializes a new instance of the <see cref="SourceTypeEntity"/> class.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:23:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public SourceTypeEntity()
        {
			this.id = 0;
			this.value = string.Empty;
			this.text = string.Empty;
		}

		#region public member

			/// <summary>
        /// Gets or sets a value mapping the Id of SourceTypeEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:23:32
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
        /// Gets or sets a value mapping the Value of SourceTypeEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:23:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string Value
		{
            get
            {
                return this.value;
            }

            set
            {
                this.value = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Text of SourceTypeEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:23:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string Text
		{
            get
            {
                return this.text;
            }

            set
            {
                this.text = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the CustomerList of SourceTypeEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:23:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual IList<CustomerEntity> CustomerList
		{
            get
            {
                return this.customerList;
            }

            set
            {
                this.customerList = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the DeliveryList of SourceTypeEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:23:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual IList<DeliveryEntity> DeliveryList1
		{
            get
            {
                return this.deliveryList1;
            }

            set
            {
                this.deliveryList1 = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the DeliveryList of SourceTypeEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:23:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual IList<DeliveryEntity> DeliveryList
		{
            get
            {
                return this.deliveryList;
            }

            set
            {
                this.deliveryList = value;
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
        /// Creation Date:2013/10/13 14:23:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public override bool Equals(object obj)
        {
            if (obj == null || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }

            var castObj = (SourceTypeEntity)obj;
            return this.Value == castObj.Value;
        }

		/// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:23:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public override int GetHashCode()
		{
			var hash = 57; 
			hash = 27 * hash * this.Value.GetHashCode();
			return hash;
		}
	}
}