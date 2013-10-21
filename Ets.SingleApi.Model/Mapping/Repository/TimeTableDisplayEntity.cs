// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TimeTableDisplayEntity.cs" company="Irdeto">
//   Copyright @ 2013
// </copyright>
// <summary>
//   Class:TimeTableDisplayEntity
//   Namespace:Ets.SingleApi.Model.Repository
//   Class Funtion:Represent the class mapping the TimeTableDisplayEntity table in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ets.SingleApi.Model.Repository
{
    using System;

    /// <summary>
    /// Class:TimeTableDisplayEntity
    /// Namespace:Ets.SingleApi.Model.Repository
    /// Class Funtion:Represent the class mapping the TimeTableDisplayEntity table in the database.
    /// </summary>
    /// Creator:周超
    /// Creation Date:2013/10/19 23:22:10
    /// Modifier:
    /// Last Modified:
    /// ----------------------------------------------------------------------------------------
    [Serializable]
    public class TimeTableDisplayEntity
    {
        #region private member

        /// <summary>
        /// The TimeTableDisplayID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/19 23:22:10
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        private int timeTableDisplayId;

        /// <summary>
        /// The OpenTime
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/19 23:22:10
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        private DateTime? openTime;

        /// <summary>
        /// The CloseTime
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/19 23:22:10
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        private DateTime? closeTime;

        /// <summary>
        /// The LastDeliveryTime
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/19 23:22:10
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        private DateTime? lastDeliveryTime;

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="TimeTableDisplayEntity"/> class.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/19 23:22:10
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public TimeTableDisplayEntity()
        {
            this.timeTableDisplayId = 0;
        }

        #region public member

        /// <summary>
        /// Gets or sets a value mapping the TimeTableDisplayID of TimeTableDisplayEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/19 23:22:10
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public virtual int TimeTableDisplayId
        {
            get
            {
                return this.timeTableDisplayId;
            }

            set
            {
                this.timeTableDisplayId = value;
            }
        }

        /// <summary>
        /// Gets or sets a value mapping the OpenTime of TimeTableDisplayEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/19 23:22:10
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public virtual DateTime? OpenTime
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
        /// Gets or sets a value mapping the CloseTime of TimeTableDisplayEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/19 23:22:10
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public virtual DateTime? CloseTime
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
        /// Gets or sets a value mapping the LastDeliveryTime of TimeTableDisplayEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/19 23:22:10
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
        /// Creation Date:2013/10/19 23:22:10
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public override bool Equals(object obj)
        {
            if (obj == null || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }

            var castObj = (TimeTableDisplayEntity)obj;
            return this.TimeTableDisplayId == castObj.TimeTableDisplayId;
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        /// Creator:周超
        /// Creation Date:2013/10/19 23:22:10
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public override int GetHashCode()
        {
            var hash = 57;
            hash = 27 * hash * this.TimeTableDisplayId.GetHashCode();
            return hash;
        }
    }
}