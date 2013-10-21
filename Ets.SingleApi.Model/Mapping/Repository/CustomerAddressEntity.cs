// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CustomerAddressEntity.cs" company="Irdeto">
//   Copyright @ 2013
// </copyright>
// <summary>
//   Class:CustomerAddressEntity
//   Namespace:Ets.SingleApi.Model.Repository
//   Class Funtion:Represent the class mapping the CustomerAddressEntity table in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ets.SingleApi.Model.Repository
{
    using System;

    /// <summary>
    /// Class:CustomerAddressEntity
    /// Namespace:Ets.SingleApi.Model.Repository
    /// Class Funtion:Represent the class mapping the CustomerAddressEntity table in the database.
    /// </summary>
    /// Creator:周超
    /// Creation Date:2013/10/19 18:50:42
    /// Modifier:
    /// Last Modified:
    /// ----------------------------------------------------------------------------------------
    [Serializable]
    public class CustomerAddressEntity
    {
        #region private member

        /// <summary>
        /// The CustomerAddressID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/19 18:50:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        private int customerAddressId;

        /// <summary>
        /// The CustomerID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/19 18:50:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        private int? customerId;

        /// <summary>
        /// The Address1
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/19 18:50:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        private string address1;

        /// <summary>
        /// The Address2
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/19 18:50:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        private string address2;

        /// <summary>
        /// The CityID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/19 18:50:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        private int? cityId;

        /// <summary>
        /// The CountyID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/19 18:50:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        private int? countyId;

        /// <summary>
        /// The CountryID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/19 18:50:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        private int? countryId;

        /// <summary>
        /// The PostCode
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/19 18:50:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        private string postCode;

        /// <summary>
        /// The Telephone
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/19 18:50:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        private string telephone;

        /// <summary>
        /// The IsDefault
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/19 18:50:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        private bool? isDefault;

        /// <summary>
        /// The Town
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/19 18:50:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        private string town;

        /// <summary>
        /// The AddressAlias
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/19 18:50:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        private string addressAlias;

        /// <summary>
        /// The Recipient
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/19 18:50:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        private string recipient;

        /// <summary>
        /// The Plane
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/19 18:50:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        private string plane;

        /// <summary>
        /// The Sex
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/19 18:50:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        private int? sex;

        /// <summary>
        /// The IsDel
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/19 18:50:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        private bool? isDel;

        /// <summary>
        /// The Type
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/19 18:50:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        private int? type;

        /// <summary>
        /// The SupplierId
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/19 18:50:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        private int? supplierId;

        /// <summary>
        /// The RegionCode
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/19 18:50:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        private string regionCode;

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerAddressEntity"/> class.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/19 18:50:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public CustomerAddressEntity()
        {
            this.customerAddressId = 0;
            this.address1 = string.Empty;
            this.address2 = string.Empty;
            this.postCode = string.Empty;
            this.telephone = string.Empty;
            this.town = string.Empty;
            this.addressAlias = string.Empty;
            this.recipient = string.Empty;
            this.plane = string.Empty;
            this.regionCode = string.Empty;
        }

        #region public member

        /// <summary>
        /// Gets or sets a value mapping the CustomerAddressID of CustomerAddressEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/19 18:50:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public virtual int CustomerAddressId
        {
            get
            {
                return this.customerAddressId;
            }

            set
            {
                this.customerAddressId = value;
            }
        }

        /// <summary>
        /// Gets or sets a value mapping the CustomerID of CustomerAddressEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/19 18:50:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public virtual int? CustomerId
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
        /// Gets or sets a value mapping the Address1 of CustomerAddressEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/19 18:50:43
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
        /// Gets or sets a value mapping the Address2 of CustomerAddressEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/19 18:50:43
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
        /// Gets or sets a value mapping the CityID of CustomerAddressEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/19 18:50:43
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
        /// Gets or sets a value mapping the CountyID of CustomerAddressEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/19 18:50:43
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
        /// Gets or sets a value mapping the CountryID of CustomerAddressEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/19 18:50:43
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
        /// Gets or sets a value mapping the PostCode of CustomerAddressEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/19 18:50:43
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
        /// Gets or sets a value mapping the Telephone of CustomerAddressEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/19 18:50:43
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
        /// Gets or sets a value indicating whether mapping the IsDefault of CustomerAddressEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/19 18:50:43
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
        /// Gets or sets a value mapping the Town of CustomerAddressEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/19 18:50:43
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
        /// Gets or sets a value mapping the AddressAlias of CustomerAddressEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/19 18:50:43
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
        /// Gets or sets a value mapping the Recipient of CustomerAddressEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/19 18:50:43
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
        /// Gets or sets a value mapping the Plane of CustomerAddressEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/19 18:50:43
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
        /// Gets or sets a value mapping the Sex of CustomerAddressEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/19 18:50:43
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
        /// Gets or sets a value indicating whether mapping the IsDel of CustomerAddressEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/19 18:50:43
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
        /// Gets or sets a value mapping the Type of CustomerAddressEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/19 18:50:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public virtual int? Type
        {
            get
            {
                return this.type;
            }

            set
            {
                this.type = value;
            }
        }

        /// <summary>
        /// Gets or sets a value mapping the SupplierId of CustomerAddressEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/19 18:50:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public virtual int? SupplierId
        {
            get
            {
                return this.supplierId;
            }

            set
            {
                this.supplierId = value;
            }
        }

        /// <summary>
        /// Gets or sets a value mapping the RegionCode of CustomerAddressEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/19 18:50:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public virtual string RegionCode
        {
            get
            {
                return this.regionCode;
            }

            set
            {
                this.regionCode = value;
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
        /// Creation Date:2013/10/19 18:50:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public override bool Equals(object obj)
        {
            if (obj == null || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }

            var castObj = (CustomerAddressEntity)obj;
            return this.CustomerAddressId == castObj.CustomerAddressId;
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        /// Creator:周超
        /// Creation Date:2013/10/19 18:50:43
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public override int GetHashCode()
        {
            var hash = 57;
            hash = 27 * hash * this.CustomerAddressId.GetHashCode();
            return hash;
        }
    }
}