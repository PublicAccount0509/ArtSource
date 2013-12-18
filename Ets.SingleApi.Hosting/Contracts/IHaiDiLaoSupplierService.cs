namespace Ets.SingleApi.Hosting.Contracts
{
    using System.ComponentModel;
    using System.ServiceModel;

    using Ets.SingleApi.Model.Controller;

    /// <summary>
    /// 接口名称：IHaiDiLaoSupplierService
    /// 命名空间：Ets.SingleApi.Hosting.Contracts
    /// 接口功能：海底捞餐厅服务
    /// </summary>
    /// 创建者：周超
    /// 创建日期：12/9/2013 3:06 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    [ServiceContract]
    public interface IHaiDiLaoSupplierService
    {
        /// <summary>
        /// 获取海底捞餐厅菜单
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
        [Description("方法功能：获取海底捞餐厅菜单")]
        ListResponse<SupplierCuisine> Menu(string id, int supplierMenuCategoryTypeId);

        /// <summary>
        /// 获取套餐详细信息
        /// </summary>
        /// <param name="id">餐厅Id</param>
        /// <param name="packageId">套餐Id</param>
        /// <returns>
        /// 返回套餐详细信息
        /// </returns>
        /// 创建者：周超
        /// 创建日期：2013/10/15 13:24
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [OperationContract]
        [Description("方法功能：获取套餐详细信息")]
        ListResponse<PackageCuisine> PackageDetail(string id, int packageId);
    }
}