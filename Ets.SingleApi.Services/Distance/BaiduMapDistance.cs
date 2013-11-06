namespace Ets.SingleApi.Services
{
    using System;
    using System.Json;
    using System.Net;
    using System.Web;

    using Ets.SingleApi.Model;
    using Ets.SingleApi.Utility;

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
            var url = city.IsEmptyOrNull()
                          ? string.Format("http://api.map.baidu.com/geocoder/v2/?ak={0}&output=json&address={1}", ServicesCommon.BaiduMapAk, HttpUtility.UrlEncode(address))
                          : string.Format("http://api.map.baidu.com/geocoder/v2/?ak={0}&output=json&address={1}&city={2}", ServicesCommon.BaiduMapAk, HttpUtility.UrlEncode(address), HttpUtility.UrlEncode(city));

            string result;
            using (var cliect = new WebClient())
            {
                var content = cliect.DownloadString(url);
                result = HttpUtility.UrlDecode(content) ?? string.Empty;
            }

            if (result.IsEmptyOrNull())
            {
                return null;
            }

            //{"status":0,"result":[]}
            //{"status":0,"result":{"location":{"lng":116.48336573873,"lat":39.909466006532},"precise":1,"confidence":70,"level":"\u5730\u4ea7\u5c0f\u533a"}}
            var jsonValue = JsonValue.Parse(result);
            if (jsonValue == null || jsonValue["result"] == null)
            {
                return null;
            }

            if (jsonValue["result"].JsonType == JsonType.Array)
            {
                return null;
            }

            var location = jsonValue["result"].ContainsKey("location") ? jsonValue["result"]["location"] : null;
            if (location == null)
            {
                return null;
            }

            if (!location.ContainsKey("lat") || !location.ContainsKey("lng"))
            {
                return null;
            }

            return new Location
                {
                    Lat = location["lat"],
                    Lng = location["lng"]
                };

        }

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
        public double GetDistance(Location locationA, Location locationB, GaussSphere gs)
        {
            var radLat1 = Rad(locationA.Lat);
            var radLat2 = Rad(locationB.Lat);
            var a = radLat1 - radLat2;
            var b = Rad(locationA.Lng) - Rad(locationB.Lng);
            var s = 2 * Math.Asin(Math.Sqrt(Math.Pow(Math.Sin(a / 2), 2) +
             Math.Cos(radLat1) * Math.Cos(radLat2) * Math.Pow(Math.Sin(b / 2), 2)));
            s = s * (gs == GaussSphere.WGS84 ? 6378137.0 : (gs == GaussSphere.Xian80 ? 6378140.0 : 6378245.0));
            s = Math.Round(s * 10000) / 10000;
            return s;
        }

        /// <summary>
        /// The method will 
        /// </summary>
        /// <param name="d">The d</param>
        /// <returns>
        /// The Double
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/4/2013 4:25 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        private double Rad(double d)
        {
            return d * Math.PI / 180.0;
        }
    }
}