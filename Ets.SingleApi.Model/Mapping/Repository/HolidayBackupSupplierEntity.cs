// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HolidayBackupSupplierEntity.cs" company="Irdeto">
//   Copyright @ 2013
// </copyright>
// <summary>
//   Class:HolidayBackupSupplierEntity
//   Namespace:Ets.SingleApi.Model.Repository
//   Class Funtion:Represent the class mapping the HolidayBackupSupplierEntity table in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ets.SingleApi.Model.Repository
{
	using System;
		
    /// <summary>
    /// Class:HolidayBackupSupplierEntity
    /// Namespace:Ets.SingleApi.Model.Repository
    /// Class Funtion:Represent the class mapping the HolidayBackupSupplierEntity table in the database.
    /// </summary>
    /// Creator:周超
    /// Creation Date:2013/10/13 14:23:32
    /// Modifier:
    /// Last Modified:
    /// ----------------------------------------------------------------------------------------
    [Serializable]
    public class HolidayBackupSupplierEntity
    {
		#region private member

			/// <summary>
		/// The BackupSupplierId
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:23:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int backupSupplierId;

			/// <summary>
		/// The FeatureOnList
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:23:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string featureOnList;

			/// <summary>
		/// The FeatureOffList
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:23:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string featureOffList;

			/// <summary>
		/// The DateStart
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:23:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private DateTime? dateStart;

			/// <summary>
		/// The DateEnd
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:23:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private DateTime? dateEnd;

			/// <summary>
		/// The IsFinished
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:23:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? isFinished;

			/// <summary>
		/// The ScrollingText
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:23:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string scrollingText;

			/// <summary>
		/// The TableOnList
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:23:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string tableOnList;

			/// <summary>
		/// The TableOffList
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:23:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string tableOffList;

			/// <summary>
		/// The FeatureId
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:23:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private FeatureEntity feature;

		#endregion

		/// <summary>
        /// Initializes a new instance of the <see cref="HolidayBackupSupplierEntity"/> class.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:23:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public HolidayBackupSupplierEntity()
        {
			this.backupSupplierId = 0;
			this.featureOnList = string.Empty;
			this.featureOffList = string.Empty;
			this.scrollingText = string.Empty;
			this.tableOnList = string.Empty;
			this.tableOffList = string.Empty;
		}

		#region public member

			/// <summary>
        /// Gets or sets a value mapping the BackupSupplierId of HolidayBackupSupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:23:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int BackupSupplierId
		{
            get
            {
                return this.backupSupplierId;
            }

            set
            {
                this.backupSupplierId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the FeatureOnList of HolidayBackupSupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:23:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string FeatureOnList
		{
            get
            {
                return this.featureOnList;
            }

            set
            {
                this.featureOnList = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the FeatureOffList of HolidayBackupSupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:23:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string FeatureOffList
		{
            get
            {
                return this.featureOffList;
            }

            set
            {
                this.featureOffList = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the DateStart of HolidayBackupSupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:23:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual DateTime? DateStart
		{
            get
            {
                return this.dateStart;
            }

            set
            {
                this.dateStart = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the DateEnd of HolidayBackupSupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:23:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual DateTime? DateEnd
		{
            get
            {
                return this.dateEnd;
            }

            set
            {
                this.dateEnd = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the IsFinished of HolidayBackupSupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:23:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? IsFinished
		{
            get
            {
                return this.isFinished;
            }

            set
            {
                this.isFinished = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the ScrollingText of HolidayBackupSupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:23:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string ScrollingText
		{
            get
            {
                return this.scrollingText;
            }

            set
            {
                this.scrollingText = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the TableOnList of HolidayBackupSupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:23:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string TableOnList
		{
            get
            {
                return this.tableOnList;
            }

            set
            {
                this.tableOnList = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the TableOffList of HolidayBackupSupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:23:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string TableOffList
		{
            get
            {
                return this.tableOffList;
            }

            set
            {
                this.tableOffList = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the FeatureId of HolidayBackupSupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:23:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual FeatureEntity Feature
		{
            get
            {
                return this.feature;
            }

            set
            {
                this.feature = value;
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
        /// Creation Date:2013/10/13 14:23:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public override bool Equals(object obj)
        {
            if (obj == null || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }

            var castObj = (HolidayBackupSupplierEntity)obj;
            return this.BackupSupplierId == castObj.BackupSupplierId;
        }

		/// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:23:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public override int GetHashCode()
		{
			var hash = 57; 
			hash = 27 * hash * this.BackupSupplierId.GetHashCode();
			return hash;
		}
	}
}