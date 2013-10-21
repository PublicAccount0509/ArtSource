// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TokenEntity.cs" company="Irdeto">
//   Copyright @ 2013
// </copyright>
// <summary>
//   Class:TokenEntity
//   Namespace:Ets.SingleApi.Model.Repository
//   Class Funtion:Represent the class mapping the TokenEntity table in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ets.SingleApi.Model.Repository
{
	using System;
		
    /// <summary>
    /// Class:TokenEntity
    /// Namespace:Ets.SingleApi.Model.Repository
    /// Class Funtion:Represent the class mapping the TokenEntity table in the database.
    /// </summary>
    /// Creator:周超
    /// Creation Date:2013/10/12 22:16:57
    /// Modifier:
    /// Last Modified:
    /// ----------------------------------------------------------------------------------------
    [Serializable]
    public class TokenEntity
    {
		#region private member

			/// <summary>
		/// The AccessToken
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/12 22:16:57
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string accessToken;

			/// <summary>
		/// The Scope
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/12 22:16:57
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string scope;

			/// <summary>
		/// The UserId
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/12 22:16:57
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? userId;

			/// <summary>
		/// The RefreshToken
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/12 22:16:57
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string refreshToken;

			/// <summary>
		/// The CreatedTime
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/12 22:16:57
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private DateTime? createdTime;

			/// <summary>
		/// The AppKey
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/12 22:16:57
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private AppEntity appKey;

		#endregion

		/// <summary>
        /// Initializes a new instance of the <see cref="TokenEntity"/> class.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/12 22:16:57
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public TokenEntity()
        {
			this.accessToken = string.Empty;
			this.scope = string.Empty;
			this.refreshToken = string.Empty;
		}

		#region public member

			/// <summary>
        /// Gets or sets a value mapping the AccessToken of TokenEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/12 22:16:57
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string AccessToken
		{
            get
            {
                return this.accessToken;
            }

            set
            {
                this.accessToken = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Scope of TokenEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/12 22:16:57
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string Scope
		{
            get
            {
                return this.scope;
            }

            set
            {
                this.scope = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the UserId of TokenEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/12 22:16:57
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? UserId
		{
            get
            {
                return this.userId;
            }

            set
            {
                this.userId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the RefreshToken of TokenEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/12 22:16:57
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string RefreshToken
		{
            get
            {
                return this.refreshToken;
            }

            set
            {
                this.refreshToken = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the CreatedTime of TokenEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/12 22:16:57
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual DateTime? CreatedTime
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
        /// Gets or sets a value mapping the AppKey of TokenEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/12 22:16:57
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual AppEntity AppKey
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

            var castObj = (TokenEntity)obj;
            return this.AccessToken == castObj.AccessToken;
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
			hash = 27 * hash * this.AccessToken.GetHashCode();
			return hash;
		}
	}
}