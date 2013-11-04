namespace Ets.SingleApi.Services
{
    using Ets.SingleApi.Model;

    /// <summary>
    /// 类名称：BaiduMapDistance
    /// 命名空间：Ets.SingleApi.Services
    /// 类功能：根据百度地图计算距离
    /// </summary>
    /// 创建者：周超
    /// 创建日期：11/4/2013 3:50 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class BaiduMapDistance : IDistance
    {
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
        public Location GetLocation(string address, string city)
        {
            return null;
        }

        /// <summary>
        /// 计算距离
        /// </summary>
        /// <param name="locationA">The locationA</param>
        /// <param name="locationB">The locationB</param>
        /// <returns>
        /// 距离
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/4/2013 3:49 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public double GetDistance(Location locationA, Location locationB)
        {
            return 0;
        }
    }
}