// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DeliveryAddressEntity.cs" company="Irdeto">
//   Copyright @ 2013
// </copyright>
// <summary>
//   Class:DeliveryAddressEntity
//   Namespace:Ets.SingleApi.Model.Repository
//   Class Funtion:Represent the class mapping the DeliveryAddressEntity table in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ets.SingleApi.Model.Repository
{
	using System;
		
    /// <summary>
    /// Class:DeliveryAddressEntity
    /// Namespace:Ets.SingleApi.Model.Repository
    /// Class Funtion:Represent the class mapping the DeliveryAddressEntity table in the database.
    /// </summary>
    /// Creator:周超
    /// Creation Date:2013/11/11 18:22:26
    /// Modifier:
    /// Last Modified:
    /// ----------------------------------------------------------------------------------------
    [Serializable]
    public class DeliveryAddressEntity
    {
		#region private member

			/// <summary>
		/// The DeliveryAddressID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/11/11 18:22:26
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int deliveryAddressId;

			/// <summary>
		/// The CustomerID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/11/11 18:22:26
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int customerId;

			/// <summary>
		/// The Address1
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/11/11 18:22:26
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string address1;

			/// <summary>
		/// The Address2
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/11/11 18:22:26
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string address2;

			/// <summary>
		/// The CityID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/11/11 18:22:26
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? cityId;

			/// <summary>
		/// The CountyID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/11/11 18:22:26
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? countyId;

			/// <summary>
		/// The CountryID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/11/11 18:22:26
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? countryId;

			/// <summary>
		/// The PostCode
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/11/11 18:22:26
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string postCode;

			/// <summary>
		/// The Telephone
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/11/11 18:22:26
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string telephone;

			/// <summary>
		/// The IsDefault
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/11/11 18:22:26
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private bool? isDefault;

			/// <summary>
		/// The Town
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/11/11 18:22:26
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string town;

			/// <summary>
		/// The AddressAlias
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/11/11 18:22:26
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string addressAlias;

			/// <summary>
		/// The Recipient
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/11/11 18:22:26
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string recipient;

			/// <summary>
		/// The Plane
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/11/11 18:22:26
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string plane;

			/// <summary>
		/// The Sex
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/11/11 18:22:26
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        private int? sex;

			/// <summary>
		/// The IsDel
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/11/11 18:22:26
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private bool? isDel;

			/// <summary>
		/// The AddressBuilding
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/11/11 18:22:26
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string addressBuilding;

			/// <summary>
		/// The AddressDetail
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/11/11 18:22:26
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string addressDetail;

		#endregion

		/// <summary>
        /// Initializes a new instance of the <see cref="DeliveryAddressEntity"/> class.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/11/11 18:22:26
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public DeliveryAddressEntity()
        {
			this.deliveryAddressId = 0;
			this.customerId = 0;
			this.address1 = string.Empty;
			this.address2 = string.Empty;
			this.postCode = string.Empty;
			this.telephone = string.Empty;
			this.town = string.Empty;
			this.addressAlias = string.Empty;
			this.recipient = string.Empty;
			this.plane = string.Empty;
			this.addressBuilding = string.Empty;
			this.addressDetail = string.Empty;
		}

		#region public member

			/// <summary>
        /// Gets or sets a value mapping the DeliveryAddressID of DeliveryAddressEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/11/11 18:22:26
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int DeliveryAddressId
		{
            get
            {
                return this.deliveryAddressId;
            }

            set
            {
                this.deliveryAddressId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the CustomerID of DeliveryAddressEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/11/11 18:22:26
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
        /// Gets or sets a value mapping the Address1 of DeliveryAddressEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/11/11 18:22:26
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
        /// Gets or sets a value mapping the Address2 of DeliveryAddressEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/11/11 18:22:26
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
        /// Gets or sets a value mapping the CityID of DeliveryAddressEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/11/11 18:22:26
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
        /// Gets or sets a value mapping the CountyID of DeliveryAddressEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/11/11 18:22:26
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
        /// Gets or sets a value mapping the CountryID of DeliveryAddressEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/11/11 18:22:26
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
        /// Gets or sets a value mapping the PostCode of DeliveryAddressEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/11/11 18:22:26
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
        /// Gets or sets a value mapping the Telephone of DeliveryAddressEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/11/11 18:22:26
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
        /// Gets or sets a value indicating whether mapping the IsDefault of DeliveryAddressEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/11/11 18:22:26
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual bool? IsDefault
		{
            get
            {
                return this.isDefault;
            }

            set
            {
                this.isDefault = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Town of DeliveryAddressEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/11/11 18:22:26
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string Town
		{
            get
            {
                return this.town;
            }

            set
            {
                this.town = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the AddressAlias of DeliveryAddressEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/11/11 18:22:26
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string AddressAlias
		{
            get
            {
                return this.addressAlias;
            }

            set
            {
                this.addressAlias = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Recipient of DeliveryAddressEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/11/11 18:22:26
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string Recipient
		{
            get
            {
                return this.recipient;
            }

            set
            {
                this.recipient = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Plane of DeliveryAddressEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/11/11 18:22:26
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string Plane
		{
            get
            {
                return this.plane;
            }

            set
            {
                this.plane = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Sex of DeliveryAddressEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/11/11 18:22:26
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public virtual int? Sex
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
        /// Gets or sets a value indicating whether mapping the IsDel of DeliveryAddressEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/11/11 18:22:26
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual bool? IsDel
		{
            get
            {
                return this.isDel;
            }

            set
            {
                this.isDel = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the AddressBuilding of DeliveryAddressEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/11/11 18:22:26
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string AddressBuilding
		{
            get
            {
                return this.addressBuilding;
            }

            set
            {
                this.addressBuilding = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the AddressDetail of DeliveryAddressEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/11/11 18:22:26
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string AddressDetail
		{
            get
            {
                return this.addressDetail;
            }

            set
            {
                this.addressDetail = value;
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
        /// Creation Date:2013/11/11 18:22:26
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public override bool Equals(object obj)
        {
            if (obj == null || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }

            var castObj = (DeliveryAddressEntity)obj;
            return this.DeliveryAddressId == castObj.DeliveryAddressId;
        }

		/// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        /// Creator:周超
        /// Creation Date:2013/11/11 18:22:26
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public override int GetHashCode()
		{
			var hash = 57; 
			hash = 27 * hash * this.DeliveryAddressId.GetHashCode();
			return hash;
		}
	}
}