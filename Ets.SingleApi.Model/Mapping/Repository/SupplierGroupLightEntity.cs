// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SupplierGroupLightEntity.cs" company="Irdeto">
//   Copyright @ 2013
// </copyright>
// <summary>
//   Class:SupplierGroupLightEntity
//   Namespace:Ets.SingleApi.Model.Repository
//   Class Funtion:Represent the class mapping the SupplierGroupLightEntity table in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ets.SingleApi.Model.Repository
{
	using System;
	using System.Collections.Generic;
		
    /// <summary>
    /// Class:SupplierGroupLightEntity
    /// Namespace:Ets.SingleApi.Model.Repository
    /// Class Funtion:Represent the class mapping the SupplierGroupLightEntity table in the database.
    /// </summary>
    /// Creator:周超
    /// Creation Date:2013/12/20 11:17:33
    /// Modifier:
    /// Last Modified:
    /// ----------------------------------------------------------------------------------------
    [Serializable]
    public class SupplierGroupLightEntity
    {
		#region private member

			/// <summary>
		/// The SupplierGroupLightId
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/20 11:17:33
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int supplierGroupLightId;

			/// <summary>
		/// The TargetId
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/20 11:17:33
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int targetId;

			/// <summary>
		/// The Name
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/20 11:17:33
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string name;

			/// <summary>
		/// The Telphone
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/20 11:17:33
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string telphone;

			/// <summary>
		/// The LogoUrl
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/20 11:17:33
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string logoUrl;

			/// <summary>
		/// The Description
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/20 11:17:33
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string description;

			/// <summary>
		/// The ServiceNote
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/20 11:17:33
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string serviceNote;

			/// <summary>
		/// The BrandStory
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/20 11:17:33
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string brandStory;

			/// <summary>
		/// The RecommendDishes
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/20 11:17:33
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string recommendDishes;

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
		/// The SupplierGroupAdvertisementList
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/20 11:17:33
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private IList<SupplierGroupAdvertisementEntity> supplierGroupAdvertisementList;

			/// <summary>
		/// The SupplierGroupFeatureList
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/20 11:17:33
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private IList<SupplierGroupFeatureEntity> supplierGroupFeatureList;

			/// <summary>
		/// The SupplierGroupLogoImageList
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/20 11:17:33
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private IList<SupplierGroupLogoImageEntity> supplierGroupLogoImageList;

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
        /// Initializes a new instance of the <see cref="SupplierGroupLightEntity"/> class.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/20 11:17:33
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public SupplierGroupLightEntity()
        {
			this.supplierGroupLightId = 0;
			this.targetId = 0;
			this.name = string.Empty;
			this.telphone = string.Empty;
			this.logoUrl = string.Empty;
			this.description = string.Empty;
			this.serviceNote = string.Empty;
			this.brandStory = string.Empty;
			this.recommendDishes = string.Empty;
			this.createDate = DateTime.Now;
		}

		#region public member

			/// <summary>
        /// Gets or sets a value mapping the SupplierGroupLightId of SupplierGroupLightEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/20 11:17:33
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int SupplierGroupLightId
		{
            get
            {
                return this.supplierGroupLightId;
            }

            set
            {
                this.supplierGroupLightId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the TargetId of SupplierGroupLightEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/20 11:17:33
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int TargetId
		{
            get
            {
                return this.targetId;
            }

            set
            {
                this.targetId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Name of SupplierGroupLightEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/20 11:17:33
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string Name
		{
            get
            {
                return this.name;
            }

            set
            {
                this.name = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Telphone of SupplierGroupLightEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/20 11:17:33
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string Telphone
		{
            get
            {
                return this.telphone;
            }

            set
            {
                this.telphone = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the LogoUrl of SupplierGroupLightEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/20 11:17:33
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string LogoUrl
		{
            get
            {
                return this.logoUrl;
            }

            set
            {
                this.logoUrl = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Description of SupplierGroupLightEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/20 11:17:33
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
        /// Gets or sets a value mapping the ServiceNote of SupplierGroupLightEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/20 11:17:33
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string ServiceNote
		{
            get
            {
                return this.serviceNote;
            }

            set
            {
                this.serviceNote = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the BrandStory of SupplierGroupLightEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/20 11:17:33
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string BrandStory
		{
            get
            {
                return this.brandStory;
            }

            set
            {
                this.brandStory = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the RecommendDishes of SupplierGroupLightEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/20 11:17:33
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string RecommendDishes
		{
            get
            {
                return this.recommendDishes;
            }

            set
            {
                this.recommendDishes = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the CreateDate of SupplierGroupLightEntity table in the database.
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
        /// Gets or sets a value mapping the SupplierGroupAdvertisementList of SupplierGroupLightEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/20 11:17:33
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual IList<SupplierGroupAdvertisementEntity> SupplierGroupAdvertisementList
		{
            get
            {
                return this.supplierGroupAdvertisementList;
            }

            set
            {
                this.supplierGroupAdvertisementList = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the SupplierGroupFeatureList of SupplierGroupLightEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/20 11:17:33
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual IList<SupplierGroupFeatureEntity> SupplierGroupFeatureList
		{
            get
            {
                return this.supplierGroupFeatureList;
            }

            set
            {
                this.supplierGroupFeatureList = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the SupplierGroupLogoImageList of SupplierGroupLightEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/20 11:17:33
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual IList<SupplierGroupLogoImageEntity> SupplierGroupLogoImageList
		{
            get
            {
                return this.supplierGroupLogoImageList;
            }

            set
            {
                this.supplierGroupLogoImageList = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the LightApplicationId of SupplierGroupLightEntity table in the database.
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

            var castObj = (SupplierGroupLightEntity)obj;
            return this.SupplierGroupLightId == castObj.SupplierGroupLightId;
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
			hash = 27 * hash * this.SupplierGroupLightId.GetHashCode();
			return hash;
		}
	}
}