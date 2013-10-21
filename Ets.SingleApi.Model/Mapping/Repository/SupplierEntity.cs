// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SupplierEntity.cs" company="Irdeto">
//   Copyright @ 2013
// </copyright>
// <summary>
//   Class:SupplierEntity
//   Namespace:Ets.SingleApi.Model.Repository
//   Class Funtion:Represent the class mapping the SupplierEntity table in the database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Ets.SingleApi.Model.Repository
{
	using System;
	using System.Collections.Generic;
		
    /// <summary>
    /// Class:SupplierEntity
    /// Namespace:Ets.SingleApi.Model.Repository
    /// Class Funtion:Represent the class mapping the SupplierEntity table in the database.
    /// </summary>
    /// Creator:周超
    /// Creation Date:2013/10/13 14:01:30
    /// Modifier:
    /// Last Modified:
    /// ----------------------------------------------------------------------------------------
    [Serializable]
    public class SupplierEntity
    {
		#region private member

			/// <summary>
		/// The SupplierID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int supplierId;

			/// <summary>
		/// The SupplierName
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string supplierName;

			/// <summary>
		/// The LiveURL
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string liveUrl;

			/// <summary>
		/// The Address1
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string address1;

			/// <summary>
		/// The Address2
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string address2;

			/// <summary>
		/// The CityID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? cityId;

			/// <summary>
		/// The CountyID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? countyId;

			/// <summary>
		/// The CountryID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? countryId;

			/// <summary>
		/// The PostCode
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string postCode;

			/// <summary>
		/// The Lat
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string lat;

			/// <summary>
		/// The Long
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string long1;

			/// <summary>
		/// The BaiduLat
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string baIduLat;

			/// <summary>
		/// The BaiduLong
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string baIduLong;

			/// <summary>
		/// The SpaceLatLong
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private byte[] spaceLatLong;

			/// <summary>
		/// The IsOpenDoor
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private bool? isOpenDoor;

			/// <summary>
		/// The Telephone
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string telephone;

			/// <summary>
		/// The Fax
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string fax;

			/// <summary>
		/// The Email
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string email;

			/// <summary>
		/// The Commission
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private decimal commission;

			/// <summary>
		/// The DeliveryTime
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string deliveryTime;

			/// <summary>
		/// The MenuPath
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string menuPath;

			/// <summary>
		/// The MapPath
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string mapPath;

			/// <summary>
		/// The SupplierDescription
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string supplierDescription;

			/// <summary>
		/// The DateJoined
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private DateTime? dateJoined;

			/// <summary>
		/// The Priority
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private short? priority;

			/// <summary>
		/// The FreeDeliveryLine
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private decimal? freeDeliveryLine;

			/// <summary>
		/// The CardTransactionFee
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private decimal? cardTransactionFee;

			/// <summary>
		/// The InputType
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string inputType;

			/// <summary>
		/// The Template
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string template;

			/// <summary>
		/// The UpdateTemplateCount
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? updateTemplateCount;

			/// <summary>
		/// The ParentID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? parentId;

			/// <summary>
		/// The ShoppingGuide
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string shoppingGuIde;

			/// <summary>
		/// The Help
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string help;

			/// <summary>
		/// The DefaultCuisineID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? defaultCuisineId;

			/// <summary>
		/// The Career
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string career;

			/// <summary>
		/// The OrderHotline
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string orderHotline;

			/// <summary>
		/// The SpecialOffersSummary
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string specialOffersSummary;

			/// <summary>
		/// The SMS
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string sMS;

			/// <summary>
		/// The FreeMiles
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private decimal? freeMiles;

			/// <summary>
		/// The CashTransctionFee
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private decimal? cashTransctionFee;

			/// <summary>
		/// The CashCommisionFee
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private decimal? cashCommisionFee;

			/// <summary>
		/// The CardTransctionFee
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private decimal? cardTransctionFee;

			/// <summary>
		/// The CardCommisionFee
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private decimal? cardCommisionFee;

			/// <summary>
		/// The CardFee
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private decimal? cardFee;

			/// <summary>
		/// The BankName
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string bankName;

			/// <summary>
		/// The SortCode
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string sortCode;

			/// <summary>
		/// The AccountNumber
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string accountNumber;

			/// <summary>
		/// The IsHallah
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? isHallah;

			/// <summary>
		/// The SecurityCode
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string securityCode;

			/// <summary>
		/// The TableBookingCharge
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private decimal? tableBookingCharge;

			/// <summary>
		/// The AverageConsumption
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? averageConsumption;

			/// <summary>
		/// The ParkingInfo
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string parkingInfo;

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
		/// The PackagingFee
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private decimal? packagingFee;

			/// <summary>
		/// The DelMinOrderAmount
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? delMinOrderAmount;

			/// <summary>
		/// The FixedDeliveryCharge
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? fixedDeliveryCharge;

			/// <summary>
		/// The TakeawaySpecialOffersSummary
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string takeawaySpecialOffersSummary;

			/// <summary>
		/// The PublicTransport
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string publicTransport;

			/// <summary>
		/// The DisplayRoomList
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private bool? displayRoomList;

			/// <summary>
		/// The DisplayTableList
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private bool? displayTableList;

			/// <summary>
		/// The Creator
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string creator;

			/// <summary>
		/// The Editor
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string editor;

			/// <summary>
		/// The EditTime
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private DateTime? editTime;

			/// <summary>
		/// The maxprice
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? maxprice;

			/// <summary>
		/// The minprice
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? minprice;

			/// <summary>
		/// The averageprice
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? averageprice;

			/// <summary>
		/// The Hits
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? hits;

			/// <summary>
		/// The IsOnSales
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private bool? isOnSales;

			/// <summary>
		/// The Tags
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string tags;

			/// <summary>
		/// The Tags1
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string tags1;

			/// <summary>
		/// The Tags2
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string tags2;

			/// <summary>
		/// The Tags3
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string tags3;

			/// <summary>
		/// The CreateDate
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private DateTime? createDate;

			/// <summary>
		/// The PackLadder
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private decimal? packLadder;

			/// <summary>
		/// The PackExplain
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string packExplain;

			/// <summary>
		/// The OrderingCustomerCommission
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private decimal? orderingCustomerCommission;

			/// <summary>
		/// The OrderConsumerCommission
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private decimal? orderConsumerCommission;

			/// <summary>
		/// The OrderETaoShiCommission
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private decimal? orderETaoShiCommission;

			/// <summary>
		/// The IsOtherSite
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private bool? isOtherSite;

			/// <summary>
		/// The LogisticsAreaId
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? logisticsAreaId;

			/// <summary>
		/// The ConsumerAmount
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private decimal? consumerAmount;

			/// <summary>
		/// The DoomNotes
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string doomNotes;

			/// <summary>
		/// The TeaBitFee
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private decimal? teaBitFee;

			/// <summary>
		/// The IsDDF
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private bool? isDDF;

			/// <summary>
		/// The OrderCount
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? orderCount;

			/// <summary>
		/// The StoredAmount
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private decimal? storedAmount;

			/// <summary>
		/// The RechargeBalance
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private decimal? rechargeBalance;

			/// <summary>
		/// The CurrentBalance
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private decimal? currentBalance;

			/// <summary>
		/// The EtkRates
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private decimal? etkRates;

			/// <summary>
		/// The CardDisplayDiscount
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private decimal? cardDisplayDiscount;

			/// <summary>
		/// The CardDisplayRule
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string cardDisplayRule;

			/// <summary>
		/// The RegionCode
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string regionCode;

			/// <summary>
		/// The ImportId
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string importId;

			/// <summary>
		/// The HasDish
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private bool? hasDish;

			/// <summary>
		/// The SignTime
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private DateTime? signTime;

			/// <summary>
		/// The Type
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string type;

			/// <summary>
		/// The OrderNum
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? orderNum;

			/// <summary>
		/// The SupplierGroupId
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? supplierGroupId;

			/// <summary>
		/// The Channel
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private string channel;

			/// <summary>
		/// The MenuLayout
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private int? menuLayout;

			/// <summary>
		/// The BundleList
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private IList<BundleEntity> bundleList;

			/// <summary>
		/// The CampaignSupplierList
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private IList<CampaignSupplierEntity> campaignSupplierList;

			/// <summary>
		/// The ChefList
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private IList<ChefEntity> chefList;

			/// <summary>
		/// The CouponList
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private IList<CouponEntity> couponList;

			/// <summary>
		/// The CustomerFavoriteList
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private IList<CustomerFavoriteEntity> customerFavoriteList;

			/// <summary>
		/// The CustomerPointList
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private IList<CustomerPointEntity> customerPointList;

			/// <summary>
		/// The FeedBackList
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private IList<FeedBackEntity> feedBackList;

			/// <summary>
		/// The InvoiceList
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private IList<InvoiceEntity> invoiceList;

			/// <summary>
		/// The MarketingAllowanceList
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private IList<MarketingAllowanceEntity> marketingAllowanceList;

			/// <summary>
		/// The MarketingMessageList
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private IList<MarketingMessageEntity> marketingMessageList;

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
		/// The MenuLayoutSupplierList
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private IList<MenuLayoutSupplierEntity> menuLayoutSupplierList;

			/// <summary>
		/// The PointCouponSupplier_RList
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private IList<PointCouponSupplierREntity> pointCouponSupplierRList;

			/// <summary>
		/// The PromotionList
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private IList<PromotionEntity> promotionList;

			/// <summary>
		/// The StatementList
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private IList<StatementEntity> statementList;

			/// <summary>
		/// The SupplierBusinessAreaList
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private IList<SupplierBusinessAreaEntity> supplierBusinessAreaList;

			/// <summary>
		/// The SupplierCommissionList
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private IList<SupplierCommissionEntity> supplierCommissionList;

			/// <summary>
		/// The SupplierContactList
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private IList<SupplierContactEntity> supplierContactList;

			/// <summary>
		/// The SupplierCouponList
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private IList<SupplierCouponEntity> supplierCouponList;

			/// <summary>
		/// The SupplierCuisineList
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private IList<SupplierCuisineEntity> supplierCuisineList;

			/// <summary>
		/// The SupplierDiningPurposeList
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private IList<SupplierDiningPurposeEntity> supplierDiningPurposeList;

			/// <summary>
		/// The SupplierDishList
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private IList<SupplierDishEntity> supplierDishList;

			/// <summary>
		/// The SupplierFeatureList
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private IList<SupplierFeatureEntity> supplierFeatureList;

			/// <summary>
		/// The SupplierImageList
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private IList<SupplierImageEntity> supplierImageList;

			/// <summary>
		/// The SupplierLocationList
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private IList<SupplierLocationEntity> supplierLocationList;

			/// <summary>
		/// The SupplierRatingList
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private IList<SupplierRatingEntity> supplierRatingList;

			/// <summary>
		/// The SupplierRoomSizeList
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private IList<SupplierRoomSizeEntity> supplierRoomSizeList;

			/// <summary>
		/// The SupplierSpecialOfferList
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private IList<SupplierSpecialOfferEntity> supplierSpecialOfferList;

			/// <summary>
		/// The SupplierStationList
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private IList<SupplierStationEntity> supplierStationList;

			/// <summary>
		/// The SupplierTransportList
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private IList<SupplierTransportEntity> supplierTransportList;

			/// <summary>
		/// The TableDeskList
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private IList<TableDeskEntity> tableDeskList;

			/// <summary>
		/// The TableReservationList
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private IList<TableReservationEntity> tableReservationList;

			/// <summary>
		/// The VacancyList
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private IList<VacancyEntity> vacancyList;

			/// <summary>
		/// The AddrCityID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private AddrCityEntity addrCity;

			/// <summary>
		/// The AddrProvinceID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private AddrProvinceEntity addrProvince;

			/// <summary>
		/// The AddrRegionID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private AddrRegionEntity addrRegion;

			/// <summary>
		/// The LoginID
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		private LoginEntity login;

		#endregion

		/// <summary>
        /// Initializes a new instance of the <see cref="SupplierEntity"/> class.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
        public SupplierEntity()
        {
			this.supplierId = 0;
            this.supplierName = string.Empty;
			this.liveUrl = string.Empty;
			this.address1 = string.Empty;
			this.address2 = string.Empty;
			this.postCode = "0";
			this.lat = string.Empty;
			this.long1 = string.Empty;
			this.baIduLat = string.Empty;
			this.baIduLong = string.Empty;
			this.spaceLatLong = null;
            this.telephone = string.Empty;
			this.fax = string.Empty;
			this.email = string.Empty;
			this.commission = 0;
			this.deliveryTime = string.Empty;
			this.menuPath = string.Empty;
			this.mapPath = string.Empty;
			this.supplierDescription = string.Empty;
			this.inputType = string.Empty;
            this.template = string.Empty;
			this.shoppingGuIde = string.Empty;
			this.help = string.Empty;
			this.career = string.Empty;
			this.orderHotline = string.Empty;
			this.specialOffersSummary = string.Empty;
			this.sMS = string.Empty;
			this.bankName = string.Empty;
			this.sortCode = string.Empty;
			this.accountNumber = string.Empty;
			this.securityCode = string.Empty;
			this.parkingInfo = string.Empty;
			this.takeawaySpecialOffersSummary = string.Empty;
			this.publicTransport = string.Empty;
			this.creator = string.Empty;
			this.editor = string.Empty;
			this.tags = string.Empty;
			this.tags1 = string.Empty;
			this.tags2 = string.Empty;
			this.tags3 = string.Empty;
			this.packExplain = string.Empty;
			this.doomNotes = string.Empty;
			this.cardDisplayRule = string.Empty;
			this.regionCode = string.Empty;
			this.importId = string.Empty;
			this.type = string.Empty;
			this.channel = string.Empty;
		}

		#region public member

			/// <summary>
        /// Gets or sets a value mapping the SupplierID of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int SupplierId
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
        /// Gets or sets a value mapping the SupplierName of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string SupplierName
		{
            get
            {
                return this.supplierName;
            }

            set
            {
                this.supplierName = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the LiveURL of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string LiveUrl
		{
            get
            {
                return this.liveUrl;
            }

            set
            {
                this.liveUrl = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Address1 of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
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
        /// Gets or sets a value mapping the Address2 of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
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
        /// Gets or sets a value mapping the CityID of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
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
        /// Gets or sets a value mapping the CountyID of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
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
        /// Gets or sets a value mapping the CountryID of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
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
        /// Gets or sets a value mapping the PostCode of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
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
        /// Gets or sets a value mapping the Lat of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string Lat
		{
            get
            {
                return this.lat;
            }

            set
            {
                this.lat = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Long of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string Long
		{
            get
            {
                return this.long1;
            }

            set
            {
                this.long1 = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the BaiduLat of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string BaIduLat
		{
            get
            {
                return this.baIduLat;
            }

            set
            {
                this.baIduLat = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the BaiduLong of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string BaIduLong
		{
            get
            {
                return this.baIduLong;
            }

            set
            {
                this.baIduLong = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the SpaceLatLong of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual byte[] SpaceLatLong
		{
            get
            {
                return this.spaceLatLong;
            }

            set
            {
                this.spaceLatLong = value;
            }
        }

			/// <summary>
        /// Gets or sets a value indicating whether mapping the IsOpenDoor of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual bool? IsOpenDoor
		{
            get
            {
                return this.isOpenDoor;
            }

            set
            {
                this.isOpenDoor = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Telephone of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
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
        /// Gets or sets a value mapping the Fax of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
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
        /// Gets or sets a value mapping the Email of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
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
        /// Gets or sets a value mapping the Commission of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual decimal Commission
		{
            get
            {
                return this.commission;
            }

            set
            {
                this.commission = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the DeliveryTime of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string DeliveryTime
		{
            get
            {
                return this.deliveryTime;
            }

            set
            {
                this.deliveryTime = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the MenuPath of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string MenuPath
		{
            get
            {
                return this.menuPath;
            }

            set
            {
                this.menuPath = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the MapPath of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string MapPath
		{
            get
            {
                return this.mapPath;
            }

            set
            {
                this.mapPath = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the SupplierDescription of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string SupplierDescription
		{
            get
            {
                return this.supplierDescription;
            }

            set
            {
                this.supplierDescription = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the DateJoined of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
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
        /// Gets or sets a value mapping the Priority of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual short? Priority
		{
            get
            {
                return this.priority;
            }

            set
            {
                this.priority = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the FreeDeliveryLine of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual decimal? FreeDeliveryLine
		{
            get
            {
                return this.freeDeliveryLine;
            }

            set
            {
                this.freeDeliveryLine = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the CardTransactionFee of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual decimal? CardTransactionFee
		{
            get
            {
                return this.cardTransactionFee;
            }

            set
            {
                this.cardTransactionFee = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the InputType of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string InputType
		{
            get
            {
                return this.inputType;
            }

            set
            {
                this.inputType = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Template of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string Template
		{
            get
            {
                return this.template;
            }

            set
            {
                this.template = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the UpdateTemplateCount of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? UpdateTemplateCount
		{
            get
            {
                return this.updateTemplateCount;
            }

            set
            {
                this.updateTemplateCount = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the ParentID of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? ParentId
		{
            get
            {
                return this.parentId;
            }

            set
            {
                this.parentId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the ShoppingGuide of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string ShoppingGuIde
		{
            get
            {
                return this.shoppingGuIde;
            }

            set
            {
                this.shoppingGuIde = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Help of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string Help
		{
            get
            {
                return this.help;
            }

            set
            {
                this.help = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the DefaultCuisineID of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? DefaultCuisineId
		{
            get
            {
                return this.defaultCuisineId;
            }

            set
            {
                this.defaultCuisineId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Career of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string Career
		{
            get
            {
                return this.career;
            }

            set
            {
                this.career = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the OrderHotline of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string OrderHotline
		{
            get
            {
                return this.orderHotline;
            }

            set
            {
                this.orderHotline = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the SpecialOffersSummary of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string SpecialOffersSummary
		{
            get
            {
                return this.specialOffersSummary;
            }

            set
            {
                this.specialOffersSummary = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the SMS of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string SMS
		{
            get
            {
                return this.sMS;
            }

            set
            {
                this.sMS = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the FreeMiles of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual decimal? FreeMiles
		{
            get
            {
                return this.freeMiles;
            }

            set
            {
                this.freeMiles = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the CashTransctionFee of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual decimal? CashTransctionFee
		{
            get
            {
                return this.cashTransctionFee;
            }

            set
            {
                this.cashTransctionFee = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the CashCommisionFee of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual decimal? CashCommisionFee
		{
            get
            {
                return this.cashCommisionFee;
            }

            set
            {
                this.cashCommisionFee = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the CardTransctionFee of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual decimal? CardTransctionFee
		{
            get
            {
                return this.cardTransctionFee;
            }

            set
            {
                this.cardTransctionFee = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the CardCommisionFee of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual decimal? CardCommisionFee
		{
            get
            {
                return this.cardCommisionFee;
            }

            set
            {
                this.cardCommisionFee = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the CardFee of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual decimal? CardFee
		{
            get
            {
                return this.cardFee;
            }

            set
            {
                this.cardFee = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the BankName of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string BankName
		{
            get
            {
                return this.bankName;
            }

            set
            {
                this.bankName = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the SortCode of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string SortCode
		{
            get
            {
                return this.sortCode;
            }

            set
            {
                this.sortCode = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the AccountNumber of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string AccountNumber
		{
            get
            {
                return this.accountNumber;
            }

            set
            {
                this.accountNumber = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the IsHallah of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? IsHallah
		{
            get
            {
                return this.isHallah;
            }

            set
            {
                this.isHallah = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the SecurityCode of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string SecurityCode
		{
            get
            {
                return this.securityCode;
            }

            set
            {
                this.securityCode = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the TableBookingCharge of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual decimal? TableBookingCharge
		{
            get
            {
                return this.tableBookingCharge;
            }

            set
            {
                this.tableBookingCharge = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the AverageConsumption of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? AverageConsumption
		{
            get
            {
                return this.averageConsumption;
            }

            set
            {
                this.averageConsumption = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the ParkingInfo of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string ParkingInfo
		{
            get
            {
                return this.parkingInfo;
            }

            set
            {
                this.parkingInfo = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the AverageRating of SupplierEntity table in the database.
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
        /// Gets or sets a value mapping the PackagingFee of SupplierEntity table in the database.
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
        /// Gets or sets a value mapping the DelMinOrderAmount of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? DelMinOrderAmount
		{
            get
            {
                return this.delMinOrderAmount;
            }

            set
            {
                this.delMinOrderAmount = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the FixedDeliveryCharge of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? FixedDeliveryCharge
		{
            get
            {
                return this.fixedDeliveryCharge;
            }

            set
            {
                this.fixedDeliveryCharge = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the TakeawaySpecialOffersSummary of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string TakeawaySpecialOffersSummary
		{
            get
            {
                return this.takeawaySpecialOffersSummary;
            }

            set
            {
                this.takeawaySpecialOffersSummary = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the PublicTransport of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string PublicTransport
		{
            get
            {
                return this.publicTransport;
            }

            set
            {
                this.publicTransport = value;
            }
        }

			/// <summary>
        /// Gets or sets a value indicating whether mapping the DisplayRoomList of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual bool? DisplayRoomList
		{
            get
            {
                return this.displayRoomList;
            }

            set
            {
                this.displayRoomList = value;
            }
        }

			/// <summary>
        /// Gets or sets a value indicating whether mapping the DisplayTableList of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual bool? DisplayTableList
		{
            get
            {
                return this.displayTableList;
            }

            set
            {
                this.displayTableList = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Creator of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string Creator
		{
            get
            {
                return this.creator;
            }

            set
            {
                this.creator = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Editor of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string Editor
		{
            get
            {
                return this.editor;
            }

            set
            {
                this.editor = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the EditTime of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual DateTime? EditTime
		{
            get
            {
                return this.editTime;
            }

            set
            {
                this.editTime = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the maxprice of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? Maxprice
		{
            get
            {
                return this.maxprice;
            }

            set
            {
                this.maxprice = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the minprice of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? Minprice
		{
            get
            {
                return this.minprice;
            }

            set
            {
                this.minprice = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the averageprice of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? Averageprice
		{
            get
            {
                return this.averageprice;
            }

            set
            {
                this.averageprice = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Hits of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? Hits
		{
            get
            {
                return this.hits;
            }

            set
            {
                this.hits = value;
            }
        }

			/// <summary>
        /// Gets or sets a value indicating whether mapping the IsOnSales of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual bool? IsOnSales
		{
            get
            {
                return this.isOnSales;
            }

            set
            {
                this.isOnSales = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Tags of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string Tags
		{
            get
            {
                return this.tags;
            }

            set
            {
                this.tags = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Tags1 of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string Tags1
		{
            get
            {
                return this.tags1;
            }

            set
            {
                this.tags1 = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Tags2 of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string Tags2
		{
            get
            {
                return this.tags2;
            }

            set
            {
                this.tags2 = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Tags3 of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string Tags3
		{
            get
            {
                return this.tags3;
            }

            set
            {
                this.tags3 = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the CreateDate of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
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
        /// Gets or sets a value mapping the PackLadder of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual decimal? PackLadder
		{
            get
            {
                return this.packLadder;
            }

            set
            {
                this.packLadder = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the PackExplain of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string PackExplain
		{
            get
            {
                return this.packExplain;
            }

            set
            {
                this.packExplain = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the OrderingCustomerCommission of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual decimal? OrderingCustomerCommission
		{
            get
            {
                return this.orderingCustomerCommission;
            }

            set
            {
                this.orderingCustomerCommission = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the OrderConsumerCommission of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual decimal? OrderConsumerCommission
		{
            get
            {
                return this.orderConsumerCommission;
            }

            set
            {
                this.orderConsumerCommission = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the OrderETaoShiCommission of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual decimal? OrderETaoShiCommission
		{
            get
            {
                return this.orderETaoShiCommission;
            }

            set
            {
                this.orderETaoShiCommission = value;
            }
        }

			/// <summary>
        /// Gets or sets a value indicating whether mapping the IsOtherSite of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual bool? IsOtherSite
		{
            get
            {
                return this.isOtherSite;
            }

            set
            {
                this.isOtherSite = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the LogisticsAreaId of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? LogisticsAreaId
		{
            get
            {
                return this.logisticsAreaId;
            }

            set
            {
                this.logisticsAreaId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the ConsumerAmount of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual decimal? ConsumerAmount
		{
            get
            {
                return this.consumerAmount;
            }

            set
            {
                this.consumerAmount = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the DoomNotes of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string DoomNotes
		{
            get
            {
                return this.doomNotes;
            }

            set
            {
                this.doomNotes = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the TeaBitFee of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual decimal? TeaBitFee
		{
            get
            {
                return this.teaBitFee;
            }

            set
            {
                this.teaBitFee = value;
            }
        }

			/// <summary>
        /// Gets or sets a value indicating whether mapping the IsDDF of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual bool? IsDDF
		{
            get
            {
                return this.isDDF;
            }

            set
            {
                this.isDDF = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the OrderCount of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? OrderCount
		{
            get
            {
                return this.orderCount;
            }

            set
            {
                this.orderCount = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the StoredAmount of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual decimal? StoredAmount
		{
            get
            {
                return this.storedAmount;
            }

            set
            {
                this.storedAmount = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the RechargeBalance of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual decimal? RechargeBalance
		{
            get
            {
                return this.rechargeBalance;
            }

            set
            {
                this.rechargeBalance = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the CurrentBalance of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual decimal? CurrentBalance
		{
            get
            {
                return this.currentBalance;
            }

            set
            {
                this.currentBalance = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the EtkRates of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual decimal? EtkRates
		{
            get
            {
                return this.etkRates;
            }

            set
            {
                this.etkRates = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the CardDisplayDiscount of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual decimal? CardDisplayDiscount
		{
            get
            {
                return this.cardDisplayDiscount;
            }

            set
            {
                this.cardDisplayDiscount = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the CardDisplayRule of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string CardDisplayRule
		{
            get
            {
                return this.cardDisplayRule;
            }

            set
            {
                this.cardDisplayRule = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the RegionCode of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
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

			/// <summary>
        /// Gets or sets a value mapping the ImportId of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string ImportId
		{
            get
            {
                return this.importId;
            }

            set
            {
                this.importId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value indicating whether mapping the HasDish of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual bool? HasDish
		{
            get
            {
                return this.hasDish;
            }

            set
            {
                this.hasDish = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the SignTime of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual DateTime? SignTime
		{
            get
            {
                return this.signTime;
            }

            set
            {
                this.signTime = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Type of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string Type
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
        /// Gets or sets a value mapping the OrderNum of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? OrderNum
		{
            get
            {
                return this.orderNum;
            }

            set
            {
                this.orderNum = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the SupplierGroupId of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? SupplierGroupId
		{
            get
            {
                return this.supplierGroupId;
            }

            set
            {
                this.supplierGroupId = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the Channel of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual string Channel
		{
            get
            {
                return this.channel;
            }

            set
            {
                this.channel = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the MenuLayout of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual int? MenuLayout
		{
            get
            {
                return this.menuLayout;
            }

            set
            {
                this.menuLayout = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the BundleList of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual IList<BundleEntity> BundleList
		{
            get
            {
                return this.bundleList;
            }

            set
            {
                this.bundleList = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the CampaignSupplierList of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual IList<CampaignSupplierEntity> CampaignSupplierList
		{
            get
            {
                return this.campaignSupplierList;
            }

            set
            {
                this.campaignSupplierList = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the ChefList of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual IList<ChefEntity> ChefList
		{
            get
            {
                return this.chefList;
            }

            set
            {
                this.chefList = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the CouponList of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual IList<CouponEntity> CouponList
		{
            get
            {
                return this.couponList;
            }

            set
            {
                this.couponList = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the CustomerFavoriteList of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
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
        /// Gets or sets a value mapping the CustomerPointList of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
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
        /// Gets or sets a value mapping the FeedBackList of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual IList<FeedBackEntity> FeedBackList
		{
            get
            {
                return this.feedBackList;
            }

            set
            {
                this.feedBackList = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the InvoiceList of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual IList<InvoiceEntity> InvoiceList
		{
            get
            {
                return this.invoiceList;
            }

            set
            {
                this.invoiceList = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the MarketingAllowanceList of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
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
        /// Gets or sets a value mapping the MarketingMessageList of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual IList<MarketingMessageEntity> MarketingMessageList
		{
            get
            {
                return this.marketingMessageList;
            }

            set
            {
                this.marketingMessageList = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the MenuLayoutDishList of SupplierEntity table in the database.
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
        /// Gets or sets a value mapping the MenuLayoutSupplierList of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual IList<MenuLayoutSupplierEntity> MenuLayoutSupplierList
		{
            get
            {
                return this.menuLayoutSupplierList;
            }

            set
            {
                this.menuLayoutSupplierList = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the PointCouponSupplier_RList of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual IList<PointCouponSupplierREntity> PointCouponSupplierRList
		{
            get
            {
                return this.pointCouponSupplierRList;
            }

            set
            {
                this.pointCouponSupplierRList = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the PromotionList of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual IList<PromotionEntity> PromotionList
		{
            get
            {
                return this.promotionList;
            }

            set
            {
                this.promotionList = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the StatementList of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual IList<StatementEntity> StatementList
		{
            get
            {
                return this.statementList;
            }

            set
            {
                this.statementList = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the SupplierBusinessAreaList of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual IList<SupplierBusinessAreaEntity> SupplierBusinessAreaList
		{
            get
            {
                return this.supplierBusinessAreaList;
            }

            set
            {
                this.supplierBusinessAreaList = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the SupplierCommissionList of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual IList<SupplierCommissionEntity> SupplierCommissionList
		{
            get
            {
                return this.supplierCommissionList;
            }

            set
            {
                this.supplierCommissionList = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the SupplierContactList of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
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

			/// <summary>
        /// Gets or sets a value mapping the SupplierCouponList of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual IList<SupplierCouponEntity> SupplierCouponList
		{
            get
            {
                return this.supplierCouponList;
            }

            set
            {
                this.supplierCouponList = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the SupplierCuisineList of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual IList<SupplierCuisineEntity> SupplierCuisineList
		{
            get
            {
                return this.supplierCuisineList;
            }

            set
            {
                this.supplierCuisineList = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the SupplierDiningPurposeList of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual IList<SupplierDiningPurposeEntity> SupplierDiningPurposeList
		{
            get
            {
                return this.supplierDiningPurposeList;
            }

            set
            {
                this.supplierDiningPurposeList = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the SupplierDishList of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual IList<SupplierDishEntity> SupplierDishList
		{
            get
            {
                return this.supplierDishList;
            }

            set
            {
                this.supplierDishList = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the SupplierFeatureList of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual IList<SupplierFeatureEntity> SupplierFeatureList
		{
            get
            {
                return this.supplierFeatureList;
            }

            set
            {
                this.supplierFeatureList = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the SupplierImageList of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual IList<SupplierImageEntity> SupplierImageList
		{
            get
            {
                return this.supplierImageList;
            }

            set
            {
                this.supplierImageList = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the SupplierLocationList of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual IList<SupplierLocationEntity> SupplierLocationList
		{
            get
            {
                return this.supplierLocationList;
            }

            set
            {
                this.supplierLocationList = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the SupplierRatingList of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual IList<SupplierRatingEntity> SupplierRatingList
		{
            get
            {
                return this.supplierRatingList;
            }

            set
            {
                this.supplierRatingList = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the SupplierRoomSizeList of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual IList<SupplierRoomSizeEntity> SupplierRoomSizeList
		{
            get
            {
                return this.supplierRoomSizeList;
            }

            set
            {
                this.supplierRoomSizeList = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the SupplierSpecialOfferList of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual IList<SupplierSpecialOfferEntity> SupplierSpecialOfferList
		{
            get
            {
                return this.supplierSpecialOfferList;
            }

            set
            {
                this.supplierSpecialOfferList = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the SupplierStationList of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual IList<SupplierStationEntity> SupplierStationList
		{
            get
            {
                return this.supplierStationList;
            }

            set
            {
                this.supplierStationList = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the SupplierTransportList of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual IList<SupplierTransportEntity> SupplierTransportList
		{
            get
            {
                return this.supplierTransportList;
            }

            set
            {
                this.supplierTransportList = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the TableDeskList of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual IList<TableDeskEntity> TableDeskList
		{
            get
            {
                return this.tableDeskList;
            }

            set
            {
                this.tableDeskList = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the TableReservationList of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual IList<TableReservationEntity> TableReservationList
		{
            get
            {
                return this.tableReservationList;
            }

            set
            {
                this.tableReservationList = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the VacancyList of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual IList<VacancyEntity> VacancyList
		{
            get
            {
                return this.vacancyList;
            }

            set
            {
                this.vacancyList = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the AddrCityID of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual AddrCityEntity AddrCity
		{
            get
            {
                return this.addrCity;
            }

            set
            {
                this.addrCity = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the AddrProvinceID of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual AddrProvinceEntity AddrProvince
		{
            get
            {
                return this.addrProvince;
            }

            set
            {
                this.addrProvince = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the AddrRegionID of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
        /// Modifier:
        /// Last Modified:
        /// ----------------------------------------------------------------------------------------
		public virtual AddrRegionEntity AddrRegion
		{
            get
            {
                return this.addrRegion;
            }

            set
            {
                this.addrRegion = value;
            }
        }

			/// <summary>
        /// Gets or sets a value mapping the LoginID of SupplierEntity table in the database.
        /// </summary>
        /// Creator:周超
        /// Creation Date:2013/10/13 14:01:30
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

            var castObj = (SupplierEntity)obj;
            return this.SupplierId == castObj.SupplierId;
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
			hash = 27 * hash * this.SupplierId.GetHashCode();
			return hash;
		}
	}
}