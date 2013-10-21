// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LoginEntity.cs" company="Irdeto">
//   Copyright @ 2013
// </copyright>
// <summary>
//   Class:LoginEntity
//   Namespace:Ets.SingleApi.Model.Repository
//   Class Funtion:Represent the class mapping the LoginEntity table in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ets.SingleApi.Model.Repository
{
	using System;
	using System.Collections.Generic;
		
    /// <summary>
    /// Class:LoginEntity
    /// Namespace:Ets.SingleApi.Model.Repository
    /// Class Funtion:Represent the class mapping the LoginEntity table in the database.
    /// </summary>
    /// Creator:周超
    /// Creation Date:2013/10/13 14:01:29
    /// Modifier:
    /// Last Modified:
    /// ----------------------------------------------------------------------------------------
    [Serializable]
    public class LoginEntity
    {
		#region private member

			/// <summary>
		/// The LoginID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int loginId;

			/// <summary>
		/// The Token
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? token;

			/// <summary>
		/// The Username
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string username;

			/// <summary>
		/// The Password
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string password;

			/// <summary>
		/// The LastLogin
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private DateTime? lastLogin;

			/// <summary>
		/// The LastLoginIP
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string lastLoginIP;

			/// <summary>
		/// The IsEnabled
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private bool isEnabled;

			/// <summary>
		/// The Imprest
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private decimal? imprest;

			/// <summary>
		/// The Overdraft
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private decimal? overdraft;

			/// <summary>
		/// The PaymentCycle
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? paymentCycle;

			/// <summary>
		/// The BlockedIPAddressList
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private IList<BlockedIPAddressEntity> blockedIPAddressList;

			/// <summary>
		/// The LoginOAuthList
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private IList<LoginOAuthEntity> loginOAuthList;

			/// <summary>
		/// The SupplierList
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private IList<SupplierEntity> supplierList;

			/// <summary>
		/// The UserShowWindowList
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private IList<UserShowWindowEntity> userShowWindowList;

			/// <summary>
		/// The LevelID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private LevelEntity level;

		#endregion

		/// <summary>
        /// Initializes a new instance of the <see cref="LoginEntity"/> class.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public LoginEntity()
        {
			this.loginId = 0;
			this.username = string.Empty;
			this.password = string.Empty;
			this.lastLoginIP = string.Empty;
			this.isEnabled = false;
		}

		#region public member

			/// <summary>
        /// Gets or sets a value mapping the LoginID of LoginEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
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
        /// Gets or sets a value mapping the Token of LoginEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? Token
		{
            get
            {
                return this.token;
            }

            set
            {
                this.token = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Username of LoginEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string Username
		{
            get
            {
                return this.username;
            }

            set
            {
                this.username = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Password of LoginEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string Password
		{
            get
            {
                return this.password;
            }

            set
            {
                this.password = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the LastLogin of LoginEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual DateTime? LastLogin
		{
            get
            {
                return this.lastLogin;
            }

            set
            {
                this.lastLogin = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the LastLoginIP of LoginEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string LastLoginIP
		{
            get
            {
                return this.lastLoginIP;
            }

            set
            {
                this.lastLoginIP = value;
            }
        }

			/// <summary>
        /// Gets or sets a value indicating whether mapping the IsEnabled of LoginEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual bool IsEnabled
		{
            get
            {
                return this.isEnabled;
            }

            set
            {
                this.isEnabled = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Imprest of LoginEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual decimal? Imprest
		{
            get
            {
                return this.imprest;
            }

            set
            {
                this.imprest = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Overdraft of LoginEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual decimal? Overdraft
		{
            get
            {
                return this.overdraft;
            }

            set
            {
                this.overdraft = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the PaymentCycle of LoginEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? PaymentCycle
		{
            get
            {
                return this.paymentCycle;
            }

            set
            {
                this.paymentCycle = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the BlockedIPAddressList of LoginEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual IList<BlockedIPAddressEntity> BlockedIPAddressList
		{
            get
            {
                return this.blockedIPAddressList;
            }

            set
            {
                this.blockedIPAddressList = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the LoginOAuthList of LoginEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual IList<LoginOAuthEntity> LoginOAuthList
		{
            get
            {
                return this.loginOAuthList;
            }

            set
            {
                this.loginOAuthList = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the SupplierList of LoginEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual IList<SupplierEntity> SupplierList
		{
            get
            {
                return this.supplierList;
            }

            set
            {
                this.supplierList = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the UserShowWindowList of LoginEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual IList<UserShowWindowEntity> UserShowWindowList
		{
            get
            {
                return this.userShowWindowList;
            }

            set
            {
                this.userShowWindowList = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the LevelID of LoginEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:29
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual LevelEntity Level
		{
            get
            {
                return this.level;
            }

            set
            {
                this.level = value;
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

            var castObj = (LoginEntity)obj;
            return this.LoginId == castObj.LoginId;
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
			hash = 27 * hash * this.LoginId.GetHashCode();
			return hash;
		}
	}
}