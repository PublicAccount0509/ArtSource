// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AppScopeEntity.cs" company="Irdeto">
//   Copyright @ 2013
// </copyright>
// <summary>
//   Class:AppScopeEntity
//   Namespace:Ets.SingleApi.Model.Repository
//   Class Funtion:Represent the class mapping the AppScopeEntity table in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ets.SingleApi.Model.Repository
{
	using System;
		
    /// <summary>
    /// Class:AppScopeEntity
    /// Namespace:Ets.SingleApi.Model.Repository
    /// Class Funtion:Represent the class mapping the AppScopeEntity table in the database.
    /// </summary>
    /// Creator:周超
    /// Creation Date:2013/10/12 22:16:57
    /// Modifier:
    /// Last Modified:
    /// ----------------------------------------------------------------------------------------
    [Serializable]
    public class AppScopeEntity
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
		/// The Scope
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/12 22:16:57
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string scope;

			/// <summary>
		/// The CreatedTime
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/12 22:16:57
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private DateTime? createdTime;

		#endregion

		/// <summary>
        /// Initializes a new instance of the <see cref="AppScopeEntity"/> class.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/12 22:16:57
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public AppScopeEntity()
        {
			this.appKey = string.Empty;
			this.scope = string.Empty;
		}

		#region public member

			/// <summary>
        /// Gets or sets a value mapping the AppKey of AppScopeEntity table in the database.
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
        /// Gets or sets a value mapping the Scope of AppScopeEntity table in the database.
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
        /// Gets or sets a value mapping the CreatedTime of AppScopeEntity table in the database.
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

            var castObj = (AppScopeEntity)obj;
            return this.AppKey == castObj.AppKey && this.Scope == castObj.Scope;
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
			hash = 27 * hash * this.Scope.GetHashCode();
			return hash;
		}
	}
}