// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ActivateCardEntity.cs" company="Irdeto">
//   Copyright @ 2013
// </copyright>
// <summary>
//   Class:ActivateCardEntity
//   Namespace:Ets.SingleApi.Model.Repository
//   Class Funtion:Represent the class mapping the ActivateCardEntity table in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ets.SingleApi.Model.Repository
{
	using System;
		
    /// <summary>
    /// Class:ActivateCardEntity
    /// Namespace:Ets.SingleApi.Model.Repository
    /// Class Funtion:Represent the class mapping the ActivateCardEntity table in the database.
    /// </summary>
    /// Creator:周超
    /// Creation Date:2013/10/13 14:27:04
    /// Modifier:
    /// Last Modified:
    /// ----------------------------------------------------------------------------------------
    [Serializable]
    public class ActivateCardEntity
    {
		#region private member

			/// <summary>
		/// The ID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:04
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int id;

			/// <summary>
		/// The CardNumber
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:04
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string cardNumber;

			/// <summary>
		/// The Name
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:04
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string name;

			/// <summary>
		/// The Sex
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:04
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int sex;

			/// <summary>
		/// The Phone
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:04
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string phone;

			/// <summary>
		/// The Email
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:04
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string email;

			/// <summary>
		/// The ActivateTiem
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:04
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private DateTime activateTiem;

			/// <summary>
		/// The PhoneMAC
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:04
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string phoneMAC;

		#endregion

		/// <summary>
        /// Initializes a new instance of the <see cref="ActivateCardEntity"/> class.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:04
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public ActivateCardEntity()
        {
			this.id = 0;
			this.cardNumber = string.Empty;
			this.name = string.Empty;
			this.sex = 0;
			this.phone = string.Empty;
			this.email = string.Empty;
			this.activateTiem = DateTime.Now;
			this.phoneMAC = string.Empty;
		}

		#region public member

			/// <summary>
        /// Gets or sets a value mapping the ID of ActivateCardEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
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
        /// Gets or sets a value mapping the CardNumber of ActivateCardEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string CardNumber
		{
            get
            {
                return this.cardNumber;
            }

            set
            {
                this.cardNumber = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Name of ActivateCardEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
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
        /// Gets or sets a value mapping the Sex of ActivateCardEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int Sex
		{
            get
            {
                return this.sex;
            }

            set
            {
                this.sex = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Phone of ActivateCardEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string Phone
		{
            get
            {
                return this.phone;
            }

            set
            {
                this.phone = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Email of ActivateCardEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string Email
		{
            get
            {
                return this.email;
            }

            set
            {
                this.email = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the ActivateTiem of ActivateCardEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual DateTime ActivateTiem
		{
            get
            {
                return this.activateTiem;
            }

            set
            {
                this.activateTiem = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the PhoneMAC of ActivateCardEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string PhoneMAC
		{
            get
            {
                return this.phoneMAC;
            }

            set
            {
                this.phoneMAC = value;
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
        /// Creation Date:2013/10/13 14:27:05
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public override bool Equals(object obj)
        {
            if (obj == null || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }

            var castObj = (ActivateCardEntity)obj;
            return this.Id == castObj.Id;
        }

		/// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:27:05
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