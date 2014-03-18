// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SsdtRoomTypeEntity.cs" company="Irdeto">
//   Copyright @ 2014
// </copyright>
// <summary>
//   Class:SsdtRoomTypeEntity
//   Namespace:Ets.SingleApi.Model.Repository
//   Class Funtion:Represent the class mapping the SsdtRoomTypeEntity table in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ets.SingleApi.Model.Repository
{
	using System;
		
    /// <summary>
    /// Class:SsdtRoomTypeEntity
    /// Namespace:Ets.SingleApi.Model.Repository
    /// Class Funtion:Represent the class mapping the SsdtRoomTypeEntity table in the database.
    /// </summary>
    /// Creator:ww
    /// Creation Date:2014-3-18 17:11:58
    /// Modifier:
    /// Last Modified:
    /// ----------------------------------------------------------------------------------------
    [Serializable]
    public class SsdtRoomTypeEntity
    {
		#region private member

			/// <summary>
		/// The Id
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-18 17:11:58
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int id;

			/// <summary>
		/// The RoomType
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-18 17:11:58
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string roomType;

			/// <summary>
		/// The RoomName
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-18 17:11:58
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string roomName;

			/// <summary>
		/// The TblType
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-18 17:11:58
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string tblType;

			/// <summary>
		/// The MinHuman
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-18 17:11:58
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string minHuman;

			/// <summary>
		/// The MaxHuman
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-18 17:11:58
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string maxHuman;

			/// <summary>
		/// The DepositAmount
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-18 17:11:58
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string depositAmount;

			/// <summary>
		/// The LowCost
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-18 17:11:58
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string lowCost;

			/// <summary>
		/// The IsOpen
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-18 17:11:58
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private bool isOpen;

			/// <summary>
		/// The IsDel
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-18 17:11:58
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private bool isDel;

			/// <summary>
		/// The CreateTime
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-18 17:11:58
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private DateTime createTime;

			/// <summary>
		/// The UpdateTime
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-18 17:11:58
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private DateTime updateTime;

			/// <summary>
		/// The Description
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-18 17:11:58
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string description;

			/// <summary>
		/// The SupplierId
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-18 17:11:58
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int supplierId;

		#endregion

		/// <summary>
        /// Initializes a new instance of the <see cref="SsdtRoomTypeEntity"/> class.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-18 17:11:58
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public SsdtRoomTypeEntity()
        {
			this.id = 0;
			this.roomType = string.Empty;
			this.roomName = string.Empty;
			this.tblType = string.Empty;
			this.minHuman = string.Empty;
			this.maxHuman = string.Empty;
			this.depositAmount = string.Empty;
			this.lowCost = string.Empty;
			this.isOpen = false;
			this.isDel = false;
			this.createTime = DateTime.Now;
			this.updateTime = DateTime.Now;
			this.description = string.Empty;
			this.supplierId = 0;
		}

		#region public member

			/// <summary>
        /// Gets or sets a value mapping the Id of SsdtRoomTypeEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-18 17:11:58
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
        /// Gets or sets a value mapping the RoomType of SsdtRoomTypeEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-18 17:11:58
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string RoomType
		{
            get
            {
                return this.roomType;
            }

            set
            {
                this.roomType = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the RoomName of SsdtRoomTypeEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-18 17:11:58
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string RoomName
		{
            get
            {
                return this.roomName;
            }

            set
            {
                this.roomName = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the TblType of SsdtRoomTypeEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-18 17:11:58
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string TblType
		{
            get
            {
                return this.tblType;
            }

            set
            {
                this.tblType = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the MinHuman of SsdtRoomTypeEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-18 17:11:58
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string MinHuman
		{
            get
            {
                return this.minHuman;
            }

            set
            {
                this.minHuman = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the MaxHuman of SsdtRoomTypeEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-18 17:11:58
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string MaxHuman
		{
            get
            {
                return this.maxHuman;
            }

            set
            {
                this.maxHuman = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the DepositAmount of SsdtRoomTypeEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-18 17:11:58
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string DepositAmount
		{
            get
            {
                return this.depositAmount;
            }

            set
            {
                this.depositAmount = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the LowCost of SsdtRoomTypeEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-18 17:11:58
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string LowCost
		{
            get
            {
                return this.lowCost;
            }

            set
            {
                this.lowCost = value;
            }
        }

			/// <summary>
        /// Gets or sets a value indicating whether mapping the IsOpen of SsdtRoomTypeEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-18 17:11:58
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual bool IsOpen
		{
            get
            {
                return this.isOpen;
            }

            set
            {
                this.isOpen = value;
            }
        }

			/// <summary>
        /// Gets or sets a value indicating whether mapping the IsDel of SsdtRoomTypeEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-18 17:11:58
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
        /// Gets or sets a value mapping the CreateTime of SsdtRoomTypeEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-18 17:11:58
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
        /// Gets or sets a value mapping the UpdateTime of SsdtRoomTypeEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-18 17:11:58
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
        /// Gets or sets a value mapping the Description of SsdtRoomTypeEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-18 17:11:58
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
        /// Gets or sets a value mapping the SupplierId of SsdtRoomTypeEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-18 17:11:58
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

		#endregion

			/// <summary>
        /// Determines whether the specified is equal to this instance.
        /// </summary>
        /// <param name="obj">The to compare with this instance.</param>
        /// <returns>
        /// true if the specified is equal to this instance; otherwise,false.
        /// </returns>
        /// Creator:ww
        /// Creation Date:2014-3-18 17:11:58
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public override bool Equals(object obj)
        {
            if (obj == null || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }

            var castObj = (SsdtRoomTypeEntity)obj;
            return this.Id == castObj.Id;
        }

		/// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        /// Creator:ww
        /// Creation Date:2014-3-18 17:11:58
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