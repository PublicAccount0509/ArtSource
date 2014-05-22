﻿// --------------------------------------------------------------------------------------------------------------------
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
    /// Creator:周超
    /// Creation Date:2014/3/24 13:15:36
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
        /// Creator:周超
        /// Creation Date:2014/3/24 13:15:37
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        private int queueId;

        /// <summary>
        /// The Time
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/3/24 13:15:37
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        private DateTime time;

        /// <summary>
        /// The UserName
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/3/24 13:15:37
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        private string userName;

        /// <summary>
        /// The Phone
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/3/24 13:15:37
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        private string phone;

        /// <summary>
        /// The SeatNumber
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/3/24 13:15:37
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        private int seatNumber;

        /// <summary>
        /// The Remark
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/3/24 13:15:37
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        private string remark;

        /// <summary>
        /// The State
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/3/24 13:15:37
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        private int state;

        /// <summary>
        /// The SupplierID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/3/24 13:15:37
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        private int supplierId;

        /// <summary>
        /// The SupplierName
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/3/24 13:15:37
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        private string supplierName;

        /// <summary>
        /// The Number
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/3/24 13:15:37
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        private string number;

        /// <summary>
        /// The AppNumber
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/3/24 13:15:37
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        private int? appNumber;

        /// <summary>
        /// The PhoneNumber
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/3/24 13:15:37
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        private int? phoneNumber;

        /// <summary>
        /// The AndroidIS
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/3/24 13:15:37
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        private int? androIdIS;

        /// <summary>
        /// The AlertNumber
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/3/24 13:15:37
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        private int? alertNumber;

        /// <summary>
        /// The Sex
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/3/24 13:15:37
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        private int? sex;

        /// <summary>
        /// The SupplierEmployeeID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/3/24 13:15:37
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        private int? supplierEmployeeId;

        /// <summary>
        /// The Code
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/3/24 13:15:37
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        private string code;

        /// <summary>
        /// The DeskTypeId
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/3/24 13:15:37
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        private int? deskTypeId;

        /// <summary>
        /// The CustomerId
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/3/24 13:15:37
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        private int? customerId;

        /// <summary>
        /// The Path
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/3/24 13:15:37
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        private string path;

        /// <summary>
        /// The TemplateId
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/3/24 13:15:37
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        private string templateId;

        /// <summary>
        /// The Cancelled
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-19 10:43:10
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        private bool? cancelled;

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="QueueEntity"/> class.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/3/24 13:15:37
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
            this.path = string.Empty;
            this.templateId = string.Empty;
            this.cancelled = false;
        }

        #region public member

        /// <summary>
        /// Gets or sets a value mapping the QueueID of QueueEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/3/24 13:15:37
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
        /// Creator:周超
        /// Creation Date:2014/3/24 13:15:37
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
        /// Creator:周超
        /// Creation Date:2014/3/24 13:15:37
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
        /// Creator:周超
        /// Creation Date:2014/3/24 13:15:37
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
        /// Creator:周超
        /// Creation Date:2014/3/24 13:15:37
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
        /// Creator:周超
        /// Creation Date:2014/3/24 13:15:37
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
        /// Creator:周超
        /// Creation Date:2014/3/24 13:15:37
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
        /// Creator:周超
        /// Creation Date:2014/3/24 13:15:37
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
        /// Creator:周超
        /// Creation Date:2014/3/24 13:15:37
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
        /// Creator:周超
        /// Creation Date:2014/3/24 13:15:37
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
        /// Creator:周超
        /// Creation Date:2014/3/24 13:15:37
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
        /// Creator:周超
        /// Creation Date:2014/3/24 13:15:37
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
        /// Creator:周超
        /// Creation Date:2014/3/24 13:15:37
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
        /// Creator:周超
        /// Creation Date:2014/3/24 13:15:37
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
        /// Creator:周超
        /// Creation Date:2014/3/24 13:15:37
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
        /// Creator:周超
        /// Creation Date:2014/3/24 13:15:37
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
        /// Creator:周超
        /// Creation Date:2014/3/24 13:15:37
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
        /// Creator:周超
        /// Creation Date:2014/3/24 13:15:37
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

        /// <summary>
        /// Gets or sets a value mapping the CustomerId of QueueEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/3/24 13:15:37
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
        /// Gets or sets a value mapping the Path of QueueEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/3/24 13:15:37
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
        /// Gets or sets a value mapping the TemplateId of QueueEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/3/24 13:15:37
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
        /// Gets or sets a value indicating whether mapping the Cancelled of TableReservationEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-19 10:43:10
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

        #endregion

        /// <summary>
        /// Determines whether the specified is equal to this instance.
        /// </summary>
        /// <param name="obj">The to compare with this instance.</param>
        /// <returns>
        /// true if the specified is equal to this instance; otherwise,false.
        /// </returns>
        /// Creator:周超
        /// Creation Date:2014/3/24 13:15:37
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
        /// Creator:周超
        /// Creation Date:2014/3/24 13:15:38
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