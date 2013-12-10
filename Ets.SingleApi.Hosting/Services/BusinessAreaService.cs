﻿namespace Ets.SingleApi.Hosting.Services
{
    using System.ServiceModel.Activation;
    using System.ServiceModel.Web;

    using Ets.SingleApi.Hosting.Contracts;
    using Ets.SingleApi.Model.Controller;

    /// <summary>
    /// 类名称：BusinessAreaService
    /// 命名空间：Ets.SingleApi.Hosting.Services
    /// 类功能：BusinessArea服务
    /// </summary>
    /// 创建者：周超
    /// 创建日期：12/9/2013 3:08 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class BusinessAreaService : IBusinessAreaService
    {
        /// <summary>
        /// 获取区域和商圈信息列表
        /// </summary>
        /// <param name="parentCode">区域或商圈父节点Id</param>
        /// <returns>
        /// 返回区域和商圈信息列表
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/13 12:33
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [WebGet(UriTemplate = "/BusinessAreaList?parentCode={parentCode}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public ListResponse<BusinessArea> BusinessAreaList(string parentCode)
        {
            return new ListResponse<BusinessArea>();
        }
    }
}