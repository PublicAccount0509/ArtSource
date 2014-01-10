namespace Ets.SingleApi.Hosting.Contracts
{
    using System.ComponentModel;
    using System.ServiceModel;

    using Ets.SingleApi.Model;
    using Ets.SingleApi.Model.Controller;

    /// <summary>
    /// 接口名称：IFunctionService
    /// 命名空间：Ets.SingleApi.Hosting.Contracts
    /// 接口功能：Function服务
    /// </summary>
    /// 创建者：周超
    /// 创建日期：12/9/2013 3:06 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    [ServiceContract]
    public interface IFunctionService
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
        [OperationContract]
        [Description("方法功能：根据地址取得对应坐标；参数说明：type（默认值为0 Baidu定位）")]
        Response<Location> Location(string address, string city, int type);

        /// <summary>
        /// 根据坐标取得对应地址
        /// </summary>
        /// <param name="userLat">The userLat</param>
        /// <param name="userLong">The userLong</param>
        /// <param name="type">定位类型</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/15/2013 1:25 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [OperationContract]
        [Description("方法功能：根据坐标取得对应地址；参数说明：type（默认值为0 Baidu定位）")]
        Response<LocationCity> LocationCity(double userLat, double userLong, int type);
    }
}