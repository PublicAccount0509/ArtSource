// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserShowWindowEntity.cs" company="Irdeto">
//   Copyright @ 2013
// </copyright>
// <summary>
//   Class:UserShowWindowEntity
//   Namespace:Ets.SingleApi.Model.Repository
//   Class Funtion:Represent the class mapping the UserShowWindowEntity table in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ets.SingleApi.Model.Repository
{
	using System;
		
    /// <summary>
    /// Class:UserShowWindowEntity
    /// Namespace:Ets.SingleApi.Model.Repository
    /// Class Funtion:Represent the class mapping the UserShowWindowEntity table in the database.
    /// </summary>
    /// Creator:周超
    /// Creation Date:2013/10/13 14:18:49
    /// Modifier:
    /// Last Modified:
    /// ----------------------------------------------------------------------------------------
    [Serializable]
    public class UserShowWindowEntity
    {
		#region private member

			/// <summary>
		/// The ShoWinId
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:49
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int shoWinId;

			/// <summary>
		/// The WinType
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:49
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? winType;

			/// <summary>
		/// The IsShowWindow
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:49
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private bool? isShowWindow;

			/// <summary>
		/// The LoginId
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:49
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private LoginEntity login;

		#endregion

		/// <summary>
        /// Initializes a new instance of the <see cref="UserShowWindowEntity"/> class.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:49
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public UserShowWindowEntity()
        {
			this.shoWinId = 0;
		}

		#region public member

			/// <summary>
        /// Gets or sets a value mapping the ShoWinId of UserShowWindowEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:49
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int ShoWinId
		{
            get
            {
                return this.shoWinId;
            }

            set
            {
                this.shoWinId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the WinType of UserShowWindowEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:49
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? WinType
		{
            get
            {
                return this.winType;
            }

            set
            {
                this.winType = value;
            }
        }

			/// <summary>
        /// Gets or sets a value indicating whether mapping the IsShowWindow of UserShowWindowEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:49
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual bool? IsShowWindow
		{
            get
            {
                return this.isShowWindow;
            }

            set
            {
                this.isShowWindow = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the LoginId of UserShowWindowEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:49
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
        /// Creation Date:2013/10/13 14:18:49
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public override bool Equals(object obj)
        {
            if (obj == null || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }

            var castObj = (UserShowWindowEntity)obj;
            return this.ShoWinId == castObj.ShoWinId;
        }

		/// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:49
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public override int GetHashCode()
		{
			var hash = 57; 
			hash = 27 * hash * this.ShoWinId.GetHashCode();
			return hash;
		}
	}
}