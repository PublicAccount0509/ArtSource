namespace Ets.SingleApi.Hosting.Contracts
{
    using System.Collections.Generic;

    using Ets.SingleApi.Model;
    using Ets.SingleApi.Model.Services;
    using Ets.SingleApi.Model.Controller;
    using System.ServiceModel;
    using System.EnterpriseServices;

    /// <summary>
    /// 接口名称：IHuangTaiJiSupplierService
    /// 命名空间：Ets.SingleApi.Hosting.Contracts
    /// 接口功能：黄太极餐厅服务
    /// </summary>
    /// 创建者：殷超
    /// 创建日期：12/25/2013 11:49 PM
    /// 修改者：
    /// 修改时间：
    /// ----------------------------------------------------------------------------------------
    [ServiceContract]
    public interface IHuangTaiJiSupplierService
    {
        /// <summary>
        /// 获取餐厅菜单列表
        /// </summary>
        /// <param name="id">餐厅Id</param>
        /// <param name="supplierMenuCategoryTypeId">餐厅菜单类型Id</param>
        /// <param name="supplierCategoryId">餐厅菜系Id</param>
        /// <returns>
        /// 返回餐厅菜单列表
        /// </returns>
        /// 创建者：殷超
        /// 创建日期：2013/12/25 13:24
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        [OperationContract]
        [Description("方法功能：获取餐厅菜单列表；参数说明：supplierMenuCategoryTypeId（1 外卖 2 堂食）")]
        ListResponse<HuangTaiJiSupplierCuisine> SupplierDishList(string id, int supplierMenuCategoryTypeId, int supplierCategoryId);

        /// <summary>
        /// 获取餐厅菜
        /// </summary>
        /// <param name="id">餐厅Id</param>
        /// <param name="supplierDishId">餐厅菜Id</param>
        /// <returns>
        /// 返回餐厅菜
        /// </returns>
        /// 创建者：殷超
        /// 创建日期：2013/12/25 13:24
        /// 修改者：
        /// 修改时间：
        /// ----------------------------------------------------------------------------------------
        /// [OperationContract]
        /// [Description("方法功能：获取餐厅菜单；参数说明：supplierMenuCategoryTypeId（1 外卖 2 堂食）")]
        /// Response<HuangTaiJiSupplierDishDetail> SupplierDish(string id, int supplierDishId);

    }
}
