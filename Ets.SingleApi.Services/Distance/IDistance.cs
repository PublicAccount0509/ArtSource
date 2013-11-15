namespace Ets.SingleApi.Services
{
    using Ets.SingleApi.Model;

    /// <summary>
    /// 接口名称：IDistance
    /// 命名空间：Ets.SingleApi.Services
    /// 接口功能：计算距离
    /// </summary>
    /// 创建者：周超
    /// 创建日期：11/4/2013 3:42 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public interface IDistance
    {
        /// <summary>
        /// 定位类型
        /// </summary>
        /// <value>
        /// 定位类型
        /// </value>
        /// 创建者：周超
        /// 创建日期：11/15/2013 1:33 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        LocationType LocationType { get; }

        /// <summary>
        /// 获取地址经纬度
        /// </summary>
        /// <param name="address">The address</param>
        /// <param name="city">The city</param>
        /// <returns>
        /// 经纬度
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/4/2013 3:49 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        Location GetLocation(string address, string city);

        /// <summary>
        /// 计算距离
        /// </summary>
        /// <param name="locationA">The locationA</param>
        /// <param name="locationB">The locationB</param>
        /// <param name="gs">The gs</param>
        /// <returns>
        /// 距离
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/4/2013 3:49 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        double GetDistance(Location locationA, Location locationB, GaussSphere gs);
    }
}