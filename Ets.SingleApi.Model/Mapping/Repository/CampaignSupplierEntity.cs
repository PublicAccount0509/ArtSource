// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CampaignSupplierEntity.cs" company="Irdeto">
//   Copyright @ 2013
// </copyright>
// <summary>
//   Class:CampaignSupplierEntity
//   Namespace:Ets.SingleApi.Model.Repository
//   Class Funtion:Represent the class mapping the CampaignSupplierEntity table in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ets.SingleApi.Model.Repository
{
	using System;
		
    /// <summary>
    /// Class:CampaignSupplierEntity
    /// Namespace:Ets.SingleApi.Model.Repository
    /// Class Funtion:Represent the class mapping the CampaignSupplierEntity table in the database.
    /// </summary>
    /// Creator:周超
    /// Creation Date:2013/10/13 14:01:28
    /// Modifier:
    /// Last Modified:
    /// ----------------------------------------------------------------------------------------
    [Serializable]
    public class CampaignSupplierEntity
    {
		#region private member

			/// <summary>
		/// The CampaignSupplierID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int campaignSupplierId;

			/// <summary>
		/// The CreatedOn
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private DateTime? createdOn;

			/// <summary>
		/// The CreatedBy
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string createdBy;

			/// <summary>
		/// The ModifiedOn
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private DateTime? modifiedOn;

			/// <summary>
		/// The ModifiedBy
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string modifiedBy;

			/// <summary>
		/// The CampaignID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private CampaignEntity campaign;

			/// <summary>
		/// The SupplierID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private SupplierEntity supplier;

		#endregion

		/// <summary>
        /// Initializes a new instance of the <see cref="CampaignSupplierEntity"/> class.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public CampaignSupplierEntity()
        {
			this.campaignSupplierId = 0;
			this.createdBy = string.Empty;
			this.modifiedBy = string.Empty;
		}

		#region public member

			/// <summary>
        /// Gets or sets a value mapping the CampaignSupplierID of CampaignSupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int CampaignSupplierId
		{
            get
            {
                return this.campaignSupplierId;
            }

            set
            {
                this.campaignSupplierId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the CreatedOn of CampaignSupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
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
        /// Gets or sets a value mapping the CreatedBy of CampaignSupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
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
        /// Gets or sets a value mapping the ModifiedOn of CampaignSupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
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
        /// Gets or sets a value mapping the ModifiedBy of CampaignSupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
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
        /// Gets or sets a value mapping the CampaignID of CampaignSupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual CampaignEntity Campaign
		{
            get
            {
                return this.campaign;
            }

            set
            {
                this.campaign = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the SupplierID of CampaignSupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
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
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public override bool Equals(object obj)
        {
            if (obj == null || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }

            var castObj = (CampaignSupplierEntity)obj;
            return this.CampaignSupplierId == castObj.CampaignSupplierId;
        }

		/// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public override int GetHashCode()
		{
			var hash = 57; 
			hash = 27 * hash * this.CampaignSupplierId.GetHashCode();
			return hash;
		}
	}
}