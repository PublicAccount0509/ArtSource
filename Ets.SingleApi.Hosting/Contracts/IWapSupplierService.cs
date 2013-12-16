namespace Ets.SingleApi.Hosting.Contracts
{
    using System.ComponentModel;
    using System.ServiceModel;

    using Ets.SingleApi.Model.Controller;

    /// <summary>
    /// 接口名称：IWapSupplierService
    /// 命名空间：Ets.SingleApi.Hosting.Contracts
    /// 接口功能：WapSupplier服务
    /// </summary>
    /// 创建者：周超
    /// 创建日期：12/14/2013 6:38 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    [ServiceContract]
    public interface IWapSupplierService
    {
        /// <summary>
        /// 根据餐厅域名获取餐厅信息
        /// </summary>
        /// <param name="supplierDomain">餐厅域名</param>
        /// <returns>
        /// 返回餐厅信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/19 23:37
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [OperationContract]
        [Description("方法功能：根据餐厅域名获取餐厅信息")]
        Response<RoughSupplier> RoughSupplier(string supplierDomain);

        /// <summary>
        /// 获取餐厅列表
        /// </summary>
        /// <param name="supplierName">餐厅名称</param>
        /// <param name="regionId">省、市、区Id</param>
        /// <param name="userLat">用户经度</param>
        /// <param name="userLong">用户纬度</param>
        /// <param name="distance">距离</param>
        /// <param name="pageSize">每页显示的数量</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="buildingLat">楼宇经度</param>
        /// <param name="buildingLong">楼宇纬度</param>
        /// <returns>
        /// 返回餐厅列表
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/15 17:49
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [OperationContract]
        [Description("方法功能：搜索餐厅列表；参数说明：pageSize（默认值为10）；返回结果：餐厅列表")]
        ListResponse<Supplier> SearchSupplierList(
            string supplierName,
            string regionId,
            string userLat,
            string userLong,
            string distance,
            int pageSize,
            string pageIndex,
            string buildingLat,
            string buildingLong);

        /// <summary>
        /// 获取餐厅列表
        /// </summary>
        /// <param name="cuisineId">菜品</param>
        /// <param name="businessAreaId">商圈Id</param>
        /// <param name="regionId">省、市、区Id</param>
        /// <param name="userLat">经度</param>
        /// <param name="userLong">纬度</param>
        /// <param name="distance">距离</param>
        /// <param name="pageSize">每页显示的数量</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="orderByType">排序规则</param>
        /// <returns>
        /// 返回餐厅列表
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/15 17:49
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [OperationContract]
        [Description("方法功能：取得用户附近餐厅列表；参数说明：pageSize（默认值为10）、orderByType（0 默认排序  1 离我最近  2 离我最远  3 最新上线  4 价格最低  5 价格最高）；返回结果：餐厅列表")]
        ListResponse<Supplier> NearSupplierList(
            string cuisineId,
            string regionId,
            string businessAreaId,
            string userLat,
            string userLong,
            string distance,
            int pageSize,
            string pageIndex,
            int orderByType);

        /// <summary>
        /// 获取外卖餐厅列表
        /// </summary>
        /// <param name="cuisineId">菜品</param>
        /// <param name="businessAreaId">商圈Id</param>
        /// <param name="regionId">省、市、区Id</param>
        /// <param name="userLat">经度</param>
        /// <param name="userLong">纬度</param>
        /// <param name="distance">距离</param>
        /// <param name="pageSize">每页显示的数量</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="orderByType">排序规则</param>
        /// <returns>
        /// 返回外卖餐厅列表
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/15 17:49
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [OperationContract]
        [Description("方法功能：取得外卖餐厅列表；参数说明：pageSize（默认值为10）、orderByType（0 默认排序  1 离我最近  2 离我最远  3 最新上线  4 价格最低  5 价格最高）；返回结果：餐厅列表")]
        ListResponse<Supplier> WaiMaiSupplierList(
            string cuisineId,
            string regionId,
            string businessAreaId,
            string userLat,
            string userLong,
            string distance,
            int pageSize,
            string pageIndex,
            int orderByType);

        /// <summary>
        /// 获取订台餐厅列表
        /// </summary>
        /// <param name="cuisineId">菜品</param>
        /// <param name="businessAreaId">商圈Id</param>
        /// <param name="regionId">省、市、区Id</param>
        /// <param name="userLat">经度</param>
        /// <param name="userLong">纬度</param>
        /// <param name="distance">距离</param>
        /// <param name="pageSize">每页显示的数量</param>
        /// <param name="pageIndex">页码</param>
        /// <param name="orderByType">排序规则</param>
        /// <returns>
        /// 返回订台餐厅列表
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/15 17:49
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        // [OperationContract]
        [Description("方法功能：取得订台餐厅列表；参数说明：pageSize（默认值为10）、orderByType（0 默认排序  1 离我最近  2 离我最远  3 最新上线  4 价格最低  5 价格最高）；返回结果：餐厅列表")]
        ListResponse<Supplier> DingTaiSupplierList(
            string cuisineId,
            string regionId,
            string businessAreaId,
            string userLat,
            string userLong,
            string distance,
            int pageSize,
            string pageIndex,
            int orderByType);
    }
}