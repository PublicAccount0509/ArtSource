// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SupplierGroupTemplateEntity.cs" company="Irdeto">
//   Copyright @ 2013
// </copyright>
// <summary>
//   Class:SupplierGroupTemplateEntity
//   Namespace:Ets.SingleApi.Model.Repository
//   Class Funtion:Represent the class mapping the SupplierGroupTemplateEntity table in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ets.SingleApi.Model.Repository
{
	using System;
		
    /// <summary>
    /// Class:SupplierGroupTemplateEntity
    /// Namespace:Ets.SingleApi.Model.Repository
    /// Class Funtion:Represent the class mapping the SupplierGroupTemplateEntity table in the database.
    /// </summary>
    /// Creator:周超
    /// Creation Date:2013/12/20 11:17:33
    /// Modifier:
    /// Last Modified:
    /// ----------------------------------------------------------------------------------------
    [Serializable]
    public class SupplierGroupTemplateEntity
    {
		#region private member

			/// <summary>
		/// The SupplierGroupTemplateId
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/20 11:17:33
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int supplierGroupTemplateId;

			/// <summary>
		/// The SupplierTypeId
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/20 11:17:33
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int supplierTypeId;

			/// <summary>
		/// The TemplateTypeId
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/20 11:17:33
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int templateTypeId;

			/// <summary>
		/// The TemplateColorId
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/20 11:17:33
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int templateColorId;

			/// <summary>
		/// The CreateDate
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/20 11:17:33
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private DateTime createDate;

			/// <summary>
		/// The LightApplicationId
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/20 11:17:33
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private BaiDuAppLightEntity lightApplication;

		#endregion

		/// <summary>
        /// Initializes a new instance of the <see cref="SupplierGroupTemplateEntity"/> class.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/20 11:17:33
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public SupplierGroupTemplateEntity()
        {
			this.supplierGroupTemplateId = 0;
			this.supplierTypeId = 0;
			this.templateTypeId = 0;
			this.templateColorId = 0;
			this.createDate = DateTime.Now;
		}

		#region public member

			/// <summary>
        /// Gets or sets a value mapping the SupplierGroupTemplateId of SupplierGroupTemplateEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/20 11:17:33
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int SupplierGroupTemplateId
		{
            get
            {
                return this.supplierGroupTemplateId;
            }

            set
            {
                this.supplierGroupTemplateId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the SupplierTypeId of SupplierGroupTemplateEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/20 11:17:33
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int SupplierTypeId
		{
            get
            {
                return this.supplierTypeId;
            }

            set
            {
                this.supplierTypeId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the TemplateTypeId of SupplierGroupTemplateEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/20 11:17:33
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int TemplateTypeId
		{
            get
            {
                return this.templateTypeId;
            }

            set
            {
                this.templateTypeId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the TemplateColorId of SupplierGroupTemplateEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/20 11:17:33
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int TemplateColorId
		{
            get
            {
                return this.templateColorId;
            }

            set
            {
                this.templateColorId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the CreateDate of SupplierGroupTemplateEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/20 11:17:33
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
        /// Gets or sets a value mapping the LightApplicationId of SupplierGroupTemplateEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/20 11:17:33
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual BaiDuAppLightEntity LightApplication
		{
            get
            {
                return this.lightApplication;
            }

            set
            {
                this.lightApplication = value;
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
        /// Creation Date:2013/12/20 11:17:33
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public override bool Equals(object obj)
        {
            if (obj == null || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }

            var castObj = (SupplierGroupTemplateEntity)obj;
            return this.SupplierGroupTemplateId == castObj.SupplierGroupTemplateId;
        }

		/// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        /// Creator:周超
        /// Creation Date:2013/12/20 11:17:33
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public override int GetHashCode()
		{
			var hash = 57; 
			hash = 27 * hash * this.SupplierGroupTemplateId.GetHashCode();
			return hash;
		}
	}
}