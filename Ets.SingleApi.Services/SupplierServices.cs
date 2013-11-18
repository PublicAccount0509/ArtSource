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
        /// 字段timeTableDisplayEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：2013/10/20 9:15
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<TimeTableDisplayEntity> timeTableDisplayEntityRepository;

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
        /// <param name="timeTableDisplayEntityRepository">The timeTableDisplayEntityRepository</param>
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
            INHibernateRepository<TimeTableDisplayEntity> timeTableDisplayEntityRepository,
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
            this.timeTableDisplayEntityRepository = timeTableDisplayEntityRepository;
            this.supplierDetailServices = supplierDetailServices;
        }

        /// <summary>
        /// 获取餐厅信息
        /// </summary>
        /// <param name="supplierId">餐厅Id</param>
        /// <returns>
        /// 返回餐厅信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/19 23:36
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<SupplierDetailModel> GetSupplier(int supplierId)
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
                                        supplierEntity.BaIduLong
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
                    LogoUrl = string.Format("{0}/{1}", ServicesCommon.ImageSiteUrl,
                    this.supplierImageEntityRepository.EntityQueryable.Where(
                            p => p.Supplier.SupplierId == supplierId && p.Online == true)
                            .Select(p => p.ImagePath)
                            .FirstOrDefault())
                };

            if (supplier.SupplierGroupId != null && !ServicesCommon.TestSupplierGroupId.Contains(supplier.SupplierGroupId.Value))
            {
                supplier.ChainCount = this.supplierEntityRepository.EntityQueryable.Count(p => p.SupplierGroupId == supplier.SupplierGroupId);
            }

            var supplierCuisineList = this.supplierCuisineEntityRepository.EntityQueryable.Where(p => p.Supplier.SupplierId == supplierId)
                                      .Select(p => new { p.Cuisine.CuisineId, p.Cuisine.CuisineName })
                                      .ToList();
            supplier.CuisineName = string.Join(",", supplierCuisineList.Select(p => p.CuisineName).Where(p => !p.IsEmptyOrNull()).Distinct().ToList());

            var suppTimeTableDisplayList = (from entity in this.suppTimeTableDisplayEntityRepository.EntityQueryable
                                            where entity.SupplierId == supplierId
                                            select new
                                                {
                                                    entity.Day,
                                                    entity.TimeTableDisplayId
                                                }).ToList();

            var timeTableDisplayIdList = suppTimeTableDisplayList.Where(item => item.Day != null).Where(item => DateTime.Now.DayOfWeek.ToString("d") == (item.Day + 1).ToString()).Select(p => p.TimeTableDisplayId).ToList();
            if (timeTableDisplayIdList.Count == 0)
            {
                return new ServicesResult<SupplierDetailModel>
                {
                    Result = supplier
                };
            }

            var timeTableDisplayList = (from entity in this.timeTableDisplayEntityRepository.EntityQueryable
                                        where timeTableDisplayIdList.Contains(entity.TimeTableDisplayId)
                                        select new
                                            {
                                                entity.OpenTime,
                                                entity.CloseTime
                                            }).ToList();

            var serviceTime = timeTableDisplayList.Aggregate(string.Empty, (current, timeTableDisplay) => string.Format("{0} {1:t}-{2:t}", current, timeTableDisplay.OpenTime, timeTableDisplay.CloseTime));
            supplier.ServiceTime = serviceTime.Trim();

            return new ServicesResult<SupplierDetailModel>
            {
                Result = supplier
            };
        }

        /// <summary>
        /// 获取餐厅列表
        /// </summary>
        /// <param name="parameter">The parameter</param>
        /// <returns>
        /// 返回餐厅列表
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/15 17:56
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResultList<SupplierModel> GetSupplierList(GetSupplierListParameter parameter)
        {
            if (parameter == null)
            {
                return new ServicesResultList<SupplierModel>
                {
                    Result = new List<SupplierModel>(),
                    StatusCode = (int)StatusCode.System.InvalidRequest
                };
            }

            var list = this.supplierEntityRepository.NamedQuery(string.Format("Pro_QuerySupplierList{0}", (OrderBy.Supplier)parameter.OrderByType))
                    .SetInt32("FeatureID", parameter.FeatureId)
                    .SetString("SupplierName", parameter.SupplierName.IsEmptyOrNull() ? "%" : parameter.SupplierName)
                    .SetInt32("CuisineID", parameter.CuisineId)
                    .SetInt32("RegionId", parameter.RegionId)
                    .SetString("BusinessAreaId", parameter.BusinessAreaId)
                    .SetDouble("UserLat", parameter.UserLat)
                    .SetDouble("UserLong", parameter.UserLong)
                    .SetDouble("Distance", !parameter.Distance.HasValue ? -1.0 : parameter.Distance.Value)
                    .SetInt32("PageIndex", !parameter.PageIndex.HasValue ? -1 : parameter.PageIndex.Value)
                    .SetInt32("PageSize", parameter.PageSize)
                    .SetBoolean("IsBuilding", parameter.IsBuilding ?? false).List();

            var supplierList = (from object[] item in list
                                select new SupplierModel
                                    {
                                        SupplierId = item[0].ObjectToInt(),
                                        SupplierName = item[1].ObjectToString(),
                                        Address = item[2].ObjectToString(),
                                        Telephone = item[3].ObjectToString(),
                                        BaIduLat = item[4].ObjectToString(),
                                        BaIduLong = item[5].ObjectToString(),
                                        SupplierDescription = item[6].ObjectToString(),
                                        Averageprice = item[7].ObjectToDouble(),
                                        ParkingInfo = item[8].ObjectToString(),
                                        CuisineName = item[9].ObjectToString(),
                                        LogoUrl = string.Format("{0}/{1}", ServicesCommon.ImageSiteUrl, item[10].ObjectToString()),
                                        IsOpenDoor = item[11].ObjectToBoolean(),
                                        Distance = item[12].ObjectToDouble(),
                                        DateJoined = item[13].ObjectToDateTime()
                                    }).ToList();

            return new ServicesResultList<SupplierModel>
            {
                Result = supplierList
            };
        }

        /// <summary>
        /// 获取餐厅分店列表
        /// </summary>
        /// <param name="parameter">The parameter</param>
        /// <returns>
        /// 返回餐厅分店列表
        /// </returns>
        /// 创建者：周超
        /// 创建日期：10/22/2013 11:38 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResultList<GroupSupplierModel> GetGroupSupplierList(GetGroupSupplierListParameter parameter)
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

            var queryable = (from supplierEntity in this.supplierEntityRepository.EntityQueryable
                             where supplierEntity.SupplierGroupId == parameter.SupplierGroupId
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
                                 supplierEntity.DateJoined,
                                 supplierEntity.IsOpenDoor,
                                 supplierEntity.DefaultCuisineId
                             });

            var tempSupplierList = parameter.PageIndex == null ? queryable.ToList() : queryable.Skip(parameter.PageIndex.Value).Take(parameter.PageSize).ToList();
            if (tempSupplierList.Count == 0)
            {
                return new ServicesResultList<GroupSupplierModel>
                {
                    StatusCode = (int)StatusCode.Succeed.Empty,
                    Result = new List<GroupSupplierModel>()
                };
            }

            var supplierIdList = tempSupplierList.Select(p => p.SupplierId).ToList();
            var supplierFeatureList = this.supplierFeatureEntityRepository.EntityQueryable.Where(
                    p => supplierIdList.Contains(p.Supplier.SupplierId) && p.IsEnabled == true)
                    .Select(p => new { p.SupplierFeatureId, p.Supplier.SupplierId, p.Feature.Feature, p.Feature.FeatureId })
                    .ToList();

            var groupSupplierList = tempSupplierList.Select(item => new GroupSupplierModel
                    {
                        SupplierId = item.SupplierId,
                        SupplierName = item.SupplierName,
                        Address = item.Address,
                        Telephone = item.Telephone,
                        Averageprice = item.Averageprice,
                        ParkingInfo = item.ParkingInfo,
                        CuisineId = item.DefaultCuisineId,
                        DateJoined = item.DateJoined,
                        IsOpenDoor = item.IsOpenDoor,
                        SupplierDescription = item.SupplierDescription,
                        SupplierFeatureList = supplierFeatureList.Where(p => p.SupplierId == item.SupplierId).Select(p => new SupplierFeatureModel { FeatureId = p.FeatureId, FeatureName = p.Feature, SupplierFeatureId = p.SupplierFeatureId }).ToList()
                    }).ToList();

            return new ServicesResultList<GroupSupplierModel>
            {
                ResultTotalCount = groupSupplierList.Count,
                Result = groupSupplierList
            };
        }

        /// <summary>
        /// 获取餐厅菜单信息
        /// </summary>
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
        public ServicesResultList<SupplierCuisineModel> GetMenu(int supplierId, int supplierMenuCategoryTypeId)
        {
            if (!this.supplierEntityRepository.EntityQueryable.Any(p => p.SupplierId == supplierId))
            {
                return new ServicesResultList<SupplierCuisineModel>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidSupplierIdCode,
                    Result = new List<SupplierCuisineModel>()
                };
            }

            var supplierMenuCategoryId = this.supplierMenuCategoryEntityRepository.EntityQueryable.Where(p => p.SupplierId == supplierId && p.SupplierMenuCategoryType.SupplierMenuCategoryTypeId == supplierMenuCategoryTypeId).Select(p => p.SupplierMenuCategoryId).FirstOrDefault();
            var tempSupplierCategoryList = (from supplierCategoryEntity in this.supplierCategoryEntityRepository.EntityQueryable
                                            where supplierCategoryEntity.SupplierId == supplierId && supplierCategoryEntity.SupplierMenuCategoryId == supplierMenuCategoryId
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
                                        SupplierId = supplierDishEntity.Supplier == null ? 0 : supplierDishEntity.Supplier.SupplierId,
                                        ImagePath = string.Empty
                                    }).OrderBy(p => p.DishNo).ToList();

            var supplierDishIdList = supplierDishList.Select(p => p.SupplierDishId).ToList();
            var supplierDishImageList = (from entity in this.supplierDishImageEntityRepository.EntityQueryable
                                         where supplierDishIdList.Contains(entity.SupplierDishId) && entity.Online == true
                                         select new { entity.SupplierDishId, entity.ImagePath }).ToList();



            var list = new List<SupplierCuisineModel>();
            foreach (var supplierCategory in supplierCategoryList)
            {
                var categoryId = supplierCategory.CategoryId;
                if (list.Exists(p => p.CategoryId == categoryId))
                {
                    continue;
                }

                var dishList = (from supplierDishEntity in supplierDishList.Where(p => p.SupplierCategoryId == categoryId)
                                let supplierDishImage = supplierDishImageList.FirstOrDefault(p => p.SupplierDishId == supplierDishEntity.SupplierDishId)
                                select new SupplierDishModel
                                    {
                                        Price = supplierDishEntity.Price,
                                        ImagePath = string.Format("{0}/{1}", ServicesCommon.ImageSiteUrl, supplierDishImage == null ? string.Empty : supplierDishImage.ImagePath),
                                        SupplierDishId = supplierDishEntity.SupplierDishId,
                                        SupplierDishName = supplierDishEntity.SupplierDishName,
                                        SuppllierDishDescription = supplierDishEntity.SuppllierDishDescription,
                                        AverageRating = supplierDishEntity.AverageRating,
                                        IsCommission = supplierDishEntity.IsCommission,
                                        IsDiscount = supplierDishEntity.IsDiscount,
                                        Recipe = supplierDishEntity.Recipe,
                                        Recommended = supplierDishEntity.Recommended
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
        /// 获取餐厅菜品类型信息
        /// </summary>
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
        public ServicesResultList<SupplierCuisineDetailModel> GetSupplierCuisineList(int supplierId, int supplierMenuCategoryTypeId)
        {
            if (!this.supplierEntityRepository.EntityQueryable.Any(p => p.SupplierId == supplierId))
            {
                return new ServicesResultList<SupplierCuisineDetailModel>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidSupplierIdCode,
                    Result = new List<SupplierCuisineDetailModel>()
                };
            }

            var supplierMenuCategoryId = this.supplierMenuCategoryEntityRepository.EntityQueryable.Where(p => p.SupplierId == supplierId && p.SupplierMenuCategoryType.SupplierMenuCategoryTypeId == supplierMenuCategoryTypeId).Select(p => p.SupplierMenuCategoryId).FirstOrDefault();
            var tempSupplierCategoryList = (from supplierCategoryEntity in this.supplierCategoryEntityRepository.EntityQueryable
                                            where supplierCategoryEntity.SupplierId == supplierId && supplierCategoryEntity.SupplierMenuCategoryId == supplierMenuCategoryId
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
        public ServicesResult<SupplierCuisineDetailModel> GetSupplierCuisine(int supplierId, int supplierCategoryId)
        {
            if (!this.supplierEntityRepository.EntityQueryable.Any(p => p.SupplierId == supplierId))
            {
                return new ServicesResult<SupplierCuisineDetailModel>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidSupplierIdCode,
                    Result = new SupplierCuisineDetailModel()
                };
            }

            var tempSupplierCategory = (from supplierCategoryEntity in this.supplierCategoryEntityRepository.EntityQueryable
                                        where supplierCategoryEntity.SupplierCategoryId == supplierCategoryId && supplierCategoryEntity.SupplierId == supplierId
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
        /// <param name="parameter">The parameter</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/1/2013 4:43 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<bool> AddSupplierCuisine(SaveSupplierCuisineParameter parameter)
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

            if (!this.supplierMenuCategoryEntityRepository.EntityQueryable.Any(p => p.SupplierMenuCategoryType.SupplierMenuCategoryTypeId == parameter.SupplierMenuCategoryTypeId))
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
        /// <param name="parameter">The parameter</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/3/2013 10:32 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<bool> UpdateSupplierCuisine(SaveSupplierCuisineParameter parameter)
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

            if (!this.supplierMenuCategoryEntityRepository.EntityQueryable.Any(p => p.SupplierMenuCategoryType.SupplierMenuCategoryTypeId == parameter.SupplierMenuCategoryTypeId))
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
        /// <param name="parameter">The parameter</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/3/2013 10:32 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<bool> DeleteSupplierCuisine(DeleteSupplierCuisineParameter parameter)
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

            if (!this.supplierMenuCategoryEntityRepository.EntityQueryable.Any(p => p.SupplierMenuCategoryType.SupplierMenuCategoryTypeId == parameter.SupplierMenuCategoryTypeId))
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
        public ServicesResultList<SupplierDishDetailModel> GetSupplierDishList(int supplierId, int supplierMenuCategoryTypeId, int? supplierCategoryId)
        {
            if (!this.supplierEntityRepository.EntityQueryable.Any(p => p.SupplierId == supplierId))
            {
                return new ServicesResultList<SupplierDishDetailModel>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidSupplierIdCode,
                    Result = new List<SupplierDishDetailModel>()
                };
            }

            var supplierMenuCategoryId = this.supplierMenuCategoryEntityRepository.EntityQueryable.Where(p => p.SupplierId == supplierId && p.SupplierMenuCategoryType.SupplierMenuCategoryTypeId == supplierMenuCategoryTypeId).Select(p => p.SupplierMenuCategoryId).FirstOrDefault();
            var supplierCategoryQueryable = this.supplierCategoryEntityRepository.EntityQueryable.Where(
                  p => p.SupplierId == supplierId && p.SupplierMenuCategoryId == supplierMenuCategoryId);

            if (supplierCategoryId != null)
            {
                supplierCategoryQueryable = supplierCategoryQueryable.Where(p => p.SupplierCategoryId == supplierCategoryId);
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
                                        SupplierId = supplierDishEntity.Supplier == null ? 0 : supplierDishEntity.Supplier.SupplierId,
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
                                         where supplierDishIdList.Contains(entity.SupplierDishId) && entity.Online == true
                                         select new { entity.SupplierDishId, entity.ImagePath }).ToList();



            var list = new List<SupplierDishDetailModel>();
            foreach (var supplierCategory in supplierCategoryList)
            {
                var categoryId = supplierCategory.CategoryId;
                if (list.Exists(p => p.CategoryId == categoryId))
                {
                    continue;
                }

                var dishList = (from supplierDishEntity in supplierDishList.Where(p => p.SupplierCategoryId == categoryId)
                                let supplierDishImage = supplierDishImageList.FirstOrDefault(p => p.SupplierDishId == supplierDishEntity.SupplierDishId)
                                select new SupplierDishDetailModel
                                {
                                    Price = supplierDishEntity.Price,
                                    ImagePath = string.Format("{0}/{1}", ServicesCommon.ImageSiteUrl, supplierDishImage == null ? string.Empty : supplierDishImage.ImagePath),
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
        /// <param name="supplierId">餐厅Id</param>
        /// <param name="supplierDishId">The supplierDishId</param>
        /// <returns>
        /// 返回餐厅菜单信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/15 13:13
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<SupplierDishDetailModel> GetSupplierDish(int supplierId, int supplierDishId)
        {
            if (!this.supplierEntityRepository.EntityQueryable.Any(p => p.SupplierId == supplierId))
            {
                return new ServicesResult<SupplierDishDetailModel>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidSupplierIdCode,
                    Result = new SupplierDishDetailModel()
                };
            }

            var supplierDish = (from supplierDishEntity in this.supplierDishEntityRepository.EntityQueryable
                                where supplierDishEntity.Supplier.SupplierId == supplierId
                                && supplierDishEntity.Online && supplierDishEntity.IsDel == false
                                && supplierDishEntity.SupplierDishId == supplierDishId
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
                                    where supplierCategoryEntity.SupplierId == supplierId && supplierCategoryEntity.Category.CategoryId == supplierDish.SupplierCategoryId
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
        /// <param name="parameter">The parameter</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/1/2013 4:43 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<bool> AddSupplierDish(SaveSupplierDishParameter parameter)
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

            if (!this.supplierMenuCategoryEntityRepository.EntityQueryable.Any(p => p.SupplierMenuCategoryType.SupplierMenuCategoryTypeId == parameter.SupplierMenuCategoryTypeId))
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
        /// <param name="parameter">The parameter</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/3/2013 10:32 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<bool> UpdateSupplierDish(SaveSupplierDishParameter parameter)
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

            if (!this.supplierMenuCategoryEntityRepository.EntityQueryable.Any(p => p.SupplierMenuCategoryType.SupplierMenuCategoryTypeId == parameter.SupplierMenuCategoryTypeId))
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
        /// <param name="parameter">The parameter</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/3/2013 10:32 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<bool> DeleteSupplierDish(DeleteSupplierDishParameter parameter)
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
    }
}