namespace Ets.SingleApi.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Ets.SingleApi.Controllers.IServices;
    using Ets.SingleApi.Model.Repository;
    using Ets.SingleApi.Model.Services;
    using Ets.SingleApi.Services.IRepository;
    using Ets.SingleApi.Utility;

    /// <summary>
    /// 类名称：HaiDiLaoSupplierServices
    /// 命名空间：Ets.SingleApi.Services
    /// 类功能：海底捞餐厅功能
    /// </summary>
    /// 创建者：周超
    /// 创建日期：12/18/2013 2:41 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class HaiDiLaoSupplierServices : IHaiDiLaoSupplierServices
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
        /// 字段packageNameEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：12/18/2013 11:46 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<PackageNameEntity> packageNameEntityRepository;

        /// <summary>
        /// 字段packageClassificationEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：12/18/2013 3:48 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<PackageClassificationEntity> packageClassificationEntityRepository;

        /// <summary>
        /// 字段packageContentEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：12/18/2013 3:48 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<PackageContentEntity> packageContentEntityRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="HaiDiLaoSupplierServices" /> class.
        /// </summary>
        /// <param name="supplierEntityRepository">The supplierEntityRepository</param>
        /// <param name="supplierDishEntityRepository">The supplierDishEntityRepository</param>
        /// <param name="supplierDishImageEntityRepository">The supplierDishImageEntityRepository</param>
        /// <param name="supplierCategoryEntityRepository">The supplierCategoryEntityRepository</param>
        /// <param name="supplierMenuCategoryEntityRepository">The supplierMenuCategoryEntityRepository</param>
        /// <param name="packageNameEntityRepository">The packageNameEntityRepository</param>
        /// <param name="packageClassificationEntityRepository">The packageClassificationEntityRepository</param>
        /// <param name="packageContentEntityRepository">The packageContentEntityRepository</param>
        /// 创建者：周超
        /// 创建日期：2013/10/15 18:10
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public HaiDiLaoSupplierServices(
            INHibernateRepository<SupplierEntity> supplierEntityRepository,
            INHibernateRepository<SupplierDishEntity> supplierDishEntityRepository,
            INHibernateRepository<SupplierDishImageEntity> supplierDishImageEntityRepository,
            INHibernateRepository<SupplierCategoryEntity> supplierCategoryEntityRepository,
            INHibernateRepository<SupplierMenuCategoryEntity> supplierMenuCategoryEntityRepository,
            INHibernateRepository<PackageNameEntity> packageNameEntityRepository,
            INHibernateRepository<PackageClassificationEntity> packageClassificationEntityRepository,
            INHibernateRepository<PackageContentEntity> packageContentEntityRepository)
        {
            this.supplierEntityRepository = supplierEntityRepository;
            this.supplierDishEntityRepository = supplierDishEntityRepository;
            this.supplierDishImageEntityRepository = supplierDishImageEntityRepository;
            this.supplierCategoryEntityRepository = supplierCategoryEntityRepository;
            this.supplierMenuCategoryEntityRepository = supplierMenuCategoryEntityRepository;
            this.packageNameEntityRepository = packageNameEntityRepository;
            this.packageClassificationEntityRepository = packageClassificationEntityRepository;
            this.packageContentEntityRepository = packageContentEntityRepository;
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
        public ServicesResultList<SupplierCuisineModel> GetMenu(string source, int supplierId, int supplierMenuCategoryTypeId)
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
                                        }).OrderBy(p => p.CategoryNo).ToList().Where(p => !ServicesCommon.HaiDiLaoNoContainMenuList.Contains((p.CategoryName ?? string.Empty).Trim())).ToList();

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

            var packageList = (from entity in this.packageNameEntityRepository.EntityQueryable
                               where entity.SupplierId == supplierId && entity.IsEnabled == true
                               select new
                                   {
                                       Price = entity.PackagePrice,
                                       ImagePath = string.Format("{0}/{1}", ServicesCommon.ImageSiteUrl, entity.ImageUrl),
                                       SupplierDishId = entity.PackageId,
                                       SupplierDishName = entity.PackageNames,
                                       SuppllierDishDescription = entity.PackageNote,
                                   }).ToList();


            var packageSupplierDishList = packageList.Select(p => new SupplierDishModel
            {
                Price = p.Price ?? 0,
                ImagePath = p.ImagePath,
                SupplierDishId = p.SupplierDishId,
                SupplierDishName = p.SupplierDishName,
                SuppllierDishDescription = p.SuppllierDishDescription,
            }).ToList();

            var resultList = new List<SupplierCuisineModel>();
            foreach (var name in ServicesCommon.HaiDiLaoFrontMenuList)
            {
                var tempName = (name ?? string.Empty).Trim();
                var item = list.FirstOrDefault(
                        p => string.Equals((p.CategoryName ?? string.Empty).Trim(), tempName, StringComparison.OrdinalIgnoreCase));
                if (item == null)
                {
                    continue;
                }

                resultList.Add(item);
            }

            resultList.AddRange(list.Where(p => !ServicesCommon.HaiDiLaoFrontMenuList.Contains((p.CategoryName ?? string.Empty).Trim()) && !ServicesCommon.HaiDiLaoEndMenuList.Contains((p.CategoryName ?? string.Empty).Trim())).ToList());
            foreach (var name in ServicesCommon.HaiDiLaoEndMenuList)
            {
                var tempName = (name ?? string.Empty).Trim();
                var item = list.FirstOrDefault(
                        p => string.Equals((p.CategoryName ?? string.Empty).Trim(), tempName, StringComparison.OrdinalIgnoreCase));
                if (item == null)
                {
                    continue;
                }

                if (string.Equals(ServicesCommon.HaiDiLaoPackageMenu.Trim(), tempName, StringComparison.OrdinalIgnoreCase))
                {
                    item.SupplierDishList = packageSupplierDishList;
                }

                resultList.Add(item);
            }

            foreach (var item in resultList)
            {
                var tempName = (item.CategoryName ?? string.Empty).Trim();
                var type = ServicesCommon.MenuTypeList.Keys.Contains(tempName) ? ServicesCommon.MenuTypeList[tempName] : 0;
                foreach (var dish in item.SupplierDishList)
                {
                    dish.Type = type;
                }
            }

            return new ServicesResultList<SupplierCuisineModel>
            {
                ResultTotalCount = resultList.Count,
                Result = resultList
            };
        }

        /// <summary>
        /// 获取套餐详细信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="supplierId">餐厅Id</param>
        /// <param name="packageId">套餐Id</param>
        /// <returns>
        /// 返回套餐详细信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/15 13:13
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResultList<PackageCuisineModel> GetPackageDetail(string source, int supplierId, int packageId)
        {
            if (!this.supplierEntityRepository.EntityQueryable.Any(p => p.SupplierId == supplierId))
            {
                return new ServicesResultList<PackageCuisineModel>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidSupplierIdCode,
                    Result = new List<PackageCuisineModel>()
                };
            }

            if (!this.packageNameEntityRepository.EntityQueryable.Any(p => p.SupplierId == supplierId && p.PackageId == packageId))
            {
                return new ServicesResultList<PackageCuisineModel>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidPackageId,
                    Result = new List<PackageCuisineModel>()
                };
            }

            var packageClassificationList = (from entity in this.packageClassificationEntityRepository.EntityQueryable
                                             where entity.SupplierId == supplierId && entity.PackageId == packageId
                                             && entity.IsEnabled == true
                                             select new
                                             {
                                                 CategoryId = entity.PackageClassificationId,
                                                 CategoryName = entity.ClassificationName,
                                                 CanSelectCount = entity.ClassificationNum,
                                                 entity.IsChoose
                                             }).ToList();

            if (packageClassificationList.Count == 0)
            {
                return new ServicesResultList<PackageCuisineModel>
                {
                    Result = new List<PackageCuisineModel>()
                };
            }

            var categoryIdList = packageClassificationList.Select(p => p.CategoryId).Distinct().ToList();
            var packageContentList = (from entity in this.packageContentEntityRepository.EntityQueryable
                                      where categoryIdList.Contains(entity.PackageClassificationId)
                                      select new
                                      {
                                          CategoryId = entity.PackageClassificationId,
                                          entity.PackageContentId,
                                          CanSelectCount = entity.SelectNumber,
                                          entity.SupplierDish
                                      }).ToList();

            var supplierDishList = (from item in packageContentList.Where(p => p.SupplierDish != null).ToList()
                                    let supplierDishEntity = item.SupplierDish
                                    where supplierDishEntity.Online && supplierDishEntity.IsDel == false
                                    select new
                                    {
                                        item.CategoryId,
                                        item.PackageContentId,
                                        item.CanSelectCount,
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
                                        SupplierId = supplierDishEntity.Supplier == null ? 0 : supplierDishEntity.Supplier.SupplierId,
                                        ImagePath = string.Empty
                                    }).OrderBy(p => p.DishNo).ToList();

            var supplierDishIdList = supplierDishList.Select(p => p.SupplierDishId).ToList();
            var supplierDishImageList = (from entity in this.supplierDishImageEntityRepository.EntityQueryable
                                         where supplierDishIdList.Contains(entity.SupplierDishId) && entity.Online == true
                                         select new { entity.SupplierDishId, entity.ImagePath }).ToList();

            var list = new List<PackageCuisineModel>();
            foreach (var supplierCategory in packageClassificationList)
            {
                var categoryId = supplierCategory.CategoryId;
                if (list.Exists(p => p.CategoryId == categoryId))
                {
                    continue;
                }

                var dishList = (from supplierDishEntity in supplierDishList.Where(p => p.CategoryId == categoryId)
                                let supplierDishImage = supplierDishImageList.FirstOrDefault(p => p.SupplierDishId == supplierDishEntity.SupplierDishId)
                                select new PackageDishModel
                                {
                                    PackageContentId = supplierDishEntity.PackageContentId,
                                    CanSelectCount = supplierDishEntity.CanSelectCount,
                                    Price = supplierDishEntity.Price,
                                    ImagePath = string.Format("{0}/{1}", ServicesCommon.ImageSiteUrl, supplierDishImage == null ? string.Empty : supplierDishImage.ImagePath),
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

                list.Add(new PackageCuisineModel
                {
                    CategoryId = supplierCategory.CategoryId,
                    CategoryName = supplierCategory.CategoryName,
                    CanSelectCount = supplierCategory.CanSelectCount,
                    IsChoose = supplierCategory.IsChoose,
                    PackageDishList = dishList
                });
            }

            foreach (var item in list)
            {
                var tempName = (item.CategoryName ?? string.Empty).Trim();
                var type = ServicesCommon.MenuTypeList.Keys.Contains(tempName) ? ServicesCommon.MenuTypeList[tempName] : 0;
                foreach (var dish in item.PackageDishList)
                {
                    dish.Type = type;
                }
            }

            return new ServicesResultList<PackageCuisineModel>
            {
                ResultTotalCount = list.Count,
                Result = list
            };
        }
    }
}