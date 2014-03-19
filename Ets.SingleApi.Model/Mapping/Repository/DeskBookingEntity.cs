// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DeskBookingEntity.cs" company="Irdeto">
//   Copyright @ 2014
// </copyright>
// <summary>
//   Class:DeskBookingEntity
//   Namespace:Ets.SingleApi.Model.Repository
//   Class Funtion:Represent the class mapping the DeskBookingEntity table in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ets.SingleApi.Model.Repository
{
	using System;
		
    /// <summary>
    /// Class:DeskBookingEntity
    /// Namespace:Ets.SingleApi.Model.Repository
    /// Class Funtion:Represent the class mapping the DeskBookingEntity table in the database.
    /// </summary>
    /// Creator:ww
    /// Creation Date:2014-3-19 10:42:44
    /// Modifier:
    /// Last Modified:
    /// ----------------------------------------------------------------------------------------
    [Serializable]
    public class DeskBookingEntity
    {
		#region private member

			/// <summary>
		/// The Id
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-19 10:42:44
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int id;

			/// <summary>
		/// The SupplierId
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-19 10:42:44
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int supplierId;

			/// <summary>
		/// The OrderNo
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-19 10:42:44
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string orderNo;

			/// <summary>
		/// The CreateTime
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-19 10:42:44
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private DateTime createTime;

			/// <summary>
		/// The Description
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-19 10:42:44
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string description;

			/// <summary>
		/// The DeskTypeId
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-19 10:42:44
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? deskTypeId;

			/// <summary>
		/// The DeskId
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-19 10:42:44
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private SupplierDeskEntity desk;

		#endregion

		/// <summary>
        /// Initializes a new instance of the <see cref="DeskBookingEntity"/> class.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-19 10:42:44
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public DeskBookingEntity()
        {
			this.id = 0;
			this.supplierId = 0;
			this.orderNo = string.Empty;
			this.createTime = DateTime.Now;
			this.description = string.Empty;
		}

		#region public member

			/// <summary>
        /// Gets or sets a value mapping the Id of DeskBookingEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-19 10:42:44
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
        /// Gets or sets a value mapping the SupplierId of DeskBookingEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-19 10:42:44
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
        /// Gets or sets a value mapping the OrderNo of DeskBookingEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-19 10:42:44
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
        /// Gets or sets a value mapping the CreateTime of DeskBookingEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-19 10:42:44
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual DateTime CreateTime
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
        /// Gets or sets a value mapping the Description of DeskBookingEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-19 10:42:44
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string Description
		{
            get
            {
                return this.description;
            }

            set
            {
                this.description = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the DeskTypeId of DeskBookingEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-19 10:42:44
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
        /// Gets or sets a value mapping the DeskId of DeskBookingEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-19 10:42:44
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual SupplierDeskEntity Desk
		{
            get
            {
                return this.desk;
            }

            set
            {
                this.desk = value;
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
        /// Creation Date:2014-3-19 10:42:44
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public override bool Equals(object obj)
        {
            if (obj == null || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }

            var castObj = (DeskBookingEntity)obj;
            return this.Id == castObj.Id;
        }

		/// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        /// Creator:ww
        /// Creation Date:2014-3-19 10:42:44
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public override int GetHashCode()
		{
			var hash = 57; 
			hash = 27 * hash * this.Id.GetHashCode();
			return hash;
		}
	}
}