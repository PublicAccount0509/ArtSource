// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CustomerEntity.cs" company="Irdeto">
//   Copyright @ 2013
// </copyright>
// <summary>
//   Class:CustomerEntity
//   Namespace:Ets.SingleApi.Model.Repository
//   Class Funtion:Represent the class mapping the CustomerEntity table in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ets.SingleApi.Model.Repository
{
	using System;
	using System.Collections.Generic;
		
    /// <summary>
    /// Class:CustomerEntity
    /// Namespace:Ets.SingleApi.Model.Repository
    /// Class Funtion:Represent the class mapping the CustomerEntity table in the database.
    /// </summary>
    /// Creator:周超
    /// Creation Date:2013/10/13 14:18:48
    /// Modifier:
    /// Last Modified:
    /// ----------------------------------------------------------------------------------------
    [Serializable]
    public class CustomerEntity
    {
		#region private member

			/// <summary>
		/// The CustomerID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int customerId;

			/// <summary>
		/// The CorporateID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? corporateId;

			/// <summary>
		/// The LoginID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? loginId;

			/// <summary>
		/// The PrePayCardNo
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string prePayCardNo;

			/// <summary>
		/// The PrePayBalance
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private decimal? prePayBalance;

			/// <summary>
		/// The Title
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string title;

			/// <summary>
		/// The Forename
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string forename;

			/// <summary>
		/// The Surname
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string surname;

			/// <summary>
		/// The Gender
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string gender;

			/// <summary>
		/// The NationalityID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? nationalityId;

			/// <summary>
		/// The Age
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? age;

			/// <summary>
		/// The Address1
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string address1;

			/// <summary>
		/// The Address2
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string address2;

			/// <summary>
		/// The CityID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? cityId;

			/// <summary>
		/// The CountyID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? countyId;

			/// <summary>
		/// The CountryID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? countryId;

			/// <summary>
		/// The OtherCity
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string otherCity;

			/// <summary>
		/// The PostCode
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string postCode;

			/// <summary>
		/// The HomeTelephone
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string homeTelephone;

			/// <summary>
		/// The WorkTelephone
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string workTelephone;

			/// <summary>
		/// The Mobile
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string mobile;

			/// <summary>
		/// The Fax
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string fax;

			/// <summary>
		/// The Email
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string email;

			/// <summary>
		/// The DateJoined
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private DateTime? dateJoined;

			/// <summary>
		/// The HomeCity
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string homeCity;

			/// <summary>
		/// The Birthday
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private DateTime? birthday;

			/// <summary>
		/// The AddrCityId
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string addrCityId;

			/// <summary>
		/// The AddrProvinceId
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string addrProvinceId;

			/// <summary>
		/// The IsValid
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private bool? isValId;

			/// <summary>
		/// The Templateid
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string templateId;

			/// <summary>
		/// The CreateDate
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private DateTime? createDate;

			/// <summary>
		/// The IsRegAllowed
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private bool? isRegAllowed;

			/// <summary>
		/// The Avatar
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string avatar;

			/// <summary>
		/// The CardList
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private IList<CardEntity> cardList;

			/// <summary>
		/// The CustomerFavoriteList
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private IList<CustomerFavoriteEntity> customerFavoriteList;

			/// <summary>
		/// The CustomerPointList
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private IList<CustomerPointEntity> customerPointList;

			/// <summary>
		/// The MarketingAllowanceList
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private IList<MarketingAllowanceEntity> marketingAllowanceList;

			/// <summary>
		/// The SupplierCommentList
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private IList<SupplierCommentEntity> supplierCommentList;

			/// <summary>
		/// The Path
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private SourcePathEntity path;

			/// <summary>
		/// The Source
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private SourceTypeEntity source;

		#endregion

		/// <summary>
        /// Initializes a new instance of the <see cref="CustomerEntity"/> class.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public CustomerEntity()
        {
			this.customerId = 0;
			this.prePayCardNo = string.Empty;
			this.title = string.Empty;
			this.forename = string.Empty;
			this.surname = string.Empty;
			this.gender = string.Empty;
			this.address1 = string.Empty;
			this.address2 = string.Empty;
			this.otherCity = string.Empty;
			this.postCode = string.Empty;
			this.homeTelephone = string.Empty;
			this.workTelephone = string.Empty;
			this.fax = string.Empty;
			this.homeCity = string.Empty;
			this.addrCityId = string.Empty;
			this.addrProvinceId = string.Empty;
			this.templateId = string.Empty;
			this.avatar = string.Empty;
		}

		#region public member

			/// <summary>
        /// Gets or sets a value mapping the CustomerID of CustomerEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int CustomerId
		{
            get
            {
                return this.customerId;
            }

            set
            {
                this.customerId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the CorporateID of CustomerEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? CorporateId
		{
            get
            {
                return this.corporateId;
            }

            set
            {
                this.corporateId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the LoginID of CustomerEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? LoginId
		{
            get
            {
                return this.loginId;
            }

            set
            {
                this.loginId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the PrePayCardNo of CustomerEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string PrePayCardNo
		{
            get
            {
                return this.prePayCardNo;
            }

            set
            {
                this.prePayCardNo = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the PrePayBalance of CustomerEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual decimal? PrePayBalance
		{
            get
            {
                return this.prePayBalance;
            }

            set
            {
                this.prePayBalance = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Title of CustomerEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
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
        /// Gets or sets a value mapping the Forename of CustomerEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
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
        /// Gets or sets a value mapping the Surname of CustomerEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
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
        /// Gets or sets a value mapping the Gender of CustomerEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string Gender
		{
            get
            {
                return this.gender;
            }

            set
            {
                this.gender = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the NationalityID of CustomerEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? NationalityId
		{
            get
            {
                return this.nationalityId;
            }

            set
            {
                this.nationalityId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Age of CustomerEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? Age
		{
            get
            {
                return this.age;
            }

            set
            {
                this.age = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Address1 of CustomerEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string Address1
		{
            get
            {
                return this.address1;
            }

            set
            {
                this.address1 = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Address2 of CustomerEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string Address2
		{
            get
            {
                return this.address2;
            }

            set
            {
                this.address2 = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the CityID of CustomerEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? CityId
		{
            get
            {
                return this.cityId;
            }

            set
            {
                this.cityId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the CountyID of CustomerEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? CountyId
		{
            get
            {
                return this.countyId;
            }

            set
            {
                this.countyId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the CountryID of CustomerEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? CountryId
		{
            get
            {
                return this.countryId;
            }

            set
            {
                this.countryId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the OtherCity of CustomerEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string OtherCity
		{
            get
            {
                return this.otherCity;
            }

            set
            {
                this.otherCity = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the PostCode of CustomerEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string PostCode
		{
            get
            {
                return this.postCode;
            }

            set
            {
                this.postCode = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the HomeTelephone of CustomerEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string HomeTelephone
		{
            get
            {
                return this.homeTelephone;
            }

            set
            {
                this.homeTelephone = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the WorkTelephone of CustomerEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string WorkTelephone
		{
            get
            {
                return this.workTelephone;
            }

            set
            {
                this.workTelephone = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Mobile of CustomerEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string Mobile
		{
            get
            {
                return this.mobile;
            }

            set
            {
                this.mobile = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Fax of CustomerEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
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
        /// Gets or sets a value mapping the Email of CustomerEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
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
        /// Gets or sets a value mapping the DateJoined of CustomerEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual DateTime? DateJoined
		{
            get
            {
                return this.dateJoined;
            }

            set
            {
                this.dateJoined = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the HomeCity of CustomerEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string HomeCity
		{
            get
            {
                return this.homeCity;
            }

            set
            {
                this.homeCity = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Birthday of CustomerEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual DateTime? Birthday
		{
            get
            {
                return this.birthday;
            }

            set
            {
                this.birthday = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the AddrCityId of CustomerEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string AddrCityId
		{
            get
            {
                return this.addrCityId;
            }

            set
            {
                this.addrCityId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the AddrProvinceId of CustomerEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string AddrProvinceId
		{
            get
            {
                return this.addrProvinceId;
            }

            set
            {
                this.addrProvinceId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value indicating whether mapping the IsValid of CustomerEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual bool? IsValId
		{
            get
            {
                return this.isValId;
            }

            set
            {
                this.isValId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Templateid of CustomerEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string TemplateId
		{
            get
            {
                return this.templateId;
            }

            set
            {
                this.templateId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the CreateDate of CustomerEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual DateTime? CreateDate
		{
            get
            {
                return this.createDate;
            }

            set
            {
                this.createDate = value;
            }
        }

			/// <summary>
        /// Gets or sets a value indicating whether mapping the IsRegAllowed of CustomerEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual bool? IsRegAllowed
		{
            get
            {
                return this.isRegAllowed;
            }

            set
            {
                this.isRegAllowed = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Avatar of CustomerEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string Avatar
		{
            get
            {
                return this.avatar;
            }

            set
            {
                this.avatar = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the CardList of CustomerEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual IList<CardEntity> CardList
		{
            get
            {
                return this.cardList;
            }

            set
            {
                this.cardList = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the CustomerFavoriteList of CustomerEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual IList<CustomerFavoriteEntity> CustomerFavoriteList
		{
            get
            {
                return this.customerFavoriteList;
            }

            set
            {
                this.customerFavoriteList = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the CustomerPointList of CustomerEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual IList<CustomerPointEntity> CustomerPointList
		{
            get
            {
                return this.customerPointList;
            }

            set
            {
                this.customerPointList = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the MarketingAllowanceList of CustomerEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual IList<MarketingAllowanceEntity> MarketingAllowanceList
		{
            get
            {
                return this.marketingAllowanceList;
            }

            set
            {
                this.marketingAllowanceList = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the SupplierCommentList of CustomerEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual IList<SupplierCommentEntity> SupplierCommentList
		{
            get
            {
                return this.supplierCommentList;
            }

            set
            {
                this.supplierCommentList = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Path of CustomerEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual SourcePathEntity Path
		{
            get
            {
                return this.path;
            }

            set
            {
                this.path = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Source of CustomerEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:18:48
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual SourceTypeEntity Source
		{
            get
            {
                return this.source;
            }

            set
            {
                this.source = value;
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

            var castObj = (CustomerEntity)obj;
            return this.CustomerId == castObj.CustomerId;
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
			hash = 27 * hash * this.CustomerId.GetHashCode();
			return hash;
		}
	}
}