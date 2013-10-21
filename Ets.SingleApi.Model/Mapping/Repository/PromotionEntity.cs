// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PromotionEntity.cs" company="Irdeto">
//   Copyright @ 2013
// </copyright>
// <summary>
//   Class:PromotionEntity
//   Namespace:Ets.SingleApi.Model.Repository
//   Class Funtion:Represent the class mapping the PromotionEntity table in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ets.SingleApi.Model.Repository
{
	using System;
		
    /// <summary>
    /// Class:PromotionEntity
    /// Namespace:Ets.SingleApi.Model.Repository
    /// Class Funtion:Represent the class mapping the PromotionEntity table in the database.
    /// </summary>
    /// Creator:周超
    /// Creation Date:2013/10/13 14:01:29
    /// Modifier:
    /// Last Modified:
    /// ----------------------------------------------------------------------------------------
    [Serializable]
    public class PromotionEntity
    {
		#region private member

			/// <summary>
		/// The PromotionID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int promotionId;

			/// <summary>
		/// The CampaignID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int campaignId;

			/// <summary>
		/// The PromotionCode
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string promotionCode;

			/// <summary>
		/// The Title
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string title;

			/// <summary>
		/// The Description
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string description;

			/// <summary>
		/// The Discount
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private decimal discount;

			/// <summary>
		/// The QtyThreshold
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int qtyThreshold;

			/// <summary>
		/// The InventoryGoal
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int inventoryGoal;

			/// <summary>
		/// The RevenueGoal
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private decimal revenueGoal;

			/// <summary>
		/// The DateBegin
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private DateTime? dateBegin;

			/// <summary>
		/// The DateEnd
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private DateTime dateEnd;

			/// <summary>
		/// The IsActive
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private bool isActive;

			/// <summary>
		/// The CreatedOn
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private DateTime? createdOn;

			/// <summary>
		/// The CreatedBy
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string createdBy;

			/// <summary>
		/// The ModifiedOn
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private DateTime? modifiedOn;

			/// <summary>
		/// The ModifiedBy
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string modifiedBy;

			/// <summary>
		/// The SupplierID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private SupplierEntity supplier;

		#endregion

		/// <summary>
        /// Initializes a new instance of the <see cref="PromotionEntity"/> class.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public PromotionEntity()
        {
			this.promotionId = 0;
			this.campaignId = 0;
			this.promotionCode = string.Empty;
			this.title = string.Empty;
			this.description = string.Empty;
			this.discount = 0;
			this.qtyThreshold = 0;
			this.inventoryGoal = 0;
			this.revenueGoal = 0;
			this.dateEnd = DateTime.Now;
			this.isActive = false;
			this.createdBy = string.Empty;
			this.modifiedBy = string.Empty;
		}

		#region public member

			/// <summary>
        /// Gets or sets a value mapping the PromotionID of PromotionEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int PromotionId
		{
            get
            {
                return this.promotionId;
            }

            set
            {
                this.promotionId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the CampaignID of PromotionEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
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
        /// Gets or sets a value mapping the PromotionCode of PromotionEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string PromotionCode
		{
            get
            {
                return this.promotionCode;
            }

            set
            {
                this.promotionCode = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Title of PromotionEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string Title
		{
            get
            {
                return this.title;
            }

            set
            {
                this.title = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Description of PromotionEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
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
        /// Gets or sets a value mapping the Discount of PromotionEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual decimal Discount
		{
            get
            {
                return this.discount;
            }

            set
            {
                this.discount = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the QtyThreshold of PromotionEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int QtyThreshold
		{
            get
            {
                return this.qtyThreshold;
            }

            set
            {
                this.qtyThreshold = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the InventoryGoal of PromotionEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
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
        /// Gets or sets a value mapping the RevenueGoal of PromotionEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
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
        /// Gets or sets a value mapping the DateBegin of PromotionEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual DateTime? DateBegin
		{
            get
            {
                return this.dateBegin;
            }

            set
            {
                this.dateBegin = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the DateEnd of PromotionEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
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
        /// Gets or sets a value indicating whether mapping the IsActive of PromotionEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
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
        /// Gets or sets a value mapping the CreatedOn of PromotionEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
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
        /// Gets or sets a value mapping the CreatedBy of PromotionEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
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
        /// Gets or sets a value mapping the ModifiedOn of PromotionEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
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
        /// Gets or sets a value mapping the ModifiedBy of PromotionEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
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
        /// Gets or sets a value mapping the SupplierID of PromotionEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual SupplierEntity Supplier
		{
            get
            {
                return this.supplier;
            }

            set
            {
                this.supplier = value;
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
        /// Creation Date:2013/10/13 14:01:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public override bool Equals(object obj)
        {
            if (obj == null || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }

            var castObj = (PromotionEntity)obj;
            return this.PromotionId == castObj.PromotionId;
        }

		/// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public override int GetHashCode()
		{
			var hash = 57; 
			hash = 27 * hash * this.PromotionId.GetHashCode();
			return hash;
		}
	}
}