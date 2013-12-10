﻿namespace Ets.SingleApi.Hosting.Services
{
    using System.ServiceModel.Activation;
    using System.ServiceModel.Web;

    using Ets.SingleApi.Hosting.Contracts;
    using Ets.SingleApi.Model;
    using Ets.SingleApi.Model.Controller;

    /// <summary>
    /// 类名称：FunctionService
    /// 命名空间：Ets.SingleApi.Hosting.Services
    /// 类功能：Function服务
    /// </summary>
    /// 创建者：周超
    /// 创建日期：12/9/2013 3:08 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class FunctionService : IFunctionService
    {
        /// <summary>
        /// 根据地址取得对应坐标
        /// </summary>
        /// <param name="address">楼宇地址</param>
        /// <param name="city">当前城市</param>
        /// <param name="type">定位类型</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/15/2013 1:25 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [WebGet(UriTemplate = "/Location?address={address}&city={city}&type={type}", ResponseFormat = WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Bare)]
        public Response<Location> Location(string address, string city, int type)
        {
            return new Response<Location>();
        }
    }
}