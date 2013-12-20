namespace Ets.SingleApi.Hosting.Contracts
{
    using System.ComponentModel;
    using System.ServiceModel;

    using Ets.SingleApi.Model.Controller;

    /// <summary>
    /// 接口名称：IBaiDuLightService
    /// 命名空间：Ets.SingleApi.Hosting.Contracts
    /// 接口功能：百度轻应用服务
    /// </summary>
    /// 创建者：周超
    /// 创建日期：12/9/2013 3:06 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    [ServiceContract]
    public interface IBaiDuLightService
    {
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
        [OperationContract]
        [Description("方法功能：获取轻应用程序Id；参数说明：applicationId（百度提供的Id）")]
        Response<string> LightApplicationId(string applicationId);

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
        [OperationContract]
        [Description("方法功能：获取轻应用餐厅或集团模板信息；参数说明：applicationId（百度提供的Id）")]
        Response<LightSupplierTemplate> LightSupplierTemplate(string applicationId);

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
        [OperationContract]
        [Description("方法功能：获取轻应用餐厅或集团信息；参数说明：applicationId（百度提供的Id）")]
        Response<LightSupplier> LightSupplier(string applicationId);

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
        [OperationContract]
        [Description("方法功能：获取轻应用餐厅或集团详细信息；参数说明：applicationId（百度提供的Id）")]
        Response<LightSupplierDetail> LightSupplierDetail(string applicationId);
    }
}