namespace Ets.SingleApi.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;

    using Ets.SingleApi.Controllers.IServices;
    using Ets.SingleApi.Model.Controller;
    using Ets.SingleApi.Utility;

    /// <summary>
    /// 类名称：BusinessAreaController
    /// 命名空间：Ets.SingleApi.Controllers
    /// 类功能：业务商圈API
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/13 11:18
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class BusinessAreaController : SingleApiController
    {
        /// <summary>
        /// 字段businessAreaServices
        /// </summary>
        /// 创建者：周超
        /// 创建日期：2013/10/13 11:18
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private readonly IBusinessAreaServices businessAreaServices;

        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessAreaController"/> class.
        /// </summary>
        /// <param name="businessAreaServices">The businessAreaServices</param>
        /// 创建者：周超
        /// 创建日期：2013/10/13 11:18
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public BusinessAreaController(IBusinessAreaServices businessAreaServices)
        {
            this.businessAreaServices = businessAreaServices;
        }

        /// <summary>
        /// 获取区域和商圈信息列表
        /// </summary>
        /// <returns>
        /// 返回区域和商圈信息列表
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/13 12:33
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [HttpGet]
        public ListResponse<BusinessArea> BusinessAreaList(string parentCode = null)
        {
            var list = this.businessAreaServices.GetAllBusinessAreaList((parentCode ?? string.Empty).Trim());
            if (list.Result == null || list.Result.Count == 0)
            {
                return new ListResponse<BusinessArea>
                    {
                        Message = new ApiMessage
                            {
                                StatusCode = list.StatusCode == (int)StatusCode.Succeed.Ok ? (int)StatusCode.Succeed.Empty : list.StatusCode
                            },
                        Result = new List<BusinessArea>()
                    };
            }

            var result = list.Result.Select(p => new BusinessArea
                    {
                        Id = (p.Id ?? string.Empty),
                        Name = (p.Name ?? string.Empty),
                        Code = (p.Code ?? string.Empty),
                        Depth = p.Depth,
                        ParentCode = (p.ParentCode ?? string.Empty)
                    }).ToList();

            return new ListResponse<BusinessArea>
                {
                    Message = new ApiMessage
                    {
                        StatusCode = list.StatusCode
                    },
                    ResultTotalCount = list.ResultTotalCount,
                    Result = result
                };
        }
    }
}