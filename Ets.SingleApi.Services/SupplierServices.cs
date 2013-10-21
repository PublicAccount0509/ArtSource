namespace Ets.SingleApi.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Ets.SingleApi.Controllers.IServices;
    using Ets.SingleApi.Model;
    using Ets.SingleApi.Model.Repository;
    using Ets.SingleApi.Model.Services;
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
        /// 字段supplierDishEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：2013/10/20 10:34
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<SupplierDishEntity> supplierDishEntityRepository;

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
        /// 字段timeTableDisplayEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：2013/10/20 9:15
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<TimeTableDisplayEntity> timeTableDisplayEntityRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="SupplierServices" /> class.
        /// </summary>
        /// <param name="supplierEntityRepository">The supplierEntityRepository</param>
        /// <param name="supplierDishEntityRepository">The supplierDishEntityRepository</param>
        /// <param name="supplierCategoryEntityRepository">The supplierCategoryEntityRepository</param>
        /// <param name="supplierMenuCategoryEntityRepository">The supplierMenuCategoryEntityRepository</param>
        /// <param name="suppTimeTableDisplayEntityRepository">The suppTimeTableDisplayEntityRepository</param>
        /// <param name="timeTableDisplayEntityRepository">The timeTableDisplayEntityRepository</param>
        /// 创建者：周超
        /// 创建日期：2013/10/15 18:10
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public SupplierServices(
            INHibernateRepository<SupplierEntity> supplierEntityRepository,
            INHibernateRepository<SupplierDishEntity> supplierDishEntityRepository,
            INHibernateRepository<SupplierCategoryEntity> supplierCategoryEntityRepository,
            INHibernateRepository<SupplierMenuCategoryEntity> supplierMenuCategoryEntityRepository,
            INHibernateRepository<SuppTimeTableDisplayEntity> suppTimeTableDisplayEntityRepository,
            INHibernateRepository<TimeTableDisplayEntity> timeTableDisplayEntityRepository)
        {
            this.supplierEntityRepository = supplierEntityRepository;
            this.supplierDishEntityRepository = supplierDishEntityRepository;
            this.supplierCategoryEntityRepository = supplierCategoryEntityRepository;
            this.supplierMenuCategoryEntityRepository = supplierMenuCategoryEntityRepository;
            this.suppTimeTableDisplayEntityRepository = suppTimeTableDisplayEntityRepository;
            this.timeTableDisplayEntityRepository = timeTableDisplayEntityRepository;
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
                                        supplierEntity.Telephone
                                    }).FirstOrDefault();

            if (tempSupplier == null)
            {
                return new ServicesResult<SupplierDetailModel>
                    {
                        StatusCode = (int)StatusCode.Validate.InvalidSupplierIdCode,
                        Result = new SupplierDetailModel()
                    };
            }

            var supplier = new SupplierDetailModel
                {
                    SupplierId = tempSupplier.SupplierId,
                    SupplierName = tempSupplier.SupplierName,
                    SupplierDescription = tempSupplier.SupplierDescription,
                    ServiceTime = string.Empty,
                    Address = tempSupplier.Address,
                    Averageprice = tempSupplier.Averageprice,
                    ParkingInfo = tempSupplier.ParkingInfo,
                    Telephone = tempSupplier.Telephone
                };

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

            var orderBy = OrderBy.SupplierExpression((OrderBy.Supplier)parameter.OrderByType);
            var list = this.supplierEntityRepository.NamedQuery(parameter.Distance.HasValue ? "Pro_QuerySupplierListHasDistance" : "Pro_QuerySupplierList")
                    .SetString("SupplierName", parameter.SupplierName.IsEmptyOrNull() ? "%" : parameter.SupplierName)
                    .SetString("SupplierDishName", parameter.DishName.IsEmptyOrNull() ? "%" : parameter.DishName)
                    .SetInt32("CuisineID", parameter.CuisineId)
                    .SetString("BusinessAreaId", parameter.BusinessAreaId)
                    .SetString("RegionId", parameter.RegionId)
                    .SetDouble("UserLat", parameter.UserLat)
                    .SetDouble("UserLong", parameter.UserLong)
                    .SetDouble("Distance", !parameter.Distance.HasValue ? -1.0 : parameter.Distance.Value)
                    .SetInt32("PageIndex", !parameter.PageIndex.HasValue ? -1 : parameter.PageIndex.Value)
                    .SetInt32("PageSize", parameter.PageSize)
                    .SetString("OrderBy", orderBy).List();

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
                                        CuisineId = item[9].ObjectToInt32(),
                                        CuisineName = item[10].ObjectToString(),
                                        LogoUrl = item[11].ObjectToString(),
                                        IsOpenDoor = item[12].ObjectToBoolean(),
                                        Distance = item[13].ObjectToDouble(),
                                        DateJoined = item[14].ObjectToDateTime()
                                    }).ToList();

            return new ServicesResultList<SupplierModel>
            {
                Result = supplierList
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

            var supplierCategoryIdList = supplierCategoryList.Select(p => p.SupplierCategoryId).Distinct().Cast<int?>().ToList();
            var supplierCuisineList = (from supplierDishEntity in this.supplierDishEntityRepository.EntityQueryable
                                       where supplierDishEntity.Supplier.SupplierId == supplierId
                                       && supplierDishEntity.Online && supplierDishEntity.IsDel == false
                                       && supplierCategoryIdList.Contains(supplierDishEntity.SupplierCategoryId)
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
                                           ImagePath = supplierDishEntity.DishImage == null ? string.Empty : supplierDishEntity.DishImage.ImagePath,
                                       }).OrderBy(p => p.DishNo).ToList();

            var list = new List<SupplierCuisineModel>();
            foreach (var supplierCategory in supplierCategoryList)
            {
                if (list.Exists(p => p.CategoryId == supplierCategory.CategoryId))
                {
                    continue;
                }

                list.Add(new SupplierCuisineModel
                {
                    CategoryId = supplierCategory.CategoryId,
                    CategoryName = supplierCategory.CategoryName,
                    SupplierDishList = supplierCuisineList.Where(p => p.SupplierCategoryId == supplierCategory.SupplierCategoryId).Select(supplierDishEntity => new SupplierDishModel
                    {
                        Price = supplierDishEntity.Price,
                        ImagePath = supplierDishEntity.ImagePath,
                        SupplierDishId = supplierDishEntity.SupplierDishId,
                        SupplierDishName = supplierDishEntity.SupplierDishName,
                        SuppllierDishDescription = supplierDishEntity.SuppllierDishDescription,
                        AverageRating = supplierDishEntity.AverageRating,
                        IsCommission = supplierDishEntity.IsCommission,
                        IsDiscount = supplierDishEntity.IsDiscount,
                        Recipe = supplierDishEntity.Recipe,
                        Recommended = supplierDishEntity.Recommended
                    }).ToList()
                });
            }

            return new ServicesResultList<SupplierCuisineModel>
            {
                Result = list
            };
        }
    }
}