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
        [Description("获取区域和商圈信息列表")]
        ListResponse<BusinessArea> BusinessAreaList(string parentCode);
    }
}