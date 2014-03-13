// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OrderDetailEntity.cs" company="Irdeto">
//   Copyright @ 2014
// </copyright>
// <summary>
//   Class:OrderDetailEntity
//   Namespace:Ets.SingleApi.Model.Repository
//   Class Funtion:Represent the class mapping the OrderDetailEntity table in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ets.SingleApi.Model.Repository
{
	using System;
		
    /// <summary>
    /// Class:OrderDetailEntity
    /// Namespace:Ets.SingleApi.Model.Repository
    /// Class Funtion:Represent the class mapping the OrderDetailEntity table in the database.
    /// </summary>
    /// Creator:周超
    /// Creation Date:2014/3/13 19:30:07
    /// Modifier:
    /// Last Modified:
    /// ----------------------------------------------------------------------------------------
    [Serializable]
    public class OrderDetailEntity
    {
		#region private member

			/// <summary>
		/// The OrderDetailId
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/3/13 19:30:08
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int orderDetailId;

			/// <summary>
		/// The OrderId
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/3/13 19:30:08
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? orderId;

			/// <summary>
		/// The OrderType
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/3/13 19:30:08
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? orderType;

			/// <summary>
		/// The CustomerId
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/3/13 19:30:08
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? customerId;

			/// <summary>
		/// The SupplierDishId
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/3/13 19:30:08
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? supplierDishId;

			/// <summary>
		/// The Quantity
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/3/13 19:30:08
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? quantity;

			/// <summary>
		/// The SupplierPrice
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/3/13 19:30:08
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private decimal? supplierPrice;

			/// <summary>
		/// The Total
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/3/13 19:30:08
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private decimal? total;

			/// <summary>
		/// The SpecialInstruction
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/3/13 19:30:08
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string specialInstruction;

			/// <summary>
		/// The OrderDate
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/3/13 19:30:08
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private DateTime? orderDate;

			/// <summary>
		/// The IsAdd
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/3/13 19:30:08
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private bool? isAdd;

			/// <summary>
		/// The Status
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/3/13 19:30:08
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? status;

			/// <summary>
		/// The SupplierDishName
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/3/13 19:30:08
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string supplierDishName;

			/// <summary>
		/// The Note
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/3/13 19:30:08
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string note;

		#endregion

		/// <summary>
        /// Initializes a new instance of the <see cref="OrderDetailEntity"/> class.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/3/13 19:30:08
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public OrderDetailEntity()
        {
			this.orderDetailId = 0;
			this.specialInstruction = string.Empty;
			this.supplierDishName = string.Empty;
			this.note = string.Empty;
		}

		#region public member

			/// <summary>
        /// Gets or sets a value mapping the OrderDetailId of OrderDetailEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/3/13 19:30:08
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int OrderDetailId
		{
            get
            {
                return this.orderDetailId;
            }

            set
            {
                this.orderDetailId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the OrderId of OrderDetailEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/3/13 19:30:08
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? OrderId
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
        /// Gets or sets a value mapping the OrderType of OrderDetailEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/3/13 19:30:08
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? OrderType
		{
            get
            {
                return this.orderType;
            }

            set
            {
                this.orderType = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the CustomerId of OrderDetailEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/3/13 19:30:08
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? CustomerId
		{
            get
            {
                return this.customerId;
            }

            set
            {
                this.customerId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the SupplierDishId of OrderDetailEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/3/13 19:30:08
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? SupplierDishId
		{
            get
            {
                return this.supplierDishId;
            }

            set
            {
                this.supplierDishId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Quantity of OrderDetailEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/3/13 19:30:08
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? Quantity
		{
            get
            {
                return this.quantity;
            }

            set
            {
                this.quantity = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the SupplierPrice of OrderDetailEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/3/13 19:30:08
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual decimal? SupplierPrice
		{
            get
            {
                return this.supplierPrice;
            }

            set
            {
                this.supplierPrice = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Total of OrderDetailEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/3/13 19:30:08
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual decimal? Total
		{
            get
            {
                return this.total;
            }

            set
            {
                this.total = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the SpecialInstruction of OrderDetailEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/3/13 19:30:08
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string SpecialInstruction
		{
            get
            {
                return this.specialInstruction;
            }

            set
            {
                this.specialInstruction = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the OrderDate of OrderDetailEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/3/13 19:30:08
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual DateTime? OrderDate
		{
            get
            {
                return this.orderDate;
            }

            set
            {
                this.orderDate = value;
            }
        }

			/// <summary>
        /// Gets or sets a value indicating whether mapping the IsAdd of OrderDetailEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/3/13 19:30:08
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual bool? IsAdd
		{
            get
            {
                return this.isAdd;
            }

            set
            {
                this.isAdd = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Status of OrderDetailEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/3/13 19:30:08
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? Status
		{
            get
            {
                return this.status;
            }

            set
            {
                this.status = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the SupplierDishName of OrderDetailEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/3/13 19:30:08
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string SupplierDishName
		{
            get
            {
                return this.supplierDishName;
            }

            set
            {
                this.supplierDishName = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Note of OrderDetailEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/3/13 19:30:08
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string Note
		{
            get
            {
                return this.note;
            }

            set
            {
                this.note = value;
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
        /// Creation Date:2014/3/13 19:30:08
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public override bool Equals(object obj)
        {
            if (obj == null || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }

            var castObj = (OrderDetailEntity)obj;
            return this.OrderDetailId == castObj.OrderDetailId;
        }

		/// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        /// Creator:周超
        /// Creation Date:2014/3/13 19:30:08
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public override int GetHashCode()
		{
			var hash = 57; 
			hash = 27 * hash * this.OrderDetailId.GetHashCode();
			return hash;
		}
	}
}