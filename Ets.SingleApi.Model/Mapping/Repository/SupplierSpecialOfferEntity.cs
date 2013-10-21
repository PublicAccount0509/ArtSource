// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SupplierSpecialOfferEntity.cs" company="Irdeto">
//   Copyright @ 2013
// </copyright>
// <summary>
//   Class:SupplierSpecialOfferEntity
//   Namespace:Ets.SingleApi.Model.Repository
//   Class Funtion:Represent the class mapping the SupplierSpecialOfferEntity table in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ets.SingleApi.Model.Repository
{
	using System;
		
    /// <summary>
    /// Class:SupplierSpecialOfferEntity
    /// Namespace:Ets.SingleApi.Model.Repository
    /// Class Funtion:Represent the class mapping the SupplierSpecialOfferEntity table in the database.
    /// </summary>
    /// Creator:周超
    /// Creation Date:2013/10/13 14:01:30
    /// Modifier:
    /// Last Modified:
    /// ----------------------------------------------------------------------------------------
    [Serializable]
    public class SupplierSpecialOfferEntity
    {
		#region private member

			/// <summary>
		/// The SupplierSpecialOfferID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int supplierSpecialOfferId;

			/// <summary>
		/// The SpecialOfferTypeID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int specialOfferTypeId;

			/// <summary>
		/// The Title
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string title;

			/// <summary>
		/// The Contents
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string contents;

			/// <summary>
		/// The EndDate
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private DateTime? endDate;

			/// <summary>
		/// The CreateTime
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private DateTime? createTime;

			/// <summary>
		/// The OfferImage
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string offerImage;

			/// <summary>
		/// The Ticket
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string ticket;

			/// <summary>
		/// The Send
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string send;

			/// <summary>
		/// The State
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? state;

			/// <summary>
		/// The OperatorID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? operatorId;

			/// <summary>
		/// The PassTime
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private DateTime? passTime;

			/// <summary>
		/// The Notes
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string notes;

			/// <summary>
		/// The ServiceTypes
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string serviceTypes;

			/// <summary>
		/// The Count
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? count;

			/// <summary>
		/// The StartTime
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private DateTime? startTime;

			/// <summary>
		/// The GroupTypes
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string groupTypes;

			/// <summary>
		/// The SupplierEmployeeId
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? supplierEmployeeId;

			/// <summary>
		/// The SupplierID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private SupplierEntity supplier;

		#endregion

		/// <summary>
        /// Initializes a new instance of the <see cref="SupplierSpecialOfferEntity"/> class.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public SupplierSpecialOfferEntity()
        {
			this.supplierSpecialOfferId = 0;
			this.specialOfferTypeId = 0;
			this.title = string.Empty;
			this.contents = string.Empty;
			this.offerImage = string.Empty;
			this.ticket = string.Empty;
			this.send = string.Empty;
			this.notes = string.Empty;
			this.serviceTypes = string.Empty;
			this.groupTypes = string.Empty;
		}

		#region public member

			/// <summary>
        /// Gets or sets a value mapping the SupplierSpecialOfferID of SupplierSpecialOfferEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int SupplierSpecialOfferId
		{
            get
            {
                return this.supplierSpecialOfferId;
            }

            set
            {
                this.supplierSpecialOfferId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the SpecialOfferTypeID of SupplierSpecialOfferEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int SpecialOfferTypeId
		{
            get
            {
                return this.specialOfferTypeId;
            }

            set
            {
                this.specialOfferTypeId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Title of SupplierSpecialOfferEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string Title
		{
            get
            {
                return this.title;
            }

            set
            {
                this.title = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Contents of SupplierSpecialOfferEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string Contents
		{
            get
            {
                return this.contents;
            }

            set
            {
                this.contents = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the EndDate of SupplierSpecialOfferEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual DateTime? EndDate
		{
            get
            {
                return this.endDate;
            }

            set
            {
                this.endDate = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the CreateTime of SupplierSpecialOfferEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual DateTime? CreateTime
		{
            get
            {
                return this.createTime;
            }

            set
            {
                this.createTime = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the OfferImage of SupplierSpecialOfferEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string OfferImage
		{
            get
            {
                return this.offerImage;
            }

            set
            {
                this.offerImage = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Ticket of SupplierSpecialOfferEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string Ticket
		{
            get
            {
                return this.ticket;
            }

            set
            {
                this.ticket = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Send of SupplierSpecialOfferEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string Send
		{
            get
            {
                return this.send;
            }

            set
            {
                this.send = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the State of SupplierSpecialOfferEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? State
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
        /// Gets or sets a value mapping the OperatorID of SupplierSpecialOfferEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
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
        /// Gets or sets a value mapping the PassTime of SupplierSpecialOfferEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual DateTime? PassTime
		{
            get
            {
                return this.passTime;
            }

            set
            {
                this.passTime = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Notes of SupplierSpecialOfferEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
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
        /// Gets or sets a value mapping the ServiceTypes of SupplierSpecialOfferEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string ServiceTypes
		{
            get
            {
                return this.serviceTypes;
            }

            set
            {
                this.serviceTypes = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Count of SupplierSpecialOfferEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? Count
		{
            get
            {
                return this.count;
            }

            set
            {
                this.count = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the StartTime of SupplierSpecialOfferEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual DateTime? StartTime
		{
            get
            {
                return this.startTime;
            }

            set
            {
                this.startTime = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the GroupTypes of SupplierSpecialOfferEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string GroupTypes
		{
            get
            {
                return this.groupTypes;
            }

            set
            {
                this.groupTypes = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the SupplierEmployeeId of SupplierSpecialOfferEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
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
        /// Gets or sets a value mapping the SupplierID of SupplierSpecialOfferEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
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
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public override bool Equals(object obj)
        {
            if (obj == null || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }

            var castObj = (SupplierSpecialOfferEntity)obj;
            return this.SupplierSpecialOfferId == castObj.SupplierSpecialOfferId;
        }

		/// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public override int GetHashCode()
		{
			var hash = 57; 
			hash = 27 * hash * this.SupplierSpecialOfferId.GetHashCode();
			return hash;
		}
	}
}