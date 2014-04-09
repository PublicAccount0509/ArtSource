// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SupplierPlatformRelationEntity.cs" company="Irdeto">
//   Copyright @ 2014
// </copyright>
// <summary>
//   Class:SupplierPlatformRelationEntity
//   Namespace:Ets.SingleApi.Model.Repository
//   Class Funtion:Represent the class mapping the SupplierPlatformRelationEntity table in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ets.SingleApi.Model.Repository
{
	using System;
		
    /// <summary>
    /// Class:SupplierPlatformRelationEntity
    /// Namespace:Ets.SingleApi.Model.Repository
    /// Class Funtion:Represent the class mapping the SupplierPlatformRelationEntity table in the database.
    /// </summary>
    /// Creator:ww
    /// Creation Date:2014-4-9 14:29:09
    /// Modifier:
    /// Last Modified:
    /// ----------------------------------------------------------------------------------------
    [Serializable]
    public class SupplierPlatformRelationEntity
    {
		#region private member

			/// <summary>
		/// The Id
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-4-9 14:29:09
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int id;

			/// <summary>
		/// The SupplierId
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-4-9 14:29:09
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int supplierId;

			/// <summary>
		/// The PlatformId
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-4-9 14:29:09
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int platformId;

			/// <summary>
		/// The Type
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-4-9 14:29:09
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? type;

			/// <summary>
		/// The IsEnabled
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-4-9 14:29:09
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private bool? isEnabled;

			/// <summary>
		/// The CreateTime
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-4-9 14:29:09
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private DateTime? createTime;

		#endregion

		/// <summary>
        /// Initializes a new instance of the <see cref="SupplierPlatformRelationEntity"/> class.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-4-9 14:29:09
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public SupplierPlatformRelationEntity()
        {
			this.id = 0;
			this.supplierId = 0;
			this.platformId = 0;
		}

		#region public member

			/// <summary>
        /// Gets or sets a value mapping the Id of SupplierPlatformRelationEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-4-9 14:29:09
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
        /// Gets or sets a value mapping the SupplierId of SupplierPlatformRelationEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-4-9 14:29:09
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
        /// Gets or sets a value mapping the PlatformId of SupplierPlatformRelationEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-4-9 14:29:09
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int PlatformId
		{
            get
            {
                return this.platformId;
            }

            set
            {
                this.platformId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Type of SupplierPlatformRelationEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-4-9 14:29:09
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? Type
		{
            get
            {
                return this.type;
            }

            set
            {
                this.type = value;
            }
        }

			/// <summary>
        /// Gets or sets a value indicating whether mapping the IsEnabled of SupplierPlatformRelationEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-4-9 14:29:09
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual bool? IsEnabled
		{
            get
            {
                return this.isEnabled;
            }

            set
            {
                this.isEnabled = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the CreateTime of SupplierPlatformRelationEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-4-9 14:29:09
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual DateTime? CreateTime
		{
            get
            {
                return this.createTime;
            }

            set
            {
                this.createTime = value;
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
        /// Creation Date:2014-4-9 14:29:09
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public override bool Equals(object obj)
        {
            if (obj == null || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }

            var castObj = (SupplierPlatformRelationEntity)obj;
            return this.Id == castObj.Id;
        }

		/// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        /// Creator:ww
        /// Creation Date:2014-4-9 14:29:09
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