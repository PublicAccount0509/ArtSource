// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SupplierBusinessAreaEntity.cs" company="Irdeto">
//   Copyright @ 2013
// </copyright>
// <summary>
//   Class:SupplierBusinessAreaEntity
//   Namespace:Ets.SingleApi.Model.Repository
//   Class Funtion:Represent the class mapping the SupplierBusinessAreaEntity table in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ets.SingleApi.Model.Repository
{
	using System;
		
    /// <summary>
    /// Class:SupplierBusinessAreaEntity
    /// Namespace:Ets.SingleApi.Model.Repository
    /// Class Funtion:Represent the class mapping the SupplierBusinessAreaEntity table in the database.
    /// </summary>
    /// Creator:周超
    /// Creation Date:2013/10/14 11:57:51
    /// Modifier:
    /// Last Modified:
    /// ----------------------------------------------------------------------------------------
    [Serializable]
    public class SupplierBusinessAreaEntity
    {
		#region private member

			/// <summary>
		/// The SupplierID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/14 11:57:51
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int supplierId;

			/// <summary>
		/// The BusinessAreaID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/14 11:57:51
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string businessAreaId;

			/// <summary>
		/// The BusinessAreaID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/14 11:57:51
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private AddrBusinessAreaEntity businessArea;

			/// <summary>
		/// The SupplierID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/14 11:57:51
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private SupplierEntity supplier;

		#endregion

		/// <summary>
        /// Initializes a new instance of the <see cref="SupplierBusinessAreaEntity"/> class.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/14 11:57:51
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public SupplierBusinessAreaEntity()
        {
			this.supplierId = 0;
			this.businessAreaId = string.Empty;
		}

		#region public member

			/// <summary>
        /// Gets or sets a value mapping the SupplierID of SupplierBusinessAreaEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/14 11:57:51
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
        /// Gets or sets a value mapping the BusinessAreaID of SupplierBusinessAreaEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/14 11:57:51
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string BusinessAreaId
		{
            get
            {
                return this.businessAreaId;
            }

            set
            {
                this.businessAreaId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the BusinessAreaID of SupplierBusinessAreaEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/14 11:57:51
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual AddrBusinessAreaEntity BusinessArea
		{
            get
            {
                return this.businessArea;
            }

            set
            {
                this.businessArea = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the SupplierID of SupplierBusinessAreaEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/14 11:57:51
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
        /// Creation Date:2013/10/14 11:57:51
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public override bool Equals(object obj)
        {
            if (obj == null || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }

            var castObj = (SupplierBusinessAreaEntity)obj;
            return this.SupplierId == castObj.SupplierId && this.BusinessAreaId == castObj.BusinessAreaId;
        }

		/// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        /// Creator:周超
        /// Creation Date:2013/10/14 11:57:51
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public override int GetHashCode()
		{
			var hash = 57; 
			hash = 27 * hash * this.SupplierId.GetHashCode();
			hash = 27 * hash * this.BusinessAreaId.GetHashCode();
			return hash;
		}
	}
}