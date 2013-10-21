// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SuppTimeTableDisplayEntity.cs" company="Irdeto">
//   Copyright @ 2013
// </copyright>
// <summary>
//   Class:SuppTimeTableDisplayEntity
//   Namespace:Ets.SingleApi.Model.Repository
//   Class Funtion:Represent the class mapping the SuppTimeTableDisplayEntity table in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ets.SingleApi.Model.Repository
{
    using System;

    /// <summary>
    /// Class:SuppTimeTableDisplayEntity
    /// Namespace:Ets.SingleApi.Model.Repository
    /// Class Funtion:Represent the class mapping the SuppTimeTableDisplayEntity table in the database.
    /// </summary>
    /// Creator:周超
    /// Creation Date:2013/10/19 23:24:23
    /// Modifier:
    /// Last Modified:
    /// ----------------------------------------------------------------------------------------
    [Serializable]
    public class SuppTimeTableDisplayEntity
    {
        #region private member

        /// <summary>
        /// The STimeTableDisID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/19 23:24:23
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        private int sTimeTableDisId;

        /// <summary>
        /// The SupplierID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/19 23:24:23
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        private int? supplierId;

        /// <summary>
        /// The TimeTableDisplayID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/19 23:24:23
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        private int? timeTableDisplayId;

        /// <summary>
        /// The Day
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/19 23:24:23
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        private int? day;

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="SuppTimeTableDisplayEntity"/> class.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/19 23:24:23
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public SuppTimeTableDisplayEntity()
        {
            this.sTimeTableDisId = 0;
        }

        #region public member

        /// <summary>
        /// Gets or sets a value mapping the STimeTableDisID of SuppTimeTableDisplayEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/19 23:24:23
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public virtual int STimeTableDisId
        {
            get
            {
                return this.sTimeTableDisId;
            }

            set
            {
                this.sTimeTableDisId = value;
            }
        }

        /// <summary>
        /// Gets or sets a value mapping the SupplierID of SuppTimeTableDisplayEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/19 23:24:23
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
        /// Gets or sets a value mapping the TimeTableDisplayID of SuppTimeTableDisplayEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/19 23:24:23
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public virtual int? TimeTableDisplayId
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
        /// Gets or sets a value mapping the Day of SuppTimeTableDisplayEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/19 23:24:23
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public virtual int? Day
        {
            get
            {
                return this.day;
            }

            set
            {
                this.day = value;
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
        /// Creation Date:2013/10/19 23:24:23
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public override bool Equals(object obj)
        {
            if (obj == null || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }

            var castObj = (SuppTimeTableDisplayEntity)obj;
            return this.STimeTableDisId == castObj.STimeTableDisId;
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        /// Creator:周超
        /// Creation Date:2013/10/19 23:24:23
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public override int GetHashCode()
        {
            var hash = 57;
            hash = 27 * hash * this.STimeTableDisId.GetHashCode();
            return hash;
        }
    }
}