// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SupplierLogisticsAreaEntity.cs" company="Irdeto">
//   Copyright @ 2014
// </copyright>
// <summary>
//   Class:SupplierLogisticsAreaEntity
//   Namespace:Ets.SingleApi.Model.Repository
//   Class Funtion:Represent the class mapping the SupplierLogisticsAreaEntity table in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ets.SingleApi.Model.Repository
{
    using System;

    /// <summary>
    /// Class:SupplierLogisticsAreaEntity
    /// Namespace:Ets.SingleApi.Model.Repository
    /// Class Funtion:Represent the class mapping the SupplierLogisticsAreaEntity table in the database.
    /// </summary>
    /// Creator:ww
    /// Creation Date:2014/8/20 11:26:04
    /// Modifier:
    /// Last Modified:
    /// ----------------------------------------------------------------------------------------
    [Serializable]
    public class SupplierLogisticsAreaEntity
    {
        #region private member

        /// <summary>
        /// The ID
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/8/20 11:26:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        private int id;

        /// <summary>
        /// The SupplierID
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/8/20 11:26:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        private int supplierId;

        /// <summary>
        /// The LogisticsAreaID
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/8/20 11:26:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        private int logisticsAreaId;

        /// <summary>
        /// The Priority
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/8/20 11:26:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        private int? priority;

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="SupplierLogisticsAreaEntity"/> class.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/8/20 11:26:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public SupplierLogisticsAreaEntity()
        {
            this.id = 0;
            this.supplierId = 0;
            this.logisticsAreaId = 0;
        }

        #region public member

        /// <summary>
        /// Gets or sets a value mapping the ID of SupplierLogisticsAreaEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/8/20 11:26:05
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
        /// Gets or sets a value mapping the SupplierID of SupplierLogisticsAreaEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/8/20 11:26:05
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
        /// Gets or sets a value mapping the LogisticsAreaID of SupplierLogisticsAreaEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/8/20 11:26:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public virtual int LogisticsAreaId
        {
            get
            {
                return this.logisticsAreaId;
            }

            set
            {
                this.logisticsAreaId = value;
            }
        }

        /// <summary>
        /// Gets or sets a value mapping the Priority of SupplierLogisticsAreaEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/8/20 11:26:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public virtual int? Priority
        {
            get
            {
                return this.priority;
            }

            set
            {
                this.priority = value;
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
        /// Creation Date:2014/8/20 11:26:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public override bool Equals(object obj)
        {
            if (obj == null || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }

            var castObj = (SupplierLogisticsAreaEntity)obj;
            return this.Id == castObj.Id;
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        /// Creator:ww
        /// Creation Date:2014/8/20 11:26:05
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