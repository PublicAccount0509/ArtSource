// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BaiDuAppLightEntity.cs" company="Irdeto">
//   Copyright @ 2013
// </copyright>
// <summary>
//   Class:BaiDuAppLightEntity
//   Namespace:Ets.SingleApi.Model.Repository
//   Class Funtion:Represent the class mapping the BaiDuAppLightEntity table in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ets.SingleApi.Model.Repository
{
	using System;
	using System.Collections.Generic;
		
    /// <summary>
    /// Class:BaiDuAppLightEntity
    /// Namespace:Ets.SingleApi.Model.Repository
    /// Class Funtion:Represent the class mapping the BaiDuAppLightEntity table in the database.
    /// </summary>
    /// Creator:周超
    /// Creation Date:2013/12/20 11:17:31
    /// Modifier:
    /// Last Modified:
    /// ----------------------------------------------------------------------------------------
    [Serializable]
    public class BaiDuAppLightEntity
    {
		#region private member

			/// <summary>
		/// The LightApplicationId
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/20 11:17:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int lightApplicationId;

			/// <summary>
		/// The ApplicationId
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/20 11:17:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string applicationId;

			/// <summary>
		/// The IsDelete
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/20 11:17:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private bool isDelete;

			/// <summary>
		/// The CreateDate
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/20 11:17:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private DateTime createDate;

			/// <summary>
		/// The SupplierGroupLightList
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/20 11:17:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private IList<SupplierGroupLightEntity> supplierGroupLightList;

			/// <summary>
		/// The SupplierGroupTemplateList
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/20 11:17:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private IList<SupplierGroupTemplateEntity> supplierGroupTemplateList;

		#endregion

		/// <summary>
        /// Initializes a new instance of the <see cref="BaiDuAppLightEntity"/> class.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/20 11:17:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public BaiDuAppLightEntity()
        {
			this.lightApplicationId = 0;
			this.applicationId = string.Empty;
			this.isDelete = false;
			this.createDate = DateTime.Now;
		}

		#region public member

			/// <summary>
        /// Gets or sets a value mapping the LightApplicationId of BaiDuAppLightEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/20 11:17:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int LightApplicationId
		{
            get
            {
                return this.lightApplicationId;
            }

            set
            {
                this.lightApplicationId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the ApplicationId of BaiDuAppLightEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/20 11:17:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string ApplicationId
		{
            get
            {
                return this.applicationId;
            }

            set
            {
                this.applicationId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value indicating whether mapping the IsDelete of BaiDuAppLightEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/20 11:17:32
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
        /// Gets or sets a value mapping the CreateDate of BaiDuAppLightEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/20 11:17:32
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
        /// Gets or sets a value mapping the SupplierGroupLightList of BaiDuAppLightEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/20 11:17:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual IList<SupplierGroupLightEntity> SupplierGroupLightList
		{
            get
            {
                return this.supplierGroupLightList;
            }

            set
            {
                this.supplierGroupLightList = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the SupplierGroupTemplateList of BaiDuAppLightEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/20 11:17:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual IList<SupplierGroupTemplateEntity> SupplierGroupTemplateList
		{
            get
            {
                return this.supplierGroupTemplateList;
            }

            set
            {
                this.supplierGroupTemplateList = value;
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
        /// Creation Date:2013/12/20 11:17:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public override bool Equals(object obj)
        {
            if (obj == null || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }

            var castObj = (BaiDuAppLightEntity)obj;
            return this.LightApplicationId == castObj.LightApplicationId;
        }

		/// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        /// Creator:周超
        /// Creation Date:2013/12/20 11:17:32
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public override int GetHashCode()
		{
			var hash = 57; 
			hash = 27 * hash * this.LightApplicationId.GetHashCode();
			return hash;
		}
	}
}