// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BlockedIPAddressEntity.cs" company="Irdeto">
//   Copyright @ 2013
// </copyright>
// <summary>
//   Class:BlockedIPAddressEntity
//   Namespace:Ets.SingleApi.Model.Repository
//   Class Funtion:Represent the class mapping the BlockedIPAddressEntity table in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ets.SingleApi.Model.Repository
{
	using System;
		
    /// <summary>
    /// Class:BlockedIPAddressEntity
    /// Namespace:Ets.SingleApi.Model.Repository
    /// Class Funtion:Represent the class mapping the BlockedIPAddressEntity table in the database.
    /// </summary>
    /// Creator:周超
    /// Creation Date:2013/10/13 14:18:47
    /// Modifier:
    /// Last Modified:
    /// ----------------------------------------------------------------------------------------
    [Serializable]
    public class BlockedIPAddressEntity
    {
		#region private member

			/// <summary>
		/// The IP_ID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:47
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int iPId;

			/// <summary>
		/// The IPAddress
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:47
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string iPAddress;

			/// <summary>
		/// The IsBlocked
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:47
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private bool? isBlocked;

			/// <summary>
		/// The DateBlocked
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:47
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private DateTime? dateBlocked;

			/// <summary>
		/// The LoginID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:47
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private LoginEntity login;

		#endregion

		/// <summary>
        /// Initializes a new instance of the <see cref="BlockedIPAddressEntity"/> class.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:47
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public BlockedIPAddressEntity()
        {
			this.iPId = 0;
			this.iPAddress = string.Empty;
		}

		#region public member

			/// <summary>
        /// Gets or sets a value mapping the IP_ID of BlockedIPAddressEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:47
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int IPId
		{
            get
            {
                return this.iPId;
            }

            set
            {
                this.iPId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the IPAddress of BlockedIPAddressEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:47
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string IPAddress
		{
            get
            {
                return this.iPAddress;
            }

            set
            {
                this.iPAddress = value;
            }
        }

			/// <summary>
        /// Gets or sets a value indicating whether mapping the IsBlocked of BlockedIPAddressEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:47
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual bool? IsBlocked
		{
            get
            {
                return this.isBlocked;
            }

            set
            {
                this.isBlocked = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the DateBlocked of BlockedIPAddressEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:47
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual DateTime? DateBlocked
		{
            get
            {
                return this.dateBlocked;
            }

            set
            {
                this.dateBlocked = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the LoginID of BlockedIPAddressEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:47
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
        /// Creation Date:2013/10/13 14:18:47
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public override bool Equals(object obj)
        {
            if (obj == null || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }

            var castObj = (BlockedIPAddressEntity)obj;
            return this.IPId == castObj.IPId;
        }

		/// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:47
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public override int GetHashCode()
		{
			var hash = 57; 
			hash = 27 * hash * this.IPId.GetHashCode();
			return hash;
		}
	}
}