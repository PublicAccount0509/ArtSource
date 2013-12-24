namespace Ets.SingleApi.Controllers
{
    using System.Linq;
    using System.Web.Http;

    using Ets.SingleApi.Controllers.IServices;
    using Ets.SingleApi.Model.Controller;
    using Ets.SingleApi.Utility;

    /// <summary>
    /// 类名称：BaiDuLightController
    /// 命名空间：Ets.SingleApi.Controllers
    /// 类功能：百度轻应用关联控制器
    /// </summary>
    /// 创建者：周超
    /// 创建日期：11/15/2013 1:13 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class BaiDuLightController : SingleApiController
    {
        /// <summary>
        /// 字段baiDuLightServices
        /// </summary>
        /// 创建者：周超
        /// 创建日期：11/15/2013 1:21 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly IBaiDuLightServices baiDuLightServices;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaiDuLightController"/> class.
        /// </summary>
        /// <param name="baiDuLightServices">The baiDuLightServices</param>
        /// 创建者：周超
        /// 创建日期：11/15/2013 1:21 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public BaiDuLightController(IBaiDuLightServices baiDuLightServices)
        {
            this.baiDuLightServices = baiDuLightServices;
        }

        /// <summary>
        /// 获取轻应用程序Id
        /// </summary>
        /// <param name="applicationId">百度应用程序Id</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：12/20/2013 12:37 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpGet]
        public Response<string> LightApplicationId(string applicationId)
        {
            if (applicationId.IsEmptyOrNull())
            {
                return new Response<string>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = (int)StatusCode.General.InvalidRequest
                    },
                    Result = string.Empty
                };
            }

            var getLightApplicationIdResult = this.baiDuLightServices.GetLightApplicationId(this.Source, applicationId);
            if (getLightApplicationIdResult.Result == null)
            {
                return new Response<string>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = getLightApplicationIdResult.StatusCode == (int)StatusCode.Succeed.Ok ? (int)StatusCode.Succeed.Empty : getLightApplicationIdResult.StatusCode
                    },
                    Result = string.Empty
                };
            }

            return new Response<string>
            {
                Message = new ApiMessage
                {
                    StatusCode = getLightApplicationIdResult.StatusCode
                },
                Result = getLightApplicationIdResult.Result
            };
        }

        /// <summary>
        /// 获取轻应用餐厅或集团模板信息
        /// </summary>
        /// <param name="applicationId">百度应用程序Id</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/17 22:11
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpGet]
        public Response<LightSupplierTemplate> LightSupplierTemplate(string applicationId)
        {
            if (applicationId.IsEmptyOrNull())
            {
                return new Response<LightSupplierTemplate>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = (int)StatusCode.General.InvalidRequest
                    },
                    Result = new LightSupplierTemplate()
                };
            }

            var getLightSupplierTemplateResult = this.baiDuLightServices.GetLightSupplierTemplate(this.Source, applicationId);
            if (getLightSupplierTemplateResult.Result == null)
            {
                return new Response<LightSupplierTemplate>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = getLightSupplierTemplateResult.StatusCode == (int)StatusCode.Succeed.Ok ? (int)StatusCode.Succeed.Empty : getLightSupplierTemplateResult.StatusCode
                    },
                    Result = new LightSupplierTemplate()
                };
            }

            var result = new LightSupplierTemplate
                {
                    LightApplicationId = getLightSupplierTemplateResult.Result.LightApplicationId,
                    SupplierTypeId = getLightSupplierTemplateResult.Result.SupplierTypeId,
                    TemplateColorId = getLightSupplierTemplateResult.Result.TemplateColorId,
                    TemplateTypeId = getLightSupplierTemplateResult.Result.TemplateTypeId,
                    TemplateStyleId = getLightSupplierTemplateResult.Result.TemplateStyleId
                };

            return new Response<LightSupplierTemplate>
            {
                Message = new ApiMessage
                {
                    StatusCode = getLightSupplierTemplateResult.StatusCode
                },
                Result = result
            };
        }

        /// <summary>
        /// 获取轻应用餐厅或集团信息
        /// </summary>
        /// <param name="applicationId">百度应用程序Id</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/17 22:11
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpGet]
        public Response<LightSupplier> LightSupplier(string applicationId)
        {
            if (applicationId.IsEmptyOrNull())
            {
                return new Response<LightSupplier>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = (int)StatusCode.General.InvalidRequest
                    },
                    Result = new LightSupplier()
                };
            }

            var getLightSupplierResult = this.baiDuLightServices.GetLightSupplier(this.Source, applicationId);
            if (getLightSupplierResult.Result == null)
            {
                return new Response<LightSupplier>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = getLightSupplierResult.StatusCode == (int)StatusCode.Succeed.Ok ? (int)StatusCode.Succeed.Empty : getLightSupplierResult.StatusCode
                    },
                    Result = new LightSupplier()
                };
            }

            var result = new LightSupplier
            {
                SupplierGroupLightId = getLightSupplierResult.Result.SupplierGroupLightId,
                LightApplicationId = getLightSupplierResult.Result.LightApplicationId,
                LogoUrl = getLightSupplierResult.Result.LogoUrl ?? string.Empty,
                Name = getLightSupplierResult.Result.Name ?? string.Empty,
                AdvertisementUrlList = getLightSupplierResult.Result.AdvertisementUrlList,
                LightFeatureList = getLightSupplierResult.Result.LightFeatureList.Select(p => new LightFeature
                    {
                        SupplierGroupFeatureId = p.SupplierGroupFeatureId,
                        FeatureId = p.FeatureId,
                        FeatureName = p.FeatureName
                    }).ToList()
            };

            return new Response<LightSupplier>
            {
                Message = new ApiMessage
                {
                    StatusCode = getLightSupplierResult.StatusCode
                },
                Result = result
            };
        }

        /// <summary>
        /// 获取轻应用餐厅或集团详细信息
        /// </summary>
        /// <param name="applicationId">百度应用程序Id</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/17 22:11
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpGet]
        public Response<LightSupplierDetail> LightSupplierDetail(string applicationId)
        {
            if (applicationId.IsEmptyOrNull())
            {
                return new Response<LightSupplierDetail>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = (int)StatusCode.General.InvalidRequest
                    },
                    Result = new LightSupplierDetail()
                };
            }

            var getLightSupplierDetailResult = this.baiDuLightServices.GetLightSupplierDetail(this.Source, applicationId);
            if (getLightSupplierDetailResult.Result == null)
            {
                return new Response<LightSupplierDetail>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = getLightSupplierDetailResult.StatusCode == (int)StatusCode.Succeed.Ok ? (int)StatusCode.Succeed.Empty : getLightSupplierDetailResult.StatusCode
                    },
                    Result = new LightSupplierDetail()
                };
            }

            var result = new LightSupplierDetail
            {
                SupplierGroupLightId = getLightSupplierDetailResult.Result.SupplierGroupLightId,
                LightApplicationId = getLightSupplierDetailResult.Result.LightApplicationId,
                TargetId = getLightSupplierDetailResult.Result.TargetId,
                Telphone = getLightSupplierDetailResult.Result.Telphone ?? string.Empty,
                LogoUrl = getLightSupplierDetailResult.Result.LogoUrl ?? string.Empty,
                Name = getLightSupplierDetailResult.Result.Name ?? string.Empty,
                Description = getLightSupplierDetailResult.Result.Description ?? string.Empty,
                ServiceNote = getLightSupplierDetailResult.Result.ServiceNote ?? string.Empty,
                BrandStory = getLightSupplierDetailResult.Result.BrandStory ?? string.Empty,
                SupplierUrlList = getLightSupplierDetailResult.Result.SupplierUrlList,
                AdvertisementUrlList = getLightSupplierDetailResult.Result.AdvertisementUrlList,
                LightFeatureList = getLightSupplierDetailResult.Result.LightFeatureList.Select(p => new LightFeature
                {
                    SupplierGroupFeatureId = p.SupplierGroupFeatureId,
                    FeatureId = p.FeatureId,
                    FeatureName = p.FeatureName
                }).ToList(),
                RecommendDisheList = getLightSupplierDetailResult.Result.RecommendDishes.Split(',').ToList()
            };

            return new Response<LightSupplierDetail>
            {
                Message = new ApiMessage
                {
                    StatusCode = getLightSupplierDetailResult.StatusCode
                },
                Result = result
            };
        }
    }
}