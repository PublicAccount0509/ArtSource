// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContactEntity.cs" company="Irdeto">
//   Copyright @ 2013
// </copyright>
// <summary>
//   Class:ContactEntity
//   Namespace:Ets.SingleApi.Model.Repository
//   Class Funtion:Represent the class mapping the ContactEntity table in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ets.SingleApi.Model.Repository
{
	using System;
	using System.Collections.Generic;
		
    /// <summary>
    /// Class:ContactEntity
    /// Namespace:Ets.SingleApi.Model.Repository
    /// Class Funtion:Represent the class mapping the ContactEntity table in the database.
    /// </summary>
    /// Creator:周超
    /// Creation Date:2013/10/13 14:18:47
    /// Modifier:
    /// Last Modified:
    /// ----------------------------------------------------------------------------------------
    [Serializable]
    public class ContactEntity
    {
		#region private member

			/// <summary>
		/// The ContactID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:47
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int contactId;

			/// <summary>
		/// The Title
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:47
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string title;

			/// <summary>
		/// The Forename
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:47
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string forename;

			/// <summary>
		/// The Surname
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:47
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string surname;

			/// <summary>
		/// The Telephone
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:47
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string telephone;

			/// <summary>
		/// The Fax
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:47
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string fax;

			/// <summary>
		/// The Email
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:47
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string email;

			/// <summary>
		/// The Mapimages
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:47
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string mapimages;

			/// <summary>
		/// The Sex
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:47
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private byte? sex;

			/// <summary>
		/// The SupplierContactList
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:47
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private IList<SupplierContactEntity> supplierContactList;

		#endregion

		/// <summary>
        /// Initializes a new instance of the <see cref="ContactEntity"/> class.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:47
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public ContactEntity()
        {
			this.contactId = 0;
			this.title = string.Empty;
			this.forename = string.Empty;
			this.surname = string.Empty;
			this.telephone = string.Empty;
			this.fax = string.Empty;
			this.email = string.Empty;
			this.mapimages = string.Empty;
		}

		#region public member

			/// <summary>
        /// Gets or sets a value mapping the ContactID of ContactEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:47
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int ContactId
		{
            get
            {
                return this.contactId;
            }

            set
            {
                this.contactId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Title of ContactEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:47
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
        /// Gets or sets a value mapping the Forename of ContactEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:47
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
        /// Gets or sets a value mapping the Surname of ContactEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:47
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
        /// Gets or sets a value mapping the Telephone of ContactEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:47
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string Telephone
		{
            get
            {
                return this.telephone;
            }

            set
            {
                this.telephone = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Fax of ContactEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:47
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string Fax
		{
            get
            {
                return this.fax;
            }

            set
            {
                this.fax = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Email of ContactEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:47
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
        /// Gets or sets a value mapping the Mapimages of ContactEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:47
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string Mapimages
		{
            get
            {
                return this.mapimages;
            }

            set
            {
                this.mapimages = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Sex of ContactEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:47
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual byte? Sex
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
        /// Gets or sets a value mapping the SupplierContactList of ContactEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:47
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual IList<SupplierContactEntity> SupplierContactList
		{
            get
            {
                return this.supplierContactList;
            }

            set
            {
                this.supplierContactList = value;
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

            var castObj = (ContactEntity)obj;
            return this.ContactId == castObj.ContactId;
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
			hash = 27 * hash * this.ContactId.GetHashCode();
			return hash;
		}
	}
}