// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AutorizationEntity.cs" company="Irdeto">
//   Copyright @ 2013
// </copyright>
// <summary>
//   Class:AutorizationEntity
//   Namespace:Ets.SingleApi.Model.Repository
//   Class Funtion:Represent the class mapping the AutorizationEntity table in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ets.SingleApi.Model.Repository
{
	using System;
		
    /// <summary>
    /// Class:AutorizationEntity
    /// Namespace:Ets.SingleApi.Model.Repository
    /// Class Funtion:Represent the class mapping the AutorizationEntity table in the database.
    /// </summary>
    /// Creator:周超
    /// Creation Date:2013/10/12 22:16:57
    /// Modifier:
    /// Last Modified:
    /// ----------------------------------------------------------------------------------------
    [Serializable]
    public class AutorizationEntity
    {
		#region private member

			/// <summary>
		/// The Id
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/12 22:16:57
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int id;

			/// <summary>
		/// The UserId
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/12 22:16:57
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int userId;

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
		private DateTime createdTime;

			/// <summary>
		/// The Code
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/12 22:16:57
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string code;

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
        /// Initializes a new instance of the <see cref="AutorizationEntity"/> class.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/12 22:16:57
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public AutorizationEntity()
        {
			this.id = 0;
			this.userId = 0;
			this.scope = string.Empty;
			this.createdTime = DateTime.Now;
			this.code = string.Empty;
		}

		#region public member

			/// <summary>
        /// Gets or sets a value mapping the Id of AutorizationEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/12 22:16:57
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

			/// <summary>
        /// Gets or sets a value mapping the UserId of AutorizationEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/12 22:16:57
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int UserId
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
        /// Gets or sets a value mapping the Scope of AutorizationEntity table in the database.
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
        /// Gets or sets a value mapping the CreatedTime of AutorizationEntity table in the database.
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
        /// Gets or sets a value mapping the Code of AutorizationEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/12 22:16:57
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string Code
		{
            get
            {
                return this.code;
            }

            set
            {
                this.code = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the AppKey of AutorizationEntity table in the database.
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

            var castObj = (AutorizationEntity)obj;
            return this.Id == castObj.Id;
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
			hash = 27 * hash * this.Id.GetHashCode();
			return hash;
		}
	}
}