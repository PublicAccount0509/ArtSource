// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SupplierDeskEntity.cs" company="Irdeto">
//   Copyright @ 2014
// </copyright>
// <summary>
//   Class:SupplierDeskEntity
//   Namespace:Ets.SingleApi.Model.Repository
//   Class Funtion:Represent the class mapping the SupplierDeskEntity table in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ets.SingleApi.Model.Repository
{
	using System;
	using System.Collections.Generic;
		
    /// <summary>
    /// Class:SupplierDeskEntity
    /// Namespace:Ets.SingleApi.Model.Repository
    /// Class Funtion:Represent the class mapping the SupplierDeskEntity table in the database.
    /// </summary>
    /// Creator:ww
    /// Creation Date:2014-3-19 10:43:05
    /// Modifier:
    /// Last Modified:
    /// ----------------------------------------------------------------------------------------
    [Serializable]
    public class SupplierDeskEntity
    {
		#region private member

			/// <summary>
		/// The Id
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-19 10:43:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int id;

			/// <summary>
		/// The DeskName
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-19 10:43:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string deskName;

			/// <summary>
		/// The DeskNo
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-19 10:43:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string deskNo;

			/// <summary>
		/// The IsDel
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-19 10:43:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private bool isDel;

			/// <summary>
		/// The CreateTime
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-19 10:43:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private DateTime createTime;

			/// <summary>
		/// The UpdateTime
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-19 10:43:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private DateTime updateTime;

			/// <summary>
		/// The SupplierId
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-19 10:43:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int supplierId;

			/// <summary>
		/// The IsEnable
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-19 10:43:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private bool isEnable;

			/// <summary>
		/// The Description
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-19 10:43:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string description;

			/// <summary>
		/// The DeskBookingList
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-19 10:43:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private IList<DeskBookingEntity> deskBookingList;

			/// <summary>
		/// The DeskTypeId
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-19 10:43:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private DeskTypeEntity deskType;

		#endregion

		/// <summary>
        /// Initializes a new instance of the <see cref="SupplierDeskEntity"/> class.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-19 10:43:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public SupplierDeskEntity()
        {
			this.id = 0;
			this.deskName = string.Empty;
			this.deskNo = string.Empty;
			this.isDel = false;
			this.createTime = DateTime.Now;
			this.updateTime = DateTime.Now;
			this.supplierId = 0;
			this.isEnable = false;
			this.description = string.Empty;
		}

		#region public member

			/// <summary>
        /// Gets or sets a value mapping the Id of SupplierDeskEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-19 10:43:05
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
        /// Gets or sets a value mapping the DeskName of SupplierDeskEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-19 10:43:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string DeskName
		{
            get
            {
                return this.deskName;
            }

            set
            {
                this.deskName = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the DeskNo of SupplierDeskEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-19 10:43:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string DeskNo
		{
            get
            {
                return this.deskNo;
            }

            set
            {
                this.deskNo = value;
            }
        }

			/// <summary>
        /// Gets or sets a value indicating whether mapping the IsDel of SupplierDeskEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-19 10:43:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual bool IsDel
		{
            get
            {
                return this.isDel;
            }

            set
            {
                this.isDel = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the CreateTime of SupplierDeskEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-19 10:43:05
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
        /// Gets or sets a value mapping the UpdateTime of SupplierDeskEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-19 10:43:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual DateTime UpdateTime
		{
            get
            {
                return this.updateTime;
            }

            set
            {
                this.updateTime = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the SupplierId of SupplierDeskEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-19 10:43:05
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
        /// Gets or sets a value indicating whether mapping the IsEnable of SupplierDeskEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-19 10:43:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual bool IsEnable
		{
            get
            {
                return this.isEnable;
            }

            set
            {
                this.isEnable = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Description of SupplierDeskEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-19 10:43:05
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
        /// Gets or sets a value mapping the DeskBookingList of SupplierDeskEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-19 10:43:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual IList<DeskBookingEntity> DeskBookingList
		{
            get
            {
                return this.deskBookingList;
            }

            set
            {
                this.deskBookingList = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the DeskTypeId of SupplierDeskEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-19 10:43:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual DeskTypeEntity DeskType
		{
            get
            {
                return this.deskType;
            }

            set
            {
                this.deskType = value;
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
        /// Creation Date:2014-3-19 10:43:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public override bool Equals(object obj)
        {
            if (obj == null || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }

            var castObj = (SupplierDeskEntity)obj;
            return this.Id == castObj.Id;
        }

		/// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        /// Creator:ww
        /// Creation Date:2014-3-19 10:43:05
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