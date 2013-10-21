// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TableReservationEntity.cs" company="Irdeto">
//   Copyright @ 2013
// </copyright>
// <summary>
//   Class:TableReservationEntity
//   Namespace:Ets.SingleApi.Model.Repository
//   Class Funtion:Represent the class mapping the TableReservationEntity table in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ets.SingleApi.Model.Repository
{
	using System;
		
    /// <summary>
    /// Class:TableReservationEntity
    /// Namespace:Ets.SingleApi.Model.Repository
    /// Class Funtion:Represent the class mapping the TableReservationEntity table in the database.
    /// </summary>
    /// Creator:周超
    /// Creation Date:2013/10/13 14:01:31
    /// Modifier:
    /// Last Modified:
    /// ----------------------------------------------------------------------------------------
    [Serializable]
    public class TableReservationEntity
    {
		#region private member

			/// <summary>
		/// The TableReservationID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int tableReservationId;

			/// <summary>
		/// The TableID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int tableId;

			/// <summary>
		/// The CustomerID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int customerId;

			/// <summary>
		/// The Templateid
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string templateId;

			/// <summary>
		/// The NumberOfPeople
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int numberOfPeople;

			/// <summary>
		/// The ContactName
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string contactName;

			/// <summary>
		/// The ContactNumber
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string contactNumber;

			/// <summary>
		/// The ReservationTime
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private DateTime reservationTime;

			/// <summary>
		/// The DateReserved
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private DateTime dateReserved;

			/// <summary>
		/// The BookInstruction
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string bookInstruction;

			/// <summary>
		/// The PaymentID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? paymentId;

			/// <summary>
		/// The Cancelled
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private bool? cancelled;

			/// <summary>
		/// The Refunded
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private bool? refunded;

			/// <summary>
		/// The IsRating
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private bool? isRating;

			/// <summary>
		/// The BookSource
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? bookSource;

			/// <summary>
		/// The EndOccupancyTime
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private DateTime endOccupancyTime;

			/// <summary>
		/// The OrderNotes
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string orderNotes;

			/// <summary>
		/// The OperatorID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? operatorId;

			/// <summary>
		/// The Sitcondition
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string sitcondition;

			/// <summary>
		/// The Roomprice
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? roomprice;

			/// <summary>
		/// The Contactsex
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string contactsex;

			/// <summary>
		/// The IsTableForOther
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private bool? isTableForOther;

			/// <summary>
		/// The TableForOtherName
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string tableForOtherName;

			/// <summary>
		/// The TableForOtherType
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string tableForOtherType;

			/// <summary>
		/// The Notes
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string notes;

			/// <summary>
		/// The ForOthers
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private bool? forOthers;

			/// <summary>
		/// The DinerName
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string dinerName;

			/// <summary>
		/// The DinerTypeID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? dinerTypeId;

			/// <summary>
		/// The SeatRequirementID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? seatRequirementId;

			/// <summary>
		/// The RoomTypeID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? roomTypeId;

			/// <summary>
		/// The RealPeople
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? realPeople;

			/// <summary>
		/// The RealSpendMoney
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private decimal? realSpendMoney;

			/// <summary>
		/// The TableStatus
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? tableStatus;

			/// <summary>
		/// The OrderNumber
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? orderNumber;

			/// <summary>
		/// The ActualFinishTime
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private DateTime? actualFinishTime;

			/// <summary>
		/// The Total
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private decimal? total;

			/// <summary>
		/// The CustomerTotal
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private decimal? customerTotal;

			/// <summary>
		/// The IsPaid
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private bool? isPaId;

			/// <summary>
		/// The InvoiceRequired
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private bool? invoiceRequired;

			/// <summary>
		/// The InvoiceTitle
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string invoiceTitle;

			/// <summary>
		/// The DineNumber
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? dineNumber;

			/// <summary>
		/// The TabelNo
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string tabelNo;

			/// <summary>
		/// The ServerNo
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string serverNo;

			/// <summary>
		/// The ValidateType
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? valIdateType;

			/// <summary>
		/// The ValidateCode
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string valIdateCode;

			/// <summary>
		/// The InvoiceType
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? invoiceType;

			/// <summary>
		/// The Type
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? type;

			/// <summary>
		/// The ModifyDate
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private DateTime? modifyDate;

			/// <summary>
		/// The ArravieTime
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private DateTime? arravieTime;

			/// <summary>
		/// The LeavelTime
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private DateTime? leavelTime;

			/// <summary>
		/// The IsReminder
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private bool? isReminder;

			/// <summary>
		/// The IsDeal
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private bool? isDeal;

			/// <summary>
		/// The IsService
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private bool? isService;

			/// <summary>
		/// The IsAdd
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private bool? isAdd;

			/// <summary>
		/// The AddTime
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private DateTime? addTime;

			/// <summary>
		/// The OrderPwd
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string orderPwd;

			/// <summary>
		/// The ConsumerAmount
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private decimal? consumerAmount;

			/// <summary>
		/// The TeaBitFee
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private decimal? teaBitFee;

			/// <summary>
		/// The IsupdateAmount
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private bool isupdateAmount;

			/// <summary>
		/// The PointCouponsNumber
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? pointCouponsNumber;

			/// <summary>
		/// The IsOnTime
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private bool isOnTime;

			/// <summary>
		/// The DirectPointCouponsNumber
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private decimal? directPointCouponsNumber;

			/// <summary>
		/// The OrderTableName
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string orderTableName;

			/// <summary>
		/// The Path
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string path;

			/// <summary>
		/// The UserStatus
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? userStatus;

			/// <summary>
		/// The SupplierID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private SupplierEntity supplier;

		#endregion

		/// <summary>
        /// Initializes a new instance of the <see cref="TableReservationEntity"/> class.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public TableReservationEntity()
        {
			this.tableReservationId = 0;
			this.tableId = 0;
			this.customerId = 0;
			this.templateId = string.Empty;
			this.numberOfPeople = 0;
			this.contactName = string.Empty;
			this.contactNumber = string.Empty;
			this.reservationTime = DateTime.Now;
			this.dateReserved = DateTime.Now;
			this.bookInstruction = string.Empty;
			this.endOccupancyTime = DateTime.Now;
			this.orderNotes = string.Empty;
			this.sitcondition = string.Empty;
			this.contactsex = string.Empty;
			this.tableForOtherName = string.Empty;
			this.tableForOtherType = string.Empty;
			this.notes = string.Empty;
			this.dinerName = string.Empty;
			this.invoiceTitle = string.Empty;
			this.tabelNo = string.Empty;
			this.serverNo = string.Empty;
			this.valIdateCode = string.Empty;
			this.orderPwd = string.Empty;
			this.isupdateAmount = false;
			this.isOnTime = false;
			this.orderTableName = string.Empty;
			this.path = @"Other";
		}

		#region public member

			/// <summary>
        /// Gets or sets a value mapping the TableReservationID of TableReservationEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int TableReservationId
		{
            get
            {
                return this.tableReservationId;
            }

            set
            {
                this.tableReservationId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the TableID of TableReservationEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int TableId
		{
            get
            {
                return this.tableId;
            }

            set
            {
                this.tableId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the CustomerID of TableReservationEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
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
        /// Gets or sets a value mapping the Templateid of TableReservationEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string TemplateId
		{
            get
            {
                return this.templateId;
            }

            set
            {
                this.templateId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the NumberOfPeople of TableReservationEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int NumberOfPeople
		{
            get
            {
                return this.numberOfPeople;
            }

            set
            {
                this.numberOfPeople = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the ContactName of TableReservationEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
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
        /// Gets or sets a value mapping the ContactNumber of TableReservationEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string ContactNumber
		{
            get
            {
                return this.contactNumber;
            }

            set
            {
                this.contactNumber = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the ReservationTime of TableReservationEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual DateTime ReservationTime
		{
            get
            {
                return this.reservationTime;
            }

            set
            {
                this.reservationTime = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the DateReserved of TableReservationEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual DateTime DateReserved
		{
            get
            {
                return this.dateReserved;
            }

            set
            {
                this.dateReserved = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the BookInstruction of TableReservationEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string BookInstruction
		{
            get
            {
                return this.bookInstruction;
            }

            set
            {
                this.bookInstruction = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the PaymentID of TableReservationEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? PaymentId
		{
            get
            {
                return this.paymentId;
            }

            set
            {
                this.paymentId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value indicating whether mapping the Cancelled of TableReservationEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
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
        /// Gets or sets a value indicating whether mapping the Refunded of TableReservationEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual bool? Refunded
		{
            get
            {
                return this.refunded;
            }

            set
            {
                this.refunded = value;
            }
        }

			/// <summary>
        /// Gets or sets a value indicating whether mapping the IsRating of TableReservationEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
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
        /// Gets or sets a value mapping the BookSource of TableReservationEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? BookSource
		{
            get
            {
                return this.bookSource;
            }

            set
            {
                this.bookSource = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the EndOccupancyTime of TableReservationEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual DateTime EndOccupancyTime
		{
            get
            {
                return this.endOccupancyTime;
            }

            set
            {
                this.endOccupancyTime = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the OrderNotes of TableReservationEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
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
        /// Gets or sets a value mapping the OperatorID of TableReservationEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
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
        /// Gets or sets a value mapping the Sitcondition of TableReservationEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string Sitcondition
		{
            get
            {
                return this.sitcondition;
            }

            set
            {
                this.sitcondition = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Roomprice of TableReservationEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? Roomprice
		{
            get
            {
                return this.roomprice;
            }

            set
            {
                this.roomprice = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Contactsex of TableReservationEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string Contactsex
		{
            get
            {
                return this.contactsex;
            }

            set
            {
                this.contactsex = value;
            }
        }

			/// <summary>
        /// Gets or sets a value indicating whether mapping the IsTableForOther of TableReservationEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual bool? IsTableForOther
		{
            get
            {
                return this.isTableForOther;
            }

            set
            {
                this.isTableForOther = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the TableForOtherName of TableReservationEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string TableForOtherName
		{
            get
            {
                return this.tableForOtherName;
            }

            set
            {
                this.tableForOtherName = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the TableForOtherType of TableReservationEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string TableForOtherType
		{
            get
            {
                return this.tableForOtherType;
            }

            set
            {
                this.tableForOtherType = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Notes of TableReservationEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string Notes
		{
            get
            {
                return this.notes;
            }

            set
            {
                this.notes = value;
            }
        }

			/// <summary>
        /// Gets or sets a value indicating whether mapping the ForOthers of TableReservationEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual bool? ForOthers
		{
            get
            {
                return this.forOthers;
            }

            set
            {
                this.forOthers = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the DinerName of TableReservationEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string DinerName
		{
            get
            {
                return this.dinerName;
            }

            set
            {
                this.dinerName = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the DinerTypeID of TableReservationEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? DinerTypeId
		{
            get
            {
                return this.dinerTypeId;
            }

            set
            {
                this.dinerTypeId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the SeatRequirementID of TableReservationEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? SeatRequirementId
		{
            get
            {
                return this.seatRequirementId;
            }

            set
            {
                this.seatRequirementId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the RoomTypeID of TableReservationEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? RoomTypeId
		{
            get
            {
                return this.roomTypeId;
            }

            set
            {
                this.roomTypeId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the RealPeople of TableReservationEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? RealPeople
		{
            get
            {
                return this.realPeople;
            }

            set
            {
                this.realPeople = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the RealSpendMoney of TableReservationEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual decimal? RealSpendMoney
		{
            get
            {
                return this.realSpendMoney;
            }

            set
            {
                this.realSpendMoney = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the TableStatus of TableReservationEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? TableStatus
		{
            get
            {
                return this.tableStatus;
            }

            set
            {
                this.tableStatus = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the OrderNumber of TableReservationEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
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
        /// Gets or sets a value mapping the ActualFinishTime of TableReservationEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual DateTime? ActualFinishTime
		{
            get
            {
                return this.actualFinishTime;
            }

            set
            {
                this.actualFinishTime = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Total of TableReservationEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
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
        /// Gets or sets a value mapping the CustomerTotal of TableReservationEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
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
        /// Gets or sets a value indicating whether mapping the IsPaid of TableReservationEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
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
        /// Gets or sets a value indicating whether mapping the InvoiceRequired of TableReservationEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
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
        /// Gets or sets a value mapping the InvoiceTitle of TableReservationEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
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
        /// Gets or sets a value mapping the DineNumber of TableReservationEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? DineNumber
		{
            get
            {
                return this.dineNumber;
            }

            set
            {
                this.dineNumber = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the TabelNo of TableReservationEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string TabelNo
		{
            get
            {
                return this.tabelNo;
            }

            set
            {
                this.tabelNo = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the ServerNo of TableReservationEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string ServerNo
		{
            get
            {
                return this.serverNo;
            }

            set
            {
                this.serverNo = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the ValidateType of TableReservationEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? ValIdateType
		{
            get
            {
                return this.valIdateType;
            }

            set
            {
                this.valIdateType = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the ValidateCode of TableReservationEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string ValIdateCode
		{
            get
            {
                return this.valIdateCode;
            }

            set
            {
                this.valIdateCode = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the InvoiceType of TableReservationEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? InvoiceType
		{
            get
            {
                return this.invoiceType;
            }

            set
            {
                this.invoiceType = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Type of TableReservationEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? Type
		{
            get
            {
                return this.type;
            }

            set
            {
                this.type = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the ModifyDate of TableReservationEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
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
        /// Gets or sets a value mapping the ArravieTime of TableReservationEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual DateTime? ArravieTime
		{
            get
            {
                return this.arravieTime;
            }

            set
            {
                this.arravieTime = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the LeavelTime of TableReservationEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual DateTime? LeavelTime
		{
            get
            {
                return this.leavelTime;
            }

            set
            {
                this.leavelTime = value;
            }
        }

			/// <summary>
        /// Gets or sets a value indicating whether mapping the IsReminder of TableReservationEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual bool? IsReminder
		{
            get
            {
                return this.isReminder;
            }

            set
            {
                this.isReminder = value;
            }
        }

			/// <summary>
        /// Gets or sets a value indicating whether mapping the IsDeal of TableReservationEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual bool? IsDeal
		{
            get
            {
                return this.isDeal;
            }

            set
            {
                this.isDeal = value;
            }
        }

			/// <summary>
        /// Gets or sets a value indicating whether mapping the IsService of TableReservationEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual bool? IsService
		{
            get
            {
                return this.isService;
            }

            set
            {
                this.isService = value;
            }
        }

			/// <summary>
        /// Gets or sets a value indicating whether mapping the IsAdd of TableReservationEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
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
        /// Gets or sets a value mapping the AddTime of TableReservationEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual DateTime? AddTime
		{
            get
            {
                return this.addTime;
            }

            set
            {
                this.addTime = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the OrderPwd of TableReservationEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string OrderPwd
		{
            get
            {
                return this.orderPwd;
            }

            set
            {
                this.orderPwd = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the ConsumerAmount of TableReservationEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual decimal? ConsumerAmount
		{
            get
            {
                return this.consumerAmount;
            }

            set
            {
                this.consumerAmount = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the TeaBitFee of TableReservationEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual decimal? TeaBitFee
		{
            get
            {
                return this.teaBitFee;
            }

            set
            {
                this.teaBitFee = value;
            }
        }

			/// <summary>
        /// Gets or sets a value indicating whether mapping the IsupdateAmount of TableReservationEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual bool IsupdateAmount
		{
            get
            {
                return this.isupdateAmount;
            }

            set
            {
                this.isupdateAmount = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the PointCouponsNumber of TableReservationEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? PointCouponsNumber
		{
            get
            {
                return this.pointCouponsNumber;
            }

            set
            {
                this.pointCouponsNumber = value;
            }
        }

			/// <summary>
        /// Gets or sets a value indicating whether mapping the IsOnTime of TableReservationEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual bool IsOnTime
		{
            get
            {
                return this.isOnTime;
            }

            set
            {
                this.isOnTime = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the DirectPointCouponsNumber of TableReservationEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual decimal? DirectPointCouponsNumber
		{
            get
            {
                return this.directPointCouponsNumber;
            }

            set
            {
                this.directPointCouponsNumber = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the OrderTableName of TableReservationEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string OrderTableName
		{
            get
            {
                return this.orderTableName;
            }

            set
            {
                this.orderTableName = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Path of TableReservationEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string Path
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
        /// Gets or sets a value mapping the UserStatus of TableReservationEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? UserStatus
		{
            get
            {
                return this.userStatus;
            }

            set
            {
                this.userStatus = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the SupplierID of TableReservationEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual SupplierEntity Supplier
		{
            get
            {
                return this.supplier;
            }

            set
            {
                this.supplier = value;
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
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public override bool Equals(object obj)
        {
            if (obj == null || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }

            var castObj = (TableReservationEntity)obj;
            return this.TableReservationId == castObj.TableReservationId;
        }

		/// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public override int GetHashCode()
		{
			var hash = 57; 
			hash = 27 * hash * this.TableReservationId.GetHashCode();
			return hash;
		}
	}
}