// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SupplierGroupPlatformEntity.cs" company="Irdeto">
//   Copyright @ 2014
// </copyright>
// <summary>
//   Class:SupplierGroupPlatformEntity
//   Namespace:Ets.SingleApi.Model.Repository
//   Class Funtion:Represent the class mapping the SupplierGroupPlatformEntity table in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ets.SingleApi.Model.Repository
{
	using System;
		
    /// <summary>
    /// Class:SupplierGroupPlatformEntity
    /// Namespace:Ets.SingleApi.Model.Repository
    /// Class Funtion:Represent the class mapping the SupplierGroupPlatformEntity table in the database.
    /// </summary>
    /// Creator:ww
    /// Creation Date:2014-4-9 14:29:09
    /// Modifier:
    /// Last Modified:
    /// ----------------------------------------------------------------------------------------
    [Serializable]
    public class SupplierGroupPlatformEntity
    {
		#region private member

			/// <summary>
		/// The PlatformId
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-4-9 14:29:09
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? platformId;

			/// <summary>
		/// The SupplierGroupId
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-4-9 14:29:09
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? supplierGroupId;

			/// <summary>
		/// The Id
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-4-9 14:29:09
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int id;

		#endregion

		/// <summary>
        /// Initializes a new instance of the <see cref="SupplierGroupPlatformEntity"/> class.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-4-9 14:29:09
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public SupplierGroupPlatformEntity()
        {
			this.id = 0;
		}

		#region public member

			/// <summary>
        /// Gets or sets a value mapping the PlatformId of SupplierGroupPlatformEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-4-9 14:29:09
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? PlatformId
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
        /// Gets or sets a value mapping the SupplierGroupId of SupplierGroupPlatformEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014-4-9 14:29:09
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? SupplierGroupId
		{
            get
            {
                return this.supplierGroupId;
            }

            set
            {
                this.supplierGroupId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Id of SupplierGroupPlatformEntity table in the database.
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

            var castObj = (SupplierGroupPlatformEntity)obj;
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