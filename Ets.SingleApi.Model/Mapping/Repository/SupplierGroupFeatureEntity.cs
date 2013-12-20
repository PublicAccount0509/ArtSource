// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SupplierGroupFeatureEntity.cs" company="Irdeto">
//   Copyright @ 2013
// </copyright>
// <summary>
//   Class:SupplierGroupFeatureEntity
//   Namespace:Ets.SingleApi.Model.Repository
//   Class Funtion:Represent the class mapping the SupplierGroupFeatureEntity table in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ets.SingleApi.Model.Repository
{
	using System;
		
    /// <summary>
    /// Class:SupplierGroupFeatureEntity
    /// Namespace:Ets.SingleApi.Model.Repository
    /// Class Funtion:Represent the class mapping the SupplierGroupFeatureEntity table in the database.
    /// </summary>
    /// Creator:周超
    /// Creation Date:2013/12/20 11:17:33
    /// Modifier:
    /// Last Modified:
    /// ----------------------------------------------------------------------------------------
    [Serializable]
    public class SupplierGroupFeatureEntity
    {
		#region private member

			/// <summary>
		/// The Id
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/20 11:17:33
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int id;

			/// <summary>
		/// The FeatureId
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/20 11:17:33
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int featureId;

			/// <summary>
		/// The SupplierGroupLight
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/20 11:17:33
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private SupplierGroupLightEntity supplierGroupLight;

		#endregion

		/// <summary>
        /// Initializes a new instance of the <see cref="SupplierGroupFeatureEntity"/> class.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/20 11:17:33
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public SupplierGroupFeatureEntity()
        {
			this.id = 0;
			this.featureId = 0;
		}

		#region public member

			/// <summary>
        /// Gets or sets a value mapping the Id of SupplierGroupFeatureEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/20 11:17:33
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
        /// Gets or sets a value mapping the FeatureId of SupplierGroupFeatureEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/20 11:17:33
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int FeatureId
		{
            get
            {
                return this.featureId;
            }

            set
            {
                this.featureId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the SupplierGroupLight of SupplierGroupFeatureEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/20 11:17:33
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual SupplierGroupLightEntity SupplierGroupLight
		{
            get
            {
                return this.supplierGroupLight;
            }

            set
            {
                this.supplierGroupLight = value;
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

            var castObj = (SupplierGroupFeatureEntity)obj;
            return this.Id == castObj.Id;
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
			hash = 27 * hash * this.Id.GetHashCode();
			return hash;
		}
	}
}