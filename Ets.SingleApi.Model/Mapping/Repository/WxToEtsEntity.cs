// --------------------------------------------------------------------------------------------------------------------
// <copyright file="WxToEtsEntity.cs" company="Irdeto">
//   Copyright @ 2013
// </copyright>
// <summary>
//   Class:WxToEtsEntity
//   Namespace:Ets.SingleApi.Model.Repository
//   Class Funtion:Represent the class mapping the WxToEtsEntity table in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ets.SingleApi.Model.Repository
{
    using System;

    /// <summary>
    /// Class:WxToEtsEntity
    /// Namespace:Ets.SingleApi.Model.Repository
    /// Class Funtion:Represent the class mapping the WxToEtsEntity table in the database.
    /// </summary>
    /// Creator:周超
    /// Creation Date:2013/12/11 11:11:22
    /// Modifier:
    /// Last Modified:
    /// ----------------------------------------------------------------------------------------
    [Serializable]
    public class WxToEtsEntity
    {
        #region private member

        /// <summary>
        /// The LoginId
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/11 11:11:22
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        private int loginId;

        /// <summary>
        /// The WeChatId
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/11 11:11:22
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        private string weChatId;

        /// <summary>
        /// The InsBy
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/11 11:11:22
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        private string insBy;

        /// <summary>
        /// The InsDt
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/11 11:11:22
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        private DateTime insDt;

        /// <summary>
        /// The UpdBy
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/11 11:11:22
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        private string updBy;

        /// <summary>
        /// The UpdDt
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/11 11:11:22
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        private DateTime updDt;

        /// <summary>
        /// The Recsts
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/11 11:11:22
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        private string recsts;

        /// <summary>
        /// The SourceCd
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/11 11:11:22
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        private string sourceCd;

        /// <summary>
        /// The Id
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/11 11:11:22
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        private int id;

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="WxToEtsEntity"/> class.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/11 11:11:22
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public WxToEtsEntity()
        {
            this.loginId = 0;
            this.weChatId = string.Empty;
            this.insBy = string.Empty;
            this.insDt = DateTime.Now;
            this.updBy = string.Empty;
            this.updDt = DateTime.Now;
            this.recsts = string.Empty;
            this.sourceCd = string.Empty;
            this.id = 0;
        }

        #region public member

        /// <summary>
        /// Gets or sets a value mapping the LoginId of WxToEtsEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/11 11:11:22
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public virtual int LoginId
        {
            get
            {
                return this.loginId;
            }

            set
            {
                this.loginId = value;
            }
        }

        /// <summary>
        /// Gets or sets a value mapping the WeChatId of WxToEtsEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/11 11:11:22
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public virtual string WeChatId
        {
            get
            {
                return this.weChatId;
            }

            set
            {
                this.weChatId = value;
            }
        }

        /// <summary>
        /// Gets or sets a value mapping the InsBy of WxToEtsEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/11 11:11:22
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public virtual string InsBy
        {
            get
            {
                return this.insBy;
            }

            set
            {
                this.insBy = value;
            }
        }

        /// <summary>
        /// Gets or sets a value mapping the InsDt of WxToEtsEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/11 11:11:22
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public virtual DateTime InsDt
        {
            get
            {
                return this.insDt;
            }

            set
            {
                this.insDt = value;
            }
        }

        /// <summary>
        /// Gets or sets a value mapping the UpdBy of WxToEtsEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/11 11:11:22
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public virtual string UpdBy
        {
            get
            {
                return this.updBy;
            }

            set
            {
                this.updBy = value;
            }
        }

        /// <summary>
        /// Gets or sets a value mapping the UpdDt of WxToEtsEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/11 11:11:22
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public virtual DateTime UpdDt
        {
            get
            {
                return this.updDt;
            }

            set
            {
                this.updDt = value;
            }
        }

        /// <summary>
        /// Gets or sets a value mapping the Recsts of WxToEtsEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/11 11:11:22
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public virtual string Recsts
        {
            get
            {
                return this.recsts;
            }

            set
            {
                this.recsts = value;
            }
        }

        /// <summary>
        /// Gets or sets a value mapping the SourceCd of WxToEtsEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/11 11:11:22
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public virtual string SourceCd
        {
            get
            {
                return this.sourceCd;
            }

            set
            {
                this.sourceCd = value;
            }
        }

        /// <summary>
        /// Gets or sets a value mapping the Id of WxToEtsEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/12/11 11:11:22
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

        #endregion

        /// <summary>
        /// Determines whether the specified is equal to this instance.
        /// </summary>
        /// <param name="obj">The to compare with this instance.</param>
        /// <returns>
        /// true if the specified is equal to this instance; otherwise,false.
        /// </returns>
        /// Creator:周超
        /// Creation Date:2013/12/11 11:11:22
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public override bool Equals(object obj)
        {
            if (obj == null || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }

            var castObj = (WxToEtsEntity)obj;
            return this.Id == castObj.Id;
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        /// Creator:周超
        /// Creation Date:2013/12/11 11:11:22
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