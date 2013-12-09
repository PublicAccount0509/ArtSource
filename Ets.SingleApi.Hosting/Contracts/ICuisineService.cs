namespace Ets.SingleApi.Hosting.Contracts
{
    using System.ComponentModel;
    using System.ServiceModel;

    using Ets.SingleApi.Model.Controller;

    /// <summary>
    /// 接口名称：ICuisineService
    /// 命名空间：Ets.SingleApi.Hosting.Contracts
    /// 接口功能：Cuisine服务
    /// </summary>
    /// 创建者：周超
    /// 创建日期：12/9/2013 3:06 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    [ServiceContract]
    public interface ICuisineService
    {
        /// <summary>
        /// 获取菜品列表
        /// </summary>
        /// <returns>
        /// 返回菜品列表
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/14 21:45
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [OperationContract]
        [Description("获取菜品列表")]
        ListResponse<Cuisine> CuisineList();

        /// <summary>
        /// 获取菜品列表
        /// </summary>
        /// <param name="cityId">城市Id</param>
        /// <returns>
        /// 返回菜品列表
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/14 21:45
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [OperationContract]
        [Description("根据城市Id获取菜品列表")]
        ListResponse<Cuisine> CityCuisineList(string cityId);
    }
}