using System;
namespace Ets.SingleApi.Model.Repository
{
    [Serializable]
    public class LogisticsAreaEntity
    {
        #region private member

        /// <summary>
        /// The AreaId
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/8/20 11:20:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        private int areaId;

        /// <summary>
        /// The AreaName
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/8/20 11:20:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        private string areaName;

        /// <summary>
        /// The Map
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/8/20 11:20:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        private byte[] map;

        /// <summary>
        /// The RegionCode
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/8/20 11:20:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        private string regionCode;

        /// <summary>
        /// The Note
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/8/20 11:20:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        private string note;

        /// <summary>
        /// The Coods
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/8/20 11:20:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        private string coods;

        /// <summary>
        /// The LogisticsId
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/8/20 11:20:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        private int? logisticsId;

        /// <summary>
        /// The IsEnabled
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/8/20 11:20:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        private bool? isEnabled;

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="LogisticsAreaEntity"/> class.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/8/20 11:20:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public LogisticsAreaEntity()
        {
            this.areaId = 0;
            this.areaName = string.Empty;
            this.map = null;
            this.regionCode = string.Empty;
            this.note = string.Empty;
            this.coods = string.Empty;
        }

        #region public member

        /// <summary>
        /// Gets or sets a value mapping the AreaId of LogisticsAreaEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/8/20 11:20:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public virtual int AreaId
        {
            get { return this.areaId; }

            set { this.areaId = value; }
        }

        /// <summary>
        /// Gets or sets a value mapping the AreaName of LogisticsAreaEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/8/20 11:20:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public virtual string AreaName
        {
            get { return this.areaName; }

            set { this.areaName = value; }
        }

        /// <summary>
        /// Gets or sets a value mapping the Map of LogisticsAreaEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/8/20 11:20:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public virtual byte[] Map
        {
            get { return this.map; }

            set { this.map = value; }
        }

        /// <summary>
        /// Gets or sets a value mapping the RegionCode of LogisticsAreaEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/8/20 11:20:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public virtual string RegionCode
        {
            get { return this.regionCode; }

            set { this.regionCode = value; }
        }

        /// <summary>
        /// Gets or sets a value mapping the Note of LogisticsAreaEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/8/20 11:20:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public virtual string Note
        {
            get { return this.note; }

            set { this.note = value; }
        }

        /// <summary>
        /// Gets or sets a value mapping the Coods of LogisticsAreaEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/8/20 11:20:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public virtual string Coods
        {
            get { return this.coods; }

            set { this.coods = value; }
        }

        /// <summary>
        /// Gets or sets a value mapping the LogisticsId of LogisticsAreaEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/8/20 11:20:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public virtual int? LogisticsId
        {
            get { return this.logisticsId; }

            set { this.logisticsId = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether mapping the IsEnabled of LogisticsAreaEntity table in the database.
        /// </summary>
        /// Creator:ww
        /// Creation Date:2014/8/20 11:20:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public virtual bool? IsEnabled
        {
            get { return this.isEnabled; }

            set { this.isEnabled = value; }
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
        /// Creation Date:2014/8/20 11:20:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public override bool Equals(object obj)
        {
            if (obj == null || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }

            var castObj = (LogisticsAreaEntity) obj;
            return this.AreaId == castObj.AreaId;
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        /// Creator:ww
        /// Creation Date:2014/8/20 11:20:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public override int GetHashCode()
        {
            var hash = 57;
            hash = 27*hash*this.AreaId.GetHashCode();
            return hash;
        }
    }
}
