namespace Ets.SingleApi.Controllers.IServices
{
    using Ets.SingleApi.Model.Services;

    /// <summary>
    /// 接口名称：ICuisineServices
    /// 命名空间：Ets.SingleApi.Controllers.IServices
    /// 接口功能：提供菜系信息
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/13 15:18
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public interface ICuisineServices
    {
        /// <summary>
        /// 获取菜品信息列表
        /// </summary>
        /// <param name="source">The source</param>
        /// <returns>
        /// 返回菜品信息列表
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/13 15:19
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResultList<CuisineModel> GetCuisineList(string source);

        /// <summary>
        /// 获取菜品信息列表
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="cityId">城市Id</param>
        /// <returns>
        /// 返回菜品信息列表
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/13 15:19
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResultList<CuisineModel> GetCityCuisineList(string source, int cityId);

        /// <summary>
        /// 获取菜品信息
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="id">菜品Id</param>
        /// <param name="cuisineName">菜品名称</param>
        /// <returns>
        /// 返回菜品信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：5/16/2014 6:20 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResult<CuisineModel> GetCuisine(string source, int id, string cuisineName);
    }
}