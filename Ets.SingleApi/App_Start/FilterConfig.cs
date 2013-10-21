namespace Ets.SingleApi
{
    using System.Web.Mvc;

    /// <summary>
    /// 类名称：FilterConfig
    /// 命名空间：Ets.SingleApi
    /// 类功能：配置Filter
    /// </summary>
    /// 创建者：周超
    /// 创建日期：2013/10/12 10:59
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    public class FilterConfig
    {
        /// <summary>
        /// Registers the global filters.
        /// </summary>
        /// <param name="filters">The filters</param>
        /// 创建者：周超
        /// 创建日期：2013/10/12 10:59
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}