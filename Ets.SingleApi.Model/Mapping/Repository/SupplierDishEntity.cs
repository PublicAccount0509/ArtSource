// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SupplierDishEntity.cs" company="Irdeto">
//   Copyright @ 2013
// </copyright>
// <summary>
//   Class:SupplierDishEntity
//   Namespace:Ets.SingleApi.Model.Repository
//   Class Funtion:Represent the class mapping the SupplierDishEntity table in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ets.SingleApi.Model.Repository
{
	using System;
	using System.Collections.Generic;
		
    /// <summary>
    /// Class:SupplierDishEntity
    /// Namespace:Ets.SingleApi.Model.Repository
    /// Class Funtion:Represent the class mapping the SupplierDishEntity table in the database.
    /// </summary>
    /// Creator:周超
    /// Creation Date:2013/10/13 14:01:30
    /// Modifier:
    /// Last Modified:
    /// ----------------------------------------------------------------------------------------
    [Serializable]
    public class SupplierDishEntity
    {
		#region private member

			/// <summary>
		/// The SupplierDishID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int supplierDishId;

			/// <summary>
		/// The SupplierCategoryID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? supplierCategoryId;

			/// <summary>
		/// The DishID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int dishId;

			/// <summary>
		/// The DishNo
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string dishNo;

			/// <summary>
		/// The SupplierDishName
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string supplierDishName;

			/// <summary>
		/// The Price
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private decimal price;

			/// <summary>
		/// The DishDescription
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string dishDescription;

			/// <summary>
		/// The Recipe
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string recipe;

			/// <summary>
		/// The StockLevel
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int stockLevel;

			/// <summary>
		/// The IsSpecialOffer
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private bool? isSpecialOffer;

			/// <summary>
		/// The SpecialOfferNo
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int specialOfferNo;

			/// <summary>
		/// The SuppllierDishDescription
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string suppllierDishDescription;

			/// <summary>
		/// The Online
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private bool online;

			/// <summary>
		/// The fuzi
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? fuzi;

			/// <summary>
		/// The SpicyLevel
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? spicyLevel;

			/// <summary>
		/// The Vegetarian
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? vegetarian;

			/// <summary>
		/// The HasNuts
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? hasNuts;

			/// <summary>
		/// The SupplierDishOldId
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? supplierDishOldId;

			/// <summary>
		/// The AverageRating
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? averageRating;

			/// <summary>
		/// The Recommended
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private bool? recommended;

			/// <summary>
		/// The PackagingFee
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private decimal? packagingFee;

			/// <summary>
		/// The QuanPin
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string quanPin;

			/// <summary>
		/// The JianPin
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string jianPin;

			/// <summary>
		/// The IsCommission
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private bool? isCommission;

			/// <summary>
		/// The IsDiscount
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private bool? isDiscount;

			/// <summary>
		/// The IsDel
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private bool? isDel;

			/// <summary>
		/// The ModifyTime
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private DateTime? modifyTime;

			/// <summary>
		/// The BundleSupplierDishList
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private IList<BundleSupplierDishEntity> bundleSupplierDishList;

			/// <summary>
		/// The CrossSupplierDishList
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private IList<CrossSupplierDishEntity> crossSupplierDishList;

			/// <summary>
		/// The MenuLayoutDishList
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private IList<MenuLayoutDishEntity> menuLayoutDishList;

			/// <summary>
		/// The supplierDishMinNumberList
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private IList<SupplierDishMinNumberEntity> supplierDishMinNumberList;

			/// <summary>
		/// The DishImageID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private DishImageEntity dishImage;

			/// <summary>
		/// The SupplierID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private SupplierEntity supplier;

		#endregion

		/// <summary>
        /// Initializes a new instance of the <see cref="SupplierDishEntity"/> class.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public SupplierDishEntity()
        {
			this.supplierDishId = 0;
			this.dishId = 0;
			this.dishNo = string.Empty;
			this.supplierDishName = string.Empty;
			this.price = 0;
			this.dishDescription = string.Empty;
			this.recipe = string.Empty;
			this.stockLevel = 0;
			this.specialOfferNo = 0;
			this.suppllierDishDescription = string.Empty;
			this.online = true;
			this.quanPin = string.Empty;
			this.jianPin = string.Empty;
		}

		#region public member

			/// <summary>
        /// Gets or sets a value mapping the SupplierDishID of SupplierDishEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int SupplierDishId
		{
            get
            {
                return this.supplierDishId;
            }

            set
            {
                this.supplierDishId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the SupplierCategoryID of SupplierDishEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? SupplierCategoryId
		{
            get
            {
                return this.supplierCategoryId;
            }

            set
            {
                this.supplierCategoryId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the DishID of SupplierDishEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int DishId
		{
            get
            {
                return this.dishId;
            }

            set
            {
                this.dishId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the DishNo of SupplierDishEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string DishNo
		{
            get
            {
                return this.dishNo;
            }

            set
            {
                this.dishNo = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the SupplierDishName of SupplierDishEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string SupplierDishName
		{
            get
            {
                return this.supplierDishName;
            }

            set
            {
                this.supplierDishName = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Price of SupplierDishEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual decimal Price
		{
            get
            {
                return this.price;
            }

            set
            {
                this.price = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the DishDescription of SupplierDishEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string DishDescription
		{
            get
            {
                return this.dishDescription;
            }

            set
            {
                this.dishDescription = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Recipe of SupplierDishEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string Recipe
		{
            get
            {
                return this.recipe;
            }

            set
            {
                this.recipe = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the StockLevel of SupplierDishEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int StockLevel
		{
            get
            {
                return this.stockLevel;
            }

            set
            {
                this.stockLevel = value;
            }
        }

			/// <summary>
        /// Gets or sets a value indicating whether mapping the IsSpecialOffer of SupplierDishEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual bool? IsSpecialOffer
		{
            get
            {
                return this.isSpecialOffer;
            }

            set
            {
                this.isSpecialOffer = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the SpecialOfferNo of SupplierDishEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int SpecialOfferNo
		{
            get
            {
                return this.specialOfferNo;
            }

            set
            {
                this.specialOfferNo = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the SuppllierDishDescription of SupplierDishEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string SuppllierDishDescription
		{
            get
            {
                return this.suppllierDishDescription;
            }

            set
            {
                this.suppllierDishDescription = value;
            }
        }

			/// <summary>
        /// Gets or sets a value indicating whether mapping the Online of SupplierDishEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual bool Online
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
        /// Gets or sets a value mapping the fuzi of SupplierDishEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? Fuzi
		{
            get
            {
                return this.fuzi;
            }

            set
            {
                this.fuzi = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the SpicyLevel of SupplierDishEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? SpicyLevel
		{
            get
            {
                return this.spicyLevel;
            }

            set
            {
                this.spicyLevel = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Vegetarian of SupplierDishEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? Vegetarian
		{
            get
            {
                return this.vegetarian;
            }

            set
            {
                this.vegetarian = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the HasNuts of SupplierDishEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? HasNuts
		{
            get
            {
                return this.hasNuts;
            }

            set
            {
                this.hasNuts = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the SupplierDishOldId of SupplierDishEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? SupplierDishOldId
		{
            get
            {
                return this.supplierDishOldId;
            }

            set
            {
                this.supplierDishOldId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the AverageRating of SupplierDishEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? AverageRating
		{
            get
            {
                return this.averageRating;
            }

            set
            {
                this.averageRating = value;
            }
        }

			/// <summary>
        /// Gets or sets a value indicating whether mapping the Recommended of SupplierDishEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual bool? Recommended
		{
            get
            {
                return this.recommended;
            }

            set
            {
                this.recommended = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the PackagingFee of SupplierDishEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual decimal? PackagingFee
		{
            get
            {
                return this.packagingFee;
            }

            set
            {
                this.packagingFee = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the QuanPin of SupplierDishEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string QuanPin
		{
            get
            {
                return this.quanPin;
            }

            set
            {
                this.quanPin = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the JianPin of SupplierDishEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string JianPin
		{
            get
            {
                return this.jianPin;
            }

            set
            {
                this.jianPin = value;
            }
        }

			/// <summary>
        /// Gets or sets a value indicating whether mapping the IsCommission of SupplierDishEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual bool? IsCommission
		{
            get
            {
                return this.isCommission;
            }

            set
            {
                this.isCommission = value;
            }
        }

			/// <summary>
        /// Gets or sets a value indicating whether mapping the IsDiscount of SupplierDishEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual bool? IsDiscount
		{
            get
            {
                return this.isDiscount;
            }

            set
            {
                this.isDiscount = value;
            }
        }

			/// <summary>
        /// Gets or sets a value indicating whether mapping the IsDel of SupplierDishEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
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
        /// Gets or sets a value mapping the ModifyTime of SupplierDishEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual DateTime? ModifyTime
		{
            get
            {
                return this.modifyTime;
            }

            set
            {
                this.modifyTime = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the BundleSupplierDishList of SupplierDishEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual IList<BundleSupplierDishEntity> BundleSupplierDishList
		{
            get
            {
                return this.bundleSupplierDishList;
            }

            set
            {
                this.bundleSupplierDishList = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the CrossSupplierDishList of SupplierDishEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual IList<CrossSupplierDishEntity> CrossSupplierDishList
		{
            get
            {
                return this.crossSupplierDishList;
            }

            set
            {
                this.crossSupplierDishList = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the MenuLayoutDishList of SupplierDishEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual IList<MenuLayoutDishEntity> MenuLayoutDishList
		{
            get
            {
                return this.menuLayoutDishList;
            }

            set
            {
                this.menuLayoutDishList = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the supplierDishMinNumberList of SupplierDishEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual IList<SupplierDishMinNumberEntity> SupplierDishMinNumberList
		{
            get
            {
                return this.supplierDishMinNumberList;
            }

            set
            {
                this.supplierDishMinNumberList = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the DishImageID of SupplierDishEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual DishImageEntity DishImage
		{
            get
            {
                return this.dishImage;
            }

            set
            {
                this.dishImage = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the SupplierID of SupplierDishEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
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
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public override bool Equals(object obj)
        {
            if (obj == null || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }

            var castObj = (SupplierDishEntity)obj;
            return this.SupplierDishId == castObj.SupplierDishId;
        }

		/// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public override int GetHashCode()
		{
			var hash = 57; 
			hash = 27 * hash * this.SupplierDishId.GetHashCode();
			return hash;
		}
	}
}