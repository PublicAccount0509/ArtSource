using Ets.SingleApi.Controllers.IServices;
using Ets.SingleApi.Model.Controller;
using Ets.SingleApi.Model.Repository;
using Ets.SingleApi.Model.Services;
using Ets.SingleApi.Services.IDetailServices;
using Ets.SingleApi.Services.IRepository;
using Ets.SingleApi.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ets.SingleApi.Services
{
    public class HuangTaiJiSupplierServices : IHuangTaiJiSupplierServices
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

        //新增
        private readonly INHibernateRepository<OptionGroupEntity> optionGroupEntityRepository;
        private readonly INHibernateRepository<CustomizationOptionEntity> customizationOptionEntityRepository;
        private readonly INHibernateRepository<SupplierDishCustomizationEntity> supplierDishCustomizationEntityRepository;
        private readonly INHibernateRepository<SupplierDishGroupEntity> supplierDishGroupEntityRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="HuangTaiJiSupplierServices" /> class.
        /// </summary>
        /// <param name="supplierEntityRepository">The supplierEntityRepository</param>
        /// <param name="supplierImageEntityRepository">The supplierImageEntityRepository</param>
         /// <param name="supplierDishEntityRepository">The supplierDishEntityRepository</param>
        /// <param name="supplierDishImageEntityRepository">The supplierDishImageEntityRepository</param>
        /// <param name="supplierCategoryEntityRepository">The supplierCategoryEntityRepository</param>
        /// <param name="supplierMenuCategoryEntityRepository">The supplierMenuCategoryEntityRepository</param>
        /// <param name="optionGroupEntityRepository">The optionGroupEntityRepository</param>
        /// <param name="customizationOptionEntityRepository">The customizationOptionEntityRepository</param>
        /// <param name="supplierDishCustomizationEntityRepository">The supplierDishCustomizationEntityRepository</param>
        /// <param name="supplierDishGroupEntityRepository">The supplierDishGroupEntityRepository</param>
        /// 创建者：殷超
        /// 创建日期：2013/12/25 18:10
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public HuangTaiJiSupplierServices(
            INHibernateRepository<SupplierEntity> supplierEntityRepository,
            INHibernateRepository<SupplierImageEntity> supplierImageEntityRepository,
            INHibernateRepository<SupplierDishEntity> supplierDishEntityRepository,
            INHibernateRepository<SupplierDishImageEntity> supplierDishImageEntityRepository,
            INHibernateRepository<SupplierCategoryEntity> supplierCategoryEntityRepository,
            INHibernateRepository<SupplierMenuCategoryEntity> supplierMenuCategoryEntityRepository,
            INHibernateRepository<OptionGroupEntity> optionGroupEntityRepository,
            INHibernateRepository<CustomizationOptionEntity> customizationOptionEntityRepository,
            INHibernateRepository<SupplierDishCustomizationEntity> supplierDishCustomizationEntityRepository,
            INHibernateRepository<SupplierDishGroupEntity> supplierDishGroupEntityRepository)
        {
            this.supplierEntityRepository = supplierEntityRepository;
            this.supplierImageEntityRepository = supplierImageEntityRepository;
            this.supplierDishEntityRepository = supplierDishEntityRepository;
            this.supplierDishImageEntityRepository = supplierDishImageEntityRepository;
            this.supplierCategoryEntityRepository = supplierCategoryEntityRepository;
            this.supplierMenuCategoryEntityRepository = supplierMenuCategoryEntityRepository;
            this.optionGroupEntityRepository = optionGroupEntityRepository;
            this.customizationOptionEntityRepository = customizationOptionEntityRepository;
            this.supplierDishCustomizationEntityRepository = supplierDishCustomizationEntityRepository;
            this.supplierDishGroupEntityRepository = supplierDishGroupEntityRepository;
        }


        public ServicesResult<HuangTaiJiSupplierDishDetail> GetSupplierDish(string source, int supplierId, int supplierDishId)
        {
            //if (!this.supplierEntityRepository.EntityQueryable.Any(p => p.SupplierId == supplierId))
            //{
            //    return new ServicesResult<HuangTaiJiSupplierDishDetail>
            //    {
            //        StatusCode = (int)StatusCode.Validate.InvalidSupplierIdCode,
            //        Result = new HuangTaiJiSupplierDishDetail()
            //    };
            //}

            return getSupplierDishDetailCascade(supplierId, supplierDishId);
        }

        // 得到本菜单的配菜信息
        private ServicesResultList<HuangTaiJiSupplierDishOptionGroup> getSupplierDishOptionGroup(int? supplierDishId)
        {
            // 得到本菜单的配菜信息
            var supplierDishCustomization = (from entity in this.supplierDishCustomizationEntityRepository.EntityQueryable
                                             where entity.SupplierDishId == supplierDishId
                                             select new
                                             {
                                                 entity.SupplierDishId,
                                                 entity.OptionGroupId,
                                                 entity.IsDropdown,
                                                 entity.MaxValue,
                                                 entity.MinValue
                                             }).ToList();
            var list = new List<HuangTaiJiSupplierDishOptionGroup>();
            foreach (var customization in supplierDishCustomization)
            {
                var optionGroupId = customization.OptionGroupId;
                var supplierDishOptionGroup = (from entity in this.optionGroupEntityRepository.EntityQueryable
                                               where entity.OptionGroupId == optionGroupId
                                               select new
                                               {
                                                   entity.OptionGroupTitle,
                                                   entity.IsMultiple,
                                                   entity.Description
                                               }).FirstOrDefault();
                var customizationOption = (from entity in this.customizationOptionEntityRepository.EntityQueryable
                                           where entity.OptionGroup.OptionGroupId == optionGroupId
                                           select new HuangTaiJiSupplierDishCustomizationOption
                                           {
                                               SupplierDishCustomizationOptionId = entity.OptionId,
                                               SupplierDishOptionTitle = entity.OptionTitle,
                                               SupplierDishPrice = entity.Price,
                                               SupplierDishOptionGroupId = optionGroupId
                                           }).ToList();

                HuangTaiJiSupplierDishOptionGroup supplierDishOptionGroupResult = new HuangTaiJiSupplierDishOptionGroup
                {
                    SupplierDishCustomizationOption = customizationOption,
                    SupplierDishId = supplierDishId,
                    SupplierDishOptionGroupId = optionGroupId,
                    SupplierDishOptionGroupTitle = supplierDishOptionGroup.OptionGroupTitle,
                    SupplierDishOptionGroupIsMultiple = supplierDishOptionGroup.IsMultiple,
                    IsDropDown = customization.IsDropdown,
                    MaxValue = customization.MaxValue,
                    MinValue = customization.MinValue
                };
                list.Add(supplierDishOptionGroupResult);
            }

            // 成功返回
            return new ServicesResultList<HuangTaiJiSupplierDishOptionGroup>
            {
                Result = list
            };
        }

        // 循环处理子菜单，同时子菜单的配菜信息，支持多级级联递归
        private ServicesResult<HuangTaiJiSupplierDishDetail> getSupplierDishDetailCascade(int supplierId, int? supplierDishId)
        {
            if (supplierDishId == null)
            {
                return new ServicesResult<HuangTaiJiSupplierDishDetail>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidSupplierDishIdCode,
                    Result = new HuangTaiJiSupplierDishDetail()
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
                return new ServicesResult<HuangTaiJiSupplierDishDetail>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidSupplierDishIdCode,
                    Result = new HuangTaiJiSupplierDishDetail()
                };
            }

            var supplierDishImage = (from entity in this.supplierDishImageEntityRepository.EntityQueryable
                                     where entity.SupplierDishId == supplierDishId && entity.Online == true
                                     select new { entity.SupplierDishId, entity.ImagePath }).FirstOrDefault();

            var subSupplierDishDetail = new List<HuangTaiJiSupplierDishDetail>();
            // 获取关联SupplierDishGroup
            // 暂时黄太极不需要支持子菜单功能
            //var supplierDishGroup = (from entity in this.supplierDishGroupEntityRepository.EntityQueryable
            //                         where entity.MainSupplierDish == supplierDishId
            //                         select new { entity.MainSupplierDish, entity.SubSupplierDish }).ToList();

            //foreach (var subSupplierDishGroup in supplierDishGroup)
                
            //{
            //    int? SubSupplierDish = subSupplierDishGroup.SubSupplierDish;  
            //    ServicesResult<HuangTaiJiSupplierDishDetail> result = getSupplierDishDetailCascade(supplierId, SubSupplierDish);
                // 返回ok
            //    if (result.StatusCode == (int)StatusCode.Succeed.Ok)
            //    {
            //        subSupplierDishDetail.Add(result.Result);
            //    }
            //}
            //var subSupplierDishIdList = supplierDishGroup.Select(p => p.SubSupplierDish).Distinct().Cast<int?>().ToList();

            // 得到本菜单的配菜信息
            var supplierDishCustomization = getSupplierDishOptionGroup(supplierDishId);

            var supplierCategory = (from supplierCategoryEntity in this.supplierCategoryEntityRepository.EntityQueryable
                                    where supplierCategoryEntity.SupplierId == supplierId && supplierCategoryEntity.Category.CategoryId == supplierDish.SupplierCategoryId
                                    select new
                                    {
                                        supplierCategoryEntity.Category.CategoryId,
                                        supplierCategoryEntity.Category.CategoryName,
                                        supplierCategoryEntity.SupplierId,
                                        supplierCategoryEntity.SupplierCategoryId
                                    }).FirstOrDefault();

            var results = new HuangTaiJiSupplierDishDetail
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
                PackagingFee = supplierDish.PackagingFee,
                SupplierCategoryId = supplierCategory == null ? 0 : supplierCategory.SupplierCategoryId,
                CategoryId = supplierCategory == null ? 0 : supplierCategory.CategoryId,
                CategoryName = supplierCategory == null ? string.Empty : supplierCategory.CategoryName,
                // 增加子菜单
                SubSupplierDishDetail = subSupplierDishDetail,
                // 增加菜单的配菜
                SupplierDishOptionGroups = supplierDishCustomization.Result
            };

            return new ServicesResult<HuangTaiJiSupplierDishDetail>
            {
                Result = results
            };
        }

        public ServicesResultList<HuangTaiJiSupplierDishDetail> GetSupplierDishList(string source, int supplierId, int supplierMenuCategoryTypeId, int? supplierCategoryId)
        {
            if (!this.supplierEntityRepository.EntityQueryable.Any(p => p.SupplierId == supplierId))
            {
                return new ServicesResultList<HuangTaiJiSupplierDishDetail>
                {
                    StatusCode = (int)StatusCode.Validate.InvalidSupplierIdCode,
                    Result = new List<HuangTaiJiSupplierDishDetail>()
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

            var result = new List<HuangTaiJiSupplierDishDetail>();
            var supplierDishList = (from supplierDishEntity in this.supplierDishEntityRepository.EntityQueryable
                                    where supplierDishEntity.Supplier.SupplierId == supplierId
                                    && supplierDishEntity.Online && supplierDishEntity.IsDel == false
                                    && categoryIdList.Contains(supplierDishEntity.SupplierCategoryId)
                                    select new
                                    {
                                        //supplierDishEntity.SupplierCategoryId,
                                        supplierDishEntity.DishNo,
                                        //supplierDishEntity.Price,
                                        supplierDishEntity.SupplierDishId
                                        //supplierDishEntity.SupplierDishName,
                                        //supplierDishEntity.SuppllierDishDescription,
                                        //supplierDishEntity.SpicyLevel,
                                        //supplierDishEntity.AverageRating,
                                        //supplierDishEntity.IsCommission,
                                        //supplierDishEntity.IsDiscount,
                                        //supplierDishEntity.Recipe,
                                        //supplierDishEntity.Recommended,
                                        //SupplierId = supplierDishEntity.Supplier == null ? 0 : supplierDishEntity.Supplier.SupplierId,
                                        //supplierDishEntity.HasNuts,
                                        //supplierDishEntity.IsDel,
                                        //supplierDishEntity.IsSpecialOffer,
                                        //supplierDishEntity.JianPin,
                                        //supplierDishEntity.Online,
                                        //supplierDishEntity.PackagingFee,
                                        //supplierDishEntity.QuanPin,
                                        //supplierDishEntity.SpecialOfferNo,
                                        //supplierDishEntity.StockLevel,
                                        //supplierDishEntity.Vegetarian,
                                        //ImagePath = string.Empty
                                    }).OrderBy(p => p.DishNo).ToList();

            var supplierDishIdList = supplierDishList.Select(p => p.SupplierDishId).ToList();

            foreach (var supplierDishId in supplierDishIdList) 
            {
                ServicesResult<HuangTaiJiSupplierDishDetail> detail = GetSupplierDish(source, supplierId, supplierDishId);
                // 返回ok
                if (detail.StatusCode == (int)StatusCode.Succeed.Ok)
                {
                    result.Add(detail.Result);
                }
            }
            
            return new ServicesResultList<HuangTaiJiSupplierDishDetail>
            {
                ResultTotalCount = result.Count,
                Result = result
            };
        }

        //public ServicesResultList<HuangTaiJiSupplierDishDetail> GetSupplierDishList(string source, int supplierId, int supplierMenuCategoryTypeId, int? supplierCategoryId)
        //{
        //    if (!this.supplierEntityRepository.EntityQueryable.Any(p => p.SupplierId == supplierId))
        //    {
        //        return new ServicesResultList<HuangTaiJiSupplierDishDetail>
        //        {
        //            StatusCode = (int)StatusCode.Validate.InvalidSupplierIdCode,
        //            Result = new List<HuangTaiJiSupplierDishDetail>()
        //        };
        //    }

        //    var supplierMenuCategoryId = this.supplierMenuCategoryEntityRepository.EntityQueryable.Where(p => p.SupplierId == supplierId && p.SupplierMenuCategoryType.SupplierMenuCategoryTypeId == supplierMenuCategoryTypeId).Select(p => p.SupplierMenuCategoryId).FirstOrDefault();
        //    var supplierCategoryQueryable = this.supplierCategoryEntityRepository.EntityQueryable.Where(
        //          p => p.SupplierId == supplierId && p.SupplierMenuCategoryId == supplierMenuCategoryId);

        //    if (supplierCategoryId != null)
        //    {
        //        supplierCategoryQueryable = supplierCategoryQueryable.Where(p => p.SupplierCategoryId == supplierCategoryId);
        //    }

        //    var tempSupplierCategoryList = (from supplierCategoryEntity in supplierCategoryQueryable
        //                                    select new
        //                                    {
        //                                        supplierCategoryEntity.Category,
        //                                        supplierCategoryEntity.SupplierId,
        //                                        supplierCategoryEntity.SupplierCategoryId
        //                                    }).ToList();

        //    var supplierCategoryList = (from entity in tempSupplierCategoryList
        //                                where entity.Category != null
        //                                select new
        //                                {
        //                                    entity.Category.CategoryId,
        //                                    entity.Category.CategoryName,
        //                                    entity.Category.CategoryNo,
        //                                    entity.SupplierId,
        //                                    entity.SupplierCategoryId
        //                                }).OrderBy(p => p.CategoryNo).ToList();

        //    var categoryIdList = supplierCategoryList.Select(p => p.CategoryId).Distinct().Cast<int?>().ToList();
        //    var supplierDishList = (from supplierDishEntity in this.supplierDishEntityRepository.EntityQueryable
        //                            where supplierDishEntity.Supplier.SupplierId == supplierId
        //                            && supplierDishEntity.Online && supplierDishEntity.IsDel == false
        //                            && categoryIdList.Contains(supplierDishEntity.SupplierCategoryId)
        //                            select new
        //                            {
        //                                supplierDishEntity.SupplierCategoryId,
        //                                supplierDishEntity.DishNo,
        //                                supplierDishEntity.Price,
        //                                supplierDishEntity.SupplierDishId,
        //                                supplierDishEntity.SupplierDishName,
        //                                supplierDishEntity.SuppllierDishDescription,
        //                                supplierDishEntity.SpicyLevel,
        //                                supplierDishEntity.AverageRating,
        //                                supplierDishEntity.IsCommission,
        //                                supplierDishEntity.IsDiscount,
        //                                supplierDishEntity.Recipe,
        //                                supplierDishEntity.Recommended,
        //                                SupplierId = supplierDishEntity.Supplier == null ? 0 : supplierDishEntity.Supplier.SupplierId,
        //                                supplierDishEntity.HasNuts,
        //                                supplierDishEntity.IsDel,
        //                                supplierDishEntity.IsSpecialOffer,
        //                                supplierDishEntity.JianPin,
        //                                supplierDishEntity.Online,
        //                                supplierDishEntity.PackagingFee,
        //                                supplierDishEntity.QuanPin,
        //                                supplierDishEntity.SpecialOfferNo,
        //                                supplierDishEntity.StockLevel,
        //                                supplierDishEntity.Vegetarian,
        //                                ImagePath = string.Empty
        //                            }).OrderBy(p => p.DishNo).ToList();

        //    var supplierDishIdList = supplierDishList.Select(p => p.SupplierDishId).ToList();
        //    var supplierDishImageList = (from entity in this.supplierDishImageEntityRepository.EntityQueryable
        //                                 where supplierDishIdList.Contains(entity.SupplierDishId) && entity.Online == true
        //                                 select new { entity.SupplierDishId, entity.ImagePath }).ToList();



        //    var list = new List<HuangTaiJiSupplierDishDetail>();
        //    foreach (var supplierCategory in supplierCategoryList)
        //    {
        //        var categoryId = supplierCategory.CategoryId;
        //        if (list.Exists(p => p.CategoryId == categoryId))
        //        {
        //            continue;
        //        }

        //        var dishList = (from supplierDishEntity in supplierDishList.Where(p => p.SupplierCategoryId == categoryId)
        //                        let supplierDishImage = supplierDishImageList.FirstOrDefault(p => p.SupplierDishId == supplierDishEntity.SupplierDishId)
        //                        select new HuangTaiJiSupplierDishDetail
        //                        {
        //                            Price = supplierDishEntity.Price,
        //                            ImagePath = string.Format("{0}/{1}", ServicesCommon.ImageSiteUrl, supplierDishImage == null ? string.Empty : supplierDishImage.ImagePath),
        //                            SupplierDishId = supplierDishEntity.SupplierDishId,
        //                            DishName = supplierDishEntity.SupplierDishName,
        //                            DishDescription = supplierDishEntity.SuppllierDishDescription,
        //                            AverageRating = supplierDishEntity.AverageRating,
        //                            IsCommission = supplierDishEntity.IsCommission,
        //                            IsDiscount = supplierDishEntity.IsDiscount,
        //                            Recipe = supplierDishEntity.Recipe,
        //                            Recommended = supplierDishEntity.Recommended,
        //                            CategoryId = categoryId,
        //                            CategoryName = supplierCategory.CategoryName,
        //                            DishNo = supplierDishEntity.DishNo,
        //                            HasNuts = supplierDishEntity.HasNuts,
        //                            IsDel = supplierDishEntity.IsDel,
        //                            IsSpecialOffer = supplierDishEntity.IsSpecialOffer,
        //                            JianPin = supplierDishEntity.JianPin,
        //                            Online = supplierDishEntity.Online,
        //                            PackagingFee = supplierDishEntity.PackagingFee,
        //                            QuanPin = supplierDishEntity.QuanPin,
        //                            SpecialOfferNo = supplierDishEntity.SpecialOfferNo,
        //                            SpicyLevel = supplierDishEntity.SpicyLevel,
        //                            StockLevel = supplierDishEntity.StockLevel,
        //                            SupplierCategoryId = supplierCategory.SupplierCategoryId,
        //                            SupplierId = supplierCategory.SupplierId,
        //                            Vegetarian = supplierDishEntity.Vegetarian
        //                        }).ToList();

        //        list.AddRange(dishList);
        //    }

        //    return new ServicesResultList<HuangTaiJiSupplierDishDetail>
        //    {
        //        ResultTotalCount = list.Count,
        //        Result = list
        //    };
        //}
    }
}
