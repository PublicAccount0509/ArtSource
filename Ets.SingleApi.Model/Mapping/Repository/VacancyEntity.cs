// --------------------------------------------------------------------------------------------------------------------
// <copyright file="VacancyEntity.cs" company="Irdeto">
//   Copyright @ 2013
// </copyright>
// <summary>
//   Class:VacancyEntity
//   Namespace:Ets.SingleApi.Model.Repository
//   Class Funtion:Represent the class mapping the VacancyEntity table in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ets.SingleApi.Model.Repository
{
	using System;
		
    /// <summary>
    /// Class:VacancyEntity
    /// Namespace:Ets.SingleApi.Model.Repository
    /// Class Funtion:Represent the class mapping the VacancyEntity table in the database.
    /// </summary>
    /// Creator:周超
    /// Creation Date:2013/10/13 14:01:31
    /// Modifier:
    /// Last Modified:
    /// ----------------------------------------------------------------------------------------
    [Serializable]
    public class VacancyEntity
    {
		#region private member

			/// <summary>
		/// The VacancyID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int vacancyId;

			/// <summary>
		/// The JobTitleID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int jobTitleId;

			/// <summary>
		/// The Quantity
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int quantity;

			/// <summary>
		/// The JobTypeID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int jobTypeId;

			/// <summary>
		/// The JobSpec
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string jobSpec;

			/// <summary>
		/// The StartDate
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string startDate;

			/// <summary>
		/// The SalaryRate
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string salaryRate;

			/// <summary>
		/// The Contact
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string contact;

			/// <summary>
		/// The Telephone
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string telephone;

			/// <summary>
		/// The Fax
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string fax;

			/// <summary>
		/// The Email
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string email;

			/// <summary>
		/// The Reference
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string reference;

			/// <summary>
		/// The DateAdded
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private DateTime? dateAdded;

			/// <summary>
		/// The Online
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private bool? online;

			/// <summary>
		/// The SupplierID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private SupplierEntity supplier;

		#endregion

		/// <summary>
        /// Initializes a new instance of the <see cref="VacancyEntity"/> class.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public VacancyEntity()
        {
			this.vacancyId = 0;
			this.jobTitleId = 0;
			this.quantity = 0;
			this.jobTypeId = 0;
			this.jobSpec = string.Empty;
			this.startDate = string.Empty;
			this.salaryRate = string.Empty;
			this.contact = string.Empty;
			this.telephone = string.Empty;
			this.fax = string.Empty;
			this.email = string.Empty;
			this.reference = string.Empty;
		}

		#region public member

			/// <summary>
        /// Gets or sets a value mapping the VacancyID of VacancyEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int VacancyId
		{
            get
            {
                return this.vacancyId;
            }

            set
            {
                this.vacancyId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the JobTitleID of VacancyEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int JobTitleId
		{
            get
            {
                return this.jobTitleId;
            }

            set
            {
                this.jobTitleId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Quantity of VacancyEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int Quantity
		{
            get
            {
                return this.quantity;
            }

            set
            {
                this.quantity = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the JobTypeID of VacancyEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int JobTypeId
		{
            get
            {
                return this.jobTypeId;
            }

            set
            {
                this.jobTypeId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the JobSpec of VacancyEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string JobSpec
		{
            get
            {
                return this.jobSpec;
            }

            set
            {
                this.jobSpec = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the StartDate of VacancyEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string StartDate
		{
            get
            {
                return this.startDate;
            }

            set
            {
                this.startDate = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the SalaryRate of VacancyEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string SalaryRate
		{
            get
            {
                return this.salaryRate;
            }

            set
            {
                this.salaryRate = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Contact of VacancyEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string Contact
		{
            get
            {
                return this.contact;
            }

            set
            {
                this.contact = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Telephone of VacancyEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
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
        /// Gets or sets a value mapping the Fax of VacancyEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
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
        /// Gets or sets a value mapping the Email of VacancyEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
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
        /// Gets or sets a value mapping the Reference of VacancyEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string Reference
		{
            get
            {
                return this.reference;
            }

            set
            {
                this.reference = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the DateAdded of VacancyEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual DateTime? DateAdded
		{
            get
            {
                return this.dateAdded;
            }

            set
            {
                this.dateAdded = value;
            }
        }

			/// <summary>
        /// Gets or sets a value indicating whether mapping the Online of VacancyEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual bool? Online
		{
            get
            {
                return this.online;
            }

            set
            {
                this.online = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the SupplierID of VacancyEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
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
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public override bool Equals(object obj)
        {
            if (obj == null || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }

            var castObj = (VacancyEntity)obj;
            return this.VacancyId == castObj.VacancyId;
        }

		/// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:31
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public override int GetHashCode()
		{
			var hash = 57; 
			hash = 27 * hash * this.VacancyId.GetHashCode();
			return hash;
		}
	}
}