// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CampaignEntity.cs" company="Irdeto">
//   Copyright @ 2013
// </copyright>
// <summary>
//   Class:CampaignEntity
//   Namespace:Ets.SingleApi.Model.Repository
//   Class Funtion:Represent the class mapping the CampaignEntity table in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ets.SingleApi.Model.Repository
{
	using System;
	using System.Collections.Generic;
		
    /// <summary>
    /// Class:CampaignEntity
    /// Namespace:Ets.SingleApi.Model.Repository
    /// Class Funtion:Represent the class mapping the CampaignEntity table in the database.
    /// </summary>
    /// Creator:周超
    /// Creation Date:2013/10/13 14:18:47
    /// Modifier:
    /// Last Modified:
    /// ----------------------------------------------------------------------------------------
    [Serializable]
    public class CampaignEntity
    {
		#region private member

			/// <summary>
		/// The CampaignID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:47
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int campaignId;

			/// <summary>
		/// The SupplierID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:47
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? supplierId;

			/// <summary>
		/// The CampaignName
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:47
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string campaignName;

			/// <summary>
		/// The Description
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:47
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string description;

			/// <summary>
		/// The Objective
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:47
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string objective;

			/// <summary>
		/// The RevenueGoal
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:47
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private decimal revenueGoal;

			/// <summary>
		/// The InventoryGoal
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:47
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int inventoryGoal;

			/// <summary>
		/// The DateEnd
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:47
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private DateTime dateEnd;

			/// <summary>
		/// The IsActive
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:47
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private bool isActive;

			/// <summary>
		/// The CreatedOn
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:47
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private DateTime? createdOn;

			/// <summary>
		/// The CreatedBy
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:47
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string createdBy;

			/// <summary>
		/// The ModifiedOn
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:47
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private DateTime? modifiedOn;

			/// <summary>
		/// The ModifiedBy
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:47
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string modifiedBy;

			/// <summary>
		/// The CampaignSupplierList
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:47
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private IList<CampaignSupplierEntity> campaignSupplierList;

		#endregion

		/// <summary>
        /// Initializes a new instance of the <see cref="CampaignEntity"/> class.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:47
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public CampaignEntity()
        {
			this.campaignId = 0;
			this.campaignName = string.Empty;
			this.description = string.Empty;
			this.objective = string.Empty;
			this.revenueGoal = 0;
			this.inventoryGoal = 0;
			this.dateEnd = DateTime.Now;
			this.isActive = false;
			this.createdBy = string.Empty;
			this.modifiedBy = string.Empty;
		}

		#region public member

			/// <summary>
        /// Gets or sets a value mapping the CampaignID of CampaignEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:47
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int CampaignId
		{
            get
            {
                return this.campaignId;
            }

            set
            {
                this.campaignId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the SupplierID of CampaignEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:47
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? SupplierId
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
        /// Gets or sets a value mapping the CampaignName of CampaignEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:47
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string CampaignName
		{
            get
            {
                return this.campaignName;
            }

            set
            {
                this.campaignName = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Description of CampaignEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:47
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
        /// Gets or sets a value mapping the Objective of CampaignEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:47
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string Objective
		{
            get
            {
                return this.objective;
            }

            set
            {
                this.objective = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the RevenueGoal of CampaignEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:47
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual decimal RevenueGoal
		{
            get
            {
                return this.revenueGoal;
            }

            set
            {
                this.revenueGoal = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the InventoryGoal of CampaignEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:47
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int InventoryGoal
		{
            get
            {
                return this.inventoryGoal;
            }

            set
            {
                this.inventoryGoal = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the DateEnd of CampaignEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:47
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual DateTime DateEnd
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
        /// Gets or sets a value indicating whether mapping the IsActive of CampaignEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:47
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual bool IsActive
		{
            get
            {
                return this.isActive;
            }

            set
            {
                this.isActive = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the CreatedOn of CampaignEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:47
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual DateTime? CreatedOn
		{
            get
            {
                return this.createdOn;
            }

            set
            {
                this.createdOn = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the CreatedBy of CampaignEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:47
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string CreatedBy
		{
            get
            {
                return this.createdBy;
            }

            set
            {
                this.createdBy = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the ModifiedOn of CampaignEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:47
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual DateTime? ModifiedOn
		{
            get
            {
                return this.modifiedOn;
            }

            set
            {
                this.modifiedOn = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the ModifiedBy of CampaignEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:47
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string ModifiedBy
		{
            get
            {
                return this.modifiedBy;
            }

            set
            {
                this.modifiedBy = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the CampaignSupplierList of CampaignEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:47
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual IList<CampaignSupplierEntity> CampaignSupplierList
		{
            get
            {
                return this.campaignSupplierList;
            }

            set
            {
                this.campaignSupplierList = value;
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
        /// Creation Date:2013/10/13 14:18:47
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public override bool Equals(object obj)
        {
            if (obj == null || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }

            var castObj = (CampaignEntity)obj;
            return this.CampaignId == castObj.CampaignId;
        }

		/// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:47
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public override int GetHashCode()
		{
			var hash = 57; 
			hash = 27 * hash * this.CampaignId.GetHashCode();
			return hash;
		}
	}
}