namespace Ets.SingleApi.Caches
{
    using System.Configuration;

    /// <summary>
    /// 类名称：CacheServicesCommon
    /// 命名空间：Ets.SingleApi.Caches
    /// 类功能：缓存服务公用类
    /// </summary>
    /// 创建者：周超
    /// 创建日期：11/21/2013 8:56 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class CacheServicesCommon
    {
        /// <summary>
        /// 购物车缓存时间（分钟）
        /// </summary>
        /// <value>
        /// 购物车缓存时间（分钟）
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/17 22:29
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static int ShoppingCartCacheTime
        {
            get
            {
                var shoppingCartCacheTime = ConfigurationManager.AppSettings["ShoppingCartCacheTime"] ?? "30";
                int result;
                if (!int.TryParse(shoppingCartCacheTime, out result))
                {
                    result = 30;
                }

                return result;
            }
        }

        /// <summary>
        /// 购物车对应的餐厅和用户信息缓存时间（天）
        /// </summary>
        /// <value>
        /// 购物车对应的餐厅和用户信息缓存时间（天）
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/17 22:29
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static int ShoppingCartLongCacheTime
        {
            get
            {
                var shoppingCartLongCacheTime = ConfigurationManager.AppSettings["ShoppingCartLongCacheTime"] ?? "30";
                int result;
                if (!int.TryParse(shoppingCartLongCacheTime, out result))
                {
                    result = 30;
                }

                return result;
            }
        }

        /// <summary>
        /// 购物车缓存关键字前缀
        /// </summary>
        /// <value>
        /// 购物车缓存关键字前缀
        /// </value>
        /// 创建者：周超
        /// 创建日期：2013/10/17 22:59
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static string ShoppingCartCacheKey
        {
            get
            {
                return "shopping_cart";
            }
        }
    }
}
