namespace Ets.SingleApi.Hosting.Contracts
{
    using System.ComponentModel;
    using System.ServiceModel;

    using Ets.SingleApi.Model.Controller;

    /// <summary>
    /// 接口名称：IBusinessAreaService
    /// 命名空间：Ets.SingleApi.Hosting.Contracts
    /// 接口功能：BusinessArea服务
    /// </summary>
    /// 创建者：周超
    /// 创建日期：12/9/2013 3:06 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    [ServiceContract]
    public interface IBusinessAreaService
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
        [OperationContract]
        [Description("方法功能：获取区域和商圈信息列表")]
        ListResponse<BusinessArea> BusinessAreaList(string parentCode);

        /// <summary>
        /// 获取已开通城市列表
        /// </summary>
        /// <returns>
        /// 返回已开通城市列表
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/13 12:33
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [OperationContract]
        [Description("方法功能：获取已开通城市列表")]
        ListResponse<BusinessArea> OpenCityList(string parentCode = null);

        /// <summary>
        /// 获取地区和商圈信息列表
        /// </summary>
        /// <param name="parentCode">父节点code</param>
        /// <returns>
        /// 返回地区和商圈信息列表
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/13 10:23
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [OperationContract]
        [Description("方法功能：获取地区和商圈信息列表")]
        ListResponse<BusinessArea> RegionBusinessAreaList(string parentCode = null);

        /// <summary>
        /// 获取商圈信息
        /// </summary>
        /// <param name="id">商圈Id</param>
        /// <param name="businessAreaName">商圈名称</param>
        /// <returns>
        /// 返回商圈信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：5/16/2014 5:09 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [OperationContract]
        [Description("方法功能：获取商圈信息")]
        Response<BusinessArea> BusinessArea(string id, string businessAreaName);

        /// <summary>
        /// 获取区域信息
        /// </summary>
        /// <param name="id">区域Id</param>
        /// <param name="regionName">区域名称</param>
        /// <returns>
        /// 返回区域信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：5/16/2014 5:09 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [OperationContract]
        [Description("方法功能：获取区域信息")]
        Response<BusinessArea> Region(string id, string regionName);
    }
}