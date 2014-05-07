namespace Ets.SingleApi.Hosting.Contracts
{
    using System;
    using System.ComponentModel;
    using System.ServiceModel;

    using Ets.SingleApi.Model.Controller;

    /// <summary>
    /// 接口名称：ISupplierService
    /// 命名空间：Ets.SingleApi.Hosting.Contracts
    /// 接口功能：餐厅功能
    /// </summary>
    /// 创建者：周超
    /// 创建日期：12/14/2013 6:20 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    [ServiceContract]
    public interface ISupplierService
    {
        /// <summary>
        /// 计算餐厅打包费
        /// </summary>
        /// <param name="id">餐厅Id</param>
        /// <param name="requst">菜品信息</param>
        /// <returns>
        /// 返回打包费
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/20/2013 2:19 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [OperationContract]
        [Description("方法功能：计算餐厅打包费")]
        Response<decimal> PackagingFee(string id, PackagingFeeRequst requst);

        /// <summary>
        /// 获取餐厅信息
        /// </summary>
        /// <param name="id">餐厅Id</param>
        /// <returns>
        /// The GetSupplierResponse
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/19 23:37
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [OperationContract]
        [Description("方法功能：获取餐厅信息")]
        Response<SupplierDetail> Supplier(string id);

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
        /// 获取餐厅基本信息
        /// </summary>
        /// <param name="id">餐厅Id</param>
        /// <returns>
        /// The GetSupplierResponse
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/19 23:37
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [OperationContract]
        [Description("方法功能：获取餐厅基本信息")]
        Response<SupplierSimple> SupplierSimple(string id);

        /// <summary>
        /// 获取餐厅分店信息
        /// </summary>
        /// <param name="supplierGroupId">集团Id</param>
        /// <param name="featureId">The featureId</param>
        /// <param name="pageSize">每页显示的数量</param>
        /// <param name="pageIndex">页码</param>
        /// <returns>
        /// The GetSupplierResponse
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/19 23:37
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [OperationContract]
        [Description("方法功能：获取餐厅分店信息；参数说明：featureId（-1 or null 所有 1 外卖 2 订台 9 堂食，默认为-1），pageSize（默认值为10）")]
        ListResponse<GroupSupplier> GroupSupplierList(int supplierGroupId, int featureId, int pageSize, string pageIndex);

        /// <summary>
        /// 获取餐厅分店信息
        /// </summary>
        /// <param name="supplierGroupId">集团Id</param>
        /// <param name="userLat">The userLat</param>
        /// <param name="userLong">The userLong</param>
        /// <param name="featureId">The featureId</param>
        /// <param name="cityId">The cityId</param>
        /// <param name="pageSize">每页显示的数量</param>
        /// <param name="pageIndex">页码</param>
        /// <returns>
        /// The GetSupplierResponse
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/19 23:37
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [OperationContract]
        [Description("方法功能：获取餐厅分店信息计算距离（如果传了用户坐标）；参数说明：featureId（-1 or null 所有 1 外卖 2 订台 9 堂食，默认为-1），pageSize（默认值为10）")]
        ListResponse<GroupSupplier> SearchGroupSupplierList(int supplierGroupId, int userLat, int userLong, int featureId, int cityId, int pageSize, int pageIndex);

        /// <summary>
        /// 获取餐厅已经开通的功能列表
        /// </summary>
        /// <param name="id">餐厅Id</param>
        /// <returns>
        /// 返回餐厅已经开通的功能列表
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/15 13:13
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [OperationContract]
        [Description("方法功能：获取餐厅已经开通的功能列表")]
        ListResponse<SupplierFeature> SupplierFeatureList(string id);

        /// <summary>
        /// 获取餐厅菜单
        /// </summary>
        /// <param name="id">餐厅Id</param>
        /// <param name="supplierMenuCategoryTypeId">餐厅菜单类型Id</param>
        /// <returns>
        /// 返回餐厅菜单
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/15 13:24
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [OperationContract]
        [Description("方法功能：获取餐厅菜单；参数说明：supplierMenuCategoryTypeId（1 外卖 2 堂食）")]
        ListResponse<SupplierCuisine> Menu(string id, int supplierMenuCategoryTypeId);

        /// <summary>
        /// 获取赠品菜列表
        /// </summary>
        /// <param name="id">餐厅Id</param>
        /// <returns>
        /// 返回赠品菜列表
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/15 13:24
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [OperationContract]
        [Description("方法功能：获取餐厅赠品菜列表")]
        ListResponse<SupplierDish> PresentDishList(string id);

        /// <summary>
        /// 获取餐厅菜系列表
        /// </summary>
        /// <param name="id">餐厅Id</param>
        /// <param name="supplierMenuCategoryTypeId">餐厅菜单类型Id</param>
        /// <returns>
        /// 返回餐厅菜系列表
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/15 13:24
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [OperationContract]
        [Description("方法功能：获取餐厅菜系列表")]
        ListResponse<SupplierCuisineDetail> SupplierCuisineList(string id, int supplierMenuCategoryTypeId);

        /// <summary>
        /// 获取餐厅菜系
        /// </summary>
        /// <param name="id">餐厅Id</param>
        /// <param name="supplierCategoryId">菜系Id</param>
        /// <returns>
        /// 返回餐厅菜系
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/15 13:24
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [OperationContract]
        [Description("方法功能：获取餐厅菜系")]
        Response<SupplierCuisineDetail> SupplierCuisine(string id, int supplierCategoryId);

        /// <summary>
        /// 添加餐厅菜品
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="requst">The requst</param>
        /// <returns>
        /// SaveSupplierCuisineResponse
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/1/2013 4:37 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [OperationContract]
        [Description("方法功能：添加餐厅菜品")]
        Response<bool> AddSupplierCuisine(string id, SaveSupplierCuisineRequst requst);

        /// <summary>
        /// 修改餐厅菜品
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="requst">The requst</param>
        /// <returns>
        /// SaveSupplierCuisineResponse
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/3/2013 11:33 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [OperationContract]
        [Description("方法功能：修改餐厅菜品")]
        Response<bool> UpdateSupplierCuisine(string id, SaveSupplierCuisineRequst requst);

        /// <summary>
        /// 删除餐厅菜品
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="requst">The requst</param>
        /// <returns>
        /// DeleteSupplierCuisineResponse
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/3/2013 11:48 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [OperationContract]
        [Description("方法功能：删除餐厅菜品")]
        Response<bool> DeleteSupplierCuisine(string id, DeleteSupplierCuisineRequst requst);

        /// <summary>
        /// 获取餐厅菜列表
        /// </summary>
        /// <param name="id">餐厅Id</param>
        /// <param name="supplierMenuCategoryTypeId">餐厅菜单类型Id</param>
        /// <param name="supplierCategoryId">餐厅菜系Id</param>
        /// <returns>
        /// 返回餐厅菜列表
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/15 13:24
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [OperationContract]
        [Description("方法功能：获取餐厅菜列表")]
        ListResponse<SupplierDishDetail> SupplierDishList(string id, int supplierMenuCategoryTypeId, string supplierCategoryId);

        /// <summary>
        /// 获取餐厅菜
        /// </summary>
        /// <param name="id">餐厅Id</param>
        /// <param name="supplierDishId">餐厅菜Id</param>
        /// <returns>
        /// 返回餐厅菜
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/15 13:24
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [OperationContract]
        [Description("方法功能：获取餐厅菜详细信息")]
        Response<SupplierDishDetail> SupplierDish(string id, int supplierDishId);

        /// <summary>
        /// 添加餐厅菜
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="requst">The requst</param>
        /// <returns>
        /// SaveSupplierDishResponse
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/1/2013 4:37 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [OperationContract]
        [Description("方法功能：添加一道菜信息")]
        Response<bool> AddSupplierDish(string id, SaveSupplierDishRequst requst);

        /// <summary>
        /// 修改餐厅菜
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="requst">The requst</param>
        /// <returns>
        /// SaveSupplierDishResponse
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/3/2013 11:33 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [OperationContract]
        [Description("方法功能：修改餐厅菜信息")]
        Response<bool> UpdateSupplierDish(string id, SaveSupplierDishRequst requst);

        /// <summary>
        /// 删除餐厅菜
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="requst">The requst</param>
        /// <returns>
        /// DeleteSupplierCuisineResponse
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/3/2013 11:48 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [OperationContract]
        [Description("方法功能：删除一道菜信息")]
        Response<bool> DeleteSupplierDish(string id, DeleteSupplierDishRequst requst);

        /// <summary>
        /// 取得餐厅营业时间
        /// </summary>
        /// <param name="id">餐厅Id</param>
        /// <param name="startDate">开始日期</param>
        /// <param name="days">天数</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：12/2/2013 11:40 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [OperationContract]
        [Description("方法功能：取得餐厅营业时间")]
        ListResponse<SupplierServiceTime> SupplierServiceTime(string id, string startDate, string days);

        /// <summary>
        /// 取得餐厅送餐时间
        /// </summary>
        /// <param name="id">餐厅Id</param>
        /// <param name="startDate">开始日期</param>
        /// <param name="days">天数</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：周超
        /// 创建日期：12/2/2013 11:40 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [OperationContract]
        [Description("方法功能：取得餐厅送餐时间")]
        ListResponse<SupplierDeliveryTime> SupplierDeliveryTime(string id, string startDate, string days);

        /// <summary>
        /// 计算距离
        /// </summary>
        /// <param name="userLat"></param>
        /// <param name="userLong"></param>
        /// <param name="id"></param>
        /// <returns>
        /// 距离
        /// </returns>
        /// 创建者：周超
        /// 创建日期：11/4/2013 3:49 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [OperationContract]
        [Description("方法功能：计算距离")]
        Response<DistanceResult> GetDistance(string id, double userLat, double userLong);

        /// <summary>
        /// 获取订台台位列表
        /// </summary>
        /// <param name="id">餐厅Id</param>
        /// <param name="bookingDate">预订日期</param>
        /// <param name="bookingTime">预订时间</param>
        /// <param name="peopleCount">预定人数</param>
        /// <returns></returns>
        /// 创建者：苏建峰
        /// 创建日期：3/18/2014 5:53 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [OperationContract]
        [Description("方法功能：获取订台台位列表")]
        ListResponse<DingTaiDesk> DeskList(string id, DateTime bookingDate, string bookingTime, int peopleCount);

        /// <summary>
        /// 获取餐厅订台开放时间列表
        /// </summary>
        /// <param name="id">餐厅Id</param>
        /// <param name="bookingDate">预订时间</param>
        /// <returns></returns>
        /// 创建者：苏建峰
        /// 创建日期：3/20/2014 2:40 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [OperationContract]
        [Description("方法功能：获取餐厅订台开放时间列表")]
        ListResponse<string> DeskOpenTimeList(string id, DateTime bookingDate);

        /// <summary>
        /// 获取餐厅订台开放日期列表
        /// </summary>
        /// <param name="id">餐厅Id</param>
        /// <param name="days">The days</param>
        /// <returns>
        /// ListResponse{DeskOpenDate}
        /// </returns>
        /// 创建者：苏建峰
        /// 创建日期：3/22/2014 7:14 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [OperationContract]
        [Description("方法功能：获取餐厅订台开放日期列表")]
        ListResponse<DeskOpenDate> DeskOpenDateList(string id, int days);

        /// <summary>
        /// 查检订台台位是否被锁
        /// </summary>
        /// <param name="id">餐厅Id</param>
        /// <param name="requst">The requst.</param>
        /// <returns></returns>
        /// 创建者：苏建峰
        /// 创建日期：3/22/2014 11:11 AM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [OperationContract]
        [Description("方法功能：查检订台台位是否被锁")]
        Response<bool> CheckDesk(string id, CheckDeskRequst requst);

        /// <summary>
        /// 检查桌号是否有效
        /// </summary>
        /// <param name="supplierId">餐厅Id</param>
        /// <param name="tableNo">桌号</param>
        /// <returns>
        /// 返回结果
        /// </returns>
        /// 创建者：单琪彬
        /// 创建日期：3/24/2014 1:21 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [OperationContract]
        [Description("方法功能：检查桌号是否有效")]
        Response<bool> CheckTableNumIsEffective(int supplierId, string tableNo);

        /// <summary>
        /// 根据桌子Id查询桌子编号
        /// </summary>
        /// <param name="supplierId">The supplierId</param>
        /// <param name="tableNo">The tableNo</param>
        /// <returns>
        /// String}
        /// </returns>
        /// 创建者：单琪彬
        /// 创建日期：3/25/2014 1:36 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [OperationContract]
        [Description("方法功能：根据桌子Id查询桌子编号")]
        Response<string> GetDeskNoById(int supplierId, int tableNo);

        /// <summary>
        /// 查询推荐菜品列表
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>
        /// 推荐菜品列表
        /// </returns>
        /// 创建者：单琪彬
        /// 创建日期：3/27/2014 3:31 PM
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [OperationContract]
        [Description("方法功能：获取订台台位列表")]
        ListResponse<SupplierRecommendedDish> GetRecommendedDishList(string id, int pageIndex, int pageSize);
    }
}