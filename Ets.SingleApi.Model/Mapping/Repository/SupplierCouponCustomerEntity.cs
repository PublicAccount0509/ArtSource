// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SupplierCouponCustomerEntity.cs" company="Irdeto">
//   Copyright @ 2013
// </copyright>
// <summary>
//   Class:SupplierCouponCustomerEntity
//   Namespace:Ets.SingleApi.Model.Repository
//   Class Funtion:Represent the class mapping the SupplierCouponCustomerEntity table in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ets.SingleApi.Model.Repository
{
    using System;

    /// <summary>
    /// Class:SupplierCouponCustomerEntity
    /// Namespace:Ets.SingleApi.Model.Repository
    /// Class Funtion:Represent the class mapping the SupplierCouponCustomerEntity table in the database.
    /// </summary>
    /// Creator:周超
    /// Creation Date:2013/12/7 14:08:50
    /// Modifier:
    /// Last Modified:
    /// ----------------------------------------------------------------------------------------
    [Serializable]
    public class SupplierCouponCustomerEntity
    {
        #region private member

        /// <summary>
        /// The Id
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/7 14:08:51
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        private int id;

        /// <summary>
        /// The SupplierCouponID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/7 14:08:51
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        private int? supplierCouponId;

        /// <summary>
        /// The CustomerID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/7 14:08:51
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        private int? customerId;

        /// <summary>
        /// The DiscountValue
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/7 14:08:51
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        private decimal? discountValue;

        /// <summary>
        /// The Description
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/7 14:08:51
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        private string description;

        /// <summary>
        /// The CreateTime
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/7 14:08:51
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        private DateTime? createTime;

        /// <summary>
        /// The DeliveryID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/7 14:08:51
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        private int? deliveryId;

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="SupplierCouponCustomerEntity"/> class.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/7 14:08:51
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public SupplierCouponCustomerEntity()
        {
            this.id = 0;
            this.description = string.Empty;
        }

        #region public member

        /// <summary>
        /// Gets or sets a value mapping the Id of SupplierCouponCustomerEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/7 14:08:51
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
        /// Gets or sets a value mapping the SupplierCouponID of SupplierCouponCustomerEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/7 14:08:51
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public virtual int? SupplierCouponId
        {
            get
            {
                return this.supplierCouponId;
            }

            set
            {
                this.supplierCouponId = value;
            }
        }

        /// <summary>
        /// Gets or sets a value mapping the CustomerID of SupplierCouponCustomerEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/7 14:08:51
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public virtual int? CustomerId
        {
            get
            {
                return this.customerId;
            }

            set
            {
                this.customerId = value;
            }
        }

        /// <summary>
        /// Gets or sets a value mapping the DiscountValue of SupplierCouponCustomerEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/7 14:08:51
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public virtual decimal? DiscountValue
        {
            get
            {
                return this.discountValue;
            }

            set
            {
                this.discountValue = value;
            }
        }

        /// <summary>
        /// Gets or sets a value mapping the Description of SupplierCouponCustomerEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/7 14:08:51
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
        /// Gets or sets a value mapping the CreateTime of SupplierCouponCustomerEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/7 14:08:51
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

        /// <summary>
        /// Gets or sets a value mapping the DeliveryID of SupplierCouponCustomerEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/7 14:08:51
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public virtual int? DeliveryId
        {
            get
            {
                return this.deliveryId;
            }

            set
            {
                this.deliveryId = value;
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
        /// Creation Date:2013/12/7 14:08:51
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public override bool Equals(object obj)
        {
            if (obj == null || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }

            var castObj = (SupplierCouponCustomerEntity)obj;
            return this.Id == castObj.Id;
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        /// Creator:周超
        /// Creation Date:2013/12/7 14:08:51
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