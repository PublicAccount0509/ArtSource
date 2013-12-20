namespace Ets.SingleApi.Controllers.IServices
{
    using Ets.SingleApi.Model.Services;

    /// <summary>
    /// 接口名称：IBaiDuLightServices
    /// 命名空间：Ets.SingleApi.Controllers.IServices
    /// 接口功能：百度轻应用功能接口
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/17 22:09
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public interface IBaiDuLightServices
    {
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
        ServicesResult<string> GetLightApplicationId(string source, string applicationId);

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
        ServicesResult<LightSupplierTemplateModel> GetLightSupplierTemplate(string source, string applicationId);

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
        ServicesResult<LightSupplierModel> GetLightSupplier(string source, string applicationId);

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
        ServicesResult<LightSupplierDetailModel> GetLightSupplierDetail(string source, string applicationId);
    }
}