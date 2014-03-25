namespace Ets.SingleApi.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Ets.SingleApi.Controllers.IServices;
    using Ets.SingleApi.Model;
    using Ets.SingleApi.Model.Repository;
    using Ets.SingleApi.Model.Services;
    using Ets.SingleApi.Services.IDetailServices;
    using Ets.SingleApi.Services.IRepository;
    using Ets.SingleApi.Utility;

    /// <summary>
    /// 类名称：SupplierServices
    /// 命名空间：Ets.SingleApi.Services
    /// 类功能：提供餐厅信息API
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/15 18:05
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class SupplierServices : ISupplierServices
    {
        /// <summary>
        /// 字段supplierEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：2013/10/15 18:10
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<SupplierEntity> supplierEntityRepository;

        /// <summary>
        /// 字段supplierImageEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：11/12/2013 6:16 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<SupplierImageEntity> supplierImageEntityRepository;

        /// <summary>
        /// 字段supplierCuisineEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：11/7/2013 10:16 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<SupplierCuisineEntity> supplierCuisineEntityRepository;

        /// <summary>
        /// 字段supplierDishEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：2013/10/20 10:34
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<SupplierDishEntity> supplierDishEntityRepository;

        /// <summary>
        /// 字段supplierDishImageEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：11/3/2013 4:25 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<SupplierDishImageEntity> supplierDishImageEntityRepository;

        /// <summary>
        /// 字段supplierCategoryEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：2013/10/20 10:34
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<SupplierCategoryEntity> supplierCategoryEntityRepository;

        /// <summary>
        /// 字段supplierMenuCategoryEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：2013/10/20 10:35
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<SupplierMenuCategoryEntity> supplierMenuCategoryEntityRepository;

        /// <summary>
        /// 字段suppTimeTableDisplayEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：2013/10/20 9:14
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<SuppTimeTableDisplayEntity> suppTimeTableDisplayEntityRepository;

        /// <summary>
        /// 字段supplierFeatureEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：10/22/2013 11:53 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<SupplierFeatureEntity> supplierFeatureEntityRepository;

        /// <summary>
        /// 字段supplierDiningPurposeEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：11/20/2013 4:43 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<SupplierDiningPurposeEntity> supplierDiningPurposeEntityRepository;

        /// <summary>
        /// 字段timeTableDisplayEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：2013/10/20 9:15
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<TimeTableDisplayEntity> timeTableDisplayEntityRepository;

        /// <summary>
        /// 字段loginEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：11/18/2013 5:06 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<LoginEntity> loginEntityRepository;

        /// <summary>
        /// 字段regionEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：12/28/2013 5:11 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<RegionEntity> regionEntityRepository;

        /// <summary>
        /// 早晚市时间
        /// </summary>
        /// 创建者：苏建峰
        /// 创建日期：3/19/2014 11:43 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<SupplierDeskTimeEntity> supplierDeskTimeEntityRepository;

        /// <summary>
        /// 台位类型锁定表
        /// </summary>
        /// 创建者：苏建峰
        /// 创建日期：3/19/2014 11:43 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<DeskTypeLockLogEntity> deskTypeLockLogEntityRepository;

        /// <summary>
        /// 台位类型表
        /// </summary>
        /// 创建者：苏建峰
        /// 创建日期：3/19/2014 2:50 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<DeskTypeEntity> deskTypeEntityRepository;

        /// <summary>
        /// 字段deskBookingEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：3/24/2014 12:20 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<DeskBookingEntity> deskBookingEntityRepository;

        /// <summary>
        /// 字段supplierDeskEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：3/24/2014 12:20 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<SupplierDeskEntity> supplierDeskEntityRepository;

        /// <summary>
        /// 字段supplierDetailServices
        /// </summary>
        /// 创建者：周超
        /// 创建日期：11/1/2013 5:06 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly ISupplierDetailServices supplierDetailServices;

        /// <summary>
        /// Initializes a new instance of the <see cref="SupplierServices" /> class.
        /// </summary>
        /// <param name="supplierEntityRepository">The supplierEntityRepository</param>
        /// <param name="supplierImageEntityRepository">The supplierImageEntityRepository</param>
        /// <param name="supplierCuisineEntityRepository">The supplierCuisineEntityRepository</param>
        /// <param name="supplierDishEntityRepository">The supplierDishEntityRepository</param>
        /// <param name="supplierDishImageEntityRepository">The supplierDishImageEntityRepository</param>
        /// <param name="supplierCategoryEntityRepository">The supplierCategoryEntityRepository</param>
        /// <param name="supplierMenuCategoryEntityRepository">The supplierMenuCategoryEntityRepository</param>
        /// <param name="suppTimeTableDisplayEntityRepository">The suppTimeTableDisplayEntityRepository</param>
        /// <param name="supplierFeatureEntityRepository">The supplierFeatureEntityRepository</param>
        /// <param name="supplierDiningPurposeEntityRepository">The supplierDiningPurposeEntityRepository</param>
        /// <param name="timeTableDisplayEntityRepository">The timeTableDisplayEntityRepository</param>
        /// <param name="loginEntityRepository">The loginEntityRepository</param>
        /// <param name="regionEntityRepository">The regionEntityRepository</param>
        /// <param name="supplierDeskTimeEntityRepository">The supplier desk time entity repository.</param>
        /// <param name="deskTypeLockLogEntityRepository">The desk type lock log entity repository.</param>
        /// <param name="deskTypeEntityRepository">The desk type entity repository.</param>
        /// <param name="deskBookingEntityRepository">The deskBookingEntityRepository</param>
        /// <param name="supplierDeskEntityRepository">The supplierDeskEntityRepository</param>
        /// <param name="supplierDetailServices">The supplierDetailServices</param>
        /// 创建者：周超
        /// 创建日期：2013/10/15 18:10
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public SupplierServices(
            INHibernateRepository<SupplierEntity> supplierEntityRepository,
            INHibernateRepository<SupplierImageEntity> supplierImageEntityRepository,
            INHibernateRepository<SupplierCuisineEntity> supplierCuisineEntityRepository,
            INHibernateRepository<SupplierDishEntity> supplierDishEntityRepository,
            INHibernateRepository<SupplierDishImageEntity> supplierDishImageEntityRepository,
            INHibernateRepository<SupplierCategoryEntity> supplierCategoryEntityRepository,
            INHibernateRepository<SupplierMenuCategoryEntity> supplierMenuCategoryEntityRepository,
            INHibernateRepository<SuppTimeTableDisplayEntity> suppTimeTableDisplayEntityRepository,
            INHibernateRepository<SupplierFeatureEntity> supplierFeatureEntityRepository,
            INHibernateRepository<SupplierDiningPurposeEntity> supplierDiningPurposeEntityRepository,
            INHibernateRepository<TimeTableDisplayEntity> timeTableDisplayEntityRepository,
            INHibernateRepository<LoginEntity> loginEntityRepository,
            INHibernateRepository<RegionEntity> regionEntityRepository,
            INHibernateRepository<SupplierDeskTimeEntity> supplierDeskTimeEntityRepository,
            INHibernateRepository<DeskTypeLockLogEntity> deskTypeLockLogEntityRepository,
            INHibernateRepository<DeskTypeEntity> deskTypeEntityRepository,
            INHibernateRepository<DeskBookingEntity> deskBookingEntityRepository,
            INHibernateRepository<SupplierDeskEntity> supplierDeskEntityRepository,
            ISupplierDetailServices supplierDetailServices)
        {
            this.supplierEntityRepository = supplierEntityRepository;
            this.supplierImageEntityRepository = supplierImageEntityRepository;
            this.supplierCuisineEntityRepository = supplierCuisineEntityRepository;
            this.supplierDishEntityRepository = supplierDishEntityRepository;
            this.supplierDishImageEntityRepository = supplierDishImageEntityRepository;
            this.supplierCategoryEntityRepository = supplierCategoryEntityRepository;
            this.supplierMenuCategoryEntityRepository = supplierMenuCategoryEntityRepository;
            this.suppTimeTableDisplayEntityRepository = suppTimeTableDisplayEntityRepository;
            this.supplierFeatureEntityRepository = supplierFeatureEntityRepository;
            this.supplierDiningPurposeEntityRepository = supplierDiningPurposeEntityRepository;
            this.timeTableDisplayEntityRepository = timeTableDisplayEntityRepository;
            this.loginEntityRepository = loginEntityRepository;
            this.regionEntityRepository = regionEntityRepository;
            this.supplierDeskTimeEntityRepository = supplierDeskTimeEntityRepository;
            this.deskTypeLockLogEntityRepository = deskTypeLockLogEntityRepository;
            this.deskTypeEntityRepository = deskTypeEntityRepository;
            this.deskBookingEntityRepository = deskBookingEntityRepository;
            this.supplierDeskEntityRepository = supplierDeskEntityRepository;
            this.supplierDetailServices = supplierDetailServices;
        }

        /// <summary>
        /// 获取餐厅信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="supplierId">餐厅Id</param>
        /// <param name="cityCode">城市Code</param>
        /// <returns>
        /// 返回餐厅信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/19 23:36
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<SupplierDetailModel> GetSupplier(string source, int supplierId, string cityCode = null)
        {
            if (!this.supplierEntityRepository.EntityQueryable.Any(p => p.SupplierId == supplierId))
            {
                return new ServicesResult<SupplierDetailModel>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidSupplierIdCode,
                    Result = new SupplierDetailModel()
                };
            }

            var tempSupplier = (from supplierEntity in this.supplierEntityRepository.EntityQueryable
                                where supplierEntity.SupplierId == supplierId
                                select new
                                {
                                    supplierEntity.SupplierId,
                                    supplierEntity.SupplierName,
                                    supplierEntity.SupplierDescription,
                                    Address = supplierEntity.Address1,
                                    supplierEntity.Averageprice,
                                    supplierEntity.ParkingInfo,
                                    supplierEntity.Telephone,
                                    supplierEntity.SupplierGroupId,
                                    supplierEntity.PackagingFee,
                                    supplierEntity.FixedDeliveryCharge,
                                    supplierEntity.FreeDeliveryLine,
                                    supplierEntity.DelMinOrderAmount,
                                    supplierEntity.BaIduLat,
                                    supplierEntity.BaIduLong,
                                    supplierEntity.TakeawaySpecialOffersSummary,
                                    supplierEntity.PublicTransport,
                                    supplierEntity.PackLadder,
                                    supplierEntity.Fax,
                                    supplierEntity.Email,
                                    supplierEntity.RegionCode
                                }).FirstOrDefault();

            if (tempSupplier == null)
            {
                return new ServicesResult<SupplierDetailModel>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidSupplierIdCode,
                    Result = new SupplierDetailModel()
                };
            }

            decimal baIduLat;
            decimal.TryParse(tempSupplier.BaIduLat, out baIduLat);
            decimal baIduLong;
            decimal.TryParse(tempSupplier.BaIduLong, out baIduLong);

            var supplierFeatureList = this.supplierFeatureEntityRepository.EntityQueryable.Where(
                p => p.Supplier.SupplierId == supplierId && p.IsEnabled == true)
                                          .Select(p => new SupplierFeatureModel
                                          {
                                              SupplierFeatureId = p.SupplierFeatureId,
                                              FeatureName = p.Feature.Feature,
                                              FeatureId = p.Feature.FeatureId
                                          }).ToList();


            var supplier = new SupplierDetailModel
            {
                SupplierId = tempSupplier.SupplierId,
                SupplierName = tempSupplier.SupplierName,
                SupplierDescription = tempSupplier.SupplierDescription,
                ServiceTime = string.Empty,
                Address = tempSupplier.Address,
                Averageprice = tempSupplier.Averageprice,
                ParkingInfo = tempSupplier.ParkingInfo,
                Telephone = tempSupplier.Telephone,
                SupplierGroupId = tempSupplier.SupplierGroupId,
                PackagingFee = tempSupplier.PackagingFee,
                FixedDeliveryCharge = tempSupplier.FixedDeliveryCharge,
                CuisineName = string.Empty,
                FreeDeliveryLine = tempSupplier.FreeDeliveryLine,
                DelMinOrderAmount = tempSupplier.DelMinOrderAmount,
                BaIduLat = baIduLat,
                BaIduLong = baIduLong,
                Email = tempSupplier.Email,
                Fax = tempSupplier.Fax,
                TakeawaySpecialOffersSummary = tempSupplier.TakeawaySpecialOffersSummary,
                PackLadder = tempSupplier.PackLadder,
                PublicTransport = tempSupplier.PublicTransport,
                LogoUrl = string.Format("{0}/{1}", ServicesCommon.ImageSiteUrl,
                                        this.supplierImageEntityRepository.EntityQueryable.Where(
                                            p => p.Supplier.SupplierId == supplierId && p.Online == true)
                                            .Select(p => p.ImagePath)
                                            .FirstOrDefault()),
                SupplierFeatureList = supplierFeatureList,
                RecommendedDishList = new List<SupplierRecommendedDishModel>()
            };

            var cooperationWaimaiList =
                ServicesCommon.CooperationWaimaiFeatures.Select(p => supplierFeatureList.Any(q => q.FeatureId == p))
                              .ToList();
            var cooperationTangshiList =
                ServicesCommon.CooperationTangshiFeatures.Select(p => supplierFeatureList.Any(q => q.FeatureId == p))
                              .ToList();
            if (cooperationWaimaiList.All(p => p) || cooperationTangshiList.All(p => p))
            {
                supplier.Telephone = ServicesCommon.CooperationHotline;
            }

            if (supplier.SupplierGroupId != null &&
                !ServicesCommon.TestSupplierGroupId.Contains(supplier.SupplierGroupId.Value))
            {
                //地区Code前缀=cityCode 
                var startRegionCode = cityCode ?? string.Empty;

                var tempSupplierIdList =
                    this.supplierEntityRepository.EntityQueryable.Where(
                        p =>
                        p.SupplierGroupId == supplier.SupplierGroupId && p.Login.IsEnabled &&
                        p.RegionCode.StartsWith(startRegionCode)).Select(p => p.SupplierId).ToList();
                var tempSupplierFeatureList =
                    this.supplierFeatureEntityRepository.EntityQueryable.Where(
                        p => p.IsEnabled == true && tempSupplierIdList.Contains(p.Supplier.SupplierId))
                        .Select(p => new { p.Supplier.SupplierId, p.Feature.FeatureId })
                        .ToList();

                var supplierIdList = new List<int>();
                foreach (var item in tempSupplierIdList)
                {
                    var list = tempSupplierFeatureList.Where(p => p.SupplierId == item).ToList();
                    var tempCooperationWaimaiList =
                        ServicesCommon.CooperationWaimaiFeatures.Select(p => list.Any(q => q.FeatureId == p)).ToList();
                    var tempCooperationTangshiList =
                        ServicesCommon.CooperationTangshiFeatures.Select(p => list.Any(q => q.FeatureId == p)).ToList();
                    if (tempCooperationWaimaiList.Any(p => !p) && tempCooperationTangshiList.Any(p => !p))
                    {
                        continue;
                    }

                    supplierIdList.Add(item);
                }

                supplier.ChainCount = supplierIdList.Count;
            }

            var tempDiningPurposeList =
                this.supplierDiningPurposeEntityRepository.EntityQueryable.Where(p => p.SupplierId == supplierId)
                    .Select(p => p.DiningPurpose.DiningPurpose)
                    .ToList();

            var diningPurposeList = tempDiningPurposeList.Where(p => !p.IsEmptyOrNull()).ToList();
            supplier.SupplierDiningPurpose = diningPurposeList.Count == 0
                                                 ? string.Empty
                                                 : string.Join(",", diningPurposeList);

            var supplierCuisineList =
                this.supplierCuisineEntityRepository.EntityQueryable.Where(p => p.Supplier.SupplierId == supplierId)
                    .Select(p => new { p.Cuisine.CuisineId, p.Cuisine.CuisineName })
                    .ToList();
            supplier.CuisineName = string.Join(",",
                                               supplierCuisineList.Select(p => p.CuisineName)
                                                                  .Where(p => !p.IsEmptyOrNull())
                                                                  .Distinct()
                                                                  .ToList());

            var suppTimeTableDisplayList = (from entity in this.suppTimeTableDisplayEntityRepository.EntityQueryable
                                            where entity.SupplierId == supplierId
                                            select new
                                            {
                                                entity.Day,
                                                entity.TimeTableDisplayId
                                            }).ToList();

            var day = DateTime.Now.GetDayOfWeek();
            var timeTableDisplayIdList =
                suppTimeTableDisplayList.Where(item => item.Day != null)
                                        .Where(item => day == item.Day.ToString())
                                        .Select(p => p.TimeTableDisplayId)
                                        .ToList();
            if (timeTableDisplayIdList.Count == 0)
            {
                return new ServicesResult<SupplierDetailModel>
                {
                    Result = supplier
                };
            }

            //餐厅推荐菜品列表
            var recommendedDishList = GetRecommendedDish(supplierId);
            if (recommendedDishList.Count == 0)
            {
                return new ServicesResult<SupplierDetailModel>
                {
                    Result = supplier
                };
            }
            supplier.RecommendedDishList = recommendedDishList;

            var timeTableDisplayList = (from entity in this.timeTableDisplayEntityRepository.EntityQueryable
                                        where timeTableDisplayIdList.Contains(entity.TimeTableDisplayId)
                                        select new
                                        {
                                            entity.OpenTime,
                                            entity.CloseTime
                                        }).ToList();

            var serviceTime = timeTableDisplayList.Aggregate(string.Empty,
                                                             (current, timeTableDisplay) =>
                                                             string.Format("{0} {1:t}-{2:t}", current,
                                                                           timeTableDisplay.OpenTime,
                                                                           timeTableDisplay.CloseTime));
            supplier.ServiceTime = serviceTime.Trim();

            return new ServicesResult<SupplierDetailModel>
            {
                Result = supplier
            };
        }

        /// <summary>
        /// 获取餐厅基本信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="supplierId">餐厅Id</param>
        /// <returns>
        /// 返回餐厅信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/19 23:37
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<SupplierSimpleModel> GetSupplierSimple(string source, int supplierId)
        {
            if (!this.supplierEntityRepository.EntityQueryable.Any(p => p.SupplierId == supplierId))
            {
                return new ServicesResult<SupplierSimpleModel>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidSupplierIdCode,
                    Result = new SupplierSimpleModel()
                };
            }

            var tempSupplier = (from supplierEntity in this.supplierEntityRepository.EntityQueryable
                                where supplierEntity.SupplierId == supplierId
                                select new
                                {
                                    supplierEntity.SupplierId,
                                    supplierEntity.SupplierName,
                                    supplierEntity.SupplierDescription,
                                    Address = supplierEntity.Address1,
                                    supplierEntity.Averageprice,
                                    supplierEntity.ParkingInfo,
                                    supplierEntity.Telephone,
                                    supplierEntity.SupplierGroupId,
                                    supplierEntity.PackagingFee,
                                    supplierEntity.FixedDeliveryCharge,
                                    supplierEntity.FreeDeliveryLine,
                                    supplierEntity.DelMinOrderAmount,
                                    supplierEntity.BaIduLat,
                                    supplierEntity.BaIduLong,
                                    supplierEntity.TakeawaySpecialOffersSummary,
                                    supplierEntity.PublicTransport,
                                    supplierEntity.PackLadder,
                                    supplierEntity.Fax,
                                    supplierEntity.Email,
                                    supplierEntity.RegionCode
                                }).FirstOrDefault();

            if (tempSupplier == null)
            {
                return new ServicesResult<SupplierSimpleModel>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidSupplierIdCode,
                    Result = new SupplierSimpleModel()
                };
            }

            decimal baIduLat;
            decimal.TryParse(tempSupplier.BaIduLat, out baIduLat);
            decimal baIduLong;
            decimal.TryParse(tempSupplier.BaIduLong, out baIduLong);

            var supplier = new SupplierSimpleModel
            {
                SupplierId = tempSupplier.SupplierId,
                SupplierName = tempSupplier.SupplierName,
                SupplierDescription = tempSupplier.SupplierDescription,
                Address = tempSupplier.Address,
                Averageprice = tempSupplier.Averageprice,
                Telephone = tempSupplier.Telephone,
                SupplierGroupId = tempSupplier.SupplierGroupId,
                PackagingFee = tempSupplier.PackagingFee,
                FixedDeliveryCharge = tempSupplier.FixedDeliveryCharge,
                FreeDeliveryLine = tempSupplier.FreeDeliveryLine,
                DelMinOrderAmount = tempSupplier.DelMinOrderAmount,
                BaIduLat = baIduLat,
                BaIduLong = baIduLong
            };

            return new ServicesResult<SupplierSimpleModel>
            {
                Result = supplier
            };
        }

        /// <summary>
        /// 根据餐厅域名获取餐厅信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="supplierDomain">餐厅域名</param>
        /// <returns>
        /// 返回餐厅信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/19 23:37
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<RoughSupplierModel> GetRoughSupplier(string source, string supplierDomain)
        {
            if (supplierDomain.IsEmptyOrNull())
            {
                return new ServicesResult<RoughSupplierModel>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidSupplierDomainCode,
                    Result = new RoughSupplierModel()
                };
            }

            var loginEntity = this.loginEntityRepository.EntityQueryable.Where(p => p.Username == supplierDomain)
                                  .Select(p => new { p.LoginId, p.IsEnabled })
                                  .FirstOrDefault();

            if (loginEntity == null)
            {
                return new ServicesResult<RoughSupplierModel>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidSupplierDomainCode,
                    Result = new RoughSupplierModel()
                };
            }

            if (!loginEntity.IsEnabled)
            {
                return new ServicesResult<RoughSupplierModel>
                {
                    StatusCode = (int)StatusCode.General.ErrorPermission,
                    Result = new RoughSupplierModel()
                };
            }

            var roughSupplierModel = (from supplierEntity in this.supplierEntityRepository.EntityQueryable
                                      where supplierEntity.Login.LoginId == loginEntity.LoginId
                                      select new RoughSupplierModel
                                      {
                                          SupplierId = supplierEntity.SupplierId,
                                          SupplierName = supplierEntity.SupplierName,
                                          SupplierDescription = supplierEntity.SupplierDescription,
                                          Address = supplierEntity.Address1,
                                          Telephone = supplierEntity.Telephone
                                      }).FirstOrDefault();

            if (roughSupplierModel == null)
            {
                return new ServicesResult<RoughSupplierModel>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidSupplierIdCode,
                    Result = new RoughSupplierModel()
                };
            }

            var supplierFeatureList = this.supplierFeatureEntityRepository.EntityQueryable.Where(
                p => p.Supplier.SupplierId == roughSupplierModel.SupplierId && p.IsEnabled == true)
                                          .Select(p => new SupplierFeatureModel
                                          {
                                              SupplierFeatureId = p.SupplierFeatureId,
                                              FeatureName = p.Feature.Feature,
                                              FeatureId = p.Feature.FeatureId
                                          }).ToList();

            roughSupplierModel.SupplierFeatureList = supplierFeatureList;

            var cooperationWaimaiList =
                ServicesCommon.CooperationWaimaiFeatures.Select(p => supplierFeatureList.Any(q => q.FeatureId == p))
                              .ToList();
            var cooperationTangshiList =
                ServicesCommon.CooperationTangshiFeatures.Select(p => supplierFeatureList.Any(q => q.FeatureId == p))
                              .ToList();
            if (cooperationWaimaiList.All(p => p) || cooperationTangshiList.All(p => p))
            {
                roughSupplierModel.Telephone = ServicesCommon.CooperationHotline;
            }

            return new ServicesResult<RoughSupplierModel>
            {
                Result = roughSupplierModel
            };
        }

        /// <summary>
        /// 取得打包费
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="supplierId">餐厅Id</param>
        /// <param name="dishList">菜品信息</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/20/2013 12:02 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<decimal> GetPackagingFee(string source, int supplierId, List<PackagingFeeItem> dishList)
        {
            if (dishList == null || dishList.Count == 0)
            {
                return new ServicesResult<decimal>
                {
                    StatusCode = (int)StatusCode.System.InvalidRequest
                };
            }

            var supplier = this.supplierEntityRepository.EntityQueryable.Where(p => p.SupplierId == supplierId)
                               .Select(p => new { p.SupplierId, p.PackLadder, p.PackagingFee })
                               .FirstOrDefault();

            if (supplier == null)
            {
                return new ServicesResult<decimal>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidSupplierIdCode
                };
            }

            var packageWay =
                this.supplierFeatureEntityRepository.EntityQueryable.Any(
                    p => p.Feature.FeatureId == ServicesCommon.PackageFeatureId && p.IsEnabled == true);
            var packagingFee = ServicesCommon.GetPackagingFee(packageWay, supplier.PackagingFee ?? 0,
                                                              supplier.PackLadder ?? 0, dishList);
            return new ServicesResult<decimal>
            {
                Result = packagingFee
            };
        }

        /// <summary>
        /// 获取餐厅列表
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="parameter">The parameter</param>
        /// <returns>
        /// 返回餐厅列表
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/15 17:56
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResultList<SupplierModel> GetSupplierList(string source, GetSupplierListParameter parameter)
        {
            if (parameter == null)
            {
                return new ServicesResultList<SupplierModel>
                {
                    Result = new List<SupplierModel>(),
                    StatusCode = (int)StatusCode.System.InvalidRequest
                };
            }

            var list =
                this.supplierEntityRepository.NamedQuery(string.Format("Pro_QuerySupplierList{0}",
                                                                       (OrderBy.Supplier)parameter.OrderByType))
                    .SetInt32("FeatureID", parameter.FeatureId)
                    .SetInt32("CuisineID", parameter.CuisineId)
                    .SetInt32("RegionId", parameter.RegionId)
                    .SetString("BusinessAreaId", parameter.BusinessAreaId)
                    .SetDouble("UserLat", parameter.UserLat)
                    .SetDouble("UserLong", parameter.UserLong)
                    .SetDouble("Distance", !parameter.Distance.HasValue ? -1.0 : parameter.Distance.Value)
                    .SetInt32("PageIndex", !parameter.PageIndex.HasValue ? -1 : parameter.PageIndex.Value)
                    .SetInt32("PageSize", parameter.PageSize)
                    .SetString("SupplierGroupIdList", string.Join(",", ServicesCommon.RetentionSupplierGroupIdList))
                    .SetString("SupplierIdList", string.Join(",", ServicesCommon.FilteredSupplierIdList))
                    .List<SupplierModelEntity>();

            var result = (from entity in list
                          select new SupplierModel
                          {
                              SupplierId = entity.SupplierId,
                              SupplierName = entity.SupplierName,
                              Address = entity.Address,
                              Telephone = entity.Telephone,
                              BaIduLat = entity.BaIduLat,
                              BaIduLong = entity.BaIduLong,
                              SupplierDescription = entity.SupplierDescription,
                              Averageprice = entity.Averageprice,
                              ParkingInfo = entity.ParkingInfo,
                              CuisineName = entity.CuisineName,
                              LogoUrl = string.Format("{0}/{1}", ServicesCommon.ImageSiteUrl, entity.LogoUrl),
                              IsOpenDoor = entity.IsOpenDoor,
                              Distance = entity.Distance,
                              DateJoined = entity.DateJoined,
                              SupplierGroupId = entity.SupplierGroupId
                          }).ToList();

            var supplierIdList = result.Select(p => p.SupplierId).ToList();
            var supplierFeatureList = this.supplierFeatureEntityRepository.EntityQueryable.Where(
                p => supplierIdList.Contains(p.Supplier.SupplierId) && p.IsEnabled == true)
                                          .Select(
                                              p =>
                                              new
                                              {
                                                  p.SupplierFeatureId,
                                                  p.Supplier.SupplierId,
                                                  p.Feature.Feature,
                                                  p.Feature.FeatureId
                                              })
                                          .ToList();

            foreach (var item in result)
            {
                item.SupplierFeatureList = supplierFeatureList.Where(p => p.SupplierId == item.SupplierId)
                                                              .Select(p => new SupplierFeatureModel
                                                              {
                                                                  FeatureId = p.FeatureId,
                                                                  FeatureName = p.Feature,
                                                                  SupplierFeatureId = p.SupplierFeatureId
                                                              }).ToList();
            }

            return new ServicesResultList<SupplierModel>
            {
                Result = result
            };
        }

        /// <summary>
        /// 获取餐厅列表
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="parameter">The parameter</param>
        /// <returns>
        /// 返回餐厅列表
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/15 17:56
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResultList<SupplierModel> GetSearchSupplierList(string source,
                                                                       GetSearchSupplierListParameter parameter)
        {
            if (parameter == null)
            {
                return new ServicesResultList<SupplierModel>
                {
                    Result = new List<SupplierModel>(),
                    StatusCode = (int)StatusCode.System.InvalidRequest
                };
            }

            var list =
                this.supplierEntityRepository.NamedQuery(string.Format("Pro_QuerySupplierList{0}",
                                                                       OrderBy.Supplier.SearchDefault))
                    .SetString("SupplierName", parameter.SupplierName.IsEmptyOrNull() ? "%" : parameter.SupplierName)
                    .SetInt32("RegionId", parameter.RegionId)
                    .SetDouble("UserLat", parameter.UserLat)
                    .SetDouble("UserLong", parameter.UserLong)
                    .SetDouble("Distance", !parameter.Distance.HasValue ? -1.0 : parameter.Distance.Value)
                    .SetInt32("PageIndex", !parameter.PageIndex.HasValue ? -1 : parameter.PageIndex.Value)
                    .SetInt32("PageSize", parameter.PageSize)
                    .SetDouble("BuildingLat", parameter.BuildingLat)
                    .SetDouble("BuildingLong", parameter.BuildingLong)
                    .SetString("FeatureIdList", string.Join(",", ServicesCommon.SupplierFeatures))
                    .SetString("SupplierGroupIdList", string.Join(",", ServicesCommon.RetentionSupplierGroupIdList))
                    .SetString("SupplierIdList", string.Join(",", ServicesCommon.FilteredSupplierIdList))
                    .List<SupplierModelEntity>();

            var result = (from entity in list
                          select new SupplierModel
                          {
                              SupplierId = entity.SupplierId,
                              SupplierName = entity.SupplierName,
                              Address = entity.Address,
                              Telephone = entity.Telephone,
                              BaIduLat = entity.BaIduLat,
                              BaIduLong = entity.BaIduLong,
                              SupplierDescription = entity.SupplierDescription,
                              Averageprice = entity.Averageprice,
                              ParkingInfo = entity.ParkingInfo,
                              CuisineName = entity.CuisineName,
                              LogoUrl = string.Format("{0}/{1}", ServicesCommon.ImageSiteUrl, entity.LogoUrl),
                              IsOpenDoor = entity.IsOpenDoor,
                              Distance = entity.Distance,
                              DateJoined = entity.DateJoined,
                              SupplierGroupId = entity.SupplierGroupId
                          }).ToList();

            var supplierIdList = result.Select(p => p.SupplierId).ToList();
            var supplierFeatureList = this.supplierFeatureEntityRepository.EntityQueryable.Where(
                p => supplierIdList.Contains(p.Supplier.SupplierId) && p.IsEnabled == true)
                                          .Select(
                                              p =>
                                              new
                                              {
                                                  p.SupplierFeatureId,
                                                  p.Supplier.SupplierId,
                                                  p.Feature.Feature,
                                                  p.Feature.FeatureId
                                              })
                                          .ToList();

            foreach (var item in result)
            {
                item.SupplierFeatureList = supplierFeatureList.Where(p => p.SupplierId == item.SupplierId)
                                                              .Select(p => new SupplierFeatureModel
                                                              {
                                                                  FeatureId = p.FeatureId,
                                                                  FeatureName = p.Feature,
                                                                  SupplierFeatureId = p.SupplierFeatureId
                                                              }).ToList();
            }

            return new ServicesResultList<SupplierModel>
            {
                Result = result
            };
        }

        /// <summary>
        /// 获取餐厅分店列表
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="parameter">The parameter</param>
        /// <returns>
        /// 返回餐厅分店列表
        /// </returns>
        /// 创建者：周超
        /// 创建日期：10/22/2013 11:38 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResultList<GroupSupplierModel> GetGroupSupplierList(string source,
                                                                           GetGroupSupplierListParameter parameter)
        {
            if (parameter == null)
            {
                return new ServicesResultList<GroupSupplierModel>
                {
                    Result = new List<GroupSupplierModel>(),
                    StatusCode = (int)StatusCode.System.InvalidRequest
                };
            }

            if (ServicesCommon.TestSupplierGroupId.Contains(parameter.SupplierGroupId))
            {
                return new ServicesResultList<GroupSupplierModel>
                {
                    Result = new List<GroupSupplierModel>()
                };
            }

            var tempQueryable =
                this.supplierEntityRepository.EntityQueryable.Where(
                    p => p.SupplierGroupId == parameter.SupplierGroupId && p.Login.IsEnabled);
            if (parameter.CityId != null)
            {
                var regionEntity = this.regionEntityRepository.FindSingleByExpression(p => p.Id == parameter.CityId);
                if (regionEntity != null)
                {
                    tempQueryable = tempQueryable.Where(p => p.RegionCode.StartsWith(regionEntity.Code));
                }
            }

            if (parameter.FeatureId != null)
            {
                tempQueryable =
                    tempQueryable.Where(q => q.SupplierFeatureList.Any(p => p.Feature.FeatureId == parameter.FeatureId));
            }

            if (ServicesCommon.SupplierFeatures.Count > 0)
            {
                var supplierFeatures = ServicesCommon.SupplierFeatures.Select(p => (int?)p).ToList();
                tempQueryable =
                    tempQueryable.Where(
                        q => q.SupplierFeatureList.Any(p => supplierFeatures.Any(t => t == p.Feature.FeatureId)));
            }

            var queryable = tempQueryable.Select(supplierEntity =>
                                                 new
                                                 {
                                                     supplierEntity.SupplierId,
                                                     supplierEntity.SupplierName,
                                                     supplierEntity.SupplierDescription,
                                                     Address = supplierEntity.Address1,
                                                     supplierEntity.Averageprice,
                                                     supplierEntity.ParkingInfo,
                                                     supplierEntity.Telephone,
                                                     supplierEntity.SupplierGroupId,
                                                     supplierEntity.DateJoined,
                                                     supplierEntity.IsOpenDoor,
                                                     supplierEntity.DefaultCuisineId,
                                                     supplierEntity.BaIduLat,
                                                     supplierEntity.BaIduLong
                                                 });

            var tempSupplierList = parameter.PageIndex == null
                                       ? queryable.ToList()
                                       : queryable.Skip((parameter.PageIndex.Value - 1) * parameter.PageSize)
                                                  .Take(parameter.PageSize)
                                                  .ToList();
            if (tempSupplierList.Count == 0)
            {
                return new ServicesResultList<GroupSupplierModel>
                {
                    StatusCode = (int)StatusCode.Succeed.Empty,
                    Result = new List<GroupSupplierModel>()
                };
            }

            var supplierIdList = tempSupplierList.Select(p => p.SupplierId).ToList();
            var supplierImageList = this.supplierImageEntityRepository.EntityQueryable.Where(
                p => supplierIdList.Contains(p.Supplier.SupplierId) && p.Online == true)
                                        .Select(p => new
                                        {
                                            p.Supplier.SupplierId,
                                            p.ImagePath
                                        }).ToList();

            var supplierFeatureList = this.supplierFeatureEntityRepository.EntityQueryable.Where(
                p => supplierIdList.Contains(p.Supplier.SupplierId) && p.IsEnabled == true)
                                          .Select(
                                              p =>
                                              new
                                              {
                                                  p.SupplierFeatureId,
                                                  p.Supplier.SupplierId,
                                                  p.Feature.Feature,
                                                  p.Feature.FeatureId
                                              })
                                          .ToList();

            var groupSupplierList = tempSupplierList.Select(item => new GroupSupplierModel
            {
                SupplierId = item.SupplierId,
                SupplierName = item.SupplierName,
                Address = item.Address,
                Telephone = item.Telephone,
                Averageprice = item.Averageprice,
                BaIduLat = item.BaIduLat,
                BaIduLong = item.BaIduLong,
                ParkingInfo = item.ParkingInfo,
                CuisineId = item.DefaultCuisineId,
                DateJoined = item.DateJoined,
                IsOpenDoor = item.IsOpenDoor,
                SupplierDescription = item.SupplierDescription,
                LogoUrl =
                    string.Format("{0}/{1}", ServicesCommon.ImageSiteUrl,
                                  (supplierImageList.FirstOrDefault(p => p.SupplierId == item.SupplierId) ??
                                   new { item.SupplierId, ImagePath = string.Empty }).ImagePath),
                SupplierFeatureList =
                    supplierFeatureList.Where(p => p.SupplierId == item.SupplierId)
                                       .Select(
                                           p =>
                                           new SupplierFeatureModel
                                           {
                                               FeatureId = p.FeatureId,
                                               FeatureName = p.Feature,
                                               SupplierFeatureId = p.SupplierFeatureId
                                           })
                                       .ToList()
            }).ToList();

            return new ServicesResultList<GroupSupplierModel>
            {
                ResultTotalCount = groupSupplierList.Count,
                Result = groupSupplierList
            };
        }

        /// <summary>
        /// Gets the search group supplier list.
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="parameter">The parameter</param>
        /// <returns>
        /// ServicesResultList{GroupSupplierModel}
        /// </returns>
        /// 创建者：周超
        /// 创建日期：12/29/2013 10:33 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResultList<GroupSupplierModel> GetSearchGroupSupplierList(string source,
                                                                                 GetSearchGroupSupplierListParameter
                                                                                     parameter)
        {
            if (parameter == null)
            {
                return new ServicesResultList<GroupSupplierModel>
                {
                    Result = new List<GroupSupplierModel>(),
                    StatusCode = (int)StatusCode.System.InvalidRequest
                };
            }

            var list = this.supplierEntityRepository.NamedQuery("Pro_QuerySearchGroupSupplierList")
                           .SetInt32("FeatureId", parameter.FeatureId ?? -1)
                           .SetInt32("SupplierGroupId", parameter.SupplierGroupId ?? -1)
                           .SetInt32("CityId", parameter.CityId ?? -1)
                           .SetDouble("UserLat", parameter.UserLat)
                           .SetDouble("UserLong", parameter.UserLong)
                           .SetInt32("PageIndex", parameter.PageIndex ?? -1)
                           .SetInt32("PageSize", parameter.PageSize)
                           .SetString("FeatureIdList", string.Join(",", ServicesCommon.SupplierFeatures))
                           .SetString("SupplierIdList", string.Join(",", ServicesCommon.FilteredSupplierIdList))
                           .List<GroupSupplierModelEntity>();

            var supplierList = (from entity in list
                                select new GroupSupplierModel
                                {
                                    SupplierId = entity.SupplierId,
                                    SupplierName = entity.SupplierName,
                                    Address = entity.Address,
                                    Telephone = entity.Telephone,
                                    BaIduLat = entity.BaIduLat,
                                    BaIduLong = entity.BaIduLong,
                                    SupplierDescription = entity.SupplierDescription,
                                    Averageprice = entity.Averageprice,
                                    ParkingInfo = entity.ParkingInfo,
                                    LogoUrl = string.Format("{0}/{1}", ServicesCommon.ImageSiteUrl, entity.LogoUrl),
                                    IsOpenDoor = entity.IsOpenDoor,
                                    Distance = entity.Distance,
                                    DateJoined = entity.DateJoined,
                                }).ToList();

            var supplierIdList = supplierList.Select(p => p.SupplierId).ToList();
            var supplierFeatureList =
                this.supplierFeatureEntityRepository.EntityQueryable.Where(
                    p => supplierIdList.Contains(p.Supplier.SupplierId) && p.IsEnabled == true)
                    .Select(
                        p => new { p.SupplierFeatureId, p.Supplier.SupplierId, p.Feature.Feature, p.Feature.FeatureId })
                    .ToList();

            foreach (var supplier in supplierList)
            {
                supplier.SupplierFeatureList = supplierFeatureList.Where(p => p.SupplierId == supplier.SupplierId)
                                                                  .Select(p =>
                                                                          new SupplierFeatureModel
                                                                          {
                                                                              FeatureId = p.FeatureId,
                                                                              FeatureName = p.Feature,
                                                                              SupplierFeatureId =
                                                                                  p.SupplierFeatureId
                                                                          }).ToList();
            }
            return new ServicesResultList<GroupSupplierModel>
            {
                Result = supplierList
            };
        }

        /// <summary>
        /// 获取餐厅已经开通的功能列表
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="supplierId">餐厅Id</param>
        /// <returns>
        /// 返回餐厅已经开通的功能列表
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/15 13:13
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResultList<SupplierFeatureModel> GetSupplierFeatureList(string source, int supplierId)
        {
            if (!this.supplierEntityRepository.EntityQueryable.Any(p => p.SupplierId == supplierId))
            {
                return new ServicesResultList<SupplierFeatureModel>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidSupplierIdCode,
                    Result = new List<SupplierFeatureModel>()
                };
            }

            var supplierFeatureList = this.supplierFeatureEntityRepository.EntityQueryable.Where(
                p => p.Supplier.SupplierId == supplierId && p.IsEnabled == true)
                                          .Select(p => new SupplierFeatureModel
                                          {
                                              SupplierFeatureId = p.SupplierFeatureId,
                                              FeatureName = p.Feature.Feature,
                                              FeatureId = p.Feature.FeatureId
                                          })
                                          .ToList();

            if (supplierFeatureList.Count == 0)
            {
                return new ServicesResultList<SupplierFeatureModel>
                {
                    StatusCode = (int)StatusCode.Succeed.Empty,
                    ResultTotalCount = supplierFeatureList.Count,
                    Result = supplierFeatureList
                };
            }

            return new ServicesResultList<SupplierFeatureModel>
            {
                ResultTotalCount = supplierFeatureList.Count,
                Result = supplierFeatureList
            };
        }

        /// <summary>
        /// 获取餐厅菜单信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="supplierId">餐厅Id</param>
        /// <param name="supplierMenuCategoryTypeId">餐厅菜单类型</param>
        /// <returns>
        /// 返回餐厅菜单信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/15 13:13
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResultList<SupplierCuisineModel> GetMenu(string source, int supplierId,
                                                                int supplierMenuCategoryTypeId)
        {
            if (!this.supplierEntityRepository.EntityQueryable.Any(p => p.SupplierId == supplierId))
            {
                return new ServicesResultList<SupplierCuisineModel>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidSupplierIdCode,
                    Result = new List<SupplierCuisineModel>()
                };
            }

            var supplierMenuCategoryId =
                this.supplierMenuCategoryEntityRepository.EntityQueryable.Where(
                    p =>
                    p.SupplierId == supplierId &&
                    p.SupplierMenuCategoryType.SupplierMenuCategoryTypeId == supplierMenuCategoryTypeId)
                    .Select(p => p.SupplierMenuCategoryId)
                    .FirstOrDefault();
            var tempSupplierCategoryList =
                (from supplierCategoryEntity in this.supplierCategoryEntityRepository.EntityQueryable
                 where
                     supplierCategoryEntity.SupplierId == supplierId &&
                     supplierCategoryEntity.SupplierMenuCategoryId == supplierMenuCategoryId
                 select new
                 {
                     supplierCategoryEntity.Category,
                     supplierCategoryEntity.SupplierId,
                     supplierCategoryEntity.SupplierCategoryId
                 }).ToList();

            if (tempSupplierCategoryList.Count == 0)
            {
                return new ServicesResultList<SupplierCuisineModel>
                {
                    Result = new List<SupplierCuisineModel>()
                };
            }

            var supplierCategoryList = (from entity in tempSupplierCategoryList
                                        where entity.Category != null
                                        select new
                                        {
                                            entity.Category.CategoryId,
                                            entity.Category.CategoryName,
                                            entity.Category.CategoryNo,
                                            entity.SupplierId,
                                            entity.SupplierCategoryId
                                        }).OrderBy(p => p.CategoryNo).ToList();

            var categoryIdList = supplierCategoryList.Select(p => p.CategoryId).Distinct().Cast<int?>().ToList();
            var supplierDishList = (from supplierDishEntity in this.supplierDishEntityRepository.EntityQueryable
                                    where supplierDishEntity.Supplier.SupplierId == supplierId
                                          && supplierDishEntity.Online && supplierDishEntity.IsDel == false
                                          && categoryIdList.Contains(supplierDishEntity.SupplierCategoryId)
                                    select new
                                    {
                                        supplierDishEntity.SupplierCategoryId,
                                        supplierDishEntity.DishNo,
                                        supplierDishEntity.Price,
                                        supplierDishEntity.SupplierDishId,
                                        supplierDishEntity.SupplierDishName,
                                        supplierDishEntity.SuppllierDishDescription,
                                        supplierDishEntity.SpicyLevel,
                                        supplierDishEntity.AverageRating,
                                        supplierDishEntity.IsCommission,
                                        supplierDishEntity.IsDiscount,
                                        supplierDishEntity.Recipe,
                                        supplierDishEntity.Recommended,
                                        supplierDishEntity.PackagingFee,
                                        SupplierId =
                                    supplierDishEntity.Supplier == null ? 0 : supplierDishEntity.Supplier.SupplierId,
                                        ImagePath = string.Empty
                                    }).OrderBy(p => p.DishNo).ToList();

            var supplierDishIdList = supplierDishList.Select(p => p.SupplierDishId).ToList();
            var supplierDishImageList = (from entity in this.supplierDishImageEntityRepository.EntityQueryable
                                         where
                                             supplierDishIdList.Contains(entity.SupplierDishId) && entity.Online == true
                                         select new { entity.SupplierDishId, entity.ImagePath }).ToList();



            var list = new List<SupplierCuisineModel>();
            foreach (var supplierCategory in supplierCategoryList)
            {
                var categoryId = supplierCategory.CategoryId;
                if (list.Exists(p => p.CategoryId == categoryId))
                {
                    continue;
                }

                var dishList =
                    (from supplierDishEntity in supplierDishList.Where(p => p.SupplierCategoryId == categoryId)
                     let supplierDishImage =
                         supplierDishImageList.FirstOrDefault(p => p.SupplierDishId == supplierDishEntity.SupplierDishId)
                     select new SupplierDishModel
                     {
                         Price = supplierDishEntity.Price,
                         ImagePath =
                             string.Format("{0}/{1}", ServicesCommon.ImageSiteUrl,
                                           supplierDishImage == null ? string.Empty : supplierDishImage.ImagePath),
                         SupplierDishId = supplierDishEntity.SupplierDishId,
                         SupplierDishName = supplierDishEntity.SupplierDishName,
                         SuppllierDishDescription = supplierDishEntity.SuppllierDishDescription,
                         AverageRating = supplierDishEntity.AverageRating,
                         IsCommission = supplierDishEntity.IsCommission,
                         IsDiscount = supplierDishEntity.IsDiscount,
                         Recipe = supplierDishEntity.Recipe,
                         Recommended = supplierDishEntity.Recommended,
                         PackagingFee = supplierDishEntity.PackagingFee
                     }).ToList();

                list.Add(new SupplierCuisineModel
                {
                    CategoryId = supplierCategory.CategoryId,
                    CategoryName = supplierCategory.CategoryName,
                    SupplierDishList = dishList
                });
            }

            return new ServicesResultList<SupplierCuisineModel>
            {
                ResultTotalCount = list.Count,
                Result = list
            };
        }

        /// <summary>
        /// 取得赠品菜
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="supplierId">餐厅Id</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：12/18/2013 11:59 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResultList<SupplierDishModel> GetPresentDishList(string source, int supplierId)
        {
            var categoryIdList = this.supplierCategoryEntityRepository.EntityQueryable.Where(
                p => p.Category.CategoryName == ServicesCommon.PresentMenu && p.SupplierId == supplierId)
                                     .Select(p => p.Category.CategoryId)
                                     .ToList().Cast<int?>().ToList();

            if (categoryIdList.Count == 0)
            {
                return new ServicesResultList<SupplierDishModel>
                {
                    Result = new List<SupplierDishModel>()
                };
            }

            var supplierDishList = (from supplierDishEntity in this.supplierDishEntityRepository.EntityQueryable
                                    where supplierDishEntity.Supplier.SupplierId == supplierId
                                          && supplierDishEntity.Online && supplierDishEntity.IsDel == false
                                          && categoryIdList.Contains(supplierDishEntity.SupplierCategoryId)
                                    select new
                                    {
                                        supplierDishEntity.SupplierCategoryId,
                                        supplierDishEntity.DishNo,
                                        supplierDishEntity.Price,
                                        supplierDishEntity.SupplierDishId,
                                        supplierDishEntity.SupplierDishName,
                                        supplierDishEntity.SuppllierDishDescription,
                                        supplierDishEntity.SpicyLevel,
                                        supplierDishEntity.AverageRating,
                                        supplierDishEntity.IsCommission,
                                        supplierDishEntity.IsDiscount,
                                        supplierDishEntity.Recipe,
                                        supplierDishEntity.Recommended,
                                        supplierDishEntity.PackagingFee,
                                        SupplierId =
                                    supplierDishEntity.Supplier == null ? 0 : supplierDishEntity.Supplier.SupplierId,
                                        ImagePath = string.Empty
                                    }).OrderBy(p => p.DishNo).ToList();

            var supplierDishIdList = supplierDishList.Select(p => p.SupplierDishId).ToList();
            var supplierDishImageList = (from entity in this.supplierDishImageEntityRepository.EntityQueryable
                                         where
                                             supplierDishIdList.Contains(entity.SupplierDishId) && entity.Online == true
                                         select new { entity.SupplierDishId, entity.ImagePath }).ToList();

            var dishList = (from supplierDishEntity in supplierDishList
                            let supplierDishImage =
                                supplierDishImageList.FirstOrDefault(
                                    p => p.SupplierDishId == supplierDishEntity.SupplierDishId)
                            select new SupplierDishModel
                            {
                                Price = supplierDishEntity.Price,
                                ImagePath =
                                    string.Format("{0}/{1}", ServicesCommon.ImageSiteUrl,
                                                  supplierDishImage == null
                                                      ? string.Empty
                                                      : supplierDishImage.ImagePath),
                                SupplierDishId = supplierDishEntity.SupplierDishId,
                                SupplierDishName = supplierDishEntity.SupplierDishName,
                                SuppllierDishDescription = supplierDishEntity.SuppllierDishDescription,
                                AverageRating = supplierDishEntity.AverageRating,
                                IsCommission = supplierDishEntity.IsCommission,
                                IsDiscount = supplierDishEntity.IsDiscount,
                                Recipe = supplierDishEntity.Recipe,
                                Recommended = supplierDishEntity.Recommended,
                                PackagingFee = supplierDishEntity.PackagingFee
                            }).ToList();

            return new ServicesResultList<SupplierDishModel>
            {
                Result = dishList
            };
        }

        /// <summary>
        /// 获取餐厅菜品类型信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="supplierId">餐厅Id</param>
        /// <param name="supplierMenuCategoryTypeId">餐厅菜单类型</param>
        /// <returns>
        /// 返回餐厅菜品类型信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/15 13:13
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResultList<SupplierCuisineDetailModel> GetSupplierCuisineList(string source, int supplierId,
                                                                                     int supplierMenuCategoryTypeId)
        {
            if (!this.supplierEntityRepository.EntityQueryable.Any(p => p.SupplierId == supplierId))
            {
                return new ServicesResultList<SupplierCuisineDetailModel>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidSupplierIdCode,
                    Result = new List<SupplierCuisineDetailModel>()
                };
            }

            var supplierMenuCategoryId =
                this.supplierMenuCategoryEntityRepository.EntityQueryable.Where(
                    p =>
                    p.SupplierId == supplierId &&
                    p.SupplierMenuCategoryType.SupplierMenuCategoryTypeId == supplierMenuCategoryTypeId)
                    .Select(p => p.SupplierMenuCategoryId)
                    .FirstOrDefault();
            var tempSupplierCategoryList =
                (from supplierCategoryEntity in this.supplierCategoryEntityRepository.EntityQueryable
                 where
                     supplierCategoryEntity.SupplierId == supplierId &&
                     supplierCategoryEntity.SupplierMenuCategoryId == supplierMenuCategoryId
                 select new
                 {
                     supplierCategoryEntity.Category,
                     supplierCategoryEntity.SupplierId,
                     supplierCategoryEntity.SupplierCategoryId
                 }).ToList();

            var supplierCategoryList = (from entity in tempSupplierCategoryList
                                        where entity.Category != null
                                        select new SupplierCuisineDetailModel
                                        {
                                            CategoryId = entity.Category.CategoryId,
                                            CategoryName = entity.Category.CategoryName,
                                            CategoryNo = entity.Category.CategoryNo,
                                            SupplierCategoryId = entity.SupplierCategoryId,
                                            CategoryDescription = entity.Category.CategoryDescription
                                        }).OrderBy(p => p.CategoryNo).ToList();

            return new ServicesResultList<SupplierCuisineDetailModel>
            {
                ResultTotalCount = supplierCategoryList.Count,
                Result = supplierCategoryList
            };
        }

        /// <summary>
        /// 获取餐厅菜品类型信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="supplierId">餐厅Id</param>
        /// <param name="supplierCategoryId">The supplierCategoryId</param>
        /// <returns>
        /// 返回餐厅菜品类型信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/15 13:13
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<SupplierCuisineDetailModel> GetSupplierCuisine(string source, int supplierId,
                                                                             int supplierCategoryId)
        {
            if (!this.supplierEntityRepository.EntityQueryable.Any(p => p.SupplierId == supplierId))
            {
                return new ServicesResult<SupplierCuisineDetailModel>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidSupplierIdCode,
                    Result = new SupplierCuisineDetailModel()
                };
            }

            var tempSupplierCategory =
                (from supplierCategoryEntity in this.supplierCategoryEntityRepository.EntityQueryable
                 where
                     supplierCategoryEntity.SupplierCategoryId == supplierCategoryId &&
                     supplierCategoryEntity.SupplierId == supplierId
                 select new
                 {
                     supplierCategoryEntity.Category,
                     supplierCategoryEntity.SupplierId,
                     supplierCategoryEntity.SupplierCategoryId
                 }).FirstOrDefault();

            if (tempSupplierCategory == null || tempSupplierCategory.Category == null)
            {
                return new ServicesResult<SupplierCuisineDetailModel>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidSupplierCategoryIdCode,
                    Result = new SupplierCuisineDetailModel()
                };
            }

            var supplierCategory = new SupplierCuisineDetailModel
            {
                CategoryId = tempSupplierCategory.Category.CategoryId,
                CategoryName = tempSupplierCategory.Category.CategoryName,
                CategoryNo = tempSupplierCategory.Category.CategoryNo,
                SupplierCategoryId = tempSupplierCategory.SupplierCategoryId,
                CategoryDescription = tempSupplierCategory.Category.CategoryDescription
            };

            return new ServicesResult<SupplierCuisineDetailModel>
            {
                Result = supplierCategory
            };
        }

        /// <summary>
        /// 添加餐厅菜品信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="parameter">The parameter</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/1/2013 4:43 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<bool> AddSupplierCuisine(string source, SaveSupplierCuisineParameter parameter)
        {
            if (parameter == null)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = (int)StatusCode.System.InvalidRequest
                };
            }

            if (!this.supplierEntityRepository.EntityQueryable.Any(p => p.SupplierId == parameter.SupplierId))
            {
                return new ServicesResult<bool>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidSupplierIdCode
                };
            }

            if (
                !this.supplierMenuCategoryEntityRepository.EntityQueryable.Any(
                    p => p.SupplierMenuCategoryType.SupplierMenuCategoryTypeId == parameter.SupplierMenuCategoryTypeId))
            {
                return new ServicesResult<bool>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidSupplierMenuCategoryTypeIdCode
                };
            }

            var result = this.supplierDetailServices.AddSupplierCuisine(parameter);
            return new ServicesResult<bool>
            {
                StatusCode = result.StatusCode,
                Result = result.Result
            };
        }

        /// <summary>
        /// 更新菜品信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="parameter">The parameter</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/3/2013 10:32 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<bool> UpdateSupplierCuisine(string source, SaveSupplierCuisineParameter parameter)
        {
            if (parameter == null)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = (int)StatusCode.System.InvalidRequest
                };
            }

            if (!this.supplierEntityRepository.EntityQueryable.Any(p => p.SupplierId == parameter.SupplierId))
            {
                return new ServicesResult<bool>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidSupplierIdCode
                };
            }

            if (
                !this.supplierMenuCategoryEntityRepository.EntityQueryable.Any(
                    p => p.SupplierMenuCategoryType.SupplierMenuCategoryTypeId == parameter.SupplierMenuCategoryTypeId))
            {
                return new ServicesResult<bool>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidSupplierMenuCategoryTypeIdCode
                };
            }

            var result = this.supplierDetailServices.UpdateSupplierCuisine(parameter);
            return new ServicesResult<bool>
            {
                StatusCode = result.StatusCode,
                Result = result.Result
            };
        }

        /// <summary>
        /// 删除菜品信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="parameter">The parameter</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/3/2013 10:32 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<bool> DeleteSupplierCuisine(string source, DeleteSupplierCuisineParameter parameter)
        {
            if (parameter == null)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = (int)StatusCode.System.InvalidRequest
                };
            }

            if (!this.supplierEntityRepository.EntityQueryable.Any(p => p.SupplierId == parameter.SupplierId))
            {
                return new ServicesResult<bool>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidSupplierIdCode
                };
            }

            if (
                !this.supplierMenuCategoryEntityRepository.EntityQueryable.Any(
                    p => p.SupplierMenuCategoryType.SupplierMenuCategoryTypeId == parameter.SupplierMenuCategoryTypeId))
            {
                return new ServicesResult<bool>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidSupplierMenuCategoryTypeIdCode
                };
            }

            var result = this.supplierDetailServices.DeleteSupplierCuisine(parameter);
            return new ServicesResult<bool>
            {
                StatusCode = result.StatusCode,
                Result = result.Result
            };
        }

        /// <summary>
        /// 获取餐厅菜单信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="supplierId">餐厅Id</param>
        /// <param name="supplierMenuCategoryTypeId">餐厅菜单类型</param>
        /// <param name="supplierCategoryId">The supplierCategoryId</param>
        /// <returns>
        /// 返回餐厅菜单信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/15 13:13
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResultList<SupplierDishDetailModel> GetSupplierDishList(string source, int supplierId,
                                                                               int supplierMenuCategoryTypeId,
                                                                               int? supplierCategoryId)
        {
            if (!this.supplierEntityRepository.EntityQueryable.Any(p => p.SupplierId == supplierId))
            {
                return new ServicesResultList<SupplierDishDetailModel>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidSupplierIdCode,
                    Result = new List<SupplierDishDetailModel>()
                };
            }

            var supplierMenuCategoryId =
                this.supplierMenuCategoryEntityRepository.EntityQueryable.Where(
                    p =>
                    p.SupplierId == supplierId &&
                    p.SupplierMenuCategoryType.SupplierMenuCategoryTypeId == supplierMenuCategoryTypeId)
                    .Select(p => p.SupplierMenuCategoryId)
                    .FirstOrDefault();
            var supplierCategoryQueryable = this.supplierCategoryEntityRepository.EntityQueryable.Where(
                p => p.SupplierId == supplierId && p.SupplierMenuCategoryId == supplierMenuCategoryId);

            if (supplierCategoryId != null)
            {
                supplierCategoryQueryable =
                    supplierCategoryQueryable.Where(p => p.SupplierCategoryId == supplierCategoryId);
            }

            var tempSupplierCategoryList = (from supplierCategoryEntity in supplierCategoryQueryable
                                            select new
                                            {
                                                supplierCategoryEntity.Category,
                                                supplierCategoryEntity.SupplierId,
                                                supplierCategoryEntity.SupplierCategoryId
                                            }).ToList();

            var supplierCategoryList = (from entity in tempSupplierCategoryList
                                        where entity.Category != null
                                        select new
                                        {
                                            entity.Category.CategoryId,
                                            entity.Category.CategoryName,
                                            entity.Category.CategoryNo,
                                            entity.SupplierId,
                                            entity.SupplierCategoryId
                                        }).OrderBy(p => p.CategoryNo).ToList();

            var categoryIdList = supplierCategoryList.Select(p => p.CategoryId).Distinct().Cast<int?>().ToList();
            var supplierDishList = (from supplierDishEntity in this.supplierDishEntityRepository.EntityQueryable
                                    where supplierDishEntity.Supplier.SupplierId == supplierId
                                          && supplierDishEntity.Online && supplierDishEntity.IsDel == false
                                          && categoryIdList.Contains(supplierDishEntity.SupplierCategoryId)
                                    select new
                                    {
                                        supplierDishEntity.SupplierCategoryId,
                                        supplierDishEntity.DishNo,
                                        supplierDishEntity.Price,
                                        supplierDishEntity.SupplierDishId,
                                        supplierDishEntity.SupplierDishName,
                                        supplierDishEntity.SuppllierDishDescription,
                                        supplierDishEntity.SpicyLevel,
                                        supplierDishEntity.AverageRating,
                                        supplierDishEntity.IsCommission,
                                        supplierDishEntity.IsDiscount,
                                        supplierDishEntity.Recipe,
                                        supplierDishEntity.Recommended,
                                        SupplierId =
                                    supplierDishEntity.Supplier == null ? 0 : supplierDishEntity.Supplier.SupplierId,
                                        supplierDishEntity.HasNuts,
                                        supplierDishEntity.IsDel,
                                        supplierDishEntity.IsSpecialOffer,
                                        supplierDishEntity.JianPin,
                                        supplierDishEntity.Online,
                                        supplierDishEntity.PackagingFee,
                                        supplierDishEntity.QuanPin,
                                        supplierDishEntity.SpecialOfferNo,
                                        supplierDishEntity.StockLevel,
                                        supplierDishEntity.Vegetarian,
                                        ImagePath = string.Empty
                                    }).OrderBy(p => p.DishNo).ToList();

            var supplierDishIdList = supplierDishList.Select(p => p.SupplierDishId).ToList();
            var supplierDishImageList = (from entity in this.supplierDishImageEntityRepository.EntityQueryable
                                         where
                                             supplierDishIdList.Contains(entity.SupplierDishId) && entity.Online == true
                                         select new { entity.SupplierDishId, entity.ImagePath }).ToList();



            var list = new List<SupplierDishDetailModel>();
            foreach (var supplierCategory in supplierCategoryList)
            {
                var categoryId = supplierCategory.CategoryId;
                if (list.Exists(p => p.CategoryId == categoryId))
                {
                    continue;
                }

                var dishList =
                    (from supplierDishEntity in supplierDishList.Where(p => p.SupplierCategoryId == categoryId)
                     let supplierDishImage =
                         supplierDishImageList.FirstOrDefault(p => p.SupplierDishId == supplierDishEntity.SupplierDishId)
                     select new SupplierDishDetailModel
                     {
                         Price = supplierDishEntity.Price,
                         ImagePath =
                             string.Format("{0}/{1}", ServicesCommon.ImageSiteUrl,
                                           supplierDishImage == null ? string.Empty : supplierDishImage.ImagePath),
                         SupplierDishId = supplierDishEntity.SupplierDishId,
                         DishName = supplierDishEntity.SupplierDishName,
                         DishDescription = supplierDishEntity.SuppllierDishDescription,
                         AverageRating = supplierDishEntity.AverageRating,
                         IsCommission = supplierDishEntity.IsCommission,
                         IsDiscount = supplierDishEntity.IsDiscount,
                         Recipe = supplierDishEntity.Recipe,
                         Recommended = supplierDishEntity.Recommended,
                         CategoryId = categoryId,
                         CategoryName = supplierCategory.CategoryName,
                         DishNo = supplierDishEntity.DishNo,
                         HasNuts = supplierDishEntity.HasNuts,
                         IsDel = supplierDishEntity.IsDel,
                         IsSpecialOffer = supplierDishEntity.IsSpecialOffer,
                         JianPin = supplierDishEntity.JianPin,
                         Online = supplierDishEntity.Online,
                         PackagingFee = supplierDishEntity.PackagingFee,
                         QuanPin = supplierDishEntity.QuanPin,
                         SpecialOfferNo = supplierDishEntity.SpecialOfferNo,
                         SpicyLevel = supplierDishEntity.SpicyLevel,
                         StockLevel = supplierDishEntity.StockLevel,
                         SupplierCategoryId = supplierCategory.SupplierCategoryId,
                         SupplierId = supplierCategory.SupplierId,
                         Vegetarian = supplierDishEntity.Vegetarian
                     }).ToList();

                list.AddRange(dishList);
            }

            return new ServicesResultList<SupplierDishDetailModel>
            {
                ResultTotalCount = list.Count,
                Result = list
            };
        }

        /// <summary>
        /// 获取餐厅菜单信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="supplierId">餐厅Id</param>
        /// <param name="supplierDishId">菜品Id</param>
        /// <param name="supplierMenuCategoryTypeId">餐厅菜单类型Id（1：外卖菜单、2：订台堂食菜单）</param>
        /// <returns>
        /// 返回餐厅菜单信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/15 13:13
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<SupplierDishDetailModel> GetSupplierDish(string source, int supplierId, int supplierDishId,
                                                                       int supplierMenuCategoryTypeId)
        {
            if (!this.supplierEntityRepository.EntityQueryable.Any(p => p.SupplierId == supplierId))
            {
                return new ServicesResult<SupplierDishDetailModel>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidSupplierIdCode,
                    Result = new SupplierDishDetailModel()
                };
            }

            var supplierMenuCategoryId =
                this.supplierMenuCategoryEntityRepository.EntityQueryable.Where(
                    p =>
                    p.SupplierId == supplierId &&
                    p.SupplierMenuCategoryType.SupplierMenuCategoryTypeId == supplierMenuCategoryTypeId)
                    .Select(p => p.SupplierMenuCategoryId)
                    .FirstOrDefault();
            var supplierCategoryQueryable = this.supplierCategoryEntityRepository.EntityQueryable.Where(
                p => p.SupplierId == supplierId && p.SupplierMenuCategoryId == supplierMenuCategoryId);

            var tempSupplierCategoryList = (from supplierCategoryEntity in supplierCategoryQueryable
                                            select new
                                            {
                                                supplierCategoryEntity.Category,
                                                supplierCategoryEntity.SupplierId,
                                                supplierCategoryEntity.SupplierCategoryId
                                            }).ToList();

            var supplierCategoryList = (from entity in tempSupplierCategoryList
                                        where entity.Category != null
                                        select new
                                        {
                                            entity.Category.CategoryId,
                                            entity.Category.CategoryName,
                                            entity.Category.CategoryNo,
                                            entity.SupplierId,
                                            entity.SupplierCategoryId
                                        }).OrderBy(p => p.CategoryNo).ToList();

            var categoryIdList = supplierCategoryList.Select(p => p.CategoryId).Distinct().Cast<int?>().ToList();

            var supplierDish = (from supplierDishEntity in this.supplierDishEntityRepository.EntityQueryable
                                where supplierDishEntity.Supplier.SupplierId == supplierId
                                      && supplierDishEntity.Online && supplierDishEntity.IsDel == false
                                      && supplierDishEntity.SupplierDishId == supplierDishId
                                      && categoryIdList.Contains(supplierDishEntity.SupplierCategoryId)
                                select new
                                {
                                    supplierDishEntity.SupplierCategoryId,
                                    supplierDishEntity.DishNo,
                                    supplierDishEntity.Price,
                                    supplierDishEntity.SupplierDishId,
                                    supplierDishEntity.SupplierDishName,
                                    supplierDishEntity.SuppllierDishDescription,
                                    supplierDishEntity.SpicyLevel,
                                    supplierDishEntity.AverageRating,
                                    supplierDishEntity.IsCommission,
                                    supplierDishEntity.IsDiscount,
                                    supplierDishEntity.Recipe,
                                    supplierDishEntity.Recommended,
                                    SupplierId = supplierId,
                                    supplierDishEntity.HasNuts,
                                    supplierDishEntity.IsDel,
                                    supplierDishEntity.IsSpecialOffer,
                                    supplierDishEntity.JianPin,
                                    supplierDishEntity.Online,
                                    supplierDishEntity.PackagingFee,
                                    supplierDishEntity.QuanPin,
                                    supplierDishEntity.SpecialOfferNo,
                                    supplierDishEntity.StockLevel,
                                    supplierDishEntity.Vegetarian
                                }).FirstOrDefault();

            if (supplierDish == null)
            {
                return new ServicesResult<SupplierDishDetailModel>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidSupplierDishIdCode,
                    Result = new SupplierDishDetailModel()
                };
            }

            var supplierDishImage = (from entity in this.supplierDishImageEntityRepository.EntityQueryable
                                     where entity.SupplierDishId == supplierDishId && entity.Online == true
                                     select new { entity.SupplierDishId, entity.ImagePath }).FirstOrDefault();

            var supplierCategory = (from supplierCategoryEntity in this.supplierCategoryEntityRepository.EntityQueryable
                                    where
                                        supplierCategoryEntity.SupplierId == supplierId &&
                                        supplierCategoryEntity.Category.CategoryId == supplierDish.SupplierCategoryId
                                    select new
                                    {
                                        supplierCategoryEntity.Category.CategoryId,
                                        supplierCategoryEntity.Category.CategoryName,
                                        supplierCategoryEntity.SupplierId,
                                        supplierCategoryEntity.SupplierCategoryId
                                    }).FirstOrDefault();

            var result = new SupplierDishDetailModel
            {
                Price = supplierDish.Price,
                ImagePath = string.Format(
                    "{0}/{1}",
                    ServicesCommon.ImageSiteUrl,
                    supplierDishImage == null ? string.Empty : supplierDishImage.ImagePath),
                SupplierDishId = supplierDish.SupplierDishId,
                DishName = supplierDish.SupplierDishName,
                DishDescription = supplierDish.SuppllierDishDescription,
                AverageRating = supplierDish.AverageRating,
                IsCommission = supplierDish.IsCommission,
                IsDiscount = supplierDish.IsDiscount,
                Recipe = supplierDish.Recipe,
                Recommended = supplierDish.Recommended,
                DishNo = supplierDish.DishNo,
                HasNuts = supplierDish.HasNuts,
                IsDel = supplierDish.IsDel,
                IsSpecialOffer = supplierDish.IsSpecialOffer,
                JianPin = supplierDish.JianPin,
                Online = supplierDish.Online,
                PackagingFee = supplierDish.PackagingFee,
                QuanPin = supplierDish.QuanPin,
                SpecialOfferNo = supplierDish.SpecialOfferNo,
                SpicyLevel = supplierDish.SpicyLevel,
                StockLevel = supplierDish.StockLevel,
                SupplierId = supplierDish.SupplierId,
                Vegetarian = supplierDish.Vegetarian,
                SupplierCategoryId = supplierCategory == null ? 0 : supplierCategory.SupplierCategoryId,
                CategoryId = supplierCategory == null ? 0 : supplierCategory.CategoryId,
                CategoryName = supplierCategory == null ? string.Empty : supplierCategory.CategoryName
            };

            return new ServicesResult<SupplierDishDetailModel>
            {
                Result = result
            };
        }

        /// <summary>
        /// 添加餐厅菜信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="parameter">The parameter</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/1/2013 4:43 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<bool> AddSupplierDish(string source, SaveSupplierDishParameter parameter)
        {
            if (parameter == null)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = (int)StatusCode.System.InvalidRequest
                };
            }

            if (!this.supplierEntityRepository.EntityQueryable.Any(p => p.SupplierId == parameter.SupplierId))
            {
                return new ServicesResult<bool>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidSupplierIdCode
                };
            }

            if (
                !this.supplierMenuCategoryEntityRepository.EntityQueryable.Any(
                    p => p.SupplierMenuCategoryType.SupplierMenuCategoryTypeId == parameter.SupplierMenuCategoryTypeId))
            {
                return new ServicesResult<bool>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidSupplierMenuCategoryTypeIdCode
                };
            }

            var result = this.supplierDetailServices.AddSupplierDish(parameter);
            return new ServicesResult<bool>
            {
                StatusCode = result.StatusCode,
                Result = result.Result
            };
        }

        /// <summary>
        /// 更新菜信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="parameter">The parameter</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/3/2013 10:32 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<bool> UpdateSupplierDish(string source, SaveSupplierDishParameter parameter)
        {
            if (parameter == null)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = (int)StatusCode.System.InvalidRequest
                };
            }

            if (!this.supplierEntityRepository.EntityQueryable.Any(p => p.SupplierId == parameter.SupplierId))
            {
                return new ServicesResult<bool>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidSupplierIdCode
                };
            }

            if (
                !this.supplierMenuCategoryEntityRepository.EntityQueryable.Any(
                    p => p.SupplierMenuCategoryType.SupplierMenuCategoryTypeId == parameter.SupplierMenuCategoryTypeId))
            {
                return new ServicesResult<bool>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidSupplierMenuCategoryTypeIdCode
                };
            }

            var result = this.supplierDetailServices.UpdateSupplierDish(parameter);
            return new ServicesResult<bool>
            {
                StatusCode = result.StatusCode,
                Result = result.Result
            };
        }

        /// <summary>
        /// 删除菜信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="parameter">The parameter</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/3/2013 10:32 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<bool> DeleteSupplierDish(string source, DeleteSupplierDishParameter parameter)
        {
            if (parameter == null)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = (int)StatusCode.System.InvalidRequest
                };
            }

            if (!this.supplierEntityRepository.EntityQueryable.Any(p => p.SupplierId == parameter.SupplierId))
            {
                return new ServicesResult<bool>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidSupplierIdCode
                };
            }

            var result = this.supplierDetailServices.DeleteSupplierDish(parameter);
            return new ServicesResult<bool>
            {
                StatusCode = result.StatusCode,
                Result = result.Result
            };
        }

        /// <summary>
        /// 取得餐厅营业时间
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="supplierId">餐厅Id</param>
        /// <param name="deliveryMethodId">送餐方式</param>
        /// <param name="startServiceDate">开始日期</param>
        /// <param name="days">天数</param>
        /// <param name="onlyActive">是否只取有效的送餐时间</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：12/2/2013 11:40 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResultList<SupplierServiceTimeModel> GetSupplierServiceTime(string source, int supplierId,
                                                                                   int deliveryMethodId,
                                                                                   DateTime? startServiceDate, int? days,
                                                                                   bool onlyActive)
        {
            var supplier =
                this.supplierEntityRepository.EntityQueryable.Where(p => p.SupplierId == supplierId).Select(p => new
                {
                    p.SupplierId,
                    p.DeliveryTime,
                    p.PickUpTime
                }).FirstOrDefault();

            if (supplier == null)
            {
                return new ServicesResultList<SupplierServiceTimeModel>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidSupplierIdCode,
                    Result = new List<SupplierServiceTimeModel>()
                };
            }

            int deliveryTime;
            if (!int.TryParse(supplier.DeliveryTime, out deliveryTime))
            {
                deliveryTime = ServicesCommon.DeliveryMethodReadyTime;
            }

            int pickUpTime;
            if (!int.TryParse(supplier.PickUpTime, out pickUpTime))
            {
                pickUpTime = ServicesCommon.PickUpMethodReadyTime;
            }

            if (!ServicesCommon.SupplierReadyTimeEnable)
            {
                deliveryTime = ServicesCommon.ActiveDeliveryMethodReadyTime;
                pickUpTime = ServicesCommon.ActivePickUpMethodReadyTime;
            }

            var beginReadyTime = deliveryMethodId == ServicesCommon.PickUpDeliveryMethodId ? pickUpTime : deliveryTime;
            var result = this.supplierDetailServices.GetSupplierServiceTime(supplierId, startServiceDate ?? DateTime.Now,
                                                                            days ??
                                                                            ServicesCommon.ServiceTimeDefaultDays,
                                                                            beginReadyTime, onlyActive);
            return new ServicesResultList<SupplierServiceTimeModel>
            {
                ResultTotalCount = result.ResultTotalCount,
                StatusCode = result.StatusCode,
                Result = result.Result
            };
        }

        /// <summary>
        /// 取得餐厅送餐时间
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="supplierId">餐厅Id</param>
        /// <param name="deliveryMethodId">送餐方式</param>
        /// <param name="startDeliveryDate">开始日期</param>
        /// <param name="days">天数</param>
        /// <param name="onlyActive">是否只取有效的送餐时间</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：12/2/2013 11:40 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResultList<SupplierDeliveryTimeModel> GetSupplierDeliveryTime(string source, int supplierId,
                                                                                     int deliveryMethodId,
                                                                                     DateTime? startDeliveryDate,
                                                                                     int? days, bool onlyActive)
        {
            var supplier =
                this.supplierEntityRepository.EntityQueryable.Where(p => p.SupplierId == supplierId).Select(p => new
                {
                    p.SupplierId,
                    p.DeliveryTime,
                    p.PickUpTime
                }).FirstOrDefault();

            if (supplier == null)
            {
                return new ServicesResultList<SupplierDeliveryTimeModel>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidSupplierIdCode,
                    Result = new List<SupplierDeliveryTimeModel>()
                };
            }

            int deliveryTime;
            if (!int.TryParse(supplier.DeliveryTime, out deliveryTime))
            {
                deliveryTime = ServicesCommon.DeliveryMethodReadyTime;
            }

            int pickUpTime;
            if (!int.TryParse(supplier.PickUpTime, out pickUpTime))
            {
                pickUpTime = ServicesCommon.PickUpMethodReadyTime;
            }

            if (!ServicesCommon.SupplierReadyTimeEnable)
            {
                deliveryTime = ServicesCommon.ActiveDeliveryMethodReadyTime;
                pickUpTime = ServicesCommon.ActivePickUpMethodReadyTime;
            }

            var beginReadyTime = deliveryMethodId == ServicesCommon.PickUpDeliveryMethodId ? pickUpTime : deliveryTime;
            var result = this.supplierDetailServices.GetSupplierDeliveryTime(supplierId,
                                                                             startDeliveryDate ?? DateTime.Now,
                                                                             days ??
                                                                             ServicesCommon.DeliveryTimeDefaultDays,
                                                                             beginReadyTime, onlyActive);
            return new ServicesResultList<SupplierDeliveryTimeModel>
            {
                ResultTotalCount = result.ResultTotalCount,
                StatusCode = result.StatusCode,
                Result = result.Result
            };
        }

        /// <summary>
        /// 计算距离
        /// </summary>
        /// <param name="source"></param>
        /// <param name="parameter"></param>
        /// <returns>
        /// 距离
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/4/2013 3:49 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<DistanceModel> GetDistance(string source, DistanceParameter parameter)
        {
            if (parameter == null)
            {
                return new ServicesResult<DistanceModel>
                {
                    StatusCode = (int)StatusCode.System.InvalidRequest,
                    Result = new DistanceModel()
                };
            }
            var distance = CalDistance(parameter.LocationA, parameter.LocationB, parameter.Gs);
            var distanceModel = new DistanceModel { Distance = distance };
            return new ServicesResult<DistanceModel>
            {
                Result = distanceModel
            };
        }

        /// <summary>
        /// 计算距离方法
        /// </summary>
        /// <param name="locationA">The locationA</param>
        /// <param name="locationB">The locationB</param>
        /// <param name="gs">The gs</param>
        /// <returns>
        /// Double
        /// </returns>
        /// 创建者：单琪彬
        /// 创建日期：2/12/2014 1:25 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private double CalDistance(Location locationA, Location locationB, GaussSphere gs)
        {
            var radLat1 = Rad(locationA.Lat);
            var radLat2 = Rad(locationB.Lat);
            var a = radLat1 - radLat2;
            var b = Rad(locationA.Lng) - Rad(locationB.Lng);
            var s = 2 * Math.Asin(Math.Sqrt(Math.Pow(Math.Sin(a / 2), 2) +
                                          Math.Cos(radLat1) * Math.Cos(radLat2) * Math.Pow(Math.Sin(b / 2), 2)));
            s = s * (gs == GaussSphere.WGS84 ? 6378137.0 : (gs == GaussSphere.Xian80 ? 6378140.0 : 6378245.0));
            s = Math.Round(s * 10000) / 10000;
            return s;
        }

        /// <summary>
        /// The method will 
        /// </summary>
        /// <param name="d">The d</param>
        /// <returns>
        /// The Double
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/4/2013 4:25 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private double Rad(double d)
        {
            return d * Math.PI / 180.0;
        }

        /// <summary>
        /// 获取 餐厅推荐菜品(外卖)列表
        /// </summary>
        /// <param name="supplierId">The supplierIdDefault documentation</param>
        /// <returns>
        /// List{SupplierRecommendedDishModel}
        /// </returns>
        /// 创建者：王巍
        /// 创建日期：3/12/2014 8:14 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private List<SupplierRecommendedDishModel> GetRecommendedDish(int supplierId)
        {
            var tempSupplierCategoryList =
                (from supplierMenu in this.supplierMenuCategoryEntityRepository.EntityQueryable
                 from supplierCategoryEntity in this.supplierCategoryEntityRepository.EntityQueryable
                 where supplierCategoryEntity.SupplierId == supplierId
                       && supplierMenu.SupplierMenuCategoryId == supplierCategoryEntity.SupplierMenuCategoryId
                       && supplierMenu.SupplierId == supplierCategoryEntity.SupplierId
                       && supplierMenu.SupplierMenuCategoryType.SupplierMenuCategoryTypeId == 1
                 select new
                 {
                     supplierCategoryEntity.Category,
                     supplierCategoryEntity.SupplierId,
                     supplierCategoryEntity.SupplierCategoryId,
                     supplierMenu.SupplierMenuCategoryId
                 }).ToList();

            if (tempSupplierCategoryList.Count == 0)
            {
                return new List<SupplierRecommendedDishModel>();
            }

            var supplierCategoryList = (from entity in tempSupplierCategoryList
                                        where entity.Category != null
                                        select new
                                        {
                                            entity.Category.CategoryId,
                                            entity.Category.CategoryName,
                                            entity.Category.CategoryNo,
                                            entity.SupplierId,
                                            entity.SupplierCategoryId,
                                            entity.SupplierMenuCategoryId
                                        }).OrderBy(p => p.CategoryNo).ToList();

            var categoryIdList = supplierCategoryList.Select(p => p.CategoryId).Distinct().Cast<int?>().ToList();
            var supplierDishList = (from supplierDishEntity in this.supplierDishEntityRepository.EntityQueryable
                                    where supplierDishEntity.Supplier.SupplierId == supplierId
                                          && supplierDishEntity.Online && supplierDishEntity.IsDel == false &&
                                          supplierDishEntity.Recommended == true
                                          && categoryIdList.Contains(supplierDishEntity.SupplierCategoryId)
                                    select new
                                    {
                                        supplierDishEntity.SupplierCategoryId,
                                        supplierDishEntity.DishNo,
                                        supplierDishEntity.Price,
                                        supplierDishEntity.SupplierDishId,
                                        supplierDishEntity.SupplierDishName,
                                        supplierDishEntity.SuppllierDishDescription,
                                        supplierDishEntity.SpicyLevel,
                                        supplierDishEntity.AverageRating,
                                        supplierDishEntity.IsCommission,
                                        supplierDishEntity.IsDiscount,
                                        supplierDishEntity.Recipe,
                                        supplierDishEntity.Recommended,
                                        supplierDishEntity.PackagingFee,
                                        SupplierId =
                                    supplierDishEntity.Supplier == null ? 0 : supplierDishEntity.Supplier.SupplierId,
                                        ImagePath = string.Empty
                                    }).OrderBy(p => p.DishNo).ToList();

            var supplierDishIdList = supplierDishList.Select(p => p.SupplierDishId).ToList();
            var supplierDishImageList = (from entity in this.supplierDishImageEntityRepository.EntityQueryable
                                         where
                                             supplierDishIdList.Contains(entity.SupplierDishId) && entity.Online == true
                                         select new { entity.SupplierDishId, entity.ImagePath }).ToList();

            var recommendDishList = (from supplierDish in supplierDishList
                                     let supplierDishImage =
                                         supplierDishImageList.FirstOrDefault(
                                             p => p.SupplierDishId == supplierDish.SupplierDishId)
                                     let supplierCategory =
                                         supplierCategoryList.FirstOrDefault(
                                             p => p.CategoryId == supplierDish.SupplierCategoryId)
                                     select new SupplierRecommendedDishModel
                                     {
                                         Price = supplierDish.Price,
                                         ImagePath =
                                             string.Format("{0}/{1}", ServicesCommon.ImageSiteUrl,
                                                           supplierDishImage == null
                                                               ? string.Empty
                                                               : supplierDishImage.ImagePath),
                                         SupplierDishId = supplierDish.SupplierDishId,
                                         SupplierDishName = supplierDish.SupplierDishName,
                                         SupplierCatogryId = supplierDish.SupplierCategoryId,
                                         SupplierMenuCategoryId =
                                             supplierCategory == null
                                                 ? null
                                                 : (int?)supplierCategory.SupplierMenuCategoryId,
                                         Type = 0, //0 菜 1 小料 2 锅底 3 套餐 4 专人服务
                                         Recipe = supplierDish.Recipe,
                                         PackagingFee = supplierDish.PackagingFee
                                     }).ToList();

            return recommendDishList;
        }

        /// <summary>
        /// 获取订台台位列表
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns></returns>
        /// 创建者：苏建峰
        /// 创建日期：3/18/2014 6:06 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        /// 创建者：苏建峰
        /// 创建日期：3/19/2014 11:35 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResultList<DingTaiDeskModel> GetDeskList(string source, DingTaiGetDeskListParameter parameter)
        {
            if (parameter == null)
            {
                return new ServicesResultList<DingTaiDeskModel>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidSupplierIdCode,
                    Result = new List<DingTaiDeskModel>()
                };
            }

            /*判断餐厅Id是否存在*/
            if (!this.supplierEntityRepository.EntityQueryable.Any(p => p.SupplierId == parameter.SupplierId))
            {
                return new ServicesResultList<DingTaiDeskModel>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidSupplierIdCode,
                    Result = new List<DingTaiDeskModel>()
                };
            }

            /*早晚市开放时间*/
            //BeginTime和EndTime时间格式为（07:00、22:00）
            var supplierDeskTimeList = (from supplierDeskTimeEntity in this.supplierDeskTimeEntityRepository.EntityQueryable
                                        where supplierDeskTimeEntity.SupplierId == parameter.SupplierId && supplierDeskTimeEntity.IsEnable == true
                                        select new
                                        {
                                            supplierDeskTimeEntity.Id,
                                            supplierDeskTimeEntity.BeginTime,
                                            supplierDeskTimeEntity.EndTime,
                                            supplierDeskTimeEntity.TimeType
                                        }).ToList();


            var supplierDeskTime = supplierDeskTimeList.FirstOrDefault(p => string.Compare(p.BeginTime, parameter.BookingTime, StringComparison.OrdinalIgnoreCase) <=
                                                          0
                                                          && string.Compare(p.EndTime, parameter.BookingTime, StringComparison.OrdinalIgnoreCase) >= 0);

            if (supplierDeskTime == null)
            {
                return new ServicesResultList<DingTaiDeskModel>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidBookingTimeCode,
                    Result = new List<DingTaiDeskModel>()
                };
            }

            /*在给定的预定日期和预定时间内，被锁定的台位类型*/
            var lockedDeskTypeId =
                this.deskTypeLockLogEntityRepository.EntityQueryable.Where(p => p.SupplierId == parameter.SupplierId
                                                                                && p.LockDate == parameter.BookingDate
                                                                                &&
                                                                                p.SupplierDeskTime.Id ==
                                                                                supplierDeskTime.Id
                                                                                && p.IsDel == false)
                    .Select(p => p.DeskTypeId)
                    .ToList();


            /*可以预定的台位列表*/
            var deskTypeList = (from deskTypeEntity in this.deskTypeEntityRepository.EntityQueryable
                                where deskTypeEntity.SupplierId == parameter.SupplierId
                                      && deskTypeEntity.IsLock == false
                                      && deskTypeEntity.IsDel == false
                                      && !lockedDeskTypeId.Contains(deskTypeEntity.Id)
                                      && deskTypeEntity.MinNumber <= parameter.PeopleCount
                                      && deskTypeEntity.MaxNumber >= parameter.PeopleCount
                                select new DingTaiDeskModel
                                {
                                    Id = deskTypeEntity.Id,
                                    RoomType = deskTypeEntity.RoomType,
                                    TblTypeId = deskTypeEntity.TableType.Id,
                                    TblTypeName = deskTypeEntity.TableType.TblTypeName,
                                    MaxNumber = deskTypeEntity.MaxNumber,
                                    MinNumber = deskTypeEntity.MinNumber,
                                    DepositAmount = deskTypeEntity.DepositAmount,
                                    LowCost = deskTypeEntity.LowCost
                                }).ToList();

            return new ServicesResultList<DingTaiDeskModel>
            {
                ResultTotalCount = deskTypeList.Count,
                Result = deskTypeList
            };
        }

        /// <summary>
        /// 获取餐厅订台开放时间列表
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="supplierId">餐厅Id</param>
        /// <param name="bookingDate">预订时间</param>
        /// <returns></returns>
        /// 创建者：苏建峰
        /// 创建日期：3/20/2014 2:22 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        /// 创建者：苏建峰
        /// 创建日期：3/20/2014 2:23 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResultList<string> GetDeskOpenTimeList(string source, int supplierId, DateTime bookingDate)
        {
            /*判断餐厅Id是否存在*/
            if (!this.supplierEntityRepository.EntityQueryable.Any(p => p.SupplierId == supplierId))
            {
                return new ServicesResultList<string>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidSupplierIdCode,
                    Result = new List<string>()
                };
            }

            var supplierDeskTimeList = (from supplierDeskTimeEntity in this.supplierDeskTimeEntityRepository.EntityQueryable
                                        where supplierDeskTimeEntity.SupplierId == supplierId && supplierDeskTimeEntity.IsEnable == true
                                        select new
                                        {
                                            supplierDeskTimeEntity.Id,
                                            supplierDeskTimeEntity.BeginTime,
                                            supplierDeskTimeEntity.EndTime,
                                            supplierDeskTimeEntity.TimeType
                                        }).ToList();

            if (supplierDeskTimeList.Count == 0)
            {
                return new ServicesResultList<string>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidSupplierIdCode,
                    Result = new List<string>()
                };
            }

            var deskTypeEntityList = this.deskTypeEntityRepository.EntityQueryable.Where(
                  p => p.IsDel == false && p.IsLock == false && p.SupplierId == supplierId)
                  .Select(p => new { p.Id, p.SupplierId })
                  .ToList();

            var supplierDeskEntityList = this.supplierDeskEntityRepository.EntityQueryable.Where(
                  p => p.IsDel == false && p.IsEnable && p.SupplierId == supplierId)
                  .Select(p => new { p.Id, DeskTypeId = p.DeskType.Id, p.SupplierId })
                  .ToList();

            if (deskTypeEntityList.Count == 0)
            {
                return new ServicesResultList<string>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidSupplierIdCode,
                    Result = new List<string>()
                };
            }

            var now = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));
            var deskBookingList = (from deskType in deskTypeEntityList
                                   from supplierDeskTime in supplierDeskTimeList
                                   from deskBookingEntity in this.deskBookingEntityRepository.EntityQueryable
                                   where deskType.Id == deskBookingEntity.DeskType.Id && deskBookingEntity.SupplierId == supplierId
                                       && deskBookingEntity.TimeType == supplierDeskTime.TimeType
                                       && deskBookingEntity.ReservationTime >= now && deskBookingEntity.ReservationTime < now.AddDays(1)
                                   select new { DeskTypeId = deskType.Id, deskBookingEntity.TimeType }).ToList();

            var deskTypeLockLogList = (from deskType in deskTypeEntityList
                                       from supplierDeskTime in supplierDeskTimeList
                                       from deskTypeLockLog in this.deskTypeLockLogEntityRepository.EntityQueryable
                                       where deskType.Id == deskTypeLockLog.DeskTypeId && deskTypeLockLog.SupplierId == supplierId
                                           && deskTypeLockLog.SupplierDeskTime.TimeType == supplierDeskTime.TimeType
                                           && deskTypeLockLog.LockDate >= now && deskTypeLockLog.LockDate < now.AddDays(1)
                                       select new { DeskTypeId = deskType.Id, deskTypeLockLog.SupplierDeskTime.TimeType }).ToList();

            var supplierDeskTimeLockList = supplierDeskTimeList.Select(
                        p =>
                        new
                        {
                            p.TimeType,
                            Count = deskTypeLockLogList.Count(q => q.TimeType == p.TimeType)
                        }).ToList();

            if (!supplierDeskTimeLockList.Any(p => p.Count < deskTypeEntityList.Count))
            {
                return new ServicesResultList<string>
                {
                    Result = new List<string>()
                };
            }

            var supplierDeskTimeBookingList = supplierDeskTimeList.Select(
                   p =>
                   new
                   {
                       p.TimeType,
                       p.BeginTime,
                       p.EndTime,
                       Count = deskBookingList.Count(q => q.TimeType == p.TimeType)
                   }).ToList();

            if (!supplierDeskTimeBookingList.Any(p => p.Count < deskTypeEntityList.Count))
            {
                return new ServicesResultList<string>
                {
                    Result = new List<string>()
                };
            }

            var list = (from item in supplierDeskTimeBookingList
                        from deskType in deskTypeEntityList
                        let bookingCount = deskBookingList.Count(p => p.TimeType == item.TimeType && p.DeskTypeId == deskType.Id)
                        let supplierDeskCount = supplierDeskEntityList.Count(p => p.DeskTypeId == deskType.Id)
                        select new
                        {
                            Can = bookingCount < supplierDeskCount,
                            item.TimeType,
                            item.BeginTime,
                            item.EndTime,
                        }).ToList();

            var tempList = list.Where(p => p.Can).ToList();
            if (tempList.Count == 0)
            {
                return new ServicesResultList<string>
                {
                    Result = new List<string>()
                };
            }

            var deskOpenTimeList = new List<DateTime>();
            var nowTime = bookingDate.ToString("yyyy-MM-dd") == now.ToString("yyyy-MM-dd") ? DateTime.Now : DateTime.Parse(bookingDate.ToString("yyyy-MM-dd"));
            foreach (var item in tempList)
            {
                var beginTime = DateTime.Parse(bookingDate.ToString("yyyy-MM-dd") + " " + item.BeginTime + ":00");
                var endTime = DateTime.Parse(bookingDate.ToString("yyyy-MM-dd") + " " + item.EndTime + ":00");

                if (nowTime > beginTime)
                {
                    beginTime = nowTime;
                }

                if (beginTime > endTime)
                {
                    continue;
                }

                while (beginTime <= endTime)
                {
                    deskOpenTimeList.Add(beginTime);
                    beginTime = beginTime.AddMinutes(30);
                }

                if (beginTime.AddMinutes(-30) < endTime)
                {
                    deskOpenTimeList.Add(endTime);
                }
            }

            var result = deskOpenTimeList.OrderBy(p => p).ToList().Select(p => p.ToString("HH:mm")).ToList();
            return new ServicesResultList<string>
            {
                ResultTotalCount = result.Count,
                Result = result
            };
        }

        /// <summary>
        /// 获取餐厅订台开放日期列表
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="supplierId">餐厅Id</param>
        /// <param name="days">The days</param>
        /// <returns>
        /// ServicesResultList{DeskOpenDateModel}
        /// </returns>
        /// 创建者：苏建峰
        /// 创建日期：3/20/2014 2:22 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResultList<DeskOpenDateModel> GetDeskOpenDateList(string source, int supplierId, int? days)
        {
            /*判断餐厅Id是否存在*/
            if (!this.supplierEntityRepository.EntityQueryable.Any(p => p.SupplierId == supplierId))
            {
                return new ServicesResultList<DeskOpenDateModel>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidSupplierIdCode,
                    Result = new List<DeskOpenDateModel>()
                };
            }

            var supplierDeskTimeList = (from supplierDeskTimeEntity in this.supplierDeskTimeEntityRepository.EntityQueryable
                                        where supplierDeskTimeEntity.SupplierId == supplierId && supplierDeskTimeEntity.IsEnable == true
                                        select new
                                        {
                                            supplierDeskTimeEntity.Id,
                                            supplierDeskTimeEntity.BeginTime,
                                            supplierDeskTimeEntity.EndTime,
                                            supplierDeskTimeEntity.TimeType
                                        }).ToList();

            if (supplierDeskTimeList.Count == 0)
            {
                return new ServicesResultList<DeskOpenDateModel>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidSupplierIdCode,
                    Result = new List<DeskOpenDateModel>()
                };
            }

            var deskTypeEntityList = this.deskTypeEntityRepository.EntityQueryable.Where(
                  p => p.IsDel == false && p.IsLock == false && p.SupplierId == supplierId)
                  .Select(p => new { p.Id, p.SupplierId })
                  .ToList();

            var supplierDeskEntityList = this.supplierDeskEntityRepository.EntityQueryable.Where(
                  p => p.IsDel == false && p.IsEnable && p.SupplierId == supplierId)
                  .Select(p => new { p.Id, DeskTypeId = p.DeskType.Id, p.SupplierId })
                  .ToList();

            if (deskTypeEntityList.Count == 0)
            {
                return new ServicesResultList<DeskOpenDateModel>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidSupplierIdCode,
                    Result = new List<DeskOpenDateModel>()
                };
            }

            var now = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));
            var dateTimeList = new List<DateTime>();
            var tempDays = days ?? ServicesCommon.DingTaiDaySpan;
            for (var i = 0; i < tempDays; i++)
            {
                dateTimeList.Add(now.AddDays(i));
            }

            var deskBookingList = (from deskType in deskTypeEntityList
                                   from time in dateTimeList
                                   from supplierDeskTime in supplierDeskTimeList
                                   from deskBookingEntity in this.deskBookingEntityRepository.EntityQueryable
                                   where deskType.Id == deskBookingEntity.DeskType.Id && deskBookingEntity.SupplierId == supplierId
                                       && deskBookingEntity.TimeType == supplierDeskTime.TimeType
                                       && deskBookingEntity.ReservationTime >= time && deskBookingEntity.ReservationTime < time.AddDays(1)
                                   select new { DeskTypeId = deskType.Id, deskBookingEntity.TimeType, Day = time }).ToList();

            var deskTypeLockLogList = (from deskType in deskTypeEntityList
                                       from time in dateTimeList
                                       from supplierDeskTime in supplierDeskTimeList
                                       from deskTypeLockLog in this.deskTypeLockLogEntityRepository.EntityQueryable
                                       where deskType.Id == deskTypeLockLog.DeskTypeId && deskTypeLockLog.SupplierId == supplierId
                                           && deskTypeLockLog.SupplierDeskTime.TimeType == supplierDeskTime.TimeType
                                           && deskTypeLockLog.LockDate >= time && deskTypeLockLog.LockDate < time.AddDays(1)
                                       select new { DeskTypeId = deskType.Id, deskTypeLockLog.SupplierDeskTime.TimeType, Day = time }).ToList();

            var deskOPenDateList = new List<DeskOpenDateModel>();
            foreach (var dateTime in dateTimeList)
            {
                var supplierDeskTimeLockList = supplierDeskTimeList.Select(
                        p =>
                        new
                        {
                            p.TimeType,
                            Count = deskTypeLockLogList.Count(q => q.Day == dateTime && q.TimeType == p.TimeType)
                        }).ToList();

                if (!supplierDeskTimeLockList.Any(p => p.Count < deskTypeEntityList.Count))
                {
                    deskOPenDateList.Add(new DeskOpenDateModel
                    {
                        Date = dateTime,
                        IsLock = true
                    });

                    continue;
                }

                var supplierDeskTimeBookingList = supplierDeskTimeList.Select(
                       p =>
                       new
                       {
                           p.TimeType,
                           Count = deskBookingList.Count(q => q.Day == dateTime && q.TimeType == p.TimeType)
                       }).ToList();

                if (!supplierDeskTimeBookingList.Any(p => p.Count < deskTypeEntityList.Count))
                {
                    deskOPenDateList.Add(new DeskOpenDateModel
                    {
                        Date = dateTime,
                        IsLock = true
                    });

                    continue;
                }

                var list = (from item in supplierDeskTimeBookingList
                            from deskType in deskTypeEntityList
                            let bookingCount = deskBookingList.Count(p => p.TimeType == item.TimeType && p.Day == dateTime && p.DeskTypeId == deskType.Id)
                            let supplierDeskCount = supplierDeskEntityList.Count(p => p.DeskTypeId == deskType.Id)
                            select bookingCount < supplierDeskCount).ToList();

                if (!list.Any(p => p))
                {
                    continue;
                }

                deskOPenDateList.Add(new DeskOpenDateModel
                {
                    Date = dateTime,
                    IsLock = false
                });
            }


            return new ServicesResultList<DeskOpenDateModel>
            {
                ResultTotalCount = deskOPenDateList.Count,
                Result = deskOPenDateList
            };

        }

        /// <summary>
        /// 查检订台台位是否被锁
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="supplierId">餐厅Id</param>
        /// <param name="parameter">The parameter.</param>
        /// <returns></returns>
        /// 创建者：苏建峰
        /// 创建日期：3/22/2014 11:19 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<bool> CheckDesk(string source, int supplierId, CheckDeskParameter parameter)
        {
            if (parameter == null)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = (int)StatusCode.System.InvalidRequest
                };
            }

            /*验证餐厅Id*/
            if (!this.supplierEntityRepository.EntityQueryable.Any(p => p.SupplierId == supplierId))
            {
                return new ServicesResult<bool>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidSupplierIdCode
                };
            }

            /*验证台位类型Id*/
            var deskTypeEntity =
                this.deskTypeEntityRepository.EntityQueryable.FirstOrDefault(p => p.SupplierId == supplierId);

            if (deskTypeEntity == null || deskTypeEntity.IsDel)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = (int)StatusCode.Validate.NotFondDeskTypeCode
                };
            }
            //台位类型已被锁定
            if (deskTypeEntity.IsLock)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = (int)StatusCode.Validate.DeskTypeIsLocked
                };
            }

            /*早晚市开放时间*/
            var supplierDeskTime = (from supplierDeskTimeEntity in this.supplierDeskTimeEntityRepository.EntityQueryable
                                    where supplierDeskTimeEntity.SupplierId == supplierId
                                    select new
                                    {
                                        supplierDeskTimeEntity.Id,
                                        supplierDeskTimeEntity.BeginTime,
                                        supplierDeskTimeEntity.EndTime
                                    }).ToList()
                                          .FirstOrDefault(p => string.Compare(p.BeginTime, parameter.BookingTime,
                                                                              StringComparison.OrdinalIgnoreCase) <=
                                                               0
                                                               && string.Compare(p.EndTime, parameter.BookingTime,
                                                                                 StringComparison
                                                                                       .OrdinalIgnoreCase) >= 0);
            //该时间内不可预订
            if (supplierDeskTime == null)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidBookingTimeCode
                };
            }

            /*在给定的预定日期和预定时间内，被锁定的台位类型*/
            var lockedDeskTypeList =
                this.deskTypeLockLogEntityRepository.EntityQueryable.Where(p => p.SupplierId == supplierId
                                                                                && p.LockDate == parameter.BookingDate
                                                                                &&
                                                                                p.SupplierDeskTime.Id ==
                                                                                supplierDeskTime.Id
                                                                                && p.IsDel == false
                                                                                && p.DeskTypeId == deskTypeEntity.Id)
                    .ToList();

            if (lockedDeskTypeList.Count > 0)
            {
                return new ServicesResult<bool>
                {
                    StatusCode = (int)StatusCode.Validate.DeskTypeIsLocked
                };
            }

            return new ServicesResult<bool>
            {
                StatusCode = (int)StatusCode.Succeed.Ok,
                Result = true
            };
        }
        /// <summary>
        /// 检查输入桌号是否有效
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="supplierId">The supplierId</param>
        /// <param name="tableNo">The tableNo</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：单琪彬
        /// 创建日期：3/24/2014 11:43 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<bool> CheckTableNumIsEffective(string source, int supplierId, string tableNo)
        {
            //找不到桌号信息
            if (!this.supplierDeskEntityRepository.EntityQueryable.Any(p => p.SupplierId == supplierId && p.DeskNo == tableNo
                                                                       && p.IsDel == false && p.IsEnable))
            {
                return new ServicesResult<bool>
                {
                    StatusCode = (int)StatusCode.Validate.NotFondDeskNum,
                    Result = false
                };
            }
            //桌号可以使用
            return new ServicesResult<bool>
            {
                StatusCode = (int)StatusCode.Succeed.Ok,
                Result = true
            };
        }

        /// <summary>
        /// 根据Id查询桌号
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="deskId">The deskId</param>
        /// <param name="supplierId">The supplierId</param>
        /// <returns>
        /// 返回桌号
        /// </returns>
        /// 创建者：单琪彬
        /// 创建日期：3/25/2014 1:06 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<string> GetDeskNoById(string source, int deskId, int supplierId)
        {
            if (deskId == 0)
            {
                return new ServicesResult<string>
                {
                    StatusCode = (int)StatusCode.System.InvalidRequest,
                    Result = string.Empty
                };
            }
            var supplierEntity = this.supplierDeskEntityRepository.EntityQueryable.Where(p => p.SupplierId == supplierId && p.Id == deskId)
                .Select(p => new { p.DeskNo })
                .FirstOrDefault();
            /*判断餐厅Id是否存在*/
            if (supplierEntity == null)
            {
                return new ServicesResult<string>
                {
                    StatusCode = (int)StatusCode.Validate.NotFondDeskNo,
                    Result = string.Empty
                };
            }

            return new ServicesResult<string>
            {
                Result = supplierEntity.DeskNo
            };
        }
    }
}