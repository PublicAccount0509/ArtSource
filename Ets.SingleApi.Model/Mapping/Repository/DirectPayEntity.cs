// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DirectPayEntity.cs" company="Irdeto">
//   Copyright @ 2014
// </copyright>
// <summary>
//   Class:DirectPayEntity
//   Namespace:Ets.SingleApi.Model.Repository
//   Class Funtion:Represent the class mapping the DirectPayEntity table in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ets.SingleApi.Model.Repository
{
	using System;
	using System.Collections.Generic;
		
    /// <summary>
    /// Class:DirectPayEntity
    /// Namespace:Ets.SingleApi.Model.Repository
    /// Class Funtion:Represent the class mapping the DirectPayEntity table in the database.
    /// </summary>
    /// Creator:ww
    /// Creation Date:2014/5/5 14:36:34
    /// Modifier:
    /// Last Modified:
    /// ----------------------------------------------------------------------------------------
    [Serializable]
    public class DirectPayEntity
    {
		#region private member

			/// <summary>
		/// The DirectPayID
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/5/5 14:36:34
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int directPayId;

			/// <summary>
		/// The OrderNumber
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/5/5 14:36:34
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int orderNumber;

			/// <summary>
		/// The ContactPhone
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/5/5 14:36:34
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string contactPhone;

			/// <summary>
		/// The ContactName
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/5/5 14:36:34
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string contactName;

			/// <summary>
		/// The Gender
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/5/5 14:36:34
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string gender;

			/// <summary>
		/// The IsPaid
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/5/5 14:36:34
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private bool isPaId;

			/// <summary>
		/// The OrderStateId
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/5/5 14:36:34
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int orderStateId;

			/// <summary>
		/// The DateAdded
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/5/5 14:36:34
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private DateTime dateAdded;

			/// <summary>
		/// The Instruction
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/5/5 14:36:34
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string instruction;

			/// <summary>
		/// The OrderNotes
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/5/5 14:36:34
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string orderNotes;

			/// <summary>
		/// The ModifyDate
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/5/5 14:36:34
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private DateTime modifyDate;

			/// <summary>
		/// The Total
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/5/5 14:36:34
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private decimal total;

			/// <summary>
		/// The CustomerTotal
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/5/5 14:36:34
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private decimal customerTotal;

			/// <summary>
		/// The CouponTotal
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/5/5 14:36:34
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private decimal couponTotal;

			/// <summary>
		/// The CustomerCouponTotal
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/5/5 14:36:34
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private decimal customerCouponTotal;

			/// <summary>
		/// The SupplierCouponTotal
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/5/5 14:36:34
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private decimal supplierCouponTotal;

			/// <summary>
		/// The InvoiceRequired
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/5/5 14:36:34
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private bool invoiceRequired;

			/// <summary>
		/// The InvoiceTitle
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/5/5 14:36:34
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string invoiceTitle;

			/// <summary>
		/// The Cancelled
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/5/5 14:36:34
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private bool? cancelled;

			/// <summary>
		/// The IPAddress
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/5/5 14:36:34
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string iPAddress;

			/// <summary>
		/// The PaymentDirectList
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/5/5 14:36:34
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private IList<PaymentDirectEntity> paymentDirectList;

			/// <summary>
		/// The CustomerId
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/5/5 14:36:34
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        private int customerId;

        /// <summary>
        /// The SupplierID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/17 17:42:38
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        private int? supplierId;

			/// <summary>
		/// The Path
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/5/5 14:36:34
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private SourcePathEntity path;

			/// <summary>
		/// The Templateid
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/5/5 14:36:34
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private SourceTypeEntity template;
        
		#endregion

		/// <summary>
        /// Initializes a new instance of the <see cref="DirectPayEntity"/> class.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/5/5 14:36:34
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public DirectPayEntity()
        {
            this.directPayId = 0;
            this.customerId = 0;
			this.orderNumber = 0;
			this.contactPhone = string.Empty;
			this.contactName = string.Empty;
			this.gender = string.Empty;
			this.isPaId = false;
			this.orderStateId = 0;
			this.dateAdded = DateTime.Now;
			this.instruction = string.Empty;
			this.orderNotes = string.Empty;
			this.modifyDate = DateTime.Now;
			this.total = 0;
			this.customerTotal = 0;
			this.couponTotal = 0;
			this.customerCouponTotal = 0;
			this.supplierCouponTotal = 0;
			this.invoiceRequired = false;
			this.invoiceTitle = string.Empty;
			this.iPAddress = string.Empty;
		}

		#region public member

			/// <summary>
        /// Gets or sets a value mapping the DirectPayID of DirectPayEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/5/5 14:36:34
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int DirectPayId
		{
            get
            {
                return this.directPayId;
            }

            set
            {
                this.directPayId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the OrderNumber of DirectPayEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/5/5 14:36:34
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int OrderNumber
		{
            get
            {
                return this.orderNumber;
            }

            set
            {
                this.orderNumber = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the ContactPhone of DirectPayEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/5/5 14:36:34
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string ContactPhone
		{
            get
            {
                return this.contactPhone;
            }

            set
            {
                this.contactPhone = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the ContactName of DirectPayEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/5/5 14:36:34
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string ContactName
		{
            get
            {
                return this.contactName;
            }

            set
            {
                this.contactName = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Gender of DirectPayEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/5/5 14:36:34
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string Gender
		{
            get
            {
                return this.gender;
            }

            set
            {
                this.gender = value;
            }
        }

			/// <summary>
        /// Gets or sets a value indicating whether mapping the IsPaid of DirectPayEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/5/5 14:36:34
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual bool IsPaId
		{
            get
            {
                return this.isPaId;
            }

            set
            {
                this.isPaId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the OrderStateId of DirectPayEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/5/5 14:36:34
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int OrderStateId
		{
            get
            {
                return this.orderStateId;
            }

            set
            {
                this.orderStateId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the DateAdded of DirectPayEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/5/5 14:36:34
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual DateTime DateAdded
		{
            get
            {
                return this.dateAdded;
            }

            set
            {
                this.dateAdded = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Instruction of DirectPayEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/5/5 14:36:34
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string Instruction
		{
            get
            {
                return this.instruction;
            }

            set
            {
                this.instruction = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the OrderNotes of DirectPayEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/5/5 14:36:34
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string OrderNotes
		{
            get
            {
                return this.orderNotes;
            }

            set
            {
                this.orderNotes = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the ModifyDate of DirectPayEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/5/5 14:36:34
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual DateTime ModifyDate
		{
            get
            {
                return this.modifyDate;
            }

            set
            {
                this.modifyDate = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Total of DirectPayEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/5/5 14:36:34
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
        /// Gets or sets a value mapping the CustomerTotal of DirectPayEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/5/5 14:36:34
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual decimal CustomerTotal
		{
            get
            {
                return this.customerTotal;
            }

            set
            {
                this.customerTotal = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the CouponTotal of DirectPayEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/5/5 14:36:34
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual decimal CouponTotal
		{
            get
            {
                return this.couponTotal;
            }

            set
            {
                this.couponTotal = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the CustomerCouponTotal of DirectPayEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/5/5 14:36:34
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual decimal CustomerCouponTotal
		{
            get
            {
                return this.customerCouponTotal;
            }

            set
            {
                this.customerCouponTotal = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the SupplierCouponTotal of DirectPayEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/5/5 14:36:34
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual decimal SupplierCouponTotal
		{
            get
            {
                return this.supplierCouponTotal;
            }

            set
            {
                this.supplierCouponTotal = value;
            }
        }

			/// <summary>
        /// Gets or sets a value indicating whether mapping the InvoiceRequired of DirectPayEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/5/5 14:36:34
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual bool InvoiceRequired
		{
            get
            {
                return this.invoiceRequired;
            }

            set
            {
                this.invoiceRequired = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the InvoiceTitle of DirectPayEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/5/5 14:36:34
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string InvoiceTitle
		{
            get
            {
                return this.invoiceTitle;
            }

            set
            {
                this.invoiceTitle = value;
            }
        }

			/// <summary>
        /// Gets or sets a value indicating whether mapping the Cancelled of DirectPayEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/5/5 14:36:34
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual bool? Cancelled
		{
            get
            {
                return this.cancelled;
            }

            set
            {
                this.cancelled = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the IPAddress of DirectPayEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/5/5 14:36:34
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string IPAddress
		{
            get
            {
                return this.iPAddress;
            }

            set
            {
                this.iPAddress = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the PaymentDirectList of DirectPayEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/5/5 14:36:34
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual IList<PaymentDirectEntity> PaymentDirectList
		{
            get
            {
                return this.paymentDirectList;
            }

            set
            {
                this.paymentDirectList = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the CustomerId of DirectPayEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/5/5 14:36:34
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
        /// Gets or sets a value mapping the Path of DirectPayEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/5/5 14:36:34
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual SourcePathEntity Path
		{
            get
            {
                return this.path;
            }

            set
            {
                this.path = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Templateid of DirectPayEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/5/5 14:36:34
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual SourceTypeEntity Template
		{
            get
            {
                return this.template;
            }

            set
            {
                this.template = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the SupplierId of DirectPayEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/5/5 14:36:34
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? SupplierId
		{
            get
            {
                return this.supplierId;
            }

            set
            {
                this.supplierId = value;
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
        /// Creation Date:2014/5/5 14:36:34
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public override bool Equals(object obj)
        {
            if (obj == null || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }

            var castObj = (DirectPayEntity)obj;
            return this.DirectPayId == castObj.DirectPayId;
        }

		/// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        /// Creator:ww
        /// Creation Date:2014/5/5 14:36:34
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public override int GetHashCode()
		{
			var hash = 57; 
			hash = 27 * hash * this.DirectPayId.GetHashCode();
			return hash;
		}
	}
}