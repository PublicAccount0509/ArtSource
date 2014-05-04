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
    /// Creation Date:2014/4/29 17:05:44
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
        /// Creation Date:2014/4/29 17:05:44
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int directPayId;

			/// <summary>
		/// The CustomerID
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int customerId;

			/// <summary>
		/// The OrderStatusID
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int orderStatusId;

			/// <summary>
		/// The DirectPayMethodID
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? directPayMethodId;

			/// <summary>
		/// The DirectPayAddressID
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? directPayAddressId;

			/// <summary>
		/// The DirectPayZoneID
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? directPayZoneId;

			/// <summary>
		/// The CouponID
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? couponId;

			/// <summary>
		/// The Total
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private decimal? total;

			/// <summary>
		/// The IsPaid
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private bool? isPaId;

			/// <summary>
		/// The Cancelled
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private bool? cancelled;

			/// <summary>
		/// The DirectPayDate
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private DateTime? directPayDate;

			/// <summary>
		/// The DirectPayInstruction
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string directPayInstruction;

			/// <summary>
		/// The DateAdded
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private DateTime? dateAdded;

			/// <summary>
		/// The IPAddress
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string iPAddress;

			/// <summary>
		/// The IsRating
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private bool? isRating;

			/// <summary>
		/// The OrderNotes
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string orderNotes;

			/// <summary>
		/// The RejectReason
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string rejectReason;

			/// <summary>
		/// The QuotedDirectPayTime
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string quotedDirectPayTime;

			/// <summary>
		/// The OperatorID
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? operatorId;

			/// <summary>
		/// The Templateid
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        private SourceTypeEntity template;

			/// <summary>
		/// The ContactPhone
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string contactPhone;

			/// <summary>
		/// The Contact
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string contact;

			/// <summary>
		/// The Gender
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string gender;

			/// <summary>
		/// The Tel
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string tel;

			/// <summary>
		/// The InvoiceRequired
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private bool? invoiceRequired;

			/// <summary>
		/// The SupplierID
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? supplierId;

			/// <summary>
		/// The InvoiceTitle
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string invoiceTitle;

			/// <summary>
		/// The PackagingFee
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private decimal? packagingFee;

			/// <summary>
		/// The DeliverCharge
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private decimal? deliverCharge;

			/// <summary>
		/// The DeliverSourcs
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private byte? deliverSourcs;

			/// <summary>
		/// The SendingPersonID
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? sendingPersonId;

			/// <summary>
		/// The LogisticsTakeFoodTime
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private DateTime? logisticsTakeFoodTime;

			/// <summary>
		/// The OrderNumber
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? orderNumber;

			/// <summary>
		/// The CustomerTotal
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private decimal? customerTotal;

			/// <summary>
		/// The CCdiscount
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private decimal? cCdiscount;

			/// <summary>
		/// The ActualSendTime
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private DateTime? actualSendTime;

			/// <summary>
		/// The ReceivablePrice
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private decimal? receivablePrice;

			/// <summary>
		/// The RealUserPrice
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private decimal? realUserPrice;

			/// <summary>
		/// The RealSupplierPrice
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private decimal? realSupplierPrice;

			/// <summary>
		/// The RealSupplierType
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private byte? realSupplierType;

			/// <summary>
		/// The IsTakeInvoice
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private bool? isTakeInvoice;

			/// <summary>
		/// The AddedTime
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private DateTime? addedTime;

			/// <summary>
		/// The CheckStatus
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private byte? checkStatus;

			/// <summary>
		/// The HandOverStatus
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private byte? handOverStatus;

			/// <summary>
		/// The Lat
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private double? lat;

			/// <summary>
		/// The Lng
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private double? lng;

			/// <summary>
		/// The LogisticsId
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string logisticsId;

			/// <summary>
		/// The ModifyDate
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private DateTime? modifyDate;

			/// <summary>
		/// The EtsTakeFoodAmount
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private decimal? etsTakeFoodAmount;

			/// <summary>
		/// The EtsActualTakeFoodAmount
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private decimal? etsActualTakeFoodAmount;

			/// <summary>
		/// The TaxPointAmount
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private decimal? taxPointAmount;

			/// <summary>
		/// The AreaId
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? areaId;

			/// <summary>
		/// The CashPay
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private decimal? cashPay;

			/// <summary>
		/// The NetWorkPay
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private decimal? netWorkPay;

			/// <summary>
		/// The PosPay
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private decimal? posPay;

			/// <summary>
		/// The StoreCardPaySup
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private decimal? storeCardPaySup;

			/// <summary>
		/// The Path
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        private SourcePathEntity path;

			/// <summary>
		/// The DirectPayDistance
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private double directPayDistance;

			/// <summary>
		/// The LogisSendTime
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private DateTime? logisSendTime;

			/// <summary>
		/// The NumOfPeople
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? numOfPeople;

			/// <summary>
		/// The NumOfCutlery
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? numOfCutlery;

			/// <summary>
		/// The ServiceFee
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private decimal? serviceFee;

			/// <summary>
		/// The Pot
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? pot;

			/// <summary>
		/// The Stove
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? stove;

			/// <summary>
		/// The ZBGD
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? zBGD;

			/// <summary>
		/// The ZBXL
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? zBXL;

			/// <summary>
		/// The PrintState
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private bool? printState;

			/// <summary>
		/// The CcName
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string ccName;

			/// <summary>
		/// The DirectPayDiscount
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private decimal? directPayDiscount;

			/// <summary>
		/// The ReprintState
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private bool? reprintState;

			/// <summary>
		/// The PaymentDirectList
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private IList<PaymentDirectEntity> paymentDirectList;

		#endregion

		/// <summary>
        /// Initializes a new instance of the <see cref="DirectPayEntity"/> class.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public DirectPayEntity()
        {
			this.directPayId = 0;
			this.customerId = 0;
			this.orderStatusId = 0;
			this.directPayInstruction = string.Empty;
			this.iPAddress = string.Empty;
			this.orderNotes = string.Empty;
			this.rejectReason = string.Empty;
			this.quotedDirectPayTime = string.Empty;
			this.contactPhone = string.Empty;
			this.contact = string.Empty;
			this.gender = string.Empty;
			this.tel = string.Empty;
			this.invoiceTitle = string.Empty;
			this.logisticsId = string.Empty;
			this.directPayDistance = -1;
			this.ccName = string.Empty;
		}

		#region public member

			/// <summary>
        /// Gets or sets a value mapping the DirectPayID of DirectPayEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
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
        /// Gets or sets a value mapping the CustomerID of DirectPayEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
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
        /// Gets or sets a value mapping the OrderStatusID of DirectPayEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
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
        /// Gets or sets a value mapping the DirectPayMethodID of DirectPayEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? DirectPayMethodId
		{
            get
            {
                return this.directPayMethodId;
            }

            set
            {
                this.directPayMethodId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the DirectPayAddressID of DirectPayEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? DirectPayAddressId
		{
            get
            {
                return this.directPayAddressId;
            }

            set
            {
                this.directPayAddressId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the DirectPayZoneID of DirectPayEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? DirectPayZoneId
		{
            get
            {
                return this.directPayZoneId;
            }

            set
            {
                this.directPayZoneId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the CouponID of DirectPayEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
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
        /// Gets or sets a value mapping the Total of DirectPayEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
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
        /// Gets or sets a value indicating whether mapping the IsPaid of DirectPayEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
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
        /// Gets or sets a value indicating whether mapping the Cancelled of DirectPayEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
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
        /// Gets or sets a value mapping the DirectPayDate of DirectPayEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual DateTime? DirectPayDate
		{
            get
            {
                return this.directPayDate;
            }

            set
            {
                this.directPayDate = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the DirectPayInstruction of DirectPayEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string DirectPayInstruction
		{
            get
            {
                return this.directPayInstruction;
            }

            set
            {
                this.directPayInstruction = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the DateAdded of DirectPayEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
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
        /// Gets or sets a value mapping the IPAddress of DirectPayEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
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
        /// Gets or sets a value indicating whether mapping the IsRating of DirectPayEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
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
        /// Gets or sets a value mapping the OrderNotes of DirectPayEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
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
        /// Gets or sets a value mapping the RejectReason of DirectPayEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
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
        /// Gets or sets a value mapping the QuotedDirectPayTime of DirectPayEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string QuotedDirectPayTime
		{
            get
            {
                return this.quotedDirectPayTime;
            }

            set
            {
                this.quotedDirectPayTime = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the OperatorID of DirectPayEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
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
        /// Gets or sets a value mapping the Templateid of DirectPayEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
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
        /// Gets or sets a value mapping the ContactPhone of DirectPayEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
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
        /// Gets or sets a value mapping the Contact of DirectPayEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
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
        /// Gets or sets a value mapping the Gender of DirectPayEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
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
        /// Gets or sets a value mapping the Tel of DirectPayEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
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
        /// Gets or sets a value indicating whether mapping the InvoiceRequired of DirectPayEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
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
        /// Gets or sets a value mapping the SupplierID of DirectPayEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
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
        /// Gets or sets a value mapping the InvoiceTitle of DirectPayEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
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
        /// Gets or sets a value mapping the PackagingFee of DirectPayEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
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
        /// Gets or sets a value mapping the DeliverCharge of DirectPayEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
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
        /// Gets or sets a value mapping the DeliverSourcs of DirectPayEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
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
        /// Gets or sets a value mapping the SendingPersonID of DirectPayEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
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
        /// Gets or sets a value mapping the LogisticsTakeFoodTime of DirectPayEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
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
        /// Gets or sets a value mapping the OrderNumber of DirectPayEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
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
        /// Gets or sets a value mapping the CustomerTotal of DirectPayEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
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
        /// Gets or sets a value mapping the CCdiscount of DirectPayEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
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
        /// Gets or sets a value mapping the ActualSendTime of DirectPayEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
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
        /// Gets or sets a value mapping the ReceivablePrice of DirectPayEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
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
        /// Gets or sets a value mapping the RealUserPrice of DirectPayEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
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
        /// Gets or sets a value mapping the RealSupplierPrice of DirectPayEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
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
        /// Gets or sets a value mapping the RealSupplierType of DirectPayEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
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
        /// Gets or sets a value indicating whether mapping the IsTakeInvoice of DirectPayEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
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
        /// Gets or sets a value mapping the AddedTime of DirectPayEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
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
        /// Gets or sets a value mapping the CheckStatus of DirectPayEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
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
        /// Gets or sets a value mapping the HandOverStatus of DirectPayEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
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
        /// Gets or sets a value mapping the Lat of DirectPayEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
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
        /// Gets or sets a value mapping the Lng of DirectPayEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
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
        /// Gets or sets a value mapping the LogisticsId of DirectPayEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
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
        /// Gets or sets a value mapping the ModifyDate of DirectPayEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
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
        /// Gets or sets a value mapping the EtsTakeFoodAmount of DirectPayEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
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
        /// Gets or sets a value mapping the EtsActualTakeFoodAmount of DirectPayEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
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
        /// Gets or sets a value mapping the TaxPointAmount of DirectPayEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
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
        /// Gets or sets a value mapping the AreaId of DirectPayEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
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
        /// Gets or sets a value mapping the CashPay of DirectPayEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
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
        /// Gets or sets a value mapping the NetWorkPay of DirectPayEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
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
        /// Gets or sets a value mapping the PosPay of DirectPayEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
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
        /// Gets or sets a value mapping the StoreCardPaySup of DirectPayEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
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
        /// Gets or sets a value mapping the Path of DirectPayEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
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
        /// Gets or sets a value mapping the DirectPayDistance of DirectPayEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual double DirectPayDistance
		{
            get
            {
                return this.directPayDistance;
            }

            set
            {
                this.directPayDistance = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the LogisSendTime of DirectPayEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
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
        /// Gets or sets a value mapping the NumOfPeople of DirectPayEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? NumOfPeople
		{
            get
            {
                return this.numOfPeople;
            }

            set
            {
                this.numOfPeople = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the NumOfCutlery of DirectPayEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? NumOfCutlery
		{
            get
            {
                return this.numOfCutlery;
            }

            set
            {
                this.numOfCutlery = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the ServiceFee of DirectPayEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual decimal? ServiceFee
		{
            get
            {
                return this.serviceFee;
            }

            set
            {
                this.serviceFee = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Pot of DirectPayEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? Pot
		{
            get
            {
                return this.pot;
            }

            set
            {
                this.pot = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Stove of DirectPayEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? Stove
		{
            get
            {
                return this.stove;
            }

            set
            {
                this.stove = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the ZBGD of DirectPayEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? ZBGD
		{
            get
            {
                return this.zBGD;
            }

            set
            {
                this.zBGD = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the ZBXL of DirectPayEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? ZBXL
		{
            get
            {
                return this.zBXL;
            }

            set
            {
                this.zBXL = value;
            }
        }

			/// <summary>
        /// Gets or sets a value indicating whether mapping the PrintState of DirectPayEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual bool? PrintState
		{
            get
            {
                return this.printState;
            }

            set
            {
                this.printState = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the CcName of DirectPayEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string CcName
		{
            get
            {
                return this.ccName;
            }

            set
            {
                this.ccName = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the DirectPayDiscount of DirectPayEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual decimal? DirectPayDiscount
		{
            get
            {
                return this.directPayDiscount;
            }

            set
            {
                this.directPayDiscount = value;
            }
        }

			/// <summary>
        /// Gets or sets a value indicating whether mapping the ReprintState of DirectPayEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual bool? ReprintState
		{
            get
            {
                return this.reprintState;
            }

            set
            {
                this.reprintState = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the PaymentDirectList of DirectPayEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
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

		#endregion

			/// <summary>
        /// Determines whether the specified is equal to this instance.
        /// </summary>
        /// <param name="obj">The to compare with this instance.</param>
        /// <returns>
        /// true if the specified is equal to this instance; otherwise,false.
        /// </returns>
        /// Creator:ww
        /// Creation Date:2014/4/29 17:05:44
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
        /// Creation Date:2014/4/29 17:05:44
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