// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SupplierDoNotSendTimeEntity.cs" company="Irdeto">
//   Copyright @ 2014
// </copyright>
// <summary>
//   Class:SupplierDoNotSendTimeEntity
//   Namespace:Ets.SingleApi.Model.Repository
//   Class Funtion:Represent the class mapping the SupplierDoNotSendTimeEntity table in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ets.SingleApi.Model.Repository
{
    using System;

    /// <summary>
    /// Class:SupplierDoNotSendTimeEntity
    /// Namespace:Ets.SingleApi.Model.Repository
    /// Class Funtion:Represent the class mapping the SupplierDoNotSendTimeEntity table in the database.
    /// </summary>
    /// Creator:周超
    /// Creation Date:2014/1/2 18:35:16
    /// Modifier:
    /// Last Modified:
    /// ----------------------------------------------------------------------------------------
    [Serializable]
    public class SupplierDoNotSendTimeEntity
    {
        #region private member

        /// <summary>
        /// The NotSendTimeId
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/1/2 18:35:16
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        private int notSendTimeId;

        /// <summary>
        /// The SupplierId
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/1/2 18:35:16
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        private int? supplierId;

        /// <summary>
        /// The NotSendDate
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/1/2 18:35:16
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        private string notSendDate;

        /// <summary>
        /// The NotSendTime
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/1/2 18:35:16
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        private int? notSendTime;

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="SupplierDoNotSendTimeEntity"/> class.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/1/2 18:35:16
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public SupplierDoNotSendTimeEntity()
        {
            this.notSendTimeId = 0;
            this.notSendDate = string.Empty;
        }

        #region public member

        /// <summary>
        /// Gets or sets a value mapping the NotSendTimeId of SupplierDoNotSendTimeEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/1/2 18:35:16
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public virtual int NotSendTimeId
        {
            get
            {
                return this.notSendTimeId;
            }

            set
            {
                this.notSendTimeId = value;
            }
        }

        /// <summary>
        /// Gets or sets a value mapping the SupplierId of SupplierDoNotSendTimeEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/1/2 18:35:16
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
        /// Gets or sets a value mapping the NotSendDate of SupplierDoNotSendTimeEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/1/2 18:35:16
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public virtual string NotSendDate
        {
            get
            {
                return this.notSendDate;
            }

            set
            {
                this.notSendDate = value;
            }
        }

        /// <summary>
        /// Gets or sets a value mapping the NotSendTime of SupplierDoNotSendTimeEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2014/1/2 18:35:16
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public virtual int? NotSendTime
        {
            get
            {
                return this.notSendTime;
            }

            set
            {
                this.notSendTime = value;
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
        /// Creation Date:2014/1/2 18:35:16
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public override bool Equals(object obj)
        {
            if (obj == null || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }

            var castObj = (SupplierDoNotSendTimeEntity)obj;
            return this.NotSendTimeId == castObj.NotSendTimeId;
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        /// Creator:周超
        /// Creation Date:2014/1/2 18:35:16
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public override int GetHashCode()
        {
            var hash = 57;
            hash = 27 * hash * this.NotSendTimeId.GetHashCode();
            return hash;
        }
    }
}