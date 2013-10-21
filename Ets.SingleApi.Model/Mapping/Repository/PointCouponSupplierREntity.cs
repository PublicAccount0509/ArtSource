// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PointCouponSupplierREntity.cs" company="Irdeto">
//   Copyright @ 2013
// </copyright>
// <summary>
//   Class:PointCouponSupplierREntity
//   Namespace:Ets.SingleApi.Model.Repository
//   Class Funtion:Represent the class mapping the PointCouponSupplierREntity table in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ets.SingleApi.Model.Repository
{
	using System;
		
    /// <summary>
    /// Class:PointCouponSupplierREntity
    /// Namespace:Ets.SingleApi.Model.Repository
    /// Class Funtion:Represent the class mapping the PointCouponSupplierREntity table in the database.
    /// </summary>
    /// Creator:周超
    /// Creation Date:2013/10/13 14:01:29
    /// Modifier:
    /// Last Modified:
    /// ----------------------------------------------------------------------------------------
    [Serializable]
    public class PointCouponSupplierREntity
    {
		#region private member

			/// <summary>
		/// The PCSRID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int pCSRId;

			/// <summary>
		/// The PointCouponID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private PointcouponEntity pointCoupon;

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
        /// Initializes a new instance of the <see cref="PointCouponSupplierREntity"/> class.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public PointCouponSupplierREntity()
        {
			this.pCSRId = 0;
		}

		#region public member

			/// <summary>
        /// Gets or sets a value mapping the PCSRID of PointCouponSupplierREntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int PCSRId
		{
            get
            {
                return this.pCSRId;
            }

            set
            {
                this.pCSRId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the PointCouponID of PointCouponSupplierREntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual PointcouponEntity PointCoupon
		{
            get
            {
                return this.pointCoupon;
            }

            set
            {
                this.pointCoupon = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the SupplierID of PointCouponSupplierREntity table in the database.
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

            var castObj = (PointCouponSupplierREntity)obj;
            return this.PCSRId == castObj.PCSRId;
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
			hash = 27 * hash * this.PCSRId.GetHashCode();
			return hash;
		}
	}
}