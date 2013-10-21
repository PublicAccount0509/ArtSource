// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AppEntity.cs" company="Irdeto">
//   Copyright @ 2013
// </copyright>
// <summary>
//   Class:AppEntity
//   Namespace:Ets.SingleApi.Model.Repository
//   Class Funtion:Represent the class mapping the AppEntity table in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ets.SingleApi.Model.Repository
{
	using System;
	using System.Collections.Generic;
		
    /// <summary>
    /// Class:AppEntity
    /// Namespace:Ets.SingleApi.Model.Repository
    /// Class Funtion:Represent the class mapping the AppEntity table in the database.
    /// </summary>
    /// Creator:周超
    /// Creation Date:2013/10/12 22:16:57
    /// Modifier:
    /// Last Modified:
    /// ----------------------------------------------------------------------------------------
    [Serializable]
    public class AppEntity
    {
		#region private member

			/// <summary>
		/// The AppKey
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/12 22:16:57
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string appKey;

			/// <summary>
		/// The AppSecret
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/12 22:16:57
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string appSecret;

			/// <summary>
		/// The Name
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/12 22:16:57
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string name;

			/// <summary>
		/// The Icon
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/12 22:16:57
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string icon;

			/// <summary>
		/// The RedirectUri
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/12 22:16:57
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string redirectUri;

			/// <summary>
		/// The Intro
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/12 22:16:57
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string intro;

			/// <summary>
		/// The HomeUri
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/12 22:16:57
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string homeUri;

			/// <summary>
		/// The AppType
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/12 22:16:57
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private byte appType;

			/// <summary>
		/// The Status
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/12 22:16:57
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private byte status;

			/// <summary>
		/// The CreatedTime
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/12 22:16:57
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private DateTime createdTime;

			/// <summary>
		/// The AppLevel
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/12 22:16:57
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private byte appLevel;

			/// <summary>
		/// The Version
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/12 22:16:57
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string version;

			/// <summary>
		/// The VersionType
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/12 22:16:57
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private byte? versionType;

			/// <summary>
		/// The VersionLog
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/12 22:16:57
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string versionLog;

			/// <summary>
		/// The DownloadUrl
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/12 22:16:57
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string downloadUrl;

			/// <summary>
		/// The Os
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/12 22:16:57
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string os;

			/// <summary>
		/// The VersionName
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/12 22:16:57
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string versionName;

			/// <summary>
		/// The VersionCode
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/12 22:16:57
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? versionCode;

			/// <summary>
		/// The AutorizationList
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/12 22:16:57
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private IList<AutorizationEntity> autorizationList;

			/// <summary>
		/// The TokenList
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/12 22:16:57
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private IList<TokenEntity> tokenList;

		#endregion

		/// <summary>
        /// Initializes a new instance of the <see cref="AppEntity"/> class.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/12 22:16:57
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public AppEntity()
        {
			this.appKey = string.Empty;
			this.appSecret = string.Empty;
			this.name = string.Empty;
			this.icon = string.Empty;
			this.redirectUri = string.Empty;
			this.intro = string.Empty;
			this.homeUri = string.Empty;
			this.appType = 0;
			this.status = 0;
			this.createdTime = DateTime.Now;
			this.appLevel = 0;
			this.version = string.Empty;
			this.versionLog = string.Empty;
			this.downloadUrl = string.Empty;
			this.os = string.Empty;
			this.versionName = string.Empty;
		}

		#region public member

			/// <summary>
        /// Gets or sets a value mapping the AppKey of AppEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/12 22:16:57
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string AppKey
		{
            get
            {
                return this.appKey;
            }

            set
            {
                this.appKey = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the AppSecret of AppEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/12 22:16:57
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string AppSecret
		{
            get
            {
                return this.appSecret;
            }

            set
            {
                this.appSecret = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Name of AppEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/12 22:16:57
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string Name
		{
            get
            {
                return this.name;
            }

            set
            {
                this.name = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Icon of AppEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/12 22:16:57
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string Icon
		{
            get
            {
                return this.icon;
            }

            set
            {
                this.icon = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the RedirectUri of AppEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/12 22:16:57
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string RedirectUri
		{
            get
            {
                return this.redirectUri;
            }

            set
            {
                this.redirectUri = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Intro of AppEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/12 22:16:57
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string Intro
		{
            get
            {
                return this.intro;
            }

            set
            {
                this.intro = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the HomeUri of AppEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/12 22:16:57
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string HomeUri
		{
            get
            {
                return this.homeUri;
            }

            set
            {
                this.homeUri = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the AppType of AppEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/12 22:16:57
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual byte AppType
		{
            get
            {
                return this.appType;
            }

            set
            {
                this.appType = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Status of AppEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/12 22:16:57
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual byte Status
		{
            get
            {
                return this.status;
            }

            set
            {
                this.status = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the CreatedTime of AppEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/12 22:16:57
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual DateTime CreatedTime
		{
            get
            {
                return this.createdTime;
            }

            set
            {
                this.createdTime = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the AppLevel of AppEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/12 22:16:57
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual byte AppLevel
		{
            get
            {
                return this.appLevel;
            }

            set
            {
                this.appLevel = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Version of AppEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/12 22:16:57
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string Version
		{
            get
            {
                return this.version;
            }

            set
            {
                this.version = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the VersionType of AppEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/12 22:16:57
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual byte? VersionType
		{
            get
            {
                return this.versionType;
            }

            set
            {
                this.versionType = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the VersionLog of AppEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/12 22:16:57
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string VersionLog
		{
            get
            {
                return this.versionLog;
            }

            set
            {
                this.versionLog = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the DownloadUrl of AppEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/12 22:16:57
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string DownloadUrl
		{
            get
            {
                return this.downloadUrl;
            }

            set
            {
                this.downloadUrl = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Os of AppEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/12 22:16:57
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string Os
		{
            get
            {
                return this.os;
            }

            set
            {
                this.os = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the VersionName of AppEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/12 22:16:57
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string VersionName
		{
            get
            {
                return this.versionName;
            }

            set
            {
                this.versionName = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the VersionCode of AppEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/12 22:16:57
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? VersionCode
		{
            get
            {
                return this.versionCode;
            }

            set
            {
                this.versionCode = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the AutorizationList of AppEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/12 22:16:57
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual IList<AutorizationEntity> AutorizationList
		{
            get
            {
                return this.autorizationList;
            }

            set
            {
                this.autorizationList = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the TokenList of AppEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/12 22:16:57
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual IList<TokenEntity> TokenList
		{
            get
            {
                return this.tokenList;
            }

            set
            {
                this.tokenList = value;
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
        /// Creation Date:2013/10/12 22:16:57
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public override bool Equals(object obj)
        {
            if (obj == null || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }

            var castObj = (AppEntity)obj;
            return this.AppKey == castObj.AppKey;
        }

		/// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        /// Creator:周超
        /// Creation Date:2013/10/12 22:16:57
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public override int GetHashCode()
		{
			var hash = 57; 
			hash = 27 * hash * this.AppKey.GetHashCode();
			return hash;
		}
	}
}