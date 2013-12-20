namespace Ets.SingleApi.Services
{
    using System.Linq;

    using Ets.SingleApi.Controllers.IServices;
    using Ets.SingleApi.Model.Repository;
    using Ets.SingleApi.Model.Services;
    using Ets.SingleApi.Services.IRepository;
    using Ets.SingleApi.Utility;

    /// <summary>
    /// 类名称：BaiDuLightServices
    /// 命名空间：Ets.SingleApi.Services
    /// 类功能：百度轻应用功能
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/17 22:17
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class BaiDuLightServices : IBaiDuLightServices
    {
        /// <summary>
        /// 字段baiDuAppLightEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：12/20/2013 12:17 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<BaiDuAppLightEntity> baiDuAppLightEntityRepository;

        /// <summary>
        /// 字段supplierGroupLightEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：12/20/2013 12:17 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<SupplierGroupLightEntity> supplierGroupLightEntityRepository;

        /// <summary>
        /// 字段supplierGroupTemplateEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：12/20/2013 12:17 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<SupplierGroupTemplateEntity> supplierGroupTemplateEntityRepository;

        /// <summary>
        /// 字段supplierGroupLogoImageEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：12/20/2013 12:18 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<SupplierGroupLogoImageEntity> supplierGroupLogoImageEntityRepository;

        /// <summary>
        /// 字段supplierGroupFeatureEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：12/20/2013 12:18 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<SupplierGroupFeatureEntity> supplierGroupFeatureEntityRepository;

        /// <summary>
        /// 字段supplierGroupAdvertisementEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：12/20/2013 12:18 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<SupplierGroupAdvertisementEntity> supplierGroupAdvertisementEntityRepository;

        /// <summary>
        /// 字段featureEntityRepository
        /// </summary>
        /// 创建者：周超
        /// 创建日期：12/20/2013 1:40 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly INHibernateRepository<FeatureEntity> featureEntityRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaiDuLightServices"/> class.
        /// </summary>
        /// <param name="baiDuAppLightEntityRepository">The baiDuAppLightEntityRepository</param>
        /// <param name="supplierGroupLightEntityRepository">The supplierGroupLightEntityRepository</param>
        /// <param name="supplierGroupTemplateEntityRepository">The supplierGroupTemplateEntityRepository</param>
        /// <param name="supplierGroupLogoImageEntityRepository">The supplierGroupLogoImageEntityRepository</param>
        /// <param name="supplierGroupFeatureEntityRepository">The supplierGroupFeatureEntityRepository</param>
        /// <param name="supplierGroupAdvertisementEntityRepository">The supplierGroupAdvertisementEntityRepository</param>
        /// <param name="featureEntityRepository">The featureEntityRepository</param>
        /// <param name="?">The ?</param>
        /// 创建者：周超
        /// 创建日期：12/20/2013 12:17 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public BaiDuLightServices(
            INHibernateRepository<BaiDuAppLightEntity> baiDuAppLightEntityRepository,
            INHibernateRepository<SupplierGroupLightEntity> supplierGroupLightEntityRepository,
            INHibernateRepository<SupplierGroupTemplateEntity> supplierGroupTemplateEntityRepository,
            INHibernateRepository<SupplierGroupLogoImageEntity> supplierGroupLogoImageEntityRepository,
            INHibernateRepository<SupplierGroupFeatureEntity> supplierGroupFeatureEntityRepository,
            INHibernateRepository<SupplierGroupAdvertisementEntity> supplierGroupAdvertisementEntityRepository,
            INHibernateRepository<FeatureEntity> featureEntityRepository)
        {
            this.baiDuAppLightEntityRepository = baiDuAppLightEntityRepository;
            this.supplierGroupLightEntityRepository = supplierGroupLightEntityRepository;
            this.supplierGroupTemplateEntityRepository = supplierGroupTemplateEntityRepository;
            this.supplierGroupLogoImageEntityRepository = supplierGroupLogoImageEntityRepository;
            this.supplierGroupFeatureEntityRepository = supplierGroupFeatureEntityRepository;
            this.supplierGroupAdvertisementEntityRepository = supplierGroupAdvertisementEntityRepository;
            this.featureEntityRepository = featureEntityRepository;
        }

        /// <summary>
        /// 获取轻应用程序Id
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="applicationId">百度应用程序Id</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：12/20/2013 12:37 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<string> GetLightApplicationId(string source, string applicationId)
        {
            if (applicationId.IsEmptyOrNull())
            {
                return new ServicesResult<string>
                {
                    Result = string.Empty,
                    StatusCode = (int)StatusCode.System.InvalidRequest
                };
            }

            var result = this.baiDuAppLightEntityRepository.FindSingleByExpression(p => p.ApplicationId == applicationId && p.IsDelete == false);
            if (result == null)
            {
                return new ServicesResult<string>
                    {
                        Result = string.Empty,
                        StatusCode = (int)StatusCode.Validate.InvalidApplicationId
                    };
            }

            return new ServicesResult<string>
            {
                Result = result.LightApplicationId.ToString(),
                StatusCode = (int)StatusCode.Succeed.Ok
            };
        }

        /// <summary>
        /// 获取轻应用餐厅或集团模板信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="applicationId">百度应用程序Id</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/17 22:11
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<LightSupplierTemplateModel> GetLightSupplierTemplate(string source, string applicationId)
        {
            if (applicationId.IsEmptyOrNull())
            {
                return new ServicesResult<LightSupplierTemplateModel>
                {
                    Result = new LightSupplierTemplateModel(),
                    StatusCode = (int)StatusCode.System.InvalidRequest
                };
            }

            if (!this.baiDuAppLightEntityRepository.EntityQueryable.Any(p => p.ApplicationId == applicationId))
            {
                return new ServicesResult<LightSupplierTemplateModel>
                {
                    Result = new LightSupplierTemplateModel(),
                    StatusCode = (int)StatusCode.Validate.InvalidApplicationId
                };
            }

            var supplierGroupTemplate = (from entity in this.supplierGroupTemplateEntityRepository.EntityQueryable
                                         where entity.LightApplication.ApplicationId == applicationId && entity.LightApplication.IsDelete == false
                                         select new LightSupplierTemplateModel
                                                 {
                                                     LightApplicationId = entity.LightApplication.LightApplicationId,
                                                     SupplierTypeId = entity.SupplierTypeId,
                                                     TemplateColorId = entity.TemplateColorId,
                                                     TemplateTypeId = entity.TemplateTypeId
                                                 }).FirstOrDefault();

            if (supplierGroupTemplate == null)
            {
                return new ServicesResult<LightSupplierTemplateModel>
                {
                    Result = new LightSupplierTemplateModel(),
                    StatusCode = (int)StatusCode.Validate.InvalidApplicationId
                };
            }

            return new ServicesResult<LightSupplierTemplateModel>
                {
                    Result = supplierGroupTemplate,
                    StatusCode = (int)StatusCode.Succeed.Ok
                };
        }

        /// <summary>
        /// 获取轻应用餐厅或集团信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="applicationId">百度应用程序Id</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/17 22:11
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<LightSupplierModel> GetLightSupplier(string source, string applicationId)
        {
            if (applicationId.IsEmptyOrNull())
            {
                return new ServicesResult<LightSupplierModel>
                {
                    Result = new LightSupplierModel(),
                    StatusCode = (int)StatusCode.System.InvalidRequest
                };
            }

            if (!this.baiDuAppLightEntityRepository.EntityQueryable.Any(p => p.ApplicationId == applicationId))
            {
                return new ServicesResult<LightSupplierModel>
                {
                    Result = new LightSupplierModel(),
                    StatusCode = (int)StatusCode.Validate.InvalidApplicationId
                };
            }

            var supplierGroupLight = (from entity in this.supplierGroupLightEntityRepository.EntityQueryable
                                      where entity.LightApplication.ApplicationId == applicationId && entity.LightApplication.IsDelete == false
                                      select new LightSupplierModel
                                      {
                                          LightApplicationId = entity.LightApplication.LightApplicationId,
                                          LogoUrl = string.Format("{0}/{1}", ServicesCommon.ImageSiteUrl, entity.LogoUrl),
                                          Name = entity.Name,
                                          SupplierGroupLightId = entity.SupplierGroupLightId
                                      }).FirstOrDefault();

            if (supplierGroupLight == null)
            {
                return new ServicesResult<LightSupplierModel>
                {
                    Result = new LightSupplierModel(),
                    StatusCode = (int)StatusCode.Validate.InvalidApplicationId
                };
            }

            var supplierGroupLightId = supplierGroupLight.SupplierGroupLightId;
            supplierGroupLight.AdvertisementUrlList = (from entity in this.supplierGroupAdvertisementEntityRepository.EntityQueryable
                                                       where entity.SupplierGroupLight.SupplierGroupLightId == supplierGroupLightId && entity.IsDetele == false
                                                       select string.Format("{0}/{1}", ServicesCommon.ImageSiteUrl, entity.ImagePath)).ToList();

            supplierGroupLight.LightFeatureList = (from entity in this.supplierGroupFeatureEntityRepository.EntityQueryable
                                                   from feature in this.featureEntityRepository.EntityQueryable
                                                   where entity.SupplierGroupLight.SupplierGroupLightId == supplierGroupLightId
                                                   && entity.FeatureId == feature.FeatureId
                                                   select new LightFeatureModel
                                                   {
                                                       SupplierGroupFeatureId = entity.Id,
                                                       FeatureId = feature.FeatureId,
                                                       FeatureName = feature.Feature
                                                   }).ToList();

            return new ServicesResult<LightSupplierModel>
            {
                Result = supplierGroupLight,
                StatusCode = (int)StatusCode.Succeed.Ok
            };
        }

        /// <summary>
        /// 获取轻应用餐厅或集团详细信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="applicationId">百度应用程序Id</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/17 22:11
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public ServicesResult<LightSupplierDetailModel> GetLightSupplierDetail(string source, string applicationId)
        {
            if (applicationId.IsEmptyOrNull())
            {
                return new ServicesResult<LightSupplierDetailModel>
                {
                    Result = new LightSupplierDetailModel(),
                    StatusCode = (int)StatusCode.System.InvalidRequest
                };
            }

            if (!this.baiDuAppLightEntityRepository.EntityQueryable.Any(p => p.ApplicationId == applicationId))
            {
                return new ServicesResult<LightSupplierDetailModel>
                {
                    Result = new LightSupplierDetailModel(),
                    StatusCode = (int)StatusCode.Validate.InvalidApplicationId
                };
            }

            var supplierGroupLight = (from entity in this.supplierGroupLightEntityRepository.EntityQueryable
                                      where entity.LightApplication.ApplicationId == applicationId && entity.LightApplication.IsDelete == false
                                      select new LightSupplierDetailModel
                                      {
                                          LightApplicationId = entity.LightApplication.LightApplicationId,
                                          LogoUrl = string.Format("{0}/{1}", ServicesCommon.ImageSiteUrl, entity.LogoUrl),
                                          Name = entity.Name,
                                          Description = entity.Description,
                                          BrandStory = entity.BrandStory,
                                          ServiceNote = entity.ServiceNote,
                                          TargetId = entity.TargetId,
                                          Telphone = entity.Telphone,
                                          RecommendDishes = entity.RecommendDishes,
                                          SupplierGroupLightId = entity.SupplierGroupLightId
                                      }).FirstOrDefault();

            if (supplierGroupLight == null)
            {
                return new ServicesResult<LightSupplierDetailModel>
                {
                    Result = new LightSupplierDetailModel(),
                    StatusCode = (int)StatusCode.Validate.InvalidApplicationId
                };
            }

            var supplierGroupLightId = supplierGroupLight.SupplierGroupLightId;
            supplierGroupLight.SupplierUrlList = (from entity in this.supplierGroupLogoImageEntityRepository.EntityQueryable
                                                  where entity.SupplierGroupLight.SupplierGroupLightId == supplierGroupLightId && entity.IsDelete == false
                                                  select string.Format("{0}/{1}", ServicesCommon.ImageSiteUrl, entity.ImagePath)).ToList();

            supplierGroupLight.AdvertisementUrlList = (from entity in this.supplierGroupAdvertisementEntityRepository.EntityQueryable
                                                       where entity.SupplierGroupLight.SupplierGroupLightId == supplierGroupLightId && entity.IsDetele == false
                                                       select string.Format("{0}/{1}", ServicesCommon.ImageSiteUrl, entity.ImagePath)).ToList();

            supplierGroupLight.LightFeatureList = (from entity in this.supplierGroupFeatureEntityRepository.EntityQueryable
                                                   from feature in this.featureEntityRepository.EntityQueryable
                                                   where entity.SupplierGroupLight.SupplierGroupLightId == supplierGroupLightId
                                                   && entity.FeatureId == feature.FeatureId
                                                   select new LightFeatureModel
                                                   {
                                                       SupplierGroupFeatureId = entity.Id,
                                                       FeatureId = feature.FeatureId,
                                                       FeatureName = feature.Feature
                                                   }).ToList();

            return new ServicesResult<LightSupplierDetailModel>
            {
                Result = supplierGroupLight,
                StatusCode = (int)StatusCode.Succeed.Ok
            };
        }
    }
}