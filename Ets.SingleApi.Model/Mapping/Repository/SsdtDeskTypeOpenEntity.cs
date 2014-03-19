// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SsdtDeskTypeOpenEntity.cs" company="Irdeto">
//   Copyright @ 2014
// </copyright>
// <summary>
//   Class:SsdtDeskTypeOpenEntity
//   Namespace:Ets.SingleApi.Model.Repository
//   Class Funtion:Represent the class mapping the SsdtDeskTypeOpenEntity table in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ets.SingleApi.Model.Repository
{
	using System;
		
    /// <summary>
    /// Class:SsdtDeskTypeOpenEntity
    /// Namespace:Ets.SingleApi.Model.Repository
    /// Class Funtion:Represent the class mapping the SsdtDeskTypeOpenEntity table in the database.
    /// </summary>
    /// Creator:ww
    /// Creation Date:2014-3-18 16:25:58
    /// Modifier:
    /// Last Modified:
    /// ----------------------------------------------------------------------------------------
    [Serializable]
    public class SsdtDeskTypeOpenEntity
    {
		#region private member

			/// <summary>
		/// The Id
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-18 16:25:58
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int id;

			/// <summary>
		/// The DeskTypeId
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-18 16:25:58
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int deskTypeId;

			/// <summary>
		/// The BeginTime
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-18 16:25:58
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string beginTime;

			/// <summary>
		/// The EndTime
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-18 16:25:58
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string endTime;

			/// <summary>
		/// The SupplierId
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-18 16:25:58
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int supplierId;

			/// <summary>
		/// The UpdateTime
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-18 16:25:58
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private DateTime updateTime;

			/// <summary>
		/// The IsDel
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-18 16:25:58
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private bool isDel;

			/// <summary>
		/// The IsEnable
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-18 16:25:58
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private bool isEnable;

			/// <summary>
		/// The Description
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-18 16:25:58
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string description;

		#endregion

		/// <summary>
        /// Initializes a new instance of the <see cref="SsdtDeskTypeOpenEntity"/> class.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-18 16:25:58
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public SsdtDeskTypeOpenEntity()
        {
			this.id = 0;
			this.deskTypeId = 0;
			this.beginTime = string.Empty;
			this.endTime = string.Empty;
			this.supplierId = 0;
			this.updateTime = DateTime.Now;
			this.isDel = false;
			this.isEnable = false;
			this.description = string.Empty;
		}

		#region public member

			/// <summary>
        /// Gets or sets a value mapping the Id of SsdtDeskTypeOpenEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-18 16:25:58
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
        /// Gets or sets a value mapping the DeskTypeId of SsdtDeskTypeOpenEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-18 16:25:58
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int DeskTypeId
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
        /// Gets or sets a value mapping the BeginTime of SsdtDeskTypeOpenEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-18 16:25:58
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string BeginTime
		{
            get
            {
                return this.beginTime;
            }

            set
            {
                this.beginTime = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the EndTime of SsdtDeskTypeOpenEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-18 16:25:58
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string EndTime
		{
            get
            {
                return this.endTime;
            }

            set
            {
                this.endTime = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the SupplierId of SsdtDeskTypeOpenEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-18 16:25:58
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
        /// Gets or sets a value mapping the UpdateTime of SsdtDeskTypeOpenEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-18 16:25:58
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
        /// Gets or sets a value indicating whether mapping the IsDel of SsdtDeskTypeOpenEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-18 16:25:58
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
        /// Gets or sets a value indicating whether mapping the IsEnable of SsdtDeskTypeOpenEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-18 16:25:58
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
        /// Gets or sets a value mapping the Description of SsdtDeskTypeOpenEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-18 16:25:58
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

		#endregion

			/// <summary>
        /// Determines whether the specified is equal to this instance.
        /// </summary>
        /// <param name="obj">The to compare with this instance.</param>
        /// <returns>
        /// true if the specified is equal to this instance; otherwise,false.
        /// </returns>
        /// Creator:ww
        /// Creation Date:2014-3-18 16:25:58
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public override bool Equals(object obj)
        {
            if (obj == null || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }

            var castObj = (SsdtDeskTypeOpenEntity)obj;
            return this.Id == castObj.Id;
        }

		/// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        /// Creator:ww
        /// Creation Date:2014-3-18 16:25:58
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