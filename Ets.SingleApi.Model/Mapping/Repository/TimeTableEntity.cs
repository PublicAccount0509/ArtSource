// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TimeTableEntity.cs" company="Irdeto">
//   Copyright @ 2013
// </copyright>
// <summary>
//   Class:TimeTableEntity
//   Namespace:Ets.SingleApi.Model.Repository
//   Class Funtion:Represent the class mapping the TimeTableEntity table in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ets.SingleApi.Model.Repository
{
    using System;

    /// <summary>
    /// Class:TimeTableEntity
    /// Namespace:Ets.SingleApi.Model.Repository
    /// Class Funtion:Represent the class mapping the TimeTableEntity table in the database.
    /// </summary>
    /// Creator:周超
    /// Creation Date:2013/12/11 14:08:42
    /// Modifier:
    /// Last Modified:
    /// ----------------------------------------------------------------------------------------
    [Serializable]
    public class TimeTableEntity
    {
        #region private member

        /// <summary>
        /// The TimeTableID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/11 14:08:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        private int timeTableId;

        /// <summary>
        /// The OpenTime
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/11 14:08:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        private DateTime openTime;

        /// <summary>
        /// The CloseTime
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/11 14:08:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        private DateTime closeTime;

        /// <summary>
        /// The LastDeliveryTime
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/11 14:08:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        private DateTime? lastDeliveryTime;

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="TimeTableEntity"/> class.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/11 14:08:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public TimeTableEntity()
        {
            this.timeTableId = 0;
            this.openTime = DateTime.Now;
            this.closeTime = DateTime.Now;
        }

        #region public member

        /// <summary>
        /// Gets or sets a value mapping the TimeTableID of TimeTableEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/11 14:08:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public virtual int TimeTableId
        {
            get
            {
                return this.timeTableId;
            }

            set
            {
                this.timeTableId = value;
            }
        }

        /// <summary>
        /// Gets or sets a value mapping the OpenTime of TimeTableEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/11 14:08:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public virtual DateTime OpenTime
        {
            get
            {
                return this.openTime;
            }

            set
            {
                this.openTime = value;
            }
        }

        /// <summary>
        /// Gets or sets a value mapping the CloseTime of TimeTableEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/11 14:08:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public virtual DateTime CloseTime
        {
            get
            {
                return this.closeTime;
            }

            set
            {
                this.closeTime = value;
            }
        }

        /// <summary>
        /// Gets or sets a value mapping the LastDeliveryTime of TimeTableEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/11 14:08:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public virtual DateTime? LastDeliveryTime
        {
            get
            {
                return this.lastDeliveryTime;
            }

            set
            {
                this.lastDeliveryTime = value;
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
        /// Creation Date:2013/12/11 14:08:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public override bool Equals(object obj)
        {
            if (obj == null || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }

            var castObj = (TimeTableEntity)obj;
            return this.TimeTableId == castObj.TimeTableId;
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        /// Creator:周超
        /// Creation Date:2013/12/11 14:08:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public override int GetHashCode()
        {
            var hash = 57;
            hash = 27 * hash * this.TimeTableId.GetHashCode();
            return hash;
        }
    }
}