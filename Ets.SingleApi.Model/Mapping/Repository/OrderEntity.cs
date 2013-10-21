// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OrderEntity.cs" company="Irdeto">
//   Copyright @ 2013
// </copyright>
// <summary>
//   Class:OrderEntity
//   Namespace:Ets.SingleApi.Model.Repository
//   Class Funtion:Represent the class mapping the OrderEntity table in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ets.SingleApi.Model.Repository
{
	using System;
		
    /// <summary>
    /// Class:OrderEntity
    /// Namespace:Ets.SingleApi.Model.Repository
    /// Class Funtion:Represent the class mapping the OrderEntity table in the database.
    /// </summary>
    /// Creator:周超
    /// Creation Date:2013/10/13 14:32:24
    /// Modifier:
    /// Last Modified:
    /// ----------------------------------------------------------------------------------------
    [Serializable]
    public class OrderEntity
    {
		#region private member

			/// <summary>
		/// The OrderID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:32:24
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int orderId;

			/// <summary>
		/// The CustomerID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:32:24
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int customerId;

			/// <summary>
		/// The SupplierDishID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:32:24
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int supplierDishId;

			/// <summary>
		/// The Quantity
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:32:24
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int quantity;

			/// <summary>
		/// The Total
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:32:24
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private decimal total;

			/// <summary>
		/// The SpecialInstruction
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:32:24
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string specialInstruction;

			/// <summary>
		/// The OrderDate
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:32:24
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private DateTime? orderDate;

			/// <summary>
		/// The IsRating
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:32:24
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private bool? isRating;

			/// <summary>
		/// The SupplierPrice
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:32:24
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private decimal? supplierPrice;

			/// <summary>
		/// The OrderSource
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:32:24
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? orderSource;

			/// <summary>
		/// The PromotionId
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:32:24
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? promotionId;

			/// <summary>
		/// The PreTaxMoney
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:32:24
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private decimal? preTaxMoney;

			/// <summary>
		/// The SupplierDishName
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:32:24
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string supplierDishName;

			/// <summary>
		/// The Note
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:32:24
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string note;

			/// <summary>
		/// The OrderNo
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:32:24
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string orderNo;

			/// <summary>
		/// The DeliveryID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:32:24
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private DeliveryEntity delivery;

		#endregion

		/// <summary>
        /// Initializes a new instance of the <see cref="OrderEntity"/> class.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:32:24
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public OrderEntity()
        {
			this.orderId = 0;
			this.customerId = 0;
			this.supplierDishId = 0;
			this.quantity = 0;
			this.total = 0;
			this.specialInstruction = string.Empty;
			this.supplierDishName = string.Empty;
			this.note = string.Empty;
			this.orderNo = string.Empty;
		}

		#region public member

			/// <summary>
        /// Gets or sets a value mapping the OrderID of OrderEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:32:24
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
        /// Gets or sets a value mapping the CustomerID of OrderEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:32:24
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int CustomerId
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
        /// Gets or sets a value mapping the SupplierDishID of OrderEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:32:24
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int SupplierDishId
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
        /// Gets or sets a value mapping the Quantity of OrderEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:32:24
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int Quantity
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
        /// Gets or sets a value mapping the Total of OrderEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:32:24
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual decimal Total
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
        /// Gets or sets a value mapping the SpecialInstruction of OrderEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:32:24
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
        /// Gets or sets a value mapping the OrderDate of OrderEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:32:24
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
        /// Gets or sets a value indicating whether mapping the IsRating of OrderEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:32:24
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual bool? IsRating
		{
            get
            {
                return this.isRating;
            }

            set
            {
                this.isRating = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the SupplierPrice of OrderEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:32:24
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
        /// Gets or sets a value mapping the OrderSource of OrderEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:32:24
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? OrderSource
		{
            get
            {
                return this.orderSource;
            }

            set
            {
                this.orderSource = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the PromotionId of OrderEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:32:24
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? PromotionId
		{
            get
            {
                return this.promotionId;
            }

            set
            {
                this.promotionId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the PreTaxMoney of OrderEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:32:24
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual decimal? PreTaxMoney
		{
            get
            {
                return this.preTaxMoney;
            }

            set
            {
                this.preTaxMoney = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the SupplierDishName of OrderEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:32:24
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
        /// Gets or sets a value mapping the Note of OrderEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:32:24
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

			/// <summary>
        /// Gets or sets a value mapping the OrderNo of OrderEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:32:24
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string OrderNo
		{
            get
            {
                return this.orderNo;
            }

            set
            {
                this.orderNo = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the DeliveryID of OrderEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:32:24
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual DeliveryEntity Delivery
		{
            get
            {
                return this.delivery;
            }

            set
            {
                this.delivery = value;
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
        /// Creation Date:2013/10/13 14:32:24
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public override bool Equals(object obj)
        {
            if (obj == null || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }

            var castObj = (OrderEntity)obj;
            return this.OrderId == castObj.OrderId;
        }

		/// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:32:24
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public override int GetHashCode()
		{
			var hash = 57; 
			hash = 27 * hash * this.OrderId.GetHashCode();
			return hash;
		}
	}
}