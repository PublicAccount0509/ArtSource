// --------------------------------------------------------------------------------------------------------------------
// <copyright file="QueueEntity.cs" company="Irdeto">
//   Copyright @ 2014
// </copyright>
// <summary>
//   Class:QueueEntity
//   Namespace:Ets.SingleApi.Model.Repository
//   Class Funtion:Represent the class mapping the QueueEntity table in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ets.SingleApi.Model.Repository
{
	using System;
		
    /// <summary>
    /// Class:QueueEntity
    /// Namespace:Ets.SingleApi.Model.Repository
    /// Class Funtion:Represent the class mapping the QueueEntity table in the database.
    /// </summary>
    /// Creator:ww
    /// Creation Date:2014-3-20 16:37:43
    /// Modifier:
    /// Last Modified:
    /// ----------------------------------------------------------------------------------------
    [Serializable]
    public class QueueEntity
    {
		#region private member

			/// <summary>
		/// The QueueID
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-20 16:37:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int queueId;

			/// <summary>
		/// The Time
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-20 16:37:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private DateTime time;

			/// <summary>
		/// The UserName
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-20 16:37:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string userName;

			/// <summary>
		/// The Phone
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-20 16:37:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string phone;

			/// <summary>
		/// The SeatNumber
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-20 16:37:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int seatNumber;

			/// <summary>
		/// The Remark
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-20 16:37:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string remark;

			/// <summary>
		/// The State
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-20 16:37:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int state;

			/// <summary>
		/// The SupplierID
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-20 16:37:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int supplierId;

			/// <summary>
		/// The SupplierName
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-20 16:37:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string supplierName;

			/// <summary>
		/// The Number
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-20 16:37:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string number;

			/// <summary>
		/// The AppNumber
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-20 16:37:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? appNumber;

			/// <summary>
		/// The PhoneNumber
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-20 16:37:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? phoneNumber;

			/// <summary>
		/// The AndroidIS
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-20 16:37:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? androIdIS;

			/// <summary>
		/// The AlertNumber
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-20 16:37:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? alertNumber;

			/// <summary>
		/// The Sex
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-20 16:37:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? sex;

			/// <summary>
		/// The SupplierEmployeeID
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-20 16:37:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? supplierEmployeeId;

			/// <summary>
		/// The Code
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-20 16:37:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string code;

			/// <summary>
		/// The DeskTypeId
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-20 16:37:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? deskTypeId;

		#endregion

		/// <summary>
        /// Initializes a new instance of the <see cref="QueueEntity"/> class.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-20 16:37:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public QueueEntity()
        {
			this.queueId = 0;
			this.time = DateTime.Now;
			this.userName = string.Empty;
			this.phone = string.Empty;
			this.seatNumber = 0;
			this.remark = string.Empty;
			this.state = 0;
			this.supplierId = 0;
			this.supplierName = string.Empty;
			this.number = string.Empty;
			this.code = string.Empty;
		}

		#region public member

			/// <summary>
        /// Gets or sets a value mapping the QueueID of QueueEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-20 16:37:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int QueueId
		{
            get
            {
                return this.queueId;
            }

            set
            {
                this.queueId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Time of QueueEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-20 16:37:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual DateTime Time
		{
            get
            {
                return this.time;
            }

            set
            {
                this.time = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the UserName of QueueEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-20 16:37:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string UserName
		{
            get
            {
                return this.userName;
            }

            set
            {
                this.userName = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Phone of QueueEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-20 16:37:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string Phone
		{
            get
            {
                return this.phone;
            }

            set
            {
                this.phone = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the SeatNumber of QueueEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-20 16:37:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int SeatNumber
		{
            get
            {
                return this.seatNumber;
            }

            set
            {
                this.seatNumber = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Remark of QueueEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-20 16:37:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string Remark
		{
            get
            {
                return this.remark;
            }

            set
            {
                this.remark = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the State of QueueEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-20 16:37:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int State
		{
            get
            {
                return this.state;
            }

            set
            {
                this.state = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the SupplierID of QueueEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-20 16:37:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int SupplierId
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
        /// Gets or sets a value mapping the SupplierName of QueueEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-20 16:37:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string SupplierName
		{
            get
            {
                return this.supplierName;
            }

            set
            {
                this.supplierName = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Number of QueueEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-20 16:37:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string Number
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
        /// Gets or sets a value mapping the AppNumber of QueueEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-20 16:37:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? AppNumber
		{
            get
            {
                return this.appNumber;
            }

            set
            {
                this.appNumber = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the PhoneNumber of QueueEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-20 16:37:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? PhoneNumber
		{
            get
            {
                return this.phoneNumber;
            }

            set
            {
                this.phoneNumber = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the AndroidIS of QueueEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-20 16:37:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? AndroIdIS
		{
            get
            {
                return this.androIdIS;
            }

            set
            {
                this.androIdIS = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the AlertNumber of QueueEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-20 16:37:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? AlertNumber
		{
            get
            {
                return this.alertNumber;
            }

            set
            {
                this.alertNumber = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Sex of QueueEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-20 16:37:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? Sex
		{
            get
            {
                return this.sex;
            }

            set
            {
                this.sex = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the SupplierEmployeeID of QueueEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-20 16:37:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? SupplierEmployeeId
		{
            get
            {
                return this.supplierEmployeeId;
            }

            set
            {
                this.supplierEmployeeId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Code of QueueEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-20 16:37:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string Code
		{
            get
            {
                return this.code;
            }

            set
            {
                this.code = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the DeskTypeId of QueueEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-20 16:37:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? DeskTypeId
		{
            get
            {
                return this.deskTypeId;
            }

            set
            {
                this.deskTypeId = value;
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
        /// Creation Date:2014-3-20 16:37:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public override bool Equals(object obj)
        {
            if (obj == null || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }

            var castObj = (QueueEntity)obj;
            return this.QueueId == castObj.QueueId;
        }

		/// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        /// Creator:ww
        /// Creation Date:2014-3-20 16:37:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public override int GetHashCode()
		{
			var hash = 57; 
			hash = 27 * hash * this.QueueId.GetHashCode();
			return hash;
		}
	}
}