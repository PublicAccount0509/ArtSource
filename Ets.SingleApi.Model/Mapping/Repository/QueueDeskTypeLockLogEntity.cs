// --------------------------------------------------------------------------------------------------------------------
// <copyright file="QueueDeskTypeLockLogEntity.cs" company="Irdeto">
//   Copyright @ 2014
// </copyright>
// <summary>
//   Class:QueueDeskTypeLockLogEntity
//   Namespace:Ets.SingleApi.Model.Repository
//   Class Funtion:Represent the class mapping the QueueDeskTypeLockLogEntity table in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ets.SingleApi.Model.Repository
{
	using System;
		
    /// <summary>
    /// Class:QueueDeskTypeLockLogEntity
    /// Namespace:Ets.SingleApi.Model.Repository
    /// Class Funtion:Represent the class mapping the QueueDeskTypeLockLogEntity table in the database.
    /// </summary>
    /// Creator:ww
    /// Creation Date:2014-3-20 16:37:43
    /// Modifier:
    /// Last Modified:
    /// ----------------------------------------------------------------------------------------
    [Serializable]
    public class QueueDeskTypeLockLogEntity
    {
		#region private member

			/// <summary>
		/// The Id
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-20 16:37:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int id;

			/// <summary>
		/// The IsLock
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-20 16:37:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private bool isLock;

			/// <summary>
		/// The IsDel
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-20 16:37:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private bool isDel;

			/// <summary>
		/// The Description
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-20 16:37:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string description;

			/// <summary>
		/// The SupplierId
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-20 16:37:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int supplierId;

			/// <summary>
		/// The DeskTypeId
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-20 16:37:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private DeskTypeEntity deskType;

		#endregion

		/// <summary>
        /// Initializes a new instance of the <see cref="QueueDeskTypeLockLogEntity"/> class.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-20 16:37:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public QueueDeskTypeLockLogEntity()
        {
			this.id = 0;
			this.isLock = false;
			this.isDel = false;
			this.description = string.Empty;
			this.supplierId = 0;
		}

		#region public member

			/// <summary>
        /// Gets or sets a value mapping the Id of QueueDeskTypeLockLogEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-20 16:37:43
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
        /// Gets or sets a value indicating whether mapping the IsLock of QueueDeskTypeLockLogEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-20 16:37:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual bool IsLock
		{
            get
            {
                return this.isLock;
            }

            set
            {
                this.isLock = value;
            }
        }

			/// <summary>
        /// Gets or sets a value indicating whether mapping the IsDel of QueueDeskTypeLockLogEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-20 16:37:43
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
        /// Gets or sets a value mapping the Description of QueueDeskTypeLockLogEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-20 16:37:43
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
        /// Gets or sets a value mapping the SupplierId of QueueDeskTypeLockLogEntity table in the database.
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
        /// Gets or sets a value mapping the DeskTypeId of QueueDeskTypeLockLogEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-3-20 16:37:43
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

            var castObj = (QueueDeskTypeLockLogEntity)obj;
            return this.Id == castObj.Id;
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
			hash = 27 * hash * this.Id.GetHashCode();
			return hash;
		}
	}
}