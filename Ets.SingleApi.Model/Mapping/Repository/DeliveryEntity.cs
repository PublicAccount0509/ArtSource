// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DeliveryEntity.cs" company="Irdeto">
//   Copyright @ 2013
// </copyright>
// <summary>
//   Class:DeliveryEntity
//   Namespace:Ets.SingleApi.Model.Repository
//   Class Funtion:Represent the class mapping the DeliveryEntity table in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ets.SingleApi.Model.Repository
{
	using System;
	using System.Collections.Generic;
		
    /// <summary>
    /// Class:DeliveryEntity
    /// Namespace:Ets.SingleApi.Model.Repository
    /// Class Funtion:Represent the class mapping the DeliveryEntity table in the database.
    /// </summary>
    /// Creator:周超
    /// Creation Date:2013/10/13 14:27:05
    /// Modifier:
    /// Last Modified:
    /// ----------------------------------------------------------------------------------------
    [Serializable]
    public class DeliveryEntity
    {
		#region private member

			/// <summary>
		/// The DeliveryID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int deliveryId;

			/// <summary>
		/// The CustomerID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int customerId;

			/// <summary>
		/// The OrderStatusID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int orderStatusId;

			/// <summary>
		/// The DeliveryMethodID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? deliveryMethodId;

			/// <summary>
		/// The DeliveryAddressID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? deliveryAddressId;

			/// <summary>
		/// The DeliveryZoneID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? deliveryZoneId;

			/// <summary>
		/// The CouponID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? couponId;

			/// <summary>
		/// The Total
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private decimal? total;

			/// <summary>
		/// The IsPaid
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private bool? isPaId;

			/// <summary>
		/// The Cancelled
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private bool? cancelled;

			/// <summary>
		/// The DeliveryDate
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private DateTime? deliveryDate;

			/// <summary>
		/// The DeliveryInstruction
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string deliveryInstruction;

			/// <summary>
		/// The DateAdded
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private DateTime? dateAdded;

			/// <summary>
		/// The IPAddress
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string iPAddress;

			/// <summary>
		/// The IsRating
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private bool? isRating;

			/// <summary>
		/// The OrderNotes
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string orderNotes;

			/// <summary>
		/// The RejectReason
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string rejectReason;

			/// <summary>
		/// The QuotedDeliveryTime
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string quotedDeliveryTime;

			/// <summary>
		/// The OperatorID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? operatorId;

			/// <summary>
		/// The ContactPhone
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string contactPhone;

			/// <summary>
		/// The Contact
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string contact;

			/// <summary>
		/// The Gender
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string gender;

			/// <summary>
		/// The Tel
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string tel;

			/// <summary>
		/// The InvoiceRequired
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private bool? invoiceRequired;

			/// <summary>
		/// The SupplierID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? supplierId;

			/// <summary>
		/// The InvoiceTitle
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string invoiceTitle;

			/// <summary>
		/// The PackagingFee
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private decimal? packagingFee;

			/// <summary>
		/// The DeliverCharge
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private decimal? deliverCharge;

			/// <summary>
		/// The DeliverSourcs
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private byte? deliverSourcs;

			/// <summary>
		/// The SendingPersonID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? sendingPersonId;

			/// <summary>
		/// The LogisticsTakeFoodTime
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private DateTime? logisticsTakeFoodTime;

			/// <summary>
		/// The OrderNumber
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? orderNumber;

			/// <summary>
		/// The CustomerTotal
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private decimal? customerTotal;

			/// <summary>
		/// The CCdiscount
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private decimal? cCdiscount;

			/// <summary>
		/// The ActualSendTime
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private DateTime? actualSendTime;

			/// <summary>
		/// The ReceivablePrice
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private decimal? receivablePrice;

			/// <summary>
		/// The RealUserPrice
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private decimal? realUserPrice;

			/// <summary>
		/// The RealSupplierPrice
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private decimal? realSupplierPrice;

			/// <summary>
		/// The RealSupplierType
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private byte? realSupplierType;

			/// <summary>
		/// The IsTakeInvoice
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private bool? isTakeInvoice;

			/// <summary>
		/// The AddedTime
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private DateTime? addedTime;

			/// <summary>
		/// The CheckStatus
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private byte? checkStatus;

			/// <summary>
		/// The HandOverStatus
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private byte? handOverStatus;

			/// <summary>
		/// The Lat
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private double? lat;

			/// <summary>
		/// The Lng
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private double? lng;

			/// <summary>
		/// The LogisticsId
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string logisticsId;

			/// <summary>
		/// The ModifyDate
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private DateTime? modifyDate;

			/// <summary>
		/// The EtsTakeFoodAmount
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private decimal? etsTakeFoodAmount;

			/// <summary>
		/// The EtsActualTakeFoodAmount
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private decimal? etsActualTakeFoodAmount;

			/// <summary>
		/// The TaxPointAmount
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private decimal? taxPointAmount;

			/// <summary>
		/// The AreaId
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? areaId;

			/// <summary>
		/// The CashPay
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private decimal? cashPay;

			/// <summary>
		/// The NetWorkPay
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private decimal? netWorkPay;

			/// <summary>
		/// The PosPay
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private decimal? posPay;

			/// <summary>
		/// The StoreCardPaySup
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private decimal? storeCardPaySup;

			/// <summary>
		/// The DeliveryDistance
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private double deliveryDistance;

			/// <summary>
		/// The LogisSendTime
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private DateTime? logisSendTime;

			/// <summary>
		/// The OrderList
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private IList<OrderEntity> orderList;

			/// <summary>
		/// The PaymentList
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private IList<PaymentEntity> paymentList;

			/// <summary>
		/// The Path
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private SourcePathEntity path;

			/// <summary>
		/// The Templateid
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private SourceTypeEntity template1;

			/// <summary>
		/// The Templateid
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private SourceTypeEntity template;

		#endregion

		/// <summary>
        /// Initializes a new instance of the <see cref="DeliveryEntity"/> class.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public DeliveryEntity()
        {
			this.deliveryId = 0;
			this.customerId = 0;
			this.orderStatusId = 0;
			this.deliveryInstruction = string.Empty;
			this.iPAddress = string.Empty;
			this.orderNotes = string.Empty;
			this.rejectReason = string.Empty;
			this.quotedDeliveryTime = string.Empty;
			this.contactPhone = string.Empty;
			this.contact = string.Empty;
			this.gender = string.Empty;
			this.tel = string.Empty;
			this.invoiceTitle = string.Empty;
			this.logisticsId = string.Empty;
			this.deliveryDistance = -1;
		}

		#region public member

			/// <summary>
        /// Gets or sets a value mapping the DeliveryID of DeliveryEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
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
        /// Gets or sets a value mapping the CustomerID of DeliveryEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
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
        /// Gets or sets a value mapping the OrderStatusID of DeliveryEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
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
        /// Gets or sets a value mapping the DeliveryMethodID of DeliveryEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? DeliveryMethodId
		{
            get
            {
                return this.deliveryMethodId;
            }

            set
            {
                this.deliveryMethodId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the DeliveryAddressID of DeliveryEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? DeliveryAddressId
		{
            get
            {
                return this.deliveryAddressId;
            }

            set
            {
                this.deliveryAddressId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the DeliveryZoneID of DeliveryEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? DeliveryZoneId
		{
            get
            {
                return this.deliveryZoneId;
            }

            set
            {
                this.deliveryZoneId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the CouponID of DeliveryEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? CouponId
		{
            get
            {
                return this.couponId;
            }

            set
            {
                this.couponId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Total of DeliveryEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
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
        /// Gets or sets a value indicating whether mapping the IsPaid of DeliveryEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual bool? IsPaId
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
        /// Gets or sets a value indicating whether mapping the Cancelled of DeliveryEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
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
        /// Gets or sets a value mapping the DeliveryDate of DeliveryEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual DateTime? DeliveryDate
		{
            get
            {
                return this.deliveryDate;
            }

            set
            {
                this.deliveryDate = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the DeliveryInstruction of DeliveryEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string DeliveryInstruction
		{
            get
            {
                return this.deliveryInstruction;
            }

            set
            {
                this.deliveryInstruction = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the DateAdded of DeliveryEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual DateTime? DateAdded
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
        /// Gets or sets a value mapping the IPAddress of DeliveryEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
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
        /// Gets or sets a value indicating whether mapping the IsRating of DeliveryEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
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
        /// Gets or sets a value mapping the OrderNotes of DeliveryEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
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
        /// Gets or sets a value mapping the RejectReason of DeliveryEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string RejectReason
		{
            get
            {
                return this.rejectReason;
            }

            set
            {
                this.rejectReason = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the QuotedDeliveryTime of DeliveryEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string QuotedDeliveryTime
		{
            get
            {
                return this.quotedDeliveryTime;
            }

            set
            {
                this.quotedDeliveryTime = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the OperatorID of DeliveryEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? OperatorId
		{
            get
            {
                return this.operatorId;
            }

            set
            {
                this.operatorId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the ContactPhone of DeliveryEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
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
        /// Gets or sets a value mapping the Contact of DeliveryEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string Contact
		{
            get
            {
                return this.contact;
            }

            set
            {
                this.contact = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Gender of DeliveryEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
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
        /// Gets or sets a value mapping the Tel of DeliveryEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string Tel
		{
            get
            {
                return this.tel;
            }

            set
            {
                this.tel = value;
            }
        }

			/// <summary>
        /// Gets or sets a value indicating whether mapping the InvoiceRequired of DeliveryEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual bool? InvoiceRequired
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
        /// Gets or sets a value mapping the SupplierID of DeliveryEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
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

			/// <summary>
        /// Gets or sets a value mapping the InvoiceTitle of DeliveryEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
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
        /// Gets or sets a value mapping the PackagingFee of DeliveryEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual decimal? PackagingFee
		{
            get
            {
                return this.packagingFee;
            }

            set
            {
                this.packagingFee = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the DeliverCharge of DeliveryEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual decimal? DeliverCharge
		{
            get
            {
                return this.deliverCharge;
            }

            set
            {
                this.deliverCharge = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the DeliverSourcs of DeliveryEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual byte? DeliverSourcs
		{
            get
            {
                return this.deliverSourcs;
            }

            set
            {
                this.deliverSourcs = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the SendingPersonID of DeliveryEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? SendingPersonId
		{
            get
            {
                return this.sendingPersonId;
            }

            set
            {
                this.sendingPersonId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the LogisticsTakeFoodTime of DeliveryEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual DateTime? LogisticsTakeFoodTime
		{
            get
            {
                return this.logisticsTakeFoodTime;
            }

            set
            {
                this.logisticsTakeFoodTime = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the OrderNumber of DeliveryEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? OrderNumber
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
        /// Gets or sets a value mapping the CustomerTotal of DeliveryEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual decimal? CustomerTotal
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
        /// Gets or sets a value mapping the CCdiscount of DeliveryEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual decimal? CCdiscount
		{
            get
            {
                return this.cCdiscount;
            }

            set
            {
                this.cCdiscount = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the ActualSendTime of DeliveryEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual DateTime? ActualSendTime
		{
            get
            {
                return this.actualSendTime;
            }

            set
            {
                this.actualSendTime = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the ReceivablePrice of DeliveryEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual decimal? ReceivablePrice
		{
            get
            {
                return this.receivablePrice;
            }

            set
            {
                this.receivablePrice = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the RealUserPrice of DeliveryEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual decimal? RealUserPrice
		{
            get
            {
                return this.realUserPrice;
            }

            set
            {
                this.realUserPrice = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the RealSupplierPrice of DeliveryEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual decimal? RealSupplierPrice
		{
            get
            {
                return this.realSupplierPrice;
            }

            set
            {
                this.realSupplierPrice = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the RealSupplierType of DeliveryEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual byte? RealSupplierType
		{
            get
            {
                return this.realSupplierType;
            }

            set
            {
                this.realSupplierType = value;
            }
        }

			/// <summary>
        /// Gets or sets a value indicating whether mapping the IsTakeInvoice of DeliveryEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual bool? IsTakeInvoice
		{
            get
            {
                return this.isTakeInvoice;
            }

            set
            {
                this.isTakeInvoice = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the AddedTime of DeliveryEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual DateTime? AddedTime
		{
            get
            {
                return this.addedTime;
            }

            set
            {
                this.addedTime = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the CheckStatus of DeliveryEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual byte? CheckStatus
		{
            get
            {
                return this.checkStatus;
            }

            set
            {
                this.checkStatus = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the HandOverStatus of DeliveryEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual byte? HandOverStatus
		{
            get
            {
                return this.handOverStatus;
            }

            set
            {
                this.handOverStatus = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Lat of DeliveryEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual double? Lat
		{
            get
            {
                return this.lat;
            }

            set
            {
                this.lat = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Lng of DeliveryEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual double? Lng
		{
            get
            {
                return this.lng;
            }

            set
            {
                this.lng = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the LogisticsId of DeliveryEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string LogisticsId
		{
            get
            {
                return this.logisticsId;
            }

            set
            {
                this.logisticsId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the ModifyDate of DeliveryEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual DateTime? ModifyDate
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
        /// Gets or sets a value mapping the EtsTakeFoodAmount of DeliveryEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual decimal? EtsTakeFoodAmount
		{
            get
            {
                return this.etsTakeFoodAmount;
            }

            set
            {
                this.etsTakeFoodAmount = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the EtsActualTakeFoodAmount of DeliveryEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual decimal? EtsActualTakeFoodAmount
		{
            get
            {
                return this.etsActualTakeFoodAmount;
            }

            set
            {
                this.etsActualTakeFoodAmount = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the TaxPointAmount of DeliveryEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual decimal? TaxPointAmount
		{
            get
            {
                return this.taxPointAmount;
            }

            set
            {
                this.taxPointAmount = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the AreaId of DeliveryEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? AreaId
		{
            get
            {
                return this.areaId;
            }

            set
            {
                this.areaId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the CashPay of DeliveryEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual decimal? CashPay
		{
            get
            {
                return this.cashPay;
            }

            set
            {
                this.cashPay = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the NetWorkPay of DeliveryEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual decimal? NetWorkPay
		{
            get
            {
                return this.netWorkPay;
            }

            set
            {
                this.netWorkPay = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the PosPay of DeliveryEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual decimal? PosPay
		{
            get
            {
                return this.posPay;
            }

            set
            {
                this.posPay = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the StoreCardPaySup of DeliveryEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual decimal? StoreCardPaySup
		{
            get
            {
                return this.storeCardPaySup;
            }

            set
            {
                this.storeCardPaySup = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the DeliveryDistance of DeliveryEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual double DeliveryDistance
		{
            get
            {
                return this.deliveryDistance;
            }

            set
            {
                this.deliveryDistance = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the LogisSendTime of DeliveryEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual DateTime? LogisSendTime
		{
            get
            {
                return this.logisSendTime;
            }

            set
            {
                this.logisSendTime = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the OrderList of DeliveryEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual IList<OrderEntity> OrderList
		{
            get
            {
                return this.orderList;
            }

            set
            {
                this.orderList = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the PaymentList of DeliveryEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual IList<PaymentEntity> PaymentList
		{
            get
            {
                return this.paymentList;
            }

            set
            {
                this.paymentList = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Path of DeliveryEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
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
        /// Gets or sets a value mapping the Templateid of DeliveryEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual SourceTypeEntity Template1
		{
            get
            {
                return this.template1;
            }

            set
            {
                this.template1 = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Templateid of DeliveryEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
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

		#endregion

			/// <summary>
        /// Determines whether the specified is equal to this instance.
        /// </summary>
        /// <param name="obj">The to compare with this instance.</param>
        /// <returns>
        /// true if the specified is equal to this instance; otherwise,false.
        /// </returns>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public override bool Equals(object obj)
        {
            if (obj == null || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }

            var castObj = (DeliveryEntity)obj;
            return this.DeliveryId == castObj.DeliveryId;
        }

		/// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
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