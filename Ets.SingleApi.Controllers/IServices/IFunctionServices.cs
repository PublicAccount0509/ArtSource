namespace Ets.SingleApi.Controllers.IServices
{
    using Ets.SingleApi.Model;
    using Ets.SingleApi.Model.Services;

    /// <summary>
    /// 接口名称：IFunctionServices
    /// 命名空间：Ets.SingleApi.Controllers.IServices
    /// 接口功能：公用功能
    /// </summary>
    /// 创建者：周超
    /// 创建日期：11/15/2013 1:19 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public interface IFunctionServices
    {
        /// <summary>
        /// 根据地址取得对应坐标
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="address">楼宇地址</param>
        /// <param name="city">当前城市</param>
        /// <param name="type">定位类型</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/15/2013 1:20 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResult<Location> GetLocation(string source, string address, string city, int type);

        /// <summary>
        /// 根据坐标取得对应地址
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="userLat">The userLat</param>
        /// <param name="userLong">The userLong</param>
        /// <param name="type">定位类型</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/15/2013 1:20 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        ServicesResult<LocationCityModel> GetLocationCity(string source, double userLat, double userLong, int type);
    }
}