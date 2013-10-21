// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ChefEntity.cs" company="Irdeto">
//   Copyright @ 2013
// </copyright>
// <summary>
//   Class:ChefEntity
//   Namespace:Ets.SingleApi.Model.Repository
//   Class Funtion:Represent the class mapping the ChefEntity table in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ets.SingleApi.Model.Repository
{
	using System;
		
    /// <summary>
    /// Class:ChefEntity
    /// Namespace:Ets.SingleApi.Model.Repository
    /// Class Funtion:Represent the class mapping the ChefEntity table in the database.
    /// </summary>
    /// Creator:周超
    /// Creation Date:2013/10/13 14:01:28
    /// Modifier:
    /// Last Modified:
    /// ----------------------------------------------------------------------------------------
    [Serializable]
    public class ChefEntity
    {
		#region private member

			/// <summary>
		/// The ChefID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int chefId;

			/// <summary>
		/// The Title
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string title;

			/// <summary>
		/// The Forename
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string forename;

			/// <summary>
		/// The Surname
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string surname;

			/// <summary>
		/// The Phone
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string phone;

			/// <summary>
		/// The Email
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string email;

			/// <summary>
		/// The Description
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string description;

			/// <summary>
		/// The ChefOfTheWeek
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private bool? chefOfTheWeek;

			/// <summary>
		/// The AwardID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private AwardEntity award;

			/// <summary>
		/// The SupplierID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private SupplierEntity supplier;

		#endregion

		/// <summary>
        /// Initializes a new instance of the <see cref="ChefEntity"/> class.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public ChefEntity()
        {
			this.chefId = 0;
			this.title = string.Empty;
			this.forename = string.Empty;
			this.surname = string.Empty;
			this.phone = string.Empty;
			this.email = string.Empty;
			this.description = string.Empty;
		}

		#region public member

			/// <summary>
        /// Gets or sets a value mapping the ChefID of ChefEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int ChefId
		{
            get
            {
                return this.chefId;
            }

            set
            {
                this.chefId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Title of ChefEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string Title
		{
            get
            {
                return this.title;
            }

            set
            {
                this.title = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Forename of ChefEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string Forename
		{
            get
            {
                return this.forename;
            }

            set
            {
                this.forename = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Surname of ChefEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string Surname
		{
            get
            {
                return this.surname;
            }

            set
            {
                this.surname = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Phone of ChefEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
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
        /// Gets or sets a value mapping the Email of ChefEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
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
        /// Gets or sets a value mapping the Description of ChefEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string Description
		{
            get
            {
                return this.description;
            }

            set
            {
                this.description = value;
            }
        }

			/// <summary>
        /// Gets or sets a value indicating whether mapping the ChefOfTheWeek of ChefEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual bool? ChefOfTheWeek
		{
            get
            {
                return this.chefOfTheWeek;
            }

            set
            {
                this.chefOfTheWeek = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the AwardID of ChefEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual AwardEntity Award
		{
            get
            {
                return this.award;
            }

            set
            {
                this.award = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the SupplierID of ChefEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual SupplierEntity Supplier
		{
            get
            {
                return this.supplier;
            }

            set
            {
                this.supplier = value;
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
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public override bool Equals(object obj)
        {
            if (obj == null || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }

            var castObj = (ChefEntity)obj;
            return this.ChefId == castObj.ChefId;
        }

		/// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:28
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public override int GetHashCode()
		{
			var hash = 57; 
			hash = 27 * hash * this.ChefId.GetHashCode();
			return hash;
		}
	}
}