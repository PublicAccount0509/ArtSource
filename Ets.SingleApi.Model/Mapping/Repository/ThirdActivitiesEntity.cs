// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ThirdActivitiesEntity.cs" company="Irdeto">
//   Copyright @ 2014
// </copyright>
// <summary>
//   Class:ThirdActivitiesEntity
//   Namespace:Ets.SingleApi.Model.Repository
//   Class Funtion:Represent the class mapping the ThirdActivitiesEntity table in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ets.SingleApi.Model.Repository
{
	using System;
	using System.Collections.Generic;
		
    /// <summary>
    /// Class:ThirdActivitiesEntity
    /// Namespace:Ets.SingleApi.Model.Repository
    /// Class Funtion:Represent the class mapping the ThirdActivitiesEntity table in the database.
    /// </summary>
    /// Creator:周超
    /// Creation Date:2014/6/9 9:58:20
    /// Modifier:
    /// Last Modified:
    /// ----------------------------------------------------------------------------------------
    [Serializable]
    public class ThirdActivitiesEntity
    {
		#region private member

			/// <summary>
		/// The ActivitieId
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/6/9 9:58:20
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int activitieId;

			/// <summary>
		/// The ActivitieName
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/6/9 9:58:20
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string activitieName;

			/// <summary>
		/// The ActivitieContent
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/6/9 9:58:20
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string activitieContent;

			/// <summary>
		/// The BeginDate
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/6/9 9:58:20
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private DateTime beginDate;

			/// <summary>
		/// The EndDate
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/6/9 9:58:20
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private DateTime endDate;

			/// <summary>
		/// The IsDelete
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/6/9 9:58:20
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private bool isDelete;

			/// <summary>
		/// The CreateDate
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/6/9 9:58:20
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private DateTime createDate;

			/// <summary>
		/// The LinkUrl
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/6/9 9:58:20
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string linkUrl;

			/// <summary>
		/// The ActivitieOrganizers
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/6/9 9:58:20
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string activitieOrganizers;

			/// <summary>
		/// The SupplierThirdActivitiesList
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/6/9 9:58:20
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private IList<SupplierThirdActivitiesEntity> supplierThirdActivitiesList;

		#endregion

		/// <summary>
        /// Initializes a new instance of the <see cref="ThirdActivitiesEntity"/> class.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/6/9 9:58:20
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public ThirdActivitiesEntity()
        {
			this.activitieId = 0;
			this.activitieName = string.Empty;
			this.activitieContent = string.Empty;
			this.beginDate = DateTime.Now;
			this.endDate = DateTime.Now;
			this.isDelete = false;
			this.createDate = DateTime.Now;
			this.linkUrl = string.Empty;
			this.activitieOrganizers = string.Empty;
		}

		#region public member

			/// <summary>
        /// Gets or sets a value mapping the ActivitieId of ThirdActivitiesEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/6/9 9:58:20
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int ActivitieId
		{
            get
            {
                return this.activitieId;
            }

            set
            {
                this.activitieId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the ActivitieName of ThirdActivitiesEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/6/9 9:58:20
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string ActivitieName
		{
            get
            {
                return this.activitieName;
            }

            set
            {
                this.activitieName = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the ActivitieContent of ThirdActivitiesEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/6/9 9:58:20
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string ActivitieContent
		{
            get
            {
                return this.activitieContent;
            }

            set
            {
                this.activitieContent = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the BeginDate of ThirdActivitiesEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/6/9 9:58:20
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual DateTime BeginDate
		{
            get
            {
                return this.beginDate;
            }

            set
            {
                this.beginDate = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the EndDate of ThirdActivitiesEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/6/9 9:58:20
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual DateTime EndDate
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
        /// Gets or sets a value indicating whether mapping the IsDelete of ThirdActivitiesEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/6/9 9:58:20
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual bool IsDelete
		{
            get
            {
                return this.isDelete;
            }

            set
            {
                this.isDelete = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the CreateDate of ThirdActivitiesEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/6/9 9:58:20
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual DateTime CreateDate
		{
            get
            {
                return this.createDate;
            }

            set
            {
                this.createDate = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the LinkUrl of ThirdActivitiesEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/6/9 9:58:20
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string LinkUrl
		{
            get
            {
                return this.linkUrl;
            }

            set
            {
                this.linkUrl = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the ActivitieOrganizers of ThirdActivitiesEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/6/9 9:58:20
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string ActivitieOrganizers
		{
            get
            {
                return this.activitieOrganizers;
            }

            set
            {
                this.activitieOrganizers = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the SupplierThirdActivitiesList of ThirdActivitiesEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/6/9 9:58:20
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual IList<SupplierThirdActivitiesEntity> SupplierThirdActivitiesList
		{
            get
            {
                return this.supplierThirdActivitiesList;
            }

            set
            {
                this.supplierThirdActivitiesList = value;
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
        /// Creation Date:2014/6/9 9:58:20
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public override bool Equals(object obj)
        {
            if (obj == null || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }

            var castObj = (ThirdActivitiesEntity)obj;
            return this.ActivitieId == castObj.ActivitieId;
        }

		/// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        /// Creator:周超
        /// Creation Date:2014/6/9 9:58:20
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public override int GetHashCode()
		{
			var hash = 57; 
			hash = 27 * hash * this.ActivitieId.GetHashCode();
			return hash;
		}
	}
}