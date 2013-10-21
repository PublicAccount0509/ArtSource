// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LoginOAuthEntity.cs" company="Irdeto">
//   Copyright @ 2013
// </copyright>
// <summary>
//   Class:LoginOAuthEntity
//   Namespace:Ets.SingleApi.Model.Repository
//   Class Funtion:Represent the class mapping the LoginOAuthEntity table in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ets.SingleApi.Model.Repository
{
	using System;
		
    /// <summary>
    /// Class:LoginOAuthEntity
    /// Namespace:Ets.SingleApi.Model.Repository
    /// Class Funtion:Represent the class mapping the LoginOAuthEntity table in the database.
    /// </summary>
    /// Creator:周超
    /// Creation Date:2013/10/13 14:18:48
    /// Modifier:
    /// Last Modified:
    /// ----------------------------------------------------------------------------------------
    [Serializable]
    public class LoginOAuthEntity
    {
		#region private member

			/// <summary>
		/// The LOId
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int lOId;

			/// <summary>
		/// The KeyName
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string keyName;

			/// <summary>
		/// The safeCode
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string safeCode;

			/// <summary>
		/// The JointLoginType
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? jointLoginType;

			/// <summary>
		/// The LoginID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private LoginEntity login;

		#endregion

		/// <summary>
        /// Initializes a new instance of the <see cref="LoginOAuthEntity"/> class.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public LoginOAuthEntity()
        {
			this.lOId = 0;
			this.keyName = string.Empty;
			this.safeCode = string.Empty;
		}

		#region public member

			/// <summary>
        /// Gets or sets a value mapping the LOId of LoginOAuthEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int LOId
		{
            get
            {
                return this.lOId;
            }

            set
            {
                this.lOId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the KeyName of LoginOAuthEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string KeyName
		{
            get
            {
                return this.keyName;
            }

            set
            {
                this.keyName = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the safeCode of LoginOAuthEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string SafeCode
		{
            get
            {
                return this.safeCode;
            }

            set
            {
                this.safeCode = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the JointLoginType of LoginOAuthEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? JointLoginType
		{
            get
            {
                return this.jointLoginType;
            }

            set
            {
                this.jointLoginType = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the LoginID of LoginOAuthEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual LoginEntity Login
		{
            get
            {
                return this.login;
            }

            set
            {
                this.login = value;
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
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public override bool Equals(object obj)
        {
            if (obj == null || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }

            var castObj = (LoginOAuthEntity)obj;
            return this.LOId == castObj.LOId;
        }

		/// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public override int GetHashCode()
		{
			var hash = 57; 
			hash = 27 * hash * this.LOId.GetHashCode();
			return hash;
		}
	}
}