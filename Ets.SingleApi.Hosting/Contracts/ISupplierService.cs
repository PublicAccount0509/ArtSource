namespace Ets.SingleApi.Hosting.Contracts
{
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
    }
}