namespace Ets.SingleApi.Services
{
    using System;
    using System.Json;
    using System.Net;
    using System.Text;
    using System.Web;

    using Ets.SingleApi.Model;
    using Ets.SingleApi.Model.Services;
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
        public LocationType LocationType
        {
            get
            {
                return LocationType.Baidu;
            }
        }

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
            using (var client = new WebClient())
            {
                client.Encoding = Encoding.UTF8;
                var content = client.DownloadString(url);
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
        /// 获取城市名称
        /// </summary>
        /// <param name="location">百度坐标</param>
        /// <returns>
        /// 城市名称
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/4/2013 3:49 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public LocationCity GetLocationCity(Location location)
        {
            if (location == null)
            {
                return new LocationCity();
            }

            var lat = location.Lat;
            var lng = location.Lng;
            var url = string.Format("http://api.map.baidu.com/geocoder?output=json&location={0},{1}&key={2}", lat, lng, ServicesCommon.BaiduMapAk);
            string result;
            using (var client = new WebClient())
            {
                client.Encoding = Encoding.UTF8;
                var content = client.DownloadString(url);
                result = HttpUtility.UrlDecode(content) ?? string.Empty;
            }

            if (result.IsEmptyOrNull())
            {
                return new LocationCity();
            }

            //            {
            //    "status":"OK",
            //    "result":{
            //        "location":{
            //            "lng":116.476824,
            //            "lat":39.904478
            //        },
            //        "formatted_address":"北京市朝阳区百子湾路32号院-南",
            //        "business":"大望路,百子湾,双井",
            //        "addressComponent":{
            //            "city":"北京市",
            //            "district":"朝阳区",
            //            "province":"北京市",
            //            "street":"百子湾路",
            //            "street_number":"32号院-南"
            //        },
            //        "cityCode":131
            //    }
            //}

            var jsonValue = JsonValue.Parse(result);
            if (jsonValue == null || jsonValue["result"] == null)
            {
                return new LocationCity();
            }

            if (!jsonValue["result"].ContainsKey("addressComponent"))
            {
                return new LocationCity();
            }

            var addressComponent = jsonValue["result"]["addressComponent"];
            var address = jsonValue["result"].ContainsKey("formatted_address") ? jsonValue["result"]["formatted_address"] : null;
            var cityCode = jsonValue["result"].ContainsKey("cityCode") ? jsonValue["result"]["cityCode"] : null;
            var city = addressComponent.ContainsKey("city") ? addressComponent["city"] : null;
            var district = addressComponent.ContainsKey("district") ? addressComponent["district"] : null;
            var province = addressComponent.ContainsKey("province") ? addressComponent["province"] : null;
            var street = addressComponent.ContainsKey("street") ? addressComponent["street"] : null;
            var streetNumber = addressComponent.ContainsKey("street_number") ? addressComponent["street_number"] : null;

            return new LocationCity
                {
                    Province = province,
                    CityCode = cityCode.JsonValueToObjectInt(),
                    City = city,
                    District = district,
                    Street = street,
                    StreetNumber = streetNumber,
                    Address = address
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